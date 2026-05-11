using System;
using System.Linq;

namespace AuthLibrary
{
    public class ValidasiInput
    {
        //Validasi Inputan Kosong
        public static bool IsEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        //Validasi Password Minimal 6 Karakter
        public static bool IsPasswordValid(string password)
        {
            return password.Length >= 6;
        }

        //Validasi Username Minimal 5 Karakter
        public static bool IsUsernameValid(string username)
        {
            return username.Length >= 5;
        }

        //Validasi Nama Hanya Huruf
        public static bool IsNameValid(string nama)
        {
            return nama.All(char.IsLetter);
        }
    }
}