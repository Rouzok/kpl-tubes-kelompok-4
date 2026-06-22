using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Tubes_Kelompok_3.HalamanRegistrasiControl;

namespace Tubes_Kelompok_3
{
    internal class DatabaseSingleton
    {
        private static DatabaseSingleton _instance;
        private MySqlConnection _connection;

        private string connectionString =
            "server=localhost;database=tubes_kpl;uid=root;pwd=;";

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

        private string HashPasswordSHA256(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // ================= CORE FUNCTION =================
        public User Login(string username, string password)
        {
            try
            {
                OpenConnection();
                string hashedPassword = HashPasswordSHA256(password);
                string query =
                    @"SELECT id_user, username, firstname, lastname, role 
                      FROM users 
                      WHERE username = @username 
                      AND password = @password LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, _connection);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Ekstraksi nilai dengan penanganan null (Defensive Programming)
                        string dbUsername = reader.GetString("username");

                        string dbNamaDepan = reader.IsDBNull(reader.GetOrdinal("firstname"))
                            ? ""
                            : reader.GetString("firstname");

                        string dbNamaBelakang = reader.IsDBNull(reader.GetOrdinal("lastname"))
                            ? ""
                            : reader.GetString("lastname");

                        return new HalamanRegistrasiControl.User(dbNamaDepan, dbNamaBelakang, dbUsername);
                    }
                }

                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

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
                    "SELECT id_user FROM users WHERE username=@username LIMIT 1";

                MySqlCommand checkCmd =
                    new MySqlCommand(checkQuery, _connection);

                checkCmd.Parameters.AddWithValue("@username", username);

                int count =
                    Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    return false;
                }
                string hashedPassword = HashPasswordSHA256(password);
                string admin = "Admin";

                string insertQuery =
                    @"INSERT INTO users
                    (username,password,firstname,lastname,role,is_active,created_at)
                    VALUES
                    (@username,@password,@firstname,@lastname,@admin,1,NOW())";

                MySqlCommand insertCmd =
                    new MySqlCommand(insertQuery, _connection);

                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", hashedPassword);
                insertCmd.Parameters.AddWithValue("@firstname", firstname);
                insertCmd.Parameters.AddWithValue("@lastname", lastname);
                insertCmd.Parameters.AddWithValue("@admin", admin);

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
