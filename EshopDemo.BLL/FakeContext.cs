using System;
using System.Collections.Generic;
using System.Text;

namespace EshopDemo.BLL
{
    internal class FakeContext
    {
        public IList<Product> Products { get; private set; }

        internal FakeContext()
        {
            // We can use any framework like FakeItEasy and so on.. But just for example 
            Products = new List<Product>()
            {
                new Product(){Id = 1,ImgUri = new Uri("http://www.test.com/"),Name="Mobile Samsung",Price = 165},
                new Product(){Id = 2,ImgUri = new Uri("http://www.test.com/"),Name="TV LG",Price = 165000},
                new Product(){Id = 3,ImgUri = new Uri("http://www.test.com/"),Name="Monitor Benq ",Price = 8000},
                new Product(){Id = 4,ImgUri = new Uri("http://www.test.com/"),Name="PC mouse Logitech",Price = 100},
            };
        }
    }
}
