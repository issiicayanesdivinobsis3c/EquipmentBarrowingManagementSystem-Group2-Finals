using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using EquipmentBarrowingManagementSystem.Models;

namespace EquipmentBarrowingManagementSystem.DataAccess
{
    public class EquipmentDAO
    {
        public List<Equipment> GetAllEquipment()
        {
            List<Equipment> equipmentList = new List<Equipment>();
            string query = "SELECT EquipmentID, ItemName, Category, TotalQty, AvailableQty FROM Equipment";

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
                                Equipment eq = new Equipment
                                {
                                    EquipmentID = Convert.ToInt32(reader["EquipmentID"]),
                                    ItemName = reader["ItemName"].ToString(),
                                    Category = reader["Category"].ToString(),
                                    TotalQty = Convert.ToInt32(reader["TotalQty"]),
                                    AvailableQty = Convert.ToInt32(reader["AvailableQty"])
                                };
                                equipmentList.Add(eq);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving equipment list: " + ex.Message);
            }

            return equipmentList;
        }

        public Equipment GetEquipmentByID(int equipmentID)
        {
            string query = "SELECT EquipmentID, ItemName, Category, TotalQty, AvailableQty FROM Equipment WHERE EquipmentID = ?";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = equipmentID;
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Equipment
                                {
                                    EquipmentID = Convert.ToInt32(reader["EquipmentID"]),
                                    ItemName = reader["ItemName"].ToString(),
                                    Category = reader["Category"].ToString(),
                                    TotalQty = Convert.ToInt32(reader["TotalQty"]),
                                    AvailableQty = Convert.ToInt32(reader["AvailableQty"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving equipment: " + ex.Message);
            }

            return null;
        }

        public void AddEquipment(Equipment equipment)
        {
            string query = "INSERT INTO Equipment (ItemName, Category, TotalQty, AvailableQty) VALUES (?, ?, ?, ?)";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = equipment.ItemName ?? "";
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = equipment.Category ?? "";
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = equipment.TotalQty;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = equipment.AvailableQty;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding equipment: " + ex.Message);
            }
        }

        public void UpdateEquipment(Equipment equipment)
        {
            string query = "UPDATE Equipment SET ItemName = ?, Category = ?, TotalQty = ?, AvailableQty = ? WHERE EquipmentID = ?";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = equipment.ItemName ?? "";
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = equipment.Category ?? "";
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = equipment.TotalQty;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = equipment.AvailableQty;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = equipment.EquipmentID;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating equipment: " + ex.Message);
            }
        }

        public void DeleteEquipment(int equipmentID)
        {
            string query = "DELETE FROM Equipment WHERE EquipmentID = ?";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = equipmentID;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting equipment: " + ex.Message);
            }
        }

        public List<Equipment> SearchEquipment(string searchTerm)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            // Access needs the parameter twice when used in two places
            string query = "SELECT EquipmentID, ItemName, Category, TotalQty, AvailableQty FROM Equipment WHERE ItemName LIKE ? OR Category LIKE ?";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        string pattern = "%" + (searchTerm ?? "") + "%";
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = pattern;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = pattern;
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Equipment eq = new Equipment
                                {
                                    EquipmentID = Convert.ToInt32(reader["EquipmentID"]),
                                    ItemName = reader["ItemName"].ToString(),
                                    Category = reader["Category"].ToString(),
                                    TotalQty = Convert.ToInt32(reader["TotalQty"]),
                                    AvailableQty = Convert.ToInt32(reader["AvailableQty"])
                                };
                                equipmentList.Add(eq);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching equipment: " + ex.Message);
            }

            return equipmentList;
        }
    }
}
