using System;

namespace Tubes_Kelompok_3.Library
{
    public static class PasswordValidator
    {
        public static bool Validate(
            string mode,
            string password)
        {
            // PRECONDITION
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception(
                    "Password tidak boleh kosong");
            }

            if (password.Length < 4)
            {
                throw new Exception(
                    "Password minimal 4 karakter");
            }

            // CORE LOGIC

            bool result =

                (mode == "GAMBAR" &&
                 password == "gambar123")

                ||

                (mode == "KATA" &&
                 password == "kata123")

                ||

                (mode == "COCOK" &&
                 password == "cocok123");

            // POSTCONDITION

            if (result == true &&
                password.Length < 4)
            {
                throw new Exception(
                    "Postcondition gagal");
            }

            return result;
        }
    }
}