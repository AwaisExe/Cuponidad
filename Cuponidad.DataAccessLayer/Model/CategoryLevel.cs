using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cuponidad.DataAccessLayer.Model
{
    public class CategoryLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryLevelID { get; set; }
        public int LevelNumber { get; set; }
        public string Color { get; set; }
        public virtual Category Category { get; set; }
    }
}
