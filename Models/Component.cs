namespace ElectricInventorySystem.Models
{
    public class Component
    {
        public int ComponentId { get; set; }

        public string ProductName { get; set; } = "";
        public string ComponentName { get; set; } = "";
        public string PartNo { get; set; } = "";
        public string Voltage { get; set; } = "";
        public string Amp { get; set; } = "";
        public int Quantity { get; set; }
        public string BrandName { get; set; } = "";
        public string Location { get; set; } = "";
    }
}