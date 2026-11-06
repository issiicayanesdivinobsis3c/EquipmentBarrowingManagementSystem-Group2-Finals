using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EquipmentBarrowingManagementSystem.DataAccess;
using EquipmentBarrowingManagementSystem.Models;
using EquipmentBarrowingManagementSystem.Utilities;

namespace EquipmentBarrowingManagementSystem
{
    public partial class Form1 : Form
    {
        private EquipmentDAO equipmentDAO;
        private BorrowRecordDAO borrowRecordDAO;
        private AdminDAO adminDAO;
        private Equipment selectedEquipment;
        private string currentUsername;

        public Form1(string username)
        {
            InitializeComponent();
            this.currentUsername = username;
            equipmentDAO = new EquipmentDAO();
            borrowRecordDAO = new BorrowRecordDAO();
            adminDAO = new AdminDAO();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Equipment Management System - " + currentUsername;
                this.Width = 1000;
                this.Height = 700;
                this.StartPosition = FormStartPosition.CenterScreen;
                RefreshEquipmentList();
                RefreshDashboard();
                RefreshBorrowHistory();
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "Form1_Load");
                ErrorHandler.ShowError("Error loading form: " + ex.Message, "Initialization Error");
            }
        }

        private void RefreshEquipmentList()
        {
            try
            {
                dgvEquipment.DataSource = null;
                List<Equipment> equipmentList = equipmentDAO.GetAllEquipment();
                dgvEquipment.DataSource = equipmentList;
                lblTotalEquipment.Text = "Total Equipment: " + equipmentList.Count;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "RefreshEquipmentList");
                ErrorHandler.ShowError("Error loading equipment: " + ex.Message, "Error");
            }
        }

        private void RefreshDashboard()
        {
            try
            {
                List<Equipment> equipmentList = equipmentDAO.GetAllEquipment();
                int totalEquipment = equipmentList.Count;
                int totalQty = 0;
                int availableQty = 0;

                foreach (var eq in equipmentList)
                {
                    totalQty += eq.TotalQty;
                    availableQty += eq.AvailableQty;
                }

                int borrowedRecords = borrowRecordDAO.GetBorrowedCount();
                int returnedRecords = borrowRecordDAO.GetReturnedCount();

                lblDashEquipmentCount.Text = "Total Equipment Types: " + totalEquipment;
                lblDashTotalQty.Text = "Total Quantity: " + totalQty;
                lblDashAvailableQty.Text = "Available: " + availableQty;
                lblDashBorrowedQty.Text = "Currently Borrowed: " + (totalQty - availableQty);
                lblDashBorrowRecords.Text = "Borrow Records: " + borrowedRecords;
                lblDashReturnRecords.Text = "Returned Records: " + returnedRecords;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "RefreshDashboard");
                ErrorHandler.ShowError("Error loading dashboard: " + ex.Message, "Error");
            }
        }

        private void RefreshBorrowHistory()
        {
            try
            {
                dgvBorrowHistory.DataSource = null;
                List<BorrowRecord> records = borrowRecordDAO.GetAllRecords();
                dgvBorrowHistory.DataSource = records;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "RefreshBorrowHistory");
                ErrorHandler.ShowError("Error loading borrow history: " + ex.Message, "Error");
            }
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                EquipmentForm equipmentForm = new EquipmentForm(null);
                if (equipmentForm.ShowDialog() == DialogResult.OK)
                {
                    adminDAO.LogTransaction(currentUsername, "ADD_EQUIPMENT", "Added new equipment");
                    RefreshEquipmentList();
                    RefreshDashboard();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "btnAddEquipment_Click");
                ErrorHandler.ShowError("Error adding equipment: " + ex.Message, "Error");
            }
        }

        private void btnEditEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEquipment.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarning("Please select an equipment to edit.", "Validation");
                    return;
                }

                int equipmentID = (int)dgvEquipment.SelectedRows[0].Cells["EquipmentID"].Value;
                Equipment equipment = equipmentDAO.GetEquipmentByID(equipmentID);

                EquipmentForm equipmentForm = new EquipmentForm(equipment);
                if (equipmentForm.ShowDialog() == DialogResult.OK)
                {
                    adminDAO.LogTransaction(currentUsername, "EDIT_EQUIPMENT", "Edited equipment ID: " + equipmentID);
                    RefreshEquipmentList();
                    RefreshDashboard();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "btnEditEquipment_Click");
                ErrorHandler.ShowError("Error editing equipment: " + ex.Message, "Error");
            }
        }

        private void btnDeleteEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEquipment.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarning("Please select an equipment to delete.", "Validation");
                    return;
                }

                int equipmentID = (int)dgvEquipment.SelectedRows[0].Cells["EquipmentID"].Value;

                if (ErrorHandler.ShowConfirmation("Are you sure you want to delete this equipment?", "Confirm Delete") == DialogResult.Yes)
                {
                    equipmentDAO.DeleteEquipment(equipmentID);
                    adminDAO.LogTransaction(currentUsername, "DELETE_EQUIPMENT", "Deleted equipment ID: " + equipmentID);
                    RefreshEquipmentList();
                    RefreshDashboard();
                    ErrorHandler.ShowInfo("Equipment deleted successfully.", "Success");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "btnDeleteEquipment_Click");
                ErrorHandler.ShowError("Error deleting equipment: " + ex.Message, "Error");
            }
        }

        private void btnSearchEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearchEquipment.Text.Trim();
                if (string.IsNullOrEmpty(searchTerm))
                {
                    RefreshEquipmentList();
                    return;
                }

                dgvEquipment.DataSource = null;
                List<Equipment> results = equipmentDAO.SearchEquipment(searchTerm);
                dgvEquipment.DataSource = results;
                lblTotalEquipment.Text = "Search Results: " + results.Count;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "btnSearchEquipment_Click");
                ErrorHandler.ShowError("Error searching equipment: " + ex.Message, "Error");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshEquipmentList();
                RefreshDashboard();
                RefreshBorrowHistory();
                ErrorHandler.ShowInfo("Data refreshed successfully.", "Success");
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "btnRefresh_Click");
                ErrorHandler.ShowError("Error refreshing data: " + ex.Message, "Error");
            }
        }

        private void btnBorrowEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                BorrowForm borrowForm = new BorrowForm(equipmentDAO);
                if (borrowForm.ShowDialog() == DialogResult.OK)
                {
                    adminDAO.LogTransaction(currentUsername, "BORROW_EQUIPMENT", "Borrowed equipment");
                    RefreshEquipmentList();
                    RefreshDashboard();
                    RefreshBorrowHistory();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "btnBorrowEquipment_Click");
                ErrorHandler.ShowError("Error borrowing equipment: " + ex.Message, "Error");
            }
        }

        private void btnReturnEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBorrowHistory.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarning("Please select a borrow record to return.", "Validation");
                    return;
                }

                int recordID = (int)dgvBorrowHistory.SelectedRows[0].Cells["RecordID"].Value;
                string status = dgvBorrowHistory.SelectedRows[0].Cells["Status"].Value.ToString();

                if (status != "Borrowed")
                {
                    ErrorHandler.ShowInfo("This item has already been returned.", "Info");
                    return;
                }

                borrowRecordDAO.ReturnEquipment(recordID, DateTime.Now);
                int equipmentID = (int)dgvBorrowHistory.SelectedRows[0].Cells["EquipmentID"].Value;
                int quantity = (int)dgvBorrowHistory.SelectedRows[0].Cells["Quantity"].Value;

                Equipment equipment = equipmentDAO.GetEquipmentByID(equipmentID);
                equipment.AvailableQty += quantity;
                equipmentDAO.UpdateEquipment(equipment);

                adminDAO.LogTransaction(currentUsername, "RETURN_EQUIPMENT", "Returned equipment ID: " + equipmentID);

                RefreshEquipmentList();
                RefreshDashboard();
                RefreshBorrowHistory();
                ErrorHandler.ShowInfo("Equipment returned successfully.", "Success");
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "btnReturnEquipment_Click");
                ErrorHandler.ShowError("Error returning equipment: " + ex.Message, "Error");
            }
        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            try
            {
                AccountSettingsForm settingsForm = new AccountSettingsForm(currentUsername);
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    ErrorHandler.ShowInfo("Account settings changed. Please log in again with your new credentials.", "Account Updated");
                    adminDAO.LogTransaction(currentUsername, "CHANGE_CREDENTIALS", "Changed account credentials");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "btnAccountSettings_Click");
                ErrorHandler.ShowError("Error opening account settings: " + ex.Message, "Error");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (ErrorHandler.ShowConfirmation("Are you sure you want to logout?", "Confirm Logout") == DialogResult.Yes)
                {
                    adminDAO.LogTransaction(currentUsername, "LOGOUT", "User logged out");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex, "btnLogout_Click");
                ErrorHandler.ShowError("Error during logout: " + ex.Message, "Error");
            }
        }
    }
}
