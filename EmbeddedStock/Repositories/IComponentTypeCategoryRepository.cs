using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    public interface IComponentTypeCategoryRepository
    {
        void CreateComponentTypeCategory(ComponentType componentType, Category category);
    }
}