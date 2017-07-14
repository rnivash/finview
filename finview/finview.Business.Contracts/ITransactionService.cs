using finview.Entities.Model;
using finview.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finview.Business.Contracts
{
    public interface ITransactionService
    {
        List<Transactions> GetTransaction();

        void ImportTransaction(string fileName);

        ReportModel GetReport();

        ReportModel GetReport(DateTime reportDate);

        void UpdateTransactionCategory(Transactions trans);
    }
}
