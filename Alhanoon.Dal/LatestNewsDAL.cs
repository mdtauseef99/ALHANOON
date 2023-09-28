using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Dal
{
   public class LatestNewsDAL
    {
       AlhanoonEntities objdb = new AlhanoonEntities();
       public List<LatestNewsModel> latestNewsList()
       {
           try
           {
               List<LatestNewsModel> obj = new List<LatestNewsModel>();
               obj = objdb.LatestNews.Select(x => new LatestNewsModel
               {
                   Id = x.Id,
                   Image = x.Image,
                   Description =x.Description,
                   IsActive = x.IsActive
               }).OrderBy(x => x.Id).ToList();
               return obj;
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
               return objdb.LatestNews.Where(x => x.Id == id).Select(x => new LatestNewsModel

               {
                   Id = x.Id,
                   Image = x.Image,
                   Description = x.Description,
                   IsActive = x.IsActive
               }).SingleOrDefault();
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
               if (model.Id == 0)
               {
                   LatestNew obj = new LatestNew
                   {
                       Image = model.Image,
                       Description = model.Description,
                       IsActive = model.IsActive,
                   };
                   objdb.LatestNews.Add(obj);
                   objdb.SaveChanges();
                   return obj.Id;
               }
               else
               {
                   LatestNew obj = objdb.LatestNews.Find(model.Id);
                   if (obj != null)
                   {

                       if (model.Image != "")
                       {
                           obj.Image = model.Image;
                           obj.Description = model.Description;
                       }
                       obj.IsActive = model.IsActive;

                       objdb.SaveChanges();
                       return obj.Id;
                   }
                   return 0;
               }
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
               var obj = objdb.LatestNews.Find(id);
               if (obj != null && obj.IsActive == true)
               {
                   obj.IsActive = false;
                   objdb.SaveChanges();
                   return false;
               }
               else if (obj != null)
               {
                   obj.IsActive = true;
                   objdb.SaveChanges();
                   return true;
               }
               return false;
           }
           catch (Exception)
           {
               return false;
               throw;
           }

       }
    }
}