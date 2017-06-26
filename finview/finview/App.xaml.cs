using finview.Business.Contracts;
using finview.Entities.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using finview.Business.Boot;

namespace finview
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            FinviewBusinessInit.Init();

            base.OnStartup(e);

            MainWindow mw = new MainWindow(FinviewContainer.Instance.Resolve<ITransactionService>());
            mw.Show();
        }
        
    }
}
