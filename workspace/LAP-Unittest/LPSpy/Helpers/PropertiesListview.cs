using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using LPReplayCore.UnitTest;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using LPReplayCore.Model;
using LPUIAObjects;
using LPReplayCore;
using LPReplayCore.Interfaces;

namespace LPSpy
{
    public class PropertiesListview
    {
        ListView listView;

        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnValue;
        private ListViewGroup listViewGroupRecommended;
        private ListViewGroup listViewGroupOthers;

        public PropertiesListview(ListView listView)
        {
            this.listView = listView;
        }

        public void Init()
        {
            
            this.listView.CheckBoxes = true;

            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName.Width = listView.Width / 2;
            this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValue.Width = listView.Width / 2;

            columnName.Text = "Name";
            columnValue.Text = "Value";
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnValue});

            this.listViewGroupRecommended = new ListViewGroup("Recommended");
            this.listViewGroupOthers = new ListViewGroup("Others");

            this.listView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
                this.listViewGroupRecommended,
                this.listViewGroupOthers
                });
            
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
        }
        
        /*
        private void ShowListedItems()
        {
            ListView.CheckedListViewItemCollection collection = this.listView.CheckedItems;

            StringWriter writer = new StringWriter();

            foreach (ListViewItem item in collection)
            {
                writer.WriteLine(string.Format("{0},{1}", item.Text, item.SubItems[0].Text));
            }
            writer.Flush();

            MessageBox.Show(writer.ToString());
        }*/

        private Dictionary<string, string> GetSelectedProperties()
        {
            Dictionary<string, string> selectedProperties = new Dictionary<string, string>();

            ListView.CheckedListViewItemCollection collection = this.listView.CheckedItems;

            foreach (ListViewItem item in collection)
            {
                KeyValuePair<string, string> pair = (KeyValuePair<string, string>)item.Tag;
                selectedProperties[pair.Key] = pair.Value;
            }
            return selectedProperties;
        }

        public void FillListviewWithProperties(IElementProperties elementProperties)
        {
            this.listView.BeginUpdate();
            this.listView.Items.Clear();

            this.listView.Tag = elementProperties;

            ////Utility.AsyncCall(() => elementProperties = new ElementProperties(element));

            ListViewItem[] items = AddProperties(elementProperties.RecommendedProperties, listViewGroupRecommended);
            this.listView.Items.AddRange(items.ToArray());

            ListViewItem[] otherItems = AddProperties(elementProperties.OtherProperties, listViewGroupOthers);
            this.listView.Items.AddRange(otherItems);

            foreach (ListViewItem item in listView.Items)
            {
                if (elementProperties.SelectedProperties.ContainsKey(((KeyValuePair<string, string>)item.Tag).Key))
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
            this.listView.EndUpdate();
        }

        private ListViewItem[] AddProperties(Dictionary<string, string> properties, ListViewGroup listViewGroup)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            IElementProperties elementProperties = (IElementProperties)this.listView.Tag;
            foreach (KeyValuePair<string, string> pair in properties)
            {
                ListViewItem item = new ListViewItem(new string[] { ControlKeysManager.GetDisplayString(pair.Key, elementProperties.ControlTypeString), pair.Value }, listViewGroup);
                item.Tag = pair;
                items.Add(item);
            }

            return items.ToArray();
        }

        internal void UpdateSelection(ListViewItem listViewItem)
        {
            IElementProperties properties = (IElementProperties)this.listView.Tag;
            properties.SelectedProperties = GetSelectedProperties();
        }
    }

}

