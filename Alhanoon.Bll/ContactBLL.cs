using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public  class ContactBLL
    {
       ContactDAL objDal = new ContactDAL();
       public List<ContactModel> ContactList()
        {
            try
            {
                return objDal.ContactList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

       public ContactModel GetContactById(int id)
        {
            try
            {
                return objDal.GetContactById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

       public int AddEditContact(ContactModel model)
        {
            try
            {
                return objDal.AddEditContact(model);
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
