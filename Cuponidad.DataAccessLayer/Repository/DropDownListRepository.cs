using Cuponidad.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuponidad.DataAccessLayer.Repository
{
    public class DropDownListRepository
    {
        static CuponContext context = new CuponContext();
        public static List<DropDownListBydays> ListBydays()
        {
            List<DropDownListBydays> dropDownListBydays = null;
            dropDownListBydays = context.DropDownListBydays.ToList();
            return dropDownListBydays;
        }
        public static List<Department> DepartmenList()
        {
            List<Department> departments = null;
            departments = context.Departments.ToList();
            return departments;
        }
    }
}
