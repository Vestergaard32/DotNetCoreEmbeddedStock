namespace EmbeddedStock.Models
{
    public class ComponentTypeCategory
    {
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public long ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }
    }
}