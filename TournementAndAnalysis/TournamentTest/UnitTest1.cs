using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TournementAndAnalysis;

namespace TournamentTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 myForm = new Form1();
            Assert.AreEqual(1, myForm.TestMethod());
        }
    }
}