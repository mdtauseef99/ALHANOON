using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonUtility;
using Alhanoon.Bll;

namespace Alhanoon1.Areas.Admin.Filters
{
   static public class CustomMethods
    {
       public static void BindDepartments<T>(T model)
       {
           try
           {
               var departments = new DepartmentBLL { }.GetAllDepartment();
               if (departments != null)
               {
                   model.GetType().GetProperty("Departments").SetValue(model, departments
                                   .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.DepartmentName }));
               }
           }
           catch (Exception)
           {
               throw;
           }
       }
    }
}