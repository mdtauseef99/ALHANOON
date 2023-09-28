using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   public class SubscriberDAL
    {
        AlhanoonEntities objdb = new AlhanoonEntities();
        public List<SubscriberModel> SubscriberList()
        {
            try
            {
                List<SubscriberModel> obj = new List<SubscriberModel>();
                obj = objdb.Subscribers.Select(x => new SubscriberModel
                {
                    Id = x.Id,
                    Email = x.Email,
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

        public int AddEditSubscriber(SubscriberModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    Subscriber obj = new Subscriber
                    {
                        Email = model.Email,
                        IsActive = model.IsActive
                    };
                    objdb.Subscribers.Add(obj);
                    objdb.SaveChanges();
                    return obj.Id;
                }
                else
                {
                    Subscriber obj = objdb.Subscribers.Find(model.Id);
                    if (obj != null)
                    {
                        obj.Email = model.Email;
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
        //public bool ChangeStatus(int id)
        //{
        //    try
        //    {
        //        var obj = objdb.Homes.Find(id);
        //        if (obj != null && obj.IsActive == true)
        //        {
        //            obj.IsActive = false;
        //            objdb.SaveChanges();
        //            return false;
        //        }
        //        else if (obj != null)
        //        {
        //            obj.IsActive = true;
        //            objdb.SaveChanges();
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //        throw;
        //    }

        //}

    }
}