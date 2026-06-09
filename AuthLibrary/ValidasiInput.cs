using System;
using System.Linq;

namespace AuthLibrary
{
    public static class ValidasiInput
    {
        //Validasi Inputan Kosong
        public static bool IsEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

    //Validasi Password Minimal 6 Karakter dan Mengandung Huruf Besar dan Angka
    public static bool IsPasswordValid(char[] password)
        {
            bool adaHurufBesar = password.Any(char.IsUpper);
            bool adaAngka = password.Any(char.IsDigit);

            return password.Length >= 6 &&
                   adaHurufBesar &&
                   adaAngka;
        }

        //Validasi Username Minimal 5 Karakter dan Hanya Boleh Huruf atau Angka
        public static bool IsUsernameValid(string username)
        {
            return username.Length >= 5 &&
                   username.All(char.IsLetterOrDigit);
        }

        //Validasi Nama Hanya Huruf
        public static bool IsNameValid(char[] nama)
        {
            return nama.All(char.IsLetter);
        }
    }

}