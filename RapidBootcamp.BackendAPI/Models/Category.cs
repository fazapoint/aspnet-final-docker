using System.ComponentModel.DataAnnotations;

namespace RapidBootcamp.BackendAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        //navigation property
        public IEnumerable<Product>? Products { get; set; }
    }
}
