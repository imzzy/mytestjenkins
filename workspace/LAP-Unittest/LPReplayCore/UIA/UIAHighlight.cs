using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows;
using LPReplayCore.UIA;
using LPReplayCore.Interfaces;
using LPReplayCore.Web;

namespace LPReplayCore
{

    public static class UIAHighlight
    {
        public static Color _highlightColor = ReplayCoreSettings.HighlightColor;
        public static void HighlightAutomationElement(AutomationElement automationElement, Color? color = null)
        {
            if (!ReplayCoreSettings.Highlight)
                return;

            Rect? rect = GetRectangle(automationElement);

            if (rect == null) return;

            HighlightRect((Rect)rect, color);

        }

        public static Rect? HighlightVirtualControl(AutomationElement automationElement, Rect rect, Color? color = null)
        {
            if (!ReplayCoreSettings.Highlight)
                return null;

            Rect? tempRect = GetRectangle(automationElement);
            if (tempRect == null) return null;
            Rect elementRect = (Rect)tempRect;

            Rect virtualControlRect = new Rect(elementRect.Left + rect.Left - 10, elementRect.Top + rect.Top - 10, rect.Width, rect.Height);

            HighlightRect(virtualControlRect, color);
            return virtualControlRect;
        }

        public static void HighlightRect(Rect rect, Color? color = null)
        {
            HighlightRectangle highlight = ShowHighlightRectangle(rect, color);

            for (int i = 0; i < 3; i++)
            {
                highlight.Visible = true;
                Thread.Sleep(200);

                highlight.Visible = false;
                Thread.Sleep(200);
            }
        }


        public static void HighlightRect(System.Drawing.Rectangle rect, Color? color = null)
        {
            Rect rc = new Rect((double)rect.Left, (double)rect.Top,
                (double)rect.Width, (double)rect.Height);
            HighlightRectangle highlight = ShowHighlightRectangle(rc, color);

            for (int i = 0; i < 3; i++)
            {
                highlight.Visible = true;
                Thread.Sleep(200);

                highlight.Visible = false;
                Thread.Sleep(200);
            }
        }

        public static HighlightRectangle HighlightThread_Spy(AutomationElement automationElement, bool infinite = false)
        {
            Rect? rect = GetRectangle(automationElement);
            if (rect == null) return null;

            HighlightRectangle highlightRect = ShowHighlightRectangle((Rect)rect);

            if (!infinite)
            {
                Thread.Sleep(500);

                if (highlightRect != null)
                    highlightRect.Visible = false;
            }
            return highlightRect;
        }

        private static Rect? GetRectangle(AutomationElement automationElement)
        {
            if (automationElement == null)
                return null;

            Rect rect;

            try
            {
                rect = automationElement.Current.BoundingRectangle;
            }
            catch { return null; }

            return rect;

        }

        public static HighlightRectangle ShowHighlightRectangle(Rect rect, Color? color = null)
        {
            HighlightRectangle highlightRect = HighlightRectangle.Instance;

            highlightRect.Init(new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height),
                true
                );

            if (color != null)
            {
                highlightRect.Color = (Color) color;
            }
            
            return highlightRect;
        }

        //can highlight both virtual control and UIA control

        public static bool SearchAndHighlight(ITestObject testObject)
        {
            /*if (testObject.ControlTypeString.StartsWith("Web"))
            {
                //check the WebDriverHost existing
                


                SETestObject seTestObject = testObject as SETestObject;
                Rectangle rc = WebUtility.GetElementScreenRect(seTestObject.SEWebElement);
                HighlightRect(rc);
                return true;
            }*/




            VirtualTestObject virtualTestObject = testObject as VirtualTestObject;

            UIATestObject uiaTestObject = (virtualTestObject == null) ? (UIATestObject)testObject: (UIATestObject)virtualTestObject.Parent;

            bool elementNotAvailable = false;
            try
            {
                if (!UIAUtility.CheckObjectExist(uiaTestObject.AutomationElement)) return false;

            }
            catch (ElementNotAvailableException)
            {
                elementNotAvailable = true;
            }
            catch (UnauthorizedAccessException)
            {
                elementNotAvailable = true;
            }

            if (elementNotAvailable)
            {
                //clean up the cache
                UIATestObject tempTestObject = uiaTestObject;
                while (tempTestObject != null)
                {
                    tempTestObject.AutomationElement = null;
                    tempTestObject = (UIATestObject)tempTestObject.Parent;
                }
                if (!UIAUtility.CheckObjectExist(uiaTestObject.AutomationElement)) return false;
            }

            AutomationElement elementToSearch = uiaTestObject.AutomationElement;

            if (virtualTestObject != null)
            {
                UIAHighlight.HighlightVirtualControl(elementToSearch, virtualTestObject.BoundingRect, _highlightColor);
            }
            else
            {
                UIAHighlight.HighlightAutomationElement(elementToSearch, _highlightColor);
            }

            return true;
        }
    }
}
