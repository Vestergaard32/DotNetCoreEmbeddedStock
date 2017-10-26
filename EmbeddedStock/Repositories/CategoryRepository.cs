using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void CreateCategory(string categoryName)
        {
            var category = new Category { Name = categoryName };

            using (var db = new DatabaseContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(long categoryId)
        {
            using (var db = new DatabaseContext())
            {
                db.Categories.Remove(db.Categories.Find(categoryId));
                db.SaveChanges();
            }
        }

        public void UpdateCategory(long categoryId, string newCategoryName)
        {
            using (var db = new DatabaseContext())
            {
                var category = db.Categories.Find(categoryId);
                category.Name = newCategoryName;
                db.SaveChanges();
            }
        }

        public Category GetCategory(long categoryId)
        {
            using (var db = new DatabaseContext())
            {
                return db.Categories.Find(categoryId);
            }
        }
    }
}