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
    public partial class WallCreationWindow : System.Windows.Forms.Form
    {
        public WallCreationWindow(List<Level> allLevels, List<WallType> allWallTypes)
        {
            InitializeComponent();

            foreach (var level in allLevels)
            {
                cb_BaseLevel.Items.Add(level);
                cb_TopLevel.Items.Add(level);
            }
            cb_BaseLevel.DisplayMember = "Name";
            cb_TopLevel.DisplayMember = "Name";


            foreach (var wallType in allWallTypes)
            {
                cb_WallTypes.Items.Add(wallType);
            }
            cb_WallTypes.DisplayMember = "Name";
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            WallCreationModel.BaseLevelValue = cb_BaseLevel.SelectedItem as Level;
            WallCreationModel.TopLevelValue = cb_TopLevel.SelectedItem as Level;
            WallCreationModel.WallTypeValue = cb_WallTypes.SelectedItem as WallType;
            WallCreationModel.StructureValue = cb_Structural.Checked;
            WallCreationModel.BaseOffsetValue = double.Parse(tb_BaseOffset.Text);

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
