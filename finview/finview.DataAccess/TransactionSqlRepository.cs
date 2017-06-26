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
            FinViewModel fvm = new FinViewModel();
            fvm.Set<Transactions>().AddRange(listTransaction);
            fvm.SaveChanges();
        }
    }
}
