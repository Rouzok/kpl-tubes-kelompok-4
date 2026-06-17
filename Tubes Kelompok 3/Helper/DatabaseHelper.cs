using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Tubes_Kelompok_3.Helper
{
    public static class DatabaseHelper
    { 
        private static readonly string connectionString = "Server=127.0.0.1;Port=3306;Database=tubes_kpl;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // contoh pemanggilan query select from users
        // import
        //using MySql.Data.MySqlClient;
        //using Tubes_Kelompok_3.Helper;

        //try
        //    {
        //        string query = "SELECT id_user, firstname, lastname FROM users";

        //        using (MySqlConnection conn = DatabaseHelper.GetConnection())
        //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //        {
        //            conn.Open();

        //            using (MySqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    int id = reader.GetInt32("id_user");
        //                    string firstname = reader.GetString("firstname");
        //                    string lastname = reader.GetString("lastname");

        //                    Console.WriteLine($"ID: {id} | Firstname: {firstname} | Lastname: {lastname}");
        //                }
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Console.WriteLine($"[Database Error] Terjadi kegagalan akses data: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"[System Error] Terjadi kegagalan sistem: {ex.Message}");
        //    }
    }
}
