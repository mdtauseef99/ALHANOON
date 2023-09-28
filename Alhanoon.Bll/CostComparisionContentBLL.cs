using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public  class CostComparisionContentBLL
    {
       CostComparisionContentDAL objDal = new CostComparisionContentDAL();
       public List<CostComparisionContentModel> CostComparisionContentList()
        {
            try
            {
                return objDal.CostComparisionContentList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

       public CostComparisionContentModel GetCostComparisionContentById(int id)
        {
            try
            {
                return objDal.GetCostComparisionContentById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

       public int AddEditCostComparisionContent(CostComparisionContentModel model)
        {
            try
            {
                return objDal.AddEditCostComparisionContent(model);
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

        /* for frontaent cost comparison*/
        public List<CostComparisionContentModel> GetAllCostComparisionContent()
        {
            try
            {
                return objDal.GetAllCostComparisionContent();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}

