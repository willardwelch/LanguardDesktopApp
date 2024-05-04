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
    public partial class Orders : Form
    {
         public Orders()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Orders_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                ConnectData.message = "Please enter name of order";
                ConnectData.title = "Order name Missing";
                if (txtOrder.Text == "")
                {
                    MessageBox.Show(ConnectData.message, ConnectData.title);
                    txtOrder.Focus();

                }
                else
                 {
                // Save Record
                ConnectData.message = "Record Saved Successfully";
                ConnectData.title = "Save";
                /*
                using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_InsertOrderType]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@orderName", SqlDbType.VarChar).Value = txtOrder.Text;
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
                            txtOrder.Text = "";
                        }
                    }
                }
                */
                    var dataset = ConnectData.insert_info.sp_InsertOrderType(txtOrder.Text);
                    if (dataset > 0)
                    {
                        ConnectData.message = "Record already exist!";
                        ConnectData.title = "Save Failed";
                        MessageBox.Show(ConnectData.message, ConnectData.title);

                    }

                    else
                    {
                        MessageBox.Show(ConnectData.message, ConnectData.title);
                        txtOrder.Text = "";
                    }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
