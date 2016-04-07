using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Windows;
using LPCommon;
using LPReplayCore;
using LPReplayCore.UIA;
using LPSpy.UIA;
using LPUIAObjects;
using LPReplayCore.Common;
using LPReplayCore.Model;
using System.IO;
using LAPResources;

namespace LPSpy
{
    public partial class UIASpyWindow : Form
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Thread _controlSpyThread = null;

        private List<AutomationElement> _parentsList = new List<AutomationElement>();
        private AutomationElement _leftElement, _rightElement;

        private bool _alwaysOnTop;

        private ElementSpyer _spyer;

        private ElementProperties _elementProperties;
        private AutomationElement _prevousElement;

        MemoryStream _stream;

        public UIASpyWindow()
        {

            _spyer = new ElementSpyer();
            _spyer.SpyEnd += ((successful) => {
                StopControlSpyThread();
                if (successful) { this.ShowWindow = true; } else this.Close(); 
            });
            _spyer.PointCaptured += this.PointToSpiedData;

            InitializeComponent();

            _alwaysOnTop = this.TopMost;


            this.MinimumSize = new System.Drawing.Size(326, 500);
            this.MaximumSize = new System.Drawing.Size(800, 800);

            _alwaysOnTop = btnPin.Checked;

            this.TopMost = _alwaysOnTop;
        }

        public bool ShowWindow
        {
            get
            {
                if (_alwaysOnTop) return true;
                return Visible;
            }
            set
            {
                if (!_alwaysOnTop)
                {
                    this.Invoke(new Action(() => { Visible = value; }));
                }
            }
        }


        public static MemoryStream CaptureTempSnapshot(AutomationElement properties)
        {
            if (properties == null)
            {
                throw new ElementNotAvailableException();
            }
            //get rectangle of TO
            Rect rect = properties.Current.BoundingRectangle;

            if (rect.Width == 0 || rect.Height == 0)
            {
                throw new ApplicationException("Element size is 0");
            }
            System.Drawing.Rectangle actualRect = System.Drawing.Rectangle.FromLTRB((int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom);

            Snapshot snapshot = new Snapshot();

            MemoryStream stream = snapshot.CaptureInflatedRectangle(actualRect);
            return stream;
        }

        private void btnSpy_Click(object sender, EventArgs e)
        {
            this.treeObjects.Nodes.Clear();
            this.propertiesTable.Rows.Clear();

            _spyer.Start();

            StartControlSpyThread();
            this.ShowWindow = false;
        }

        private void StartControlSpyThread()
        {
            _controlSpyThread = new Thread(ControlSpyThreadProc);
            _controlSpyThread.Start();
        }

        private void StopControlSpyThread()
        {
            _controlSpyThread.Abort();
        }

        private void ControlSpyThreadProc()
        {
            Point currentPosition, lastPosition = new Point(0, 0);
            while (true)
            {
                Thread.Sleep(500);
                currentPosition = SafeNativeMethods.GetCursorPos();
                if (lastPosition != currentPosition)
                {
                    lastPosition = currentPosition;
                    UpdateElementData(currentPosition, false);
                }
            }
        }


        private void PointToSpiedData(Point mousePoint)
        {
            try
            {
                UpdateElementData(mousePoint, true);

                _stream = CaptureTempSnapshot(_elementProperties.AutomationElement);


                this.ShowWindow = true;
                //this.treeObjects.Focus();
                //ConstructElementsTree(clickedElement);
            }
            catch (ElementNotAvailableException)
            {
                //Element is no longer available, please reselect the element
                MessageBox.Show(StringResources.LPSpy_ElementNotAvailableException);
            }
        }

        private void UpdateElementData(System.Windows.Point mousePoint, bool clicked)
        {
            _parentsList.Clear();

            AutomationElement hoveredElement = null;

            //need to use the Async method to get the object
            Utility.AsyncCall(() => { 
                try
                {
                    hoveredElement = AutomationElement.FromPoint(mousePoint);
                    if (hoveredElement != null)
                    {
                        _elementProperties = new ElementProperties(hoveredElement);
                    }
                }
                catch (FileNotFoundException ex/*TODO fake exception, should be replaced with real one*/)
                {
                    _Logger.WriteLog(ex.Message.ToString());
                    _Logger.WriteLog(ex.Source);
                    _Logger.WriteLog(ex.TargetSite.ToString());
                    if (ex.InnerException != null)
                    {
                        _Logger.WriteLog(ex.InnerException.Message);
                    }
                }
            });

            if (hoveredElement != null & hoveredElement != _prevousElement)
            {
                _prevousElement = hoveredElement;
                
                HighlightRectangle hightlightRect = UIAHighlight.HighlightThread_Spy(hoveredElement, infinite:true);

                if (clicked || _alwaysOnTop)
                {
                    if (clicked)
                    {
                        if (hightlightRect != null)
                        {
                            hightlightRect.Visible = false;
                            Thread.Sleep(500);
                        }
                    }
                    this.Invoke(new Action(() =>
                    {

                        _leftElement = UIAUtility.GetPreviousElement(hoveredElement);
                        _rightElement = UIAUtility.GetNextElement(hoveredElement);
                        _parentsList = UIAUtility.GetAutomationElementsLine(hoveredElement);
                        /*
                        AutomationElement rootElement = AutomationElement.RootElement;
                        while (parent != null)
                        {
                            if (!(parent.Current.NativeWindowHandle == rootElement.Current.NativeWindowHandle && rootElement.Current.Name == parent.Current.Name))
                            {
                                parentsList.Add(parent);
                            }
                            parent = TreeWalker.ControlViewWalker.GetParent(parent);
                        }

                        parentsList.Reverse();
                         */
                        this.treeObjects.Nodes.Clear();

                        TreeNodeCollection currentTreeNodeCollection = this.treeObjects.Nodes;
                        TreeNode currentTreeNode = null;
                        foreach (AutomationElement element in _parentsList)
                        {
                            currentTreeNode = currentTreeNodeCollection.Add(_parentsList.IndexOf(element).ToString(), element.Current.ControlType.ControlTypeToString() + ": " + element.Current.Name);
                            currentTreeNode.Tag = element;
                            currentTreeNodeCollection = currentTreeNode.Nodes;
                        }

                        if (_leftElement != null)
                        {
                            currentTreeNode = currentTreeNodeCollection.Add("left", "[Left Object]" + _leftElement.Current.ControlType.ControlTypeToString() + ": " + _leftElement.Current.Name);
                            currentTreeNode.Tag = _leftElement;
                        }

                        currentTreeNode = currentTreeNodeCollection.Add("self", hoveredElement.Current.ControlType.ControlTypeToString() + ": " + hoveredElement.Current.Name);
                        this.treeObjects.SelectedNode = currentTreeNode;
                        currentTreeNode.Tag = hoveredElement;

                        if (_rightElement != null)
                        {
                            currentTreeNode = currentTreeNodeCollection.Add("right", "[Right Object]" + _rightElement.Current.ControlType.ControlTypeToString() + ": " + _rightElement.Current.Name);
                            currentTreeNode.Tag = _rightElement;
                        }
                        this.treeObjects.ExpandAll();
                        updatePropertyTable(hoveredElement);
                    }));
                }
            }
        }


        private void updatePropertyTable(AutomationElement e)
        {
            this.propertiesTable.Rows.Clear();
            // Runtime type
            string controltype = e.Current.ControlType.ControlTypeToString();
            this.propertiesTable.Rows.Add("Control Type", controltype);

            //title
            if (controltype.Equals("window", StringComparison.InvariantCultureIgnoreCase))
            {
                this.propertiesTable.Rows.Add("* title", e.Current.Name);
            }
            else
            {
                // Name            
                this.propertiesTable.Rows.Add("* Name", e.Current.Name);
            }
            //Attached Text
            try
            {
                AutomationElement attachmentElement = e.Current.LabeledBy;
                if (attachmentElement != null)
                    this.propertiesTable.Rows.Add("* Attachedtext", attachmentElement.Current.Name);
            }
            catch { }

            //Text
            string text = "";
            try
            {
                text = ((TextPattern)e.GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(-1);
            }
            catch { }
            try
            {
                text = ((ValuePattern)e.GetCurrentPattern(ValuePattern.Pattern)).Current.Value;
            }
            catch { }
            try
            {
                text = (string)e.GetCurrentPropertyValue(LegacyIAccessiblePattern.ValueProperty);
            }
            catch { }

            if (controltype.ToLower() == "link")
            {
                this.propertiesTable.Rows.Add("* URL", text);
            }
            else
            {
                this.propertiesTable.Rows.Add("* Text", text);
            }


            //Process ID
            this.propertiesTable.Rows.Add("* ProcessID", e.Current.ProcessId.ToString());

            //Handle
            try
            {
                string handle = e.Current.NativeWindowHandle.ToString();
                this.propertiesTable.Rows.Add("* Handle", e.Current.NativeWindowHandle.ToString());
            }
            catch
            { }

            // help text
            try
            {
                this.propertiesTable.Rows.Add("* HelpText", e.Current.HelpText);
            }
            catch
            { }

            //X and Y
            try
            {
                Point clickedPoint = e.GetClickablePoint();
                this.propertiesTable.Rows.Add("X", clickedPoint.X);
                this.propertiesTable.Rows.Add("Y", clickedPoint.Y);
            }
            catch { }

            //Bound
            try
            {
                
                Rect rectSelected = e.Current.BoundingRectangle;
                this.propertiesTable.Rows.Add("Width", (rectSelected.Right - rectSelected.Left).ToString());
                this.propertiesTable.Rows.Add("Height", (rectSelected.Bottom - rectSelected.Top).ToString());
            }
            catch { }
        }

        private void treeObjects_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //get the IUIAutomationElement
            try
            {
                AutomationElement selectedElement = (AutomationElement)treeObjects.SelectedNode.Tag;
                AutomationElement currentElement = (AutomationElement)e.Node.Tag;
                if (!(selectedElement.Current.Name == currentElement.Current.Name && selectedElement.Current.NativeWindowHandle == currentElement.Current.NativeWindowHandle))
                {
                    //this.propertytable.Rows.Clear();
                    updatePropertyTable(currentElement);
                }
            }
            catch
            {
                this.propertiesTable.Rows.Clear();
            }
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            try
            {
                UIAHighlight.HighlightThread_Spy((AutomationElement)treeObjects.SelectedNode.Tag);
            }
            catch
            { }
        }

        private void UIASpyWindow_Resize(object sender, EventArgs e)
        {
            System.Drawing.Size windowSize = this.Size;

            this.treeObjects.Height = panelUpper.Height - 55;
            this.propertiesTable.Height = panelLower.Height - 40;
        }

        private void btnPin_Click(object sender, EventArgs e)
        {
            btnPin.Checked = !btnPin.Checked;
            _alwaysOnTop = btnPin.Checked;

            this.TopMost = _alwaysOnTop;
        }

        /*
        private void btnEditVirtualControl_Click(object sender, EventArgs e)
        {
            
            VirtualTestObject[] virtualControls = new VirtualTestObject[0];

            System.Drawing.Image controlImage = System.Drawing.Image.FromStream(_stream);
            UIATestObject testObject = (UIATestObject) _elementProperties.ToTestObject();
            VirtualControlHelper.EditVirtualControls(testObject, controlImage, ref virtualControls);


        }*/

        private void btnAddToRepo_Click(object sender, EventArgs e)
        {

        }

    }
}
