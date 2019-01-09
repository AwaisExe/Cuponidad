using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Cuponidad.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace Cuponidad.DataAccessLayer.Repository
{
    public class BannerRepository
    {
        static CuponContext context = new CuponContext();
        public static List<RightBanner> RightBannerList()
        {
            List<RightBanner> rightBanners = null;
            rightBanners = context.RightBanners
                         .Include(a => a.Product)
                         .Include(a => a.Product.Company)
                         .Include(a => a.Product.Category)
                         .Include(a => a.Product.Category.Family)
                         .ToList();
            return rightBanners;
        }
    }
}
