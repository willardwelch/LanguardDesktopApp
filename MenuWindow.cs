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
    public partial class MenuWindow : Form
    {
      
        public MenuWindow()
        {
            InitializeComponent();
           
            getLogonUserDetails();
            DisableMenuItem();
        }

        public MenuWindow(Form frm)
        {
            InitializeComponent();
            
            getLogonUserDetails();
            DisableMenuItem();
            ConnectData.formName = frm;
           

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateBrigade f2 = new CreateBrigade();
            f2.MdiParent = this;
            f2.Show();
           
        }

        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CreateUser f2 = new CreateUser();
            f2.MdiParent = this;
            f2.Show();
        }

        public void getLogonUserDetails()
        {
            //  SqlConnection connDb = new SqlConnection(ConnectData.connectionString);
            //  connDb.Open();
            this.cmbUnitName.ValueMember = "ID";
            this.cmbUnitName.DisplayMember = "Unit";


            var dataset = ConnectData.insert_info.sp_selectUserLoginDetail(ConnectData.UserName);
                this.cmbTxttRight.ValueMember = "Rights";
           this.cmbUnitName.DisplayMember = "Unit";
            this.cmbTxttRight.DataSource = dataset;
                ConnectData.createRights= cmbTxttRight.SelectedValue.ToString();

                //BrigadeLevel,UntLevel,CoyLevel
               
                cmbtxtBrigade.ValueMember = "BrigadeLevel";
            this.cmbtxtBrigade.DisplayMember = "BrigadeLevel";
            cmbtxtBrigade.DataSource = dataset;

            ConnectData.bdeLevelAccess = (int)cmbtxtBrigade.SelectedValue;

              
                cmbtxtUnit.ValueMember = "UntLevel";
               this.cmbtxtUnit.DisplayMember = "UntLevel";
                cmbtxtUnit.DataSource = dataset;
            ConnectData.UnitLevelAccess = (int)cmbtxtUnit.SelectedValue;

                 txtcmbCoy.ValueMember = "CoyLevel";
                txtcmbCoy.DisplayMember = "CoyLevel";
              txtcmbCoy.DataSource = dataset;

            ConnectData.coylevelAccess = (int)txtcmbCoy.SelectedValue;

           // }

           // connDb.Close();
        }

       
        private void MenuWindow_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome " + ConnectData.UserName;
            callLoadBrigade();

        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateUnit f2 = new CreateUnit();
            f2.MdiParent = this;
            f2.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Createcoy f2 = new Createcoy();
            f2.MdiParent = this;
            f2.Show();
        }

        private void addToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            CreateRank f2 = new CreateRank();
            f2.MdiParent = this;
            f2.Show();
        }

        private void addToolStripMenuItem5_Click(object sender, EventArgs e)
        {

            Orders f2 = new Orders();
            f2.MdiParent = this;
            f2.Show();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            Entry f2 = new Entry();
            f2.MdiParent = this;
            f2.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBrigade f2 = new EditBrigade();
            f2.MdiParent = this;
            f2.Show();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditUnit f2 = new EditUnit();
            f2.MdiParent = this;
            f2.Show();
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EditCoy f2=new EditCoy();
            f2.MdiParent = this;
            f2.Show();
        }

        private void editToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            EditEntry f2 = new EditEntry();
            f2.MdiParent = this;
            f2.Show();
        }

        private void editToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            EditOrder f2 = new EditOrder();
            f2.MdiParent = this;
            f2.Show();
        }

        private void editToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            EditRank f2 = new EditRank();
            f2.MdiParent = this;
            f2.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void DisableMenuItem()
        {
            if (ConnectData.createRights != "Administrator")
            {
               
                brigadeToolStripMenuItem.Visible = false;
                userToolStripMenuItem.Visible = false;
                ordersToolStripMenuItem.Visible = false;
                entryToolStripMenuItem.Visible = false;
                rankToolStripMenuItem.Visible = false;
                addToolStripMenuItem7.Visible = true;
                deleteToolStripMenuItem6.Visible = true;

                if (ConnectData.UnitLevelAccess > 0)
                {
                    unitToolStripMenuItem.Visible = false;
                }

                if (ConnectData.coylevelAccess > 0)
                {
                    coyToolStripMenuItem.Visible = false;
                    editToolStripMenuItem7.Visible = false;
                    deleteToolStripMenuItem6.Visible = false;
                    searchToolStripMenuItem.Visible = false;
                }
                panel1.Visible=true;
            }
            else
            {
                brigadeToolStripMenuItem.Visible = true;
                userToolStripMenuItem.Visible = true;
                ordersToolStripMenuItem.Visible = true;
                entryToolStripMenuItem.Visible = true;
                rankToolStripMenuItem.Visible = true;
                editToolStripMenuItem7.Visible = false;
                deleteToolStripMenuItem6.Visible = true;

            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            CreateSecurity f2 = new CreateSecurity();
            f2.MdiParent = this;
            f2.Show();
        }

        private void editToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            EditSecurityDetail f2 = new EditSecurityDetail();
            f2.MdiParent = this;
            f2.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecuriyInfoSearch f2 = new SecuriyInfoSearch();
            f2.MdiParent = this;
            f2.Show();
        }

        private void editToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            EditUser f2 = new EditUser();
            f2.MdiParent = this;
            f2.Show();
        }

        private void MenuWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectData.formName.Close();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBrigade f2 = new DeleteBrigade();
            f2.MdiParent = this;
            f2.Show();
        }

        private void deletdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUnit f2 = new DeleteUnit();
            f2.MdiParent = this;
            f2.Show();

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteCoy f2 = new DeleteCoy();
            f2.MdiParent = this;
            f2.Show();
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteEntry f2 = new DeleteEntry();
            f2.MdiParent = this;
            f2.Show();
        }

        private void deleteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DeleteOrder f2 = new DeleteOrder();
            f2.MdiParent = this;
            f2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void callLoadBrigade()
        {
            cmbgetuserbrigade.Visible = false;
            cmbUnitName.Visible = false;
            cmbgetcoyname.Visible = false;
           

            if (ConnectData.createRights != "Administrator") {
                var dataset = ConnectData.insert_info.sp_selectBrigade();
                this.cmbgetuserbrigade.ValueMember = "ID";
                this.cmbgetuserbrigade.DisplayMember = "Brigade";
                this.cmbgetuserbrigade.DataSource = dataset;

                cmbgetuserbrigade.Visible = true;
                
            }

            if (ConnectData.UnitLevelAccess > 0)
             {
                //   this.cmbUnitName.DataSource = ConnectData.sp_selectUnitbyID((int)this.cmbtxtBrigade.SelectedValue);
                    var dataset = ConnectData.insert_info.sp_selectUnit((int)this.cmbtxtBrigade.SelectedValue);

                    this.cmbUnitName.ValueMember = "ID";
                    this.cmbUnitName.DisplayMember = "Unit";
                    this.cmbUnitName.DataSource = dataset;
                    this.cmbUnitName.SelectedValue = ConnectData.UnitLevelAccess;
                     cmbUnitName.Visible = true;



            }

            if (ConnectData.coylevelAccess > 0)
            {
                var dataset = ConnectData.insert_info.sp_selectCoy(ConnectData.bdeLevelAccess, ConnectData.UnitLevelAccess);

                this.cmbgetcoyname.ValueMember = "ID";
                this.cmbgetcoyname.DisplayMember = "CoyName";
                this.cmbgetcoyname.DataSource = dataset;
                this.cmbgetcoyname.Visible = true;
                //cmbgetcoyname.Enabled = true;
                //this.cmbgetcoyname.SelectedText = txtcmbCoy.Text;
                /// this.cmbgetcoyname.SelectedValue = (int)ConnectData.coylevelAccess;
                editToolStripMenuItem7.Visible = false;
                deleteToolStripMenuItem6.Visible = false;
                searchToolStripMenuItem.Visible = false;


            }

        }

        private void deleteToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DeleteSecurity f2 = new DeleteSecurity();
            f2.MdiParent = this;
            f2.Show();
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DeleteUser f2 = new DeleteUser();
            f2.MdiParent = this;
            f2.Show();
        }
    }
}
