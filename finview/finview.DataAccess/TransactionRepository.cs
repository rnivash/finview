using finview.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using finview.Entities.Model;
using Cassandra.Data.Linq;

namespace finview.DataAccess
{
    public class TransactionRepository 
    {
        private static ISession _session;

        public IEnumerable<Transactions> GetData()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            

            _session = cluster.Connect("finview");

            
            var transactions = new Table<Transactions>(_session);

            IEnumerable<Transactions> adminUsers =
      (from user in transactions select user).Execute();

            //var selectCql = "SELECT * from finview.Transactions";
            ////Create a statement
            //var selectStatement = new SimpleStatement(selectCql);
            ////Add the parameters
            ////Execute the select statement
            //var rs = _session.Execute(selectStatement);

            //foreach (var row in rs)
            //{

            //    var tr = new Transactions();
            //    tr.ChequeNumer = row.GetValue<string>("chequenumer");
            //    tr.TransactionDate = row.GetValue<DateTime>("transactiondate");
            //    tr.WithdrawalAmount = row.GetValue<decimal>("withdrawalamount");
            //}

            //Transactions


            return adminUsers;
        }

        public List<Transactions> GetTransaction()
        {
            throw new NotImplementedException();
        }

        public List<Transactions> GetTransaction(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public void SaveTransactions(List<Transactions> listTransaction)
        {
            throw new NotImplementedException();
        }
    }
}
