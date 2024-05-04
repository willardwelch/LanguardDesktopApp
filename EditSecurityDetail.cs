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
using System.IO;

namespace ReportingSystem
{
    public partial class EditSecurityDetail : Form
    {
       
        public EditSecurityDetail()
        {
            InitializeComponent();
        }

        private void EditSecurityDetail_Load(object sender, EventArgs e)
        {

        }

        private void GetSearchInfo()
        {
           // SqlConnection connDb = new SqlConnection(ConnectData.connectionString);
           // connDb.Open();
            if (txtSearchLName.Text != "")
            {

                /*  using (var command = new SqlCommand("sp_SearchSecurityDetail", connDb)
                  {
                      // Set command type and add Parameters
                      CommandType = CommandType.StoredProcedure,
                      Parameters = { new SqlParameter("@LastName", txtSearchLName.Text) }
                  })
                  {
                */
                // Execute command in Adapter and store to datatable
                // var adapter = new SqlDataAdapter(command);
                // DataTable de = new DataTable();
                // adapter.Fill(de);
              
                try
                {
                    var dataset = ConnectData.insert_info.sp_SearchSecurityDetail(txtSearchLName.Text);
                    this.dataGridView1.DataSource = dataset;
                     this.dataGridView1.Columns[0].Visible = false;
                }
                catch (IOException) { }

              /*  }
                connDb.Close();
                */

            }
            else
            {
                ConnectData.message = "Please enter name to search by";
                ConnectData.title = "name Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtSearchLName.Focus();

            }

        }

        private void Search_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            GetSearchInfo();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Visible = true;
            dataGridView1.Visible = false;

            // txtFirstName=dataGridView1.
            if (e.RowIndex > -1)
            {
                txtIDNum.Text = this.dataGridView1[0, e.RowIndex].Value.ToString();
                txtFirstName.Text = this.dataGridView1[1, e.RowIndex].Value.ToString();
                txtLastName.Text = this.dataGridView1[2, e.RowIndex].Value.ToString();
                cmbMStatus.Text = this.dataGridView1[3, e.RowIndex].Value.ToString();
                cmbGender.Text = this.dataGridView1[4, e.RowIndex].Value.ToString();
                txtDOB.Text = this.dataGridView1[5, e.RowIndex].Value.ToString();
                txtDOE.Text = this.dataGridView1[6, e.RowIndex].Value.ToString();
                txtRod.Text = this.dataGridView1[7, e.RowIndex].Value.ToString();
                txtAddress.Text = this.dataGridView1[8, e.RowIndex].Value.ToString();
                cmbParish.Text = this.dataGridView1[9, e.RowIndex].Value.ToString();

            }
        }



        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Visible = true;
            dataGridView1.Visible = false;

            // txtFirstName=dataGridView1.
            if (e.RowIndex > -1)
            {
                txtIDNum.Text = this.dataGridView1[0, e.RowIndex].Value.ToString();
                txtFirstName.Text = this.dataGridView1[1, e.RowIndex].Value.ToString();
                txtLastName.Text = this.dataGridView1[2, e.RowIndex].Value.ToString();
                cmbMStatus.Text = this.dataGridView1[3, e.RowIndex].Value.ToString();
                cmbGender.Text = this.dataGridView1[4, e.RowIndex].Value.ToString();
                txtDOB.Text = this.dataGridView1[5, e.RowIndex].Value.ToString();
                txtDOE.Text = this.dataGridView1[6, e.RowIndex].Value.ToString();
                txtRod.Text = this.dataGridView1[7, e.RowIndex].Value.ToString();
                txtAddress.Text = this.dataGridView1[8, e.RowIndex].Value.ToString();
                cmbParish.Text = this.dataGridView1[9, e.RowIndex].Value.ToString();
                cmbParish.Text = this.dataGridView1[8, e.RowIndex].Value.ToString();

            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBox1.Visible = true;
            dataGridView1.Visible = false;

            // txtFirstName=dataGridView1.
            if (e.RowIndex > -1)
            {
                txtIDNum.Text = this.dataGridView1[0, e.RowIndex].Value.ToString();
                txtFirstName.Text = this.dataGridView1[1, e.RowIndex].Value.ToString();
                txtLastName.Text = this.dataGridView1[2, e.RowIndex].Value.ToString();
                cmbMStatus.Text = this.dataGridView1[3, e.RowIndex].Value.ToString();
                cmbGender.Text = this.dataGridView1[4, e.RowIndex].Value.ToString();
                txtDOB.Text = this.dataGridView1[5, e.RowIndex].Value.ToString();
                txtDOE.Text = this.dataGridView1[6, e.RowIndex].Value.ToString();
                txtRod.Text = this.dataGridView1[7, e.RowIndex].Value.ToString();
                txtAddress.Text = this.dataGridView1[8, e.RowIndex].Value.ToString();
                cmbParish.Text = this.dataGridView1[9, e.RowIndex].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateSecurityInfo();
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

        private void updateSecurityInfo()
        {
            try
            {
                int IDNumber = int.Parse(txtIDNum.Text);
                /*
                using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_UpdateSecurityDetail]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IDNum", SqlDbType.Int).Value = IDNumber;
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
                            ConnectData.message = "Record Updated Successfully";
                            ConnectData.title = "Updated";
                            MessageBox.Show(ConnectData.message, ConnectData.title);
                            EmptyComponent();
                            GetSearchInfo();
                            groupBox1.Visible = false;
                            dataGridView1.Visible = true;

                        }

                        else
                        {
                            //MessageBox.Show(ConnectData.message, ConnectData.title);

                        }
                    }
                }
                */
                var dataset = ConnectData.insert_info.sp_UpdateSecurityDetail(IDNumber, txtFirstName.Text, txtFirstName.Text, cmbGender.Text, cmbMStatus.Text, DateTime.Parse(txtDOB.Text), DateTime.Parse(txtDOE.Text), DateTime.Parse(txtRod.Text), txtAddress.Text.ToString(), cmbParish.Text.ToString());
                if (dataset > 0)
                {
                    ConnectData.message = "Record Updated Successfully";
                    ConnectData.title = "Updated";
                    MessageBox.Show(ConnectData.message, ConnectData.title);
                    EmptyComponent();
                    GetSearchInfo();
                    groupBox1.Visible = false;
                    dataGridView1.Visible = true;

                }

                else
                {
                    //MessageBox.Show(ConnectData.message, ConnectData.title);

                }
            }
            catch (Exception a)
            {
                ConnectData.message = a.Message;
                ConnectData.title = "Update Failed";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
