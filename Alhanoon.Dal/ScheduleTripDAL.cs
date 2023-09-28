using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   public  class ScheduleTripDAL
    { AlhanoonEntities objdb = new AlhanoonEntities();
       public List<ScheduleTripModel> ScheduleTripList()
       {
           try
           {
               List<ScheduleTripModel> obj = new List<ScheduleTripModel>();
               obj = objdb.ScheduleTrips.Select(x => new ScheduleTripModel  
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
       public ScheduleTripModel GetScheduleTripById(int Id)
       {
           try
           {
               return objdb.ScheduleTrips.Where(x => x.Id == Id).Select(x => new ScheduleTripModel
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
       public int AddEditScheduleTrip(ScheduleTripModel model)
       {
           try
           {
               if (model.Id == 0)
               {
                   ScheduleTrip obj = new ScheduleTrip
                   {
                       Title = model.Title,
                       Description = model.Description,
                       IsActive = model.IsActive
                   };
                   objdb.ScheduleTrips.Add(obj);
                   objdb.SaveChanges();
                   return obj.Id;
               }
               else
               {
                   ScheduleTrip obj = objdb.ScheduleTrips.Find(model.Id);
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
               var obj = objdb.ScheduleTrips.Find(id);
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

       /*for frontent */

       public List<ScheduleTripModel> GetAllScheduleTrip()
       {
           try
           {
               List<ScheduleTripModel> obj = new List<ScheduleTripModel>();
               obj = objdb.ScheduleTrips.Select(x => new ScheduleTripModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   Description = x.Description,
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

    }
    
}
