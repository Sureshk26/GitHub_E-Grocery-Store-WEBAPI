using E_GroceryStoreWebApi.Core.Interface;
using E_GroceryStoreWebApi.DataAccess;
using E_GroceryStoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStoreWebApi.Core.Repository
{
    public class Category : ICategory
    {
        public readonly GroceryStoreDbContext _context;
        public Category(GroceryStoreDbContext context)
        {
           _context = context;
        }
        public List<CategoryModel> Get()
        {
            var list = _context.category.ToList();
            return list;
        }
        public CategoryModel Post(CategoryModel model)
        {
            _context.category.AddAsync(model);
            _context.SaveChangesAsync();
            return model;
        }

        public CategoryModel Put(CategoryModel model)
        {
            var CategoryToEdit = _context.category.Where(x => x.CategoryId == model.CategoryId).FirstOrDefault();
            CategoryToEdit.CategoryId = model.CategoryId;
            CategoryToEdit.CategoryType = model.CategoryType;
            _context.SaveChanges();
            return CategoryToEdit;
        }
        
        public bool Delete(int CategoryId)
        {
            var Category = _context.category.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
            _context.category.Remove(Category);
            _context.SaveChanges();
            return true;
        }

    }
}
