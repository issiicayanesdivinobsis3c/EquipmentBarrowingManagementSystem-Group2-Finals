using System;
using System.Data.OleDb;
using System.IO;

class DatabaseInitializer
{
    static void Main()
    {
        try
        {
            string dbPath = "C:\\Users\\Dinno\\Documents\\EquipmentDB.accdb";

            // Create database file if it doesn't exist
            if (!System.IO.File.Exists(dbPath))
            {
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    conn.Close();
                }
                Console.WriteLine("✓ Database file created");
            }

            // Create connection
            string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                Console.WriteLine("✓ Connected to database");

                // Create Admin table
                try
                {
                    string query = "SELECT COUNT(*) FROM Admin";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.ExecuteScalar();
                        Console.WriteLine("✓ Admin table already exists");
                    }
                }
                catch
                {
                    string createAdmin = "CREATE TABLE Admin (AdminID COUNTER PRIMARY KEY, Username TEXT NOT NULL UNIQUE, Password TEXT NOT NULL, Email TEXT)";
                    using (OleDbCommand cmd = new OleDbCommand(createAdmin, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("✓ Admin table created");
                    }
                }

                // Create Equipment table
                try
                {
                    string query = "SELECT COUNT(*) FROM Equipment";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.ExecuteScalar();
                        Console.WriteLine("✓ Equipment table already exists");
                    }
                }
                catch
                {
                    string createEquipment = "CREATE TABLE Equipment (EquipmentID COUNTER PRIMARY KEY, ItemName TEXT NOT NULL, Category TEXT NOT NULL, TotalQty INTEGER NOT NULL, AvailableQty INTEGER NOT NULL, Description TEXT)";
                    using (OleDbCommand cmd = new OleDbCommand(createEquipment, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("✓ Equipment table created");
                    }
                }

                // Create BorrowRecords table
                try
                {
                    string query = "SELECT COUNT(*) FROM BorrowRecords";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.ExecuteScalar();
                        Console.WriteLine("✓ BorrowRecords table already exists");
                    }
                }
                catch
                {
                    string createBorrowRecords = "CREATE TABLE BorrowRecords (RecordID COUNTER PRIMARY KEY, EquipmentID INTEGER NOT NULL, ItemName TEXT NOT NULL, Quantity INTEGER NOT NULL, BorrowedBy TEXT NOT NULL, BorrowDate DATE NOT NULL, ReturnDate DATE, Status TEXT NOT NULL, Notes TEXT)";
                    using (OleDbCommand cmd = new OleDbCommand(createBorrowRecords, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("✓ BorrowRecords table created");
                    }
                }

                // Create TransactionLog table
                try
                {
                    string query = "SELECT COUNT(*) FROM TransactionLog";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.ExecuteScalar();
                        Console.WriteLine("✓ TransactionLog table already exists");
                    }
                }
                catch
                {
                    string createTransactionLog = "CREATE TABLE TransactionLog (LogID COUNTER PRIMARY KEY, AdminUsername TEXT NOT NULL, Action TEXT NOT NULL, Details TEXT)";
                    using (OleDbCommand cmd = new OleDbCommand(createTransactionLog, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("✓ TransactionLog table created");
                    }
                }

                // Insert default admin if table is empty
                try
                {
                    string countQuery = "SELECT COUNT(*) FROM Admin";
                    using (OleDbCommand cmd = new OleDbCommand(countQuery, conn))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        if (count == 0)
                        {
                            string insertAdmin = "INSERT INTO Admin (Username, Password, Email) VALUES (@Username, @Password, @Email)";
                            using (OleDbCommand insertCmd = new OleDbCommand(insertAdmin, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@Username", "admin");
                                insertCmd.Parameters.AddWithValue("@Password", "1234");
                                insertCmd.Parameters.AddWithValue("@Email", "admin@equipmentborrow.com");
                                insertCmd.ExecuteNonQuery();
                                Console.WriteLine("✓ Default admin account created (admin / 1234)");
                            }
                        }
                        else
                        {
                            Console.WriteLine("✓ Admin account already exists");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✗ Error with admin account: {ex.Message}");
                }

                conn.Close();
            }

            Console.WriteLine("\n✅ Database initialization complete!");
            Console.WriteLine("Login credentials: admin / 1234");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }
}
