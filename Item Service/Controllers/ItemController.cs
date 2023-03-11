﻿using Item_Service.DTO;
using Item_Service.Response;
using Item_Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Item_Service.Controllers

{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    
    public class ItemController : ControllerBase
    {

        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<ItemDTO> Get()
        {
            ServiceResponse<List<ItemDTO>> response = _itemService.GetAll();
            response.Success = false;
            response.Message = "The item list is empty";
            if (response.Data is not null)
            {
                response.Success = true;
                response.Message = "";
            }
            return Ok(response);
        }


        [HttpGet("{id}")]
        public ActionResult<List<ItemDTO>> Get(int id)
        {
            ServiceResponse<ItemDTO> response = _itemService.GetById(id);
            response.Success = false;
            response.Message = "The item " + id + " could not be found";
            if (response.Data is not null)
            {
                response.Success = true;
                response.Message = "";
            }
            return Ok(response);
        }

  
        [HttpGet("")]
        public ActionResult<List<ItemDTO>> SearchItem(string query)
        {
            ServiceResponse<List<ItemDTO>> response = _itemService.SearchItem(query);
            response.Success = false;
            response.Message = "The item list is empty";
            if (response.Data is not null)
            {
                response.Success = true;
                response.Message = "";
            }
            return Ok(response);
        }



        [HttpPost]
        public ActionResult<List<ItemDTO>> AddItem(ItemAddDTO itemDTO)
        {
            ServiceResponse<ItemAddDTO> response = _itemService.AddItem(itemDTO);
            response.Success = false;
            response.Message = "The item could not be added";
            if (response.Data is not null)
            {
                response.Success = true;
                response.Message = "The item has been added";
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<ItemDTO>> DeleteItem(int id)
        {
            ServiceResponse<ItemDTO> response = _itemService.DeleteItem(id);
            response.Success = false;
            response.Message = "The item could not be deleted";
            if (response.Data is not null)
            {
                response.Success = true;
                response.Message = "The item has been deleted";
            }
            return Ok(response);
        }
    
        [HttpPut]
        public ActionResult<ItemDTO> UpdateItem(ItemDTO itemDTO)
        {
            ServiceResponse<ItemDTO> response = _itemService.UpdateItem(itemDTO);
            response.Success = false;
            response.Message = "The item could not be updated";
            if (response.Data is not null)
            {
                response.Success = true;
                response.Message = "The item has been updated";
            }
            return Ok(response);
        }
    }
}
