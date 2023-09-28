using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public class latestNewsBLL
   {
       LatestNewsDAL objDal = new LatestNewsDAL();
       public List<LatestNewsModel> latestNewsList()
       {
           try
           {
               return objDal.latestNewsList();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public LatestNewsModel GetLatestNewsById(int id)
       {
           try
           {
               return objDal.GetLatestNewsById(id);
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public int AddEditlatestNews(LatestNewsModel model)
       {
           try
           {
               return objDal.AddEditlatestNews(model);
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

