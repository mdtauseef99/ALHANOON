using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;
using System.Web.Mvc;

namespace Alhanoon.Bll
{
    public  class DoctorBLL
    {
        DoctorDAL objDal = new DoctorDAL();
        public List<DoctorModel> DoctorList()
        {
            try
            {
                return objDal.DoctorList();
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
                return objDal.DoctorListByDepartment(id);

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
                return objDal.GetDoctorById(id);
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


                return objDal.GetDoctorByDepartmentId(id);
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
                return objDal.AddEditDoctor(model);
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
                return objDal.ChangeStatus(id);
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
                return objDal.GetListOfDoctors();
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
             
                   return objDal.CompareDepartment(model);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
}

