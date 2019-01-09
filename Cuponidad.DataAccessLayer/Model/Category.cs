using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cuponidad.DataAccessLayer.Model
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        public int CategoryLevelID { get; set; }
        public int FamilyID { get; set; }
        public string Name { get; set; }
        [ForeignKey("CategoryLevelID")]
        public virtual CategoryLevel CategoryLevel{ get; set; }
        [ForeignKey("FamilyID")]
        public virtual Family Family{ get; set; }
    }
}
