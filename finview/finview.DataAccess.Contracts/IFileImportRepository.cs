using finview.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finview.DataAccess.Contracts
{
    public interface IFileImportRepository
    {
        List<Transactions> ReadTransactions(string fileName);
    }
}
