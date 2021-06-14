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
        /// <param name="id">id</param>
        /// <returns>Serialize product like json</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.Get(id);
                if (product == null)
                {
                    return BadRequest($"Product {id} not found");
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
                var products = _unitOfWork.ProductRepository.GetAll();
                if (products == null)
                {
                    return BadRequest($"Not exist any products");
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
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] string description)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.Get(id);
                if (product == null)
                {
                    return BadRequest("Can't update not existing product");
                }
                product.Description = description;
                if (!_unitOfWork.ProductRepository.Update(product))
                {
                    return BadRequest("Update produc ended unhandled exception ");
                }

                _unitOfWork.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                // log ex
                return BadRequest("Unhandled exception");
            }
        }


    }
}
