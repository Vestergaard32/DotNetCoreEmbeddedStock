using System.Collections.Generic;
using System.Linq;
using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    public class ComponentTypeRepository : IComponentTypeRepository
    {
        public void CreateComponentType(ComponentType componentToSave)
        {
            using (var db = new DatabaseContext())
            {
                db.ComponentType.Add(componentToSave);
                db.SaveChanges();
            }
        }

        public void DeleteComponentType(long componentTypeId)
        {
            using (var db = new DatabaseContext())
            {
                db.ComponentType.Remove(db.ComponentType.Find(componentTypeId));
            }
        }

        public void UpdateComponentType(ComponentType updatedComponentType)
        {
            using (var db = new DatabaseContext())
            {
                var dbComponent = db.ComponentType.Find(updatedComponentType.ComponentTypeId);
                db.Entry(dbComponent).CurrentValues.SetValues(updatedComponentType);
                db.SaveChanges();
            }
        }

        public ComponentType GetComponentType(long componentTypeId)
        {
            using (var db = new DatabaseContext())
            {
                return db.ComponentType.Find(componentTypeId);
            }
        }

        public List<ComponentType> GetComponentTypesWithCategory(long categoryId)
        {
            using (var db = new DatabaseContext())
            {
                var listOfComponentTypeIds = db.ComponentTypeCategories
                    .Where(category => Equals(category.CategoryId, categoryId))
                    .Select(category => category.ComponentTypeId)
                    .Distinct()
                    .ToList();

                var result = db.ComponentType
                    .Where(type => listOfComponentTypeIds.Contains(type.ComponentTypeId))
                    .ToList();
                return result;
            }
        }
    }
}