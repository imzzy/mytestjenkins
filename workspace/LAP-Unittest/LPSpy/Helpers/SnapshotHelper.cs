using LPCommon;
using LPReplayCore.Interfaces;
using LPReplayCore.UIA;
using LPUIAObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using OpenQA.Selenium.Remote;
using LPReplayCore.Web;

namespace LPSpy
{
    public static class SnapshotHelper
    {
        static readonly CacheHandler _cacheHandler = new CacheHandler(AppEnvironment.CurrentDirectory);

        public static CacheHandler CacheHandler
        {
            get
            {
               return _cacheHandler;
            }
        }

        public static void CaptureTempSnapshot(AutomationElement element, out string token)
        {
            if (element == null)
            {
                throw new ElementNotAvailableException();
            }
            //get rectangle of TO
            Rect rect = element.Current.BoundingRectangle;
            if (rect.Width == 0 || rect.Height == 0)
            {
                throw new ApplicationException("Element size is 0");
            }
            System.Drawing.Rectangle actualRect = System.Drawing.Rectangle.FromLTRB((int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom);

            Snapshot snapshotHelper = new Snapshot();

            MemoryStream stream = snapshotHelper.CaptureInflatedRectangle(actualRect);

            string tempToken = Guid.NewGuid().ToString();

            _cacheHandler.SaveCachedItem(stream, tempToken);

            token = tempToken;
        }

        public static void CaptureTempSnapshot(System.Drawing.Rectangle actualRect, out string token)
        {
            Snapshot snapshotHelper = new Snapshot();

            MemoryStream stream = snapshotHelper.CaptureInflatedRectangle(actualRect);

            string tempToken = Guid.NewGuid().ToString();

            _cacheHandler.SaveCachedItem(stream, tempToken);

            token = tempToken;
        }

        public static void CaptureTempSnapshot(RemoteWebElement webElement, out string token)
        {
            if (webElement == null)
            {
                throw new ElementNotAvailableException();
            }
            //get rectangle of TO

            System.Drawing.Rectangle actualRect = WebUtility.GetElementScreenRect(webElement);

            //System.Drawing.Rectangle actualRect = System.Drawing.Rectangle.FromLTRB((int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom);

            Snapshot snapshot = new Snapshot();

            MemoryStream stream = snapshot.CaptureInflatedRectangle(actualRect);

            string tempToken = Guid.NewGuid().ToString();

            _cacheHandler.SaveCachedItem(stream, tempToken);

            token = tempToken;
        }

        public static string GetCachedSnapshot(string token, string fileName = null)
        {
            if (token == null) return null;

            if (string.IsNullOrEmpty(fileName))
            {
                fileName = token + ".png";
            }
            string imagePath = Path.Combine(AppEnvironment.ModelResourceFolder, fileName);

            _cacheHandler.MoveCachedItemToFile(token, imagePath);
            return fileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testObject"></param>
        /// <param name="bitmap"></param>
        /// <returns>return the token of the bitmap</returns>
        public static string SnapshotFileFromBitmap(ITestObject testObject, System.Drawing.Bitmap bitmap)
        {
            //currently only support UIA, maybe later support more types of test objects

            UIATestObject uiaObject = (UIATestObject)testObject;

            MemoryStream stream = SnapshotFromBitmap(uiaObject.AutomationElement, bitmap);

            if (stream == null) return null;

            string tempToken = Guid.NewGuid().ToString();
            _cacheHandler.SaveCachedItem(stream, tempToken);

            return GetCachedSnapshot(tempToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subUiaCondition"></param>
        /// <param name="bitmap"></param>
        /// <returns>return the token of the bitmap</returns>
        public static MemoryStream SnapshotFromBitmap(AutomationElement element, System.Drawing.Bitmap bitmap)
        {
            System.Windows.Rect rect = System.Windows.Rect.Empty;
            if (element.Cached.BoundingRectangle != null)
                rect = element.Cached.BoundingRectangle;
            else
                rect = element.Current.BoundingRectangle;

            System.Drawing.Rectangle rectDrawing = new System.Drawing.Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
            MemoryStream stream = Snapshot.GetBitmap(rectDrawing, bitmap);

            return stream;
        }

    }
}
