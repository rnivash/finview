using finview.Business.Contracts;
using finview.Entities.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using finview.Settings;
using finview.Entities.Unity;
using Microsoft.Practices.Unity;

namespace finview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ITransactionService _transactionService;

        public MainWindow(ITransactionService transactionService)
        {
            _transactionService = transactionService;

            InitializeComponent();
            
            LoadTransactionGrid();
        }

        public void LoadTransactionGrid()
        {
            
            ObservableCollection<Transactions> TransactionsList = 
                new ObservableCollection<Transactions>(_transactionService.GetTransaction());
            
            dgTransaction.DataContext = TransactionsList;
            List<Category> cats = new List<Category>();
            cats.Add(new Category {
                Id = 100,
                CategoryName = "Citi food"
            });
            cats.Add(new Category
            {
                Id = 200,
                CategoryName = "Fuel"
            });
            Cato.ItemsSource = cats;
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadTransactionGrid();
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    _transactionService.ImportTransaction(filename);
                    //System.IO.Path.GetFileName(filename);
                }
            }
        }
       

        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            CategorySettings mw = new CategorySettings(FinviewContainer.Instance.Resolve<ICategoryService>());
            mw.Show();
        }
    }
}
