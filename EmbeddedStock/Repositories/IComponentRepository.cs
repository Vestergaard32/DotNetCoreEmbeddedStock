using System.Collections.Generic;
using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    public interface IComponentRepository
    {
        void CreateComponent(Component component);
        void DeleteComponent(long componentId);
        void UpdateComponent(Component updatedComponent);
        Component GetComponent(long componentId);
        List<Component> GetComponentsWithComponentType(long componentTypeId);
        List<Component> GetAllComponents();
    }
}