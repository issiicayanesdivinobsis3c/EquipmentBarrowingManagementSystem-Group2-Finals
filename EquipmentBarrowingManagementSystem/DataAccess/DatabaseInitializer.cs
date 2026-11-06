using System;
using System.Data.OleDb;
using System.IO;

namespace EquipmentBarrowingManagementSystem.DataAccess
{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            try
            {
                string dbPath = DatabaseConnection.GetDatabasePath();

                // If DB does not exist in AppData, copy template from install folder (next to .exe)
                if (!File.Exists(dbPath))
                {
                    string templatePath = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "EquipmentDB.accdb");

                    if (File.Exists(templatePath))
                    {
                        File.Copy(templatePath, dbPath);
                    }
                    else
                    {
                        throw new FileNotFoundException(
                            "Equipment database template not found.\n" +
                            "Please make sure 'EquipmentDB.accdb' is installed with the application.");
                    }
                }

                // Ensure tables and default admin exist
                CreateTables();
                InsertDefaultData();
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing database: " + ex.Message, ex);
            }
        }

        private static void CreateTables()
        {
            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    CreateAdminTable(conn);
                    CreateEquipmentTable(conn);
                    CreateBorrowRecordsTable(conn);
                    CreateTransactionLogTable(conn);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating tables: " + ex.Message, ex);
            }
        }

        private static void CreateAdminTable(OleDbConnection conn)
        {
            if (TableExists(conn, "Admin"))
                return;

            string createQuery = "CREATE TABLE Admin (AdminID COUNTER PRIMARY KEY, Username TEXT NOT NULL, Password TEXT NOT NULL, Email TEXT)";
            using (OleDbCommand cmd = new OleDbCommand(createQuery, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void CreateEquipmentTable(OleDbConnection conn)
        {
            if (TableExists(conn, "Equipment"))
                return;

            string createQuery = "CREATE TABLE Equipment (EquipmentID COUNTER PRIMARY KEY, ItemName TEXT NOT NULL, Category TEXT NOT NULL, TotalQty INTEGER NOT NULL, AvailableQty INTEGER NOT NULL, Description TEXT)";
            using (OleDbCommand cmd = new OleDbCommand(createQuery, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void CreateBorrowRecordsTable(OleDbConnection conn)
        {
            if (TableExists(conn, "BorrowRecords"))
                return;

            string createQuery = "CREATE TABLE BorrowRecords (RecordID COUNTER PRIMARY KEY, EquipmentID INTEGER NOT NULL, ItemName TEXT NOT NULL, Quantity INTEGER NOT NULL, BorrowedBy TEXT NOT NULL, BorrowDate DATE NOT NULL, ReturnDate DATE, Status TEXT NOT NULL, Notes TEXT)";
            using (OleDbCommand cmd = new OleDbCommand(createQuery, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void CreateTransactionLogTable(OleDbConnection conn)
        {
            if (TableExists(conn, "TransactionLog"))
                return;

            string createQuery = "CREATE TABLE TransactionLog (LogID COUNTER PRIMARY KEY, AdminUsername TEXT NOT NULL, Action TEXT NOT NULL, Details TEXT)";
            using (OleDbCommand cmd = new OleDbCommand(createQuery, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static bool TableExists(OleDbConnection conn, string tableName)
        {
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM " + tableName;
                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                {
                    checkCmd.ExecuteScalar();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private static void InsertDefaultData()
        {
            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string countQuery = "SELECT COUNT(*) FROM Admin";
                    using (OleDbCommand cmd = new OleDbCommand(countQuery, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            // Default login: admin / 123456
                            string insertQuery = "INSERT INTO Admin (Username, Password, Email) VALUES (?, ?, ?)";
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.Add("?", System.Data.OleDb.OleDbType.VarWChar).Value = "admin";
                                insertCmd.Parameters.Add("?", System.Data.OleDb.OleDbType.VarWChar).Value = "123456";
                                insertCmd.Parameters.Add("?", System.Data.OleDb.OleDbType.VarWChar).Value = "admin@equipmentborrow.com";
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting default data: " + ex.Message, ex);
            }
        }

        public static bool VerifyDatabaseVersion()
        {
            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string[] tables = { "Admin", "Equipment", "BorrowRecords", "TransactionLog" };
                    foreach (string table in tables)
                    {
                        if (!TableExists(conn, table))
                            return false;
                    }
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