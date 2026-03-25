using System;

namespace ElectricInventorySystem.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public int ComponentId { get; set; }
        public required Component Component { get; set; }

        public int SupplierId { get; set; }
        public required Supplier Supplier { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }
    }
}