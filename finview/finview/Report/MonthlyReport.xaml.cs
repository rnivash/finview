﻿using finview.Business.Contracts;
using finview.Controls;
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
        private IReportService _reportService;

        public MonthlyReport(IReportService reportService)
        {
            _reportService = reportService;

            InitializeComponent();

            LoadTransactionGrid();

            ucMonthNavigationctrl.dateChanged += UcMonthNavigationctrl_dateChanged;
        }

        private void UcMonthNavigationctrl_dateChanged(object sender, EventArgs e)
        {
            var ucMonthNavigationobj = sender as ucMonthNavigation;
            if(ucMonthNavigationobj != null)
            {
                var result = _reportService.GetReport(ucMonthNavigationobj.ActiveDate);
                lblexpense.Content = result.Expense;
                lblincome.Content = result.Income;
                pieChart.DataContext = result.CategoryTrans;
            }
        }

        public void LoadTransactionGrid()
        {

            var result = _reportService.GetReport();
            lblexpense.Content = result.Expense;
            lblincome.Content = result.Income;
            pieChart.DataContext = result.CategoryTrans;

        }

        private void dpreportdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            var result = _reportService.GetReport(dpreportdate.SelectedDate.GetValueOrDefault());
            lblexpense.Content = result.Expense;
            lblincome.Content = result.Income;
            pieChart.DataContext = result.CategoryTrans;
        }
    }
}
