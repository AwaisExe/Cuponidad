using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cuponidad.DataAccessLayer.Model
{

    public enum SortingEnum
    {
        [Display(Name = "Lo más vendido")]
        MostSold = 1,
        [Display(Name = "Lo último")]
        Last = 2,
        [Display(Name = "Mayor precio")]
        HigherPrize = 3,
        [Display(Name = "Menor precio")]
        LowerPrize = 4,
    }
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        public int CompanyID { get; set; }
        public int CategoryID { get; set; }
        public int DaysOpenID { get; set; }
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Prize { get; set; }
        public decimal Discount { get; set; }
        [NotMapped]
        public string DiscountAmount { get; set; }
        public string Terms { get; set; }
        public string DayUse { get; set; }
        public string Conditions { get; set; }
        public int QuantitySold { get; set; }
        public float Rating { get; set; }
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [ForeignKey("DaysOpenID")]
        public virtual DropDownListBydays DropDownListBydays { get; set; }
        
        public virtual Cart Cart { get; set; }
    }
}
