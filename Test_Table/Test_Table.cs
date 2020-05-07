using Microsoft.VisualStudio.TestTools.UnitTesting;
using Table;
using System;
using System.Windows;
using System.Diagnostics;

namespace Test_Table
{
    [TestClass]
    public class Test_Table
    {

        [DataRow("123", true)]
        [DataRow("abc", false)]
        [DataRow("2020-05-01", false)]
        [DataRow("", false)]
        public void InputCheckInt(string s, bool n)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Arrange
            var expected = n;

            // Act
            LibraryBD library = new LibraryBD();
            var actual = library.InputCheckInt(s);

            // Assert
            Assert.AreEqual(expected, actual);

            stopWatch.Stop();
        }

        [DataRow("123", false)]
        [DataRow("abc", true)]
        [DataRow("2020-05-01", false)]
        [DataRow("", false)]
        public void InputCheckString(string s, bool n)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Arrange
            var expected = n;

            // Act
            LibraryBD library = new LibraryBD();
            var actual = library.InputCheckString(s);

            // Assert
            Assert.AreEqual(expected, actual);

            stopWatch.Stop();
        }

        [DataRow("123", false)]
        [DataRow("abc", false)]
        [DataRow("2020-05-01", true)]
        [DataRow("", false)]
        public void InputCheckDate(string s, bool n)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Arrange
            var expected = n;

            // Act
            LibraryBD library = new LibraryBD();
            var actual = library.InputCheckDate(s);

            // Assert
            Assert.AreEqual(expected, actual);

            stopWatch.Stop();
        }


    }
}
