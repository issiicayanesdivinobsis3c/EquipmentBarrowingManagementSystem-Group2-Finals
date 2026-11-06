using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using EquipmentBarrowingManagementSystem.Models;

namespace EquipmentBarrowingManagementSystem.DataAccess
{
    public class BorrowRecordDAO
    {
        public List<BorrowRecord> GetAllRecords()
        {
            List<BorrowRecord> records = new List<BorrowRecord>();
            string query = "SELECT RecordID, EquipmentID, ItemName, Quantity, BorrowedBy, BorrowDate, ReturnDate, Status FROM BorrowRecords ORDER BY BorrowDate DESC";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                records.Add(ReadBorrowRecord(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving borrow records: " + ex.Message);
            }

            return records;
        }

        public List<BorrowRecord> GetActiveBorrows()
        {
            List<BorrowRecord> records = new List<BorrowRecord>();
            string query = "SELECT RecordID, EquipmentID, ItemName, Quantity, BorrowedBy, BorrowDate, ReturnDate, Status FROM BorrowRecords WHERE Status = 'Borrowed' ORDER BY BorrowDate DESC";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                records.Add(ReadBorrowRecord(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving active borrows: " + ex.Message);
            }

            return records;
        }

        public void AddBorrowRecord(BorrowRecord record)
        {
            string query = "INSERT INTO BorrowRecords (EquipmentID, ItemName, Quantity, BorrowedBy, BorrowDate, Status) VALUES (?, ?, ?, ?, ?, ?)";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = record.EquipmentID;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = record.ItemName ?? "";
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = record.Quantity;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = record.BorrowedBy ?? "";
                        // Explicit Date type avoids Access datatype mismatch on dates
                        cmd.Parameters.Add("?", OleDbType.Date).Value = record.BorrowDate;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = record.Status ?? "Borrowed";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding borrow record: " + ex.Message);
            }
        }

        public void ReturnEquipment(int recordID, DateTime returnDate)
        {
            string query = "UPDATE BorrowRecords SET Status = ?, ReturnDate = ? WHERE RecordID = ?";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "Returned";
                        cmd.Parameters.Add("?", OleDbType.Date).Value = returnDate;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = recordID;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error returning equipment: " + ex.Message);
            }
        }

        public int GetBorrowedCount()
        {
            string query = "SELECT COUNT(*) FROM BorrowRecords WHERE Status = 'Borrowed'";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public int GetReturnedCount()
        {
            string query = "SELECT COUNT(*) FROM BorrowRecords WHERE Status = 'Returned'";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private static BorrowRecord ReadBorrowRecord(OleDbDataReader reader)
        {
            return new BorrowRecord
            {
                RecordID = Convert.ToInt32(reader["RecordID"]),
                EquipmentID = Convert.ToInt32(reader["EquipmentID"]),
                ItemName = reader["ItemName"].ToString(),
                Quantity = Convert.ToInt32(reader["Quantity"]),
                BorrowedBy = reader["BorrowedBy"].ToString(),
                BorrowDate = Convert.ToDateTime(reader["BorrowDate"]),
                ReturnDate = reader["ReturnDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["ReturnDate"]) : null,
                Status = reader["Status"].ToString()
            };
        }
    }
}
