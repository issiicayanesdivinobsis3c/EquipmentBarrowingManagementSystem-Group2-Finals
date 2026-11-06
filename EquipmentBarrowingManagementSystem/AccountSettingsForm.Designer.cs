namespace EquipmentBarrowingManagementSystem
{
    partial class AccountSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountSettingsForm));
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.grpChangePassword = new System.Windows.Forms.GroupBox();
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.grpChangeUsername = new System.Windows.Forms.GroupBox();
            this.lblNewUsername = new System.Windows.Forms.Label();
            this.txtNewUsername = new System.Windows.Forms.TextBox();
            this.btnChangeUsername = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpChangePassword.SuspendLayout();
            this.grpChangeUsername.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCurrentUser.Location = new System.Drawing.Point(20, 15);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(113, 19);
            this.lblCurrentUser.TabIndex = 8;
            this.lblCurrentUser.Text = "Current User:";
            // 
            // grpChangePassword
            // 
            this.grpChangePassword.Controls.Add(this.lblCurrentPassword);
            this.grpChangePassword.Controls.Add(this.txtCurrentPassword);
            this.grpChangePassword.Controls.Add(this.lblNewPassword);
            this.grpChangePassword.Controls.Add(this.txtNewPassword);
            this.grpChangePassword.Controls.Add(this.lblConfirmPassword);
            this.grpChangePassword.Controls.Add(this.txtConfirmPassword);
            this.grpChangePassword.Controls.Add(this.btnChangePassword);
            this.grpChangePassword.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChangePassword.ForeColor = System.Drawing.SystemColors.Control;
            this.grpChangePassword.Location = new System.Drawing.Point(20, 50);
            this.grpChangePassword.Name = "grpChangePassword";
            this.grpChangePassword.Size = new System.Drawing.Size(400, 200);
            this.grpChangePassword.TabIndex = 1;
            this.grpChangePassword.TabStop = false;
            this.grpChangePassword.Text = "Change Password";
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPassword.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCurrentPassword.Location = new System.Drawing.Point(10, 25);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(102, 14);
            this.lblCurrentPassword.TabIndex = 0;
            this.lblCurrentPassword.Text = "Current Password:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(130, 25);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(250, 21);
            this.txtCurrentPassword.TabIndex = 1;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNewPassword.Location = new System.Drawing.Point(10, 60);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(87, 14);
            this.lblNewPassword.TabIndex = 2;
            this.lblNewPassword.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(130, 60);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(250, 21);
            this.txtNewPassword.TabIndex = 2;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.SystemColors.Control;
            this.lblConfirmPassword.Location = new System.Drawing.Point(10, 95);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(105, 14);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(130, 95);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(250, 21);
            this.txtConfirmPassword.TabIndex = 3;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.ForestGreen;
            this.btnChangePassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangePassword.Location = new System.Drawing.Point(130, 130);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(100, 23);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // grpChangeUsername
            // 
            this.grpChangeUsername.Controls.Add(this.lblNewUsername);
            this.grpChangeUsername.Controls.Add(this.txtNewUsername);
            this.grpChangeUsername.Controls.Add(this.btnChangeUsername);
            this.grpChangeUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChangeUsername.ForeColor = System.Drawing.SystemColors.Control;
            this.grpChangeUsername.Location = new System.Drawing.Point(20, 270);
            this.grpChangeUsername.Name = "grpChangeUsername";
            this.grpChangeUsername.Size = new System.Drawing.Size(400, 120);
            this.grpChangeUsername.TabIndex = 2;
            this.grpChangeUsername.TabStop = false;
            this.grpChangeUsername.Text = "Change Username";
            this.grpChangeUsername.Enter += new System.EventHandler(this.grpChangeUsername_Enter);
            // 
            // lblNewUsername
            // 
            this.lblNewUsername.AutoSize = true;
            this.lblNewUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewUsername.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNewUsername.Location = new System.Drawing.Point(10, 30);
            this.lblNewUsername.Name = "lblNewUsername";
            this.lblNewUsername.Size = new System.Drawing.Size(89, 14);
            this.lblNewUsername.TabIndex = 0;
            this.lblNewUsername.Text = "New Username:";
            // 
            // txtNewUsername
            // 
            this.txtNewUsername.Location = new System.Drawing.Point(130, 30);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(250, 21);
            this.txtNewUsername.TabIndex = 5;
            // 
            // btnChangeUsername
            // 
            this.btnChangeUsername.BackColor = System.Drawing.Color.ForestGreen;
            this.btnChangeUsername.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangeUsername.Location = new System.Drawing.Point(130, 65);
            this.btnChangeUsername.Name = "btnChangeUsername";
            this.btnChangeUsername.Size = new System.Drawing.Size(100, 23);
            this.btnChangeUsername.TabIndex = 6;
            this.btnChangeUsername.Text = "Change Username";
            this.btnChangeUsername.UseVisualStyleBackColor = false;
            this.btnChangeUsername.Click += new System.EventHandler(this.btnChangeUsername_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(345, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AccountSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(440, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpChangeUsername);
            this.Controls.Add(this.grpChangePassword);
            this.Controls.Add(this.lblCurrentUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccountSettingsForm";
            this.Text = "Account Settings";
            this.Load += new System.EventHandler(this.AccountSettingsForm_Load);
            this.grpChangePassword.ResumeLayout(false);
            this.grpChangePassword.PerformLayout();
            this.grpChangeUsername.ResumeLayout(false);
            this.grpChangeUsername.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.GroupBox grpChangePassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.GroupBox grpChangeUsername;
        private System.Windows.Forms.Label lblNewUsername;
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.Button btnChangeUsername;
        private System.Windows.Forms.Button btnCancel;
    }
}
