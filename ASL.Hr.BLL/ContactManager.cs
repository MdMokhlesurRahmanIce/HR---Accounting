using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class ContactManager
    {
       public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup entitySetup)
       {
           return Gen_LookupEnt.GetAllGen_LookupEnt(entitySetup);
       }
       public CustomList<Contact> GetAllContact()
       {
           return Contact.GetAllContact();
       }
       public CustomList<ContactCategory> GetAllContactCategory()
       {
           return ContactCategory.GetAllContactCategory();
       }
       public CustomList<ContactSubCategory> GetAllContactSubCategory()
       {
           return ContactSubCategory.GetAllContactSubCategory();
       }
       public CustomList<Gen_Country> GetAllCountry()
       {
           return Gen_Country.GetAllGen_Country();
       }
       public void SaveContact(ref CustomList<Contact> ContactList,ref CustomList<ContactCategoryMapping> DeletedContactCategoryMappingList,ref CustomList<ContactSubCategoryMapping> DeletedContactSubCategoryMappingList, ref CustomList<ContactCategoryMapping> ContactCategoryMappingList, ref CustomList<ContactSubCategoryMapping> ContactSubCategoryMappingList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(ContactList, ContactCategoryMappingList, ContactSubCategoryMappingList);
               blnTranStarted = true;
               int contactID = ContactList[0].ID;
               if (contactID.IsNull() || contactID==0)
                   contactID = Convert.ToInt32(conManager.InsertData(blnTranStarted, ContactList));
               else
                   conManager.SaveDataCollectionThroughCollection(blnTranStarted, ContactList);
               DeletedContactCategoryMappingList.ForEach(s => s.ContractID = contactID);
               DeletedContactCategoryMappingList.DeleteSpName = "spDeleteContactCategoryMapping";
               DeletedContactSubCategoryMappingList.ForEach(s=>s.ContactID=contactID);
               DeletedContactSubCategoryMappingList.DeleteSpName = "spDeleteContactSubCategoryMapping";
               ContactCategoryMappingList.ForEach(s => s.ContractID = contactID);
               ContactSubCategoryMappingList.ForEach(s=>s.ContactID=contactID);
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, DeletedContactCategoryMappingList, DeletedContactSubCategoryMappingList, ContactCategoryMappingList, ContactSubCategoryMappingList);

               ContactList.AcceptChanges();
               DeletedContactCategoryMappingList.AcceptChanges();
               DeletedContactSubCategoryMappingList.AcceptChanges();
               ContactCategoryMappingList.AcceptChanges();
               ContactSubCategoryMappingList.AcceptChanges();
               conManager.CommitTransaction();
               blnTranStarted = false;
           }
           catch (Exception Ex)
           {
               conManager.RollBack();
               throw Ex;
           }
           finally
           {
               if (conManager.IsNotNull())
               {
                   conManager.Dispose();
               }
           }
       }
       private void ReSetSPName(CustomList<Contact> ContactList,CustomList<ContactCategoryMapping> ContactCategoryMappingList,CustomList<ContactSubCategoryMapping> ContactSubCategoryMappingList)
       {
           #region Contact
           ContactList.InsertSpName = "spInsertContact";
           ContactList.UpdateSpName = "spUpdateContact";
           ContactList.DeleteSpName = "spDeleteContact";
           #endregion
           #region ContactCategoryMapping
           ContactCategoryMappingList.InsertSpName = "spInsertContactCategoryMapping";
           ContactCategoryMappingList.UpdateSpName = "spUpdateContactCategoryMapping";
           ContactCategoryMappingList.DeleteSpName = "spDeleteContactCategoryMapping";
           #endregion
           #region ContactSubCategoryMapping
           ContactSubCategoryMappingList.InsertSpName = "spInsertContactSubCategoryMapping";
           ContactSubCategoryMappingList.UpdateSpName = "spUpdateContactSubCategoryMapping";
           ContactSubCategoryMappingList.DeleteSpName = "spDeleteContactSubCategoryMapping";
           #endregion
       }
    }
}
