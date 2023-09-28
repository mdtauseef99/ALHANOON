using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
    public class BannerBLL
    {
        BannerDAL objDal = new BannerDAL();
        public List<BannerModel> BannerList()
        {
            try
            {
                return objDal.BannerList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public BannerModel GetBannerById(int id)
        {
            try
            {
                return objDal.GetBannerById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int AddEditBanner(BannerModel model)
        {
            try
            {
                return objDal.AddEditBanner(model);
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
