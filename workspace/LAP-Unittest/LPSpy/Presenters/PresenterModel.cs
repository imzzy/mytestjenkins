using LAPResources;
using LPReplayCore;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LPReplayCore.Web;
using LPUIAObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace LPSpy
{
    public interface IPresenterModelView
    {
        void SetPresenter(PresenterModel presenterModel);
    }

    public interface IMainWindowView: IPresenterModelView
    {
        void SetStatusText(string status);

        INodeView NodeViewControl { get; }

        IModelTreeView ModelTreeControl { get; }
    }

    public interface IModelTreeView: IPresenterModelView
    {
        TreeView GetTreeView();

        void DeleteSelectedNode();
    }

    public interface INodeView: IPresenterModelView
    {
        void NodeChanged(TestObjectNurse nurseObject);
        void SetSelectNodeName(string name);
    }

    /// <summary>
    /// Presenter model for App Model
    /// </summary>
    public class PresenterModel: IDisposable
    {
        public IModelTreeView _modelTreeView;
        public INodeView _nodeView;
        public IMainWindowView _mainView;

        public PresenterModel(IMainWindowView mainView)
        {
            UIAFinder.StatusUpdate += this.ElementFindStatusChange;
            BindMainWindowView(mainView);
            BindModelTreeView(mainView.ModelTreeControl);
            BindNodeView(mainView.NodeViewControl);
        }

        private void ElementFindStatusChange(UIATestObject testObject, ElementFindingStatusEnum findStatus)
        {
            string statusText = null;

            switch (findStatus)
            {
                case ElementFindingStatusEnum.Searching:
                    statusText = string.Format(StringResources.LPSpy_SpyMainWindow_IdentifyingFormat, testObject.NodeName);
                    break;
                case ElementFindingStatusEnum.Found:
                    statusText = string.Format(StringResources.LPSpy_SpyMainWindow_FoundFormat, testObject.NodeName);
                    break;
                case ElementFindingStatusEnum.NotFound:
                    statusText = string.Format(StringResources.LPSpy_SpyMainWindow_CannotfindFormat, testObject.NodeName);
                    break;
            }

            SetStatusText(statusText);
        }

        private void SetStatusText(string statusText)
        {
            _mainView.SetStatusText(statusText);
        }

        public void BindModelTreeView(IModelTreeView modelTreeView)
        {
            modelTreeView.SetPresenter(this);
            _modelTreeView = modelTreeView;
        }

        public void BindNodeView(INodeView nodeView)
        {
            nodeView.SetPresenter(this);
            _nodeView = nodeView;
        }

        public void BindMainWindowView(IMainWindowView mainView)
        {
            mainView.SetPresenter(this);
            _mainView = mainView;
        }


        public void SetSelectNodeName(string newName)
        {
            _nodeView.SetSelectNodeName(newName);
        }
        
        public delegate void ModelChangedDelegate();

        public event ModelChangedDelegate ModelChanged;


        public void CaptureSnapshot(TestObjectNurse nurseObject)
        {
            string token = null;

            UIATestObject testObject = nurseObject.TestObject as UIATestObject;
            if (testObject == null) return; //not the UIA object

            AutomationElement element = testObject.AutomationElement;

            if (SpySettings.CaptureSnapshots)
            {
                try
                {
                    //capture snapshot of clicked area
                    SnapshotHelper.CaptureTempSnapshot(element, out token);
                }
                catch (ElementNotAvailableException)
                {
                    MessageBox.Show(StringResources.LPSpy_SpyMainWindow_CannotFindObjectMsg);
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            nurseObject.ImageFile = SnapshotHelper.GetCachedSnapshot(token, nurseObject.ImageFile);
            

            AppEnvironment.SetModelChanged(true);
        }

        private void HighlightObjectThread(object param)
        {
            try
            {
                TestObjectNurse nurseObject = param as TestObjectNurse;
                if (nurseObject == null) return;

                ITestObject testObject = nurseObject.TestObject;

                SetStatusText(StringResources.LPSpy_SpyMainWindow_Identifying);


                //Check whether the WebDriver Host exist or not
                if (testObject.ControlTypeString.StartsWith("Web"))
                {
                    SETestObject seTestObject = testObject as SETestObject;
                    if (seTestObject.SEWebElement == null)
                    {
                        //look for WebPage
                        TreeNode parentNode = nurseObject.TreeNode;
                        ITestObject parentObject = null;


                        do
                        {
                            parentObject = TestObjectNurse.FromTreeNode(parentNode).TestObject;
                            if (parentObject.ControlTypeString.Equals("WebPage"))
                            {
                                //seTestObject = parentObject as SETestObject;
                                break;
                            }
                        }
                        while (null != (parentNode = parentNode.Parent));

                        if (null != parentObject)
                        {
                            //check the WebDriverHost existing
                            if (null == _webDriverHost)
                            {
                                _webDriverHost = new WebDriverHost();
                                _webDriverHost.GotoUrl(parentObject.Properties[WebControlKeys.URL]);
                            }
                            else
                            {
                                _webDriverHost.SwithToURL(parentObject.Properties[WebControlKeys.URL]);
                            }
                            WebRefreshNodeTag(parentNode);
                        }
                    }

                    Rectangle rc = _webDriverHost.GetElementRectangle(seTestObject);

                    UIAHighlight.HighlightRect(rc);
                    return;
                }


                if (!UIAHighlight.SearchAndHighlight(testObject))
                {
                    MessageBox.Show(StringResources.LPSpy_SpyMainWindow_CannotFindObjectMsg);
                }
            }
            finally
            {
                SetStatusText("");
            }
        }

        public WebDriverHost GetWebDriverHost()
        {
            return _webDriverHost;
        }


        private void WebRefreshNodeTag(TreeNode node)
        {
            SETestObject seTestObject = TestObjectNurse.FromTreeNode(node).TestObject as SETestObject;
            seTestObject.WebDriver = _webDriverHost.WebDriver;
            foreach (TreeNode node0 in node.Nodes)
                WebRefreshNodeTag(node0);
        }
            
        internal void Highlight(TestObjectNurse selectedNode = null)
        {
            selectedNode = selectedNode ?? _selectedObject;
            if (selectedNode == null)
            {
                MessageBox.Show(StringResources.LPSpy_SpyMainWindow_SelNodeWarningMsg);
                return;
            }
            else
            {
                Thread thread = new Thread(HighlightObjectThread);

                if (selectedNode != null)
                {
                    thread.Start(selectedNode);
                }
            }
        }

        internal void EditVirtualControl(TestObjectNurse nurseObject)
        {

            if (nurseObject.ControlTypeString == NodeType.VirtualControl)
            {
                nurseObject = nurseObject.ParentNurse;

                Debug.Assert(nurseObject.TestObject is UIATestObject);
            }

            if (nurseObject.ImageFile == null)
            {
                //"Please capture the screen shot of the control before editing virtual controls"
                MessageBox.Show(StringResources.LPSpy_SpyMainWindow_CaptureSnapshotFirst);
                return;
            }

            string imagePath = AppEnvironment.GetModelResourceFilePath(nurseObject.ImageFile);

            VirtualTestObject[] virtualControls = VirtualControlHelper.GetVirtualControls(nurseObject.TestObject);

            System.Drawing.Image controlImage = System.Drawing.Image.FromFile(imagePath);

            UIATestObject testObject = (UIATestObject)nurseObject.TestObject;

            bool changed = VirtualControlHelper.EditVirtualControls(testObject, controlImage, ref virtualControls);

            if (changed)
            {
                VirtualTestObject[] updatedControls = virtualControls;

                bool different = TreeNodeHelper.MergeVirtualControlsToTree(updatedControls, nurseObject.TreeNode);

                nurseObject.TreeNode.Expand();

                if (different)
                {
                    AppEnvironment.SetModelChanged(true);
                }
            }
        }

        TestObjectNurse _selectedObject;

        internal void SelectNodeChanged(TestObjectNurse nurseObject)
        {
            _selectedObject = nurseObject;
            _nodeView.NodeChanged(nurseObject);
        }

        private WebDriverHost _webDriverHost = null;     
        
        internal void LaunchWebDriverHost()
        {
             if (_webDriverHost != null) _webDriverHost.Dispose();
             _webDriverHost = new WebDriverHost();
        }

        internal void DeleteNode()
        {
            _modelTreeView.DeleteSelectedNode();
        }

        TestObjectNurse RootNurseObject
        {
            get
            {
                return TestObjectNurse.FromTree(GetTreeView());
            }
        }

        /// <summary>
        /// create a new empty model
        /// </summary>
        /// <param name="filePath"></param>
        internal void NewModel(string filePath)
        {
            RootNurseObject.Clear();

            _nodeView.NodeChanged(null);

            AppEnvironment.CurrentModelPath = filePath;
            AppEnvironment.SetModelChanged(false);
        }

        internal bool DlgOpenModelFile()
        {
            return ModelFileHandler.DlgLoadModelFile(_modelTreeView.GetTreeView());
        }

        internal bool SaveModel()
        {
            return SpyWindowHelper.Save(RootNurseObject);
        }

        internal void MergeTree(ITestObject rootObject, ITestObject selfObject, ITestObject leftObject, ITestObject rightObject)
        {
            TreeMerger treeMerger = new TreeMerger(_modelTreeView.GetTreeView(),
                AppEnvironment.SetModelChanged, this.UpdateNodePropertyCompleteHandler
                );

            treeMerger.StartToUpdate(rootObject, selfObject, leftObject, rightObject);
        }

        public TreeView GetTreeView()
        {
            return _modelTreeView.GetTreeView();
        }

        private void UpdateNodePropertyCompleteHandler(ResultType result)
        {
            if (ResultType.OK == result)
            {
                AppEnvironment.SetModelChanged(true);
                
                //TODO Is this necessary?
                //SelectedNodesChanged(_selectedNode);
            }
            else if (ResultType.NotSameControlType == result)
            {
                MessageBox.Show(StringResources.LPSpy_SpyMainWindow_RefreshobjNotMatchWarningMsg,
                    StringResources.LPSpy_SpyMainWindow_RefreshobjWarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        public void Dispose()
        {
            if (_webDriverHost != null)
            {
                _webDriverHost.Dispose();
            }
        }


        internal void UpdateSelNode(ElementProperties elementProperties, string snapshotPath)
        {
            TreeMerger treeMerger = new TreeMerger(_modelTreeView.GetTreeView(),
                 AppEnvironment.SetModelChanged, this.UpdateNodePropertyCompleteHandler
                 );

            treeMerger.UpdateSelNode(elementProperties, snapshotPath);
        }

        internal void Init()
        {
            
        }
    }
}
