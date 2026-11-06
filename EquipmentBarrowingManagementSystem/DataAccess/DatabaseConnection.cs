using System;
using System.Data.OleDb;
using System.IO;

namespace EquipmentBarrowingManagementSystem.DataAccess
{
    public class DatabaseConnection
    {
        /// **Summary:**

        /// Returns the full path to EquipmentDB.accdb in a writable folder (LocalAppData).
        /// This avoids "read-only / access denied" errors when the app is installed under Program Files.
        /// 
        public static string GetDatabasePath()
        {
            // Writable location for installed app
            string appDataDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "EquipmentBarrowingManagementSystem");

            if (!Directory.Exists(appDataDir))
                Directory.CreateDirectory(appDataDir);

            return Path.Combine(appDataDir, "EquipmentDB.accdb");
        }

        private static string GetConnectionString()
        {
            string dbPath = GetDatabasePath();
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
        }

        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(GetConnectionString());
        }

        public static bool TestConnection()
        {
            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}