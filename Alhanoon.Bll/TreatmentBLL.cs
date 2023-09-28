using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public class TreatmentBLL
   {
       TreatmentDAL objDal = new TreatmentDAL();
       public List<TreatmentModel> TreatmentList()
       {
           try
           {
               return objDal.TreatmentList();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public TreatmentModel GetTreatmentById(int id)
       {
           try
           {
               return objDal.GetTreatmentById(id);
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
               return objDal.AddEditTreatment(model);
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

       /* for frontent */
       public List<TreatmentModel> GetAllTreatment()
       {
           try
           {
               return objDal.GetAllTreatment();

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
               return objDal.GetAllTreatmentListById(id);

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
   }
}

