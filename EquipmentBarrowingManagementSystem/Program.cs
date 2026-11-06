using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EquipmentBarrowingManagementSystem.DataAccess;
using EquipmentBarrowingManagementSystem.Utilities;

namespace EquipmentBarrowingManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Initialize database on startup
                DatabaseInitializer.InitializeDatabase();

                // Show login form
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1(loginForm.CurrentUsername));
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "Program.Main");
                ErrorHandler.ShowError("Critical error: " + ex.Message, "Application Error");
            }
        }
    }
}
