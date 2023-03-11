using AutoMapper;
using Item_Service.Data;
using Item_Service.DTO;
using Item_Service.Model;
using Item_Service.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mysqlx.Crud;
using System.Net.WebSockets;
using System.Reflection.Metadata;

namespace Item_Service.Service
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
            Item item = new Item(itemDTO.Name, itemDTO.Stock, itemDTO.Price, itemDTO.Description);
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
                ItemDTO itemDTO = new ItemDTO(item.Id, item.Name, item.Stock, item.Price, item.Description);
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
                List<ItemDTO> ItemDTOList = new List<ItemDTO>();
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
                ItemDTO itemDTO = new ItemDTO(item.Id, item.Name, item.Stock, item.Price, item.Description);
                serviceResponse.Data = itemDTO;
            }
            return serviceResponse;
        }

        public ServiceResponse<List<ItemDTO>> SearchItem(string match)
        {
            ServiceResponse<List<ItemDTO>> serviceResponse = new();
            List<Item> item = _context.Item.ToList();
            if (item is not null)
            {
                List<ItemDTO> ItemDTOList = new();
                Predicate<Item> predicate = elem => elem.Name.Contains(match) || elem.Name.StartsWith(match) || elem.Name.EndsWith(match) || elem.Description.Contains(match) || elem.Description.StartsWith(match) || elem.Description.EndsWith(match);
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
            Item item = new Item(itemDTO.Id, itemDTO.Name, itemDTO.Stock, itemDTO.Price, itemDTO.Description);
            _context.Update(item);
            if (true)
            {
                serviceResponse.Data = itemDTO;
            }
            return serviceResponse;
        }
    }
}
