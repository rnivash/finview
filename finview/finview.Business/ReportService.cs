using finview.Business.Contracts;
using finview.Entities.Model;
using finview.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finview.Business
{
    public class ReportService : IReportService
    {
        private readonly ITransactionService _transactionService;

        private readonly ICategoryService _categoryService;

        public ReportService(ITransactionService transactionService, ICategoryService categoryService)
        {
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        public ReportModel GetReport(DateTime reportDate)
        {
            var monthTrans = _transactionService.GetTransaction(reportDate);

            var Categories = _categoryService.GetCategories();

            var groupedTrans = monthTrans
                .GroupBy(g => g.CategoryId)
                .Select(gp => new
                {
                    Category = gp.First().CategoryId,
                    Amount = gp.Sum(a => a.WithdrawalAmount)
                }).Select(gp => new
                {
                    Category = gp.Category == null? 4: gp.Category,
                    Amount = gp.Amount
                }).ToList();

            var chartData = groupedTrans.Join(Categories, ok => ok.Category, ik => ik.Id, (r1, r2) => new
            {
                r1.Amount,
                r2.CategoryName

            }).ToDictionary(r => r.CategoryName, r => r.Amount.GetValueOrDefault());

            return new ReportModel()
            {
                Expense = GetExepenses(monthTrans),
                Income = GetIncome(monthTrans),
                CategoryTrans = chartData.ToList()
            };
        }

        public ReportModel GetReport()
        {
            return GetReport(DateTime.Now);
        }

        public decimal GetExepenses(List<Transactions> trans)
        {
            return trans.Where(t => t.WithdrawalAmount > 0)
                .Sum(w => w.WithdrawalAmount)
                .GetValueOrDefault();
        }

        public decimal GetIncome(List<Transactions> trans)
        {
            return trans.Where(t => t.DepositAmount > 0)
                .Sum(w => w.DepositAmount)
                .GetValueOrDefault();
        }
    }
}
