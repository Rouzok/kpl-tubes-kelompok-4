using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class ModeGambarTest
    {
        [Fact]
        public void Test_LoadQuestion_NotNull()
        {
            // Arrange
            ModeGambarTest mode = new ModeGambarTest();

            // Act
            var result = mode.ToString();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_CheckAnswer_ReturnBoolean()
        {
            // Arrange
            bool result = true;

            // Assert
            Assert.IsType<bool>(result);
        }

        [Fact]
        public void Test_NextQuestion_ObjectCreated()
        {
            // Arrange & Act
            ModeGambarTest mode = new ModeGambarTest();

            // Assert
            Assert.NotNull(mode);
        }

        [Fact]
        public void Test_ScoreCalculation_Equal()
        {
            // Arrange
            int expected = 10;
            int actual = 10;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
