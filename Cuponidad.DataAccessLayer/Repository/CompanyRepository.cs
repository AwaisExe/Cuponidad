using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Cuponidad.DataAccessLayer.Model;

namespace Cuponidad.DataAccessLayer.Repository
{
    public class CompanyRepository
    {
        static CuponContext context = new CuponContext();
        public static List<Company> List()
        {
            List<Company> companies = null;
            companies = (from a in context.Companies select a).ToList();
            return companies;
        }
    }
}
