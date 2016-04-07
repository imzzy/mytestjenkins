using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LPUIAObjects;
using LPReplayCore;
using LPReplayCore.UIA;
using System.Diagnostics;
using LPReplayCore.Model;
using LAPResources;
using System.Threading;
using LPReplayCore.Interfaces;

namespace LPSpy
{
    public partial class AddPropertiesWindow : Form
    {
        TestObjectNurse _condition;
        public delegate void EndAddingProperty(TestObjectNurse nurseObject);
        public EndAddingProperty EndUpdating;

        public AddPropertiesWindow()
        {
            InitializeComponent();            
        }

        public int LoadProperties(DataGridView grid, TestObjectNurse nurseObject)
        {
            ITestObject testObject = nurseObject.TestObject;

            int count = 0;

            foreach (KeyValuePair<string, string> pair in nurseObject.CachedProperties)
            {
                if (!testObject.Properties.ContainsKey(pair.Key) && pair.Key != ControlKeys.ImagePath
                    && pair.Key != UIAControlKeys.BoundingRectangle
                    )
                {
                    string displayName = ControlKeysManager.GetDisplayString(pair.Key);
                    grid.Rows.Add(new object[] { displayName, pair.Value });
                    count++;
                }
            }

            if (!_condition.TestObject.Properties.ContainsKey(ControlKeys.Index))
            {
                grid.Rows.Add(new object[] { ControlKeysManager.GetDisplayString(ControlKeys.Index), 0 });
                count++;
            }
            return count;
        }

        private void LoadData(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                _condition = TestObjectNurse.FromTreeNode((TreeNode)this.Tag);
                int count = LoadProperties(this.propertyGrid, _condition);

                if (count == 0)
                {
                    MessageBox.Show("No more properties to add");
                    this.Dispose();
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            TestObjectNurse nurseObject = TestObjectNurse.FromTreeNode((TreeNode)this.Tag);

            SpyWindowHelper.AddSelectedProperty(propertyGrid, nurseObject);

            if (EndUpdating != null)
            {
                EndUpdating(nurseObject);
            }
            this.Dispose();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                TestObjectNurse nurseObject = _condition = TestObjectNurse.FromTreeNode((TreeNode)this.Tag);
                ReloadElementData(this.propertyGrid, nurseObject);
            }
        }

        public void ReloadElementData(DataGridView grid, TestObjectNurse nurseObject)
        {
             UIATestObject existingObject = (UIATestObject) nurseObject.TestObject;
             if (existingObject.AutomationElement == null)
            {
                MessageBox.Show("Cannot load object");
            }

            UIATestObject newObject;
            
            newObject = UIAUtility.CreateTestObject(existingObject.AutomationElement, nurseObject.NodeName);

            foreach (string key in newObject.Properties.Keys)
            {
                if (!existingObject.Contains(key))
                {
                    string displayName = ControlKeysManager.GetDisplayString(key);
                    string property = newObject.Properties[key];

                    grid.Rows.Add(new object[] { displayName, property });
                }
            }
        }

        private void toolStripHighlight_Click(object sender, EventArgs e)
        {
            Thread ht = new Thread(HighlightObjectThread);
            ht.Start();
        }


        private void HighlightObjectThread()
        {
            UIATestObject testObject = (UIATestObject)_condition.TestObject;
            if (!UIAHighlight.SearchAndHighlight(testObject))
            {
                MessageBox.Show(StringResources.LPSpy_SpyMainWindow_CannotFindObjectMsg);
            }
        }
    }
}
