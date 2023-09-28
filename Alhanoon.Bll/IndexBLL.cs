using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alhanoon.Dal;
using CommonUtility;

namespace Alhanoon.Bll
{

   public  class IndexBLL
    {
       IndexDAL objDal = new IndexDAL();
       public List<BannerModel> GetAllBanner()
       {
           try
           {
               return objDal.GetAllBanner();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public List<ServicesModel> GetAllServices()
       {
           try
           {
               return objDal.GetAllServices();

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public List<DoctorModel> GetAllDoctor()
       {
           try
           {
               return objDal.GetAllDoctor();

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public List<HospitalModel> GetAllHospital()
       {
           try
           {
               return objDal.GetAllHospital();

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public List<TreatmentModel> GetAllTreatment()
       {
           try
           {
               return objDal.GetAllTreatment();

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public List<LatestNewsModel> GetAllLatestNews()
       {
           try
           {
               return objDal.GetAllLatestNews();

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
    }
}
