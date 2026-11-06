using System;

namespace EquipmentBarrowingManagementSystem.Models
{
    public class BorrowRecord
    {
        public int RecordID { get; set; }
        public int EquipmentID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string BorrowedBy { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } // "Borrowed" or "Returned"

        public override string ToString()
        {
            return $"{ItemName} - {Quantity} units - {BorrowDate:yyyy-MM-dd} - Status: {Status}";
        }
    }
}
