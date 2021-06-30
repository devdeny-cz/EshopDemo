using EshopDemo.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Return product by id.
        /// </summary>
        /// <param name="id">id of product</param>
        /// <example>/api/Product/1 </example>
        /// <returns>Serialize product to json</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product =  await _unitOfWork.ProductRepository.GetAsync(id);
                if (product == null)
                {
                    return NotFound($"Product {id} not found");
                }

                return new JsonResult(product);
            }
            catch (Exception)
            {
                // log ex
                return BadRequest("Unhandled exception");
            }
        }

        /// <summary>
        /// Return all existing products
        /// </summary>
        /// <returns>Collection products serialized to json</returns>

        [HttpGet("Getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync();
                if (products == null || !products.Any())
                {
                    return NotFound($"Not exist any products");
                }

                return new JsonResult(products);
            }
            catch (Exception)
            {
                // log ex
                return BadRequest("Unhandled exception");
            }
        }


        /// <summary>
        /// Update choice proudt description to new
        /// </summary>
        /// <param name="id">id of product</param>
        /// <param name="description">new descripton</param>
        /// <returns>result</returns>
        [HttpPatch("Update/{id}")]
        public async Task<IActionResult> Update(int id, string description)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(id);
                if (product == null)
                {
                    return NotFound("Can't update not existing product");
                }
                product.Description = description;
                if (!await _unitOfWork.ProductRepository.UpdateAsync(product))
                {
                    return BadRequest("Update product ended unhandled exception");
                }

                _unitOfWork.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                // log ex
                return BadRequest("Unhandled exception during update");
            }
        }


    }
}
