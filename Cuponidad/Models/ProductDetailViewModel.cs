using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuponidad.DataAccessLayer.Model;
using Cuponidad.DataAccessLayer.Repository;

namespace Cuponidad.Models
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel(int productID = 0, int familyID = 0, int categoryID = 0, SortingEnum DropDown = 0)
        {
            if (productID > 0) ProductRead(productID);
            if (categoryID > 0)
            {
                ProductListByCategory(categoryID, DropDown);
            }
            else
            {
                ProductList(DropDown);
            }

            CategoryList();
            FamilyRead(familyID);
            FamilyList();
        }
        public Product Product { get; set; }
        public Family Family { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Family> Families { get; set; }
        public int DropDownID { get; set; }

        private void ProductRead(int productID)
        {
            Product = ProductRepository.Read(productID);
            Product.DiscountAmount = string.Format("{0:0.##}", (Product.Prize - ((Product.Prize * Product.Discount) / 100)));
        }
        private void FamilyRead(int familyID)
        {
            Family = FamilyRepository.Read(familyID);
        }
        private void ProductList(SortingEnum DropDown)
        {
            Products = ProductRepository.List();
            if (DropDown == SortingEnum.MostSold)
            {
                Products = (Products.OrderByDescending(x => x.QuantitySold)).ToList();
            }
            else if (DropDown == SortingEnum.HigherPrize)
            {
                Products = (Products.OrderByDescending(x => x.Prize)).ToList();
            }
            else if (DropDown == SortingEnum.LowerPrize)
            {
                Products = (Products.OrderBy(x => x.Prize)).ToList();
            }
            else if (DropDown == SortingEnum.Last)
            {
                Products = (Products.OrderByDescending(x => x.ProductID)).ToList();
            }
            foreach (var item in Products)
            {
                item.DiscountAmount = string.Format("{0:0.##}", (item.Prize - ((item.Prize * item.Discount) / 100)));

                if (item.Description.Length > 77)
                {
                    item.Description = item.Description.Substring(0, 77);
                }
            }
        }
        private void ProductListByCategory(int categoryID, SortingEnum DropDown = 0)
        {
            Products = ProductRepository.ListByCategory(categoryID);
            if (DropDown == SortingEnum.MostSold)
            {
                Products = (Products.OrderByDescending(x => x.QuantitySold)).ToList();
            }
            else if(DropDown == SortingEnum.HigherPrize)
            {
                Products = (Products.OrderByDescending(x => x.Prize)).ToList();
            }
            else if (DropDown == SortingEnum.LowerPrize)
            {
                Products = (Products.OrderBy(x => x.Prize)).ToList();
            }
            else if (DropDown == SortingEnum.Last)
            {
                Products = (Products.OrderByDescending(x => x.ProductID)).ToList();
            }
            foreach (var item in Products)
            {
                item.DiscountAmount = string.Format("{0:0.##}", (item.Prize - ((item.Prize * item.Discount) / 100)));

                if (item.Description.Length > 77)
                {
                    item.Description = item.Description.Substring(0, 77);
                }
            }
        }
        private void CategoryList()
        {
            Categories = CategoryRepository.List();
        }
        private void CategoryListByID(int categoryID)
        {
            Categories = CategoryRepository.ListByCategoryID(categoryID);
        }
        private void FamilyList()
        {
            Families = FamilyRepository.List();
        }
    }
}
