using finview.Entities.Model;
using finview.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finview.Business.Contracts
{
    public interface IReportService
    {
        ReportModel GetReport(DateTime reportDate);

        ReportModel GetReport();

        decimal GetExepenses(List<Transactions> trans);

        decimal GetIncome(List<Transactions> trans);
    }
}
