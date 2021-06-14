using EshopDemo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EshopDemo
{
    public class Product : IEntity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Image url is required")]
        public Uri ImgUri { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, Double.MaxValue, ErrorMessage = "Product can't be for free.")]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
