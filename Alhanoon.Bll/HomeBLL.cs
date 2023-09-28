using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public  class HomeBLL
    {
        HomeDAL objDal = new HomeDAL();
        public List<HomeModel> HomeList()
        {
            try
            {
                return objDal.HomeList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public HomeModel GetHomeById(int id)
        {
            try
            {
                return objDal.GetHomeById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int AddEditHome(HomeModel model)
        {
            try
            {
                return objDal.AddEditHome(model);
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
