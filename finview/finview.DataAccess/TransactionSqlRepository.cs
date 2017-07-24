using finview.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finview.Entities.Model;
using finview.DataAccess.Data;
using System;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace finview.DataAccess
{
    public class TransactionSqlRepository : ITransactionRepository
    {
        public List<Transactions> GetTransaction()
        {
            List<Transactions> res;
            using (FinViewModel fvm = new FinViewModel())
            {
                res = fvm.Set<Transactions>()
                    .ToList();
            }
            return res;
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
                if(tran.posted_at == null)
                {
                    fvm.Transactions.Add(tran);
                }
                else
                {
                    if (fvm.Entry(tran).State == System.Data.Entity.EntityState.Detached)
                    {
                        fvm.Set<Transactions>().Attach(tran);
                        fvm.Entry(tran).State = System.Data.Entity.EntityState.Modified;
                    }
                }

                var ss = fvm.SaveChanges();
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
                    .OrderBy(o => o.TransactionDate)
                    .ToList();
            }
            return res;
        }
    }
}
