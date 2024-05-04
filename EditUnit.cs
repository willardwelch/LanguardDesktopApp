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
    public partial class EditUnit : Form
    {
       

        public EditUnit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditUnit_Load(object sender, EventArgs e)
        {
            callBrigadeRights();
            callUnitRights();
          //  LoadUnit();
        }

        public void callBrigadeRights()
        {
           // cmbBrigade.DataSource = ConnectData.LoadBrigadeRights();
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
               /* int Bdeid;
                if (string.Compare(ConnectData.createRights, "Administrator") != 0)
                {
                    Bdeid = ConnectData.bdeLevelAccess;
                }
                else
                {
                    Bdeid = int.Parse(cmbBrigade.SelectedValue.ToString());
                }
               */
              
                if (cmbBrigade.SelectedValue != null)
                {
                    int BrigadeId = (int)cmbBrigade.SelectedValue;
                    cmbUnit.ValueMember = "ID";
                    cmbUnit.DisplayMember = "Unit";

                    var dataset = ConnectData.insert_info.sp_selectUnit(BrigadeId);
                    cmbUnit.DataSource = dataset;
                }
            }

            catch(Exception)
            {
                //error has occor
                //check for eror here
            }
        }// callUnitRights()



        private void button1_Click_1(object sender, EventArgs e)
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
            else if (TxtUnit.Text == "")
            {
                ConnectData.message = "Please Enter Unit Name!";
                ConnectData.title = "Unit";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else
            {
                //********Update Record Here
                ConnectData.message = "Record Updated Successfully";
                ConnectData.title = "Save";
                int BrigadeId = (int)cmbBrigade.SelectedValue;
                int Unitid = (int)cmbUnit.SelectedValue;
                /*
                using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateUnit", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@UnitName", SqlDbType.VarChar).Value = TxtUnit.Text;
                        cmd.Parameters.Add("@bdeId", SqlDbType.Int).Value = BrigadeId;
                        cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = Unitid;

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
                            callUnitRights();
                            TxtUnit.Text = "";
                        }
                    }
                }
                */
                var dataset = ConnectData.insert_info.sp_UpdateUnit(Unitid, TxtUnit.Text, BrigadeId);
                if (dataset > 1)
                {
                    ConnectData.message = "Record already exist!";
                    ConnectData.title = "Save Failed";
                    MessageBox.Show(ConnectData.message, ConnectData.title);

                }

                else
                {
                    MessageBox.Show(ConnectData.message, ConnectData.title);
                    callUnitRights();
                    TxtUnit.Text = "";
                }
            }
        }

       

        private void cmbBrigade_SelectedIndexChanged(object sender, EventArgs e)
        {
            callUnitRights();
        }

        private void cmbUnit_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TxtUnit.Text = cmbUnit.Text;
        }
    }
}