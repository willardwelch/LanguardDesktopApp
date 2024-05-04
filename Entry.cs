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
    public partial class Entry : Form
    {
       
        public Entry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConnectData.message = "Please enter Entry Name";
            ConnectData.title = "Entry name is Missing";
            if (txtEntryName.Text == "")
            {
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtEntryName.Focus();

            }
            else
            {
                ConnectData.message = "Record Saved Successfully";
                ConnectData.title = "Save";
                /*
                using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_InsertEntryName]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@EntryName", SqlDbType.VarChar).Value = txtEntryName.Text;
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
                            txtEntryName.Text = "";
                        }
                    }
                }
                */
                var dataset = ConnectData.insert_info.sp_InsertEntryName(txtEntryName.Text);
                if (dataset > 0)
                {
                    ConnectData.message = "Record already exist!";
                    ConnectData.title = "Save Failed";
                    MessageBox.Show(ConnectData.message, ConnectData.title);

                }

                else
                {
                    MessageBox.Show(ConnectData.message, ConnectData.title);
                    txtEntryName.Text = "";
                }

            }

        }

        private void Entry_Load(object sender, EventArgs e)
        {

        }
    }
}
