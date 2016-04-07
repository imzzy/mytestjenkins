using LPReplayCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    public partial class OptionWindow : Form
    {
        public OptionWindow()
        {
            InitializeComponent();

            this.highlightColorSelector.Items.AddRange(new object[] {
            "Green",
            "Red",
            "Yellow"});
            LoadSettingsUI();
        }

        private void LoadSettingsUI()
        {
            chkCaptureScreenshots.Checked = SpySettings.CaptureSnapshots;

            highlightColorSelector.SelectColor(ReplayCoreSettings.HighlightColor);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SpySettings.SaveUserSettings();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkCaptureScreenshots_CheckedChanged(object sender, EventArgs e)
        {
            SpySettings.CaptureSnapshots = chkCaptureScreenshots.Checked;
        }

        private void highlightColorSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            ReplayCoreSettings.HighlightColor = Color.FromName(highlightColorSelector.SelectedText);
        }

        public void GetHighlightedColor()
        {

        }
    }
}
