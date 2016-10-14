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

namespace Hr.Web.UI.ACC
{
    public partial class Voucher : PageBase
    {
        VoucherManager manager = new VoucherManager();
        #region Constructor
        public Voucher()
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
        private CustomList<Acc_COA> AccCOAList
        {
            get
            {
                if (Session["PFVoucher_AccCOAList"] == null)
                    return new CustomList<Acc_COA>();
                else
                    return (CustomList<Acc_COA>)Session["PFVoucher_AccCOAList"];
            }
            set
            {
                Session["PFVoucher_AccCOAList"] = value;
            }
        }
        private CustomList<Acc_COA> AccCOAListAll
        {
            get
            {
                if (Session["PFVoucher_AccCOAListAll"] == null)
                    return new CustomList<Acc_COA>();
                else
                    return (CustomList<Acc_COA>)Session["PFVoucher_AccCOAListAll"];
            }
            set
            {
                Session["PFVoucher_AccCOAListAll"] = value;
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
                String match = HttpContext.Current.Request.QueryString["Match"];
                if (match == "editVoucher")
                {
                    InitializeCombo();
                    InitializeSession();
                    String vocherNo = HttpContext.Current.Request.QueryString["VoucherNo"];
                    Acc_Voucher item = manager.GetAllAcc_Voucher(vocherNo);
                    CustomList<Acc_Voucher> VoucherList = new CustomList<Acc_Voucher>();
                    VoucherList.Add(item);
                    AccVoucherList = VoucherList;
                    PopulatePFVoucherInformation(item);
                }
                else
                {
                    InitializeCombo();
                    btnNew_Click(null, null);
                }
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget == "SearchPFVoucher")
                {
                    Acc_Voucher searchAccVoucher = Session[StaticInfo.SearchSessionVarName] as Acc_Voucher;
                    CustomList<Acc_Voucher> VoucherList = new CustomList<Acc_Voucher>();
                    VoucherList.Add(searchAccVoucher);
                    AccVoucherList = VoucherList;
                    if (searchAccVoucher.IsNotNull())
                        PopulatePFVoucherInformation(searchAccVoucher);
                }
                else if (eventTarget == "vou_delete")
                {
                    btnDelete_Click(null, null);
                }
            }
        }
        #region All Methods
        private void PopulatePFVoucherInformation(Acc_Voucher aV)
        {
            try
            {
                SetDataInControls(aV);
                AccVoucherDetList = manager.GetAllAcc_VoucherDet(aV.VoucherKey);
                //if (AccVoucherDetList.Count == 2)
                //{
                //    ddlDebit.SelectedValue = AccVoucherDetList[0].COAKey.ToString();
                //    txtDrAmount.Text = AccVoucherDetList[0].Dr.ToString();
                //    ddlCredit.SelectedValue = AccVoucherDetList[1].COAKey.ToString();
                //    txtCreditAmount.Text = AccVoucherDetList[1].Cr.ToString();
                //}
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetDataInControls(Acc_Voucher aV)
        {
            try
            {
                txtVoucher.Text = aV.VoucherNo;
                txtVoucherDate_nc.Text = aV.VoucherDate == DateTime.MinValue ? string.Empty : aV.VoucherDate.ToString(StaticInfo.GridDateFormatAcc);
                ddlCompany_nc.SelectedValue = aV.OrgKey.ToString();
                if (aV.VoucherTypeKey != 0)
                    ddlVoucherType_nc.SelectedValue = ddlVoucherType_nc.Items.FindByValue(aV.VoucherTypeKey.ToString()) == null ? "" : ddlVoucherType_nc.Items.FindByValue(aV.VoucherTypeKey.ToString()).Value;
                if (ddlVoucherType_nc.SelectedItem.Text == "BP" || ddlVoucherType_nc.SelectedItem.Text == "BR")
                {
                    txtChequeNo.Text = aV.CheckNo;
                    if (aV.CheckDate.IsNotNull())
                    {
                        txtChequeDate.Text = aV.CheckDate.ToStringOrDefault(StaticInfo.GridDateFormat, null);
                    }
                    txtChequeNo.Enabled = true;
                    txtChequeDate.Enabled = true;
                }
                else
                {
                    txtChequeNo.Enabled = false;
                    txtChequeDate.Enabled = false;
                }
                txtPayeeOrRecipient.Text = aV.PayRec;
                txtVoucherDescription.Text = aV.VoucherDesc;
                txtChequeNo.Text = aV.CheckNo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitializeSession()
        {
            try
            {
                AccVoucherList = new CustomList<Acc_Voucher>();
                AccVoucherDetList = new CustomList<Acc_VoucherDet>();
                AccCOAList = new CustomList<Acc_COA>();
                AccCOAList = manager.GetAllAcc_COA_ByLevel(1);
                //AccCOAListAll = new CustomList<Acc_COA>();
                //AccCOAListAll = manager.GetAllAcc_COA_ByLevelAll(1);
                //formatCOA();
                //AccCOAList = lst;
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
                //if (CurrentUserSession.IsAdmin)
                //{
                //    ddlCompany_nc.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                //    ddlCompany_nc.SelectedIndex = 0;
                //}
                //Loding Voucher Type GetAllAcc_VoucherType
                ddlVoucherType_nc.DataSource = manager.GetAllAcc_VoucherType();
                ddlVoucherType_nc.DataTextField = "VoucherTypeCode";
                ddlVoucherType_nc.DataValueField = "VoucherTypeKey";
                ddlVoucherType_nc.DataBind();
                ddlVoucherType_nc.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlVoucherType_nc.SelectedIndex = 0;

                //Loding debit
                ddlDebit.DataSource = manager.GetAllAcc_COA_ByLevel(1);
                ddlDebit.DataTextField = "COAName";
                ddlDebit.DataValueField = "COAKey";
                ddlDebit.DataBind();
                ddlDebit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDebit.SelectedIndex = 0;
                //Loding Credit
                ddlCredit.DataSource = manager.GetAllAcc_COA_ByLevel(1);
                ddlCredit.DataTextField = "COAName";
                ddlCredit.DataValueField = "COAKey";
                ddlCredit.DataBind();
                ddlCredit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCredit.SelectedIndex = 0;
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
                obj.PayRec = txtPayeeOrRecipient.Text;
                obj.VoucherDesc = txtVoucherDescription.Text;
                if (txtVoucher.Text.IsNullOrEmpty())
                {
                    obj.EntryUserKey = CurrentUserSession.UserKey;
                }
                else
                {
                    obj.LastUpdateUserKey = CurrentUserSession.UserKey;
                }
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
        //btnAddOrEdit_Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
           
                try
                {
                    Decimal totalDr = 0.0M;
                    Decimal totalCr = 0.0M;
                    CustomList<Acc_Voucher> lstAccVoucher = AccVoucherList;
                    if (lstAccVoucher.Count == 0)
                    {
                        Acc_Voucher newVoucher = new Acc_Voucher();
                        lstAccVoucher.Add(newVoucher);
                    }
                    SetDataFromControlToObject(ref lstAccVoucher);
                    CustomList<Acc_VoucherDet> lstAccVoucherDet = (CustomList<Acc_VoucherDet>)Session["PFVoucher_AccVoucherDetList"];
                    CustomList<Acc_VoucherDet> lstAccVoucherDetAdded = lstAccVoucherDet.FindAll(f => f.IsAdded);
                    CustomList<Acc_VoucherDet> lstAccVoucherDetUpdated = lstAccVoucherDet.FindAll(f => f.IsModified);
                    foreach (Acc_VoucherDet vD in lstAccVoucherDetAdded)
                    {
                        vD.EntryDate = DateTime.Now;
                        vD.EntryUserKey = CurrentUserSession.UserKey;
                    }
                    foreach (Acc_VoucherDet vd in lstAccVoucherDetUpdated)
                    {
                        vd.LastUpdateDate = DateTime.Now;
                        vd.LastUpdateUserKey = CurrentUserSession.UserKey;
                    }

                    foreach (Acc_VoucherDet vD in lstAccVoucherDet)
                    {
                        totalDr += vD.Dr;
                        totalCr += vD.Cr;
                    }
                    if (totalDr == totalCr)
                    {
                        string prifix = ddlVoucherType_nc.SelectedItem.Text;
                        manager.SavePFVoucher(ref lstAccVoucher, ref lstAccVoucherDet, prifix);
                        this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg + ". Voucher No: " + manager.VoucherID);
                    }
                    else
                    {
                        this.ErrorMessage = ("Dr and Cr must be equal.");
                        return;
                    }
                    btnNew_Click(null, null);
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

                ddlDebit.DataSource = manager.GetAllAcc_COA_ByLevel(1);
                ddlDebit.DataTextField = "COAName";
                ddlDebit.DataValueField = "COAKey";
                ddlDebit.DataBind();
                ddlDebit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDebit.SelectedIndex = 0;
            }
            else if (ddlVoucherType_nc.SelectedValue == "3")
            {
                ddlCredit.DataSource = manager.GetAllAcc_COA_CashAtBank();
                ddlCredit.DataTextField = "COAName";
                ddlCredit.DataValueField = "COAKey";
                ddlCredit.DataBind();
                ddlCredit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCredit.SelectedIndex = 0;

                ddlDebit.DataSource = manager.GetAllAcc_COA_ByLevel(1);
                ddlDebit.DataTextField = "COAName";
                ddlDebit.DataValueField = "COAKey";
                ddlDebit.DataBind();
                ddlDebit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDebit.SelectedIndex = 0;
            }
            else if (ddlVoucherType_nc.SelectedValue == "2")
            {
                ddlDebit.DataSource = manager.GetAllAcc_COA_CashInHand();
                ddlDebit.DataTextField = "COAName";
                ddlDebit.DataValueField = "COAKey";
                ddlDebit.DataBind();
                ddlDebit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDebit.SelectedIndex = 0;

                ddlCredit.DataSource = manager.GetAllAcc_COA_ByLevel(1);
                ddlCredit.DataTextField = "COAName";
                ddlCredit.DataValueField = "COAKey";
                ddlCredit.DataBind();
                ddlCredit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCredit.SelectedIndex = 0;
            }
            else if (ddlVoucherType_nc.SelectedValue == "4")
            {
                ddlDebit.DataSource = manager.GetAllAcc_COA_CashAtBank();
                ddlDebit.DataTextField = "COAName";
                ddlDebit.DataValueField = "COAKey";
                ddlDebit.DataBind();
                ddlDebit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDebit.SelectedIndex = 0;

                ddlCredit.DataSource = manager.GetAllAcc_COA_ByLevel(1);
                ddlCredit.DataTextField = "COAName";
                ddlCredit.DataValueField = "COAKey";
                ddlCredit.DataBind();
                ddlCredit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCredit.SelectedIndex = 0;
            }
            else
            {
                ddlDebit.DataSource = manager.GetAllAcc_COA_ByLevel(1);
                ddlDebit.DataTextField = "COAName";
                ddlDebit.DataValueField = "COAKey";
                ddlDebit.DataBind();
                ddlDebit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDebit.SelectedIndex = 0;

                ddlCredit.DataSource = manager.GetAllAcc_COA_ByLevel(1);
                ddlCredit.DataTextField = "COAName";
                ddlCredit.DataValueField = "COAKey";
                ddlCredit.DataBind();
                ddlCredit.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCredit.SelectedIndex = 0;
            }

        }
        #endregion
    }
}
