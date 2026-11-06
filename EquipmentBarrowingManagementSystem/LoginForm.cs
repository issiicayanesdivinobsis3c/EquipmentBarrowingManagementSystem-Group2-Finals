using System;
using System.Windows.Forms;
using EquipmentBarrowingManagementSystem.DataAccess;
using EquipmentBarrowingManagementSystem.Utilities;

namespace EquipmentBarrowingManagementSystem
{
    public partial class LoginForm : Form
    {
        private AdminDAO adminDAO;
        public string CurrentUsername { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            this.adminDAO = new AdminDAO();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Text = "Equipment Management System - Login";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ErrorHandler.ShowWarning("Please enter both username and password.", "Validation Error");
                txtUsername.Focus();
                return;
            }

            try
            {
                if (adminDAO.AuthenticateAdmin(username, password))
                {
                    this.CurrentUsername = username;
                    adminDAO.LogTransaction(username, "LOGIN", "User logged in successfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ErrorHandler.ShowError("Invalid username or password.", "Authentication Failed");
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "LoginForm.btnLogin_Click");
                ErrorHandler.ShowError("Error during login: " + ex.Message, "Login Error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
                e.Handled = true;
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
