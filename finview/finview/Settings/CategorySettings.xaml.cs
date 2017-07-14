using finview.Business.Contracts;
using finview.Entities.Model;
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

namespace finview.Settings
{
    /// <summary>
    /// Interaction logic for CategorySettings.xaml
    /// </summary>
    public partial class CategorySettings : Window
    {
        private readonly ICategoryService _categoryService;
        public CategorySettings(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _categoryService.SaveCategory(new Category {
                CategoryName = txtCategoryName.Text                
            });
        }
    }
}
