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
    public partial class EditBrigade : Form
    {
        
        public EditBrigade()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void EditBrigade_Load(object sender, EventArgs e)
        {
            callLoadBrigade();

        }


        private void callLoadBrigade()
        {
            cmbBrigade1.ValueMember = "ID";
           
            if (ConnectData.createRights == "Administrator")
            {

                var dataset = ConnectData.insert_info.sp_selectBrigade();
                cmbBrigade1.DisplayMember = "Brigade";

                cmbBrigade1.DataSource = dataset;
            }
            else
            {
                var dataset = ConnectData.insert_info.sp_selectBrigadebyBde(ConnectData.bdeLevelAccess);
                cmbBrigade1.DisplayMember = "Brigade";
                cmbBrigade1.DataSource = dataset;
            }
            //  cmbBrigade1.Bin = dataset;


        }

        private void cmbBrigade1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBrigade.Text = cmbBrigade1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          /*  if (cmbBrigade1.Text == "")
            {
                ConnectData.message = "Please Select a Brigade to Edit";
                ConnectData.title = "Brigade Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }*/
           // else
            if (txtBrigade.Text == "")
            {
                ConnectData.message = "Please enter the new Brigade name to update to";
                ConnectData.title = "Brigade Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtBrigade.Focus();
            }
            else
            {
                int BrigadeId = (int)cmbBrigade1.SelectedValue;

                /* using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                 {
                     using (SqlCommand cmd = new SqlCommand("[sp_UpdateBrigade]", con))
                     {
                         cmd.CommandType = CommandType.StoredProcedure;

                         cmd.Parameters.Add("@brigadeName", SqlDbType.VarChar).Value = txtBrigade.Text;
                         cmd.Parameters.Add("@bdeId", SqlDbType.Int).Value = BrigadeId;

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
                             ConnectData.message = "Record Successfully Updated";
                             ConnectData.title = "Record Updated";
                             MessageBox.Show(ConnectData.message, ConnectData.title);
                             callLoadBrigade();
                             txtBrigade.Text = "";
                         }
                     }

                 } */
                   
                    var returnValue = ConnectData.insert_info.sp_UpdateBrigade(txtBrigade.Text, BrigadeId);
                    if (returnValue > 1)
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
                        callLoadBrigade();
                        txtBrigade.Text = "";
                    }

            }
        }
    }
}
