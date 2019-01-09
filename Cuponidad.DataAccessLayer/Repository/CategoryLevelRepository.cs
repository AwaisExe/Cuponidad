using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Cuponidad.DataAccessLayer.Model;

namespace Cuponidad.DataAccessLayer.Repository
{
    public class CategoryLevelRepository
    {
        static CuponContext context = new CuponContext();
        public static List<CategoryLevel> List()
        {
            List<CategoryLevel> categoryLevels = null;
            categoryLevels = (from a in context.CategoryLevels select a).ToList();
            return categoryLevels;
        }
    }
}
