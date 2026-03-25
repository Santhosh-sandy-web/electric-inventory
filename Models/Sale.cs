using System;

namespace ElectricInventorySystem.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        public int ComponentId { get; set; }
        public required Component Component { get; set; }

        public int Quantity { get; set; }

        public required string IssuedTo { get; set; }

        public DateTime Date { get; set; }
    }
}