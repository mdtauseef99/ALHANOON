using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CommonUtility
{
   public  class DepartmentModel
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public List<DepartmentModel> DepartmentList { get; set; }
        //public List<DoctorModel> DoctorList { get; set; }
    }
}
