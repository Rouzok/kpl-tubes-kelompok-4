using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tubes_Kelompok_3.Library;

namespace Tubes_Kelompok_3_Test
{
    [TestClass]
    public class PasswordValidatorTest
    {
        [TestMethod]
        public void Validate_GambarPassword_Benar()
        {
            bool result =
                PasswordValidator.Validate(
                    GameMode.GAMBAR,
                    "gambar123");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_KataPassword_Benar()
        {
            bool result =
                PasswordValidator.Validate(
                    GameMode.KATA,
                    "kata123");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_CocokPassword_Benar()
        {
            bool result =
                PasswordValidator.Validate(
                    GameMode.COCOK,
                    "cocok123");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_PasswordSalah()
        {
            bool result =
                PasswordValidator.Validate(
                    GameMode.GAMBAR,
                    "salah123");

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validate_PasswordKosong()
        {
            PasswordValidator.Validate(
                GameMode.GAMBAR,
                "");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validate_PasswordKurang4()
        {
            PasswordValidator.Validate(
                GameMode.GAMBAR,
                "123");
        }
    }
}