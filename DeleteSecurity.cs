using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingSystem
{
    public partial class DeleteSecurity : Form
    {
        public DeleteSecurity()
        {
            InitializeComponent();
        }


        private void Search_Click(object sender, EventArgs e)
        {
            /*try
            {
                var dataset = ConnectData.insert_info.sp_SearchSecurityDetail(txtSearchLName.Text);
                this.dataGridView1.DataSource = dataset;
                this.dataGridView1.Columns[0].Visible = false;
            }
            catch (IOException) { }*/
            GetSearchInfo();

        }
        private void GetSearchInfo()
        {
            // SqlConnection connDb = new SqlConnection(ConnectData.connectionString);
            //  connDb.Open();
            if (this.txtSearchLName.Text != "")
            {

                /*  using (var command = new SqlCommand("sp_SearchSecurityDetail", connDb)
                  {
                      // Set command type and add Parameters
                      CommandType = CommandType.StoredProcedure,
                      Parameters = { new SqlParameter("@LastName", txtSearchLName.Text) }
                  })
                  {
                      // Execute command in Adapter and store to datatable
                      var adapter = new SqlDataAdapter(command);
                      DataTable de = new DataTable();
                      adapter.Fill(de);*/
                var dataset = ConnectData.insert_info.sp_SearchSecurityDetail(txtSearchLName.Text);
                SearchResult.DataSource = dataset;
                SearchResult.Columns[0].Visible = false;
                SearchResult.Visible = true;


                // }
                // connDb.Close();

            }
            else
            {
                ConnectData.message = "Please enter name to search by";
                ConnectData.title = "name Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtSearchLName.Focus();

            }

        }
        private void DeleteSecurity_Load(object sender, EventArgs e)
        {

        }
    }
}
