using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;
//using ASL.Web.Controls;
using System.Collections;
using System.Data.SqlClient;
namespace Hr.Web.UI.Setup
{
    public partial class ContactInfo : PageBase
    {
        ContactManager _manager = new ContactManager();
        #region Session Variables
        private CustomList<Contact> ContactList
        {
            get
            {
                if (Session["ContactInfo_ContactList"] == null)
                    return new CustomList<Contact>();
                else
                    return (CustomList<Contact>)Session["ContactInfo_ContactList"];
            }
            set
            {
                Session["ContactInfo_ContactList"] = value;
            }
        }
        private CustomList<ContactCategory> ContactCategoryList
        {
            get
            {
                if (Session["ContactInfo_ContactCategoryList"] == null)
                    return new CustomList<ContactCategory>();
                else
                    return (CustomList<ContactCategory>)Session["ContactInfo_ContactCategoryList"];
            }
            set
            {
                Session["ContactInfo_ContactCategoryList"] = value;
            }
        }
        private CustomList<ContactSubCategory> ContactSubCategoryList
        {
            get
            {
                if (Session["ContactInfo_ContactSubCategoryList"] == null)
                    return new CustomList<ContactSubCategory>();
                else
                    return (CustomList<ContactSubCategory>)Session["ContactInfo_ContactSubCategoryList"];
            }
            set
            {
                Session["ContactInfo_ContactSubCategoryList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitilizeDropdownList();
                InitializeSession();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "SearchContactInfo")
                {
                    ContactList = new CustomList<Contact>();
                    Contact searchContactInfo = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as Contact;
                    ContactList.Add(searchContactInfo);
                    if (searchContactInfo.IsNotNull())
                    {
                        PopulateContactInfo(searchContactInfo);
                    }
                }
            }
        }
        #region All Methods
        private void PopulateContactInfo(Contact contact)
        {
            try
            {
                txtID.Text = contact.ID.ToString();
                txtName.Text = contact.Name;
                txtCardNo.Text = contact.CardNo;
                txtContactName.Text = contact.ContactPerson;
                txtVATRegNo.Text = contact.VATRegNo;
                ddlCountry.SelectedValue = contact.CountryID.ToString();
                ddlVATStatus.SelectedValue = contact.TarriffID.ToString();
                txtAddress.Text = contact.Address;
                txtPhone.Text = contact.Phone;
                txtMobile.Text = contact.Mobile;
                txtNote.Text = contact.Note;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        private void InitializeSession()
        {
            ContactList = new CustomList<Contact>();
            ContactCategoryList = new CustomList<ContactCategory>();
            ContactSubCategoryList = new CustomList<ContactSubCategory>();
            ContactList = _manager.GetAllContact();
            ContactCategoryList = _manager.GetAllContactCategory();
            ContactSubCategoryList = _manager.GetAllContactSubCategory();
        }
        private void InitilizeDropdownList()
        {
            #region Tarrif Status
            ddlVATStatus.DataSource = _manager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.TarriffStatus);
            ddlVATStatus.DataTextField = "ElementName";
            ddlVATStatus.DataValueField = "ElementKey";
            ddlVATStatus.DataBind();
            ddlVATStatus.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region Country
            CustomList<Gen_Country> CountryList = _manager.GetAllCountry();
            ddlCountry.DataSource = CountryList;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryKey";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region Supplier Type
            ddlType.DataSource = _manager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.SupplierType);
            ddlType.DataTextField = "ElementName";
            ddlType.DataValueField = "ElementKey";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
        }
        private void SetDataFromControlToObj(ref CustomList<Contact> lstContact)
        {
            Contact obj=lstContact[0];
            obj.ID = txtID.Text.ToInt();
            obj.Name = txtName.Text;
            obj.CardNo = txtCardNo.Text;
            obj.ContactPerson = txtContactName.Text;
            obj.VATRegNo = txtVATRegNo.Text;
            obj.Address = txtAddress.Text;
            obj.TarriffID = ddlVATStatus.SelectedValue.ToInt();
            obj.CountryID = ddlCountry.SelectedValue.ToInt();
            obj.Phone = txtPhone.Text;
            obj.Email = txtFax.Text;
            obj.Mobile = txtMobile.Text;
            obj.Note = txtNote.Text;
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<Contact> lstContact = ContactList;
                if (lstContact.Count == 0)
                {
                    Contact newObj = new Contact();
                    lstContact.Add(newObj);
                }
                SetDataFromControlToObj(ref lstContact);
                CustomList<ContactCategory> lstContactCategory = ContactCategoryList.FindAll(f=>f.IsChecked);
                CustomList<ContactSubCategory> lstContactSubCategory = ContactSubCategoryList.FindAll(f=>f.IsChecked);
                CustomList<ContactCategoryMapping> lstContactCategoryMapping = new CustomList<ContactCategoryMapping>();
                CustomList<ContactSubCategoryMapping> lstContactSubCategoryMapping = new CustomList<ContactSubCategoryMapping>();
                CustomList<ContactCategoryMapping> deletedContactCategoryMappingList = new CustomList<ContactCategoryMapping>();
                CustomList<ContactSubCategoryMapping> deletedContactSubCategoryMappingList = new CustomList<ContactSubCategoryMapping>();
                foreach (ContactCategory cC in lstContactCategory)
                {
                    ContactCategoryMapping objCCM = new ContactCategoryMapping();
                    ContactCategoryMapping deletedObj = new ContactCategoryMapping();
                    objCCM.CategoryID = cC.ID;
                    deletedObj.CategoryID = cC.ID;
                    deletedObj.Delete();
                    lstContactCategoryMapping.Add(objCCM);
                    deletedContactCategoryMappingList.Add(deletedObj);
                }
                foreach (ContactSubCategory cCSC in lstContactSubCategory)
                {
                    ContactSubCategoryMapping cSCM = new ContactSubCategoryMapping();
                    ContactSubCategoryMapping deletedObj = new ContactSubCategoryMapping();
                    cSCM.SubCategoryID = cCSC.ID;
                    deletedObj.SubCategoryID = cCSC.ID;
                    deletedObj.Delete();
                    lstContactSubCategoryMapping.Add(cSCM);
                    deletedContactSubCategoryMappingList.Add(deletedObj);
                }
                if (lstContact.Count != 0)
                {
                    //if (!CheckUserAuthentication(SalaryRuleBackupList, SRList, DeletedSRList)) return;
                  _manager.SaveContact(ref lstContact, ref deletedContactCategoryMappingList, ref deletedContactSubCategoryMappingList, ref lstContactCategoryMapping, ref lstContactSubCategoryMapping);
                    //txtSalaryRuleID.Text = manager.SalaryRuleCode;
                    this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                }
            }
            catch (SqlException ex)
            {
                this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<Contact> items = _manager.GetAllContact();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("Name", "Name");
                columns.Add("CardNo", "Card No");

                StaticInfo.SearchItem(items, "Contact Info", "SearchContactInfo", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(Contact), columns), 500);
            }
            catch (Exception ex)
            {

                this.ErrorMessage = ("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        #endregion
    }
}