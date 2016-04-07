using LPReplayCore;
using LPReplayCore.Interfaces;
using LPUIAObjects;
using LPReplayCore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LAPResources;

namespace LPSpy
{
    /// <summary>
    /// handle model file loading and saving
    /// </summary>
    public static class ModelFileHandler
    {
        static TreeView _treeObjects;

        static FileSystemWatcher _fileChangeWatcher;

        public static bool SaveToModelFile(TestObjectNurse rootNurse)
        {
            string filePath = AppEnvironment.CurrentModelPath;
            bool ret = SaveToModelFile(rootNurse, filePath);

            AppEnvironment.DumpRecyclingBin(rootNurse);
            return ret;
        }

        private static bool WatcherEnable
        {
            set
            {
                if (_fileChangeWatcher == null) return;
                _fileChangeWatcher.EnableRaisingEvents = value;
            }
        }

        public static bool SaveToModelFile(TestObjectNurse rootNurse, string filePath)
        {
            AppModel model = new AppModel();

            foreach (TestObjectNurse nurseObject in rootNurse.Children)
            {
                ITestObject testObject = nurseObject.TestObject;

                model.Add(testObject);
            }

            try
            {
                WatcherEnable = false;
                AppModelManager.Save(model, filePath);

                EnsureWatcherCreated(filePath);
                AppEnvironment.CurrentModelPath = filePath;
            }
            finally
            {
                WatcherEnable = true;
            }

            return true;
        }

        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Form form = _treeObjects.FindForm();

            form.Invoke(new Action(() =>
            {
                //"File changed outside the Manager, do you want to reload?"
                DialogResult result = MessageBox.Show(form, StringResources.LPSpy_ModelFileHandler_ReloadChangedFile
                    , StringResources.LPSPY_Confirm
                    , MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //reload the file
                    
                    TestObjectNurse rootNurse = TestObjectNurse.FromTree(_treeObjects);
                    rootNurse.Clear();

                    LoadModelFile(AppEnvironment.CurrentModelPath, rootNurse);
                }
            }));
        }

        public static bool DlgNewModelFile(out string filePath)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "New Model File";
            savefile.Filter = "*.json|*.json";

            savefile.FileName = "Model1.json";
            savefile.OverwritePrompt = true;

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                filePath = savefile.FileName;
                return true;
            }

            filePath = null;
            return false;
        }

        public static bool DlgSaveAsModelFile(TestObjectNurse rootNurse)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save as";
            savefile.Filter = "*.json|*.json";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                SaveToModelFile(rootNurse);

                AppEnvironment.CurrentModelPath = savefile.FileName;

                rootNurse.Clear();

                LoadModelFile(AppEnvironment.CurrentModelPath, rootNurse);
                return true;
            }

            return false;
        }


        public static event AfterFileLoadDelegate AfterFileLoad;

        public static AppModel LoadModelFile(string appModelPath, TestObjectNurse rootNurse)
        {
            _treeObjects = rootNurse.TreeView;

            AppModel model = AppModelManager.Load(appModelPath, ModelLoadLevel.Full);

            TestObjectToTreeNode(model.Items, rootNurse);

            AppEnvironment.CurrentModelPath = appModelPath;

            OnFileLoaded(appModelPath);

            AppEnvironment.CurrentModelPath = appModelPath;
            EnsureWatcherCreated(AppEnvironment.CurrentModelPath);

            return model;
        }

        private static void OnFileLoaded(string appModelPath)
        {
            if (AfterFileLoad != null)
            {
                AfterFileLoad(appModelPath);
            }
        }

        /// <summary>
        /// generate tree nodes hierarchy from the TestObjects hierarchy
        /// </summary>
        /// <param name="testObjects"></param>
        /// <param name="parentNurse"></param>
        private static void TestObjectToTreeNode(IEnumerable<ITestObject> testObjects, TestObjectNurse parentNurse)
        {
            if (testObjects == null) return;

            foreach (ITestObject to in testObjects)
            {
                TestObjectNurse nurse = (TestObjectNurse)parentNurse.AddChild(to);
                TreeNode treeNode = nurse.TreeNode;
                treeNode.Expand();

                TreeNodeHelper.FixTreeNodeImage(treeNode, nurse.ControlTypeString);

                TestObjectToTreeNode(to.Children, nurse);
            }
        }


        /// <summary>
        /// populate tree view with the AppModel
        /// </summary>
        /// <param name="treeObjects"></param>
        /// <returns>indicate whether load successful</returns>
        public static bool DlgLoadModelFile(TreeView treeObjects)
        {

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "Plese select an Application Model file";
            fileDialog.Filter = "*.json|*.json";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                TestObjectNurse rootNurse = TestObjectNurse.FromTree(treeObjects);
                rootNurse.Clear();

                LoadModelFile(fileDialog.FileName, rootNurse);

                //_treeObjects is used by the file watcher event
                _treeObjects = treeObjects;

                return true;
            }
            return false;
        }

        /// <summary>
        /// return value indicate whether the load is successful
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="treeObjects"></param>
        /// <returns>return false if file cannot be found</returns>
        public static bool LoadRecentModelFile(string filePath, TreeView treeObjects)
        {
            try
            {
                TestObjectNurse rootNurse = TestObjectNurse.FromTree(treeObjects);
                rootNurse.Clear();

                LoadModelFile(filePath, rootNurse);

                //_treeObjects is used by the file watcher event
                _treeObjects = treeObjects;

                return true;
            }
            catch (FileNotFoundException)
            {
                AppEnvironment.CurrentModelPath = null;
                return false;
            }

        }

        private static void EnsureWatcherCreated(string filePath)
        {
            if (_fileChangeWatcher != null)
            {
                //Need to use Async call to dispose it, otherwise it will hang, because the Dispose is called inside 
                //the file watcher's Changed event handler
                Action action = new Action(() =>
                {
                    _fileChangeWatcher.Dispose();
                });
                IAsyncResult result = action.BeginInvoke(null, null);
            }

            FileInfo fileInfo = new FileInfo(filePath);
            _fileChangeWatcher = new FileSystemWatcher(fileInfo.DirectoryName);
            _fileChangeWatcher.Filter = fileInfo.Name;
            _fileChangeWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
            _fileChangeWatcher.Changed += watcher_Changed;
            _fileChangeWatcher.EnableRaisingEvents = true;
        }
    }
}
