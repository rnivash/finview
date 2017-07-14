using finview.Business.Contracts;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace finview.Report
{
    /// <summary>
    /// Interaction logic for MonthlyReport.xaml
    /// </summary>
    public partial class MonthlyReport : Window
    {
        private ITransactionService _transactionService;

        public MonthlyReport(ITransactionService transactionService)
        {
            _transactionService = transactionService;

            InitializeComponent();

            LoadTransactionGrid();
        }

        public void LoadTransactionGrid()
        {

            var result = _transactionService.GetReport();
            lblexpense.Content = result.Expense;
            lblincome.Content = result.Income;
        }

        private void dpreportdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            var result = _transactionService.GetReport(dpreportdate.SelectedDate.GetValueOrDefault());
            lblexpense.Content = result.Expense;
            lblincome.Content = result.Income;
        }
    }
}
