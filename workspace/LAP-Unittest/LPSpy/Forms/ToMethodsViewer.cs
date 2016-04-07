using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using LPReplayCore;
using LPUIAObjects;
using LPCommon;
using LAPResources;

namespace LPSpy
{
    public partial class ToMethodsViewer : Form
    {
        public ToMethodsViewer(TestObjectNurse nurseObject, System.Windows.Point position) 
        {
            _nurseObject = nurseObject;
            _mouseposition = position;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
            InitializelvControl();
            buildlvControl();
        }

#region private properties
        private TestObjectNurse _nurseObject = null;
        private System.Windows.Point _mouseposition;
        private List<string> _resultList = new List<string>();
        private static string[] _hardCodeProperties = new string[]
        {
            "title",
            "name",
            "text",
            "hwnd",
            "handle",
            "x",
            "y",
            "height",
            "width",
            "enabled",
            "focused",
            "helptext",
            "value",
            "labeledtext",
            "processid"
        };

        private static string[] _hardCodeMethods = new string[]
        {
            "Click()",
            "DBClick()",
            "Exist()",
            "HScroll()",
            "VScroll()",
            "Drag()",
            "Drop()"
        };
#endregion

        public List<string> TestObjectInfomation
        {
            get { return _resultList; }
        } 

#region private methods
        private void InitializelvControl()
        {
            if (null == this._nurseObject)
                 return;

            this.lvToInfo.Columns[0].Width = 20;
            this.lvToInfo.Columns[1].Width = this.lvToInfo.Width - 45;
            this.lvToInfo.AllowColumnReorder = false;
            this.lvToInfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 20);
            lvToInfo.SmallImageList = imgList;

            this.lvToInfo.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
                new ListViewGroup(StringResources.LPSpy_ToMethodViewer_GroupNameMethods), 
                new ListViewGroup(StringResources.LPSpy_ToMethodViewer_GroupNameProperties)
            });
        }

        private void buildlvControl()
        {
            //AutomationElement ae = this._uiaCondition.AutomationElement;
            //AutomationPattern[] aePatterns = ae.GetSupportedPatterns();
            //AutomationProperty[] aeProperties = ae.GetSupportedProperties();

            this.lvToInfo.BeginUpdate();
            this.lvToInfo.Items.Clear();

            foreach (var method in _hardCodeMethods)
            {
                ListViewItem item = new ListViewItem(new string[] { "", method }, this.lvToInfo.Groups[0]);
                this.lvToInfo.Items.Add(item);
            }

            foreach (var property in _hardCodeProperties)
            {
                ListViewItem item = new ListViewItem(new string[] { "", property }, this.lvToInfo.Groups[1]);
                this.lvToInfo.Items.Add(item);
            }
            this.lvToInfo.EndUpdate();

        }
#endregion

#region private event handlers
        private void btnOK_Click(object sender, EventArgs e)
        {
            _resultList.Clear();
            ListView.CheckedListViewItemCollection lvCheckedItems = this.lvToInfo.CheckedItems;
            _resultList = lvCheckedItems.Cast<ListViewItem>().Select((lvItem) => lvItem.SubItems[1].Text.ToString()).ToList();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _resultList.Clear();
            DialogResult = DialogResult.Cancel;
        }

        private void ToMethodsViewer_Load(object sender, EventArgs e)
        {
            this._mouseposition.X -= this.Width / 2;
            this._mouseposition.Y -= this.Height / 2;
            this.Location = new Point((int)_mouseposition.X, (int)_mouseposition.Y);
        }
#endregion
    }
}
