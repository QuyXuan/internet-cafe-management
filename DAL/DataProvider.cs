using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        private static string ConnectionString = Properties.Settings.Default.ConnectionString;
        private SqlConnection SQLConnection;
        private static DataProvider instance;
        private DataProvider(string strCon)
        {
            SQLConnection = new SqlConnection(strCon);
        }
        public static DataProvider Instance 
        { 
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider(ConnectionString);
                }
                return instance;
            }
            private set { instance = value; }
        }
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            SQLConnection.Open();
            SqlCommand Command = new SqlCommand(query, SQLConnection);
            if (parameters != null)
            {
                string[] listPara = query.Split(' ');
                int count = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        Command.Parameters.AddWithValue(item, parameters[count++]);
                    }
                }
            }
            SqlDataAdapter Adapter = new SqlDataAdapter(Command);
            Adapter.Fill(data);
            SQLConnection.Close();
            return data;
        }
        public bool ExecuteNonQuery(string query, object[] parameters = null)
        {
            int acceptedRows = 0;
            SQLConnection.Open();
            SqlCommand Command = new SqlCommand(query, SQLConnection);
            if (parameters != null)
            {
                string[] listPara = query.Split(' ');
                int count = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        Command.Parameters.AddWithValue(item, parameters[count++]);
                    }
                }
            }
            acceptedRows = Command.ExecuteNonQuery();
            SQLConnection.Close();
            return acceptedRows > 0;
        }
        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = null;
            SQLConnection.Open();
            SqlCommand Command = new SqlCommand(query, SQLConnection);
            if (parameters != null)
            {
                string[] listPara = query.Split(' ');
                int count = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        Command.Parameters.AddWithValue(item, parameters[count++]);
                    }
                }
            }
            data = Command.ExecuteScalar();
            SQLConnection.Close();
            return data;
        }
    }
}
