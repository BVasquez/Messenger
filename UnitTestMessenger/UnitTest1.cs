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
            string val1 = ":-) :-x ";

            //Assert
            Assert.AreEqual("FelizMal", Helper.SetEmotionIcon(val1));
        }
    }
}
