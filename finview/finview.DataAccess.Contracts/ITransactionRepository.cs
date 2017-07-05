using finview.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finview.DataAccess.Contracts
{
    public interface ITransactionRepository
    {
        List<Transactions> GetTransaction();

        void SaveTransactions(List<Transactions> listTransaction);

        List<Transactions> GetTransaction(DateTime fromDate, DateTime toDate);
    }
}
