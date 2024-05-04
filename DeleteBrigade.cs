using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingSystem
{
    public partial class DeleteBrigade : Form
    {
      
        public DeleteBrigade()
        {
            InitializeComponent();
        }

        private void DeleteBrigade_Load(object sender, EventArgs e)
        {
            // LoadBrigade();
            callLoadBrigade();
        }

        private void callLoadBrigade()
        {
           
            // cmbBrigade1.DataSource = ConnectData.LoadBrigade(this);
           //   cmbBrigade1.DataSource = dataset;
            if (ConnectData.createRights == "Administrator")
            {

                var dataset = ConnectData.insert_info.sp_selectBrigade();
                cmbBrigade1.ValueMember = "ID";
                cmbBrigade1.DisplayMember = "Brigade";
                cmbBrigade1.DataSource = dataset;
            }
            else
            {
                var dataset = ConnectData.insert_info.sp_selectBrigadebyBde(ConnectData.bdeLevelAccess);
                cmbBrigade1.ValueMember = "ID";
                cmbBrigade1.DisplayMember = "Brigade";
                cmbBrigade1.DataSource = dataset;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteBrigades();
        }

        
        public void DeleteBrigades()
        {
            if (cmbBrigade1.Text == "")
            {
                ConnectData.message = "Please Select a Brigade to Delete";
                ConnectData.title = "Brigade Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }

            else
            {
                int BrigadeId = (int)cmbBrigade1.SelectedValue;
                var ans = MessageBox.Show("Are you sure you want to delete this record", "Delete Record", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                   try
                    {
                        /*
                       using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_DeleteBrigade", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@bdeId", SqlDbType.Int).Value = BrigadeId;

                                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                                returnParameter.Direction = ParameterDirection.ReturnValue;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                int returnValue = (int)returnParameter.Value;
                                con.Close();
                                if (returnValue > 0)
                                {
                                    ConnectData.message = "Record successfully deleted!";
                                    ConnectData.title = "Record Deleted";
                                    MessageBox.Show(ConnectData.message, ConnectData.title);
                                    callLoadBrigade();

                                }// end of if()

                            }// end of  using (SqlCommand cmd = new SqlCommand("sp_DeleteBrigade", con))
                             
                        }// end of  using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                        */

                      //  var insert_info = new WinformReportingSystemEntities();
                        var returnValue = ConnectData.insert_info.sp_DeleteBrigade(BrigadeId);
                        ConnectData.message = "Record successfully deleted!";
                        ConnectData.title = "Record Deleted";
                        MessageBox.Show(ConnectData.message, ConnectData.title);
                        callLoadBrigade();

                       

                    }// end of try
                    catch (Exception ex)
                   {
                        MessageBox.Show(ex.Message, "Error as Occurred");


                   }
                }
            }//end of else condition
        } //end of Delete Brigade

        private void cmbBrigade1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
