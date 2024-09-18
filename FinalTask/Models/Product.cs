using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTask.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Title is Required.")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Price is Required.")]
        [Column(TypeName = "decimal(8,2)")]
        public double Price { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is Required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [DisplayName("Product Quantity")]
        public int Quantity { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
