using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   public class TestimonialDAL
    {
        AlhanoonEntities objdb = new AlhanoonEntities();
       public List<TestimonialModel> TestimonialList()
       {
           try
           {
               List<TestimonialModel> obj = new List<TestimonialModel>();
               obj = objdb.Testimonials.Select(x => new TestimonialModel
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
       public TestimonialModel GetTestimonialById(int id)
       {
           try
           {
               return objdb.Testimonials.Where(x => x.Id == id).Select(x => new TestimonialModel

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
       public int AddEditTestimonial(TestimonialModel model)
       {
           try
           {
               if (model.Id == 0)
               {
                   Testimonial obj = new Testimonial
                   {
                       Image = model.Image,
                       Description = model.Description,
                       IsActive = model.IsActive,
                   };
                   objdb.Testimonials.Add(obj);
                   objdb.SaveChanges();
                   return obj.Id;
               }
               else
               {
                   Testimonial obj = objdb.Testimonials.Find(model.Id);
                   if (obj != null)
                   {

                       if (model.Image != "")
                       {
                           obj.Image = model.Image;
                          
                       }
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
               var obj = objdb.Testimonials.Find(id);
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
