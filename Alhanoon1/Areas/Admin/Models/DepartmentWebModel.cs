using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonUtility;

namespace Alhanoon1.Areas.Admin.Models
{
    public class DepartmentWebModel
    {

        public int DoctorId { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string Designation { get; set; }
        public string Photo { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }

        public int DepartmentId { get; set; }

        public int? ParentDepartmentId { get; set; }

        public IEnumerable<SelectListItem> ParentDepartment { get; set; }

        [Display(Name = "Select Department")]
        public IEnumerable<SelectListItem> Department { get; set; }

        //public DoctorModel DoctorsModel { get; set; }

    }
  
}