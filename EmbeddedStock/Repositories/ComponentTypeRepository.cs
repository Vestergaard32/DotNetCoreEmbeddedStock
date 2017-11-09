using System.Collections.Generic;
using System.Linq;
using EmbeddedStock.Models;
using Microsoft.EntityFrameworkCore;

namespace EmbeddedStock.Repositories
{
    public class ComponentTypeRepository : IComponentTypeRepository
    {
        public long CreateComponentType(ComponentType componentToSave)
        {
            using (var db = new DatabaseContext())
            {
                db.ComponentType.Add(componentToSave);
                db.SaveChanges();
            }

            return componentToSave.ComponentTypeId;
        }

        public void DeleteComponentType(long componentTypeId)
        {
            using (var db = new DatabaseContext())
            {
                db.ComponentType.Remove(db.ComponentType.Find(componentTypeId));
                db.SaveChanges();
            }
        }
        
        public void UpdateComponentType(ComponentType updatedComponentType)
        {
            using (var db = new DatabaseContext())
            {
                var dbComponent = db.ComponentType
                    .Include(type => type.Image)
                    .FirstOrDefault(type => Equals(type.ComponentTypeId, updatedComponentType.ComponentTypeId));
                db.Entry(dbComponent).CurrentValues.SetValues(updatedComponentType);

                if (dbComponent.Image != null)
                {
                    var image = db.EsImages.Find(dbComponent.Image.ESImageId);
                    image.ImageData = updatedComponentType.Image.ImageData;
                } else
                {
                    dbComponent.Image = updatedComponentType.Image;
                }

                db.SaveChanges();
            }
        }

        public List<ComponentType> GetAllComponentTypes()
        {
            using (var db = new DatabaseContext())
            {
                return db.ComponentType.ToList();
            }
        }

        public ComponentType GetComponentType(long componentTypeId)
        {
            using (var db = new DatabaseContext())
            {
                return db.ComponentType
                    .Include(ct => ct.Image)
                    .FirstOrDefault(c => c.ComponentTypeId == componentTypeId);
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