using finview.DataAccess.Contracts;
using finview.Entities.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace finview.DataAccess.Boot
{
    public class FinviewDataAccessInit
    {
        public static void Init()
        {
            FinviewContainer.Instance
                .RegisterType<ITransactionRepository, TransactionRepository>()
                .RegisterType<IFileImportRepository, FileImportRepository>()
                .RegisterType<ICategoryRepository, CategoryRepository>();
        }
    }
}
