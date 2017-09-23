using finview.Business.Contracts;
using finview.Controls;
using finview.Entities.Model;
using finview.Entities.Unity;
using finview.Settings;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace finview
{
    public partial class Dashboard : Form
    {

        private readonly ITransactionService _transactionService;

        private readonly ICategoryService _categoryService;

        private FinviewMdi MyMdi { get; set; }   

        public Dashboard(ITransactionService transactionService, ICategoryService categoryService)
        {
            _transactionService = transactionService;

            _categoryService = categoryService;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            MyMdi = this.MdiParent as FinviewMdi;

            var cbcat = dgTransaction.Columns["cbCategory"] as System.Windows.Forms.DataGridViewComboBoxColumn;
            cbcat.DisplayMember = "CategoryName";
            cbcat.ValueMember = "Id";

            dgTransaction.CellEndEdit += DgTransaction_CellEndEdit;

            dgTransaction.AutoGenerateColumns = false;

            MyMdi.ShowMonthControls(true);

            MyMdi.dpTransGrid.Value = DateTime.Now;

            MyMdi.ucNavigation.dateChanged += UcNavigation_dateChanged;
            MyMdi.dpTransGrid.ValueChanged += DpTransGrid_ValueChanged;

            LoadTransactionGrid();
        }

        private void DpTransGrid_ValueChanged(object sender, EventArgs e)
        {
            LoadTransactionGrid();
            MyMdi.ucNavigation.SetActiveDate(MyMdi.dpTransGrid.Value);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            MyMdi.ShowMonthControls(false);
        }

        private void DgTransaction_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                var dgv = sender as DataGridView;
                if(dgv != null)
                {
                    var cbcat = dgv.CurrentRow.Cells["cbCategory"] as DataGridViewComboBoxCell;

                    var dcTransaction = dgv.CurrentRow.DataBoundItem as Transactions;
                    if (dcTransaction != null && cbcat != null)
                    {
                        dcTransaction.TransCategory = new Category { Id = (int)cbcat.Value };
                        _transactionService.UpdateTransactionCategory(dcTransaction);
                    }
                }

            }
        }

        private void UcNavigation_dateChanged(object sender, EventArgs e)
        {
            var ucMonthNavigationobj = sender as ucMonthRoller;
            if (ucMonthNavigationobj != null)
            {
                MyMdi.dpTransGrid.Value = ucMonthNavigationobj.ActiveDate;
                LoadTransactionGrid();
            }

        }

        public async void LoadTransactionGrid()
        {
            var dt = MyMdi.dpTransGrid.Value;

            var cbcat = dgTransaction.Columns["cbCategory"] as System.Windows.Forms.DataGridViewComboBoxColumn;

            if(cbcat != null)
            {
                cbcat.DataSource = await Task.Factory.StartNew(() =>
                {
                    return _categoryService.GetCategories();
                });
            }

            dgTransaction.DataSource = await Task.Factory.StartNew(() => {
                return _transactionService.GetTransaction(dt);
            });
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadTransactionGrid();
        }    

       
       
    }
}
