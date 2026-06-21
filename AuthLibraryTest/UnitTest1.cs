using AuthLibrary;
using Xunit;

namespace AuthLibraryTest
{
    public class UnitTest1
    {
        //Test Inputan Kosong
        [Fact]
        public void TestIsEmpty()
        {
            bool hasil = ValidasiInput.IsEmpty("");

            Assert.True(hasil);
        }

        //Test Password Valid
        [Fact]
        public void TestPasswordValid()
        {
            bool hasil = ValidasiInput.IsPasswordValid(
                "Admin123".ToCharArray());

            Assert.True(hasil);
        }

        //Test Username Valid
        [Fact]
        public void TestUsernameValid()
        {
            bool hasil = ValidasiInput.IsUsernameValid(
                "debby123");

            Assert.True(hasil);
        }

        //Test Nama Valid
        [Fact]
        public void TestNameValid()
        {
            bool hasil = ValidasiInput.IsNameValid(
                "Debby".ToCharArray());

            Assert.True(hasil);
        }
    }
}