using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public class TestimonialBLL
    {
       TestimonialDAL objDal = new TestimonialDAL();
       public List<TestimonialModel> TestimonialList()
        {
            try
            {
                return objDal.TestimonialList();
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
                return objDal.GetTestimonialById(id);
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
                return objDal.AddEditTestimonial(model);
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
                return objDal.ChangeStatus(id);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}

