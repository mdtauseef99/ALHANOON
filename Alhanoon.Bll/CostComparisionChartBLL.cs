using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public  class CostComparisionChartBLL
    {
       CostComparisionChartDAL objDal = new CostComparisionChartDAL();
       public List<CostComparisionChartModel> CostComparisionChartList()
        {
            try
            {
                return objDal.CostComparisionChartList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

       public CostComparisionChartModel GetCostComparisionChartById(int id)
        {
            try
            {
                return objDal.GetCostComparisionChartById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

       public int AddEditCostChart(CostComparisionChartModel model)
        {
            try
            {
                return objDal.AddEditCostChart(model);
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

        /* for frontent cost comparison*/
        public List<CostComparisionChartModel> GetAllCostComparisionChart()
        {
            try
            {
                return objDal.GetAllCostComparisionChart();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}

