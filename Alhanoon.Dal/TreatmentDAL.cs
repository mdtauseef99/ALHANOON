using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   public  class TreatmentDAL
    {
        AlhanoonEntities objdb = new AlhanoonEntities();
        public List<TreatmentModel> TreatmentList()
        {
            try
            {
                List<TreatmentModel> obj = new List<TreatmentModel>();
                obj = objdb.Treatments.Select(x => new TreatmentModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Disease=x.Disease,
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
        public TreatmentModel GetTreatmentById(int Id)
        {
            try
            {
                return objdb.Treatments.Where(x => x.Id == Id).Select(x => new TreatmentModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Disease=x.Disease,
                    Description = x.Description,
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
        public int AddEditTreatment(TreatmentModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    Treatment obj = new Treatment
                    {
                        Title = model.Title,
                        Disease=model.Disease,
                        Description = model.Description,
                        IsActive = model.IsActive
                    };
                    objdb.Treatments.Add(obj);
                    objdb.SaveChanges();
                    return obj.Id;
                }
                else
                {
                    Treatment obj = objdb.Treatments.Find(model.Id);
                    if (obj != null)
                    {
                        obj.Title = model.Title;
                        obj.Disease = model.Disease;
                        obj.Description = model.Description;
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
                var obj = objdb.Treatments.Find(id);
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


       /* for frontent */
       public List<TreatmentModel> GetAllTreatment()
       {
           try
           {
               List<TreatmentModel> obj = new List<TreatmentModel>();
               obj = objdb.Treatments.Where(x => x.IsActive == true).Select(x => new TreatmentModel
               {
                   Id = x.Id,
                   Title = x.Title,
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

       public List<TreatmentModel> GetAllTreatmentListById(int id)
       {
           try
           {
               List<TreatmentModel> obj = new List<TreatmentModel>();
               obj = objdb.Treatments.Where(x => x.Id == id).Select(x => new TreatmentModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   Disease=x.Disease,
                   Description=x.Description,
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

