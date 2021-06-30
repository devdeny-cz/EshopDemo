using EshopDemo;
using EshopDemo.BLL;
using EshopDemo.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopDemoService.Test
{
    /// <summary>
    /// Unit test of product controller for main crud function
    /// For test is using: 
    /// Moq - fakeking entities and injection false dependency
    /// FluentAsstertion - for equal result like object (compare parameter by parameter)
    /// </summary>
    [TestClass]
    public class ProductControllerTest
    {
        // person note: if class contains a lot of test, we can split main class by test part for example ProcutControllerGetOneTest, ProductControllerGetAllTest, and so on.
        // Or we can use Partial class for better readability 

        #region GetOne

        /// <summary>
        /// Test get one product by id - successfull
        /// </summary>
        [TestMethod]
        public void GetOneTest()
        {
            var fakeProduct = new Product()
            {
                Id = 1,
                Name = "Book Clean Code"
            };
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAsync(1)).Returns(Task.FromResult<Product>(fakeProduct));
            var productController = new ProductController(uowMoq.Object);
            var result = productController.Get(1);
            result.Result.Should().BeEquivalentTo(new JsonResult(fakeProduct));
        }

        /// <summary>
        /// Test get one not exist product by id
        /// </summary>
        [TestMethod]
        public void GetOne_NotExistingProductTest()
        {
            var fakeProduct = new Product()
            {
                Id = 1,
                Name = "Book Clean Code"
            };
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAsync(1)).Returns(Task.FromResult<Product>(fakeProduct));
            var productController = new ProductController(uowMoq.Object);
            var result = productController.Get(2);
            result.Result.Should().BeEquivalentTo(new NotFoundObjectResult("Product 2 not found"));
        }

        /// <summary>
        /// Test get one not exist product by id
        /// </summary>
        [TestMethod]
        public void GetOne_ExceptionTest()
        {
            var fakeProduct = new Product()
            {
                Id = 1,
                Name = "Book Clean Code"
            };
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAsync(1)).Throws(new System.Exception("Any exception"));
            var productController = new ProductController(uowMoq.Object);
            var result = productController.Get(1);
            result.Result.Should().BeEquivalentTo(new BadRequestObjectResult("Unhandled exception"));
        }



        #endregion

        #region GetAll

        /// <summary>
        /// Test getting all existing product - succesfully
        /// </summary>
        [TestMethod]
        public void GetAllTest()
        {
            var fakeProducts = new List<Product>()
            {
                new Product(){Id = 1,Name = "TV", Price = 18000 },
                new Product(){Id = 2,Name = "Fruit", Price = 50 },
                new Product(){Id = 3,Name = "Printer",Price = 700 },
                new Product(){Id = 4,Name = "MS Office",Price = 2500 }
            };

            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAllAsync()).Returns(Task.FromResult<IEnumerable<Product>>(fakeProducts));
            var productController = new ProductController(uowMoq.Object);
            var result = productController.GetAll();
            result.Result.Should().BeEquivalentTo(new JsonResult(fakeProducts));
        }

        /// <summary>
        /// Test getting all existing product - succesfully
        /// </summary>
        [TestMethod]
        public void GetAll_NotExistAnyTest()
        {
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAllAsync()).Returns(Task.FromResult<IEnumerable<Product>>(new List<Product>()));
            var productController = new ProductController(uowMoq.Object);
            var result = productController.GetAll();
            result.Result.Should().BeEquivalentTo(new NotFoundObjectResult("Not exist any products"));
        }


        /// <summary>
        /// Test getall with internal any exception
        /// </summary>
        [TestMethod]
        public void GetAll_ExceptionTest()
        {
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAllAsync()).Throws(new System.Exception("Any exception"));
            var productController = new ProductController(uowMoq.Object);
            var result = productController.GetAll();
            result.Result.Should().BeEquivalentTo(new BadRequestObjectResult("Unhandled exception"));
        }

        #endregion


        #region Update
        [TestMethod]
        public void UpdateProductTest()
        {
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAsync(1)).Returns(Task.FromResult<Product>(new Product() { Id = 1, Description = "Old description" }));
            uowMoq.Setup(uow => uow.ProductRepository.UpdateAsync(It.IsAny<Product>())).Returns(Task.FromResult<bool>(true));
            var productController = new ProductController(uowMoq.Object);
            var result = productController.Update(1, "new description");
            result.Result.Should().BeEquivalentTo(new OkResult());
        }

        [TestMethod]
        public void UpdateProduct_NotExistingProductTest()
        {
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAsync(1)).Returns(Task.FromResult<Product>(new Product() { Id = 1, Description = "Old description" }));
            var productController = new ProductController(uowMoq.Object);
            var result = productController.Update(2, "new description");
            result.Result.Should().BeEquivalentTo(new NotFoundObjectResult("Can't update not existing product"));
        }

        [TestMethod]
        public void UpdateProduct_InvalidUpdateTest()
        {
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAsync(1)).Returns(Task.FromResult<Product>(new Product() { Id = 1, Description = "Old description" }));
            uowMoq.Setup(uow => uow.ProductRepository.UpdateAsync(It.IsAny<Product>())).Returns(Task.FromResult<bool>(false));
            var productController = new ProductController(uowMoq.Object);
            var result = productController.Update(1, "new description");
            result.Result.Should().BeEquivalentTo(new BadRequestObjectResult("Update product ended unhandled exception"));
        }

        [TestMethod]
        public void UpdateProduct_UnhandledExceptionTest()
        {
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(uow => uow.ProductRepository.GetAsync(1)).Throws(new System.Exception());
            var productController = new ProductController(uowMoq.Object);
            var result = productController.Update(1, "new description");
            result.Result.Should().BeEquivalentTo(new BadRequestObjectResult("Unhandled exception during update"));
        } 
        #endregion


    }
}
