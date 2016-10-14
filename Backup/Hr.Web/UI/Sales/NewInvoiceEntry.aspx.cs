using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACC.BLL;
using ACC.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;
using ASL.Hr.DAO;
using ReportSuite.DAO;

namespace Hr.Web.UI.Sales
{
    public partial class NewInvoiceEntry : PageBase
    {
        VoucherManager manager = new VoucherManager();
        #region Constructor
        public NewInvoiceEntry()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session
        private CustomList<Acc_Voucher> AccVoucherList
        {
            get
            {
                if (Session["PFVoucher_AccVoucherList"] == null)
                    return new CustomList<Acc_Voucher>();
                else
                    return (CustomList<Acc_Voucher>)Session["PFVoucher_AccVoucherList"];
            }
            set
            {
                Session["PFVoucher_AccVoucherList"] = value;
            }
        }
        private CustomList<Acc_VoucherDet> AccVoucherDetList
        {
            get
            {
                if (Session["PFVoucher_AccVoucherDetList"] == null)
                    return new CustomList<Acc_VoucherDet>();
                else
                    return (CustomList<Acc_VoucherDet>)Session["PFVoucher_AccVoucherDetList"];
            }
            set
            {
                Session["PFVoucher_AccVoucherDetList"] = value;
            }
        }
        private RDLReportDocument Report
        {
            get
            {
                if (Session["ReportViewer_Report"].IsNull())
                    Session["ReportViewer_Report"] = new RDLReportDocument();
                return (RDLReportDocument)Session["ReportViewer_Report"];
            }
            set
            {
                Session["ReportViewer_Report"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                    InitializeCombo();
                    InitializeSession();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget == "SearchEmployee")
                {
                    HRM_Emp searchEmp = Session[StaticInfo.SearchSessionVarName] as HRM_Emp;
                    if (searchEmp.IsNotNull())
                    {
                        txtEmployeeName.Text = searchEmp.EmpName;
                        hfEmpKey.Value = searchEmp.EmpKey.ToString();
                    }
                }
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                AccVoucherList = new CustomList<Acc_Voucher>();
                AccVoucherDetList = new CustomList<Acc_VoucherDet>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            try
            {
                //Loading Company
                ddlCompany_nc.DataSource = manager.GetCompany();
                ddlCompany_nc.DataTextField = "HKName";
                ddlCompany_nc.DataValueField = "HKID";
                ddlCompany_nc.DataBind();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControlToObject(ref CustomList<Acc_Voucher> lstAccVoucher)
        {
            try
            {
                Acc_Voucher obj = lstAccVoucher[0];
                obj.VoucherTypeKey = 5;
                obj.VoucherDate = txtVoucherDate_nc.Text.ToDateTime(StaticInfo.GridDateFormatAcc);
                obj.OrgKey =Convert.ToInt64(ddlCompany_nc.SelectedValue);
                obj.VoucherDesc = txtVoucherDescription.Text;
                obj.EntryUserKey = CurrentUserSession.UserKey;
                obj.EntryDate = DateTime.Now;
                obj.DField_1 = null;
                obj.DField_2 = null;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<Acc_Voucher> lstAccVoucher = AccVoucherList;
                if (lstAccVoucher.Count == 0)
                {
                    Acc_Voucher newVoucher = new Acc_Voucher();
                    lstAccVoucher.Add(newVoucher);
                }
                SetDataFromControlToObject(ref lstAccVoucher);
                CustomList<Acc_VoucherDet> lstAccVoucherDet = (CustomList<Acc_VoucherDet>)Session["PFVoucher_AccVoucherDetList"];
                if (lstAccVoucherDet.Count == 0)
                {
                    Acc_VoucherDet voucherDet = new Acc_VoucherDet();
                    voucherDet.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("Inventory");
                    voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                    voucherDet.Cr = txtCrAmount.Text.ToDecimal();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Criteria = "Sales";
                    lstAccVoucherDet.Add(voucherDet);

                    voucherDet = new Acc_VoucherDet();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("Dist Commission");
                    voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Cr = txtCommission.Text.ToDecimal();
                    voucherDet.Criteria = "Sales";
                    lstAccVoucherDet.Add(voucherDet);

                    voucherDet = new Acc_VoucherDet();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("VAT");
                    voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Cr = txtVAT.Text.ToDecimal();
                    voucherDet.Criteria = "Sales";
                    lstAccVoucherDet.Add(voucherDet);

                    voucherDet = new Acc_VoucherDet();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("GrossSales");
                    voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Dr = txtGrossSales.Text.ToDecimal();
                    voucherDet.Criteria = "Sales";
                    lstAccVoucherDet.Add(voucherDet);

                    voucherDet = new Acc_VoucherDet();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.COAKey= Hr_MasterSetup.GetAllHr_MasterSetup("GrossSales");
                    voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Cr = txtGrossSales.Text.ToDecimal();
                    voucherDet.Criteria = "Sales";
                    lstAccVoucherDet.Add(voucherDet);

                    //Receivable to SO
                    voucherDet = new Acc_VoucherDet();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Dr = txtReceivableAmount.Text.ToDecimal();
                    voucherDet.Criteria = "Sales";
                    lstAccVoucherDet.Add(voucherDet);

                    //Unilever Commission
                    voucherDet = new Acc_VoucherDet();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("Commission");
                    voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Dr =  txtUnileverComm.Text.ToDecimal();
                    voucherDet.Criteria = "Sales";
                    lstAccVoucherDet.Add(voucherDet);

                    //Unilever Commission
                    voucherDet = new Acc_VoucherDet();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("FreeSales");
                    voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Dr = txtUnileverFreeSales.Text.ToDecimal();
                    voucherDet.Criteria = "Sales";
                    lstAccVoucherDet.Add(voucherDet);
                }
                else
                {
                    foreach (Acc_VoucherDet vd in lstAccVoucherDet)
                    {
                        vd.LastUpdateDate = DateTime.Now;
                        vd.LastUpdateUserKey = CurrentUserSession.UserKey;
                    }
                }
                string prifix = "JV";
                manager.SavePFVoucher(ref lstAccVoucher, ref lstAccVoucherDet, prifix);
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg + ". Voucher No: " + manager.VoucherID);
                txtVoucher.Text = manager.VoucherID;
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
        protected void btnClear_Click(object sender, EventArgs e)
        {
            FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
            InitializeSession();
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<HRM_Emp> EmpList = manager.doSearch();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");

                StaticInfo.SearchItem(EmpList, "Emp Info", "SearchEmployee", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 500, GlobalEnums.enumSearchType.StoredProcedured);
            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Account"] = "Voucher";
                Session["OrgKey"] = ddlCompany_nc.SelectedValue;
                Session["VoucherNo"] = txtVoucher.Text;
                Report.ReportPath = Server.MapPath(@"~\ASTReports\Voucher.rdl");
                String script = "javascript:ShowReportViewer();";
                if (ClientScript.IsClientScriptBlockRegistered("scriptShowReportViewer").IsFalse())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptShowReportViewer", script, true);
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        #endregion
    }
}