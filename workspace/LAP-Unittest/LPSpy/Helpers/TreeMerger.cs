using LPUIAObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using LPReplayCore.Common;
using LPCommon;
using LPReplayCore.UIA;
using LPReplayCore;
using LPReplayCore.Interfaces;
using System.Collections.ObjectModel;
using LPReplayCore.Web;

namespace LPSpy
{
    public enum ResultType
    {
        OK = 0,
        NotSameControlType,
        NoSelectedNode,
    }

    public delegate void MergeCompleteDelegate(bool changed);

    public delegate void UpdateNodePropertyCompleteDelegate(ResultType result);

    public class TreeMerger
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//"LPReplayCore.UIA.UIAFinder");

        private TreeView _treeObjects;

        public event MergeCompleteDelegate MergeComplete;

        public event UpdateNodePropertyCompleteDelegate UpdateNodePropertyComplete;

        public TestObjectNurse LeftCondition, RightCondition, SelfCondition;

        public TreeMerger(TreeView treeObjects, MergeCompleteDelegate mergeCompleteCallback, UpdateNodePropertyCompleteDelegate updateNodePropertyCompleteCallBack)
        {
            _treeObjects = treeObjects;
            MergeComplete = mergeCompleteCallback;
            UpdateNodePropertyComplete = updateNodePropertyCompleteCallBack;
        }

        private void RaiseUpdateNodePropertyCompleteEvent(ResultType result)
        {
            if (UpdateNodePropertyComplete != null)
            {
                UpdateNodePropertyComplete(result);
            }

        }
        private void RaiseMergeCompleteEvent(bool changed)
        {
            if (MergeComplete != null)
            {
                MergeComplete(changed);
            }
        }

        public void UpdateSelNode(ElementProperties elementProperties, string imagePath)
        {
            TreeNode selectNode = _treeObjects.SelectedNode;
            TestObjectNurse TONurse = null;
            if (selectNode == null)
            {
                RaiseUpdateNodePropertyCompleteEvent(ResultType.NoSelectedNode);
                return;
            }
            if (null == (TONurse = selectNode.Tag as TestObjectNurse))
            {
                RaiseUpdateNodePropertyCompleteEvent(ResultType.NoSelectedNode);
                return;
            }

            if (!TONurse.ControlTypeString.Equals(elementProperties.ControlTypeString))
            {
                RaiseUpdateNodePropertyCompleteEvent(ResultType.NotSameControlType);
                return;
            }

            ITestObject TO = TONurse.TestObject;
            TONurse.CachedProperties.Clear();
            TONurse.ImageFile = imagePath;
            foreach (KeyValuePair<string, string> pair in elementProperties.NoneEmptyProperties)
            {
                TONurse.CachedProperties.Add(pair.Key, pair.Value);
                if (TO.Properties.ContainsKey(pair.Key))
                {
                    TO.Properties[pair.Key] = pair.Value;
                }
            }

            //foreach (KeyValuePair<string, string> pair in elementProperties.SelectedProperties)
            //{
            //    if (TO.Properties.ContainsKey(pair.Key))
            //    {
            //        TO.Properties[pair.Key] = pair.Value;
            //    }
            //}

            //TODO : temporarily convert to UIATestObject. Should use TestObjectBase or ITestObject directly
            (TO as UIATestObject).AutomationElement = elementProperties.AutomationElement;
            (TO as UIATestObject).ControlType = elementProperties.ControlType;
            (TO as UIATestObject).NodeName = elementProperties.DerivedName;
            TONurse.RefreshName();
            RaiseUpdateNodePropertyCompleteEvent(ResultType.OK);
        }

        public void StartToUpdate(ITestObject topNurse, ITestObject selfNurse,
            ITestObject leftNurse, ITestObject rightNurse)
        {
            LeftCondition = (TestObjectNurse)leftNurse;
            RightCondition = (TestObjectNurse)rightNurse;
            SelfCondition = (TestObjectNurse)selfNurse;

            TestObjectNurse rootNurse = TestObjectNurse.FromTree(_treeObjects);

            bool changed = MergeObjectsToMainTree(rootNurse, (new List<TestObjectNurse>() { (TestObjectNurse)topNurse }).AsReadOnly());

            if (changed)
            {
                RaiseMergeCompleteEvent(true);
            }


            /*
            if (_selfCondition != null)
            {
                if (_leftCondition != null)
                {
                    _selfCondition.UpdateCondition(UIAPropertyKey.LeftCondition, _leftCondition);
                    _selfCondition.UpdateCondition(UIAPropertyKey.Left, _leftCondition.NodeName);
                }
                if (_rightCondition != null)
                {
                    _selfCondition.UpdateCondition(UIAPropertyKey.RightCondition, _rightCondition);
                    _selfCondition.UpdateCondition(UIAPropertyKey.Right, _rightCondition.NodeName);
                }
            }*/
        }


        private TestObjectNurse FindMatchingNode(TestObjectNurse nodes, TestObjectNurse fromObjectNurse)
        {
            //_Logger.WriteLog(LogTypeEnum.Debug, () => UIAUtility.DumpAutomationElement(fromObjectNurse.AutomationElement));

            bool startswithWebfrom = false;
            bool startswithWeb = false;
            foreach (TestObjectNurse repoChildNode in nodes.Children)
            {
                startswithWebfrom = fromObjectNurse.TestObject.ControlTypeString.StartsWith("Web");
                startswithWeb = repoChildNode.TestObject.ControlTypeString.StartsWith("Web");

                if (startswithWebfrom != startswithWeb)
                    continue;

                if (startswithWebfrom)
                {
                    if (WebUtility.AreEqual(repoChildNode.TestObject, fromObjectNurse.TestObject))
                    {
                        return repoChildNode;
                    }
                    continue;
                }

                if (UIAUtility.AreEqual(repoChildNode.TestObject, fromObjectNurse.TestObject))
                //if (condition.Match(fromCondition.AutomationElement))
                {
                    return repoChildNode;
                }
            }



            return null;
        }



        private bool MergeObjectsToMainTree(TestObjectNurse repoNurseNode, IEnumerable<ITestObject> testObjectNodes) //addCollection
        {
            bool found;
            bool changed = false;
            bool web = false;
            foreach (TestObjectNurse testObjectNurse in testObjectNodes)
            {
               
                found = false;
                ITestObject testobject = testObjectNurse.TestObject;
                web = testobject.ControlTypeString.StartsWith("Web");

                //if ( null == (repoNurseNode.TestObject as UIATestObject ))
                //{

                //    TestObjectNurse newTestNurse = new TestObjectNurse(testObjectNurse.TestObject);

                //    newTestNurse.NodeName = testObjectNurse.TestObject.NodeName;

                //    repoNurseNode.AddChild(newTestNurse);

                //    TreeNode node = newTestNurse.TreeNode;

                //    changed = true;

                //    TreeNodeHelper.FixTreeNodeImage(node, "Button");

                //    MergeObjectsToMainTree(newTestNurse, testObjectNurse.Children);
                //   // NeighbourChecker(newTestNurse, testObjectNurse);

                //    RaiseMergeCompleteEvent(true);
                //    continue;
                //}
                ////UIACondition fromNodeCondition = (UIACondition)fromNode.Tag;
                TestObjectNurse repoNode = FindMatchingNode(repoNurseNode, testObjectNurse);

                if (repoNode != null)
                {
                    changed |= MergeObjectsToMainTree(repoNode, testObjectNurse.Children);
                    changed |= NeighbourChecker(repoNode, testObjectNurse);
                    repoNode.TreeNode.Expand();
                    found = true;
                }

                
                

                if (!found)
                {
                    TestObjectNurse newTestNurse = new TestObjectNurse(testObjectNurse.TestObject);
                    TreeNode node = newTestNurse.TreeNode;
                    if (web)
                    {
                        newTestNurse.NodeName = testObjectNurse.TestObject.NodeName;

                        repoNurseNode.AddChild(newTestNurse);

                        changed = true;

                        TreeNodeHelper.FixTreeNodeImage(node, testObjectNurse.TestObject.ControlTypeString);

                        MergeObjectsToMainTree(newTestNurse, testObjectNurse.Children);
                        // NeighbourChecker(newTestNurse, testObjectNurse);

                        RaiseMergeCompleteEvent(true);
                        continue;
                    }
                    UIATestObject uiaTestObject = (UIATestObject)testObjectNurse.TestObject;
                    AutomationElement addedElement = uiaTestObject.AutomationElement;

                    string nodeName;

                    // if Element not exist, use the default condition, if exist, create new condition, because this can create index for object.
                    bool elementExist = (!addedElement.Current.BoundingRectangle.IsEmpty);
                    if (!elementExist)
                    {
                        string tempNewName;

                        if (!string.IsNullOrEmpty(uiaTestObject.ControlName))
                            tempNewName = uiaTestObject.ControlName;
                        else
                            tempNewName = uiaTestObject.ControlTypeString;

                        nodeName = SpyWindowHelper.DeriveControlName(repoNurseNode, tempNewName);
                    }
                    else
                    {
                        nodeName = SpyWindowHelper.DeriveControlName(repoNurseNode, addedElement);
                        //TODO should use the following logic
                        //newCondition = new UIACondition(fromNode, nodeName);
                    }

                    string nodeText = testObjectNurse.NodeName = nodeName;
                    
                    //TestObjectNurse newTestNurse = new TestObjectNurse(uiaTestObject);

                    newTestNurse.NodeName = nodeText;

                    repoNurseNode.AddChild(newTestNurse);

                   // TreeNode node = newTestNurse.TreeNode;

                    changed = true;
                    
                    TreeNodeHelper.FixTreeNodeImage(node, uiaTestObject.ControlTypeString);

                    MergeObjectsToMainTree(newTestNurse, testObjectNurse.Children);
                    NeighbourChecker(newTestNurse, testObjectNurse);

                    node.Expand();
                    RaiseMergeCompleteEvent(true);
                }
            }

            return changed;
        }

        /// <summary>
        /// return value: indicate whether the tree node is changed
        /// </summary>
        /// <param name="fromNode"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        private bool NeighbourChecker(TestObjectNurse fromNode, TestObjectNurse condition)
        {
            if (SelfCondition != condition) return false;

            bool changed = false;
            
            TestObjectNurse parentNurse = fromNode.ParentNurse;

            if (LeftCondition != null)
            {
                TestObjectNurse repoNode = FindMatchingNode(parentNurse, LeftCondition);
                if (repoNode == null)
                {
                    if (parentNurse != null)
                    {
                        parentNurse.AddChild(LeftCondition);
                    }
                    TreeNode tempNode = parentNurse.Nodes.Insert(parentNurse.Children.Count - 1, "left", LeftCondition.NodeName);
                    tempNode.Tag = LeftCondition;
                    changed = true;
                }
            }

            if (RightCondition != null)
            {
                TestObjectNurse repoNode = FindMatchingNode(parentNurse, RightCondition);
                if (repoNode == null)
                {
                    if (parentNurse != null)
                    {
                        parentNurse.AddChild(RightCondition);
                    }
                    TreeNode tempNode = parentNurse.Nodes.Add("right", RightCondition.ControlTypeString + ": " + RightCondition.ControlName);
                    tempNode.Tag = RightCondition;
                    changed = true;
                }
            }
            return changed;
        }
    }
}
