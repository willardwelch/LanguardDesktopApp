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
    public partial class DeleteRank : Form
    {
        public DeleteRank()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmdRank.Text != "")
            {
                   var dataset = ConnectData.insert_info.sp_DeleteRank((int)cmdRank.SelectedValue);
              
                    ConnectData.message = "Record Successfully Deleted!";
                    ConnectData.title = "Record Deleted";
                    LoadRanks();
                    MessageBox.Show(ConnectData.message, ConnectData.title);

            }
        }

        private void LoadRanks()
        {
            var dataset = ConnectData.insert_info.sp_selectRank();
            cmdRank.ValueMember = "ID";
            cmdRank.DisplayMember = "RankName";
            cmdRank.DataSource = dataset;

        }
        private void DeleteRank_Load(object sender, EventArgs e)
        {

            LoadRanks();
        }
    }
}
