using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace finview.DataAccess.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TransactionRepository tr = new TransactionRepository();
            var result = tr.GetTransaction();
            Assert.IsNotNull(result);
        }


        public static void Main(string[] aaa)
        {
           
        }
    }
}
