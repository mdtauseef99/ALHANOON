using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alhanoon.Dal;
using CommonUtility;

namespace Alhanoon.Bll
{
   public  class AboutUsBLL
    {
       AboutUsDAL objDal = new AboutUsDAL();
       public List<AboutUsModel> AboutUsList()
        {
            try
            {
                return objDal.AboutUsList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public AboutUsModel GetAboutUsById(int id)
        {
            try
            {
                return objDal.GetAboutUsById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int AddEditAboutUs(AboutUsModel model)
        {
            try
            {
                return objDal.AddEditAboutUs(model);
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

        /* for frotent of department*/
        public List<AboutUsModel> GetAllAboutUs()
        {
            try
            {
                return objDal.GetAllAboutUs();

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}
