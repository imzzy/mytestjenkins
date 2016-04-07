using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    class BreadcrumbControl : System.Windows.Forms.UserControl
    {
        public const string PrefixCheckBox = "CK";
        public const string PrefixLinkLabel = "LL";
        public const string PrefixArrowSeparator = "BC";

        public delegate void ItemClickedDelegate(Object sender, BreadcrumbClickedEventArgs e);

        //used to item group count
        private int _itemCount;
        private FlowLayoutPanel flowLayoutPanel1;
        private LAPResourceManager.ResourceControl resourceControl1;

        private ArrayList _tags = new ArrayList();

        public BreadcrumbControl()
        {
            InitializeComponent();
        }


        bool _showCheckbox = true;

        #region Interfaces
        public bool ShowCheckBox
        {
            get
            {
                return _showCheckbox;
            }
            set
            {
                if (this.Count > 0)
                {
                    throw new InvalidOperationException("Cannot change this value when items exists.");
                }
                _showCheckbox = value;
            }
        }

        /////////////Raised event to pass menu value back to hosted form////////////////
        public event ItemClickedDelegate ItemClicked;

        public void AddItem(string linkText)
        {
            AddBreadcrumbLink(linkText);
        }

        public void AddItem(string linkText, bool isChecked, object tag)
        {
            AddBreadcrumbLink(linkText, isChecked);
            if (_tags.Count < _itemCount)
            {
                while (_tags.Count < _itemCount) _tags.Add(null);
            }
            _tags[_itemCount - 1] = tag;
        }

        public void AddItems(string[] linkTexts)
        {
            foreach (string linkText in linkTexts)
            {
                AddBreadcrumbLink(linkText);
            }
        }

        public int Count
        {
            get
            {
                return _itemCount;
            }
        }

        public void Clear()
        {
            ClearItems(-1);
        }


        #endregion



        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BreadcrumbControl));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.SuspendLayout();
            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resourceControl1
            // 
            this.resourceControl1.ResAssemblyName = "LAPResources";
            this.resourceControl1.UIComponentName = "LPSpy.BreadcrumbControl";
            this.resourceControl1.reInitResManger(ref resources);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
           
            // 
            // BreadcrumbControl
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BreadcrumbControl";
            this.ResumeLayout(false);

        }

        internal ControlCollection ChildControls
        {
            get
            {
                //for unit test purpose
                return flowLayoutPanel1.Controls;
            }
        }

        internal void RemoveLaterItems(string tagIdentifierForItemDeletion)
        {
            int indexClicked;

            indexClicked = int.Parse(tagIdentifierForItemDeletion);

            ClearItems(indexClicked);

            _itemCount = indexClicked;
        }


        internal bool ClearItems(int indexClicked)
        {
            int index;

            bool itemsCleared = false;

            List<Control> controlsToRemove = new List<Control>();

            foreach (Control thisControl in flowLayoutPanel1.Controls)
            {
                // identify labels and link labels for that tag set (1's, 2's, etc.)
                index = (int)(thisControl.Tag);
                if (index > indexClicked)
                {
                    //_increasingLength = _increasingLength - thisControl.Width;
                    controlsToRemove.Add(thisControl);
                }
            }
            itemsCleared = controlsToRemove.Count > 0;

            foreach (Control control in controlsToRemove)
            {
                flowLayoutPanel1.Controls.Remove(control);
            }
            _itemCount = Math.Max(indexClicked, 0);

            return itemsCleared;
        }

        private void AddBreadcrumbLink(string linkText, bool isChecked = false)
        {
            EnableDisableLastLink(true); //enable the last one

            if (_itemCount > 0)
            {
                //add the > symbol
                Label label = new Label();
                label.Top = 0;
                //label.Left = _increasingLength;
                //create unique name
                label.Name = PrefixArrowSeparator + _itemCount;
                label.Text = ">";
                //the tag will be used to identify what symbol to delete and what was clicked
                label.Tag = _itemCount; //strArrayList.Count - 1
                //important!  autosize the control so everything has a smooth look
                label.AutoSize = true;
                //now add the control to your form
                flowLayoutPanel1.Controls.Add(label);
            }

            if (ShowCheckBox)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Margin = new Padding(0, -3, 0, 0);
                checkbox.Name = PrefixCheckBox + _itemCount;
                checkbox.AutoSize = true;
                checkbox.Checked = isChecked;
                checkbox.Tag = _itemCount;

                flowLayoutPanel1.Controls.Add(checkbox);
                //_increasingLength += checkbox.Width;
            }

            //add the new linklabel
            LinkLabel linkLabel = new LinkLabel();
            linkLabel.Top = 0;
            linkLabel.Name = PrefixLinkLabel + _itemCount;
            //linkLabel.Left = _increasingLength;
            linkLabel.Text = linkText;

            linkLabel.AutoSize = true;
            linkLabel.DisabledLinkColor = Color.Black;
            
            //the tag will be used to identify what linklabel to delete and what was clicked
            linkLabel.Tag = _itemCount;
            flowLayoutPanel1.Controls.Add(linkLabel);

            _itemCount++;

            //_increasingLength += linkLabel.Width;

            //add a handler for the linklabel
            //same userd for all and we will use the control.tag property
            // to see which was clicked
            linkLabel.Click += myLinkLabel_Click;

            linkLabel.Enabled = false;
        }

        private bool EnableDisableLastLink(bool enable)
        {
            if (_itemCount == 0) return false;
            int lastControlID = _itemCount - 1;
            Control[] controls = flowLayoutPanel1.Controls.Find(PrefixLinkLabel + lastControlID, false);
            Debug.Assert(controls.Length == 1);
            LinkLabel linkLabel = (LinkLabel)controls[0];

            linkLabel.Enabled = enable;
            return true;
        }

        private void myLinkLabel_Click(object sender, System.EventArgs e)
        {
            //event is raised to the form that holds this control
            LinkLabel label = (LinkLabel)sender;
            Breadcrumb crumb = GetBreadcrumbFromIndex((int)label.Tag);

            ItemClicked(this, new BreadcrumbClickedEventArgs(crumb)); //TODO: originally sender
            //we are moving back in the menu so we need to adjust our menu.
            RemoveLaterItems(((Control)sender).Tag.ToString()); //TODO
            label.Enabled = false;
        }

        private Breadcrumb GetBreadcrumbFromIndex(string tag)
        {
            int index = int.Parse(tag);
            return GetBreadcrumbFromIndex(index);
        }


        private Breadcrumb GetBreadcrumbFromIndex(int index)
        {
            Breadcrumb breadcrumb = new Breadcrumb();

            Control[] controls = flowLayoutPanel1.Controls.Find(PrefixCheckBox + index.ToString(), true);
            CheckBox checkbox = (controls.Length > 0) ? (CheckBox)controls[0] : null;
            breadcrumb.Checked = checkbox != null && checkbox.Checked;

            controls = flowLayoutPanel1.Controls.Find(PrefixLinkLabel + index.ToString(), true);
            LinkLabel label = (controls.Length > 0) ? (LinkLabel)controls[0] : null;
            breadcrumb.Text = (label != null) ? label.Text : null;

            breadcrumb.Tag = _tags[index];

            return breadcrumb;
        }

        internal Breadcrumb[] GetItems()
        {
            List<Breadcrumb> list = new List<Breadcrumb>(_itemCount);
            for (int i = 0; i < _itemCount; i++)
            {
                Breadcrumb breadcrumb = GetBreadcrumbFromIndex(i);

                list.Add(breadcrumb);
            }
            return list.ToArray();
        }
    }


    public class Breadcrumb
    {
        public string Text;
        public bool Checked;
        public object Tag;
    }


    public class BreadcrumbClickedEventArgs : System.EventArgs
    {
        public Breadcrumb Breadcrumb;

        public BreadcrumbClickedEventArgs(Breadcrumb crumb)
        {
            Breadcrumb = new Breadcrumb();
            this.Breadcrumb = crumb;
        }
    }
}
