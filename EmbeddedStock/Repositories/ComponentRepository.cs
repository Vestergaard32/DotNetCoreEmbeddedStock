using System.Collections.Generic;
using System.Linq;
using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        public void CreateComponent(Component component)
        {
            using (var db = new DatabaseContext())
            {
                db.Components.Add(component);
                db.SaveChanges();
            }
        }

        public void DeleteComponent(long componentId)
        {
            using (var db = new DatabaseContext())
            {
                db.Components.Remove(db.Components.Find(componentId));
                db.SaveChanges();
            }
        }

        public void UpdateComponent(Component updatedComponent)
        {
            using (var db = new DatabaseContext())
            {
                var oldComponent = db.Components.Find(updatedComponent.ComponentId);
                db.Entry(oldComponent).CurrentValues.SetValues(updatedComponent);
                db.SaveChanges();
            }
        }

        public Component GetComponent(long componentId)
        {
            using (var db = new DatabaseContext())
            {
                return db.Components.Find(componentId);
            }
        }

        public List<Component> GetComponentsWithComponentType(long componentTypeId)
        {
            using (var db = new DatabaseContext())
            {
                var query = db.Components.AsQueryable();
                var components = query.Where(component => Equals(component.ComponentTypeId, componentTypeId)).ToList();
                return components;
            }
        }

        public List<Component> GetAllComponents()
        {
            using (var db = new DatabaseContext())
            {
                return db.Components.ToList();
            }
        }
    }
}