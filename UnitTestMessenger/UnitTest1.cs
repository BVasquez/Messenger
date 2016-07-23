using System;
using Messenger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMessenger
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Array

            //Act
            string val1 = "Hola";

            //Assert
            Assert.AreEqual("Hola ", Helper.SetEmotionIcon(val1));
        }
    }
}
