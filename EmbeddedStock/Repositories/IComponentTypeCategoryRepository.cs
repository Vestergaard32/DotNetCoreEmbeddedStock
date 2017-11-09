using System.Collections.Generic;
using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    public interface IComponentTypeCategoryRepository
    {
        void CreateComponentTypeCategory(ComponentType componentType, Category category);
        List<ComponentType> GetComponentTypesForCategory(long categoryId);
        void ClearComponentTypeCategoriesForComponentType(long componentTypeId);
    }
}