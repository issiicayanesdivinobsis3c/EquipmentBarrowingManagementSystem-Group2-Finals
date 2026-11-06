using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace EquipmentBarrowingManagementSystem.Utilities
{
    public static class ErrorHandler
    {
        private static readonly string LogPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "error.log");

        public static void LogException(Exception ex, string context)
        {
            try
            {
                string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{context}] {ex}\r\n";
                File.AppendAllText(LogPath, line);
                Debug.WriteLine(line);
            }
            catch { /* ignore logging failures */ }
        }

        public static void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarning(string message, string title = "Warning")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInfo(string message, string title = "Information")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowConfirmation(string message, string title = "Confirm")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}