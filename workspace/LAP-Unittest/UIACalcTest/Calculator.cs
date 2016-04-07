using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LPReplayCore;
using LPReplayCore.Interfaces;
using LPReplayCore.UnitTest;

#if TEST
namespace UnitTestProject1
{
    class Calculator : IDisposable
    {
        Process _calculatorProcess;

        AutomationElement _calculatorAutomationElement;
        AutomationElement _resultAutomationElement;

        AppModel _calcModel;

        //initialize the class using model file path
        public Calculator(string modelFilePath)
        {
            _calculatorProcess = TestUtility.LaunchCalc();
            _calcModel = AppModelSerializer.Load(modelFilePath);

            int ct = 0;
            do
            {
                _calculatorAutomationElement = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                    new PropertyCondition(AutomationElement.NameProperty, "Calculator"));
                ct++;
                Thread.Sleep(100);
            }
            while (_calculatorAutomationElement == null || ct < 50);

            if (_calculatorAutomationElement == null)
            {
                throw new InvalidOperationException("Calculator must be missing");
            }


            _resultAutomationElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, "")
                    //new AndCondition(new Condition[] {
                    //    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text),
                    //    new PropertyCondition(AutomationElement.NameProperty, "")})
                    );
            //    new PropertyCondition(AutomationElement.AutomationIdProperty, 150)); //This is used for Windows Calc (< Win 10)            

            if (_resultAutomationElement == null)
            {
                throw new InvalidOperationException("Could not find result box");
            }

            //TODO get invoke pattern
            ITestObject clearButton = _calcModel[Functions.Clear];
            GetInvokePattern(UIATestObject.ToAutomationObject(clearButton)).Invoke();
        }

        public Calculator(): this("CalcAppModel.json")
        {
            
        }

        public void Dispose()
        {
            _calculatorProcess.CloseMainWindow();
            _calculatorProcess.Dispose();
        }

        public InvokePattern GetInvokePattern(AutomationElement element)
        {
            return element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        }

        public string GetValue(AutomationElement element)
        {
            ValuePattern pt = element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            return pt.Current.Value;
        }

        public void InvokeControl(ITestObject control)
        {
            AutomationElement functionButton = GetFunctionButton(control);
            GetInvokePattern(functionButton).Invoke();

        }

        public AutomationElement GetFunctionButton(ITestObject control)
        {
            AutomationElement functionButton = UIATestObject.ToAutomationObject(control);
            //AutomationElement functionButton = _calculatorAutomationElement.FindFirst(TreeScope.Descendants,
            //    new PropertyCondition(AutomationElement.NameProperty, functionName));

            if (functionButton == null)
                throw new InvalidOperationException("No function button found with descriptor: " + control.ToString());

            return functionButton;
        }

        //the button is node name in the model
        public class Functions
        {
            public const string Clear = "clear";
            public const string DecimalSeparator = ".";
            public new const string Equals = "equal";
            public const string Add = "plus";
            public const string Divide = "divide";
            public const string Multiply = "multiply";
            public const string Minus = "minus";
        }

        public AutomationElement GetDigitButton(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new InvalidOperationException("Invalid digit number");
            }

            AutomationElement digitButton = _calculatorAutomationElement.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, digit.ToString()));

            if (digitButton == null) 
            { 
                throw new InvalidOperationException("Could not find button corresponding to digit" + digit); 
            }

            return digitButton;

        }

        public string Result
        {
            get
            {
                return GetValue(_resultAutomationElement);
                //return _resultAutomationElement.GetCurrentPropertyValue(AutomationElement.).ToString();
            }
            set
            {
                string stringRep = value.ToString();
                for (int index = 0; index < stringRep.Length; index++)
                {
                    int leftDigit = int.Parse(stringRep[index].ToString());

                    Thread.Sleep(300);
                    GetInvokePattern(GetDigitButton(leftDigit)).Invoke();
                    Thread.Sleep(300);
                }
            }
        }

        public void Evaluate()
        {
            InvokeControl(_calcModel[Functions.Equals]);
        }

        public void Clear()
        {
            InvokeControl(_calcModel[Functions.Clear]);
        }

        public string BinaryOperate(int digit1, int digit2, string operation)
        {
            Result = digit1.ToString();
            Thread.Sleep(300);
            InvokeControl(_calcModel[operation]);
            Thread.Sleep(300);
            Result = digit2.ToString();
            Thread.Sleep(300);
            Evaluate();
            Thread.Sleep(300);
            return Result;
        }

        public string Add(int digit1, int digit2)
        {
            return BinaryOperate(digit1, digit2, Functions.Add);
        }

        public string Divide(int digit1, int digit2)
        {
            return BinaryOperate(digit1, digit2, Functions.Divide);
        }

        public string Minus(int digit1, int digit2)
        {
            return BinaryOperate(digit1, digit2, Functions.Minus);
        }

        public string Multiply(int digit1, int digit2)
        {
            return BinaryOperate(digit1, digit2, Functions.Multiply);
        }
    }
}
#endif