using Cuponidad.DataAccessLayer.Model;
using Cuponidad.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuponidad.Models
{
    public class SearchListViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Family> Families { get; set; }

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
    }
}
