using finview.Business.Contracts;
using finview.Entities.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using finview.DataAccess.Boot;

namespace finview.Business.Boot
{
    public class FinviewBusinessInit 
    {
        public static void Init()
        {
            FinviewContainer.Instance
                .RegisterType<ITransactionService, TransactionService>();

            FinviewDataAccessInit.Init();
        }
    }
}
