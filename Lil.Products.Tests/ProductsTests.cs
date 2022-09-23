using Lil.Products.Controllers;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Customers.Tests
{
    [TestClass]
    public class ProductsTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var productsProvider = new ProductsProvider();
            var productsController = new ProductsController(productsProvider);

            var result = productsController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            var productsProvider = new ProductsProvider();
            var productsController = new ProductsController(productsProvider);

            var result = productsController.GetAsync("500").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}