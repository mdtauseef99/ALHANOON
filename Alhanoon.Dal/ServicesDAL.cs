using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   public class ServicesDAL
    {
        AlhanoonEntities objdb = new AlhanoonEntities();
        public List<ServicesModel> ServicesList()
        {
            try
            {
                List<ServicesModel> obj = new List<ServicesModel>();
                obj = objdb.Services.Select(x => new ServicesModel
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
        public ServicesModel GetServicesById(int Id)
        {
            try
            {
                return objdb.Services.Where(x => x.Id == Id).Select(x => new ServicesModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    //Icon=x.Icon,
                    IsActive = x.IsActive
                }
                    ).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public int AddEditServices(ServicesModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    Service obj = new Service
                    {
                        Title = model.Title,
                        Description = model.Description,
                        //Icon=model.Icon,
                        IsActive = model.IsActive
                    };
                    objdb.Services.Add(obj);
                    objdb.SaveChanges();
                    return obj.Id;
                }
                else
                {
                    Service obj = objdb.Services.Find(model.Id);
                    if (obj != null)
                    {
                        obj.Title = model.Title;
                        obj.Description = model.Description;
                        //if (model.Icon != "")
                        //{
                        //    obj.Icon = model.Icon;
                        //}
                       
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
                var obj = objdb.Services.Find(id);
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
