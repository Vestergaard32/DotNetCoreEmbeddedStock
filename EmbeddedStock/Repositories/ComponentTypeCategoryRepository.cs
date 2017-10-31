using EmbeddedStock.Models;

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
    }
}