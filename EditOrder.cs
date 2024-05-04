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
    public partial class EditOrder : Form
    {
      
        public EditOrder()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbOrder.Text == "")
            {
                ConnectData.message = "Please Select a order to Edit";
                ConnectData.title = "Order Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
            else if (txtorder.Text == "")
            {
                ConnectData.message = "Please enter the new Order name to update to";
                ConnectData.title = "Order Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
                txtorder.Focus();
            }
            else
            {
                int Orderid = (int)cmbOrder.SelectedValue;
                /*

                using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateOrderType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@orderName", SqlDbType.VarChar).Value = txtorder.Text;
                        cmd.Parameters.Add("@orderId", SqlDbType.Int).Value = Entryid;
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
                            LoadOrder();
                            txtorder.Text = "";
                        }
                    }
                }
                */
                var dataset = ConnectData.insert_info.sp_UpdateOrderType(txtorder.Text, Orderid);
                if (dataset > 1)
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
                    LoadOrder();
                    txtorder.Text = "";
                }
            }
        }// end of button click

           private void LoadOrder()
           {
            
            cmbOrder.ValueMember = "ID";
            cmbOrder.DisplayMember = "ordersName";
           // cmbOrder.DataSource = ConnectData.LoadOrderClass();
            var dataset = ConnectData.insert_info.sp_selectOrdersType();
            cmbOrder.DataSource = dataset;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtorder.Text = cmbOrder.Text;
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            LoadOrder();
        }
    }
}
