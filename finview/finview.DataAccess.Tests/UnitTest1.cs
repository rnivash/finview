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
            TransactionSqlRepository tr = new TransactionSqlRepository();
            var result = tr.GetData();
            Assert.IsNotNull(result);
        }


        public static void Main(string[] aaa)
        {
            TransactionRepository tr = new TransactionRepository();
            tr.GetData();
        }
    }
}
