﻿using finview.Business.Contracts;
using finview.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;

namespace finview.Report
{
    public partial class Reports : Form
    {

        private IReportService _reportService;

        private FinviewMdi MyMdi { get; set; }

        public Reports(IReportService reportService)
        {
            _reportService = reportService;
            InitializeComponent();
          
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            MyMdi = this.MdiParent as FinviewMdi;

            LoadTransactionGrid();

            MyMdi.dpTransGrid.Value = DateTime.Now;

            MyMdi.ucNavigation.dateChanged += UcMonthNavigationctrl_dateChanged;
        }

        private void UcMonthNavigationctrl_dateChanged(object sender, EventArgs e)
        {
            var ucMonthNavigationobj = sender as ucMonthRoller;
            if (ucMonthNavigationobj != null)
            {
                MyMdi.dpTransGrid.Value = ucMonthNavigationobj.ActiveDate;

                var result = _reportService.GetReport(ucMonthNavigationobj.ActiveDate);
                lblexpense.Text = result.Expense.ToString();
                lblincome.Text = result.Income.ToString();

                FillChart(result.CategoryTrans);
                
                
            }
        }

        private void FillChart(List<KeyValuePair<string, decimal>> CategoryTrans)
        {
            pieChart.Series["Series1"].Points.Clear();

            foreach (var item in CategoryTrans)
            {
                pieChart.Series["Series1"].Points.AddXY(item.Key, item.Value);
            }
            
        }

        public void LoadTransactionGrid()
        {

            var result = _reportService.GetReport();
            lblexpense.Text = result.Expense.ToString();
            lblincome.Text = result.Income.ToString();

            FillChart(result.CategoryTrans);

        }

        private void dpreportdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            var result = _reportService.GetReport(MyMdi.dpTransGrid.Value);
            lblexpense.Text = result.Expense.ToString();
            lblincome.Text = result.Income.ToString();

            FillChart(result.CategoryTrans);

            MyMdi.ucNavigation.SetActiveDate(MyMdi.dpTransGrid.Value);
        }
    }
}
