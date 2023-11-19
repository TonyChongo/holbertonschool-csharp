using System;

namespace InventoryLibrary
{
    public class Inventory : BaseClass
    {
        public string user_id { get; set; }
        public string item_id { get; set; }
        public int quantity { get; set; } = 1; // Default value: 1, cannot be less than 0
    }
}
