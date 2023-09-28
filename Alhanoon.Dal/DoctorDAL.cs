using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using System.Web.Mvc;
using System.Data.Objects.SqlClient;

namespace Alhanoon.Dal
{
   public class DoctorDAL
    {
        AlhanoonEntities objdb = new AlhanoonEntities();
        public List<DoctorModel> DoctorList()
        {
            try
            {
                List<DoctorModel> obj = new List<DoctorModel>();

                obj = objdb.Doctors.Select(r => new DoctorModel
                {

                    DoctorId = r.DoctorId,
                    DoctorName = r.DoctorName,
                    Designation = r.Designation,
                    Photo = r.Photo,
                    Details = r.Details,
                    DepartmentId = r.DepartmentId,
                    DepartmentName = objdb.Departments.Where(x => x.DepartmentId == r.DepartmentId).Select(x => x.DepartmentName).FirstOrDefault(),
                    IsActive = r.IsActive

                }).OrderBy(r => r.DoctorId).ToList();
                return obj;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public DoctorModel GetDoctorById(int id)
        {
            try
            {
                int? cid = objdb.Doctors.Where(x => x.DoctorId == id).Select(x => x.DepartmentId).FirstOrDefault();
                string Dname = objdb.Departments.Where(x => x.DepartmentId == cid).Select(x => x.DepartmentName).FirstOrDefault();
                return objdb.Doctors.Where(x => x.DoctorId == id).Select(x => new DoctorModel
                {
                    DoctorId = x.DoctorId,
                    DoctorName = x.DoctorName,
                    Designation = x.Designation,
                    Photo = x.Photo,
                    Details = x.Details,
                    DepartmentId = x.DepartmentId,
                    IsActive = x.IsActive,
                    DepartmentName = Dname
                  
                }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public DoctorModel GetDoctorByDepartmentId(int id)
        {
            try
            {
                return objdb.Doctors.Where(x => x.DepartmentId == id).Select(x => new DoctorModel
                {
                    DoctorId = x.DoctorId,
                    DoctorName = x.DoctorName,
                    Designation = x.Designation,
                    Photo = x.Photo,
                    Details = x.Details,
                    DepartmentId = x.DepartmentId,


                }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<DoctorModel> DoctorListByDepartment(int id)
        {
            try
            {
                List<DoctorModel> obj = new List<DoctorModel>();

                obj = objdb.Doctors.Where(x => x.DepartmentId == id).Select(x => new DoctorModel
                {
                    DoctorId = x.DoctorId,
                    DoctorName = x.DoctorName,
                    Designation = x.Designation,
                    Photo = x.Photo,
                    Details = x.Details,
                    DepartmentId = x.DepartmentId,

                }).OrderBy(x => x.DoctorId).ToList();
         
                return obj;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public int AddEditDoctor(DoctorModel model)
        {
            try
            {
                if (model.DoctorId == 0)
                {
                    Doctor obj = new Doctor
                    {
                        DoctorId = model.DoctorId,
                        DoctorName = model.DoctorName,
                        Designation = model.Designation,
                        Photo = model.Photo,
                        Details = model.Details,
                        DepartmentId = model.DepartmentId,
                        IsActive = model.IsActive

                    };
                    objdb.Doctors.Add(obj);
                    objdb.SaveChanges();
                    return obj.DoctorId;
                }
                else
                {
                    Doctor obj = objdb.Doctors.Find(model.DoctorId);
                    if (obj != null)
                    {
                        obj.DoctorId = model.DoctorId;
                        obj.DoctorName = model.DoctorName;
                        obj.Designation = model.Designation;
                        if (model.Photo != "")
                        {
                            obj.Photo = model.Photo;
                        }
                       
                        obj.Details = model.Details;
                         obj.DepartmentId = model.DepartmentId;
                         obj.IsActive = model.IsActive;
                        objdb.SaveChanges();
                        return obj.DoctorId;
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
                var obj = objdb.Doctors.Find(id);
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

        public DoctorModel GetListOfDoctors()
        {
            try
            {
                DoctorModel doctorObj = new DoctorModel();
                doctorObj.DoctorsLists = objdb.Departments.Select(x => new SelectListItem { Text = x.DepartmentName, Value = SqlFunctions.StringConvert((double)x.DepartmentId) }).ToList();
                return doctorObj;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DoctorModel CompareDepartment(DoctorModel model )
        {
            try
            {
             
                    Department obj = objdb.Departments.Find(model.DepartmentId);
                    if (obj != null)
                    {
                        obj.DepartmentId = model.DepartmentId;

                        obj.IsActive = model.IsActive;
                        objdb.SaveChanges();
                        
                    }
                    return model;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
