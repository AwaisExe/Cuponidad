using System;
using System.Collections.Generic;
using System.Text;
using Cuponidad.DataAccessLayer.Model;
using System.Linq;

namespace Cuponidad.DataAccessLayer.Repository
{
    public class FamilyRepository
    {
        static CuponContext context = new CuponContext();
        public static List<Family> List()
        {
            List<Family> families = null;
            families = (from a in context.Families select a).ToList();
            return families;
        }
        public static Family Read(int familyID)
        {
            Family family = null;
            family = (from a in context.Families where a.FamilyID == familyID select a).FirstOrDefault();
            return family;
        }

    }
}
