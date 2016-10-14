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
using System.Collections;
using System.Data.SqlClient;

namespace Hr.Web.UI.Payroll
{
    public partial class MiscAllowDedEntry : PageBase
    {
        MiscAllowDedManager manager = new MiscAllowDedManager();
        #region Constractor
        public MiscAllowDedEntry()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Variable
        private CustomList<SalaryHead> SalaryHeadList
        {
            get
            {
                if (Session["MiscAllowDedEntry_SalaryHeadList"] == null)
                    return new CustomList<SalaryHead>();
                else
                    return (CustomList<SalaryHead>)Session["MiscAllowDedEntry_SalaryHeadList"];
            }
            set
            {
                Session["MiscAllowDedEntry_SalaryHeadList"] = value;
            }
        }
        private CustomList<MiscEntryDynamicGrid> MiscEntryDynamicGridList
        {
            get
            {
                if (Session["MiscAllowDedEntry_MiscEntryDynamicGridList"] == null)
                    return new CustomList<MiscEntryDynamicGrid>();
                else
                    return (CustomList<MiscEntryDynamicGrid>)Session["MiscAllowDedEntry_MiscEntryDynamicGridList"];
            }
            set
            {
                Session["MiscAllowDedEntry_MiscEntryDynamicGridList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "SelectedTab_Test")
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "selectedtab", "selectedtab=1", true);
                }
                else
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "selectedtab", "selectedtab=0", true);
                }
            }
        }
        #region All Method
        private void InitializeSession()
        {
            try
            {
                SalaryHeadList = new CustomList<SalaryHead>();
                SalaryHeadList = SalaryHead.GetAllSalaryHeadForMisc();
                MiscEntryDynamicGridList = new CustomList<MiscEntryDynamicGrid>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void ClearControls()
        {
            try
            {
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
                CustomList<HRM_Emp> EmpList=new CustomList<HRM_Emp>();
                HttpContext.Current.Session["View_EmpList"] = EmpList;
                InitializeSession();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Events
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<UploadSalary> UploadSalaryList = new CustomList<UploadSalary>();
                CustomList<MiscEntryDynamicGrid> lstMiscEntryDynamicGrid = MiscEntryDynamicGridList;

                CustomList<SalaryHead> HeadList = (CustomList<SalaryHead>)HttpContext.Current.Session["MiscAllowDedEntry_SalaryHeadList"];
                CustomList<SalaryHead> CheckedHeadList = HeadList.FindAll(f => f.IsChecked);
                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> CheckedEmpList = EmpList.FindAll(f => f.IsChecked);
                foreach (HRM_Emp emp in CheckedEmpList)
                {
                    int headCount = 1;
                    MiscEntryDynamicGrid item = lstMiscEntryDynamicGrid.Find(f => f.EmpKey == emp.EmpKey);
                    foreach (SalaryHead sH in CheckedHeadList)
                    {
                        UploadSalary newUploadSalary = new UploadSalary();
                        newUploadSalary.EmpKey = emp.EmpKey;
                        if (headCount == 1)
                        {
                            newUploadSalary.SalaryHeadKey = item.SalaryHeadKey1;
                            newUploadSalary.Amount = item.HeadName1.ToDecimal();
                        }
                        else if (headCount == 2)
                        {
                            newUploadSalary.SalaryHeadKey = item.SalaryHeadKey2;
                            newUploadSalary.Amount = item.HeadName2.ToDecimal();
                        }
                        else if (headCount == 3)
                        {
                            newUploadSalary.SalaryHeadKey = item.SalaryHeadKey3;
                            newUploadSalary.Amount = item.HeadName3.ToDecimal();
                        }
                        else if (headCount == 4)
                        {
                            newUploadSalary.SalaryHeadKey = item.SalaryHeadKey4;
                            newUploadSalary.Amount = item.HeadName4.ToDecimal();
                        }
                        else if (headCount == 5)
                        {
                            newUploadSalary.SalaryHeadKey = item.SalaryHeadKey5;
                            newUploadSalary.Amount = item.HeadName5.ToDecimal();
                        }
                        else if (headCount == 6)
                        {
                            newUploadSalary.SalaryHeadKey = item.SalaryHeadKey6;
                            newUploadSalary.Amount = item.HeadName6.ToDecimal();
                        }
                        else if (headCount == 7)
                        {
                            newUploadSalary.SalaryHeadKey = item.SalaryHeadKey7;
                            newUploadSalary.Amount = item.HeadName7.ToDecimal();
                        }
                        newUploadSalary.FromDate = txtFromDate.Text.ToDateTime();
                        newUploadSalary.ToDate = txtToDate.Text.ToDateTime();
                        newUploadSalary.Remarks = item.Remarks;
                        headCount++;
                        UploadSalaryList.Add(newUploadSalary);
                    }
                }
                if (UploadSalaryList.Count != 0)
                {
                    if (!CheckUserAuthentication(UploadSalaryList)) return;
                    manager.SaveUploadSalary(ref UploadSalaryList);
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
        #endregion
    }
}