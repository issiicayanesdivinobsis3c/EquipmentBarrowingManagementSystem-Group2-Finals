using System;

namespace EquipmentBarrowingManagementSystem.Models
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public int TotalQty { get; set; }
        public int AvailableQty { get; set; }

        public override string ToString()
        {
            return $"{ItemName} ({Category}) - Available: {AvailableQty}/{TotalQty}";
        }
    }
}
