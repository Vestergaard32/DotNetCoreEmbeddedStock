using System.Collections.Generic;

namespace EmbeddedStock.Models
{
    public class CategoryViewModel
    {
        public string Title { get; set; } = null;
        public Category CurrentCategory { get; set; }
        public List<Category> AllCategories { get; set; }
    }
}