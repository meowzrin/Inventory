using Inventory.domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Inventory.DAL
{
    public class ProductDal : IProductDal
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ProductDal> _logger;
        public ProductDal(AppDbContext context, ILogger<ProductDal> logger)
        {
            _dbContext = context;
            _logger = logger;
        }
        public   IEnumerable<Products> fetchProducts()
        {
            return  _dbContext.products;
        }

        public Products insertProduct(Products newProduct)
        {
            try
            {
                _dbContext.products.Add(newProduct);
                _dbContext.SaveChanges();
            }
            catch (Exception  e)
            {
                _logger.LogError("Error info" + e);
            }
           
            return newProduct;
        }

        public Products DeleteData(int id)
        {
            Products product = _dbContext.products.Find(id);
            try
            {
                if (product != null)
                {
                    _dbContext.Remove(product);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error info" + e);
            }
            
            return product;
        }
        public  Products fetchProductsById(int id)
        {
            return _dbContext.products.Find(id);
        }
        public Products editProduct(Products updatedProduct)
        {
            try
            {
                var prod = _dbContext.products.Attach(updatedProduct);
                prod.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
           catch(Exception e)
            {
                _logger.LogError("Error info" + e);
            }
            return updatedProduct;

        }
    }
}
