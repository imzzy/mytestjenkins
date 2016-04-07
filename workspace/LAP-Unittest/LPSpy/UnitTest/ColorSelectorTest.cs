using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class ColorSelectorTest
    {
        [TestMethod]
        public void ColorSelector_SelectColor()
        {
            ColorSelector selector = new ColorSelector();
            selector.Items.AddRange(new object[] {
            "Green",
            "Red",
            "Yellow"});

            bool result = selector.SelectColor(Color.Yellow);

            Assert.IsTrue(result);

            Assert.AreEqual(Color.Yellow, selector.ColorSelected);
        }
    }
}
#endif