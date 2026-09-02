using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            this.Resize += MainMenuForm_Resize;
            CenterControls();
        }

        private void CenterControls()
        {
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            lblTitle.Top = 40;

            int centerX = (this.ClientSize.Width - btnReportIssues.Width) / 2;
            int centerY = (this.ClientSize.Height - 180) / 2;

            btnReportIssues.Left = centerX;
            btnReportIssues.Top = centerY;

            btnEvents.Left = centerX;
            btnEvents.Top = centerY + 60;

            btnStatus.Left = centerX;
            btnStatus.Top = centerY + 120;
        }

        private void MainMenuForm_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportForm = new ReportIssuesForm();
            reportForm.ShowDialog();
        }

    }
}
