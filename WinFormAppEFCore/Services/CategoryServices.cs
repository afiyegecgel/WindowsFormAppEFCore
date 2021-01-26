using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormAppEFCore.Data;
using WinFormAppEFCore.Models;

namespace WinFormAppEFCore.Services
{
    class CategoryServices
    {
        StoreDBContext context = new StoreDBContext();
        public List<Categories> GetCategories()
        {
            return context.Categories.ToList();
        }

        public Categories GetCategoriesById(int id)
        {
            return context.Categories.Find(id);
        }


        /// <summary>
        /// Kategori nesnesi alarak yeni kategori ekler. Döndürdüğü int değeri ile başarılı/başarısız durumu kontrol edilebilir.
        /// </summary>
        public int AddCategory(Categories categories)
        {
            context.Categories.Add(categories);
            return context.SaveChanges();
        }

        public int UpdateCategory(Categories categories)
        {
            context.Entry(categories).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public int DeleteCategory(Categories categories)
        {
            context.Categories.Remove(categories);
            return context.SaveChanges();
        }
    }
}
