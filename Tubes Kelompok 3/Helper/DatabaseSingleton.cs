using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tubes_Kelompok_3.Models;

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
                        int idUser= reader.GetInt32("id_user");

                        string dbUsername = reader.GetString("username");

                        string dbNamaDepan = reader.IsDBNull(reader.GetOrdinal("firstname"))
                            ? ""
                            : reader.GetString("firstname");

                        string dbNamaBelakang = reader.IsDBNull(reader.GetOrdinal("lastname"))
                            ? ""
                            : reader.GetString("lastname");

                        return new User(idUser, dbNamaDepan, dbNamaBelakang, dbUsername);
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
        public List<Level> GetLevels(string mode)
        {
            List<Level> levels = new List<Level>();

            try
            {
                OpenConnection();

                string query = @"
            SELECT
                id_level,
                nama_mode,
                level_number,
                total_skor,
                is_active
            FROM levels
            WHERE nama_mode = @mode
            ORDER BY level_number ASC";

                MySqlCommand cmd = new MySqlCommand(query, _connection);

                cmd.Parameters.AddWithValue("@mode", mode);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Level level = new Level();

                        level.IdLevel = reader.GetInt32("id_level");
                        level.NamaMode = reader.GetString("nama_mode");
                        level.LevelNumber = reader.GetInt32("level_number");
                        level.TotalSkor = reader.GetInt32("total_skor");
                        level.IsActive = reader.GetBoolean("is_active");

                        levels.Add(level);
                    }
                }

                return levels;
            }
            finally
            {
                CloseConnection();
            }
        }
        public SoalMemilihKata GetSoalMemilihKata(int levelId)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT judul_soal, opsi_benar, opsi_salah 
                         FROM soal_mode_memilih_kata 
                         WHERE level_id = @levelId LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@levelId", levelId);

                using (MySqlDataReader reader = cmd.ExecuteReader()){
                    if (reader.Read()){
                        return new SoalMemilihKata
                        {
                            JudulSoal = reader.GetString("judul_soal"),
                            OpsiBenar = reader.GetString("opsi_benar"),
                            OpsiSalah = reader.GetString("opsi_salah")
                        };
                    }
                }
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void SimpanSkorUser(int userId, int levelId, int skorPersentase)
        {
            try
            {
                OpenConnection();

                string query = @"INSERT INTO user_scores (user_id, level_id, skor_user, played_at) 
                         VALUES (@userId, @levelId, @skorUser, NOW())";

                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@levelId", levelId);
                cmd.Parameters.AddWithValue("@skorUser", skorPersentase);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Image> GetSoalModeGambar(int levelId)
        {
            List<Image> listSoal = new List<Image>();
            try
            {
                OpenConnection();
                string query = @"SELECT id_soal_gambar, path_gambar, kunci_jawaban 
                         FROM soal_mode_gambar 
                         WHERE level_id = @levelId";

                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@levelId", levelId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listSoal.Add(new Image
                        {
                            IdSoalGambar = reader.GetInt32("id_soal_gambar"),
                            PathGambar = reader.GetString("path_gambar"),
                            KunciJawaban = reader.GetString("kunci_jawaban")
                        });
                    }
                }
                return listSoal;
            }
            finally
            {
                CloseConnection();
            }
        }
        public MencocokkanKata GetSoalMencocokkanKata(int levelId)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT entitas_kiri, entitas_kanan 
                         FROM soal_mode_mencocokkan_kata 
                         WHERE level_id = @levelId LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@levelId", levelId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MencocokkanKata
                        {
                            EntitasKiri = reader.GetString("entitas_kiri"),
                            EntitasKanan = reader.GetString("entitas_kanan")
                        };
                    }
                }
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
