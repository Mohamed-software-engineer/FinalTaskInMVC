using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalTask.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Required.")]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Category Description")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
