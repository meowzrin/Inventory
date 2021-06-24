using Inventory.DAL;
using Inventory.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.controller
{
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IProductDal _productDal;
        public InventoryController(IProductDal productBl, ILogger<InventoryController> logger)
        {
            _productDal = productBl;
            _logger = logger;
        }

        [HttpGet]
        [Route("Inventory/getProducts")]
        [ProducesResponseType(200, Type = typeof(Products))]
        [ProducesResponseType(404)]
        public  ActionResult<Products> getProducts()
        {

            IEnumerable<Products> response;

            
            response =  _productDal.fetchProducts();

            return Ok(response);
        }

        [HttpPost]
        [Route("Inventory/addProducts")]
        public ActionResult<Products> AddProducts([FromBody] Products newProduct)
        {
            _productDal.insertProduct(newProduct);
            return Ok(newProduct);
        }


        [HttpPut]
        [Route("Inventory/editProducts/{id}")]
        [ProducesResponseType(200, Type = typeof(Products))]
        [ProducesResponseType(404)]
        public ActionResult<Products> UpdateProduct(int id,[FromBody]Products updatedProduct)
        {
            Products updateProd = _productDal.fetchProductsById(id);
            try
            {
                updateProd.Name = updatedProduct.Name;
                updateProd.Description = updatedProduct.Description;
                updateProd.Price = updatedProduct.Price;
                _productDal.editProduct(updateProd);
            }
            catch (Exception e)
            {
                _logger.LogError("Error info" + e);
            }
           
           
          
         
            return updateProd;
        }

        [HttpDelete]
        [Route("Inventory/removeProducts/{id}")]
        [ProducesResponseType(200, Type = typeof(Products))]
        [ProducesResponseType(404)]
        public Products DeleteProduct(int id)
        {
            Products deleteProducts = _productDal.DeleteData(id);
            return deleteProducts;
        }

    }
}
