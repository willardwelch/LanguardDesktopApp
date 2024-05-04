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
    public partial class DeleteOrder : Form
    {
        public DeleteOrder()
        {
            InitializeComponent();
        }

        private void DeleteOrder_Load(object sender, EventArgs e)
        {
            LoadOrder();

        }
        private void LoadOrder()
        {
            cmbOrder.ValueMember = "ID";
            cmbOrder.DisplayMember = "ordersName";

            var dataset = ConnectData.insert_info.sp_selectOrdersType();
            cmbOrder.DataSource = dataset;


        }// end LoadOrder()

        private void DeleteOrders()
        {
            if (cmbOrder.Text == "")
            {
                ConnectData.message = "Please Select a order to delete";
                ConnectData.title = "Order Missing";
                MessageBox.Show(ConnectData.message, ConnectData.title);
            }
           else
            {
                int Entryid = (int)cmbOrder.SelectedValue;
                var ans = MessageBox.Show("Are you sure you want to delete this record", "Delete Record", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    try
                    {
                        /*  using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                          {
                              using (SqlCommand cmd = new SqlCommand("sp_DeleteOrderType", con))
                              {
                                  cmd.CommandType = CommandType.StoredProcedure;
                                  cmd.Parameters.Add("@orderId", SqlDbType.Int).Value = Entryid;
                                  var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                                  returnParameter.Direction = ParameterDirection.ReturnValue;
                                  con.Open();
                                  cmd.ExecuteNonQuery();
                                  int returnValue = (int)returnParameter.Value;
                                  con.Close();
                                  if (returnValue > 0)
                                  {
                                      ConnectData.message = "Record successfully deleted!";
                                      ConnectData.title = "Record deleted";
                                      LoadOrder();
                                      MessageBox.Show(ConnectData.message, ConnectData.title);

                                  }// end if (returnValue > 0)

                              }// end of   using (SqlCommand cmd = new SqlCommand("sp_UpdateOrderType", con))

                          }// end  using (SqlConnection con = new SqlConnection(ConnectData.connectionString))
                          */

                                 var dataset = ConnectData.insert_info.sp_DeleteOrderType(Entryid);
                                if (dataset > 0)
                                {
                                    ConnectData.message = "Record successfully deleted!";
                                    ConnectData.title = "Record deleted";
                                    LoadOrder();
                                    MessageBox.Show(ConnectData.message, ConnectData.title);

                                }// end if (returnValue > 0)

                    }// end try

                    catch (Exception mes)
                    {
                        MessageBox.Show(mes.Message, "An error as occurred");
                    }

                }// end  if (ans == DialogResult.Yes)
            }//end else
        }// end DeleteOrders()

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteOrders();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }// end of class DeleteOrder

}//end namespace ReportingSystem
