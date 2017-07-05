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
            List<Transactions> res;
            using (FinViewModel fvm = new FinViewModel())
            {
                res = fvm.Set<Transactions>().ToList();
            }
            return res;
        }

        public void SaveTransactions(List<Transactions> listTransaction)
        {
            using (FinViewModel fvm = new FinViewModel())
            {
                fvm.Set<Transactions>().AddRange(listTransaction);
                fvm.SaveChanges();
            }
           
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
