using System;
using Xunit;

using static HashSalt.Lib.HashSalter;

namespace HashSalt.Tests
{
    public class HashSaltTests
    {
        [Fact]
        public void EqualsTest()
        {
            // Arrange
            string salt = GetSalt(24);
            string tmp = GetHash("henk", salt);

            // Act
            bool expected = true;
            bool actual = ConfirmHash("henk", tmp, salt);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NotEqualsTest()
        {
            // Arrange
            string salt = GetSalt(24);
            string tmp = GetHash("henk", salt);

            // Act
            salt = "obviously not the right salt";
            bool expected = false;
            bool actual = ConfirmHash("henk", tmp, salt);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
