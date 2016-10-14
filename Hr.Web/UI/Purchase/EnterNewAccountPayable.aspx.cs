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
using ReportSuite.DAO;

namespace Hr.Web.UI.Purchase
{
    public partial class EnterNewAccountPayable : PageBase
    {
        VoucherManager manager = new VoucherManager();
        #region Constructor
        public EnterNewAccountPayable()
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
                    InitializeSession();
                    ddlRecipient_nc_SelectedIndexChanged(null,null);
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
                //Loading Payable 
                ddlDebit_nc.DataSource = manager.GetAllAcc_COAGetPayable();
                ddlDebit_nc.DataTextField = "COAName";
                ddlDebit_nc.DataValueField = "COAKey";
                ddlDebit_nc.DataBind();
                //Loading Recipient
                ddlRecipient_nc.DataSource = manager.GetAllContact();
                ddlRecipient_nc.DataTextField = "Name";
                ddlRecipient_nc.DataValueField = "ID";
                ddlRecipient_nc.DataBind();
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
                obj.VoucherDate = txtVoucherDate_nc.Text.ToDateTime(StaticInfo.GridDateFormatAcc);
                obj.OrgKey = Convert.ToInt64(ddlCompany_nc.SelectedValue);
                obj.VoucherTypeKey = 5;
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
                    voucherDet.COAKey = Convert.ToInt64(ddlDebit_nc.SelectedValue);
                    voucherDet.ContactID = Convert.ToInt32(ddlRecipient_nc.SelectedValue);
                    voucherDet.Dr = txtDrAmount.Text.ToDecimal();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Criteria = "Purchase";
                    lstAccVoucherDet.Add(voucherDet);
                    voucherDet = new Acc_VoucherDet();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.ContactID = Convert.ToInt32(ddlRecipient_nc.SelectedValue);
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Cr = txtDrAmount.Text.ToDecimal();
                    voucherDet.Criteria = "Purchase";
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
                txtVoucher.Text = manager.VoucherID;
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg + ". Voucher No: " + manager.VoucherID);
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
            btnNew_Click(null, null);
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
            InitializeSession();
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
        protected void ddlRecipient_nc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBal_nc.Text = manager.GetBal(Convert.ToInt32(ddlRecipient_nc.SelectedValue)).ToString();
        }
        #endregion
    }
}