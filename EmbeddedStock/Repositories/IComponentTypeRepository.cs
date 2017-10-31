using System.Collections.Generic;
using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    public interface IComponentTypeRepository
    {
        long CreateComponentType(ComponentType componentToSave);
        void DeleteComponentType(long componentTypeId);
        void UpdateComponentType(ComponentType updatedComponentType);
        List<ComponentType> GetAllComponentTypes();
        ComponentType GetComponentType(long componentTypeId);
        List<ComponentType> GetComponentTypesWithCategory(long categoryId);
    }
}