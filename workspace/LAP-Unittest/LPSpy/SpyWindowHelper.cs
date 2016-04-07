using LPSpy.UIA;
using LPUIAObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using LPReplayCore.Common;
using LPReplayCore;
using LPReplayCore.Interfaces;
using System.Windows.Automation;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LPCommon;
using System.Diagnostics;
using System.Reflection;
using LAPResources;

namespace LPSpy
{
    public delegate void AfterFileLoadDelegate(string path);

    static class SpyWindowHelper
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//"LPReplayCore.UIA.UIAFinder");

        public static string DeriveControlName(TestObjectNurse treeNodes, AutomationElement element)
        {
            string controlName = "";

            if (!string.IsNullOrEmpty(element.Current.Name))
                controlName = element.Current.Name;
            else
                controlName = element.Current.ControlType.ControlTypeToString();
 
            return DeriveControlName(treeNodes, controlName);
        }

        /// <summary>
        /// determine a control name that is unique in the tree
        /// </summary>
        /// <param name="treeNodes"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public static string DeriveControlName(TestObjectNurse treeNodes, string controlName)
        {
            int sameNameIndex = 0;

            string tempName = controlName;

            foreach (TestObjectNurse nurse in treeNodes.Children)
            {
                if (nurse.NodeName == tempName)
                {
                    sameNameIndex++;
                    tempName = controlName + "_" + sameNameIndex;
                }
            }

            controlName = tempName;
            return controlName;
        }


        public static int FillPropertyGrid(DataGridView propertiesTable, ITestObject testObject)
        {
            propertiesTable.Rows.Clear();

            propertiesTable.Tag = testObject;

            int count = 0;
            foreach (KeyValuePair<string, string> property in testObject.Properties)
            {
                string displayName = ControlKeysManager.GetDisplayString(property.Key);

                propertiesTable.Rows.Add(new Object[] { displayName, property.Value });

                count++;
            }

            return count;
        }


        public static bool DeleteSelectedProperties(string key, ITestObject testObject)
        {
            Debug.Assert(!(testObject is TestObjectNurse), "Should not pass nurse object to it");

            if (string.IsNullOrEmpty(key)) return false;

            bool bChanged = false;

            if (testObject.Properties.ContainsKey(key))
            {
                testObject.RemoveProperty(key);
                bChanged = true;
            }
            
            return bChanged;
        }


        /// <summary>
        /// Add the selected property in grid to the uiaCondition
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="testObject"></param>
        public static void AddSelectedProperty(DataGridView grid, ITestObject testObject)
        {
            foreach (DataGridViewRow gridRow in grid.SelectedRows)
            {
                string propertyName = gridRow.Cells["Property"].Value.ToString();
                string keyName = ControlKeysManager.GetKeyString(propertyName);
                string value = (gridRow.Cells["Value"].Value ?? string.Empty).ToString();

                if (!testObject.Contains(propertyName))
                {
                    testObject.AddProperty(keyName, value);
                }

            }
        }

        public static void SwitchLanguage(AppLanguageEnum language, Action action)
        {
            //"Need to restart application to take effect, restart now?"
            DialogResult result = MessageBox.Show(StringResources.LPSpy_SpyMainWindow_RetartToTakeEffect,"Confirm",
            MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SpySettings.Language = language;
                SpySettings.SaveUserSettings();

                action();

                RestartApp();
            }
        }

        public static void RestartApp()
        {
            //TODO: close this current app first and start a new one
            Process.Start(Assembly.GetExecutingAssembly().Location);
            Application.Exit();
        }


        public static void WantToSave(TestObjectNurse rootNurseObject)
        {
            if (AppEnvironment.ModelStatus)
            {
                if (MessageBox.Show(StringResources.LPSpy_SpyMainWindow_SaveWarningMsg, StringResources.WarningTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save(rootNurseObject);
                }
            }
        }


        public static bool Save(TestObjectNurse rootNurseObject)
        {
            bool succeed = ModelFileHandler.SaveToModelFile(rootNurseObject);

            if (succeed)
            {
                AppEnvironment.SetModelChanged(false);
            }

            SpySettings.Persist();
            return succeed;
        }

        public static bool ShowHelp()
        {
            return ShowPDFHelp("LAP User Guide.pdf", null);
        }

        /// <summary>
        /// Show the help content in the corresponding section of PDF file
        /// </summary>
        /// <param name="filename">pdf file name</param>
        /// <param name="namedReference">the named location in the pdf file</param>
        /// <returns></returns>
        public static bool ShowPDFHelp(string filename, string namedReference)
        {

            System.Reflection.Assembly p = System.Reflection.Assembly.GetExecutingAssembly();
            string helpFolder = Path.Combine(Path.GetDirectoryName(p.Location), "..\\help");

            try
            {
                // Open pdf help file
                Process helpProcess = new Process();

                helpProcess.StartInfo.FileName = "acrord32.exe";
                helpProcess.StartInfo.Arguments = string.Format("{0} \"{1}\"", "/A nameddest=" + namedReference,
                    System.IO.Path.Combine(helpFolder, filename)
                    );

                if (helpProcess.Start())
                {
                    return true;
                }
            }
            catch (Exception) {  }
                MessageBox.Show(StringResources.Error_Message_No_AcroRD32,
                    StringResources.WarningTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;

        }
 }
}
