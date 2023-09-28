using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   public class CostComparisionContentDAL
    {
        AlhanoonEntities objdb = new AlhanoonEntities();
        public List<CostComparisionContentModel> CostComparisionContentList()
        {
            try
            {
                List<CostComparisionContentModel> obj = new List<CostComparisionContentModel>();
                obj = objdb.Cost_ComparisionContents.Select(x => new CostComparisionContentModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ChartTitle = x.ChartTitle,
                    Disclaimer=x.Disclaimer,
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
        public CostComparisionContentModel GetCostComparisionContentById(int Id)
        {
            try
            {
                return objdb.Cost_ComparisionContents.Where(x => x.Id == Id).Select(x => new CostComparisionContentModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ChartTitle = x.ChartTitle,
                    Disclaimer = x.Disclaimer,
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
        public int AddEditCostComparisionContent(CostComparisionContentModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    Cost_ComparisionContent obj = new Cost_ComparisionContent
                    {
                        Title = model.Title,
                        Description = model.Description,
                        ChartTitle=model.ChartTitle,
                        Disclaimer=model.Disclaimer,
                        IsActive = model.IsActive
                    };
                    objdb.Cost_ComparisionContents.Add(obj);
                    objdb.SaveChanges();
                    return obj.Id;
                }
                else
                {
                    Cost_ComparisionContent obj = objdb.Cost_ComparisionContents.Find(model.Id);
                    if (obj != null)
                    {
                        obj.Title = model.Title;
                        obj.Description = model.Description;
                        obj.ChartTitle = model.ChartTitle;
                        obj.Disclaimer = model.Disclaimer;
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
                var obj = objdb.Cost_ComparisionContents.Find(id);
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

       /* for frontaent cost comparison*/
        public List<CostComparisionContentModel> GetAllCostComparisionContent()
        {
            try
            {
                List<CostComparisionContentModel> obj = new List<CostComparisionContentModel>();
                obj = objdb.Cost_ComparisionContents.Select(x => new CostComparisionContentModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ChartTitle = x.ChartTitle,
                    Disclaimer = x.Disclaimer,
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
