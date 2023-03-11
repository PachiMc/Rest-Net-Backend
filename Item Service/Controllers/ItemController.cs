using Azure;
using Item_Service.DTO;
using Item_Service.Model;
using Item_Service.Response;
using Item_Service.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Item_Service.Controllers

{
    [ApiController]

    [Route("api/[controller]/[action]")]
    public class ItemController : ControllerBase
    {

        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<ItemDTO> GetAll()
        {
            ServiceResponse<List<ItemDTO>> response = _itemService.GetAll();
            response.Succcess = false;
            response.Message = "The item list is empty";
            if (response.Data is not null)
            {
                response.Succcess = true;
                response.Message = "";
            }
            return Ok(response);
        }

        [Route("/GetById/{id}")]
        [HttpGet]
        public ActionResult<List<ItemDTO>> GetSingle(int id)
        {
            ServiceResponse<ItemDTO> response = _itemService.GetById(id);
            response.Succcess = false;
            response.Message = "The item " + id + " could not be found";
            if (response.Data is not null)
            {
                response.Succcess = true;
                response.Message = "";
            }
            return Ok(response);
        }

        [Route("/GetBySearch")]
        [HttpGet]
        public ActionResult<List<ItemDTO>> SearchItem(string match)
        {
            ServiceResponse<List<ItemDTO>> response = _itemService.SearchItem(match);
            response.Succcess = false;
            response.Message = "The item list is empty";
            if (response.Data is not null)
            {
                response.Succcess = true;
                response.Message = "";
            }
            return Ok(response);
        }


        [Route("/New")]
        [HttpPost]
        public ActionResult<List<ItemDTO>> AddItem(ItemAddDTO itemDTO)
        {
            ServiceResponse<ItemAddDTO> response = _itemService.AddItem(itemDTO);
            response.Succcess = false;
            response.Message = "The item could not be added";
            if (response.Data is not null)
            {
                response.Succcess = true;
                response.Message = "The item has been added";
            }
            return Ok(response);
        }
        [Route("/Delete/{id}")]
        [HttpDelete]
        public ActionResult<List<ItemDTO>> DeleteItem(int id)
        {
            ServiceResponse<ItemDTO> response = _itemService.DeleteItem(id);
            response.Succcess = false;
            response.Message = "The item could not be deleted";
            if (response.Data is not null)
            {
                response.Succcess = true;
                response.Message = "The item has been deleted";
            }
            return Ok(response);
        }
        [Route("/Update")]
        [HttpPut]
        public ActionResult<ItemDTO> DeleteItem(ItemDTO itemDTO)
        {
            ServiceResponse<ItemDTO> response = _itemService.UpdateItem(itemDTO);
            response.Succcess = false;
            response.Message = "The item could not be updated";
            if (response.Data is not null)
            {
                response.Succcess = true;
                response.Message = "The item has been updated";
            }
            return Ok(response);
        }
    }
}
