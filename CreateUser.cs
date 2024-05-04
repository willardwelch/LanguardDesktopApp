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
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;

namespace ReportingSystem
{
    public partial class CreateUser : Form
    {
         

         public CreateUser()
        {
            InitializeComponent();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reportingSystemDataSet.sp_selectBrigade' table. You can move, or remove it, as needed.
            this.sp_selectBrigadeTableAdapter.Fill(this.reportingSystemDataSet.sp_selectBrigade);

        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string connectionString = "Data Source=DESKTOP-GUFUJSB;Initial Catalog=ReportingSystem;Integrated Security=True;Trust Server Certificate=True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Brigade.Visible = true;
            this.Brigade.Enabled = true;
            label5.Visible = false;
            label6.Visible = false;
            this.cmbUnit1.Visible = false;
            this.cmbCoy.Visible = false;
            ConnectData.Userrights = radioButton2.Text;
            LoadBrigade();

        }



        private void LoadBrigade()
        {
            /*this.cmbBrigade.DataSource = ConnectData.LoadBrigadeRights();
            this.cmbBrigade.ValueMember = "ID";
            this.cmbBrigade.DisplayMember = "Brigade";*/
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

            LoadUnit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Brigade.Visible = false;
            ConnectData.Userrights = radioButton1.Text;
            LoadBrigade();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.Brigade.Visible = true;
            this.Brigade.Enabled = true;
            label5.Visible = true;
            label6.Visible = false;
            this.cmbUnit1.Visible = true;
            this.cmbUnit1.Enabled = true;
            this.cmbCoy.Visible = false;
            ConnectData.Userrights = radioButton3.Text;
            LoadBrigade();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.Brigade.Visible = true;
            this.Brigade.Enabled = true;
            label5.Visible = true;
            label6.Visible = true;
            this.cmbUnit1.Visible = true;
            this.cmbUnit1.Enabled = true;
            this.cmbCoy.Visible = true;
            this.cmbCoy.Enabled = true;
            ConnectData.Userrights = radioButton4.Text;
            LoadBrigade();
            //LoadCoy();



        }

        private void cmbBrigade_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUnit();
        }

        private void LoadUnit()
        {
           

           // SqlConnection connDb = new SqlConnection(ConnectData.connectionString);
           // connDb.Open();
            try
            {
                var brigades = this.cmbBrigade.SelectedValue;
                if (brigades != null)
                {
                        int BrigadeId = int.Parse(this.cmbBrigade.SelectedValue.ToString());
                    
                      //  this.cmbUnit1.DataSource = ConnectData.LoadUnitRights(BrigadeId);
                        
                       
                        if (ConnectData.createRights != "Administrator")
                                BrigadeId = ConnectData.bdeLevelAccess;
                        else
                            BrigadeId =  int.Parse(this.cmbBrigade.SelectedValue.ToString());

                        if (ConnectData.UnitLevelAccess > 0)
                        {
                            var dataset = ConnectData.insert_info.sp_selectUnitbyID(BrigadeId, ConnectData.UnitLevelAccess);
                                 this.cmbUnit1.DisplayMember = "Unit";
                                this.cmbUnit1.ValueMember = "ID";
                                this.cmbUnit1.DataSource = dataset;

                        }
                        else
                        {
                             this.cmbUnit1.Enabled = true;
                                 var dataset = ConnectData.insert_info.sp_selectUnit(BrigadeId);
                                this.cmbUnit1.DisplayMember = "Unit";
                                this.cmbUnit1.ValueMember = "ID";
                                this.cmbUnit1.DataSource = dataset;
                                  this.cmbUnit1.Enabled = true;
                        }

                } //end of  if (brigades != null)

            }// end of try
            catch(Exception)
            {
                  // code for error here
            }
        } // end of LoadUnit();
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                ConnectData.message = "Please enter user name";
                ConnectData.title = "User Name Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtUserName.Focus();

            }
            else if (ConnectData.Userrights=="")
            {
                ConnectData.message = "Please select user rights";
                ConnectData.title = "User's Right Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if ((ConnectData.Userrights=="Brigade") && (cmbBrigade.Text==""))
            {
                ConnectData.message = "Please select user brigade";
                ConnectData.title = "User's brigade Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if ((ConnectData.Userrights == "Unit") && (cmbBrigade.Text == ""))
            {
                ConnectData.message = "Please select user brigade";
                ConnectData.title = "User's brigade Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }

            else if ((ConnectData.Userrights == "Unit") && (cmbUnit1.Text == ""))
            {
                ConnectData.message = "Please select user's unit";
                ConnectData.title = "User's unit is Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if ((ConnectData.Userrights == "Company") && (cmbBrigade.Text == ""))
            {
                ConnectData.message = "Please select user's brigade";
                ConnectData.title = "User's brigade is Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if ((ConnectData.Userrights == "Company") && (cmbUnit1.Text == ""))
            {
                ConnectData.message = "Please select user's unit";
                ConnectData.title = "User's unit is Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if ((ConnectData.Userrights == "Company") && (cmbCoy.Text == ""))
            {
                ConnectData.message = "Please select user's company";
                ConnectData.title = "User's comnpany is Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if (txtPassword.Text == "")
            {
                ConnectData.message = "Please enter user's password";
                ConnectData.title = "User's password is Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if (txtConfirmPassword.Text == "")
            {
                ConnectData.message = "Please confirm passsword is missing";
                ConnectData.title = "confirm password is Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if ((txtPassword.Text != "")&& (txtConfirmPassword.Text != "") && (txtPassword.Text!=txtConfirmPassword.Text))
            {
                ConnectData.message = "Password does not match";
                ConnectData.title = "password not match";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }

            else
            {

                InsertUser();
            }
        }

        private void LoadCoy()
        {
            
            try 
            {
                int unitID = int.Parse(this.cmbUnit1.SelectedValue.ToString());
                int BdeID = int.Parse(this.cmbBrigade.SelectedValue.ToString());

                if (this.cmbUnit1.Text != null)
                {
                   var dataset = ConnectData.insert_info.sp_selectCoy( BdeID, unitID);
                    this.cmbCoy.ValueMember = "ID";
                    this.cmbCoy.DisplayMember = "CoyName";
                    this.cmbCoy.DataSource = dataset;
                }

                //connDb.Close();

            }// end try
            catch(Exception )
            {
               
            }

        }// end LoadCoy()




        private void cmbUnit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///if (cmbCoy.Visible == true)
              LoadCoy();
        }

        private void cmbCoy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void InsertUser()
        {
            
            ConnectData.createUserName = txtUserName.Text;
            ConnectData.message = "Record Saved Successfully";
            ConnectData.title = "Save";
          //  var insert_info = new WinformReportingSystemEntities();
            int final_value = 0;
           
            if (ConnectData.Userrights == "Administrator")
                    {
                      
                      var returnValue = ConnectData.insert_info.sp_InsertUser(ConnectData.createUserName, txtPassword.Text, ConnectData.Userrights,0,0,0);
                      final_value = returnValue;   

                    }

            if (ConnectData.Userrights == "Brigade")
                    {
                       var returnValue = ConnectData.insert_info.sp_InsertUser(ConnectData.createUserName, txtPassword.Text, ConnectData.Userrights, (int)this.cmbBrigade.SelectedValue, 0, 0);
                       final_value = returnValue;

            }

            if (ConnectData.Userrights == "Unit")
                    {
                 var returnValue = ConnectData.insert_info.sp_InsertUser(ConnectData.createUserName, txtPassword.Text, ConnectData.Userrights, (int)this.cmbBrigade.SelectedValue, (int)this.cmbUnit1.SelectedValue, 0);
                final_value = returnValue;

            }
            if (ConnectData.Userrights == "Company")
                    {
                  var returnValue = ConnectData.insert_info.sp_InsertUser(ConnectData.createUserName, txtPassword.Text, ConnectData.Userrights, (int)this.cmbBrigade.SelectedValue, (int)this.cmbUnit1.SelectedValue, (int)this.cmbCoy.SelectedValue);
                final_value = returnValue;
            }


            

                    if (final_value > 0)
                    {
                        ConnectData.message = "Record already exist!";
                        ConnectData.title = "Save Failed";
                        MessageBox.Show(ConnectData.message, ConnectData.title);

                    }

                    else
                    {
                        MessageBox.Show(ConnectData.message, ConnectData.title);
                        txtUserName.Text = "";
                    }
        }
           // }
       // }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
