namespace Project_Management.Views
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.tabProjects = new System.Windows.Forms.TabPage();
            this.tabAllIssues = new System.Windows.Forms.TabPage();
            this.tabForecast = new System.Windows.Forms.TabPage();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.toolTipProject = new System.Windows.Forms.ToolTip(this.components);
            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.materialTabControl1.Controls.Add(this.tabHome);
            this.materialTabControl1.Controls.Add(this.tabProjects);
            this.materialTabControl1.Controls.Add(this.tabAllIssues);
            this.materialTabControl1.Controls.Add(this.tabForecast);
            this.materialTabControl1.Controls.Add(this.tabReports);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(295, 607);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabHome
            // 
            this.tabHome.ImageKey = "home.png";
            this.tabHome.Location = new System.Drawing.Point(31, 4);
            this.tabHome.Name = "tabHome";
            this.tabHome.Size = new System.Drawing.Size(260, 599);
            this.tabHome.TabIndex = 4;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // tabProjects
            // 
            this.tabProjects.ImageKey = "projects.png";
            this.tabProjects.Location = new System.Drawing.Point(31, 4);
            this.tabProjects.Name = "tabProjects";
            this.tabProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabProjects.Size = new System.Drawing.Size(260, 599);
            this.tabProjects.TabIndex = 0;
            this.tabProjects.Text = "Projects";
            this.toolTipProject.SetToolTip(this.tabProjects, "Projects");
            this.tabProjects.UseVisualStyleBackColor = true;
            // 
            // tabAllIssues
            // 
            this.tabAllIssues.ImageKey = "tasks.png";
            this.tabAllIssues.Location = new System.Drawing.Point(31, 4);
            this.tabAllIssues.Name = "tabAllIssues";
            this.tabAllIssues.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllIssues.Size = new System.Drawing.Size(260, 599);
            this.tabAllIssues.TabIndex = 1;
            this.tabAllIssues.Text = "All Issues";
            this.tabAllIssues.UseVisualStyleBackColor = true;
            // 
            // tabForecast
            // 
            this.tabForecast.ImageKey = "calendar.png";
            this.tabForecast.Location = new System.Drawing.Point(31, 4);
            this.tabForecast.Name = "tabForecast";
            this.tabForecast.Size = new System.Drawing.Size(260, 599);
            this.tabForecast.TabIndex = 3;
            this.tabForecast.Text = "Forecast";
            this.tabForecast.UseVisualStyleBackColor = true;
            // 
            // tabReports
            // 
            this.tabReports.ImageKey = "reports.png";
            this.tabReports.Location = new System.Drawing.Point(31, 4);
            this.tabReports.Name = "tabReports";
            this.tabReports.Size = new System.Drawing.Size(260, 599);
            this.tabReports.TabIndex = 2;
            this.tabReports.Text = "Reports";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "calendar.png");
            this.imageList1.Images.SetKeyName(1, "export.png");
            this.imageList1.Images.SetKeyName(2, "projects.png");
            this.imageList1.Images.SetKeyName(3, "reports.png");
            this.imageList1.Images.SetKeyName(4, "settings.png");
            this.imageList1.Images.SetKeyName(5, "tasks.png");
            this.imageList1.Images.SetKeyName(6, "home.png");
            // 
            // tabSettings
            // 
            this.tabSettings.ImageIndex = 2;
            this.tabSettings.Location = new System.Drawing.Point(39, 4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(252, 599);
            this.tabSettings.TabIndex = 4;
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 674);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabProjects;
        private TabPage tabAllIssues;
        private TabPage tabForecast;
        private TabPage tabReports;
        private ImageList imageList1;
        private TabPage tabSettings;
        private ToolTip toolTipProject;
        private TabPage tabHome;
    }
}