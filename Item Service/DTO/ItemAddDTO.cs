using Microsoft.AspNetCore.Mvc;

namespace Item_Service.DTO
{
    public class ItemAddDTO
    {

        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
