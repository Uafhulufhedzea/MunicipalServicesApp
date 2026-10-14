using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        private TextBox txtSearchKeyword;
        private ComboBox cmbCategoryFilter;
        private DateTimePicker dtpDateFilter;
        private CheckBox chkEnableDateFilter;
        private Button btnSearch;
        private Button btnClear;
        private Button btnBackToMenu;
        private ListView lvwEventsDisplay;
        private ListView lvwRecommendationsDisplay;
        private Label lblSearchTitle;
        private Label lblRecommendationTitle;

        public LocalEventsForm()
        {
            InitializeCustomComponents();
            ConfigureDataBindings();
            TriggerInitialDisplay();
            this.SizeChanged += (s, e) => AdjustFormLayout();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Local Events & Announcements";
            this.Size = new Size(900, 650);
            this.MinimumSize = new Size(800, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            lblSearchTitle = new Label { Text = "Search Municipal Events", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.DarkSlateGray };
            lblRecommendationTitle = new Label { Text = "Recommended For You", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.DarkSlateGray };

            txtSearchKeyword = new TextBox { Font = new Font("Segoe UI", 10) };

            cmbCategoryFilter = new ComboBox { Font = new Font("Segoe UI", 10), DropDownStyle = ComboBoxStyle.DropDownList };

            dtpDateFilter = new DateTimePicker { Font = new Font("Segoe UI", 10), Format = DateTimePickerFormat.Short, Enabled = false };

            chkEnableDateFilter = new CheckBox { Text = "Filter by Date", Font = new Font("Segoe UI", 9), Checked = false };
            chkEnableDateFilter.CheckedChanged += (s, e) => dtpDateFilter.Enabled = chkEnableDateFilter.Checked;

            btnSearch = new Button { Text = "Search", Font = new Font("Segoe UI", 10, FontStyle.Bold), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSearch.Click += BtnSearch_Click;

            btnClear = new Button { Text = "Clear Filters", Font = new Font("Segoe UI", 10), BackColor = Color.LightGray, FlatStyle = FlatStyle.Flat };
            btnClear.Click += BtnClear_Click;

            btnBackToMenu = new Button { Text = "Back to Main Menu", Font = new Font("Segoe UI", 10), BackColor = Color.IndianRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnBackToMenu.Click += BtnBackToMenu_Click;

            lvwEventsDisplay = CreateStyledListView();
            lvwRecommendationsDisplay = CreateStyledListView();

            this.Controls.AddRange(new Control[] {
                lblSearchTitle, lblRecommendationTitle, txtSearchKeyword, cmbCategoryFilter,
                dtpDateFilter, chkEnableDateFilter, btnSearch, btnClear, btnBackToMenu,
                lvwEventsDisplay, lvwRecommendationsDisplay
            });

            AdjustFormLayout();
        }

        private ListView CreateStyledListView()
        {
            ListView lvw = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 9),
                BorderStyle = BorderStyle.FixedSingle
            };
            lvw.Columns.Add("Date", 100);
            lvw.Columns.Add("Category", 110);
            lvw.Columns.Add("Title", 200);
            lvw.Columns.Add("Description", 400);
            return lvw;
        }

        private void ConfigureDataBindings()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");

            foreach (var category in EventDataStore.UniqueCategories)
            {
                cmbCategoryFilter.Items.Add(category);
            }

            cmbCategoryFilter.SelectedIndex = 0;
        }

        private void TriggerInitialDisplay()
        {
            RenderEventsList(EventDataStore.QueryEvents("All Categories", null, ""));
            RenderRecommendationsList(EventDataStore.GetAlgorithmicRecommendations());
        }

        private void AdjustFormLayout()
        {
            int margin = 20;
            int controlWidth = (this.ClientSize.Width - (margin * 3)) / 2;

            lblSearchTitle.Location = new Point(margin, margin);
            lblSearchTitle.Size = new Size(controlWidth, 25);

            txtSearchKeyword.Location = new Point(margin, margin + 30);
            txtSearchKeyword.Size = new Size(controlWidth, 30);

            cmbCategoryFilter.Location = new Point(margin, margin + 65);
            cmbCategoryFilter.Size = new Size(controlWidth, 30);

            chkEnableDateFilter.Location = new Point(margin, margin + 105);
            chkEnableDateFilter.Size = new Size(110, 25);

            dtpDateFilter.Location = new Point(margin + 115, margin + 105);
            dtpDateFilter.Size = new Size(controlWidth - 115, 30);

            btnSearch.Location = new Point(margin, margin + 145);
            btnSearch.Size = new Size((controlWidth - 10) / 2, 35);

            btnClear.Location = new Point(margin + (controlWidth / 2) + 5, margin + 145);
            btnClear.Size = new Size((controlWidth - 10) / 2, 35);

            int listY = margin + 195;
            int listHeight = this.ClientSize.Height - listY - 70;

            lvwEventsDisplay.Location = new Point(margin, listY);
            lvwEventsDisplay.Size = new Size(controlWidth, listHeight);

            int rightColumnX = (margin * 2) + controlWidth;

            lblRecommendationTitle.Location = new Point(rightColumnX, margin);
            lblRecommendationTitle.Size = new Size(controlWidth, 25);

            lvwRecommendationsDisplay.Location = new Point(rightColumnX, margin + 30);
            lvwRecommendationsDisplay.Size = new Size(controlWidth, listHeight + 165);

            btnBackToMenu.Location = new Point(margin, this.ClientSize.Height - 50);
            btnBackToMenu.Size = new Size(180, 35);
        }

        private void RenderEventsList(List<EventAnnouncement> events)
        {
            lvwEventsDisplay.BeginUpdate();
            lvwEventsDisplay.Items.Clear();
            foreach (var ev in events)
            {
                ListViewItem item = new ListViewItem(ev.EventDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(ev.Category);
                item.SubItems.Add(ev.Title);
                item.SubItems.Add(ev.Description);
                lvwEventsDisplay.Items.Add(item);
            }
            lvwEventsDisplay.EndUpdate();
        }

        private void RenderRecommendationsList(List<EventAnnouncement> recommendations)
        {
            lvwRecommendationsDisplay.BeginUpdate();
            lvwRecommendationsDisplay.Items.Clear();
            foreach (var rec in recommendations)
            {
                ListViewItem item = new ListViewItem(rec.EventDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(rec.Category);
                item.SubItems.Add(rec.Title);
                item.SubItems.Add(rec.Description);
                lvwRecommendationsDisplay.Items.Add(item);
            }
            lvwRecommendationsDisplay.EndUpdate();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchKeyword.Text;
            string category = cmbCategoryFilter.SelectedItem?.ToString() ?? "All Categories";
            DateTime? selectedDate = chkEnableDateFilter.Checked ? (DateTime?)dtpDateFilter.Value : null;

            EventDataStore.RecordUserSearch(keyword, category, selectedDate);

            List<EventAnnouncement> searchResults = EventDataStore.QueryEvents(category, selectedDate, keyword);
            RenderEventsList(searchResults);

            List<EventAnnouncement> generalRecommendations = EventDataStore.GetAlgorithmicRecommendations();
            RenderRecommendationsList(generalRecommendations);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtSearchKeyword.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            chkEnableDateFilter.Checked = false;
            TriggerInitialDisplay();
        }

        private void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            MainMenuForm mainDashboard = (MainMenuForm)Application.OpenForms["MainMenuForm"] ?? new MainMenuForm();
            mainDashboard.Show();
            this.Hide();
        }
    }
}
