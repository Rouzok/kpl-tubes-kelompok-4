using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_Kelompok_3
{
    internal class DatabaseSingleton
    {
        private static DatabaseSingleton _instance;
        private MySqlConnection _connection;

        private string connectionString =
            "server=localhost;database=game_db;uid=root;pwd=;";

        private DatabaseSingleton()
        {
            _connection = new MySqlConnection(connectionString);
        }

        public static DatabaseSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseSingleton();
            }

            return _instance;
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        private void OpenConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        // ================= LOGIN =================
        public bool Login(string username, string password)
        {
            try
            {
                OpenConnection();

                string query =
                    @"SELECT * FROM users
                      WHERE username = @username
                      AND password = @password";

                MySqlCommand cmd =
                    new MySqlCommand(query, _connection);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();

                bool success = reader.Read();

                reader.Close();
                return success;
            }
            finally
            {
                CloseConnection();
            }
        }

        // ================= REGISTER =================
        public bool Register(
            string username,
            string password,
            string firstname,
            string lastname)
        {
            try
            {
                OpenConnection();

                string checkQuery =
                    "SELECT COUNT(*) FROM users WHERE username=@username";

                MySqlCommand checkCmd =
                    new MySqlCommand(checkQuery, _connection);

                checkCmd.Parameters.AddWithValue("@username", username);

                int count =
                    Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    return false;
                }

                string insertQuery =
                    @"INSERT INTO users
                    (username,password,firstname,lastname,role_id,is_active,created_at)
                    VALUES
                    (@username,@password,@firstname,@lastname,2,1,NOW())";

                MySqlCommand insertCmd =
                    new MySqlCommand(insertQuery, _connection);

                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", password);
                insertCmd.Parameters.AddWithValue("@firstname", firstname);
                insertCmd.Parameters.AddWithValue("@lastname", lastname);

                insertCmd.ExecuteNonQuery();

                return true;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
