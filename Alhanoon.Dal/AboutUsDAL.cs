using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alhanoon.Dal;
using CommonUtility;

namespace Alhanoon.Dal
{
   public class AboutUsDAL
    {
       AlhanoonEntities objdb = new AlhanoonEntities();
        public List<AboutUsModel> AboutUsList()
        {
            try
            {
                List<AboutUsModel> obj = new List<AboutUsModel>();
                obj = objdb.Abouts.Select(x => new AboutUsModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    InnerTitle=x.InnerTitle,
                    InnerDescription=x.InnerDescription,
                    Image=x.Image,
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

        public AboutUsModel GetAboutUsById(int id)
        {
            try
            {
                return objdb.Abouts.Where(x => x.Id == id).Select(x => new AboutUsModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    InnerTitle = x.InnerTitle,
                    InnerDescription = x.InnerDescription,
                    Image=x.Image,
                    IsActive = x.IsActive
                }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int AddEditAboutUs(AboutUsModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    About obj = new About
                    {
                        Title = model.Title,
                        Description = model.Description,
                        InnerTitle = model.InnerTitle,
                        InnerDescription = model.InnerDescription,
                        Image = model.Image,
                        IsActive = model.IsActive,

                    };
                    objdb.Abouts.Add(obj);
                    objdb.SaveChanges();
                    return obj.Id;
                }
                else
                {
                    About obj = objdb.Abouts.Find(model.Id);
                    if (obj != null)
                    {
                        obj.Title = model.Title;
                        obj.Description = model.Description;
                        obj.InnerTitle = model.InnerTitle;
                        obj.InnerDescription = model.InnerDescription;
                        obj.IsActive = model.IsActive;
                        if (model.Image != "")
                        {
                            obj.Image = model.Image;
                        }
                       
                      
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
                var obj = objdb.Abouts.Find(id);
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

       /* for frotent of */
        public List<AboutUsModel> GetAllAboutUs()
        {
            try
            {
                List<AboutUsModel> obj = new List<AboutUsModel>();
                obj = objdb.Abouts.Select(x => new AboutUsModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    InnerTitle = x.InnerTitle,
                    InnerDescription = x.InnerDescription,
                    Image = x.Image,
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
