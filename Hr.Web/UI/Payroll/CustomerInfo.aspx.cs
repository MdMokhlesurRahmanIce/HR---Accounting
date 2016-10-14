using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ASL.DATA;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.Web.Framework;

namespace Hr.Web.UI.Payroll
{

    

    

    public partial class CustomerInfo  : PageBase
    {
        HKEntryManager ManagerHKEntry = new HKEntryManager();
        MedicalReinversementManager manager = new MedicalReinversementManager();
        #region session variable
        
        private CustomList<ASL.Hr.DAO.CustomerWisePer> _CustomerWisePer
        {
            get
            {
                if (Session["CustomerInfo_PerchentageList"] == null)
                    return new CustomList<ASL.Hr.DAO.CustomerWisePer>();
                else
                    return (CustomList<ASL.Hr.DAO.CustomerWisePer>)Session["CustomerInfo_PerchentageList"];
            }
            set
            {
                Session["CustomerInfo_PerchentageList"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.HouseKeepingValue> _HkInfo
        {
            get
            {
                if (Session["HKInfo"] == null)
                    return new CustomList<ASL.Hr.DAO.HouseKeepingValue>();
                else
                    return (CustomList<ASL.Hr.DAO.HouseKeepingValue>)Session["HKInfo"];
            }
            set
            {
                Session["HKInfo"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
                InitializeControls();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget.Equals("SearchEmployee"))
                {
                    string EmployeeCode = ((TextBox)this.Header1.FindControl("txtSearch")).Text.ToString();
                }
            }


        }
        public void InitializeSession()
        {
            
                _CustomerWisePer = new CustomList<CustomerWisePer>();
                _HkInfo = new CustomList<HouseKeepingValue>();
            
        }
        public void SetDateFromObjToControl(string EmployeeCode)
        {
            string LeaveYear = ddlLeaveYear.SelectedValue;
          
            CustomList<HRM_Emp> _RunnignEmpInfo = manager.GetSearchEmp(EmployeeCode);
            if (_RunnignEmpInfo.Count != 0)
            {
                ClearControls(EmployeeCode);

                txtEmployeeName.Text = _RunnignEmpInfo[0].EmpName;
                txtDesignation.Text = _RunnignEmpInfo[0].Designation;
                txtDOJ.Text = _RunnignEmpInfo[0].DOJ.ToShortDateString();
                txtStaffCategory.Text = _RunnignEmpInfo[0].StaffCategory;
                
                hfEmpKey.Value =  _RunnignEmpInfo[0].EmpKey.ToString();
               
                imgGarment.ImageUrl = ResolveUrl(_RunnignEmpInfo[0].EmpPicture);
            }
        }
        public void ClearControls(string EmployeeCode)
        {

            txtEmployeeName.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtStaffCategory.Text = string.Empty;
            txtDOJ.Text = string.Empty;
            _CustomerWisePer = new CustomList<CustomerWisePer>();
            _CustomerWisePer = manager.GetAllCustomerInfo(EmployeeCode);
          

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<CustomerWisePer> lstCustomerInfo = (CustomList<CustomerWisePer>)HttpContext.Current.Session["CustomerInfo_PerchentageList"];
                    //(CustomList<CustomerWisePer>)_CustomerWisePer;

                if (lstCustomerInfo.IsNotNull())
                {
                   // if (!CheckUserAuthentication(lstCustomerInfo)) return;
                    CustomList<CustomerWisePer> SavedCustomerInfo = lstCustomerInfo.FindAll(f => f.IsAdded || f.IsModified || f.IsDeleted);
                    foreach (CustomerWisePer mT in SavedCustomerInfo)
                    {
                        if (mT.IsAdded)
                        {

                            mT.EmpKey = Convert.ToInt64(hfEmpKey.Value); //lstCustomerInfo[0].EmpKey;
                                //
                            
                        }
                    }
                    manager.SaveCustomerInfo(ref SavedCustomerInfo);
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

        private void InitializeControls()
        {
            try
            {
                CustomList<ASL.Hr.DAO.HouseKeepingValue> HkList = ManagerHKEntry.GetAllCustomerInfo();
               
                _HkInfo = HkList;

           




            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

       
    }
}