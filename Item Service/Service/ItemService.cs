using AutoMapper;
using API.Data;
using API.DTO;
using API.Model;
using API.Response;
using Microsoft.EntityFrameworkCore;


namespace API.Service
{
    public class ItemService : IItemService
    {

        private readonly DataContext _context;

        public ItemService(DataContext context)
        {
            _context = context;
        }
        public ServiceResponse<ItemAddDTO> AddItem(ItemAddDTO itemDTO)
        {
            ServiceResponse<ItemAddDTO> serviceResponse = new();
            Item item = new (itemDTO.Name, itemDTO.Stock, itemDTO.Price, itemDTO.Description);
            _context.Add(item);
            if (_context.SaveChanges() > 0)
            {
                serviceResponse.Data = itemDTO;
            }
            return serviceResponse;
        }

        public ServiceResponse<ItemDTO> DeleteItem(int id)
        {
            ServiceResponse<ItemDTO> serviceResponse = new();
            Item? item = _context.Find<Item>(id);
            if (item is not null)
            {
                ItemDTO itemDTO = new (item.Id, item.Name, item.Stock, item.Price, item.Description);
                _context.Remove(item);
                if (_context.SaveChanges() > 0)
                {
                    serviceResponse.Data = itemDTO;
                }
            }
            return serviceResponse;
        }

        public ServiceResponse<List<ItemDTO>> GetAll()
        {
            ServiceResponse<List<ItemDTO>> serviceResponse = new();
            List<Item> item = _context.Item.ToList();
            if (item is not null)
            {
                List<ItemDTO> ItemDTOList =new();
                for (int i = 0; i < item.Count; i++)
                {
                    ItemDTOList.Add(new ItemDTO(item[i].Id, item[i].Name, item[i].Stock, item[i].Price, item[i].Description));
                }
                serviceResponse.Data = ItemDTOList;
            }
            return serviceResponse;
        }

        public ServiceResponse<ItemDTO> GetById(int id)
        {
            ServiceResponse<ItemDTO> serviceResponse = new();
            Item? item = _context.Find<Item>(id);
            if (item is not null)
            {
                ItemDTO itemDTO = new (item.Id, item.Name, item.Stock, item.Price, item.Description);
                serviceResponse.Data = itemDTO;
            }
            return serviceResponse;
        }

        public ServiceResponse<List<ItemDTO>> SearchItem(string query)
        {
            ServiceResponse<List<ItemDTO>> serviceResponse = new();
            List<Item> item = _context.Item.ToList();
            if (item is not null)
            {
                List<ItemDTO> ItemDTOList = new();
                Predicate<Item> predicate = elem => elem.Name.Contains(query) || elem.Name.StartsWith(query) || elem.Name.EndsWith(query) || elem.Description.Contains(query) || elem.Description.StartsWith(query) || elem.Description.EndsWith(query);
                item = item.FindAll(predicate);
                for (int i = 0; i < item.Count; i++)
                {
                    ItemDTOList.Add(new ItemDTO(item[i].Id, item[i].Name, item[i].Stock, item[i].Price, item[i].Description));
                }
                serviceResponse.Data = ItemDTOList;
            }
            return serviceResponse;
        }

        public ServiceResponse<ItemDTO> UpdateItem(ItemDTO itemDTO)
        {
            ServiceResponse<ItemDTO> serviceResponse = new();
            int rowsAffected = _context.Item.Where(elem => elem.Id == itemDTO.Id).ExecuteUpdate(
                update => update.SetProperty(item => item.Name, itemDTO.Name).SetProperty(item => item.Description, itemDTO.Description).SetProperty(item => item.Stock, itemDTO.Stock).SetProperty(item => item.Price, itemDTO.Price)
                );
            _context.SaveChanges(); 
            if (rowsAffected > 0)
            {
                serviceResponse.Data = itemDTO;
            }
            return serviceResponse;
        }
    }
}
    