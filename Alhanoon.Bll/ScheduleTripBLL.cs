using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alhanoon.Dal;
using CommonUtility;

namespace Alhanoon.Bll
{
   public  class ScheduleTripBLL
    {
       ScheduleTripDAL objDal = new ScheduleTripDAL();
        public List<ScheduleTripModel> ScheduleTripList()
        {
            try
            {
                return objDal.ScheduleTripList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public ScheduleTripModel GetScheduleTripById(int id)
        {
            try
            {
                return objDal.GetScheduleTripById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int AddEditScheduleTrip(ScheduleTripModel model)
        {
            try
            {
                return objDal.AddEditScheduleTrip(model);
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

        /*for frontent */

        public List<ScheduleTripModel> GetAllScheduleTrip()
        {
            try
            {
                return objDal.GetAllScheduleTrip();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}
