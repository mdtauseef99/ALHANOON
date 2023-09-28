using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public  class DepartmentBLL
    {
        DepartmentDAL objDal = new DepartmentDAL();
        public List<DepartmentModel> DepartmentList()
        {
            try
            {
                return objDal.DepartmentList();
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
                return objDal.GetDepartmentById(id);
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
                return objDal.AddEditDepartment(model);
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
        public List<DepartmentModel> GetAllDepartment()
        {
            try
            {
                return objDal.GetAllDepartment();

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}
