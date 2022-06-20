using Autodesk.Revit.DB;
using AwesomeAddin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeAddin.Views
{
    public partial class RevitLinkSelectorWindow : System.Windows.Forms.Form
    {
        public RevitLinkSelectorWindow(List<string> rvtLinkNames)
        {
            InitializeComponent();

            foreach (var link in rvtLinkNames)
            {
                lstView_Links.Items.Add(link);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RevitLinkSelectorModel.selectedRevitLinks.Clear();
            foreach (var item in lstView_Links.CheckedItems)
            {
                RevitLinkSelectorModel.selectedRevitLinks.Add(item.ToString());
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
