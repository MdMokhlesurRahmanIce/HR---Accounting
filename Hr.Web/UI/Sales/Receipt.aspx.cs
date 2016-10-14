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
    public partial class Receipt : PageBase
    {
        VoucherManager manager = new VoucherManager();
        #region Constructor
        public Receipt()
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
        private RDLReportDocument Report
        {
            get
            {
                if (Session["ReportViewer_Report"].IsNull())
                    Session["ReportViewer_Report"] = new RDLReportDocument();
                //
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
                        txtBal.Text = manager.GetBal(searchEmp.EmpKey).ToString();
                        txtCreditAmount.Text = txtBal.Text;

                        ddlReceiptFromAC_nc.DataSource = manager.GetReceiptHeadList(searchEmp.EmpKey);
                        ddlReceiptFromAC_nc.DataTextField = "COAName";
                        ddlReceiptFromAC_nc.DataValueField = "COAKey";
                        ddlReceiptFromAC_nc.DataBind();
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

                //Loding Company
                ddlCompany_nc.DataSource = manager.GetCompany();
                ddlCompany_nc.DataTextField = "HKName";
                ddlCompany_nc.DataValueField = "HKID";
                ddlCompany_nc.DataBind();
                //Loding Credit  
                ddlCashDebit_nc.DataSource = manager.GetAllAcc_COA_CashInHand();
                ddlCashDebit_nc.DataTextField = "COAName";
                ddlCashDebit_nc.DataValueField = "COAKey";
                ddlCashDebit_nc.DataBind();
                //Loading Cash At Bank
                ddlBankDeposit_nc.DataSource = manager.GetAllAcc_COA_CashAtBank();
                ddlBankDeposit_nc.DataTextField = "COAName";
                ddlBankDeposit_nc.DataValueField = "COAKey";
                ddlBankDeposit_nc.DataBind();
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
                obj.VoucherNo = "";
                obj.VoucherDate = txtVoucherDate_nc.Text.ToDateTime(StaticInfo.GridDateFormatAcc);
                obj.OrgKey = ddlCompany_nc.SelectedValue.ToInt();
                obj.VoucherTypeKey = 5;
                //obj.PayRec = txtPayeeOrRecipient.Text;
                obj.VoucherDesc = txtVoucherDescription.Text;
                obj.EntryUserKey = CurrentUserSession.UserKey;
                obj.EntryDate = DateTime.Now;
                obj.CheckNo = txtChequeNo.Text;
                if (!string.IsNullOrEmpty(txtChequeDate.Text))
                    obj.CheckDate = txtChequeDate.Text.ToDateTime(StaticInfo.GridDateFormat);
                else
                    obj.CheckDate = null;
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
                CustomList<Acc_VoucherDet> lstAccVoucherDet = new CustomList<Acc_VoucherDet>();
                if (lstAccVoucherDet.Count == 0)
                {
                    //Receive From SO
                    Acc_VoucherDet voucherDet = new Acc_VoucherDet();
                    voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                    voucherDet.COAKey = Convert.ToInt64(ddlReceiptFromAC_nc.SelectedValue);
                    voucherDet.Cr = txtCreditAmount.Text.ToDecimal();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Criteria = "Sales";
                    lstAccVoucherDet.Add(voucherDet);
                    //Cash Amount
                    if (txtCashAmount.Text != "")
                    {
                        voucherDet = new Acc_VoucherDet();
                        voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                        voucherDet.COAKey = Convert.ToInt64(ddlCashDebit_nc.SelectedValue);
                        voucherDet.Dr = txtCashAmount.Text.ToDecimal();
                        voucherDet.EntryDate = DateTime.Now;
                        voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                        voucherDet.Criteria = "Sales";
                        lstAccVoucherDet.Add(voucherDet);
                    }
                    //Bank Amount
                    if (txtBankAmount.Text != "")
                    {
                        voucherDet = new Acc_VoucherDet();
                        voucherDet.UserKey = Convert.ToInt32(hfEmpKey.Value);
                        voucherDet.COAKey = Convert.ToInt64(ddlBankDeposit_nc.SelectedValue);
                        voucherDet.Dr = txtBankAmount.Text.ToDecimal();
                        voucherDet.EntryDate = DateTime.Now;
                        voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                        voucherDet.Criteria = "Sales";
                        lstAccVoucherDet.Add(voucherDet);
                    }
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
                btnNew_Click(null,null);
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
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
            InitializeSession();
            txtVoucherDate_nc.Text = DateTime.Now.ToString(StaticInfo.GridDateFormatAcc);
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
        #region Combo Event
        //protected void ddlVoucherType_nc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlVoucherType_nc.SelectedValue == "2")
        //    {
        //        ddlDebit.DataSource = manager.GetAllAcc_COA_ByLevelAll(1, 5);
        //        ddlDebit.DataTextField = "COAName";
        //        ddlDebit.DataValueField = "COAKey";
        //        ddlDebit.DataBind();
        //    }
        //    else if (ddlVoucherType_nc.SelectedValue == "4")
        //    {
        //        ddlDebit.DataSource = manager.GetAllAcc_COA_ByLevelAll(1, 6);
        //        ddlDebit.DataTextField = "COAName";
        //        ddlDebit.DataValueField = "COAKey";
        //        ddlDebit.DataBind();
        //    }
        //    //if (ddlVoucherType_nc.SelectedItem.Text == "BR")
        //    //{
        //    //    txtChequeNo.Enabled = true;
        //    //    txtChequeDate.Enabled = true;
        //    //}
        //    //else
        //    //{
        //    //    txtChequeNo.Enabled = false;
        //    //    txtChequeDate.Enabled = false;
        //    //}
        //}
        #endregion
    }
}