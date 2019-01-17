using System;
using System.Collections.Generic;
using Cuponidad.DataAccessLayer.Model;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Cuponidad.DataAccessLayer.Repository
{
    public class ProductRepository
    {
        static CuponContext context = new CuponContext();
        public static void Insert(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }
        public static List<Product> List()
        {
            List<Product> products = null;
            products = context.Products
                        .Include(a => a.Company)
                        .Include(a => a.Category)
                        .Include(a => a.DropDownListBydays)
                        .ToList();
            return products;
        }
        public static List<Product> ListByFamily(int FamilyID)
        {
            List<Product> products = null;
            products = context.Products
                         .Include(a => a.Company)
                         .Include(a => a.Category)
                         .Where(a => a.CategoryID == context.Categories.SingleOrDefault(family => family.FamilyID == FamilyID).CategoryID)
                         .ToList();
            return products;
        }
        public static List<Product> ListByCategory(int categoryID)
        {
            List<Product> products = null;
            products = (from a in context.Products where a.CategoryID == categoryID select a).ToList();
            return products;
        }
        public static List<Product> ListBySearch(string searchText)
        {
            List<Product> products = null;
            products = context.Products
                         .Include(a => a.Company)
                         .Include(a => a.Category)
                         .Include(a => a.Category.Family)
                         .Where(a => a.Description.Contains(searchText) || a.Company.Direction == searchText || a.Name == searchText)
                         .ToList();
            return products;
        }
        public static List<Product> ListByDepartment(int departmentID)
        {
            List<Product> products = null;
            products = context.Products
                         .Include(a => a.Company)
                         .Include(a => a.Category)
                         .Include(a => a.Category.Family)
                         .Include(a => a.DropDownListBydays)
                         .Where(a => a.DepartmentID == departmentID)
                         .ToList();
            return products;
        }
        public static Product Read(int ProductID)
        {
            Product product = null;
            product = context.Products
                        .Include(a => a.Company)
                        .Include(a => a.Category)
                        .Where(a => a.ProductID == ProductID)
                        .FirstOrDefault();
            return product;
        }
    }
}
