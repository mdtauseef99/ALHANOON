using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Dal
{
      
  
   public class BannerDAL
    {
         AlhanoonEntities objdb = new AlhanoonEntities();
         public List<BannerModel> BannerList()
         {
             try
             {
                 List<BannerModel> obj = new List<BannerModel>();
                 obj = objdb.Banners.Select(x => new BannerModel
                 {
                     BannerId = x.BannerId,
                     BannerName = x.BannerName,
                     IsActive = x.IsActive
                 }).OrderByDescending(x => x.BannerId).ToList();
                 return obj;
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
                 return objdb.Banners.Where(x => x.BannerId == id).Select(x => new BannerModel
                 {
                     BannerId = x.BannerId,
                     BannerName = x.BannerName,
                     IsActive = x.IsActive
                 }).SingleOrDefault();
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
                 if (model.BannerId == 0)
                 {
                     Banner obj = new Banner
                     {
                         BannerName = model.BannerName,
                         IsActive = model.IsActive,
                     };
                     objdb.Banners.Add(obj);
                     objdb.SaveChanges();
                     return obj.BannerId;
                 }
                 else
                 {
                     Banner obj = objdb.Banners.Find(model.BannerId);
                     if (obj != null)
                     {

                         if (model.BannerName != "")
                         {
                             obj.BannerName = model.BannerName;
                         }
                         obj.IsActive = model.IsActive;

                         objdb.SaveChanges();
                         return obj.BannerId;
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
                 var obj = objdb.Banners.Find(id);
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
