namespace MunicipalServicesApp
{
    partial class ReportIssuesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.pbReportingProgress = new System.Windows.Forms.ProgressBar();
            this.lblEngagementMessage = new System.Windows.Forms.Label();
            this.btnAttachMedia = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(24, 9);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 16);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Address:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(24, 28);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(520, 22);
            this.txtLocation.TabIndex = 0;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(24, 55);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(66, 16);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(24, 74);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(520, 24);
            this.cmbCategory.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(24, 107);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 16);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Description:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(24, 126);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(520, 180);
            this.rtbDescription.TabIndex = 2;
            this.rtbDescription.Text = "";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(24, 315);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 16);
            this.lblFileName.TabIndex = 3;
            // 
            // pbReportingProgress
            // 
            this.pbReportingProgress.Location = new System.Drawing.Point(24, 335);
            this.pbReportingProgress.Name = "pbReportingProgress";
            this.pbReportingProgress.Size = new System.Drawing.Size(520, 23);
            this.pbReportingProgress.TabIndex = 4;
            this.pbReportingProgress.Maximum = 100;
            this.pbReportingProgress.Value = 0;
            // 
            // lblEngagementMessage
            // 
            this.lblEngagementMessage.AutoSize = true;
            this.lblEngagementMessage.Location = new System.Drawing.Point(24, 365);
            this.lblEngagementMessage.Name = "lblEngagementMessage";
            this.lblEngagementMessage.Size = new System.Drawing.Size(296, 16);
            this.lblEngagementMessage.TabIndex = 5;
            this.lblEngagementMessage.Text = "Please fill out fields to notify your ward.";
            // 
            // btnAttachMedia
            // 
            this.btnAttachMedia.Location = new System.Drawing.Point(218, 400);
            this.btnAttachMedia.Name = "btnAttachMedia";
            this.btnAttachMedia.Size = new System.Drawing.Size(140, 30);
            this.btnAttachMedia.TabIndex = 6;
            this.btnAttachMedia.Text = "Attach Image / Document";
            this.btnAttachMedia.UseVisualStyleBackColor = true;
            this.btnAttachMedia.Click += new System.EventHandler(this.btnAttachMedia_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(218, 445);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(140, 30);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit Report";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.Location = new System.Drawing.Point(218, 481);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(140, 30);
            this.btnBackToMenu.TabIndex = 8;
            this.btnBackToMenu.Text = "Back to Menu";
            this.btnBackToMenu.UseVisualStyleBackColor = true;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // ReportIssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 520);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnAttachMedia);
            this.Controls.Add(this.lblEngagementMessage);
            this.Controls.Add(this.pbReportingProgress);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtLocation);
            this.Name = "ReportIssuesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report an Issue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.ProgressBar pbReportingProgress;
        private System.Windows.Forms.Label lblEngagementMessage;
        private System.Windows.Forms.Button btnAttachMedia;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBackToMenu;
    }
}