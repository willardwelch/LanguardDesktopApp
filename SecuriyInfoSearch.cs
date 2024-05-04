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
using System.Security.Cryptography;

namespace ReportingSystem
{
    public partial class SecuriyInfoSearch : Form
    {
      
        public SecuriyInfoSearch()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SecuriyInfoSearch_Load(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            GetSearchInfo();
        }

        private void GetSearchInfo()
        {
            // SqlConnection connDb = new SqlConnection(ConnectData.connectionString);
            //  connDb.Open();
            if (txtSearchLName.Text != "")
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
                  dataGridView1.DataSource = dataset;
                  dataGridView1.Columns[0].Visible = false;
                  dataGridView1.Visible = true;


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

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }//end of class
}