using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using LPReplayCore.Interfaces;
using LPUIAObjects;
using LPReplayCore;
using LPReplayCore.UIA;
using LPReplayCore.Model;
using System.Text;
using System.Diagnostics;

namespace LPSpy.UnitTest
{
    
#if TEST
    [TestClass]
    public class SpyHelperTest
    {

        [TestMethod]
        public void SpyHelper_FillPropertyGrid()
        {

            UIATestObject testObject = new UIATestObject(
            ObjectDescriptor.FromJson(@"{
              ""identifyProperties"": {
                ""title"": ""LAP (Running) - Microsoft Visual Studio"",
                ""type"": ""Window""}
              }"));

            DataGridView propertyGrid = GetAnEmptyPropertyGrid();

            int count = SpyWindowHelper.FillPropertyGrid(propertyGrid, testObject);

            Assert.AreEqual(2, count);

            testObject.AddProperty("property3", "value3");

            count = SpyWindowHelper.FillPropertyGrid(propertyGrid, testObject);

            Assert.AreEqual(3, count);

        }

        private static DataGridView GetAnEmptyPropertyGrid()
        {
            DataGridView propertyGrid = new DataGridView();

            propertyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            propertyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() {
                        HeaderText = "Property",
                        Name = "Property",
                        ReadOnly = true
                },
                        new DataGridViewTextBoxColumn() 
                        {HeaderText = "Value",
                        Name = "Value",
                        ReadOnly = true
                        }
            });
            return propertyGrid;
        }

        [TestMethod]
        public void SpyHelper_DeleteSelectedProperties()
        {
            //TODO: need to update the unit test

            UIATestObject testObject = new UIATestObject(
            ObjectDescriptor.FromJson(@"{
              ""identifyProperties"": {
                ""title"": ""LAP (Running) - Microsoft Visual Studio"",
                ""helptext"": ""this is help text"",
                ""url"": ""this is url"",
                ""type"": ""Window""}
              }"));

            Assert.AreEqual(4, testObject.Properties.Count);

            DataGridView propertyGrid = GetAnEmptyPropertyGrid();
            SpyWindowHelper.FillPropertyGrid(propertyGrid, testObject);

            Assert.AreEqual(5, propertyGrid.Rows.Count, "Should have 5 properties before deletion");

            SpyWindowHelper.DeleteSelectedProperties(ControlKeys.Title, testObject);

            SpyWindowHelper.FillPropertyGrid(propertyGrid, testObject);

            string data = DumpPropertyGridRows(propertyGrid);
            Debug.Write(data);
            Assert.AreEqual(4, propertyGrid.Rows.Count, data);

        }

        private string DumpPropertyGridRows(DataGridView propertyGrid)
        {
            StringBuilder builder = new StringBuilder();

            foreach (DataGridViewRow row in propertyGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    builder.Append(cell.Value);
                    builder.Append(", ");
                }
                builder.AppendLine("");
            }
            return builder.ToString();
        }

        [TestMethod]
        public void SpyHelper_AddSelectedProperty()
        {
            UIATestObject testObject = new UIATestObject(
            ObjectDescriptor.FromJson(@"{
              ""identifyProperties"": {
                ""title"": ""LAP (Running) - Microsoft Visual Studio"",
                ""helptext"": ""this is help text"",
                ""url"": ""this is url"",
                ""type"": ""Window""}
              }"));

            Assert.AreEqual(4, testObject.Properties.Count);

            DataGridView propertyGrid = GetAnEmptyPropertyGrid();
            SpyWindowHelper.FillPropertyGrid(propertyGrid, testObject);

            Assert.AreEqual(5, propertyGrid.Rows.Count, "Should have 4 properties before selection");

            propertyGrid.Rows[1].Selected = true;
            propertyGrid.Rows[2].Selected = true;

            UIATestObject newTestObject = new UIATestObject();

            Assert.AreEqual(0, newTestObject.Properties.Count);

            SpyWindowHelper.AddSelectedProperty(propertyGrid, newTestObject);

            Assert.AreEqual(2, newTestObject.Properties.Count);

        }
    }

#endif
}
