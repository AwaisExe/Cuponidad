using Cuponidad.DataAccessLayer.Model;
using Cuponidad.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuponidad.Models
{
    public class CartVewModel
    {
        public CartVewModel(int userID = 0)
        {
            CartList(userID);
            ReadTotalAMount(userID);
            FamilyList();
            ProductList();
            
        }
        public decimal SubTotal { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Product> Products { get; set; }
        public List<Family> Families { get; set; }
        public int FamilyID { get; set; }

        private void CartList(int userID)
        {
            Carts = CartRepository.ListByUser(userID);
            foreach (var item in Carts)
            {
                item.Product.DiscountAmount = string.Format("{0:0.##}", (item.Product.Prize - ((item.Product.Prize * item.Product.Discount) / 100)));
                if (item.Product.Description.Length > 50)
                {
                    item.Product.Description = item.Product.Description.Substring(0, 50);
                }
            }
        }
        private void ReadTotalAMount(int userID)
        {
            TotalAmount = UserRepository.ReadTotalAmount(userID);
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
        private void FamilyList()
        {
            Families = FamilyRepository.List();
        }
    }
}
