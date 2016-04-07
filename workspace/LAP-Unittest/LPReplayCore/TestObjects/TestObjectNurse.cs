using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.UIA;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPReplayCore
{
    /// <summary>
    /// Provide the tree node binding
    /// </summary>
    public class TestObjectNurse: TestObjectBase, ITextSearch
    {
        
        ITestObject _testObject;
        private TreeView _treeView;
        private TreeNode _treeNode;

        public TestObjectNurse(ITestObject testObject)
        {
            _testObject = testObject;
            _cachedProperties = testObject.GetContext<CachedPropertyGroup>();

            Bind(new TreeNode());
        }

        public TestObjectNurse(TreeView treeView)
        {
            treeView.Tag = this;
            _treeView = treeView;
            _testObject = new TestObjectBase(); //dump test object
        }

        public void Bind(TreeNode treeNode)
        {
            _treeNode = treeNode;
            _treeNode.Tag = this;

            RefreshName();
        }

        public void Clear()
        {
            while (Children.Count > 0)
            {
                this.RemoveChild(Children[0]);
            }

            if (Nodes != null)
            {
                Nodes.Clear();
            }
        }

        public override bool RemoveChild(ITestObject testObject)
        {
            bool removed = false;
            TestObjectNurse childNurse = testObject as TestObjectNurse;
            ITestObject realTestObject = (childNurse == null) ? testObject : childNurse.TestObject;

            if (childNurse != null)
            {
                childNurse.TreeNode.Remove();

                AddToRecycleBin(childNurse);
                base.RemoveChild(childNurse);
            }

            foreach (ITestObject childTestObject in Children)
            {
                TestObjectNurse nurse = childTestObject as TestObjectNurse;
                if (nurse.TestObject == testObject)
                {
                    nurse.TreeNode.Remove();
                    base.RemoveChild(nurse);
                    removed = true;
                    break;
                }
            }

            if (realTestObject != null)
            {
                this.TestObject.RemoveChild(realTestObject);
                removed = true;
            }

            return removed;
        }

        private void AddToRecycleBin(TestObjectNurse childNurse)
        {
            TestObjectNurse nurse = childNurse;

            //find root nurse
            while (nurse.IsRoot == false && nurse.ParentNurse != null)
            {
                nurse = nurse.ParentNurse;
            }
            nurse.RecycleBin.Add(childNurse);
        }

        public override ITestObject AddChild(ITestObject childObject)
        {
            if (childObject == null) return null;

            TestObjectNurse childNurse  = childObject as TestObjectNurse;

            if (childNurse == null)
            {
                //childObject is not nurse object
                childNurse = new TestObjectNurse(childObject);
            }
            
            ITestObject childTestObject = childNurse.TestObject;

            //connect 2 test objects
            if (childTestObject.Parent != _testObject && !this.IsRoot)
            {
                _testObject.AddChild(childTestObject);
            }
            
            //connect 2 nurses object
            base.AddChild(childNurse);

            if (Nodes != null)
            {
                Nodes.Add(childNurse.TreeNode);
            }
            return childNurse;
        }

        public void AddChildren(ITestObject childObject, params ITestObject[] childObjects)
        {
            this.AddChild(childObject);
            foreach (ITestObject testObject in childObjects)
            {
                this.AddChild(testObject);
            }
        }

        //remove self from the hierarchy
        public bool Remove()
        {
            if (this.ParentNurse == null)
            {
                return false; //cannot remove since this is the root
            }
            this.ParentNurse.RemoveChild(this);
            return true;
        }

        public TestObjectNurse this[int index]
        {
            get
            {
                return (TestObjectNurse)Children[index];
            }
        }

        public bool IsRoot
        {
            get
            {
                return _treeView != null;
            }
        }

        public TestObjectNurse ParentNurse
        {
            get
            {
                return (TestObjectNurse)Parent;
            }
        }

        public override string ControlTypeString
        {
            get { return _testObject.ControlTypeString; }
        }

        /// <summary>
        /// return the root nurse object
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="rootTestObject"></param>
        /// <returns>return root nurse, which does not contain test object</returns>
        internal static TestObjectNurse AddTree(TreeView treeView, ITestObject testObject)
        {
            TestObjectNurse rootNurse = TestObjectNurse.FromTree(treeView);

            TestObjectNurse nurse = rootNurse.AddDecendants(testObject);

            return rootNurse;
        }

        public static TestObjectNurse FromTree(TreeView treeView)
        {
            TestObjectNurse rootNurse = treeView.Tag as TestObjectNurse;

            if (rootNurse == null)
            {
                rootNurse = new TestObjectNurse(treeView);
                treeView.Tag = rootNurse; //store root nurse to 
            }

            return rootNurse;
        }

        public static TestObjectNurse FromTreeNode(TreeNode treeNode)
        {
            TestObjectNurse nurse = treeNode.Tag as TestObjectNurse;
            return nurse;
        }

        public ITestObject TestObject
        {
            get
            {
                return _testObject;
            }
        }


        public override string NodeName
        {
            get
            {
                return _testObject.NodeName;
            }
            set
            {
                _testObject.NodeName = value;
                RefreshName();
            }
        }

        public string ImageFile
        {
            get
            {
                if (_cachedProperties == null) return null;

                string imageFile;
                _cachedProperties.Properties.TryGetValue(UIAControlKeys.ImagePath, out imageFile);
                return imageFile;
            }
            set
            {
                CachedProperties[UIAControlKeys.ImagePath] = value;
            }
        }

        /// <summary>
        /// Add testObjects subtree to the current nurse node.
        /// </summary>
        /// <param name="testObject"></param>
        /// <returns></returns>
        internal TestObjectNurse AddDecendants(ITestObject testObject)
        {
            TestObjectNurse nurse = this.AddChild(testObject) as TestObjectNurse;

            foreach (ITestObject childTestObject in testObject.Children)
            {
                nurse.AddDecendants(childTestObject);
            }
            return nurse;
        }

        public TreeNode TreeNode
        {
            get
            {
                return _treeNode;
            }
        }

        CachedPropertyGroup _cachedProperties;

        public Dictionary<string, string> CachedProperties
        {
            get
            {
                if (_cachedProperties == null)
                {
                    _cachedProperties = new CachedPropertyGroup();
                    TestObject.SetContext<CachedPropertyGroup>(_cachedProperties);
                }
                return _cachedProperties.Properties;
            }
            set
            {
                _cachedProperties = new CachedPropertyGroup();
                TestObject.SetContext<CachedPropertyGroup>(_cachedProperties);
                _cachedProperties.Properties = value;
            }
        }

        public TreeView TreeView
        {
            get
            {
                return _treeView;
            }
        }

        public TreeNodeCollection Nodes
        {
            get
            {
                if (_treeNode != null) return _treeNode.Nodes;

                return _treeView.Nodes;
            }
        }

        public static TestObjectNurse ConvertSubtree(UIATestObject topTestObject)
        {
            TestObjectNurse nurse = new TestObjectNurse(topTestObject);

            foreach (ITestObject childTestObject in topTestObject.Children)
            {
                nurse.AddDecendants(childTestObject);
            }
            return nurse;
        }

        List<ITestObject> _recycleBin;

        public List<ITestObject> RecycleBin
        {
            get
            {
                return (_recycleBin ?? (_recycleBin = new List<ITestObject>()));
            }
        }


        /// <summary>
        /// should be called with parameter inRecursion = false;
        /// </summary>
        /// <param name="nurse"></param>
        /// <param name="deleteFile"></param>
        /// <param name="inRecursion"></param>
        public static void CleanupDeletedItems(TestObjectNurse nurse, Action<string> deleteFile, bool inRecursion = false)
        {
            if (nurse == null) return;

            if (inRecursion == false)
            {
                while (nurse.IsRoot == false && nurse.ParentNurse != null)
                {
                    nurse = nurse.ParentNurse;
                }


                List<ITestObject> recycleBin = nurse.RecycleBin;
                foreach (TestObjectNurse nurseObject in recycleBin)
                {
                    if (!string.IsNullOrEmpty(nurseObject.ImageFile))
                    {
                        string imageFile = nurseObject.ImageFile;
                        deleteFile(nurseObject.ImageFile);
                    }
                    CleanupDeletedItems(nurseObject, deleteFile, true);
                }

                recycleBin.Clear();
            }
            else
            {
                foreach (TestObjectNurse nurseObject in nurse.Children)
                {
                    if (!string.IsNullOrEmpty(nurseObject.ImageFile))
                    {
                        deleteFile(nurseObject.ImageFile);
                    }
                    CleanupDeletedItems(nurseObject, deleteFile, true);
                }
            }
        }

        public void RefreshName()
        {
            _treeNode.Text = TestObject.ControlTypeString + ": " + TestObject.NodeName;
        }

        public bool ContainsKeyword(string keyword)
        {
            if (_testObject == null)
                return false;

            CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;

            if (compareInfo.IndexOf(_testObject.NodeName, keyword, CompareOptions.IgnoreCase) >= 0 ||
                compareInfo.IndexOf(_testObject.ControlTypeString, keyword, CompareOptions.IgnoreCase) >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
