using System;
using System.Data;
using System.Data.OleDb;

namespace EquipmentBarrowingManagementSystem.DataAccess
{
    public class AdminDAO
    {
        public bool AuthenticateAdmin(string username, string password)
        {
            // [Password] because Password is a reserved word in Access
            string query = "SELECT COUNT(*) FROM Admin WHERE Username = ? AND [Password] = ?";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = username ?? "";
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = password ?? "";
                        object result = cmd.ExecuteScalar();
                        int count = result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating admin: " + ex.Message);
            }
        }

        public void UpdateAdminPassword(string username, string newPassword)
        {
            // [Password] required - Password is reserved in Access SQL
            string query = "UPDATE Admin SET [Password] = ? WHERE Username = ?";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = newPassword ?? "";
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = username ?? "";
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("Admin user not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating password: " + ex.Message);
            }
        }

        public void UpdateAdminUsername(string currentUsername, string newUsername)
        {
            string query = "UPDATE Admin SET Username = ? WHERE Username = ?";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = newUsername ?? "";
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = currentUsername ?? "";
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("Admin user not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating username: " + ex.Message);
            }
        }

        public bool UsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM Admin WHERE Username = ?";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = username ?? "";
                        object result = cmd.ExecuteScalar();
                        int count = result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking username: " + ex.Message);
            }
        }

        public void LogTransaction(string adminUsername, string action, string details)
        {
            string query = "INSERT INTO TransactionLog (AdminUsername, Action, Details) VALUES (?, ?, ?)";

            try
            {
                using (OleDbConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = adminUsername ?? "";
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = action ?? "";
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = details ?? "";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error logging transaction: " + ex.Message);
            }
        }
    }
}
