using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CommonUtility
{
   public  class DoctorModel
    {
       public int DoctorId { get; set; }
       public string DoctorName { get; set; }
       public string Designation { get; set; }
       public string Photo { get; set; }
       public string Details { get; set; }
       public int DepartmentId { get; set; }
       public bool IsActive { get; set; }
       public string DepartmentName { get; set; }
       public List<DoctorModel> DoctorList { get; set; }

       public IEnumerable<SelectListItem> DoctorsLists { get; set; }
    }
}
