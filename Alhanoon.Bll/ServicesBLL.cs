using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public class ServicesBLL
    {
       ServicesDAL objDal = new ServicesDAL();
        public List<ServicesModel> ServicesList()
        {
            try
            {
                return objDal.ServicesList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public ServicesModel GetServicesById(int id)
        {
            try
            {
                return objDal.GetServicesById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int AddEditServices(ServicesModel model)
        {
            try
            {
                return objDal.AddEditServices(model);
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
    }
}
