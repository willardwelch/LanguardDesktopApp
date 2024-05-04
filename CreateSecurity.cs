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
    public partial class CreateSecurity : Form
    {
       
        public CreateSecurity()
        {
            InitializeComponent();
        }

        private void CreateSecurity_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSecurityInfo();
        } 
        private void EmptyComponent()
        {
            txtAddress.Text = "";
            txtDOB.Text = "";
            txtDOE.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtRod.Text = "";
            cmbGender.Text = "";
            cmbParish.Text = "";
            cmbMStatus.Text = "";

        }

        private void SaveSecurityInfo()
        {
            ConnectData.message = "Record Saved Successfully";
            ConnectData.title = "Save";
            try
            {
                /*
                   using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                   {
                       using (SqlCommand cmd = new SqlCommand("sp_InsertSecurityDetail", con))
                       {

                           cmd.CommandType = CommandType.StoredProcedure;

                           cmd.Parameters.Add("@FirstrName", SqlDbType.VarChar).Value = txtFirstName.Text;
                           cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;
                           cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = cmbGender.Text;
                           cmd.Parameters.Add("@MaritalStatus", SqlDbType.VarChar).Value = cmbMStatus.Text;
                           cmd.Parameters.Add("@dob", SqlDbType.Date).Value = DateTime.Parse(txtDOB.Text);
                           cmd.Parameters.Add("@DOE", SqlDbType.Date).Value = DateTime.Parse(txtDOE.Text);
                           cmd.Parameters.Add("@ROD", SqlDbType.Date).Value = DateTime.Parse(txtRod.Text);
                           cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtAddress.Text.ToString();
                           cmd.Parameters.Add("@Parish", SqlDbType.VarChar).Value = cmbParish.Text.ToString();




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
                               EmptyComponent();
                           }
                       }
                   }
                   */
                  //  var insert_info = new WinformReportingSystemEntities();
                    var returnValue = ConnectData.insert_info.sp_InsertSecurityDetail(txtFirstName.Text, txtLastName.Text, cmbGender.Text, cmbMStatus.Text, DateTime.Parse(txtDOB.Text), DateTime.Parse(txtDOE.Text), DateTime.Parse(txtRod.Text), txtAddress.Text.ToString(), cmbParish.Text.ToString());
                    if (returnValue > 0)
                    {
                        ConnectData.message = "Record already exist!";
                        ConnectData.title = "Save Failed";
                        MessageBox.Show(ConnectData.message, ConnectData.title);

                    }

                    else
                    {
                        MessageBox.Show(ConnectData.message, ConnectData.title);
                        EmptyComponent();
                    }
            }
            catch (Exception ex)
            {
                ConnectData.message = ex.Message;
                ConnectData.title = "Save Failed";
                MessageBox.Show(ConnectData.message, ConnectData.title);
                
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
