using finview.Business.Boot;
using System.Windows;

namespace finview
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		
		public App():base() 
		{
			this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
		}

		private void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) 
		{
			string errorMessage = string.Format("An unhandled exception occurred: {0}", e.Exception.Message);
			MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			e.Handled = true;
		}
	
        protected override void OnStartup(StartupEventArgs e)
        {

            FinviewBusinessInit.Init();

            base.OnStartup(e);

            FinviewMdi nmw = new FinviewMdi();
            nmw.Show();
        }
        
    }
}
