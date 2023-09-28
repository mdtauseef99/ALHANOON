using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;


namespace Alhanoon.Dal
{
   public  class CostComparisionChartDAL
    {
        AlhanoonEntities objdb = new AlhanoonEntities();
        public List<CostComparisionChartModel> CostComparisionChartList()
        {
            try
            {
                List<CostComparisionChartModel> obj = new List<CostComparisionChartModel>();
                obj = objdb.Cost_Comparison.Select(x => new CostComparisionChartModel
                {
                    Id = x.Id,
                    Procedures = x.Procedures,
                    US = x.US,
                    UK = x.UK,
                    Bangkok=x.Bangkok,
                    India=x.India,
                    Singapore=x.Singapore,
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
        public CostComparisionChartModel GetCostComparisionChartById(int Id)
        {
            try
            {
                return objdb.Cost_Comparison.Where(x => x.Id == Id).Select(x => new CostComparisionChartModel
                {
                    Id = x.Id,
                    Procedures = x.Procedures,
                    US = x.US,
                    UK = x.UK,
                    Bangkok = x.Bangkok,
                    India = x.India,
                    Singapore = x.Singapore,
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
        public int AddEditCostChart(CostComparisionChartModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    Cost_Comparison obj = new Cost_Comparison
                    {
                        Procedures = model.Procedures,
                        US = model.US,
                        UK = model.UK,
                        Bangkok = model.Bangkok,
                        India = model.India,
                        Singapore = model.Singapore,
                        IsActive = model.IsActive
                    };
                    objdb.Cost_Comparison.Add(obj);
                    objdb.SaveChanges();
                    return obj.Id;
                }
                else
                {
                    Cost_Comparison obj = objdb.Cost_Comparison.Find(model.Id);
                    if (obj != null)
                    {
                       obj.Procedures = model.Procedures;
                       obj.US = model.US;
                        obj.UK = model.UK;
                        obj.Bangkok = model.Bangkok;
                        obj.India = model.India;
                        obj.Singapore = model.Singapore;
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
                var obj = objdb.Cost_Comparison.Find(id);
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

       /* for frontent cost comparison*/
        public List<CostComparisionChartModel> GetAllCostComparisionChart()
        {
            try
            {
                List<CostComparisionChartModel> obj = new List<CostComparisionChartModel>();
                obj = objdb.Cost_Comparison.Select(x => new CostComparisionChartModel
                {
                    Id = x.Id,
                    Procedures = x.Procedures,
                    US = x.US,
                    UK = x.UK,
                    Bangkok = x.Bangkok,
                    India = x.India,
                    Singapore = x.Singapore,
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

    }
}
