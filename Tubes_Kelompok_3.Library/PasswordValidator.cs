using System;
using System.Collections.Generic;

namespace Tubes_Kelompok_3.Library
{
    public static class PasswordValidator
    {
        public static bool Validate(
            GameMode mode,
            string password)
        {
            // PRECONDITION

            if (password == null)
            {
                throw new ArgumentNullException(
                    nameof(password),
                    "Password tidak boleh null");
            }

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

            // TABLE DRIVEN

            Dictionary<GameMode, string> validPassword =
                new Dictionary<GameMode, string>()
                {
                    { GameMode.GAMBAR, "gambar123" },
                    { GameMode.KATA, "kata123" },
                    { GameMode.COCOK, "cocok123" }
                };

            // CORE LOGIC

            bool result =
                validPassword.ContainsKey(mode)
                && validPassword[mode] == password;

            // POSTCONDITION

            if (result && password.Length < 4)
            {
                throw new Exception(
                    "Postcondition gagal");
            }

            return result;
        }
    }
}