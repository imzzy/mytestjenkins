using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Input;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Automation;
using LPReplayCore.Common;
using LPReplayCore.UIA;
using LPReplayCore;
using LAPResources;
using LPCommon;
using LPSpy.UIA;
using LPUIAObjects;
using Point = System.Windows.Point;
using DrawingPoint = System.Drawing.Point;
using ListViewSubItem = System.Windows.Forms.ListViewItem.ListViewSubItem;

namespace LPSpy
{
    public partial class BatchAddWindow : Form
    {
        #region WIN32

        #endregion

        #region private properties
        ElementSpyer _spyer;

        private AutomationElement _clickedElement = null;
        //string _token = "";
        private List<AutomationElement> _ancestorElements = new List<AutomationElement>();
        private List<AutomationElement> _childElements = new List<AutomationElement>();

        public TreeUpdatedDelegate UpdateSelectedTree;
        public PropertiesListview propertiesListview;

        private CacheHandler _cacheHandler = new CacheHandler(AppEnvironment.CurrentDirectory);
        private Bitmap _bmpDeskTop = null;
        private ElementsBuilder _elementsBuilder = null;
        private Point _mousePoint;
        #endregion

        public BatchAddWindow()
        {
            _spyer = new ElementSpyer();
            _spyer.PointCaptured += ((mousepoint) =>
            {
                _mousePoint = mousepoint;
                _elementsBuilder.PointToElements(_mousePoint);
            });
            _spyer.SpyEnd += ((successful) =>
            {
                //this.Visible = true;
            });

            _elementsBuilder = new ElementsBuilder();
            _elementsBuilder.afterPointToElementsEventHander += afterPointToElementsEventHander;
            _elementsBuilder.afterReNewElementsByChildEventHander += afterRenewElementsByChildEventHander;
            _elementsBuilder.afterReNewElementsByAncestorEventHander += afterRenewElementsByAncestorEventHander;

            InitializeComponent();
            breadcrumbControl1.ItemClicked += BreadCrumb_Clicked;
            InitListviewControl();
            propertiesListview = new PropertiesListview(this.listView1);
            propertiesListview.Init();
        }

        internal void Start()
        {
            _spyer.Start();
        }

        #region private event handlers
        private void afterPointToElementsEventHander(object source, ElementsBuilderEventArgs args)
        {
            _clickedElement = args.element;
            _ancestorElements = args.ancestorElements;
            _childElements = args.childElements;

            //this form hasn't been created, therefore call the parent form's invoke function
            this.Owner.BeginInvoke(new Action(() =>
            {
                this.Hide();
                GetDesktopSnapshot();
                BuildListviewControl(_childElements, lapListViewObjects, lvItem_lnLinkItemClick);
                BuildBreadcrumbControl(_ancestorElements, breadcrumbControl1);
                this.Visible = true;
            }));
        }

        private void afterRenewElementsByChildEventHander(object source, ElementsBuilderEventArgs args)
        {
            _clickedElement = args.element;
            _ancestorElements = args.ancestorElements;
            _childElements = args.childElements;
            this.BeginInvoke(new Action(() =>
            {
                this.Hide();
                GetDesktopSnapshot();
                BuildListviewControl(_childElements, lapListViewObjects, lvItem_lnLinkItemClick);
                BuildBreadcrumbControl(_ancestorElements, breadcrumbControl1);
                this.Show();
            }));
        }

        private void afterRenewElementsByAncestorEventHander(object source, ElementsBuilderEventArgs args)
        {
            _clickedElement = args.element;
            _ancestorElements = args.ancestorElements;
            _childElements = args.childElements;

            this.BeginInvoke(new Action(() =>
            {
                this.Hide();
                GetDesktopSnapshot();
                BuildListviewControl(_childElements, lapListViewObjects, lvItem_lnLinkItemClick);
                this.Show();
            }));
        }


        #endregion

        #region private methods
        private void GetDesktopSnapshot()
        {
            if (SpySettings.CaptureSnapshots)
            {
                if (_bmpDeskTop != null)
                {
                    _bmpDeskTop.Dispose();
                    _bmpDeskTop = null;
                }
                _bmpDeskTop = Snapshot.GetDeskTopSnapShot();
            }
        }

        private void InitListviewControl()
        {
            int columnWith1 = this.lapListViewObjects.Width / 4;
            int columnWith2 = this.lapListViewObjects.Width - columnWith1 - 45;
            this.lapListViewObjects.Columns[0].Width = 20;
            this.lapListViewObjects.Columns[1].Width = columnWith1;
            this.lapListViewObjects.Columns[2].Width = columnWith2;
            this.lapListViewObjects.AllowColumnReorder = false;
            this.lapListViewObjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 25);
            lapListViewObjects.SmallImageList = imgList;
            //Get the header control handle
            /*  IntPtr header = UnsafeNativeMethods.SendMessage(this.lvObjects.Handle,
                          (0x1000 + 31), IntPtr.Zero, IntPtr.Zero);

              UInt32 style = UnsafeNativeMethods.GetWindowLong(header, NativeMethods.GWL_STYLE);
              style |= (UInt32)NativeMethods.WS_CLIPSIBLINGS;
              style |= (UInt32)NativeMethods.WS_CLIPCHILDREN;
              UnsafeNativeMethods.SetWindowLong(header, NativeMethods.GWL_STYLE, style);
              SafeNativeMethods.EnableWindow(header, false);

              style = UnsafeNativeMethods.GetWindowLong(this.lvObjects.Handle, NativeMethods.GWL_STYLE);
              style |= (UInt32)NativeMethods.WS_CLIPSIBLINGS;
              style |= (UInt32)NativeMethods.WS_CLIPCHILDREN;
              UnsafeNativeMethods.SetWindowLong(this.lvObjects.Handle, NativeMethods.GWL_STYLE, style);*/
        }

        internal static void BuildListviewControl(List<AutomationElement> childElements,
            LAPListViewControl lapListViewObjects,
            EventHandler linkItemClick
            )
        {
            int[] checkedIndexes = lapListViewObjects.CheckedIndicesArray;

            ListView.SelectedIndexCollection selectedIndexs = lapListViewObjects.SelectedIndices;

            int selectIndex = selectedIndexs.Count == 0 ? 0 : selectedIndexs[0];

            lapListViewObjects.BeginUpdate();

            foreach (Control control in lapListViewObjects.Controls)
            {
                if (control.Name.IndexOf("linkLabel") >= 0)
                {
                    control.Click -= linkItemClick;// lvItem_lnLinkItemClick;
                    control.Dispose();
                }
            }


            lapListViewObjects.Items.Clear();
            if (0 == childElements.Count)
            {
                lapListViewObjects.EndUpdate();
                return;
            }


            int index = 0;
            int i = 0, j = 0;

            ElementNotAvailableException elementNotAvailableException = null;

            List<ElementProperties> propertiesList = null;
            Utility.AsyncCall(() =>
            {
                try
                {
                    propertiesList = childElements.ConvertAll<ElementProperties>((element) =>
                    {
                        System.Windows.Rect rect = element.Cached.BoundingRectangle;
                        if (rect.IsEmpty) return null;
                        return new ElementProperties(element);
                    });
                }
                catch (ElementNotAvailableException ex)
                {
                    lapListViewObjects.Invoke(new Action(() => { lapListViewObjects.EndUpdate(); }));
                    //TODO, still not being handled by some handler
                    elementNotAvailableException = ex;
                }
            });

            if (elementNotAvailableException != null)
            {
                lapListViewObjects.EndUpdate();
                throw elementNotAvailableException;
            }

            foreach (var properties in propertiesList)
            {
                //zero size control will be skipped.
                if (properties == null) continue;

                ListViewSubItem[] lvSubItem = new ListViewSubItem[3];
                Graphics graphics = lapListViewObjects.CreateGraphics();

                string controlType = properties.ControlType.ControlTypeToString();
                LinkLabel linkLabel = new LinkLabel();
                linkLabel.Name = string.Format("linkLabel{0}", j++);
                linkLabel.Text = controlType;
                linkLabel.AutoSize = true;
                linkLabel.Click += linkItemClick; //lvItem_lnLinkItemClick;

                lvSubItem[0] = new ListViewSubItem() { Text = string.Empty };
                lvSubItem[1] = new ListViewSubItem() { Text = controlType, Tag = linkLabel };
                lvSubItem[2] = new ListViewSubItem() { Text = properties.Name };

                graphics.Dispose();

                ListViewItem lvItem = new ListViewItem(lvSubItem, 0);

                if (checkedIndexes.Length > 0 && i < checkedIndexes.Length)
                {
                    if (index == checkedIndexes[i])
                    {
                        lvItem.Checked = true;
                        ++i;
                    }
                }
                //   lvItem.Checked = true;
                lvItem.Tag = properties;
                lapListViewObjects.Items.Add(lvItem);
                ++index;
            }

            if (lapListViewObjects.Items.Count > 0)
            {
                lapListViewObjects.Focus();
                ListViewItem lvItem = selectIndex >= lapListViewObjects.Items.Count ? lapListViewObjects.Items[0] : lapListViewObjects.Items[selectIndex];
                lvItem.Selected = true;
                lvItem.Focused = true;
            }

            lapListViewObjects.EndUpdate();
        }

        internal static void BuildBreadcrumbControl(List<AutomationElement> ancestorElements, BreadcrumbControl breadcrumbControl)
        {
            int elementsCount = ancestorElements.Count;
            List<ElementProperties> properties = new List<ElementProperties>();

            Utility.AsyncCall(() =>
            {
                foreach (AutomationElement element in ancestorElements)
                {
                    string name = element.Current.Name;
                    properties.Add(new ElementProperties(element));
                }
            });

            breadcrumbControl.Clear();

            foreach (ElementProperties element in properties)
            {
                bool isNotEmpty = !string.IsNullOrEmpty(element.Name);
                string displayName = (isNotEmpty) ? element.ControlType.ControlTypeToString() + ": " + element.Name : element.ControlType.ControlTypeToString();

                breadcrumbControl.AddItem(displayName, isNotEmpty, element);
            }
        }

        private static TestObjectNurse BuildTestObjectsHierarchy(List<AutomationElement> ancestorElements,
            BreadcrumbControl breadcrumbControl,
            LAPListViewControl listView,
            Bitmap bmpDeskTop
            )
        {
            int ancestorCount = ancestorElements.Count;
            int breadcrumbCount = breadcrumbControl.Count;
            int indexOfAutomationElement = 0;

            UIATestObject topTestObject = UIAUtility.CreateTestObject(ancestorElements[0]);
            TestObjectNurse topNurseObject = new TestObjectNurse(topTestObject);
            TestObjectNurse currentNurseObject = topNurseObject;

            if (ancestorCount > breadcrumbCount)
            {
                for (indexOfAutomationElement = 1; indexOfAutomationElement < ancestorCount && breadcrumbCount < ancestorCount - indexOfAutomationElement; ++indexOfAutomationElement)
                {
                    AutomationElement element = ancestorElements[indexOfAutomationElement];
                    if (!string.IsNullOrEmpty(element.Current.Name))
                    {
                        UIATestObject childTestObject = UIAUtility.CreateTestObject(element);
                        currentNurseObject = (TestObjectNurse)currentNurseObject.AddChild(childTestObject);
                    }
                }
            }

            Breadcrumb[] breadcrumbs = breadcrumbControl.GetItems();
            foreach (Breadcrumb breadcrumb in breadcrumbs)
            {
                if (breadcrumb.Checked)
                {
                    UIATestObject childTestObject = UIAUtility.CreateTestObject((breadcrumb.Tag as ElementProperties).AutomationElement);
                    currentNurseObject = (TestObjectNurse)currentNurseObject.AddChild(childTestObject);
                }
            }

            ListView.CheckedListViewItemCollection selectedItems = listView.CheckedItems;

            foreach (ListViewItem item in selectedItems)
            {
                if (null == item.Tag) continue;
                ElementProperties ep = item.Tag as ElementProperties;
                TestObjectNurse subNurse = ep.ToNurseObject();

                subNurse.ImageFile = SnapshotHelper.SnapshotFileFromBitmap(subNurse.TestObject, bmpDeskTop);
                currentNurseObject.AddChild(subNurse);
            }
            return topNurseObject;
        }


        private void RefreshElements()
        {
            Utility.AsyncCall(() => this._elementsBuilder.RenewElementsByAncestor(this._clickedElement));
        }

        private void CheckOrUncheckAllItems(bool Check = true)
        {
            this.lapListViewObjects.BeginUpdate();
            ListView.ListViewItemCollection lvItemCollection = this.lapListViewObjects.Items;
            foreach (ListViewItem lvItem in lvItemCollection)
            {
                lvItem.Checked = Check;
            }
            this.lapListViewObjects.EndUpdate();
        }
        #endregion

        #region private control event handlers
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                propertiesListview.UpdateSelection(null);
            }
        }

        private void BreadCrumb_Clicked(object sender, BreadcrumbClickedEventArgs e)
        {
            Breadcrumb breadcrumb = e.Breadcrumb;
            ElementProperties ep = breadcrumb.Tag as ElementProperties;
            Utility.AsyncCall(() => this._elementsBuilder.RenewElementsByAncestor(ep.AutomationElement));
        }

        private void lvItem_lnLinkItemClick(object sender, EventArgs e)
        {
            ListViewItem lvItem = (sender as LinkLabel).Tag as ListViewItem;
            ElementProperties ep = lvItem.Tag as ElementProperties;
            _clickedElement = ep.AutomationElement;
            Utility.AsyncCall(() => _elementsBuilder.RenewElementsByChild(ep.AutomationElement));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
            if (this.UpdateSelectedTree != null)
            {
                TestObjectNurse topNurseObject = BuildTestObjectsHierarchy(
                    _ancestorElements,
                    breadcrumbControl1,
                    lapListViewObjects,
                    _bmpDeskTop);

                UpdateSelectedTree(topNurseObject,
                    null, null, null);
            }
            this._bmpDeskTop.Dispose();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
            this._bmpDeskTop.Dispose();
            this.Dispose();
        }

        private void BreadCrumbWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnCancel_Click(null, null);
        }

        private void lvObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Acquire SelectedItems reference.
            var selectedItems = this.lapListViewObjects.SelectedItems;

            if (selectedItems.Count > 0)
            {
                // Display text of first item selected.
                ElementProperties elementProperties = (ElementProperties)selectedItems[0].Tag;
                propertiesListview.FillListviewWithProperties(elementProperties);

                MemoryStream stream = SnapshotHelper.SnapshotFromBitmap(elementProperties.AutomationElement, _bmpDeskTop);
                if (stream == null) return;
                pictureBox1.Image = Image.FromStream(stream);
            }
            this.lapListViewObjects.Invalidate(true);
        }

        private void toolBtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshElements();
        }
        #endregion

    }
}

