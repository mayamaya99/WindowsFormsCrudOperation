using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = null;
            SqlConnection conn;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql = null;
            connectionString = @"Server=.\SQLEXPRESS; Database = Birds;Integrated Security=SSPI";
            conn = new SqlConnection(connectionString);
            sql = "Select* from Bird order by BirdID";
            try
            {


                conn.Open();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.CommandText = sql;
                adapter.SelectCommand.Connection = new SqlConnection();
                adapter.SelectCommand.Connection.ConnectionString = connectionString;
                adapter.Fill(ds);

                //Start of Insert Block
                adapter.InsertCommand = new SqlCommand();
                adapter.InsertCommand.CommandText = "INSERT into Bird" +
                    "(BirdID,Name,Description) " +
                    "VALUES (@BirdID,@Name,@Description)"; ;
                adapter.InsertCommand.Connection = new SqlConnection();
                adapter.InsertCommand.Connection.ConnectionString = connectionString;
                adapter.InsertCommand.Connection = new SqlConnection();
                adapter.InsertCommand.Parameters.Add("@BirdID", System.Data.SqlDbType.NVarChar, 40);
                adapter.InsertCommand.Parameters["@BirdID"].SourceColumn = "BirdID";
                adapter.InsertCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 40);
                adapter.InsertCommand.Parameters["@Name"].SourceColumn = "Name";
                adapter.InsertCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 24);
                adapter.InsertCommand.Parameters["@Description"].SourceColumn = "Description";

                //Start of Update Block
                adapter.UpdateCommand = new SqlCommand();
                adapter.UpdateCommand.CommandText = "Update Bird" +

                    "Set BirdID=@BirdID" +
                    "Name=@Name" +
                    "Description=@Description";
                adapter.UpdateCommand.Connection = new SqlConnection();
                adapter.UpdateCommand.Connection.ConnectionString = connectionString;
                adapter.UpdateCommand.Connection = new SqlConnection();
                adapter.UpdateCommand.Parameters.Add("@BirdID", System.Data.SqlDbType.NVarChar, 40);
                adapter.UpdateCommand.Parameters["@BirdID"].SourceColumn = "BirdID";
                adapter.UpdateCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 40);
                adapter.UpdateCommand.Parameters["@Name"].SourceColumn = "Name";
                adapter.UpdateCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 24);
                adapter.UpdateCommand.Parameters["@Description"].SourceColumn = "Description";
                adapter.UpdateCommand.Connection = adapter.InsertCommand.Connection;

                //Start of Delete Block
                adapter.DeleteCommand = new SqlCommand();
                adapter.DeleteCommand.CommandText = "Delete from Bird" +"Where  BirdID=@BirdID";
                adapter.DeleteCommand.Parameters.Add("@BirdID", System.Data.SqlDbType.NVarChar, 40);
                adapter.DeleteCommand.Parameters["@BirdID"].SourceColumn = "BirdID";
                adapter.DeleteCommand.Connection = adapter.InsertCommand.Connection;

                conn.Close();
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
