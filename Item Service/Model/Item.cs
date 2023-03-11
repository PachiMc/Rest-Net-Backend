using Item_Service.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;

namespace Item_Service.Model
{
    public class Item
    {
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public Item(string name, int stock, int price, string description)
        {
            // this.Id = itemDTO.Id;
            Name = name;
            Stock = stock;
            Price = price;
            Description = description;
        }
        public Item(int id, string name, int stock, int price, string description)
        {
            // this.Id = itemDTO.Id;
            Id = id;
            Name = name;
            Stock = stock;
            Price = price;
            Description = description;
        }
    }
}
