﻿using finview.Business.Contracts;
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
using finview.Report;
using finview.Entities.Unity;
using Microsoft.Practices.Unity;
using System.Collections.Specialized;

namespace finview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ITransactionService _transactionService;

        private readonly ICategoryService _categoryService;

        public MainWindow(ITransactionService transactionService, ICategoryService categoryService)
        {
            _transactionService = transactionService;

            _categoryService = categoryService;

            InitializeComponent();

            dpTransGrid.SelectedDate = DateTime.Now;

            LoadTransactionGrid();
        }

        public async void LoadTransactionGrid()
        {
            var dt = dpTransGrid.SelectedDate.GetValueOrDefault();

            Cato.ItemsSource = await Task.Factory.StartNew(() => {
                return _categoryService.GetCategories();
            });

            dgTransaction.DataContext = await Task.Factory.StartNew(() => {
                return _transactionService.GetTransaction(dt);
            });           

           
        }

        private void Cato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e != null)
            {
                var cbSource = e.Source as ComboBox;
                if(cbSource != null)
                {
                    var dgcParent = cbSource.Parent as DataGridCell;
                    if(dgcParent != null)
                    {
                        var dcTransaction = dgcParent.DataContext as Transactions;
                        if(dcTransaction != null)
                        {
                            dcTransaction.TransCategory = cbSource.SelectedItem as Category;
                            _transactionService.UpdateTransactionCategory(dcTransaction);
                        }
                    }
                }
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadTransactionGrid();
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    _transactionService.ImportTransaction(filename);
                }
            }
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            MonthlyReport mw = new MonthlyReport(FinviewContainer.Instance.Resolve<ITransactionService>());
            mw.Show();
        }
        
        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            CategorySettings mw = new CategorySettings(FinviewContainer.Instance.Resolve<ICategoryService>());
            mw.Show();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void dpTransGrid_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTransactionGrid();
        }
    }
}
