using LPSpy.UIA;
using LPUIAObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using LPReplayCore.Common;
using LPReplayCore.UIA;
using LPReplayCore;
using System.Runtime.InteropServices;
using LAPResources;
using LPCommon;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;


namespace LPSpy
{

    public delegate void TreeUpdatedDelegate(ITestObject rootObject, ITestObject selfObject,
        ITestObject leftObject, ITestObject rightObject);

    public delegate void TreeNodeUpdatedDelegate(ElementProperties elementProperties, string snapshotPath);

    public enum AddObjWndModeType
    {
        Normal = 1,
        UpdateProperties,
    }
    public partial class AddObjectsWindow : Form
    {
        ElementSpyer spyer;

        public ElementProperties _leftElement, _rightElement, _selfElement;

        public TreeUpdatedDelegate UpdateSelectedTree;

        public TreeNodeUpdatedDelegate UpdateSelectedNode;

        public PropertiesListview propertiesListview;

        private AddObjWndModeType _modeType = AddObjWndModeType.Normal;

        //form's own Owner property will be reset to null when hide, therefore need to use our own
        private Form _owner;

        public AddObjectsWindow(Form owner, AddObjWndModeType ModeType = AddObjWndModeType.Normal)
        {
            spyer = new ElementSpyer();
            this._owner = owner;
            spyer.SpyEnd += ((successful) => {
                if (this._owner != null) this._owner.BeginInvoke(new Action(() => { this._owner.Visible = true; })); 
                if (successful) { this._owner.BeginInvoke(new Action(() => { this.Visible = true; })); } else this.Close();
            });
            spyer.PointCaptured += this.PointToSpiedData;
            InitializeComponent();
            _modeType = ModeType;
            objectTree.ImageList = TreeNodeHelper.TreeImageList;
            if (_modeType == AddObjWndModeType.UpdateProperties)
                objectTree.CheckBoxes = false;
            else
                objectTree.CheckBoxes = true;

            propertiesListview = new PropertiesListview(this.listView1);
            propertiesListview.Init();
        }


        string _token;

        private void PointToSpiedData(Point mousePoint)
        {
            try
            {
                AutomationElement clickedElement = AutomationElement.FromPoint(mousePoint);
                
                WebDriverHost webDriverHost = this.Tag as WebDriverHost;
                if ( null != webDriverHost && clickedElement.Current.ClassName.Equals("Chrome_RenderWidgetHostHWND"))
                {
                    System.Drawing.Point point = new System.Drawing.Point((int)mousePoint.X, (int)mousePoint.Y);
                    webDriverHost.CheckWindowHandle(clickedElement);

                   // RemoteWebElement webElement = webDriverHost.FindElementByPoint(point) as RemoteWebElement;

                   /* if (SpySettings.CaptureSnapshots && null != webElement)
                    {
                        //capture snapshot of clicked area
                        SnapshotHelper.CaptureTempSnapshot(webElement, out _token);
                    }*/
                  //  WebUtility.GetElementScreenRect(webElement);
                   // UIAHighlight.HighlightRect( WebUtility.GetElementScreenRect(webElement));
               //     webDriverHost.HighlightWebElement(webElement);
               //     ConstructElementsTree(webElement);

                   /* List<RemoteWebElement> webElements = webDriverHost.GenerateElementsLineByPoint(point);

                    TreeNodesFromAutomationElements(webElements);*/
                    System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty;
                    List<WebElementProperties> webElementProperiesList = webDriverHost.GenerateElementPropertiesLineByPoint(point);
                    if ( webElementProperiesList.Count > 0 ) {
                        WebElementProperties webElementProperties = webElementProperiesList[webElementProperiesList.Count - 1];
                        rect = webDriverHost.GetElementRectangle(webElementProperties);
                        UIAHighlight.HighlightRect(rect);
                    }
                    TreeNodesFromWebElementProperties(webDriverHost.GenerateElementPropertiesLineByPoint(point));
                    //webDriverHost.GetElementRectangle()
                   // UIAHighlight.HighlightRect(WebUtility.GetElementScreenRect(webDriverHost.WebSelectElement));
                    if (SpySettings.CaptureSnapshots && !rect.IsEmpty)
                    {
                        //capture snapshot of clicked area

                        SnapshotHelper.CaptureTempSnapshot(rect, out _token);
                    }
                

                    this.objectTree.ExpandAll();
                    return;
                }
                
                


                ConstructElementsTree(clickedElement);

                _token = null;

                if (SpySettings.CaptureSnapshots)
                {
                    //capture snapshot of clicked area
                    SnapshotHelper.CaptureTempSnapshot(clickedElement, out _token);
                }
            }
            catch (ElementNotAvailableException)
            {
                //Element is no longer available, please reselect the element
                MessageBox.Show(StringResources.LPSpy_ElementNotAvailableException);
            }
        }


        private void ConstructElementsTree(AutomationElement clickedElement)
        {
            this.objectTree.Nodes.Clear();

            if (clickedElement == null) return;
            
            UIAHighlight.HighlightThread_Spy(clickedElement);

            List<AutomationElement> elements = UIAUtility.GetAutomationElementsLine(clickedElement);

            TreeNodesFromAutomationElements(elements);

            if (_modeType == AddObjWndModeType.Normal)
           	    ConstructLeftAndRightNode(objectTree, clickedElement);

            this.objectTree.ExpandAll();
        }

        private void ConstructElementsTree(RemoteWebElement webElement)
        {
            this.objectTree.Nodes.Clear();

            if (webElement == null) return;

           // UIAHighlight.HighlightThread_Spy(clickedElement);

          //  List<AutomationElement> elements = UIAUtility.GetAutomationElementsLine(clickedElement);
            WebDriverHost webBrowerWrapper = this.Tag as WebDriverHost;
             List<RemoteWebElement> webElements = webBrowerWrapper.GenerateWebElementsLine(webElement);

            
             TreeNodesFromAutomationElements(webElements);

           // if (_modeType == AddObjWndModeType.Normal)
           //     ConstructLeftAndRightNode(objectTree, clickedElement);

            this.objectTree.ExpandAll();
        }


        private void TreeNodesFromWebElementProperties(List<WebElementProperties> webElementPropertiesList)
        {
            if (null == webElementPropertiesList || 0 == webElementPropertiesList.Count) return;
            TreeNodeCollection currentNodes = this.objectTree.Nodes;
            TreeNode tempNode = null;

            int index = 0;
            foreach (WebElementProperties webElementProperties in webElementPropertiesList)
            {
                tempNode = currentNodes.Add(index.ToString(), webElementProperties.Name);
                tempNode.Tag = webElementProperties;
                TreeNodeHelper.FixTreeNodeImage(tempNode, "Custom");
                currentNodes = tempNode.Nodes;
                tempNode.Checked = true;
            }

            TreeNode currentNode = tempNode;
            currentNode.Name = "self";
            currentNode.Checked = true;
            objectTree.SelectedNode = currentNode;
        }
        private void TreeNodesFromAutomationElements(List<RemoteWebElement> webElements)
        {
            TreeNodeCollection currentNodes = this.objectTree.Nodes;
            TreeNode tempNode = null;

            int index = 0;
            foreach (RemoteWebElement webelement in webElements)
            {
                WebElementProperties webElementProperties = new WebElementProperties(webelement);
                if (string.IsNullOrEmpty(webElementProperties.ControlTypeString))
                   continue;
                tempNode = currentNodes.Add(index.ToString(), webElementProperties.Name);
                tempNode.Tag = webElementProperties;
                TreeNodeHelper.FixTreeNodeImage(tempNode, "Button");
                currentNodes = tempNode.Nodes;
                tempNode.Checked = true;
            }

            TreeNode currentNode = tempNode;
            currentNode.Name = "self";
            currentNode.Checked = true;
            objectTree.SelectedNode = currentNode;

           // _selfElement = (ElementProperties)currentNode.Tag;
        }


    

        /// <summary>
        /// bind the tree node and the UIACondition object
        /// </summary>
        /// <param name="node"></param>
        /// <param name="condition"></param>
        private void Associate(TreeNode node, ElementProperties elementProperties)
        {
            node.Tag = elementProperties;
        }

        private void ConstructLeftAndRightNode(TreeView objectTree, AutomationElement clickedElement)
        {
            TreeNode parentNode = null, leafNode;
            leafNode = objectTree.Nodes[0];

            while (leafNode.Nodes.Count > 0)
            {
                parentNode = leafNode;
                leafNode = leafNode.Nodes[0];
            }

            AutomationElement leftElement = UIAUtility.GetPreviousElement(clickedElement);
            AutomationElement rightElement = UIAUtility.GetNextElement(clickedElement);

            TreeNode tempNode = null;

            if (parentNode == null) return;

            //TreeNodeCollection nodes = (parentNode == null) ? objectTree.Nodes : parentNode.Nodes;
            if (leftElement != null)
            {
                _leftElement = new ElementProperties(leftElement);
                tempNode = parentNode.Nodes.Insert(0, "left", StringResources.LPSpy_AddObjectsWindow_LeftObject + _leftElement.DerivedName);
                _leftElement.SetContext(tempNode);
                tempNode.Tag = new ElementProperties(leftElement);
            }

            if (rightElement != null)
            {
                _rightElement = new ElementProperties(rightElement);
                tempNode = parentNode.Nodes.Add("right", StringResources.LPSpy_AddObjectsWindow_RightObject + _rightElement.DerivedName);
                _rightElement.SetContext(tempNode);
                tempNode.Tag = new ElementProperties(rightElement);
            }
        }

        private void TreeNodesFromAutomationElements(List<AutomationElement> elementsLine)
        {
            TreeNodeCollection currentNodes = this.objectTree.Nodes;
            TreeNode tempNode = null;

            int index = 0;
            foreach (AutomationElement element in elementsLine)
            {
                string controlType = element.Current.ControlType.ControlTypeToString();

                ElementProperties elementProperties = new ElementProperties(element);

                string displayName = controlType + ": " + elementProperties.DerivedName;
                tempNode = currentNodes.Add(index.ToString(), displayName);
                tempNode.Tag = elementProperties;
                TreeNodeHelper.FixTreeNodeImage(tempNode, controlType);

                currentNodes = tempNode.Nodes;

                if (!string.IsNullOrEmpty(element.Current.Name))
                    tempNode.Checked = true;
            }

            TreeNode currentNode = tempNode;
            currentNode.Name = "self";
            currentNode.Checked = true;
            objectTree.SelectedNode = currentNode;

            _selfElement = (ElementProperties)currentNode.Tag;
        }

        private void btnAddObject_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this._owner.Visible = true;
            
            if ( this._modeType == AddObjWndModeType.Normal && this.UpdateSelectedTree != null)
            {
                TestObjectNurse selfNurse = GetNurseObjectsLine(objectTree);

                TestObjectNurse leftNurse = null, rightNurse = null;

                if (_leftElement != null)
                {
                    TreeNode node = _leftElement.GetContext<TreeNode>();
                    if (node.Checked)
                    {
                        leftNurse = _leftElement.ToNurseObject();
                    }
                }
                if (_rightElement != null)
                {
                    TreeNode node = _rightElement.GetContext<TreeNode>();
                    if (node.Checked)
                    {
                        rightNurse = _rightElement.ToNurseObject();
                    }
                }

                selfNurse.ImageFile = SnapshotHelper.GetCachedSnapshot(_token);

                TestObjectNurse rootNurse;
                TestObjectNurse temp;
                temp = selfNurse;
                do
                {
                    rootNurse = temp;
                    temp = rootNurse.ParentNurse;

                } while (temp != null);

                UpdateSelectedTree(rootNurse, selfNurse, leftNurse, rightNurse);
            }

            if (this._modeType == AddObjWndModeType.UpdateProperties && this.UpdateSelectedNode != null)
            {
                ElementProperties elementProperties = null;
                if (this.objectTree.SelectedNode != null &&
                    null != (elementProperties = objectTree.SelectedNode.Tag as ElementProperties))
                {
                    if (SpySettings.CaptureSnapshots)
                    {
                        //capture snapshot of clicked area
                        SnapshotHelper.CaptureTempSnapshot(elementProperties.AutomationElement, out _token);
                    }
                    UpdateSelectedNode(elementProperties, SnapshotHelper.GetCachedSnapshot(_token));
                }
                else
                {
                    UpdateSelectedNode(_selfElement, SnapshotHelper.GetCachedSnapshot(_token));
                }

            }


            this.Dispose();
        }


        /// <summary>
        /// return the selfCondition
        /// </summary>
        /// <param name="treeView"></param>
        /// <returns></returns>
        private TestObjectNurse GetNurseObjectsLine(TreeView treeView)
        {
            TreeNode fromNode = treeView.Nodes[0];

            IElementProperties properties = (IElementProperties)fromNode.Tag;

            TestObjectNurse topNurseNode = properties.ToNurseObject();
            TestObjectNurse currentNurseNode = topNurseNode;

            PreGetNurseObjectsLine(properties);

            while (fromNode != null)
            {
                switch(fromNode.Nodes.Count)
                {
                    case 0:
                        fromNode = null;
                        break;
                    case 1:
                        fromNode = fromNode.Nodes[0];
                        break;
                    default:
                        fromNode = fromNode.Nodes["self"];
                        break;
                }

                //need refactoring
                if (fromNode != null && (fromNode.Checked))
                {
                   
                    properties = (IElementProperties)fromNode.Tag;
                    TestObjectNurse childNurseNode = properties.ToNurseObject();     
                    bool need2Add = PreGetNurseObjectsLine((IElementProperties)fromNode.Tag);
                    if (need2Add || fromNode.IsSelected)
                    {
                        currentNurseNode.AddChild(childNurseNode);
                        currentNurseNode = childNurseNode;
                    }

                }
            }

            return currentNurseNode;
        }

        private bool PreGetNurseObjectsLine(IElementProperties elementProperties)
        {
            WebElementProperties webElementProperties = elementProperties as WebElementProperties;
            if (null == webElementProperties) return false;

            string ctrlType = webElementProperties.ControlTypeString;
            WebDriverHost webDriverHost = this.Tag as WebDriverHost;

            //WebPage & WebFrame must be inserted into the elements line since the Web driver should be switched to relevant window when 
            //using it to get properties of some web element
            //and in order to find such window, the URL and src property which is included in webPage & WebFrame should be used.
            switch(ctrlType)
            {
                case "WebPage":
                    {
                        //in order to add Webpage object, need to switch to its window.
                        webDriverHost.SwitchRelevantWindow(webElementProperties.Properties[WebControlKeys.URL]);
                        return true;
                    }
                case "WebFrame":
                    {
                        webDriverHost.SwitchRelevantWindow(webElementProperties.WebElement);
                        return true;
                    }
                default:
                    {
                        if (!ctrlType.StartsWith("Web"))
                            return true;
                    }
                    break;
            }
            return false;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this._owner.Visible = true;
            this.Dispose();
        }

        private void AddObjectsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        internal void Start()
        {
            spyer.Start();
        }

        private void objectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            IElementProperties elementProperties = (IElementProperties) node.Tag;

            propertiesListview.FillListviewWithProperties(elementProperties);
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                propertiesListview.UpdateSelection(null);
            }
        }
    }
}
