using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public  class HospitalBLL
    {
        HospitalDAL objDal = new HospitalDAL();
        public List<HospitalModel> HospitalList()
        {
            try
            {
                return objDal.HospitalList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public HospitalModel GetHospitalById(int id)
        {
            try
            {
                return objDal.GetHospitalById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int AddEditHospital(HospitalModel model)
        {
            try
            {
                return objDal.AddEditHospital(model);
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
