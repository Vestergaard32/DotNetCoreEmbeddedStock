using System.Collections.Generic;

namespace EmbeddedStock.Models
{
    public class Category
    {
        public Category()
        {
            ComponentTypes =  new List<ComponentTypeCategory>();    
        }

        public long CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ComponentTypeCategory> ComponentTypes { get; set; }
    }
}