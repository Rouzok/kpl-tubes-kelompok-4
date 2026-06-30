using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_Kelompok_3.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }

        public string Username { get; set; }

        public User(
            int idUser,
            string namaDepan,
            string namaBelakang,
            string username)
        {
            IdUser = idUser;
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            Username = username;
        }
    }
}
