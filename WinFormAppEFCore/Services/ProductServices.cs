using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormAppEFCore.Data;
using WinFormAppEFCore.Models;

namespace WinFormAppEFCore.Services
{
    class ProductServices
    {
        StoreDBContext context = new StoreDBContext();

        public List<Products> GetProducts()
        {
            var products = context.Products
                .Select(m => new Products()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Description = m.Description,
                    CategoryName = m.Category.Name
                }).ToList();

            return products;
        }

        public Products GetProductsById(int id)
        {
            return context.Products.Find(id);
        }

        /// <summary>
        /// Alınan CategoryID ile ilgili ürünleri getirir..
        /// </summary>
        public List<Products> GetProductsByCategory(int categoryId)
        {
            var products = context.Products.Select(m => new Products()
            {
                Id = m.Id,
                Name = m.Name,
                Price = m.Price,
                Description = m.Description,
                CategoryId = m.Category.Id,
                CategoryName = m.Category.Name
            }).Where(a => a.CategoryId == categoryId).ToList();
            return products;
        }

        /// <summary>
        /// Ürün nesnesi alarak yeni ürün ekler.
        /// </summary>
        public void AddProduct(Products products)
        {
            //var category = context.Categories.Where(m => m.Name == products.CategoryName).FirstOrDefault();
            //products.Category = category;
            context.Products.Add(products);
            context.SaveChanges();
        }

        /// <summary>
        /// Ürün nesnesi alarak ürün bilgilerini günceller.
        /// </summary>
        public void UpdateProduct (Products products)
        {
            context.Entry(products).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteProduct (Products products)
        {
            context.Products.Remove(products);
            context.SaveChanges();
        }
    }
}
