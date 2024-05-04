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
using System.Security.Cryptography;

namespace ReportingSystem
{
    public partial class EditCoy : Form
    {
       
        public EditCoy()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditCoy_Load(object sender, EventArgs e)
        {
            callBrigadeRights();
        }
        public void callBrigadeRights()
        {
            /* cmbBrigade.DataSource = ConnectData.LoadBrigadeRights();
             cmbBrigade.ValueMember = "ID";
             cmbBrigade.DisplayMember = "Brigade";
            */
            cmbBrigade.ValueMember = "ID";
            cmbBrigade.DisplayMember = "Brigade";
            if (ConnectData.createRights == "Administrator")
            {

                var dataset = ConnectData.insert_info.sp_selectBrigade().ToList();
                cmbBrigade.DataSource = dataset;
            }
            else
            {
                var dataset = ConnectData.insert_info.sp_selectBrigadebyBde(ConnectData.bdeLevelAccess).ToList();
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

              
                if (cmbBrigade.SelectedValue != null)
                {
                    int BrigadeId = (int)cmbBrigade.SelectedValue;

                    var dataset = ConnectData.insert_info.sp_selectUnit(Bdeid);
                    cmbUnit.ValueMember = "ID";
                    cmbUnit.DisplayMember = "Unit";

                    cmbUnit.DataSource = dataset;


                }
            }
            catch (Exception)
            {
                //error has occor
                //check for eror here
            }
        }// callUnitRights()

        private void Brigade_Enter(object sender, EventArgs e)
        {

        }

        private void cmbBrigade_SelectedIndexChanged(object sender, EventArgs e)
        {
            callUnitRights();
        }


        private void LoadCoyRights()
        {
            try
            {
                int unitID = (int)cmbUnit.SelectedValue;
                int BdeID = (int)cmbBrigade.SelectedValue;

                 CmbCoy.ValueMember = "ID";
                CmbCoy.DisplayMember = "CoyName";
                var dataset = ConnectData.insert_info.sp_selectCoy(BdeID, unitID);
                CmbCoy.DataSource = dataset;
            }
            catch (Exception)
            {
                //Code for error here
            }

          
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCoyRights();
        }

        private void CmbCoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCoy.Text = CmbCoy.Text;
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
            else if (CmbCoy.Text == "")
            {
                ConnectData.message = "Company Name is Missing!";
                ConnectData.title = "Company";
                MessageBox.Show(ConnectData.message, ConnectData.title);

            }
            else if (txtCoy.Text == "")
            {
                ConnectData.message = "Please enter Company name !";
                ConnectData.title = "Company";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else
            {
                //********Update Record Here
                ConnectData.message = "Record Updated Successfully";
                ConnectData.title = "Save";
                int BrigadeId = (int)cmbBrigade.SelectedValue;
                int Unitid = (int)cmbUnit.SelectedValue;
                int CoyID = (int)CmbCoy.SelectedValue;
                /*
                using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EditCoy", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@unitId", SqlDbType.Int).Value = Unitid;
                        cmd.Parameters.Add("@bdeid", SqlDbType.Int).Value = BrigadeId;
                        cmd.Parameters.Add("@CoyId", SqlDbType.Int).Value = CoyID;
                        cmd.Parameters.Add("@Coyname", SqlDbType.VarChar).Value = txtCoy.Text;

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
                            LoadCoyRights();
                            MessageBox.Show(ConnectData.message, ConnectData.title);
                            txtCoy.Text = "";
                        }
                    }
                }
                */
                var dataset = ConnectData.insert_info.sp_EditCoy(Unitid, BrigadeId, CoyID, txtCoy.Text);
                if (dataset > 1)
                {
                    ConnectData.message = "Record already exist!";
                    ConnectData.title = "Save Failed";
                    MessageBox.Show(ConnectData.message, ConnectData.title);

                }

                else
                {
                    LoadCoyRights();
                    MessageBox.Show(ConnectData.message, ConnectData.title);
                    txtCoy.Text = "";
                }
            }
        }//end of function


    }
}

