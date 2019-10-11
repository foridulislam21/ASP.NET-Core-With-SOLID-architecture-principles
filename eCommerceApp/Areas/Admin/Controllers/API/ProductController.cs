using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceApp.Abstractions.BLL;
using eCommerceApp.Models;
using eCommerceApp.Models.ApiViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Areas.Admin.Controllers.API
{
    [FormatFilter]
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        public IActionResult Get([FromQuery] ProductSearchCriteriaVm productSearchCriteria)
        {
            var products = _productManager.GetByCriteria(productSearchCriteria);
            if (products.Any())
            {
                return Ok(products);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var product = await _productManager.GetById(id);
            if (product == null)
            {
                return BadRequest("No Product Found!");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _productManager.Add(product);
                if (isAdded)
                {
                    return Created("/api/products" + product.Id, product);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Product model)
        {
            var product = await _productManager.GetById(id);
            if (product == null)
            {
                return BadRequest("No Product Found As Updated!");
            }

            if (ModelState.IsValid)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;
                product.IsActive = model.IsActive;
                product.ExpireDate = model.ExpireDate;
                product.Image = model.Image;
                product.Description = model.Description;

                bool isUpdated = await _productManager.Update(product);
                if (isUpdated)
                {
                    return Ok("Update Successfully");
                }
            }
            else
            {
                return BadRequest("No Product Found!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var product = await _productManager.GetById(id);
            if (product == null)
            {
                return BadRequest("No Product Found As Deleted!");
            }

            bool isRemove = await _productManager.Remove(product);
            if (isRemove)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}