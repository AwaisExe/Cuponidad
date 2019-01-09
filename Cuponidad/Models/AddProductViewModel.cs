using Cuponidad.DataAccessLayer.Model;
using Cuponidad.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuponidad.Models
{
    public class AddProductViewModel
    {
        public AddProductViewModel(int FamilyID = 0)
        {
            FamilyList();
            CompanyList();
            DepartmentList();
            CategoryLevelList();
            CategoryList(FamilyID);
            ListBydays();
        }
        public int CategoryLevelID { get; set; }
        public int FamilyID { get; set; }
        public Product Product { get; set; }
        public List<Family> Families { get; set; }
        public List<Company> Companies { get; set; }
        public List<Department> Departments { get; set; }
        public List<CategoryLevel> CategoryLevels { get; set; }
        public List<Category> Categories{ get; set; }
        public List<DropDownListBydays> DropDownListBydays { get; set; }

        private void FamilyList()
        {
            Families = FamilyRepository.List();
        }
        private void CompanyList()
        {
            Companies = CompanyRepository.List();
        }
        private void DepartmentList()
        {
            Departments = DropDownListRepository.DepartmenList();
        }
        private void CategoryLevelList()
        {
            CategoryLevels = CategoryLevelRepository.List();
        }
        private void CategoryList(int FamilyID)
        {
            Categories = CategoryRepository.ListByFamily(FamilyID);
        }
        private void ListBydays()
        {
            DropDownListBydays = DropDownListRepository.ListBydays();
        }
    }
}
