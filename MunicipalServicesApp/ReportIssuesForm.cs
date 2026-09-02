using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        private string attachedFilePath = "";

        public ReportIssuesForm()
        {
            InitializeComponent();
            SetupCategoryDropdown();
            AttachProgressTrackers();
            this.Resize += ReportIssuesForm_Resize;
            this.Load += ReportIssuesForm_Load;
        }

        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void ReportIssuesForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int padding = 24;
            int contentWidth = this.ClientSize.Width - (padding * 2);
            int buttonWidth = 120;
            int buttonHeight = 30;
            int buttonSpacing = 10;
            int totalButtonWidth = (buttonWidth * 3) + (buttonSpacing * 2);
            int centerX = (this.ClientSize.Width - totalButtonWidth) / 2;

            // Adjust input fields width
            txtLocation.Width = contentWidth;
            cmbCategory.Width = contentWidth;
            rtbDescription.Width = contentWidth;
            pbReportingProgress.Width = contentWidth;

            // Position buttons at the bottom center
            int bottomMargin = 20;
            int buttonsTopPosition = this.ClientSize.Height - buttonHeight - bottomMargin;

            btnAttachMedia.Left = centerX;
            btnAttachMedia.Top = buttonsTopPosition;
            btnAttachMedia.Width = buttonWidth;
            btnAttachMedia.Height = buttonHeight;

            btnSubmit.Left = centerX + buttonWidth + buttonSpacing;
            btnSubmit.Top = buttonsTopPosition;
            btnSubmit.Width = buttonWidth;
            btnSubmit.Height = buttonHeight;

            btnBackToMenu.Left = centerX + (buttonWidth + buttonSpacing) * 2;
            btnBackToMenu.Top = buttonsTopPosition;
            btnBackToMenu.Width = buttonWidth;
            btnBackToMenu.Height = buttonHeight;

            // Adjust rich text box height to make room for buttons
            rtbDescription.Height = Math.Max(100, buttonsTopPosition - rtbDescription.Top - 20);
        }


        private void SetupCategoryDropdown()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new string[] { "Sanitation & Leaks", "Roads & Potholes", "Utilities & Outages", "Refuse & Dumping" });
        }

        private void AttachProgressTrackers()
        {
            // Attach event handlers to track form completion
            // lblEngagementMessage is triggered whenever these events fire:
            // - User types in address field
            // - User selects a category
            // - User types in description field
            // It updates based on form completion score (0, 25, 50, 75, 100%)
            txtLocation.TextChanged += (s, e) => UpdateProgress();
            cmbCategory.SelectedIndexChanged += (s, e) => UpdateProgress();
            rtbDescription.TextChanged += (s, e) => UpdateProgress();
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            int score = 0;
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) score += 25;
            if (cmbCategory.SelectedIndex != -1) score += 25;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) score += 25;
            if (!string.IsNullOrWhiteSpace(attachedFilePath)) score += 25;

            pbReportingProgress.Value = score;

            if (score == 0) lblEngagementMessage.Text = "Please fill out fields to notify your ward.";
            else if (score < 75) lblEngagementMessage.Text = "Good start! Keep documenting the issue.";
            else if (score == 75) lblEngagementMessage.Text = "Almost complete! Adding a media file speeds up dispatch.";
            else lblEngagementMessage.Text = "Form verified! Ready for municipal submission.";
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images & Documents|*.jpg;*.jpeg;*.png;*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    attachedFilePath = ofd.FileName;
                    lblFileName.Text = Path.GetFileName(attachedFilePath);
                    UpdateProgress();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text) || cmbCategory.SelectedIndex == -1 || string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please complete all required input fields before final submission.",
                                "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IssueReport newIssue = new IssueReport
            {
                Location = txtLocation.Text,
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text,
                AttachedFilePath = attachedFilePath,
                DateReported = DateTime.Now
            };

            DataStore.MasterIssueList.Add(newIssue);

            MessageBox.Show("Report successfully dispatched and saved to our municipal tracking engine.",
                            "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Helper data structures moved to the bottom so the designer works perfectly
    public class IssueReport
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachedFilePath { get; set; }
        public DateTime DateReported { get; set; }
    }

    public static class DataStore
    {
        public static List<IssueReport> MasterIssueList = new List<IssueReport>();
    }
}
