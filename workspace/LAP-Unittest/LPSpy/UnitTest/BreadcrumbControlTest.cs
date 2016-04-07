using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Windows.Automation;
using System.Collections.Generic;
using System.Windows.Forms;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class BreadcrumbControlTest
    {
        [TestMethod]
        public void Breadcrumb_AddItem()
        {
            BreadcrumbControl control = new BreadcrumbControl();
            control.AddItem("link1");
            control.AddItem("link2");
            Assert.AreEqual(2, control.Count);
        }

        [TestMethod]
        public void Breadcrumb_AddItem2()
        {
            BreadcrumbControl control = new BreadcrumbControl();
            string somethingToPutInTag = "Something";
            string anotherthingToPutInTag = "Another";
            control.AddItem("link1", false, somethingToPutInTag);
            control.AddItem("link2", true, anotherthingToPutInTag);
            Assert.AreEqual(2, control.Count);


            Breadcrumb[] breadcrumbs = control.GetItems();
            Assert.AreEqual(2, breadcrumbs.Length);

            Assert.AreEqual(false, breadcrumbs[0].Checked);
            Assert.AreEqual("Something", (string)breadcrumbs[0].Tag);
            Assert.AreEqual("link1", (string)breadcrumbs[0].Text);

            Assert.AreEqual(true, breadcrumbs[1].Checked);
            Assert.AreEqual("Another", (string)breadcrumbs[1].Tag);
            Assert.AreEqual("link2", (string)breadcrumbs[1].Text);
        }


        [TestMethod]
        public void Breadcrumb_Clear()
        {
            BreadcrumbControl control = new BreadcrumbControl();

            string somethingToPutInTag = "Something";
            string anotherthingToPutInTag = "Another";

            control.AddItem("link1", false, somethingToPutInTag);
            control.AddItem("link2", true, anotherthingToPutInTag);

            control.Clear();

            Assert.AreEqual(0, control.Count);

            Assert.AreEqual(0, control.GetItems().Length);
        }

        [TestMethod]
        public void Breadcrumb_SeparatorCheck()
        {
            BreadcrumbControl control = new BreadcrumbControl();

            control.AddItem("link1");

            bool hasSeparator = control.ChildControls.ContainsKey(BreadcrumbControl.PrefixArrowSeparator + "0");
            Assert.IsFalse(hasSeparator);

            control.AddItem("link2");
            Label separator1 = (Label)control.ChildControls[BreadcrumbControl.PrefixArrowSeparator + "1"];
            Assert.IsNotNull(separator1);

        }

        [TestMethod]
        public void Breadcrumb_EnableLast()
        {
            BreadcrumbControl control = new BreadcrumbControl();

            control.AddItem("link1");

            LinkLabel linkLabel = (LinkLabel)control.ChildControls[BreadcrumbControl.PrefixLinkLabel + "0"];
            Assert.AreEqual(false, linkLabel.Enabled);

            control.AddItem("link2");
            Assert.AreEqual(true, linkLabel.Enabled);

            LinkLabel linkLabel2 = (LinkLabel)control.ChildControls[BreadcrumbControl.PrefixLinkLabel + "1"];
            Assert.AreEqual(false, linkLabel2.Enabled);
            
        }

        /*
        public class BreadcrumbCollection : ICollection
        {
            private List<Breadcrumb> _obj;

            internal BreadcrumbCollection(List<Breadcrumb> obj)
            {
                _obj = obj;
            }

            public int Count
            {
                get
                {
                    return _obj.Count;
                }
            }
            public virtual bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            public virtual object SyncRoot
            {
                get
                {
                    return this;
                }
            }

            public AutomationElement this[int index] { get; }

            public virtual void CopyTo(Array array, int index);
            public void CopyTo(AutomationElement[] array, int index);
            public IEnumerator GetEnumerator();
        }*/
    }
}

#endif