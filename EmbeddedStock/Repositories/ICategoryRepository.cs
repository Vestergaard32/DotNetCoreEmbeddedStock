using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    public interface ICategoryRepository
    {
        void CreateCategory(string categoryName);
        void DeleteCategory(long categoryId);
        void UpdateCategory(long categoryId, string newCategoryName);
        Category GetCategory(long categoryId);
    }
}