using finview.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finview.Entities.Model;
using finview.DataAccess.Contracts;
using System.Transactions;

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

        public void ImportTransaction(string fileName)
        {
            using(TransactionScope tr = new TransactionScope())
            {

                var importTrack = _fileImportRepository.InitiateImport();

                var listTrans = _fileImportRepository.ReadTransactions(fileName, importTrack);

                _transactionRepository.SaveTransactions(listTrans);

                _fileImportRepository.SaveFileUploadTrack(importTrack);

                tr.Complete();
            }
            
        }
    }
}
