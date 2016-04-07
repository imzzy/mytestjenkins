using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;

namespace Install_CA
{
    //https://lostechies.com/gabrielschenker/2010/05/18/wix-and-custom-actions/

    public class CustomActions
    {
        /// <summary>
        /// Set properties in Custom Action Data to be used later in the deferred execute sequence. 
        /// This is needed as Windows Installer properties are not accessible in the deferred execute sequence. 
        /// This custom action must be executed in the immediate execute sequence.
        /// </summary>
        /// <param name="session">msi session</param>
        /// <returns>custom action results</returns>
        /// 


        public static class CAConstants
        {
            public const string RunBeforeModify = "run_before_modify";
            public const string RunBeforeFinish = "run_before_finish";
            public const string RunBeforeUninstall = "run_before_uninstall";
            public const string CreateSoftlink = "create_softlink";
        }

        [CustomAction]
        public static ActionResult CADefferedProperties(Session session)
        {
            //System.Diagnostics.Debugger.Launch();

            session.Log("CADefferedProperties: start");

            //create custom action data from immidated session properties
            CustomActionData data = new CustomActionData();
            data["INSTALLDIR"] = session["INSTALLDIR"];
            data["TARGETDIR"] = session["LAPINSTALLDIR"];
            data["Language"] = session["Language"];

            //Store custom action data for each deffered CAs
            session[CAConstants.RunBeforeModify] = data.ToString();
            session[CAConstants.RunBeforeFinish] = data.ToString();
            session[CAConstants.RunBeforeUninstall] = data.ToString();

            session.Log("CADefferedProperties: Complete");
            return ActionResult.Success;
        }


        [CustomAction]
        public static ActionResult run_before_modify(Session session)
        {
            System.Windows.Forms.MessageBox.Show("run_before_modify");
             
            return ActionResult.Success;
        }

        /// <summary>
        /// the directory that contains AppConfig.json, should be [TARGETDIR]\bin
        /// </summary>
        /// <param name="directory"></param>
        public static void ChangeLanguage(string directory, string language)
        {
            string configFilePath = Path.Combine(directory, "AppConfig.json");
        
            string content = ReadFileContent(configFilePath);
            content = content.Replace("English", language);

            WriteFileContent(configFilePath, content);
            
        }

        internal static void WriteFileContent(string filePath, string serializedContent)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.Write(serializedContent);
            }
        }

        public static string ReadFileContent(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }


        [CustomAction]
        public static ActionResult run_before_finish(Session session)
        {
            CustomActionData data = session.CustomActionData;

            string installDir = data["TARGETDIR"];
            string languageID = data["Language"];
            string language = "English";
            if (languageID == "2052")
            {
                language = "Chinese";
            }

            ChangeLanguage(Path.Combine(installDir, "bin"), language);

            //System.Windows.Forms.MessageBox.Show(codePage);
           
            return ActionResult.Success;
        }


        [CustomAction]
        public static ActionResult run_before_uninstall(Session session)
        {
            //System.Windows.Forms.MessageBox.Show("run_before_uninstall");
            
            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult show_admin_ui(Session session)
        {
            //System.Windows.Forms.MessageBox.Show("show_admin_ui");
          
            return ActionResult.Success;
        }
    }
}
