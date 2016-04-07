using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using LPUIAObjects;
using LPReplayCore.UIA;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class ConditionSelectorWindowTest
    {
        [TestMethod]
        public void ConditionSelector_Test()
        {
            ConditionSelectorWindow window = new ConditionSelectorWindow();
            UIACondition uiaCondition = new UIACondition(new UIATestObject());
            TreeNode treeNode = new TreeNode();
            treeNode.Tag = uiaCondition;

            window.Tag = treeNode;
            window.ShowDialog();
        }
    }
}
#endif
