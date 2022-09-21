using E_GroceryStoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStoreWebApi.Core.Interface
{
    public interface ICategory
    {
        List<CategoryModel> Get();
        CategoryModel Post(CategoryModel category);
        CategoryModel Put(CategoryModel category);
        bool Delete(int categoryId);
    }
}
