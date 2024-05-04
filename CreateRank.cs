using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingSystem
{
    public partial class CreateRank : Form
    {
        public CreateRank()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (txtRank.Text == "")
            {
                ConnectData.message = "Please enter Rank";
                ConnectData.title = "Rank is Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtRank.Focus();

            }
            else
            {
                ConnectData.message = "Record Saved Successfully";
                ConnectData.title = "Save";

                var dataset = ConnectData.insert_info.sp_InsertRank(txtRank.Text);
                if (dataset > 0)
                {
                    ConnectData.message = "Record already exist!";
                    ConnectData.title = "Save Failed";
                    MessageBox.Show(ConnectData.message, ConnectData.title);

                }

                else
                {
                    MessageBox.Show(ConnectData.message, ConnectData.title);
                    txtRank.Text = "";
                }

            } // end of else
        }// end of Search_Click
    }
}
