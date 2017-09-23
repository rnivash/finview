using finview.Business.Contracts;
using finview.Entities.Unity;
using finview.Report;
using finview.Settings;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Forms;

namespace finview
{
    public partial class FinviewMdi : Form
    {

        private readonly ITransactionService _transactionService;

        public FinviewMdi()
        {
            InitializeComponent();

            _transactionService = FinviewContainer.Instance.Resolve<ITransactionService>();

            ShowMonthControls(false);
            LoadMdi();
        }

        private void LoadMdi()
        {
            Dashboard childForm = new Dashboard(FinviewContainer.Instance.Resolve<ITransactionService>() , FinviewContainer.Instance.Resolve<ICategoryService>());
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        public void ShowMonthControls(bool flag)
        {
            dpTransGrid.Visible = flag;
            ucNavigation.Visible = flag;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Dashboard childForm = new Dashboard(FinviewContainer.Instance.Resolve<ITransactionService>(), FinviewContainer.Instance.Resolve<ICategoryService>());
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
       
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports childForm = new Reports(FinviewContainer.Instance.Resolve<IReportService>());
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {
            Dashboard childForm = new Dashboard(FinviewContainer.Instance.Resolve<ITransactionService>(), FinviewContainer.Instance.Resolve<ICategoryService>());
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                Multiselect = false,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    _transactionService.ImportTransaction(filename);
                }
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm childForm = new CategoryForm(FinviewContainer.Instance.Resolve<ICategoryService>());
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
    }
}
