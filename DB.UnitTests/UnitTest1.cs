using System;
using Xunit;

namespace DB.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            const int someValue = 1;

            // Act
            var result = someValue * 2;

            // Assert
            Assert.Equal(2, result);
        }
    }
}