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
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.IO;

namespace ReportingSystem
{
    public partial class DeleteCoy : Form
    {
        public DeleteCoy()
        {
            InitializeComponent();
        }

        private void DeleteCoy_Load(object sender, EventArgs e)
        {
            callBrigadeRights();
            LoadUnit();
            LoadCoyRights();
        }
       
        public void callBrigadeRights()
        {
            /* cmbBrigade.DataSource = ConnectData.LoadBrigadeRights();
             cmbBrigade.ValueMember = "ID";
             cmbBrigade.DisplayMember = "Brigade";

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
        
        private void LoadUnit()
        {
            try
            {
                if (cmbBrigade.SelectedValue != null)
                {
                    int BrigadeId = (int)cmbBrigade.SelectedValue;

                    cmbUnit.ValueMember = "ID";
                    cmbUnit.DisplayMember = "Unit";
                    var dataset = ConnectData.insert_info.sp_selectUnit(BrigadeId);
                    cmbUnit.DataSource = dataset;


                }
            }
            catch(IOException)
            {

            }

        }

        private void LoadCoyRights()
        {
            try
            {
                int BdeID = (int)cmbBrigade.SelectedValue;
                int unitID = (int)cmbUnit.SelectedValue;

                //  CmbCoy.DataSource = ConnectData.LoadCoy(unitID, BdeID, cmbUnit.Text);
                var dataset = ConnectData.insert_info.sp_selectCoy( BdeID, unitID);

                CmbCoy.ValueMember = "ID";
                CmbCoy.DisplayMember = "CoyName";
                CmbCoy.DataSource = dataset;
            }
            catch (IOException)
            {

            }
        }
      

        private void DeleteRecord()
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
            else
            {
                //********Delete Record Here
                int BrigadeId = (int)cmbBrigade.SelectedValue;
                int Unitid = (int)cmbUnit.SelectedValue;
                int CoyID = (int)CmbCoy.SelectedValue;

                if (CoyID == 0)
                    return;

                var ans = MessageBox.Show("Are you sure you want to delete this record", "Delete Record", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    try
                    {
                        var dataset = ConnectData.insert_info.sp_DeleteCoy(Unitid, BrigadeId, CoyID);
                        if (dataset > 0)
                        {
                            LoadCoyRights();
                            MessageBox.Show("Record successfully deleted", "Record Delete");

                        }

                     
                   // } // end of  using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                    }// end of try

                    catch(Exception ex){
                        MessageBox.Show(ex.Message, "Error as occurred");
                    }
                }

            }// end of else
        } //end of DeleteRecord()

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCoyRights();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Brigade_Enter(object sender, EventArgs e)
        {

        }

        private void cmbBrigade_SelectedIndexChanged(object sender, EventArgs e)
        {
                 LoadUnit();
                 LoadCoyRights();
        }
    }
}

