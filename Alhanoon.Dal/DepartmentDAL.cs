using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
//using Alhanoon1.Models;


namespace Alhanoon.Dal
{
   public  class DepartmentDAL
    {
        AlhanoonEntities objdb = new AlhanoonEntities();
        public List<DepartmentModel> DepartmentList()
        {
            try
            {
                List<DepartmentModel> obj = new List<DepartmentModel>();
                obj = objdb.Departments.Select(x => new DepartmentModel
                {
                    Id = x.DepartmentId,
                    DepartmentName = x.DepartmentName,
                    IsActive = x.IsActive
                }).OrderByDescending(x => x.Id).ToList();
                return obj;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public DepartmentModel GetDepartmentById(int id)
        {
            try
            {
                return objdb.Departments.Where(x => x.DepartmentId == id).Select(x => new DepartmentModel
                {
                    Id = x.DepartmentId,
                    DepartmentName = x.DepartmentName,
                    IsActive = x.IsActive
                }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int AddEditDepartment(DepartmentModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    Department obj = new Department
                    {
                        DepartmentName = model.DepartmentName,
                        IsActive = model.IsActive,

                    };
                    objdb.Departments.Add(obj);
                    objdb.SaveChanges();
                    return obj.DepartmentId;
                }
                else
                {
                    Department obj = objdb.Departments.Find(model.Id);
                    if (obj != null)
                    {
                        obj.DepartmentName = model.DepartmentName;
                        obj.IsActive = model.IsActive;
                        objdb.SaveChanges();
                        return obj.DepartmentId;
                    }
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public bool ChangeStatus(int id)
        {
            try
            {
                var obj = objdb.Departments.Find(id);
                if (obj != null && obj.IsActive == true)
                {
                    obj.IsActive = false;
                    objdb.SaveChanges();
                    return false;
                }
                else if (obj != null)
                {
                    obj.IsActive = true;
                    objdb.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        public List<DepartmentModel> GetAllDepartment()
        {
            try
            {
                List<DepartmentModel> obj = new List<DepartmentModel>();
                obj = objdb.Departments.Select(x => new DepartmentModel
                {
                    Id = x.DepartmentId,
                    DepartmentName = x.DepartmentName,
                    IsActive = x.IsActive
                }).OrderBy(x => x.Id).ToList();
                return obj;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}