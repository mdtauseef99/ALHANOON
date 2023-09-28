using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;


namespace Alhanoon.Dal
{
   public class HomeDAL
    {
       AlhanoonEntities objdb = new AlhanoonEntities();
       public List<HomeModel> HomeList()
       {
           try
           {
               List<HomeModel> obj = new List<HomeModel>();
               obj=objdb.Homes.Select(x=>new HomeModel  
               {
                   Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    IsActive = x.IsActive
                }).OrderByDescending(x => x.Id).ToList();
                return obj;
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public HomeModel GetHomeById(int Id)
       {
           try
           {
               return objdb.Homes.Where(x => x.Id == Id).Select(x => new HomeModel
                   {
                       Id = x.Id,
                       Title = x.Title,
                       Description = x.Description,
                       IsActive = x.IsActive
                   }
                   ).SingleOrDefault();
           }
           catch(Exception)
           {
               return null;
               throw;
           }
       }
       public int AddEditHome(HomeModel model)
       {
           try
           {
               if (model.Id == 0)
               {
                   Home obj = new Home
                   {
                       Title = model.Title,
                       Description = model.Description,
                       IsActive = model.IsActive
                   };
                   objdb.Homes.Add(obj);
                   objdb.SaveChanges();
                   return obj.Id;
               }
               else
               {
                   Home obj = objdb.Homes.Find(model.Id);
                   if (obj != null)
                   {
                       obj.Title = model.Title;
                       obj.Description = model.Description;
                       obj.IsActive = model.IsActive;
                       objdb.SaveChanges();
                       return obj.Id;
                   }
                   return 0;
               }
           }
           catch(Exception)
           {
               return 0;
               throw;
           }
       }
       public bool ChangeStatus(int id)
       {
           try
           {
               var obj = objdb.Homes.Find(id);
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
