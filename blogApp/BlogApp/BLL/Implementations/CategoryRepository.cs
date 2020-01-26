using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private BlogDbContext _blogDbContext;
        private bool disposed = false;

        public CategoryRepository(BlogDbContext dbContext)
        {
            _blogDbContext = dbContext;
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = _blogDbContext.Categories.Find(categoryId);

            if (category != null)
            {
                _blogDbContext.Categories.Remove(category);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _blogDbContext.Dispose();
            }
            disposed = true;
        }

        public List<Category> GetCategories()
        {
            return _blogDbContext.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _blogDbContext.Categories.Find(categoryId);
        }

        public void InsertCategory(Category category)
        {
            if(category != null)
            {
                _blogDbContext.Categories.Add(category);
            }
        }

        public async void SaveAsync()
        {
            await _blogDbContext.SaveChangesAsync();
        }

        public void Save()
        {
            _blogDbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            if (category != null)
            {
                _blogDbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
    }
}
