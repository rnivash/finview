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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace finview.Controls
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Interaction logic for ucMonthNavigation.xaml
    /// </summary>
    public partial class ucMonthNavigation : UserControl
    {

        public event ChangedEventHandler dateChanged;

        public DateTime ActiveDate { get; set; }

        public ucMonthNavigation()
        {
            InitializeComponent();

            if(ActiveDate == DateTime.MinValue)
            {
                ActiveDate = DateTime.Now;
            }

            SetLabel();
        }

        private void SetLabel()
        {
            lblActiveMonth.Content = ActiveDate.ToString("MMM yyyy");
        }

        private void btnforward_Click(object sender, RoutedEventArgs e)
        {
            ActiveDate = ActiveDate.AddMonths(1);
            SetLabel();

            if (dateChanged != null)
                dateChanged(this, e);
        }

        private void btnbackward_Click(object sender, RoutedEventArgs e)
        {
            ActiveDate = ActiveDate.AddMonths(-1);
            SetLabel();

            if (dateChanged != null)
                dateChanged(this, e);
        }
    }
}
