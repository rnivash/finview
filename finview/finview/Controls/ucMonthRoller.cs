using System;
using System.Windows.Forms;

namespace finview.Controls
{
    public partial class ucMonthRoller : UserControl
    {
        public ucMonthRoller()
        {
            InitializeComponent();

            if (ActiveDate == DateTime.MinValue)
            {
                ActiveDate = DateTime.Now;
            }

            SetLabel();
        }

        public event ChangedEventHandler dateChanged;

        public DateTime ActiveDate { get; set; }


        private void SetLabel()
        {
            lblActiveMonth.Text = ActiveDate.ToString("MMM yyyy");
        }

        public void SetActiveDate(DateTime activeDate)
        {
            ActiveDate = activeDate;
            SetLabel();
        }

        private void btnbackward_Click(object sender, EventArgs e)
        {
            ActiveDate = ActiveDate.AddMonths(-1);
            SetLabel();

            if (dateChanged != null)
                dateChanged(this, e);
        }

        private void btnforward_Click(object sender, EventArgs e)
        {
            ActiveDate = ActiveDate.AddMonths(1);
            SetLabel();

            if (dateChanged != null)
                dateChanged(this, e);

        }
    }
}
