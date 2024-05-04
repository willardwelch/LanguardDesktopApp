using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ReportingSystem
{
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            LoadUsertoDataGrid();
            LoadBrigade();
            LoadUnit();
            LoadCoy();
        }

        public void LoadUsertoDataGrid()
        {
            var dataset = ConnectData.insert_info.sp_SelectUser().ToList();
            dataGridView1.DataSource = dataset;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void LoadBrigade()
        {

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

            cmbUnit1.Refresh();
            cmbCoy.Refresh();
            // Close connection

            LoadUnit();
        }

        private void LoadUnit()
        {

            if (this.cmbBrigade.SelectedValue.ToString() != null)
            {
                int BrigadeId = int.Parse(this.cmbBrigade.SelectedValue.ToString());

                var dataset = ConnectData.insert_info.sp_selectUnit(BrigadeId);


                this.cmbUnit1.ValueMember = "id";
                this.cmbUnit1.DisplayMember = "Unit";
                this.cmbUnit1.DataSource = dataset;

                this.cmbUnit1.Refresh();

            }

            //    LoadCoy();

        }

        private void LoadCoy()
        {

            try
            {
                //  SqlConnection connDb = new SqlConnection(ConnectData.connectionString);
                //  connDb.Open();
                int unitID = int.Parse(this.cmbUnit1.SelectedValue.ToString());
                int BdeID = int.Parse(this.cmbBrigade.SelectedValue.ToString());

                if (this.cmbUnit1.Text != null)
                {

                    var dataset = ConnectData.insert_info.sp_selectCoy(BdeID, unitID);
                    this.cmbCoy.ValueMember = "ID";
                    this.cmbCoy.DisplayMember = "CoyName";
                    this.cmbCoy.DataSource = dataset;
                }

                // connDb.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error as occurred", MessageBoxButtons.OK);
            }

        }

        public void getBrigadeName(int bdeID)
        {



            var dataset = ConnectData.insert_info.sp_selectBrigadebyBde(bdeID);

           this.cmbHideBrigade.ValueMember = "ID";
            this.cmbHideBrigade.DisplayMember = "Brigade";
            this.cmbHideBrigade.DataSource = dataset;

            this.cmbHideBrigade.Refresh();

            cmbBrigade.SelectedValue = cmbHideBrigade.SelectedValue;
         

        }

        public void getUnitName(int bdeID, int UnitdID)
        {



            var dataset = ConnectData.insert_info.sp_selectUnitbyID(bdeID, UnitdID);



           cmbhideUnit.DisplayMember = "Unit";
            cmbhideUnit.ValueMember = "ID";
            cmbhideUnit.DataSource = dataset;

            cmbUnit1.SelectedValue = cmbhideUnit.SelectedValue;
            // cmd.ExecuteNonQuery();


        }

        public void getCoyName(int bdeID, int UnitdID, int CoyID)
        {



            var dataset = ConnectData.insert_info.sp_selectCoybyID(UnitdID, bdeID, CoyID);

           cmbhidecoy.DisplayMember = "Company";
            cmbhidecoy.ValueMember = "ID";
            cmbhidecoy.DataSource = dataset;

            cmbCoy.SelectedValue = cmbhidecoy.SelectedValue;
            // cmd.ExecuteNonQuery();*/


        }
        private void dataGridView1_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string rights = "";
            if (e.RowIndex > -1)
            {
                groupBox2.Visible = true;
                Brigade.Visible = true;
                txtUserName.Text = this.dataGridView1[0, e.RowIndex].Value.ToString();
                rights = this.dataGridView1[2, e.RowIndex].Value.ToString();
                if (rights == radioButton1.Text)
                    radioButton1.Checked = true;
                if (rights == radioButton2.Text)
                    radioButton2.Checked = true;
                if (rights == radioButton3.Text)
                    radioButton3.Checked = true;
                if (rights == radioButton4.Text)
                    radioButton4.Checked = true;



            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string getpassword;
            if (e.RowIndex > -1)
            {
                string rights;
                groupBox2.Visible = true;
                Brigade.Visible = true;
                getpassword = this.dataGridView1[1, e.RowIndex].Value.ToString();
                this.txtPassword.Text = getpassword;
                txtUserName.Text = this.dataGridView1[0, e.RowIndex].Value.ToString();
                rights = this.dataGridView1[2, e.RowIndex].Value.ToString();
                if (rights == radioButton1.Text)  //Administrator
                {
                    radioButton1.Checked = true;
                    label4.Visible = false;
                    cmbBrigade.Visible = false;
                    Brigade.Visible = false;


                    label5.Visible = false;
                    cmbUnit1.Visible = false;

                    label6.Visible = false;
                    cmbCoy.Visible = false;
                }
                if (rights == radioButton2.Text) //Brigade User
                {
                    radioButton2.Checked = true;
                    getBrigadeName(int.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString()));
                    label4.Visible = true;
                    cmbBrigade.Visible = true;

                    label5.Visible = false;
                    cmbUnit1.Visible = false;

                    label6.Visible = false;
                    cmbCoy.Visible = false;
                }
                if (rights == radioButton3.Text) //Unit User
                {
                    radioButton3.Checked = true;
                    getBrigadeName(int.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString()));
                    getUnitName(int.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString()), int.Parse(this.dataGridView1[4, e.RowIndex].Value.ToString()));
                    label4.Visible = true;
                    cmbBrigade.Visible = true;

                    label5.Visible = true;
                    cmbUnit1.Visible = true;

                    label6.Visible = false;
                    cmbCoy.Visible = false;
                }
                if (rights == radioButton4.Text)  // Company User
                {
                    getBrigadeName(int.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString()));
                    getUnitName(int.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString()), int.Parse(this.dataGridView1[4, e.RowIndex].Value.ToString()));

                    radioButton4.Checked = true;
                    label4.Visible = true;
                    cmbBrigade.Visible = true;
                    label5.Visible = true;
                    cmbUnit1.Visible = true;
                    label6.Visible = true;
                    cmbCoy.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "")
            {
                var ans = MessageBox.Show("Are you sure you want to delete this record", "Delete Record", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    try
                    {
                        var dataset = ConnectData.insert_info.sp_DeleteUser(txtUserName.Text, this.txtPassword.Text);
                        LoadUsertoDataGrid();
                        groupBox2.Visible = false;
                        MessageBox.Show("Record successfully deleted", "Record Delete");
                        // } // end of  using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                    }// end of try

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error as occurred");
                    }
                }
            }

        }
    }
}
