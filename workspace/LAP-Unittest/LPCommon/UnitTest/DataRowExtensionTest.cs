using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace LPCommon
{
#if TEST
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string MobilePhone;
    }
    [TestClass]
    public class DataRowExtensionTest
    {
        [ClassInitialize]
        public static void Init(TestContext TestContext)
        {
            
        }

        [TestMethod]
        public void DataRowExtension_ToEntity()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("firstName", typeof(string));
            dt.Columns.Add("lastName", typeof(string));
            dt.Columns.Add("mobilePhone", typeof(string));
            DataRow row1 = dt.Rows.Add("Jason", "Jing", "11111111");
            DataRow row2 = dt.Rows.Add("John", "Smith", "22222222");

            Person person1 = row1.ToEntity<Person>();

            Assert.AreEqual("Jason", person1.FirstName);
            Assert.AreEqual("Jing", person1.LastName);
            Assert.AreEqual("11111111", person1.MobilePhone);

            Person person2 = row2.ToEntity<Person>();

            Assert.AreEqual("John", person2.FirstName);
            Assert.AreEqual("Smith", person2.LastName);
            Assert.AreEqual("22222222", person2.MobilePhone);
        }

    }

#endif
}
