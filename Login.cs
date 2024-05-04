using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace ReportingSystem
{
    public partial class Login : Form
    {
          public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                ConnectData.message = "Please enter user name to login";
                ConnectData.title = "Missing User Name";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if (txtPassword.Text == "")
            {
                ConnectData.message = "Please enter password";
                ConnectData.title = " Password is Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtPassword.Focus();
            }
            else
            {
                //   int BrigadeId = (int)cmbBrigade1.SelectedValue;
                /*   

                 using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                 {
                     using (SqlCommand cmd = new SqlCommand("sp_selectUserLogin", con))
                     {
                         cmd.CommandType = CommandType.StoredProcedure;

                         cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUserName.Text;
                         cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text;

                         var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                         returnParameter.Direction = ParameterDirection.ReturnValue;
                         con.Open();
                         cmd.ExecuteNonQuery();
                         int returnValue = (int)returnParameter.Value;
                         con.Close();
                         if (returnValue < 1)
                         {
                             ConnectData.message = "User entered is invalid";
                             ConnectData.title = "Password or user is invalid";
                             MessageBox.Show(ConnectData.message, ConnectData.title);

                         }

                         else
                         {
                             ConnectData.UserName = txtUserName.Text;
                             MenuWindow f2 = new MenuWindow(this);
                             f2.Show();
                             this.Hide();
                         }
                     }
                 }
                 */
                    var dataset = ConnectData.insert_info.sp_selectUserLogin(txtUserName.Text, txtPassword.Text).First();
                    if (dataset < 1)
                    {
                        ConnectData.message = "User entered is invalid";
                        ConnectData.title = "Password or user is invalid";
                        MessageBox.Show(ConnectData.message, ConnectData.title);

                    }

                    else
                    {
                        ConnectData.UserName = txtUserName.Text;
                        MenuWindow f2 = new MenuWindow(this);
                        f2.Show();
                        this.Hide();
                    }


            }


        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
