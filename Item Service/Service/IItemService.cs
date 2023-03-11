using API.DTO;
using API.Response;

namespace API.Service
{
    public interface IItemService
    {
        public ServiceResponse<List<ItemDTO>> GetAll();
        public ServiceResponse<ItemDTO> GetById(int id);
        public ServiceResponse<ItemDTO> UpdateItem(ItemDTO item);
        public ServiceResponse<ItemDTO> DeleteItem(int id);
        public ServiceResponse<ItemAddDTO> AddItem(ItemAddDTO itemDTO);
        public ServiceResponse<List<ItemDTO>> SearchItem(string query);
    }
}
