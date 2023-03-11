using Microsoft.AspNetCore.Mvc;

namespace API.DTO
{
    public class ItemDTO
    {
        public ItemDTO(int id, string name, int stock, int price, string description)
        {
            Id = id;
            Name = name;
            Stock = stock;
            Price = price;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
