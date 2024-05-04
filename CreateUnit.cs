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
    public partial class CreateUnit : Form
    {
        
        public CreateUnit()
        {
            InitializeComponent();
        }

        private void CreateUnit_Load(object sender, EventArgs e)
        {
            // LoadBrigade();
            callBrigadeRights();
        }

        public void callBrigadeRights()
        {
            /* cmbBrigade.DataSource = ConnectData.LoadBrigadeRights();
             cmbBrigade.ValueMember = "ID";
             cmbBrigade.DisplayMember = "Brigade";*/
            if (ConnectData.createRights == "Administrator")
            {
               // var insert_info = new WinformReportingSystemEntities();
                var dataset = ConnectData.insert_info.sp_selectBrigade();
                cmbBrigade.ValueMember = "ID";
                cmbBrigade.DisplayMember = "Brigade";
                cmbBrigade.DataSource = dataset;
            }
            else
            {
              //  var insert_info = new WinformReportingSystemEntities();
                var dataset = ConnectData.insert_info.sp_selectBrigadebyBde(ConnectData.bdeLevelAccess);
                cmbBrigade.ValueMember = "ID";
                cmbBrigade.DisplayMember = "Brigade";

                cmbBrigade.DataSource = dataset;
            }

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectData.message = "Please enter Unit Name";
            ConnectData.title = "Unit is Missing";
            if (txtUnit.Text == "")
            {
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtUnit.Focus();

            }
            else
            {
                ConnectData.message = "Record Saved Successfully";
                ConnectData.title = "Save";
                int BrigadeId = (int)cmbBrigade.SelectedValue;
                /*   using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                   {
                       using (SqlCommand cmd = new SqlCommand("[sp_InsertUnit]", con))
                       {
                           cmd.CommandType = CommandType.StoredProcedure;

                           cmd.Parameters.Add("@UnitName", SqlDbType.VarChar).Value = txtUnit.Text;
                           cmd.Parameters.Add("@bdeId", SqlDbType.Int).Value = BrigadeId;

                           var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                           returnParameter.Direction = ParameterDirection.ReturnValue;
                           con.Open();
                           cmd.ExecuteNonQuery();
                           int returnValue = (int)returnParameter.Value;
                           con.Close();
                */
                   // var insert_info = new WinformReportingSystemEntities();
                    var returnValue = ConnectData.insert_info.sp_InsertUnit(txtUnit.Text, BrigadeId);

                    if (returnValue > 0)
                     {
                            ConnectData.message = "Record already exist!";
                            ConnectData.title = "Save Failed";
                            MessageBox.Show(ConnectData.message, ConnectData.title);

                     }
                     else
                       {
                            MessageBox.Show(ConnectData.message, ConnectData.title);
                            txtUnit.Text = "";
                        }
                        
                   // }
               // }
            }
        }// end of function
    }
}
