using Cuponidad.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Cuponidad.DataAccessLayer.Repository
{
    public class CategoryRepository
    {
        static CuponContext context = new CuponContext();
        public static List<Category> List()
        {
            List<Category> categories = null;
            categories = (from a in context.Categories select a).ToList();
            return categories;
        }
        public static List<Category> ListByFamily(int FamilyID)
        {
            List<Category> Categories = null;
            Categories = (from a in context.Categories where a.FamilyID == FamilyID
                          select a).ToList();
            return Categories;
        }
        public static List<Category> ListByCategoryID(int CategoryID)
        {
            List<Category> Categories = null;
            Categories = (from a in context.Categories
                          where a.CategoryID == CategoryID
                          select a).ToList();
            return Categories;
        }
    }
}
