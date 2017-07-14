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

        Transactions GetTransaction(params object[] keyValues);

        void SaveTransactions(List<Transactions> listTransaction);

        void SaveTransactions(Transactions tran);

        List<Transactions> GetTransaction(DateTime fromDate, DateTime toDate);
    }
}
