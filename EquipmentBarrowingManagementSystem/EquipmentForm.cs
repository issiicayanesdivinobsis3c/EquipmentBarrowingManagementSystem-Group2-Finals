using System;
using System.Windows.Forms;
using EquipmentBarrowingManagementSystem.DataAccess;
using EquipmentBarrowingManagementSystem.Models;

namespace EquipmentBarrowingManagementSystem
{
    public partial class EquipmentForm : Form
    {
        private Equipment equipment;
        private EquipmentDAO equipmentDAO;

        public EquipmentForm(Equipment equipment)
        {
            InitializeComponent();
            this.equipment = equipment;
            this.equipmentDAO = new EquipmentDAO();
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            this.Text = equipment == null ? "Add Equipment" : "Edit Equipment";
            if (equipment != null)
            {
                txtItemName.Text = equipment.ItemName;
                txtCategory.Text = equipment.Category;
                txtTotalQty.Text = equipment.TotalQty.ToString();
                txtAvailableQty.Text = equipment.AvailableQty.ToString();
                //txtTotalQty.ReadOnly = true;
                //txtAvailableQty.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                if (equipment == null)
                {
                    // Add new equipment
                    Equipment newEquipment = new Equipment
                    {
                        ItemName = txtItemName.Text.Trim(),
                        Category = txtCategory.Text.Trim(),
                        TotalQty = int.Parse(txtTotalQty.Text),
                        AvailableQty = int.Parse(txtAvailableQty.Text)
                    };
                    equipmentDAO.AddEquipment(newEquipment);
                    MessageBox.Show("Equipment added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Update existing equipment
                    equipment.ItemName = txtItemName.Text.Trim();
                    equipment.Category = txtCategory.Text.Trim();
                    equipmentDAO.UpdateEquipment(equipment);
                    MessageBox.Show("Equipment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving equipment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Please enter category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (equipment == null)
            {
                if (string.IsNullOrWhiteSpace(txtTotalQty.Text) || !int.TryParse(txtTotalQty.Text, out int total) || total < 0)
                {
                    MessageBox.Show("Please enter a valid total quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtAvailableQty.Text) || !int.TryParse(txtAvailableQty.Text, out int available) || available < 0 || available > total)
                {
                    MessageBox.Show("Please enter a valid available quantity (must be <= total quantity).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}
