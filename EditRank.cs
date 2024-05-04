using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReportingSystem
{
    public partial class EditRank : Form
    {
        public string connectionString = ConnectData.connectionString;

        public EditRank()
        {
            InitializeComponent();
           
        }

        private void EditRank_Load(object sender, EventArgs e)
        {
            LoadRank();
        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtrank.Text = cmbRank.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbRank.Text == "")
            {
                ConnectData.message = "Please Select Rank to Edit";
                ConnectData.title = "Rank Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if (txtrank.Text == "")
            {
                ConnectData.message = "Please enter the new Rank name to update to";
                ConnectData.title = "Rank Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtrank.Focus();
            }
            else
            {
                int rankid = (int)cmbRank.SelectedValue;
                /*
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateRank", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@RankName", SqlDbType.VarChar).Value = txtrank.Text;
                        cmd.Parameters.Add("@RankId", SqlDbType.Int).Value = rankid;
                       
                        var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        int returnValue = (int)returnParameter.Value;
                        con.Close();
                        if (returnValue > 1)
                        {
                            ConnectData.message = "Record already exist!";
                            ConnectData.title = "Save Failed";
                            MessageBox.Show(ConnectData.message, ConnectData.title);

                        }

                        else
                        {
                            txtrank.Text = "";
                            ConnectData.message = "Record Successfully Updated";
                            ConnectData.title = "Record Updated";
                            MessageBox.Show(ConnectData.message, ConnectData.title);
                            LoadRank();
                        }
                    }
                }
                */
                        var dataset = ConnectData.insert_info.sp_UpdateRank(txtrank.Text, rankid);
                        if (dataset > 1)
                        {
                            ConnectData.message = "Record already exist!";
                            ConnectData.title = "Save Failed";
                            MessageBox.Show(ConnectData.message, ConnectData.title);

                        }

                        else
                        {
                            txtrank.Text = "";
                            ConnectData.message = "Record Successfully Updated";
                            ConnectData.title = "Record Updated";
                            MessageBox.Show(ConnectData.message, ConnectData.title);
                            LoadRank();
                        }

            }
        }

        public void LoadRank()
        {
            
            cmbRank.ValueMember = "ID";
            cmbRank.DisplayMember = "RankName";

            var dataset = ConnectData.insert_info.sp_selectRank();
            cmbRank.DataSource = dataset;

           // cmbRank.DataSource = ConnectData.LoadRankClass();

        }
    }
}
