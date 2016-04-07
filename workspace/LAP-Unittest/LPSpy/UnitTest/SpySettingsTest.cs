using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore;
using LPReplayCore.Common;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class SpySettingsTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            //remove LAPUserConfig.json
            LPConfig.ResetToGlobal();
        }

        [TestMethod]
        public void SpySettings_Height()
        {
            Assert.AreEqual(true, ReplayCoreSettings.Highlight);
        }

        [TestMethod]
        public void SpySettings_ToggleLanguage()
        {
            AppLanguageEnum oldLanguage = SpySettings.Language;

            //toggle to a different language
            SpySettings.Language = (oldLanguage == AppLanguageEnum.English) ? AppLanguageEnum.Chinese : AppLanguageEnum.English;

            SpySettings.SaveUserSettings();

            LPConfig.ReloadConfig();

            Assert.AreNotEqual(oldLanguage, SpySettings.Language, "The toggled the language value should be different");

        }

        [TestMethod]
        public void SpySettings_ToggleCaptureSnapshots()
        {
            bool captureSnapshots = SpySettings.CaptureSnapshots;

            //default should be true;
            Assert.AreEqual(true, captureSnapshots);

            //toggle to a different language
            SpySettings.CaptureSnapshots = !captureSnapshots;

            SpySettings.SaveUserSettings();

            LPConfig.ReloadConfig();

            Assert.AreNotEqual(captureSnapshots, SpySettings.CaptureSnapshots, "The toggled the CaptureSnapshots setting should be different");

        }
    }
}

#endif