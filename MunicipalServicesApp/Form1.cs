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

            int buttonWidth = Math.Min(320, Math.Max(220, this.ClientSize.Width - 80));
            int buttonHeight = 42;
            int buttonSpacing = 16;
            int totalButtonHeight = (buttonHeight * 3) + (buttonSpacing * 2);
            int centerX = (this.ClientSize.Width - buttonWidth) / 2;
            int centerY = Math.Max(110, (this.ClientSize.Height - totalButtonHeight) / 2);

            btnReportIssues.Width = buttonWidth;
            btnReportIssues.Height = buttonHeight;
            btnReportIssues.Left = centerX;
            btnReportIssues.Top = centerY;

            btnEvents.Width = buttonWidth;
            btnEvents.Height = buttonHeight;
            btnEvents.Left = centerX;
            btnEvents.Top = centerY + buttonHeight + buttonSpacing;

            btnStatus.Width = buttonWidth;
            btnStatus.Height = buttonHeight;
            btnStatus.Left = centerX;
            btnStatus.Top = centerY + (buttonHeight + buttonSpacing) * 2;
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

        private void btnEvents_Click(object sender, EventArgs e)
        {
         
            LocalEventsForm eventsPage = new LocalEventsForm();

     
            eventsPage.FormClosed += (s, args) => this.Close();

        
            eventsPage.Show();

           
            this.Hide();
        }
    }
}
