using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeAddin
{
    public partial class HelloWorldWindow : Form
    {
        public HelloWorldWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Name.Text))
            {
                MessageBox.Show("Enter the data before click Ok");
            }
            else
            {
                HelloWorldModel.NameValue = tb_Name.Text;
                HelloWorldModel.AgeValue = int.Parse(tb_Age.Text);
                HelloWorldModel.WeightValue = double.Parse(tb_Weight.Text);
                DialogResult = DialogResult.OK;
                this.Close();
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
