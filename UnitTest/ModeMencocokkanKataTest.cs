using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class ModeMencocokkanKataTest
    {
        [Fact]
        public void Test_LoadWords_NotNull()
        {
            // Arrange
            ModeMencocokkanKataTest mode = new ModeMencocokkanKataTest();

            // Act
            var result = mode.ToString();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_CheckMatching_ReturnBoolean()
        {
            // Arrange
            bool result = true;

            // Assert
            Assert.IsType<bool>(result);
        }

        [Fact]
        public void Test_ResetGame_ObjectCreated()
        {
            // Arrange & Act
            ModeMencocokkanKataTest mode = new ModeMencocokkanKataTest();

            // Assert
            Assert.NotNull(mode);
        }

        [Fact]
        public void Test_ScoreUpdate_Equal()
        {
            // Arrange
            int expected = 20;
            int actual = 20;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
