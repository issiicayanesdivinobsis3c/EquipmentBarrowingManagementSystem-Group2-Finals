using System;
using System.Windows.Forms;
using EquipmentBarrowingManagementSystem.DataAccess;

namespace EquipmentBarrowingManagementSystem
{
    public partial class AccountSettingsForm : Form
    {
        private string currentUsername;
        private AdminDAO adminDAO;

        public AccountSettingsForm(string username)
        {
            InitializeComponent();
            this.currentUsername = username;
            this.adminDAO = new AdminDAO();
        }

        private void AccountSettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = "Account Settings - " + currentUsername;
            lblCurrentUser.Text = "Current User: " + currentUsername;
            txtNewUsername.Text = currentUsername;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!ValidatePasswordChange())
                return;

            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            try
            {
                // Verify current password
                if (!adminDAO.AuthenticateAdmin(currentUsername, currentPassword))
                {
                    MessageBox.Show("Current password is incorrect.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCurrentPassword.Clear();
                    txtCurrentPassword.Focus();
                    return;
                }

                // Update password
                adminDAO.UpdateAdminPassword(currentUsername, newPassword);
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearPasswordFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            if (!ValidateUsernameChange())
                return;

            string newUsername = txtNewUsername.Text.Trim();

            if (newUsername == currentUsername)
            {
                MessageBox.Show("New username must be different from current username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Check if new username already exists
                if (adminDAO.UsernameExists(newUsername))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewUsername.Focus();
                    return;
                }

                // Update username
                adminDAO.UpdateAdminUsername(currentUsername, newUsername);
                MessageBox.Show("Username changed successfully. Please log in again with your new username.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing username: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidatePasswordChange()
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                MessageBox.Show("Please enter your current password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Please enter a new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text.Length < 4)
            {
                MessageBox.Show("New password must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please confirm your new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateUsernameChange()
        {
            if (string.IsNullOrWhiteSpace(txtNewUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewUsername.Focus();
                return false;
            }

            if (txtNewUsername.Text.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewUsername.Focus();
                return false;
            }

            return true;
        }

        private void ClearPasswordFields()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            txtCurrentPassword.Focus();
        }

        private void grpChangeUsername_Enter(object sender, EventArgs e)
        {

        }
    }
}
