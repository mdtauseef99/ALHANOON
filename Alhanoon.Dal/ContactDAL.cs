using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   public   class ContactDAL
   {
       AlhanoonEntities objdb = new AlhanoonEntities();
       public List<ContactModel> ContactList()
       {
           try
           {
               List<ContactModel> obj = new List<ContactModel>();
               obj = objdb.Contacts.Select(x => new ContactModel
               {
                   Id = x.Id,
                   Address = x.Address,
                   ContactPerson_1 = x.ContactPerson_1,
                   ContactPerson_2 = x.ContactPerson_2,
                   MailFrom=x.MailFrom,
                   MailTo=x.MailTo,
                   SmtpClient=x.SmtpClient,
                   Port=x.Port,
                   smtp_Email=x.smtp_Email,
                   Password=x.Password,
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
       public ContactModel GetContactById(int Id)
       {
           try
           {
               return objdb.Contacts.Where(x => x.Id == Id).Select(x => new ContactModel
               {
                   Id = x.Id,
                   Address = x.Address,
                   ContactPerson_1 = x.ContactPerson_1,
                   ContactPerson_2 = x.ContactPerson_2,
                   MailFrom = x.MailFrom,
                   MailTo = x.MailTo,
                   SmtpClient = x.SmtpClient,
                   Port = x.Port,
                   smtp_Email = x.smtp_Email,
                   Password = x.Password,
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
       public int AddEditContact(ContactModel model)
       {
           try
           {
               if (model.Id == 0)
               {
                   Contact obj = new Contact
                   {
                       Address = model.Address,
                       ContactPerson_1 = model.ContactPerson_1,
                       ContactPerson_2 = model.ContactPerson_2,
                       MailFrom = model.MailFrom,
                       MailTo = model.MailTo,
                       SmtpClient = model.SmtpClient,
                       Port = model.Port,
                       smtp_Email = model.smtp_Email,
                       Password = model.Password,
                       IsActive = model.IsActive
                   };
                   objdb.Contacts.Add(obj);
                   objdb.SaveChanges();
                   return obj.Id;
               }
               else
               {
                   Contact obj = objdb.Contacts.Find(model.Id);
                   if (obj != null)
                   {
                        obj.Address = model.Address;
                      obj. ContactPerson_1 = model.ContactPerson_1;
                      obj.ContactPerson_2 = model.ContactPerson_2;
                      obj.MailFrom = model.MailFrom;
                      obj.MailTo = model.MailTo;
                       obj.SmtpClient = model.SmtpClient;
                       obj.Port = model.Port;
                       obj.smtp_Email = model.smtp_Email;
                       obj.Password = model.Password;
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
               var obj = objdb.Contacts.Find(id);
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
