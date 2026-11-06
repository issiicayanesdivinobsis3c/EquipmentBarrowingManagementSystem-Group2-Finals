namespace EquipmentBarrowingManagementSystem
{
    partial class BorrowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowForm));
            this.lblEquipment = new System.Windows.Forms.Label();
            this.cmbEquipment = new System.Windows.Forms.ComboBox();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblBorrowedBy = new System.Windows.Forms.Label();
            this.txtBorrowedBy = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblBorrowDate = new System.Windows.Forms.Label();
            this.dtBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEquipment
            // 
            this.lblEquipment.AutoSize = true;
            this.lblEquipment.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipment.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEquipment.Location = new System.Drawing.Point(20, 20);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(67, 14);
            this.lblEquipment.TabIndex = 0;
            this.lblEquipment.Text = "Equipment:";
            // 
            // cmbEquipment
            // 
            this.cmbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipment.FormattingEnabled = true;
            this.cmbEquipment.Location = new System.Drawing.Point(120, 20);
            this.cmbEquipment.Name = "cmbEquipment";
            this.cmbEquipment.Size = new System.Drawing.Size(250, 21);
            this.cmbEquipment.TabIndex = 1;
            this.cmbEquipment.SelectedIndexChanged += new System.EventHandler(this.cmbEquipment_SelectedIndexChanged);
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailable.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAvailable.Location = new System.Drawing.Point(20, 55);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(67, 14);
            this.lblAvailable.TabIndex = 2;
            this.lblAvailable.Text = "Available: 0";
            // 
            // lblBorrowedBy
            // 
            this.lblBorrowedBy.AutoSize = true;
            this.lblBorrowedBy.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowedBy.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBorrowedBy.Location = new System.Drawing.Point(20, 95);
            this.lblBorrowedBy.Name = "lblBorrowedBy";
            this.lblBorrowedBy.Size = new System.Drawing.Size(77, 14);
            this.lblBorrowedBy.TabIndex = 3;
            this.lblBorrowedBy.Text = "Borrowed By:";
            // 
            // txtBorrowedBy
            // 
            this.txtBorrowedBy.Location = new System.Drawing.Point(120, 95);
            this.txtBorrowedBy.Name = "txtBorrowedBy";
            this.txtBorrowedBy.Size = new System.Drawing.Size(250, 20);
            this.txtBorrowedBy.TabIndex = 4;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.SystemColors.Control;
            this.lblQuantity.Location = new System.Drawing.Point(20, 135);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(55, 14);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(120, 135);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(250, 20);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBorrowDate
            // 
            this.lblBorrowDate.AutoSize = true;
            this.lblBorrowDate.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowDate.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBorrowDate.Location = new System.Drawing.Point(20, 175);
            this.lblBorrowDate.Name = "lblBorrowDate";
            this.lblBorrowDate.Size = new System.Drawing.Size(75, 14);
            this.lblBorrowDate.TabIndex = 7;
            this.lblBorrowDate.Text = "Borrow Date:";
            // 
            // dtBorrowDate
            // 
            this.dtBorrowDate.Location = new System.Drawing.Point(120, 175);
            this.dtBorrowDate.Name = "dtBorrowDate";
            this.dtBorrowDate.Size = new System.Drawing.Size(250, 20);
            this.dtBorrowDate.TabIndex = 8;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrow.Location = new System.Drawing.Point(120, 215);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(75, 23);
            this.btnBorrow.TabIndex = 9;
            this.btnBorrow.Text = "Borrow";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(295, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BorrowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.dtBorrowDate);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtBorrowedBy);
            this.Controls.Add(this.lblBorrowedBy);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.cmbEquipment);
            this.Controls.Add(this.lblEquipment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BorrowForm";
            this.Text = "Barrow Form";
            this.Load += new System.EventHandler(this.BorrowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblEquipment;
        private System.Windows.Forms.ComboBox cmbEquipment;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblBorrowedBy;
        private System.Windows.Forms.TextBox txtBorrowedBy;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.DateTimePicker dtBorrowDate;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnCancel;
    }
}
