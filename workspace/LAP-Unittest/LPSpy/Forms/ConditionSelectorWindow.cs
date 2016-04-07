using LPReplayCore;
using LPReplayCore.UIA;
using LPUIAObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    public partial class ConditionSelectorWindow : Form
    {
        public ConditionSelectorWindow()
        {
            InitializeComponent();
        }

        private void ConditionSelectorWindow_Load(object sender, EventArgs e)
        {
            Debug.Assert(this.Tag != null);

            TestObjectNurse nurseObject = TestObjectNurse.FromTreeNode((TreeNode)this.Tag);
            UIATestObject testObject = new UIATestObject();

            FillListView(testObject);
        }

        private void FillListView(UIATestObject testObject)
        {
            listViewConditions.Items.Add(new ListViewItem("Hello"));
            //listViewConditions.Columns.AddRange();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
