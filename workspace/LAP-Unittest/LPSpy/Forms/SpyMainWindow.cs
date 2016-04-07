using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.ObjectModel;
using LPSpy.UIA;
using LPUIAObjects;
using LPReplayCore;
using LPReplayCore.Common;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LAPResources;
using LPCommon;
using LPReplayCore.Web;


namespace LPSpy
{
    public partial class SpyMainWindow: Form, IMainWindowView
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private String _windowTitle = StringResources.LPSpy_SpyMainWindow_WindowTitle;

        private TreeNode _selectedNode = null;

        private IDataObject _dragDataObject = new DataObject();

        private TestObjectNurse _rootNurseObject;

        protected MruStripMenu mruMenu;
        static string mruRegKey = "SOFTWARE\\LAP\\MruMenus";

        public SpyMainWindow()
        {
            InitializeComponent();

            _presenterModel = new PresenterModel(this);

            _presenterModel.Init();

            InitMenuStates();

            AdjustSize();

            _rootNurseObject = TestObjectNurse.FromTree(_presenterModel.GetTreeView());

            AppEnvironment.ModelChanged += (status =>
            {
                this.Text = _windowTitle + " " + AppEnvironment.CurrentModelPath + ((status) ? " - *" : "");
            });

            mruMenu = new MruStripMenuInline(fileToolStripMenuItem, menuRecentFiles, new MruStripMenu.ClickedHandler(OnMruFile), mruRegKey + "\\MRU" /*, 4 "4 is the max number of recent files*/);

            mruMenu.LoadFromRegistry();

        }

        PresenterModel _presenterModel;

        public void SetPresenter(PresenterModel presenterModel)
        {
            _presenterModel = presenterModel;
        }

        public void SetStatusText(string status)
        {
            this.Invoke(new Action(() => toolStripStatusLabel1.Text = status));
        }


        private void OnMruFile(int number, String filename)
        {
            bool loadSuccessful = false;
            try
            {
                SpyWindowHelper.WantToSave(_rootNurseObject);
                loadSuccessful = ModelFileHandler.LoadRecentModelFile(filename, _presenterModel.GetTreeView());
            }
            catch (Exception ex)
            {
                //"Invalid file format, please check log files for more details"
                MessageBox.Show(StringResources.LPSpy_SpyMainWindow_InvalidFileFormat);
                //TODO: log message
                MessageBox.Show(ex.ToString());
            }

            if (loadSuccessful)
            {
                mruMenu.SetFirstFile(number);
            }
            else
            {
                //The file '{0}' cannot be opened and will be removed from the Recent list(s)
                string message = StringResources.LPSpy_SpyMainWindow_FileRemovedFromRecentList;
                MessageBox.Show(string.Format(message, filename)
                    , ""
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                mruMenu.RemoveFile(number);
            }
        }


        private void InitMenuStates()
        {
            englighMenuItem.Checked = SpySettings.Language == AppLanguageEnum.English;
            chineseMenuItem.Checked = SpySettings.Language == AppLanguageEnum.Chinese;
        }

        private AddObjectsWindow _addObjectsWindow;
        private BatchAddWindow _batchAddWindow;

        private void btnAddObject_Click(object sender, EventArgs e)
        {
            this.Hide();

            _addObjectsWindow = new AddObjectsWindow(this);
            _addObjectsWindow.Tag = _presenterModel.GetWebDriverHost();
            _addObjectsWindow.Start();

            _addObjectsWindow.UpdateSelectedTree = new TreeUpdatedDelegate(_presenterModel.MergeTree);
        }

        private void btnRemoveObject_Click(object sender, EventArgs e)
        {
            _presenterModel.DeleteNode();
        }


        private void spyMainWindow_Onload(object sender, EventArgs e)
        {
            ModelFileHandler.AfterFileLoad += (path) =>
            {
                this.Text = _windowTitle + " " + path;
            };

            LoadFile();
        }

        private void LoadFile()
        {
            string tempFilePath = AppEnvironment.CurrentModelPath;

            if (File.Exists(tempFilePath))
            {
                TestObjectNurse testObjectNurse = TestObjectNurse.FromTree(_presenterModel.GetTreeView());

                ModelFileHandler.LoadModelFile(tempFilePath, testObjectNurse);
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (_presenterModel.SaveModel())
            {
                string filePath = AppEnvironment.CurrentModelPath;
                mruMenu.AddFile(filePath);
            }
        }

        //toolbar -> save
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveMenuItem_Click(sender, e);
        }


        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (ModelFileHandler.DlgSaveAsModelFile(_rootNurseObject))
            {
                mruMenu.AddFile(AppEnvironment.CurrentModelPath);
            }
        }


        //menu -> open
        private void openMenuItem_Click(object sender, EventArgs e)
        {

            SpyWindowHelper.WantToSave(_rootNurseObject);
            try
            {
                if (_presenterModel.DlgOpenModelFile())
                {
                    mruMenu.AddFile(AppEnvironment.CurrentModelPath);
                }
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                //Invalid file format, please check log files for more detail
                MessageBox.Show(StringResources.LPSpy_SpyMainWindow_InvalidFileFormat);
                
                _Logger.WriteWarning(ex.ToString());
            }
        }

        //toolbar -> open
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openMenuItem_Click(sender, e);
        }

        //menu -> new
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            SpyWindowHelper.WantToSave(_rootNurseObject);

            string filePath = null;

            if (ModelFileHandler.DlgNewModelFile(out filePath))
            {
                _presenterModel.NewModel(filePath);
            }
        }

        //toolbar -> new
        private void btnNewFile_Click(object sender, EventArgs e)
        {
            newMenuItem_Click(sender, e);
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            _presenterModel.Highlight();
        }

        private void SpyMainWindow_Resize(object sender, EventArgs e)
        {
            AdjustSize();
        }

        private void AdjustSize()
        {
            panelRight.Width = this.Width - panelLeft.Width - 20;
        }

        private void btnSpy_Click(object sender, EventArgs e)
        {
            UIASpyWindow spy = new UIASpyWindow();
            spy.Show();

        }

        private void btnConditionHighlight_Click(object sender, EventArgs e)
        {
            ConditionSelectorWindow conditionSlectorWindow = new ConditionSelectorWindow();
            if (_selectedNode != null)
            {
                conditionSlectorWindow.Tag = _selectedNode;
                conditionSlectorWindow.ShowDialog();
            }
            else
            {
                //Please select a node.
                MessageBox.Show(StringResources.LPSpy_SpyMainWindow_PleaseSelectNode);
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }


        private void englighMenuItem_Click(object sender, EventArgs e)
        {
            if (SpySettings.Language == AppLanguageEnum.Chinese)
            {
                SpyWindowHelper.SwitchLanguage(AppLanguageEnum.English, () => { SpyWindowHelper.WantToSave(_rootNurseObject); });
            }
        }

        private void chineseMenuItem_Click(object sender, EventArgs e)
        {
            if (SpySettings.Language == AppLanguageEnum.English)
            {
                SpyWindowHelper.SwitchLanguage(AppLanguageEnum.Chinese, () => { SpyWindowHelper.WantToSave(_rootNurseObject); });
            }
        }


        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            OptionWindow optionWindow = new OptionWindow();
            optionWindow.ShowDialog();
        }

        private void documentsMenuItem_Click(object sender, EventArgs e)
        {
            SpyWindowHelper.ShowHelp();
        }


        private void SpyMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check whether need to save before exit
            SpyWindowHelper.WantToSave(_rootNurseObject);

            SpySettings.SaveUserSettings();
            mruMenu.SaveToRegistry();
            mruMenu.BuildJumpList();
        }

		 private void batchAddMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                _batchAddWindow = new BatchAddWindow();
                _batchAddWindow.Owner = this;
                _batchAddWindow.Start();


                _batchAddWindow.UpdateSelectedTree = new TreeUpdatedDelegate(_presenterModel.MergeTree);
                _batchAddWindow.Hide();
            }
            catch(ElementNotAvailableException)
            {
                //Element is no longer available, please reselect the element
                MessageBox.Show(StringResources.LPSpy_ElementNotAvailableException);
            }
		 }

         private void btnBatchAdd_Click(object sender, EventArgs e)
         {
             batchAddMenuItem_Click(sender, e);
         }


         private void mnuOpenLocation_Click(object sender, EventArgs e)
         {
             string path = AppEnvironment.CurrentModelPath;
             if (File.Exists(path))
             {
                 Process.Start(new ProcessStartInfo("explorer.exe", " /select, " + path));
             }
         }

         private void toolStripbtnUpdate_Click(object sender, EventArgs e)
         {
             if (_selectedNode == null || (_selectedNode.Tag as TestObjectNurse) == null)
             {
                 MessageBox.Show(StringResources.LPSpy_SpyMainWindow_RefreshobjWarningMsg,
                     StringResources.LPSpy_SpyMainWindow_RefreshobjWarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }
             this.Hide();
             _addObjectsWindow = new AddObjectsWindow(this, AddObjWndModeType.UpdateProperties);
             _addObjectsWindow.Tag = _selectedNode;
             _addObjectsWindow.Owner = this;
             _addObjectsWindow.Start();

             _addObjectsWindow.UpdateSelectedNode = new TreeNodeUpdatedDelegate(_presenterModel.UpdateSelNode);

         }

         private void toolStripbtnBrowser_Click(object sender, EventArgs e)
         {
             _presenterModel.LaunchWebDriverHost();
         }

         public INodeView NodeViewControl
         {
             get { return nodeViewControl1; }
         }

         public IModelTreeView ModelTreeControl
         {
             get { return modelTreeViewControl1; }
         }
    }
}
