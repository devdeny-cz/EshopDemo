using EshopDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EshopDemoModel.Test
{
    /// <summary>
    /// Test all attribute validations
    /// </summary>
    [TestClass]
    public class ProductValidationTest
    {
        [TestMethod]
        public void Product_NameIsRequiredTest()
        {
            var product = new Product()
            {
                ImgUri = new System.Uri("http://abc.cz"),
                Price = 1
            };

            Assert.IsTrue(Validate(product).
                All(v => v.ErrorMessage.Equals("Name is required")
                ));
        }

        [TestMethod]
        public void Product_IsNotForFreeTest()
        {
            var product = new Product()
            {
                Name = "Test",
                ImgUri = new System.Uri("http://abc.cz"),
                Price = 0
            };
            Assert.IsTrue(Validate(product).
                All(v => v.ErrorMessage.Equals("Product can't be for free.")
                ));
        }

        [TestMethod]
        public void Product_UriIsRequiredTest()
        {
            var product = new Product()
            {
                Name = "xyz",
                Price = 1
            };
            Assert.IsTrue(Validate(product).
                All(v => v.ErrorMessage.Equals("Image url is required")
                ));
        }


        private static IEnumerable<ValidationResult> Validate(object obj)
        {
            var validationContext = new ValidationContext(obj, null, null);
            var validResult = new List<ValidationResult>();
            Validator.TryValidateObject(obj, validationContext, validResult, true);
            return validResult;
        }
    }
}
