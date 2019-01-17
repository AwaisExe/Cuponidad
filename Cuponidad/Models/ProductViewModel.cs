using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuponidad.DataAccessLayer.Model;
using Cuponidad.DataAccessLayer.Repository;

namespace Cuponidad.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(int departmentID = 0)
        {
            if (departmentID > 0) ProductListByDepartment(departmentID);
            else ProductList();
            RightBannerList();
            CategoryLevelList();
            CategoryList();
            FamilyList();
        }
        public List<Product> Products { get; set; }
        public List<CategoryLevel> CategoryLevels { get; set; }
        public List<Category> Categories { get; set; }
        public List<Family> Families { get; set; }
        public List<RightBanner> RightBanners { get; set; }
        public List<DropDownListBydays> DropDownListBydays { get; set; }
        private void FamilyList()
        {
            Families = FamilyRepository.List();
        }
        private void ProductList()
        {
            Products = ProductRepository.List();
            foreach (var item in Products)
            {
                item.DiscountAmount = string.Format("{0:0.##}", (item.Prize - ((item.Prize * item.Discount) / 100)));

                if (item.Description.Length > 77)
                {
                    item.Description = item.Description.Substring(0, 77);
                }
            }
        }
        private void CategoryLevelList()
        {
            CategoryLevels = CategoryLevelRepository.List();
        }
        private void CategoryList()
        {
            Categories = CategoryRepository.List();
        }
        private void RightBannerList()
        {
            RightBanners = BannerRepository.RightBannerList();
            foreach (var item in RightBanners)
            {
                item.Product.DiscountAmount = string.Format("{0:0.##}", (item.Product.Prize - ((item.Product.Prize * item.Product.Discount) / 100)));

                if (item.Product.Description.Length > 60)
                {
                    item.Product.Description = item.Product.Description.Substring(0, 60);
                }
            }
        }

        private void ProductListByDepartment(int departmentID )
        {
            Products = ProductRepository.ListByDepartment(departmentID);
            foreach (var item in Products)
            {
                item.DiscountAmount = string.Format("{0:0.##}", (item.Prize - ((item.Prize * item.Discount) / 100)));

                if (item.Description.Length > 77)
                {
                    item.Description = item.Description.Substring(0, 77);
                }
            }
        }
    }
}
