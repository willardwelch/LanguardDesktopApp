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
    public partial class DeleteUnit : Form
    {
        public DeleteUnit()
        {
            InitializeComponent();
            callBrigadeRights();
            callUnitRights();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
        
        public void DeleteUnits()
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
           
            else
            {
                //********Delete Record Here

                var ans = MessageBox.Show("Are you sure you want to delete this record", "Delete Record", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    int BrigadeId = (int)cmbBrigade.SelectedValue;
                    int Unitid = (int)cmbUnit.SelectedValue;
                    /*  using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                      {
                          using (SqlCommand cmd = new SqlCommand("sp_DeleteUnit", con))
                          {
                              cmd.CommandType = CommandType.StoredProcedure;

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
                                  ConnectData.message = "Record Successfully Deleted!";
                                  ConnectData.title = "Record Deleted";
                                  MessageBox.Show(ConnectData.message, ConnectData.title);
                                  callUnitRights();

                              }

                          }
                      }*/
                    var dataset = ConnectData.insert_info.sp_DeleteUnit(Unitid, BrigadeId);
                    if (dataset > 0)
                    {
                        ConnectData.message = "Record Successfully Deleted!";
                        ConnectData.title = "Record Deleted";
                        MessageBox.Show(ConnectData.message, ConnectData.title);
                        callUnitRights();

                    }

                }
            }
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DeleteUnits();
        }

        private void cmbBrigade_SelectedIndexChanged(object sender, EventArgs e)
        {
            callUnitRights();
        }

        private void DeleteUnit_Load(object sender, EventArgs e)
        {

        }


        public void callBrigadeRights()
        {
            /* cmbBrigade.DataSource = ConnectData.LoadBrigadeRights();
             */
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

               
                    var dataset = ConnectData.insert_info.sp_selectUnit(Bdeid);
                    cmbUnit.ValueMember = "ID";
                    cmbUnit.DisplayMember = "Unit";
                    cmbUnit.DataSource = dataset;
               
               
            }

            catch (Exception)
            {
                //error has occor
                //check for eror here
            }
        }// callUnitRights()

    }
}
