using ReportingSystem;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

public class ConnectData
{
    public static Login log = new Login();
    public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DesktopReportingSystemEntities"].ConnectionString;
    public static DesktopReportingSystemEntities insert_info = new DesktopReportingSystemEntities();

    public static string message = "";
    public static string title = "";
    public static string UserName = "";
    public static string Userrights = "";
    public static string createUserName = "";
    public static string createRights = "";
    public static int bdeLevelAccess;
    public static int UnitLevelAccess;
    public static int coylevelAccess;
    public static Form formName;
    // public static int BdeLevel;
    public void MyData()
    {
    }

    public static DataTable LoadBrigade(Form frm)
    {
       
        SqlConnection connection_db = new SqlConnection(connectionString);
        connection_db.Open();

        // Check to see if connection is closed, to be safe, if closed then open
        if (connection_db.State == ConnectionState.Closed)
            connection_db.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("sp_selectBrigade", connection_db);
        sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable table = new DataTable();
        // Store data in table
        sqlData.Fill(table);
        connection_db.Close();
        // Close connection
        return table;

     }

    public static DataTable LoadBrigadeRights()
    {

        SqlConnection connection_db = new SqlConnection(connectionString);
        connection_db.Open();

        // Check to see if connection is closed, to be safe, if closed then open
        if (connection_db.State == ConnectionState.Closed)
            connection_db.Open();


        if (ConnectData.createRights == "Administrator")
        {
            SqlDataAdapter sqlData = new SqlDataAdapter("sp_selectBrigade", connection_db);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();
            // Store data in table
            sqlData.Fill(table);
            connection_db.Close();
            return table;

        }
        else
        {

            using (var command = new SqlCommand("sp_selectBrigadebyBde", connection_db)
            {
                // Set command type and add Parameters
                CommandType = CommandType.StoredProcedure,
                Parameters = { new SqlParameter("@BdeId", ConnectData.bdeLevelAccess) }
            })
            {
                // Execute command in Adapter and store to datatable
                
                var adapter = new SqlDataAdapter(command);
                DataTable de = new DataTable();
                adapter.Fill(de);
                connection_db.Close();
                return de;

            }
        }

    }// LoadBrigadeRights()


    public static DataTable LoadUnitRights(int bde)
    {

        SqlConnection connDb = new SqlConnection(ConnectData.connectionString);
        connDb.Open();
        int Bdeid;
        if (ConnectData.createRights != "Administrator")
            Bdeid = ConnectData.bdeLevelAccess;
        else
            Bdeid = bde;

            if (ConnectData.UnitLevelAccess > 0)
            {
                using (SqlCommand cmd = new SqlCommand("sp_selectUnitbyID", connDb))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BdeID", SqlDbType.Int).Value = Bdeid;
                    cmd.Parameters.Add("@UnitID", SqlDbType.Int).Value = ConnectData.UnitLevelAccess;
                    // Execute command in Adapter and store to datatable
                    var adapter = new SqlDataAdapter(cmd);
                    DataTable de = new DataTable();
                    adapter.Fill(de);
                    connDb.Close();
                    return de;

                }

            }
            else
            {

                using (var command = new SqlCommand("sp_selectUnit", connDb)
                {
                    // Set command type and add Parameters
                    CommandType = CommandType.StoredProcedure,
                    Parameters = { new SqlParameter("@BdeID", Bdeid) }
                })
                {
                    // Execute command in Adapter and store to datatable
                    var adapter = new SqlDataAdapter(command);

                    DataTable de = new DataTable();
                    adapter.Fill(de);
                    connDb.Close();
                    return de;
                }
            }
              
    }  // LoadUnitRights()



    public static DataTable LoadCoy(int unitid, int bdeId, string coy)
    {
        SqlConnection connDb = new SqlConnection(ConnectData.connectionString);
        connDb.Open();
        int unitID = unitid;
        int BdeID = bdeId;

            var command = new SqlCommand("sp_selectCoy", connDb);

            // Set command type and add Parameters
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@unitId", unitID);
            command.Parameters.AddWithValue("@BdeID", BdeID);

            // Execute command in Adapter and store to datatable
            var adapter = new SqlDataAdapter(command);
            DataTable de1 = new DataTable();
            adapter.Fill(de1);

        /* CmbCoy.DataSource = de1;
         CmbCoy.ValueMember = "ID";
         CmbCoy.DisplayMember = "CoyName";*/
            connDb.Close();
            return de1;

      
    }// end of LoadCoy()

    public static DataTable LoadEntryClass()
    {
        //string connectionString = "Data Source=DESKTOP-GUFUJSB;Initial Catalog=ReportingSystem;Integrated Security=True;Trust Server Certificate=True";

        SqlConnection connection_db = new SqlConnection(ConnectData.connectionString);
        connection_db.Open();

        // Check to see if connection is closed, to be safe, if closed then open
        if (connection_db.State == ConnectionState.Closed)
            connection_db.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("[sp_selectEntryName]", connection_db);
        sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataTable table = new DataTable();

        // Store data in table
        sqlData.Fill(table);

        connection_db.Close();
        return table;

        // Close connection
        
    }// end of LoadEntry Class()


    public static DataTable LoadOrderClass()
    {
        SqlConnection connection_db = new SqlConnection(ConnectData.connectionString);
        connection_db.Open();

        // Check to see if connection is closed, to be safe, if closed then open
        if (connection_db.State == ConnectionState.Closed)
            connection_db.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("sp_selectOrdersType", connection_db);
        sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataTable table = new DataTable();

        // Store data in table
        sqlData.Fill(table);
        connection_db.Close();
        return table;
    }// end LoadOrder()

    public static DataTable LoadRankClass()
    {
        SqlConnection connection_db = new SqlConnection(connectionString);
        connection_db.Open();

        // Check to see if connection is closed, to be safe, if closed then open
        if (connection_db.State == ConnectionState.Closed)
            connection_db.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("[sp_selectRank]", connection_db);
        sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataTable table = new DataTable();

        // Store data in table
        sqlData.Fill(table);

       // Close connection
        connection_db.Close();
        return table;
    }


}