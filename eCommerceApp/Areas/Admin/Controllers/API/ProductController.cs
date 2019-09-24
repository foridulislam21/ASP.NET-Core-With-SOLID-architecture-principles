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
            var products = _productManager.GetByCriteria(productSearchCriteria).Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                p.ExpireDate,
                Category = new
                {
                    CategoryId = p.Category.Id,
                    CategoryName = p.Category.Name
                }
            });
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
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;
                product.ExpireDate = model.ExpireDate;
                product.IsActive = model.IsActive;
                product.Image = model.Image;

                bool isUpdated = await _productManager.Update(product);
                if (isUpdated)
                {
                    return Ok();
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
        }
    }
}