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
    public partial class Createcoy : Form
    {
         public Createcoy()
        {
            InitializeComponent();
        }

        private void Createcoy_Load(object sender, EventArgs e)
        {
            callBrigadeRights();
            callUnitRights();
        }

       
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void callBrigadeRights()
        {
            //  cmbBrigade.DataSource = ConnectData.LoadBrigadeRights();
            //var insert_info = new WinformReportingSystemEntities();

            if (ConnectData.createRights == "Administrator")
            {

                var dataset = ConnectData.insert_info.sp_selectBrigade();
                cmbBrigade.ValueMember = "ID";
                cmbBrigade.DisplayMember = "Brigade";
                cmbBrigade.DataSource = dataset;
            }
            else
            {
                var dataset = ConnectData.insert_info.sp_selectBrigadebyBde(ConnectData.bdeLevelAccess);
                cmbBrigade.ValueMember = "ID";
                cmbBrigade.DisplayMember = "Brigade";
                cmbBrigade.DataSource = dataset;
            }
        }



            public void callUnitRights()
        {
            try
            {
                int Bdeid;
                if (string.Compare(ConnectData.createRights, "Administrator") != 0)
                {
                    Bdeid = ConnectData.bdeLevelAccess;
                }
                else
                {
                    Bdeid = int.Parse(cmbBrigade.SelectedValue.ToString());
                }
                cmbUnit.ValueMember = "ID";
               
               
                if (ConnectData.UnitLevelAccess > 0)
                {
                    var dataset = ConnectData.insert_info.sp_selectUnitbyID(Bdeid, ConnectData.UnitLevelAccess);
                    cmbUnit.DisplayMember = "Unit";
                    cmbUnit.DataSource = dataset;
                }
                else
                {
                    var dataset = ConnectData.insert_info.sp_selectUnit(Bdeid);
                    cmbUnit.DisplayMember = "Unit";

                    cmbUnit.DataSource = dataset;
                }
               // cmbUnit.DataSource = ConnectData.LoadUnitRights(Bdeid);
                
            }

            catch (Exception)
            {
                //error has occor
                //check for eror here
            }
        }// callUnitRights()

        private void cmbBrigade_SelectedIndexChanged(object sender, EventArgs e)
        {
            callUnitRights();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbBrigade.Text == "")
            {
                ConnectData.message = "Brigade Name is Missing!";
                ConnectData.title = "Brigade";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }

            else if (cmbUnit.Text == "")
            {
                ConnectData.message = "Unit Name is Missing!";
                ConnectData.title = "Unit";
                MessageBox.Show(ConnectData.message, ConnectData.title);

            }
            else if (txtCoy.Text== "")
            {
                ConnectData.message = "Please enter Company name !";
                ConnectData.title = "Company";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else
            {
                //********Update Record Here
                ConnectData.message = "Record Saved Successfully";
                ConnectData.title = "Save";
                int BrigadeId = (int)cmbBrigade.SelectedValue;
                int Unitid = (int)cmbUnit.SelectedValue;
                /* using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                 {
                     using (SqlCommand cmd = new SqlCommand("sp_InsertCoy", con))
                     {
                         cmd.CommandType = CommandType.StoredProcedure;

                         cmd.Parameters.Add("@CoyName", SqlDbType.VarChar).Value = txtCoy.Text;
                         cmd.Parameters.Add("@bdeId", SqlDbType.Int).Value = BrigadeId;
                         cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = Unitid;

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
                             txtCoy.Text = "";
                         }
                     }

                 } */
                  

                    var returnValue = ConnectData.insert_info.sp_InsertCoy(txtCoy.Text, Unitid, BrigadeId);
                    if (returnValue > 0)
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
                        txtCoy.Text = "";
                    }


            }
        }

        private void txtCoy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
