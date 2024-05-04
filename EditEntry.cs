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
using System.Drawing.Drawing2D;

namespace ReportingSystem
{
    public partial class EditEntry : Form
    {
        
        public EditEntry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditEntry_Load(object sender, EventArgs e)
        {
            LoadEntry();
        }
        private void LoadEntry()
        {
           
            cmdEntry.ValueMember = "ID";
            cmdEntry.DisplayMember = "Entry";
            var dataset = ConnectData.insert_info.sp_selectEntryName();
            cmdEntry.DataSource = dataset;
        }

        private void cmdEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtentry.Text = cmdEntry.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtentry.Text == "")
            {

            }
            else
            {
                ConnectData.message = "Record Updated Successfully";
                ConnectData.title = "Entry";
                int EntryId = (int)cmdEntry.SelectedValue;
                /*
                 using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateEntryName", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@entryName", SqlDbType.VarChar).Value = txtentry.Text;
                        cmd.Parameters.Add("@entryid", SqlDbType.Int).Value = EntryId;

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
                            MessageBox.Show(ConnectData.message, ConnectData.title);
                            LoadEntry();
                            txtentry.Text = "";
                        }
                    }
                }
                 */
                       var dataset = ConnectData.insert_info.sp_UpdateEntryName(txtentry.Text, EntryId);
                        if (dataset > 1)
                        {
                            ConnectData.message = "Record already exist!";
                            ConnectData.title = "Save Failed";
                            MessageBox.Show(ConnectData.message, ConnectData.title);

                        }

                        else
                        {
                            MessageBox.Show(ConnectData.message, ConnectData.title);
                            LoadEntry();
                            txtentry.Text = "";
                        }

            }//end of else

        } // btnSave_Click
    }// EditEntry
}
