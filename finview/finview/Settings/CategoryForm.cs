using finview.Business.Contracts;
using finview.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finview.Settings
{
    public partial class CategoryForm : Form
    {
        public CategoryForm(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            InitializeComponent();

            dgvCategory.CellClick += DgvCategory_CellClick;
        }

        private async void DgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                var dgv = sender as DataGridView;
                if (dgv != null)
                {
                    var category = dgv.CurrentRow.DataBoundItem as Category;
                    if (category != null)
                    {
                        try
                        {
                            _categoryService.RemoveCategory(category);
                        }
                        catch
                        {

                        }
                        dgvCategory.DataSource = await Task.Factory.StartNew(() =>
                        {
                            return _categoryService.GetCategories();
                        });
                    }
                }
            }
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dgvCategory.AutoGenerateColumns = false;

            dgvCategory.DataSource = await Task.Factory.StartNew(() =>
            {
                return _categoryService.GetCategories();
            });           
        }

        private readonly ICategoryService _categoryService;


        private async void button1_Click(object sender, EventArgs e)
        {
            _categoryService.SaveCategory(new Category
            {
                CategoryName = txtCategoryName.Text
            });

            txtCategoryName.Text = string.Empty;

            dgvCategory.DataSource = await Task.Factory.StartNew(() =>
            {
                return _categoryService.GetCategories();
            });
        }
    }
}
