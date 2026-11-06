namespace EquipmentBarrowingManagementSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEquipment = new System.Windows.Forms.TabPage();
            this.lblSearchEquipment = new System.Windows.Forms.Label();
            this.txtSearchEquipment = new System.Windows.Forms.TextBox();
            this.btnSearchEquipment = new System.Windows.Forms.Button();
            this.btnAddEquipment = new System.Windows.Forms.Button();
            this.btnEditEquipment = new System.Windows.Forms.Button();
            this.btnDeleteEquipment = new System.Windows.Forms.Button();
            this.lblTotalEquipment = new System.Windows.Forms.Label();
            this.dgvEquipment = new System.Windows.Forms.DataGridView();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.lblDashEquipmentCount = new System.Windows.Forms.Label();
            this.lblDashTotalQty = new System.Windows.Forms.Label();
            this.lblDashAvailableQty = new System.Windows.Forms.Label();
            this.lblDashBorrowedQty = new System.Windows.Forms.Label();
            this.lblDashBorrowRecords = new System.Windows.Forms.Label();
            this.lblDashReturnRecords = new System.Windows.Forms.Label();
            this.tabBorrowHistory = new System.Windows.Forms.TabPage();
            this.btnBorrowEquipment = new System.Windows.Forms.Button();
            this.btnReturnEquipment = new System.Windows.Forms.Button();
            this.dgvBorrowHistory = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAccountSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).BeginInit();
            this.tabDashboard.SuspendLayout();
            this.tabBorrowHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEquipment);
            this.tabControl1.Controls.Add(this.tabDashboard);
            this.tabControl1.Controls.Add(this.tabBorrowHistory);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(10, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 590);
            this.tabControl1.TabIndex = 0;
            // 
            // tabEquipment
            // 
            this.tabEquipment.Controls.Add(this.lblSearchEquipment);
            this.tabEquipment.Controls.Add(this.txtSearchEquipment);
            this.tabEquipment.Controls.Add(this.btnSearchEquipment);
            this.tabEquipment.Controls.Add(this.btnAddEquipment);
            this.tabEquipment.Controls.Add(this.btnEditEquipment);
            this.tabEquipment.Controls.Add(this.btnDeleteEquipment);
            this.tabEquipment.Controls.Add(this.lblTotalEquipment);
            this.tabEquipment.Controls.Add(this.dgvEquipment);
            this.tabEquipment.Location = new System.Drawing.Point(4, 23);
            this.tabEquipment.Name = "tabEquipment";
            this.tabEquipment.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabEquipment.Size = new System.Drawing.Size(952, 563);
            this.tabEquipment.TabIndex = 0;
            this.tabEquipment.Text = "Equipment Management";
            this.tabEquipment.UseVisualStyleBackColor = true;
            // 
            // lblSearchEquipment
            // 
            this.lblSearchEquipment.AutoSize = true;
            this.lblSearchEquipment.Location = new System.Drawing.Point(10, 15);
            this.lblSearchEquipment.Name = "lblSearchEquipment";
            this.lblSearchEquipment.Size = new System.Drawing.Size(44, 14);
            this.lblSearchEquipment.TabIndex = 0;
            this.lblSearchEquipment.Text = "Search:";
            // 
            // txtSearchEquipment
            // 
            this.txtSearchEquipment.Location = new System.Drawing.Point(60, 12);
            this.txtSearchEquipment.Name = "txtSearchEquipment";
            this.txtSearchEquipment.Size = new System.Drawing.Size(200, 21);
            this.txtSearchEquipment.TabIndex = 0;
            // 
            // btnSearchEquipment
            // 
            this.btnSearchEquipment.Location = new System.Drawing.Point(270, 12);
            this.btnSearchEquipment.Name = "btnSearchEquipment";
            this.btnSearchEquipment.Size = new System.Drawing.Size(75, 23);
            this.btnSearchEquipment.TabIndex = 1;
            this.btnSearchEquipment.Text = "Search";
            this.btnSearchEquipment.Click += new System.EventHandler(this.btnSearchEquipment_Click);
            // 
            // btnAddEquipment
            // 
            this.btnAddEquipment.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddEquipment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddEquipment.Location = new System.Drawing.Point(10, 450);
            this.btnAddEquipment.Name = "btnAddEquipment";
            this.btnAddEquipment.Size = new System.Drawing.Size(75, 23);
            this.btnAddEquipment.TabIndex = 3;
            this.btnAddEquipment.Text = "Add";
            this.btnAddEquipment.UseVisualStyleBackColor = false;
            this.btnAddEquipment.Click += new System.EventHandler(this.btnAddEquipment_Click);
            // 
            // btnEditEquipment
            // 
            this.btnEditEquipment.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditEquipment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditEquipment.Location = new System.Drawing.Point(100, 450);
            this.btnEditEquipment.Name = "btnEditEquipment";
            this.btnEditEquipment.Size = new System.Drawing.Size(75, 23);
            this.btnEditEquipment.TabIndex = 4;
            this.btnEditEquipment.Text = "Edit";
            this.btnEditEquipment.UseVisualStyleBackColor = false;
            this.btnEditEquipment.Click += new System.EventHandler(this.btnEditEquipment_Click);
            // 
            // btnDeleteEquipment
            // 
            this.btnDeleteEquipment.BackColor = System.Drawing.Color.DarkRed;
            this.btnDeleteEquipment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteEquipment.Location = new System.Drawing.Point(190, 450);
            this.btnDeleteEquipment.Name = "btnDeleteEquipment";
            this.btnDeleteEquipment.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteEquipment.TabIndex = 5;
            this.btnDeleteEquipment.Text = "Delete";
            this.btnDeleteEquipment.UseVisualStyleBackColor = false;
            this.btnDeleteEquipment.Click += new System.EventHandler(this.btnDeleteEquipment_Click);
            // 
            // lblTotalEquipment
            // 
            this.lblTotalEquipment.AutoSize = true;
            this.lblTotalEquipment.Location = new System.Drawing.Point(10, 530);
            this.lblTotalEquipment.Name = "lblTotalEquipment";
            this.lblTotalEquipment.Size = new System.Drawing.Size(105, 14);
            this.lblTotalEquipment.TabIndex = 6;
            this.lblTotalEquipment.Text = "Total Equipment: 0";
            // 
            // dgvEquipment
            // 
            this.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipment.Location = new System.Drawing.Point(10, 45);
            this.dgvEquipment.Name = "dgvEquipment";
            this.dgvEquipment.Size = new System.Drawing.Size(930, 400);
            this.dgvEquipment.TabIndex = 2;
            // 
            // tabDashboard
            // 
            this.tabDashboard.Controls.Add(this.lblDashEquipmentCount);
            this.tabDashboard.Controls.Add(this.lblDashTotalQty);
            this.tabDashboard.Controls.Add(this.lblDashAvailableQty);
            this.tabDashboard.Controls.Add(this.lblDashBorrowedQty);
            this.tabDashboard.Controls.Add(this.lblDashBorrowRecords);
            this.tabDashboard.Controls.Add(this.lblDashReturnRecords);
            this.tabDashboard.Location = new System.Drawing.Point(4, 23);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabDashboard.Size = new System.Drawing.Size(952, 563);
            this.tabDashboard.TabIndex = 1;
            this.tabDashboard.Text = "Dashboard";
            this.tabDashboard.UseVisualStyleBackColor = true;
            // 
            // lblDashEquipmentCount
            // 
            this.lblDashEquipmentCount.AutoSize = true;
            this.lblDashEquipmentCount.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashEquipmentCount.Location = new System.Drawing.Point(50, 50);
            this.lblDashEquipmentCount.Name = "lblDashEquipmentCount";
            this.lblDashEquipmentCount.Size = new System.Drawing.Size(246, 22);
            this.lblDashEquipmentCount.TabIndex = 0;
            this.lblDashEquipmentCount.Text = "Total Equipment Types: 0";
            // 
            // lblDashTotalQty
            // 
            this.lblDashTotalQty.AutoSize = true;
            this.lblDashTotalQty.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashTotalQty.Location = new System.Drawing.Point(50, 120);
            this.lblDashTotalQty.Name = "lblDashTotalQty";
            this.lblDashTotalQty.Size = new System.Drawing.Size(162, 22);
            this.lblDashTotalQty.TabIndex = 1;
            this.lblDashTotalQty.Text = "Total Quantity: 0";
            // 
            // lblDashAvailableQty
            // 
            this.lblDashAvailableQty.AutoSize = true;
            this.lblDashAvailableQty.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashAvailableQty.Location = new System.Drawing.Point(50, 190);
            this.lblDashAvailableQty.Name = "lblDashAvailableQty";
            this.lblDashAvailableQty.Size = new System.Drawing.Size(116, 22);
            this.lblDashAvailableQty.TabIndex = 2;
            this.lblDashAvailableQty.Text = "Available: 0";
            // 
            // lblDashBorrowedQty
            // 
            this.lblDashBorrowedQty.AutoSize = true;
            this.lblDashBorrowedQty.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashBorrowedQty.Location = new System.Drawing.Point(50, 260);
            this.lblDashBorrowedQty.Name = "lblDashBorrowedQty";
            this.lblDashBorrowedQty.Size = new System.Drawing.Size(217, 22);
            this.lblDashBorrowedQty.TabIndex = 3;
            this.lblDashBorrowedQty.Text = "Currently Borrowed: 0";
            // 
            // lblDashBorrowRecords
            // 
            this.lblDashBorrowRecords.AutoSize = true;
            this.lblDashBorrowRecords.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashBorrowRecords.Location = new System.Drawing.Point(50, 330);
            this.lblDashBorrowRecords.Name = "lblDashBorrowRecords";
            this.lblDashBorrowRecords.Size = new System.Drawing.Size(185, 22);
            this.lblDashBorrowRecords.TabIndex = 4;
            this.lblDashBorrowRecords.Text = "Borrow Records: 0";
            // 
            // lblDashReturnRecords
            // 
            this.lblDashReturnRecords.AutoSize = true;
            this.lblDashReturnRecords.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashReturnRecords.Location = new System.Drawing.Point(50, 400);
            this.lblDashReturnRecords.Name = "lblDashReturnRecords";
            this.lblDashReturnRecords.Size = new System.Drawing.Size(201, 22);
            this.lblDashReturnRecords.TabIndex = 5;
            this.lblDashReturnRecords.Text = "Returned Records: 0";
            // 
            // tabBorrowHistory
            // 
            this.tabBorrowHistory.Controls.Add(this.btnBorrowEquipment);
            this.tabBorrowHistory.Controls.Add(this.btnReturnEquipment);
            this.tabBorrowHistory.Controls.Add(this.dgvBorrowHistory);
            this.tabBorrowHistory.Location = new System.Drawing.Point(4, 23);
            this.tabBorrowHistory.Name = "tabBorrowHistory";
            this.tabBorrowHistory.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabBorrowHistory.Size = new System.Drawing.Size(952, 563);
            this.tabBorrowHistory.TabIndex = 2;
            this.tabBorrowHistory.Text = "Borrowing History";
            this.tabBorrowHistory.UseVisualStyleBackColor = true;
            // 
            // btnBorrowEquipment
            // 
            this.btnBorrowEquipment.BackColor = System.Drawing.Color.Goldenrod;
            this.btnBorrowEquipment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBorrowEquipment.Location = new System.Drawing.Point(10, 505);
            this.btnBorrowEquipment.Name = "btnBorrowEquipment";
            this.btnBorrowEquipment.Size = new System.Drawing.Size(100, 23);
            this.btnBorrowEquipment.TabIndex = 1;
            this.btnBorrowEquipment.Text = "Borrow Equipment";
            this.btnBorrowEquipment.UseVisualStyleBackColor = false;
            this.btnBorrowEquipment.Click += new System.EventHandler(this.btnBorrowEquipment_Click);
            // 
            // btnReturnEquipment
            // 
            this.btnReturnEquipment.BackColor = System.Drawing.Color.OliveDrab;
            this.btnReturnEquipment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReturnEquipment.Location = new System.Drawing.Point(120, 505);
            this.btnReturnEquipment.Name = "btnReturnEquipment";
            this.btnReturnEquipment.Size = new System.Drawing.Size(100, 23);
            this.btnReturnEquipment.TabIndex = 2;
            this.btnReturnEquipment.Text = "Return Equipment";
            this.btnReturnEquipment.UseVisualStyleBackColor = false;
            this.btnReturnEquipment.Click += new System.EventHandler(this.btnReturnEquipment_Click);
            // 
            // dgvBorrowHistory
            // 
            this.dgvBorrowHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowHistory.Location = new System.Drawing.Point(10, 45);
            this.dgvBorrowHistory.Name = "dgvBorrowHistory";
            this.dgvBorrowHistory.Size = new System.Drawing.Size(930, 450);
            this.dgvBorrowHistory.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(870, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAccountSettings
            // 
            this.btnAccountSettings.BackColor = System.Drawing.SystemColors.Control;
            this.btnAccountSettings.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountSettings.Location = new System.Drawing.Point(760, 15);
            this.btnAccountSettings.Name = "btnAccountSettings";
            this.btnAccountSettings.Size = new System.Drawing.Size(100, 23);
            this.btnAccountSettings.TabIndex = 2;
            this.btnAccountSettings.Text = "Account Settings";
            this.btnAccountSettings.UseVisualStyleBackColor = false;
            this.btnAccountSettings.Click += new System.EventHandler(this.btnAccountSettings_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(650, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 23);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAccountSettings);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Equipment Barrowing Management System Dashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabEquipment.ResumeLayout(false);
            this.tabEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).EndInit();
            this.tabDashboard.ResumeLayout(false);
            this.tabDashboard.PerformLayout();
            this.tabBorrowHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowHistory)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEquipment;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabBorrowHistory;
        private System.Windows.Forms.Label lblTotalEquipment;
        private System.Windows.Forms.DataGridView dgvEquipment;
        private System.Windows.Forms.Button btnAddEquipment;
        private System.Windows.Forms.Button btnEditEquipment;
        private System.Windows.Forms.Button btnDeleteEquipment;
        private System.Windows.Forms.TextBox txtSearchEquipment;
        private System.Windows.Forms.Button btnSearchEquipment;
        private System.Windows.Forms.Label lblSearchEquipment;
        private System.Windows.Forms.Label lblDashEquipmentCount;
        private System.Windows.Forms.Label lblDashTotalQty;
        private System.Windows.Forms.Label lblDashAvailableQty;
        private System.Windows.Forms.Label lblDashBorrowedQty;
        private System.Windows.Forms.Label lblDashBorrowRecords;
        private System.Windows.Forms.Label lblDashReturnRecords;
        private System.Windows.Forms.DataGridView dgvBorrowHistory;
        private System.Windows.Forms.Button btnBorrowEquipment;
        private System.Windows.Forms.Button btnReturnEquipment;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAccountSettings;
        private System.Windows.Forms.Button btnLogout;
    }
}

