using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alhanoon.Dal;
using CommonUtility;

namespace Alhanoon.Bll
{
   public class SubscriberBLL
    {
       SubscriberDAL objDal = new SubscriberDAL();
       public List<SubscriberModel> SubscriberList()
        {
            try
            {
                return objDal.SubscriberList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


       public int AddEditSubscriber(SubscriberModel model)
        {
            try
            {
                return objDal.AddEditSubscriber(model);
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        //public bool ChangeStatus(int id)
        //{
        //    try
        //    {
        //        return objDal.ChangeStatus(id);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //        throw;
        //    }
        //}
    }
}
  