using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   public  class HospitalDAL
    {
        AlhanoonEntities objdb = new AlhanoonEntities();
        public List<HospitalModel> HospitalList()
        {
            try
            {
                List<HospitalModel> obj = new List<HospitalModel>();
                obj = objdb.Hospitals.Select(x => new HospitalModel
                {
                    Id = x.Id,
                    Image = x.Image,
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
        public HospitalModel GetHospitalById(int id)
        {
            try
            {
                return objdb.Hospitals.Where(x => x.Id == id).Select(x => new HospitalModel
                {
                    Id = x.Id,
                    Image = x.Image,
                    IsActive = x.IsActive
                }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public int AddEditHospital(HospitalModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    Hospital obj = new Hospital
                    {
                        Image = model.Image,
                        IsActive = model.IsActive,
                    };
                    objdb.Hospitals.Add(obj);
                    objdb.SaveChanges();
                    return obj.Id;
                }
                else
                {
                    Hospital obj = objdb.Hospitals.Find(model.Id);
                    if (obj != null)
                    {

                        if (model.Image != "")
                        {
                            obj.Image = model.Image;
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
                var obj = objdb.Hospitals.Find(id);
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