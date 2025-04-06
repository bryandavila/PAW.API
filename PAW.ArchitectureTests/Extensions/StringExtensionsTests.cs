using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAW.Architecture.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Architecture.Extensions.Tests
{
    [TestClass()]
    public class StringExtensionsTests
    {
        [TestMethod()]
        public void AddASaltTest()
        {
            // AAA 
            // Arrange
            var inQuestion = "QAB001";
            var value = "ASKDFOEIR(#)#$K456546GROKErg==";
            var target = $"ASKDFOEIR(#)#$K456546GROKErg{inQuestion}";

            // Act
            var expected = value.AddASalt();

            // Assert
            Assert.IsTrue(expected.Substring(expected.Length-6, 6) == inQuestion);
            Assert.IsFalse(target == value);
            Assert.AreEqual(expected, target);
        }
    }
}