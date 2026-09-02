namespace MunicipalServicesApp
{
    partial class MainMenuForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnReportIssues = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(240, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 29);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Municipal Services Portal";
            // 
            // btnReportIssues
            // 
            this.btnReportIssues.Location = new System.Drawing.Point(310, 150);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new System.Drawing.Size(180, 45);
            this.btnReportIssues.TabIndex = 0;
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.UseVisualStyleBackColor = true;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);
            // 
            // btnEvents
            // 
            this.btnEvents.Enabled = false;
            this.btnEvents.Location = new System.Drawing.Point(310, 210);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(180, 45);
            this.btnEvents.TabIndex = 1;
            this.btnEvents.Text = "Local Events and Announcements\r\n(Coming Soon)";
            this.btnEvents.UseVisualStyleBackColor = true;
            // 
            // btnStatus
            // 
            this.btnStatus.Enabled = false;
            this.btnStatus.Location = new System.Drawing.Point(310, 270);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(180, 45);
            this.btnStatus.TabIndex = 2;
            this.btnStatus.Text = "Service Request Status\r\n(Coming Soon)";
            this.btnStatus.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnEvents);
            this.Controls.Add(this.btnReportIssues);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnStatus;
    }
}

