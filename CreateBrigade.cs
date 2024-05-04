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
    public partial class CreateBrigade : Form
    {
      
        public CreateBrigade()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ConnectData.message = "Please enter Brigade Name";
            ConnectData.title = "Brigade Missing";
            if (txtBrigade.Text == "")
            {
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtBrigade.Focus();

            }
            else
            {
                /*
                  ConnectData.message = "Record Saved Successfully";
                  ConnectData.title = "Save";
                  using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                      {
                          using (SqlCommand cmd = new SqlCommand("sp_insertBrigade", con))
                          {
                              cmd.CommandType = CommandType.StoredProcedure;

                              cmd.Parameters.Add("@brigadeName", SqlDbType.VarChar).Value = txtBrigade.Text;

                              var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                              returnParameter.Direction = ParameterDirection.ReturnValue;


                              con.Open();
                              cmd.ExecuteNonQuery();
                              int returnValue = (int)returnParameter.Value;
                                  con.Close();
                              if (returnValue > 0)
                              {
                                  ConnectData.message = "Record already exist!";
                                  ConnectData.title = "Save Failed";
                                  MessageBox.Show(ConnectData.message, ConnectData.title);

                              }

                              else
                              {
                                  MessageBox.Show(ConnectData.message, ConnectData.title);
                                  txtBrigade.Text = "";
                              }
                          }
                  }

              }*/
               
                var returnValue = ConnectData.insert_info.sp_InsertBrigade(txtBrigade.Text);
                if (returnValue > 0)
                {
                    ConnectData.message = "Record already exist!";
                    ConnectData.title = "Save Failed";
                    MessageBox.Show(ConnectData.message, ConnectData.title);

                }

                else
                {
                    ConnectData.message = "Record saved successfully";
                    ConnectData.title = "Save";
                    MessageBox.Show(ConnectData.message, ConnectData.title);
                    txtBrigade.Text = "";
                }
            }
        }
         
       

        private void CreateBrigade_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
