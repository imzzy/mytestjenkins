using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPReplayCore;
using LAPResources;

namespace LPSpy
{
    public partial class NodeViewControl : UserControl, INodeView
    {

        private PresenterModel _presenterModel;

        private AddPropertiesWindow addPropertyWindow;

        TestObjectNurse _nurseObject;

        public NodeViewControl()
        {
            InitializeComponent();
            UpdateView();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Application.AddMessageFilter(new PropertyGridMessageFilter(propertyGrid.GetChildAtPoint(new Point(40, 40)),
                 new MouseEventHandler(propertyGrid.MouseUpHandler)));
        }

        /// <summary>
        /// update view with data from _nurseObject;
        /// </summary>
        private void UpdateView()
        {
            propertyGrid.SetTestObject(_nurseObject);

            if (_nurseObject == null)
            {
                this.txtNodeName.Text = "";
                this.txtUIAType.Text = "";
                return;
            }
            else
            {
                txtNodeName.Text = _nurseObject.NodeName;
                this.txtUIAType.Text = _nurseObject.TestObject.ControlTypeString;
                LoadImage(_nurseObject);
            }
        }

        private void txtNodeName_TextChanged(object sender, EventArgs e)
        {
            //it will automatically update the treeview
            _nurseObject.NodeName = txtNodeName.Text;
        }


        private void snapshotBox_Click(object sender, EventArgs e)
        {
            snapshotBox.SizeMode =
                (snapshotBox.SizeMode == PictureBoxSizeMode.StretchImage) ? PictureBoxSizeMode.Normal : PictureBoxSizeMode.StretchImage;
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            if (_nurseObject == null)
            {
                MessageBox.Show(StringResources.LPSpy_SpyMainWindow_SelectobjMsg);
                return;
            }

            addPropertyWindow = new AddPropertiesWindow();

            addPropertyWindow.Tag = _nurseObject.TreeNode;
            addPropertyWindow.Owner = this.ParentForm;

            if (addPropertyWindow.EndUpdating == null)
                addPropertyWindow.EndUpdating = new AddPropertiesWindow.EndAddingProperty(
                    nurseObject =>
                    {
                        propertyGrid.SetTestObject(nurseObject);
                        AppEnvironment.SetModelChanged(true);
                    }
                    );

            addPropertyWindow.ShowDialog();
        }

        private void btnDelectProperty_Click(object sender, EventArgs e)
        {
            propertyGrid.mnuPropertyRemove_Click(sender, e);
        }

        private void LoadImage(TestObjectNurse testNurse)
        {
            if (testNurse == null/* || testNurse.ImageFile == null*/)
            {
                snapshotBox.Image = null;
                snapshotBox2.TestObject = null;
                return;
            }

            snapshotBox.TestObject = snapshotBox2.TestObject = testNurse;

            string imageFile = testNurse.ImageFile;

            if (imageFile != null)
            {
                string path = AppEnvironment.GetModelResourceFilePath(imageFile);

                Image image = snapshotBox.Image;
                if (image != null)
                {
                    if (image.Height > snapshotBox.Height || image.Width > snapshotBox.Width)
                    {
                        snapshotBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        snapshotBox.SizeMode = PictureBoxSizeMode.Normal;
                    }

                }
            }
        }

        public void NodeChanged(TestObjectNurse nurseObject)
        {
            _nurseObject = nurseObject;
            UpdateView();
        }

        public void SetPresenter(PresenterModel presenterModel)
        {
            _presenterModel = presenterModel;
        }


        public void SetSelectNodeName(string name)
        {
            this.txtNodeName.Text = name;
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            _presenterModel.Highlight(_nurseObject);
        }

        private void NodeViewControl_Resize(object sender, EventArgs e)
        {
            AdjustSize();
        }

        private void AdjustSize()
        {
            const int borderSize = 5;

            propertyGrid.Height = this.Height - propertyGrid.Top - borderSize;
            propertyGrid.Width = Math.Min(600, this.Width - propertyGrid.Left - borderSize);
            tabProperties.Height = tabProperties.Parent.Height - 125;
        }
    }
}
