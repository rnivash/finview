using finview.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finview.Entities.Model;
using finview.DataAccess.Contracts;
using System.Transactions;
using finview.Entities.ViewModel;

namespace finview.Business
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;

        private IFileImportRepository _fileImportRepository;

        public TransactionService(ITransactionRepository transactionRepository,
            IFileImportRepository fileImportRepository)
        {
            _transactionRepository = transactionRepository;
            _fileImportRepository = fileImportRepository;
        }

        public List<Transactions> GetTransaction()
        {
            return _transactionRepository.GetTransaction();
        }

        public void UpdateTransactionCategory(Transactions trans)
        {
            var tran = _transactionRepository.GetTransaction(trans.TransactionDate,
                        trans.ChequeNumer,
                        trans.ClosingBalance);

            if (tran != null)
            {
                tran.TransCategory = trans.TransCategory;
                tran.CategoryId = tran.TransCategory.Id;
                _transactionRepository.SaveTransactions(tran);
            }
        }

        public void ImportTransaction(string fileName)
        {
            using(TransactionScope tr = new TransactionScope())
            {

                var importTrack = _fileImportRepository.InitiateImport();

                var listTrans = _fileImportRepository.ReadTransactions(fileName, importTrack);

                foreach (var item in listTrans)
                {
                    var tran = _transactionRepository.GetTransaction(item.TransactionDate, 
                        item.ChequeNumer, 
                        item.ClosingBalance);

                    if(tran == null)
                    {
                        _transactionRepository.SaveTransactions(item);
                    }
                }

                _fileImportRepository.SaveFileUploadTrack(importTrack);

                tr.Complete();
            }
            
        }

        public ReportModel GetReport(DateTime reportDate)
        {
            var result = new ReportModel();
            var rr = GetReportForDateRange(reportDate);
            result.Expense = GetExepenses(rr);
            result.Income = GetIncome(rr);
            return result;
        }

        public ReportModel GetReport()
        {
            var result = new ReportModel();
            var rr = GetReportForDateRange(DateTime.Now);
            result.Expense = GetExepenses(rr);
            result.Income = GetIncome(rr);
            return result;

        }

        public List<Transactions> GetReportForDateRange(DateTime reportDate)
        {
            var fromdate = new DateTime(reportDate.Year, reportDate.Month,1);
            var enddate = new DateTime(reportDate.Year, reportDate.Month, DateTime.DaysInMonth(reportDate.Year, reportDate.Month));
           // DateTime fromDate = reportDate.Date.
            return _transactionRepository.GetTransaction(fromdate, enddate);
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

        public List<Transactions> GetTransaction(DateTime reportDate)
        {
            var fromdate = new DateTime(reportDate.Year, reportDate.Month, 1);
            var enddate = new DateTime(reportDate.Year, reportDate.Month, DateTime.DaysInMonth(reportDate.Year, reportDate.Month));
            // DateTime fromDate = reportDate.Date.
            return _transactionRepository.GetTransaction(fromdate, enddate);
        }
    }
}
