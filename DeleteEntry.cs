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
using System.IdentityModel.Metadata;

namespace ReportingSystem
{
    public partial class DeleteEntry : Form
    {
        public DeleteEntry()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteentryRecord();
        }
        private void LoadEntry()
        {
            //string connectionString = "Data Source=DESKTOP-GUFUJSB;Initial Catalog=ReportingSystem;Integrated Security=True;Trust Server Certificate=True";
          
           // cmdEntry.DataSource = ConnectData.LoadEntryClass();

            var dataset = ConnectData.insert_info.sp_selectEntryName();
            cmdEntry.ValueMember = "ID";
            cmdEntry.DisplayMember = "Entry";
            cmdEntry.DataSource = dataset;
         
        }

        private void DeleteEntry_Load(object sender, EventArgs e)
        {
            LoadEntry();
        }

        private void deleteentryRecord()
        {
            if (cmdEntry.Text != "")
            {
                int EntryId = (int)cmdEntry.SelectedValue;
                var ans = MessageBox.Show("Are you sure you want to delete this record", "Delete Record", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    try
                    {
                        /*  using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                          {
                              using (SqlCommand cmd = new SqlCommand("sp_DeleteEntryName", con))
                              {
                                  cmd.CommandType = CommandType.StoredProcedure;

                                  cmd.Parameters.Add("@entryid", SqlDbType.Int).Value = EntryId;

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
                                      LoadEntry();
                                      MessageBox.Show(ConnectData.message, ConnectData.title);
                                  }
                              }// end of  using (SqlCommand cmd = new SqlCommand("sp_DeleteEntryName", con))
                          */
                        // }// end of   using (SqlConnection con = new SqlConnection(ConnectData.connectionString))

                                var dataset = ConnectData.insert_info.sp_DeleteEntryName(EntryId);
                                if (dataset > 0)
                                {
                                    ConnectData.message = "Record successfully deleted!";
                                    ConnectData.title = "Record Deleted";
                                    LoadEntry();
                                    MessageBox.Show(ConnectData.message, ConnectData.title);
                                }

                    }//end try

                    catch (Exception mes){

                        MessageBox.Show(mes.Message, "Error as occurred");
                    }
                }
            }//end if
        }//end of deleteentryRecord()

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
