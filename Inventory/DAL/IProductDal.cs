using Inventory.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.DAL
{
    public interface IProductDal
    {
        IEnumerable<Products> fetchProducts();
        Products insertProduct(Products newProduct);
        Products DeleteData(int id);
        Products editProduct( Products updatedProduct);
        Products fetchProductsById(int id);
    }
}
