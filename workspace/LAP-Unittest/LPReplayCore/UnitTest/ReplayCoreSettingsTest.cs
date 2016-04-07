using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.Common;
using System.Drawing;

#if TEST
namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class ReplayCoreSettingsTest
    {
        [TestMethod]
        public void RCSettings_HighlightColor()
        {
            LPConfig.Global.SetSettings("highlightColor", KnownColor.Green.ToString());

            Color highlightColor = ReplayCoreSettings.HighlightColor;

            Assert.AreEqual(Color.Green, highlightColor);
        }

        [TestMethod]
        public void RCSettings_HighlightColor_Set()
        {
            ReplayCoreSettings.HighlightColor = Color.Red;

            string colorName = LPConfig.Global.GetSetting<string>("highlightColor");

            Assert.AreEqual("Red", colorName);
        }
    }
}
#endif