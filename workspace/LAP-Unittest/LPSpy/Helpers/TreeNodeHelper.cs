using LAPResources;
using LPReplayCore;
using LPReplayCore.Interfaces;
using LPReplayCore.UIA;
using LPUIAObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    class TreeNodeHelper
    {
        
        public enum TreeNodeImage : int
        {
            Window = 0,
            Button = 1,
            CheckBox = 2,
            Calendar = 3,
            ComboBox = 4,
            Dialog = 5,
            Edit = 6,
            Editor = 7,
            Image = 8,
            Label = 9,
            Link = 10,
            List = 11,
            Menu = 12,
            RadioButton = 13,
            ScrollBar = 14,
            Tab = 15,
            ToolBar = 15,
            Tree = 17,
            Custom = 18
        }

        private static System.Windows.Forms.ImageList treeImageList = new System.Windows.Forms.ImageList();

        static TreeNodeHelper()
        {
            Image[] images = new Image[] {
                ImageResources.Window,      //0, "Window.png"
                ImageResources.Button,      //1, "Button.png"
                ImageResources.Checkbox,    //2, "Checkbox.png"
                ImageResources.Calendar,    //3, "Calendar.png"
                ImageResources.ComboBox,    //4, "ComboBox.png"
                ImageResources.Dialog,      //5, "Dialog.png"
                ImageResources.Edit,        //6, "Edit.png"
                ImageResources.Editor,      //7, "Editor.png"
                ImageResources.Image,       //8, "Image.png"
                ImageResources.Label,       //9, "Label.png"
                ImageResources.Link,        //10, "Link.png"
                ImageResources.List,        //11, "List.png"
                ImageResources.Menu,        //12, "Menu.png"
                ImageResources.RadioButton, //13, "RadioButton.png"
                ImageResources.ScrollBar,   //14, "ScrollBar.png"
                ImageResources.Tab,         //15, "Tab.png"
                ImageResources.ToolBar,     //16, "ToolBar.png"
                ImageResources.Tree,        //17, "Tree.png"
                ImageResources.UiObject     //18, "UiObject.png"
            };
            treeImageList.Images.AddRange(images);
        }
        
            

        public static void FixTreeNodeImage(TreeNode treeNode, string contentType)
        {
            TreeNodeImage index;
            if (!Enum.TryParse<TreeNodeImage>(contentType, out index))
            {
                index = TreeNodeImage.Custom;
            }
            treeNode.ImageIndex = (int)index;
            treeNode.SelectedImageIndex = (int)index;
        }

        public static ImageList TreeImageList
        {
            get { return treeImageList; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newControls"></param>
        /// <param name="parentNode"></param>
        /// <returns>return whether virtual controls are changed</returns>
        public static bool MergeVirtualControlsToTree(VirtualTestObject[] newControls, TreeNode parentNode)
        {
            TestObjectNurse parentNurse = TestObjectNurse.FromTreeNode(parentNode);

            //remove the previously attached nodes.
            List<ITestObject> oldControls = new List<ITestObject>(parentNurse.Children).FindAll(to => ((TestObjectNurse)to).TestObject is VirtualTestObject);
            if (oldControls.Count() == newControls.Count())
            {
                int i = 0;
                foreach (TestObjectNurse oldControl in oldControls)
                {
                    VirtualTestObject oldObject = (VirtualTestObject)oldControl.TestObject;
                    VirtualTestObject newObject = newControls[i];
                    if (oldObject != newObject) break;
                    ++i;
                }
                if (i == newControls.Count()) return false; //exactly the same, not update.
            }
            foreach (ITestObject testObject in oldControls)
            {
                parentNurse.RemoveChild(testObject);
            }

            //Add new virtual nodes
            foreach (VirtualTestObject testObject in newControls)
            {
                parentNurse.AddChild(testObject);
            }
            return true;
        }

    }
}
