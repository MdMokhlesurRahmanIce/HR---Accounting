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
    public partial class PayPayable : PageBase
    {
        VoucherManager manager = new VoucherManager();
        #region Constructor
        public PayPayable()
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

                //Loding Company
                ddlCompany_nc.DataSource = manager.GetCompany();
                ddlCompany_nc.DataTextField = "HKName";
                ddlCompany_nc.DataValueField = "HKID";
                ddlCompany_nc.DataBind();
                //Loding Voucher Type GetAllAcc_VoucherType
                ddlVoucherType_nc.DataSource = manager.GetAllAcc_VoucherTypePayment();
                ddlVoucherType_nc.DataTextField = "VoucherTypeCode";
                ddlVoucherType_nc.DataValueField = "VoucherTypeKey";
                ddlVoucherType_nc.DataBind();
                ddlVoucherType_nc.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlVoucherType_nc.SelectedIndex = 0;
                //Loding Credit
                ddlCredit.DataSource = manager.GetAllAcc_COA_ByLevel(1);
                ddlCredit.DataTextField = "COAName";
                ddlCredit.DataValueField = "COAKey";
                ddlCredit.DataBind();
                ddlCredit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCredit.SelectedIndex = 0;
                //Loading Receipeint
                ddlRecipient_nc.DataSource = manager.GetAllContact();
                ddlRecipient_nc.DataTextField = "Name";
                ddlRecipient_nc.DataValueField = "ID";
                ddlRecipient_nc.DataBind();
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
                obj.VoucherNo = txtVoucher.Text;
                obj.VoucherDate = txtVoucherDate_nc.Text.ToDateTime(StaticInfo.GridDateFormatAcc);
                obj.OrgKey = ddlCompany_nc.SelectedValue.ToInt();
                obj.VoucherTypeKey = ddlVoucherType_nc.SelectedValue.ToInt();
                //obj.PayRec = txtPayeeOrRecipient.Text;
                obj.VoucherDesc = txtVoucherDescription.Text;
                obj.EntryUserKey = CurrentUserSession.UserKey;
                obj.EntryDate = DateTime.Now;
                obj.CheckNo = txtChequeNo.Text;
                if (!string.IsNullOrEmpty(txtChequeDate.Text))
                    obj.CheckDate = txtChequeDate.Text.ToDateTime(StaticInfo.GridDateFormatAcc);
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
                CustomList<Acc_VoucherDet> lstAccVoucherDet = (CustomList<Acc_VoucherDet>)Session["PFVoucher_AccVoucherDetList"];
                if (lstAccVoucherDet.Count == 0)
                {
                    Acc_VoucherDet voucherDet = new Acc_VoucherDet();
                    voucherDet.ContactID = Convert.ToInt32(ddlRecipient_nc.SelectedValue);
                    voucherDet.COAKey = Convert.ToInt64(ddlCredit.SelectedValue);
                    voucherDet.Cr = txtCreditAmount.Text.ToDecimal();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
                    voucherDet.Criteria = "Purchase";
                    lstAccVoucherDet.Add(voucherDet);
                    voucherDet = new Acc_VoucherDet();
                    // voucherDet.COAKey = Convert.ToInt64(ddlCredit.SelectedValue);
                    voucherDet.ContactID = Convert.ToInt32(ddlRecipient_nc.SelectedValue);
                    voucherDet.Dr = txtCreditAmount.Text.ToDecimal();
                    voucherDet.EntryDate = DateTime.Now;
                    voucherDet.EntryUserKey = CurrentUserSession.UserKey;
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
                string prifix = ddlVoucherType_nc.SelectedItem.Text;
                manager.SavePFVoucher(ref lstAccVoucher, ref lstAccVoucherDet, prifix);
                txtVoucher.Text = manager.VoucherID;
                ddlRecipient_nc_SelectedIndexChanged(null, null);
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
            //txtVoucher.Text = StaticInfo.NewIDString;
            txtVoucherDate_nc.Text = DateTime.Now.ToString(StaticInfo.GridDateFormatAcc);
            if (ddlVoucherType_nc.SelectedItem.Text == "BP" || ddlVoucherType_nc.SelectedItem.Text == "BR")
            {
                txtChequeNo.Enabled = true;
                txtChequeDate.Enabled = true;
            }
            else
            {
                txtChequeNo.Enabled = false;
                txtChequeDate.Enabled = false;
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CustomList<Acc_VoucherDet> lstAccVoucherDet = AccVoucherDetList;
            CustomList<Acc_Voucher> lstAccVoucher = AccVoucherList;
            if (lstAccVoucher[0].IsPost == 0)
            {
                lstAccVoucherDet.ForEach(s => s.Delete());
                lstAccVoucher.ForEach(s => s.Delete());
                
                
            }
            else
            {
                lstAccVoucherDet.ForEach(s => s.SetModified());
                SetDataFromControlToObject(ref lstAccVoucher);
                lstAccVoucher.ForEach(s => s.IsPost = 2);
            }
            if (CheckUserAuthentication(lstAccVoucherDet, lstAccVoucher).IsFalse()) return;
            manager.DeleteVoucher(ref lstAccVoucherDet, ref lstAccVoucher);
            btnNew_Click(null, null);
            txtVoucherDate_nc.Text = string.Empty;
            //ddlCompany_nc.SelectedValue = string.Empty;
            ddlVoucherType_nc.SelectedValue = string.Empty;
            this.SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
                InitializeSession();

                CustomList<Acc_Voucher> items = manager.GetAllAcc_Voucher();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("VoucherNo", "Voucher No");
                columns.Add("VoucherDate", "Voucher Date");

                StaticInfo.SearchItem(items, "PF Voucher", "SearchPFVoucher", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(Acc_Voucher), columns), 500);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
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
        protected void ddlVoucherType_nc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVoucherType_nc.SelectedValue == "1")
            {
                ddlCredit.DataSource = manager.GetAllAcc_COA_CashInHand();
                ddlCredit.DataTextField = "COAName";
                ddlCredit.DataValueField = "COAKey";
                ddlCredit.DataBind();
                ddlCredit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCredit.SelectedIndex = 0;
            }
            else if (ddlVoucherType_nc.SelectedValue == "3")
            {
                ddlCredit.DataSource = manager.GetAllAcc_COA_CashAtBank();
                ddlCredit.DataTextField = "COAName";
                ddlCredit.DataValueField = "COAKey";
                ddlCredit.DataBind();
                ddlCredit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCredit.SelectedIndex = 0;
            }

        }
        protected void ddlRecipient_nc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBal_nc.Text = manager.GetBal(Convert.ToInt32(ddlRecipient_nc.SelectedValue)).ToString();
        }
        #endregion
    }
}
