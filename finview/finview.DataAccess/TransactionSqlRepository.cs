using finview.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finview.Entities.Model;
using finview.DataAccess.Data;

namespace finview.DataAccess
{
    public class TransactionSqlRepository : ITransactionRepository
    {
        public List<Transactions> GetTransaction()
        {
            FinViewModel fvm = new FinViewModel();
            return fvm.Set<Transactions>().ToList();
        }

        public void SaveTransactions(List<Transactions> listTransaction)
        {
            using (FinViewModel fvm = new FinViewModel())
            {
                fvm.Transactions.AddOrUpdate(listTransaction.ToArray());
                fvm.SaveChanges();
            }
        }

        public void SaveTransactions(Transactions tran)
        {
            using (FinViewModel fvm = new FinViewModel())
            {
                fvm.Transactions.Add(tran);
                fvm.SaveChanges();
            }
        }

        public Transactions GetTransaction(params object[] keyValues)
        {
            Transactions res = null;
            using (FinViewModel fvm = new FinViewModel())
            {
                res = fvm.Transactions.Find(keyValues); 
            }
            return res;
        }

        public List<Transactions> GetTransaction(DateTime fromDate, DateTime toDate)
        {
            List<Transactions> res;
            using (FinViewModel fvm = new FinViewModel())
            {
                res = fvm.Set<Transactions>()
                    .Where(t => t.TransactionDate >= fromDate.Date && t.TransactionDate <= toDate.Date)
                    .ToList();
            }
            return res;
        }
    }
}
