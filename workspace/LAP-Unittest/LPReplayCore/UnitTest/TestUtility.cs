using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Runtime.InteropServices;

#if TEST

 

namespace LPReplayCore.UnitTest
{
    public class TestUtility
    {

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName); 


        static string hintPath = Path.GetFullPath("..\\..\\..\\samples\\bin");
        public static Process _calculatorProcess; //QT Calculator.exe
        public static Process _winCalcProcess; //Windows Calc.exe

        public static void AppActivate(string titleOfForm) {
            //http://ronniediaz.com/2011/05/03/start-a-process-in-the-foreground-in-c-net-without-appactivate/
            IntPtr splashwindow = FindWindowByCaption(IntPtr.Zero, titleOfForm);
                        SetForegroundWindow(splashwindow);
        }

        public static Process LaunchQTCalculator()
        {
            string calcPath = Path.Combine(hintPath, "Calculator.exe");
            if (File.Exists(calcPath))
            {
                _calculatorProcess = Process.Start(calcPath);
            }
            else
            {
                _calculatorProcess = Process.Start("Calculator.exe"); //use default path, should exists in the path
            }
            _calculatorProcess.WaitForInputIdle();
            return _calculatorProcess;
        }

        public static Process LaunchWindowsCalc()
        {
            string calcPath = System.Environment.ExpandEnvironmentVariables(@"%windir%\System32\calc.exe");
            if (File.Exists(calcPath))
            {
                _winCalcProcess = Process.Start(calcPath);
                _winCalcProcess.WaitForInputIdle();
            }
            return _winCalcProcess;
        }

        public static void ExitQTCalculator()
        {
            if (!_calculatorProcess.HasExited)
            {
                _calculatorProcess.CloseMainWindow();
                _calculatorProcess.Dispose();
            }
        }

        public static void ExitWindowCalculator()
        {
            if (!_winCalcProcess.HasExited)
            {
                _winCalcProcess.CloseMainWindow();
                _winCalcProcess.Dispose();
            }
        }

        public static void LaunchNotepad(string textFilePath)
        {
            _calculatorProcess = Process.Start("Notepad.exe", textFilePath);

        }

        public static object Count(IEnumerable testObjects)
        {
            int i = 0;
            foreach (Object obj in testObjects)
            {
                i++;
            }
            return i;
        }

        public static AutomationElement GetCalculatorButton1Element()
        {
            ObjectDescriptor windowDescriptor = ObjectDescriptor.FromJson(@"
                {ntype:""uia"",identifyProperties: {name: ""Calculator""}}
                ");

            ObjectDescriptor buttonDescriptor = ObjectDescriptor.FromJson(@"
                {ntype:""uia"",identifyProperties: {name: ""1""}}
                ", windowDescriptor);

            ITestObject windowObject = windowDescriptor.GetObject();
            UIATestObject uiaObject = (UIATestObject)windowObject.Children[0];
            AutomationElement element = uiaObject.AutomationElement;
            return element;
        }

        public static List<AutomationElement> GetAncestorsList(AutomationElement element)
        {
            TreeWalker walker = TreeWalker.ControlViewWalker;

            List<AutomationElement> elementList = UIAUtility.GetAutomationElementsLine(element);

            return elementList;
        }

        public static List<AutomationElement> GetPeerList(AutomationElement element)
        {
            TreeWalker walker = TreeWalker.ControlViewWalker;

            AutomationElement parentElement = walker.GetParent(element);
            element = walker.GetFirstChild(parentElement);

            List<AutomationElement> elementList = new List<AutomationElement>();
            while (element != null)
            {
                elementList.Add(element);
                element = walker.GetNextSibling(element);
            }
            return elementList;
        }

        internal static void DumpAutomationElements(List<AutomationElement> elements)
        {
            foreach (AutomationElement element in elements)
            {
                string jsonString = UIAUtility.DumpAutomationElement(element);
                Debug.WriteLine(jsonString);
            }
        }
    }
}

#endif