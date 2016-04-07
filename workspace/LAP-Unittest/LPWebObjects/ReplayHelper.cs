using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using LPWebObjects.Controls;
using LPReplayCore;
using LPReplayCore.Model;
using LPReplayCore.Web;

namespace LPWebObjects
{

    [Guid("B2B48B98-C088-4E55-8492-E8F571322B5E")]
    [TypeLibType(4160)]
    public interface IReplayHelper
    {
        [DispId(1)]
        void LoadRepository(string path);

        [DispId(2)]
        void StartReplay();

        [DispId(3)]
        WebPage WebPage(string nodeName);

    }


    [ProgId("LeanPro.ReplayHelper")]
    [Guid(ReplayHelper.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ReplayHelper : IReplayHelper
    {
        internal const string ClassId = "DBDF6CA7-EE10-410A-BB5C-A8BC28958C4C";

        private ControlCollections _pageCollections = new ControlCollections();
        public ReplayHelper()
        {
          
        }

        public void LoadRepository(string path)
        {
            AppModel.Initialize(path);
        }

        public WebPage WebPage(string nodeName)
        {
            WebPage webPage = _pageCollections[nodeName] as WebPage;
            if (null == webPage)
            {
                webPage = new WebPage();
                webPage.ObjectName = nodeName;
                _pageCollections[nodeName] = webPage;
                AppModel model = AppModel.Current;
                webPage.RelayObject = model.GetTestObject(nodeName) as SETestObject;
               // webPage.RelayObject.WebDriver = BrowserHoster.getInstance().WebDriver;
               // BrowserHoster.getInstance().SwithToURL(webPage.RelayObject.Properties[WebControlKeys.URL]);
                LPWebObjects.Controls.WebPage.SwitchTo(webPage);
            }
            return webPage;
        }

        public void StartReplay()
        {
            //launch the browser

        }
    }
}
