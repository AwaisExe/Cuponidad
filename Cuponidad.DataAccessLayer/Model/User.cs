using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cuponidad.DataAccessLayer.Model
{
    public enum UserGender : int
    {
        Male = 1,
        Female = 2
    }
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        public string CellPhone { get; set; }
        public decimal TotalAmount { get; set; }
        public UserGender Gender { get; set; }
        public virtual Cart cart { get; set; }

    }
}
