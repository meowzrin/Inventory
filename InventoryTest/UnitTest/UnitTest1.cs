using Inventory.controller;
using Inventory.DAL;
using Inventory.domain;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace InventoryTest
{
    public class Tests
    {
        private Mock<IProductDal> _productDal;
        private Mock<ILogger<InventoryController>> _log;

        [SetUp]
        public void Setup()
        {
            _productDal = new Mock<IProductDal>();
            _log = new Mock<ILogger<InventoryController>>();
        }
        [Test]
        public void getRouteTest()
        {
            InventoryController ic = new InventoryController(_productDal.Object, _log.Object);
            List<Products> product;
            using (StreamReader r = new StreamReader(@"C:\Users\Trinita\source\repos\Inventory\InventoryTest\UnitTest\sample.json"))
            {
                string json = r.ReadToEnd();
                product = JsonConvert.DeserializeObject<List<Products>>(json);
            }
            _productDal.Setup(x => x.fetchProducts()).Returns(product);

            var res = ic.getProducts();

            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).StatusCode);
        }
    }
}
