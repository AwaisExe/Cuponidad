using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cuponidad.DataAccessLayer.Model
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
