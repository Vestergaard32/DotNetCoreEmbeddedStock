using System.Collections.Generic;
using System.Linq;
using EmbeddedStock.Models;
using Microsoft.EntityFrameworkCore;

namespace EmbeddedStock.Repositories
{
    public class ComponentTypeCategoryRepository : IComponentTypeCategoryRepository
    {
        public void CreateComponentTypeCategory(ComponentType componentType, Category category)
        {
            using (var db = new DatabaseContext())
            {
                db.ComponentTypeCategories.Add(new ComponentTypeCategory()
               {
                    ComponentTypeId = componentType.ComponentTypeId,
                    CategoryId = category.CategoryId
                });

                db.SaveChanges();
            }
        }

        public List<ComponentType> GetComponentTypesForCategory(long categoryId)
        {
            using (var db = new DatabaseContext())
            {
                List<ComponentType> results =  db.ComponentTypeCategories
                    .Include(category => category.ComponentType)
                    .Where(category => Equals(category.CategoryId, categoryId))
                    .Select(category => category.ComponentType)
                    .ToList();
                return results;
            }
        }
    }
}