using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EquipmentBarrowingManagementSystem.DataAccess;
using EquipmentBarrowingManagementSystem.Models;

namespace EquipmentBarrowingManagementSystem
{
    public partial class BorrowForm : Form
    {
        private EquipmentDAO equipmentDAO;
        private BorrowRecordDAO borrowRecordDAO;
        private List<Equipment> equipmentList;

        public BorrowForm(EquipmentDAO equipmentDAO)
        {
            InitializeComponent();
            this.equipmentDAO = equipmentDAO;
            this.borrowRecordDAO = new BorrowRecordDAO();
        }

        private void BorrowForm_Load(object sender, EventArgs e)
        {
            this.Text = "Borrow Equipment";
            LoadEquipment();
        }

        private void LoadEquipment()
        {
            try
            {
                equipmentList = equipmentDAO.GetAllEquipment();
                var displayList = new List<dynamic>();
                foreach (var eq in equipmentList)
                {
                    displayList.Add(new { ID = eq.EquipmentID, Name = eq.ItemName, Category = eq.Category, Available = eq.AvailableQty });
                }
                cmbEquipment.DataSource = displayList;
                cmbEquipment.DisplayMember = "Name";
                cmbEquipment.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading equipment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void cmbEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEquipment.SelectedItem != null && equipmentList != null && equipmentList.Count > 0)
            {
                int selectedIndex = cmbEquipment.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < equipmentList.Count)
                {
                    Equipment selected = equipmentList[selectedIndex];
                    lblAvailable.Text = "Available: " + selected.AvailableQty;

                    
                    txtQuantity.Minimum = 1;
                    txtQuantity.Maximum = Math.Max(1, selected.AvailableQty);
                    txtQuantity.Value = 1;
                }
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                int equipmentID = (int)cmbEquipment.SelectedValue;
                Equipment equipment = equipmentDAO.GetEquipmentByID(equipmentID);
                int borrowQuantity = (int)txtQuantity.Value;

                if (borrowQuantity > equipment.AvailableQty)
                {
                    MessageBox.Show("Quantity exceeds available stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BorrowRecord record = new BorrowRecord
                {
                    EquipmentID = equipmentID,
                    ItemName = equipment.ItemName,
                    Quantity = borrowQuantity,
                    BorrowedBy = txtBorrowedBy.Text.Trim(),
                    BorrowDate = dtBorrowDate.Value,
                    Status = "Borrowed"
                };

                borrowRecordDAO.AddBorrowRecord(record);

                equipment.AvailableQty -= borrowQuantity;
                equipmentDAO.UpdateEquipment(equipment);

                MessageBox.Show("Equipment borrowed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error borrowing equipment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
        private bool ValidateInputs()
        {
            if (cmbEquipment.SelectedItem == null)
            {
                MessageBox.Show("Please select an equipment.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBorrowedBy.Text))
            {
                MessageBox.Show("Please enter borrower name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtQuantity.Value < 1)
            {
                MessageBox.Show("Quantity must be at least 1.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
