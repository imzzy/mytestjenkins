using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LPReplayCore.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using LPReplayCore.Common;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;

#if TEST

namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class TempUnitTests
    {

        [TestMethod]
        public void FileChangeNotifier()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(System.Environment.CurrentDirectory);
            watcher.Changed += watcher_Changed;
            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;  //启动监控
            
            //watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
            Thread.Sleep(10000);
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("file changed");
        }

        [TestMethod]
        public void ReadOnlyCollectionTest()
        {
            List<string> listString = new List<string>()
            {
                "list1", "list2"
            };

            ReadOnlyCollection<string> readonlyList = listString.AsReadOnly();

            listString.Add("list3");

            Assert.AreEqual(3, readonlyList.Count);
        }

        [TestMethod]
        public void ReadOnlyCollectionTest2()
        {
            List<string> listString = new List<string>()
            {
                "list1", "list2"
            };

            ReadOnlyCollection<string> readonlyList = listString.AsReadOnly();
            //listString.Add("list3");
            ReadOnlyCollection<string> readonlyList2 = listString.AsReadOnly();
            

            Assert.AreNotEqual(readonlyList, readonlyList2);
        }


        [TestMethod]
        public void PropertyItemTest()
        {
            
            ObjectDescriptor descriptor = new ObjectDescriptor();

            descriptor.Name = "Button";

            VisualRelationPropertyItem item = descriptor.GetItem<VisualRelationPropertyItem>();
            Assert.AreEqual(null, item);

            item = new VisualRelationPropertyItem() { Left = "aaa", Right = "bbb" };
            descriptor.SetItem(item);

            string result = JsonUtil.SerializeObject(descriptor);

            Debug.WriteLine(result);
        }


        [TestMethod]
        public void ArrayHandlerTest()
        {
            string jsonSample = @"{
                    nname:""button1"",
                    type:""button"",
                    relation:{left:""button0"", right:""button1""},
                    properties: {
                        other_property1:""other_value1"",
                        other_property2:""other_value2""
                    }
                ";
        }

        //[TestMethod]
        public void launchFileWithNotepad()
        {
            TestUtility.LaunchNotepad("abc.xml");
        }

        //[TestMethod]
        public void SortedListTest()
        {
            SortedList<string, string> list = new SortedList<string, string>(new DuplicateComparer());
            list.Add("key1", "value1");
            list.Add("key1", "value2");
            list.Add("key2", "value3");
            list.Add("key3", "");

//            Assert.AreEqual(4, list.Count);

            
            foreach (string key in list.Keys)
            {
                string value;
                list.TryGetValue(key, out value);
                Debug.WriteLine(string.Format("key: {0}, value: {1}", key, value));
            }

            Debug.WriteLine(list["key2"]);
            Debug.WriteLine(list["key3"]);
            Debug.WriteLine(list["key1"]);

            /*
            foreach (string key in list.Keys)
            {
                Debug.WriteLine(list["key1"]);
                Debug.WriteLine(list["key2"]);
                Debug.WriteLine(list["key3"]);
            }*/

            foreach (string value in list.Values)
            {
                Debug.WriteLine(list.Values);
            }

        }


        public class Descriptor
        {
            public string NodeName;
            public string Type;
            Dictionary<string, Action> JsonHandler;

            public void ParseJson(string json)
            {
                string value = null;
                JsonHandler = new Dictionary<string, Action>()
                {
                    {"nname", new Action(()=> NodeName = value)},
                    {"relation", new Action(()=> NodeName = value)}
                };
            }

           
        }

        public class Relation
        {
            public string left;
            public string right;
        }

        
        
    }
}

#endif