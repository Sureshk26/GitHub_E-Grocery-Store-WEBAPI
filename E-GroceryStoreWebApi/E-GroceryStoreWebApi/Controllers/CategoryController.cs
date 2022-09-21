using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_GroceryStoreWebApi.DataAccess;
using E_GroceryStoreWebApi.Models;
using log4net;
using E_GroceryStoreWebApi.Core.Interface;

namespace E_GroceryStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryRepo;
        public CategoryController(ICategory Category)
        {
            _categoryRepo = Category;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _categoryRepo.Get();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] CategoryModel category)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var result = _categoryRepo.Post(category);
                    return StatusCode(200, result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] CategoryModel category)
        {
            try
            {
                var result = _categoryRepo.Put(category);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            try
            {
                var result = _categoryRepo.Delete(categoryId);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
