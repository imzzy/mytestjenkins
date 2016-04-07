using LPReplayCore.Interfaces;
using LPReplayCore.UIA;
using LPUIAObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    public static class VirtualControlHelper
    {
        public static VirtualTestObject[] GetVirtualControls(ITestObject testObjects)
        {
            List<VirtualTestObject> list = new List<VirtualTestObject>();

            foreach (ITestObject childTestObject in testObjects.Children)
            {
                if (childTestObject is VirtualTestObject)
                {
                    list.Add(childTestObject as VirtualTestObject);
                }
            }
            return list.ToArray();
        }

        public static bool EditVirtualControls(UIATestObject testObject, Image image, ref VirtualTestObject[] virtualControls)
        {
            //TreeNode node = (TreeNode)_selectedNode;

            VirtualControlEditWindow editWindow = new VirtualControlEditWindow();

            //Get image and the virtual controls list of the test object
            editWindow.SetImage(image);
            editWindow.ParentObject = testObject;

            //get the current test object
            editWindow.VirtualControls = virtualControls;

            //Launch the edit window with the parameters
            DialogResult result = editWindow.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Cancel) return false;

            //get the virtual controls from the edit window
            VirtualTestObject[] controls = editWindow.VirtualControls;

            //TODO merge the controls to the tree
            Debug.WriteLine(DumpVirtualControls(controls));

            virtualControls = controls;
            return true;
        }


        public static string DumpVirtualControls(VirtualTestObject[] controls)
        {
            List<VirtualTestObject> virtualControls = new List<VirtualTestObject>(controls);
            string[] ss = virtualControls.ConvertAll(control => string.Format("{0}: {1}, {2}, {3}, {4}",
                control.NodeName, control.BoundingRect.Left, control.BoundingRect.Top,
                control.BoundingRect.Width, control.BoundingRect.Height)).ToArray();

            return string.Join("\r\n", ss);
        }


        public static void MergeVirtualControls(ITestObject testObject, VirtualTestObject[] virtualObjects)
        {
            //Remove existing virtual objects
            foreach (ITestObject childObject in testObject.Children)
            {
                if (childObject is VirtualTestObject)
                {
                    testObject.RemoveChild(childObject);
                }
            }

            //Add new virtualObjects
            foreach (VirtualTestObject virtualObject in virtualObjects)
            {
                testObject.AddChild(virtualObject);
            }
        }
    }
}
