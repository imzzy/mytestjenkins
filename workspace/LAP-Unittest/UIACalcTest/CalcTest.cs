using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#if TEST
namespace UnitTestProject1
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void CalcTest_TypeRandomNumber()
        {
            using (Calculator calc = new Calculator())
            {
                int number = new Random().Next(100, 10000);
                string stringRep = number.ToString();
                calc.Result = stringRep;
                Assert.AreEqual(stringRep, calc.Result);
            }
        }

        [TestMethod]
        public void CalcTest_VerifyAdd()
        {
            using (Calculator calc = new Calculator())
            {
                Random r = new Random();
                int number1 = r.Next(100, 10000);
                int number2 = r.Next(100, 10000);

                string stringRep = (number1 + number2).ToString();

                string result = calc.Add(number1, number2);
                Assert.AreEqual(stringRep, result);
            }
        }
    }
}

#endif