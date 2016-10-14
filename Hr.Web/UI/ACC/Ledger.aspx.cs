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
using ReportSuite.DAO;

namespace Hr.Web.UI.ACC
{
    public partial class Ledger : PageBase
    {
        LedgerManager manager = new LedgerManager();
        VoucherManager _voucherManager = new VoucherManager();
        #region Constructur
        public Ledger()
        {
            RequiresAuthorization = true;
        }
        #endregion
        private CustomList<Acc_VoucherDet> LedgerList
        {
            get
            {
                if (Session["Ledger_AccVoucherDetList"] == null)
                    return new CustomList<Acc_VoucherDet>();
                else
                    return (CustomList<Acc_VoucherDet>)Session["Ledger_AccVoucherDetList"];
            }
            set
            {
                Session["Ledger_AccVoucherDetList"] = value;
            }
        }
        private CustomList<Acc_COA> AccCOAList
        {
            get
            {
                if (Session["Voucher_AccCOAList"] == null)
                    return new CustomList<Acc_COA>();
                else
                    return (CustomList<Acc_COA>)Session["Voucher_AccCOAList"];
            }
            set
            {
                Session["Voucher_AccCOAList"] = value;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                LedgerList = new CustomList<Acc_VoucherDet>();
                InitializeCombo();
                txtFromDate.Text = DateTime.Now.ToString(StaticInfo.GridDateFormatAcc);
                txtToDate.Text = DateTime.Now.ToString(StaticInfo.GridDateFormatAcc);
            }

        }
        #region All Methods
        private void InitializeCombo()
        {
            try
            {

                //Loding Company
                ddlCompany.DataSource = _voucherManager.GetCompany();
                ddlCompany.DataTextField = "HKName";
                ddlCompany.DataValueField = "HKID";
                ddlCompany.DataBind();
                //if (CurrentUserSession.IsAdmin)
                //{
                //    ddlCompany.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                //    ddlCompany.SelectedIndex = 0;
                //}

                AccCOAList = new CustomList<Acc_COA>();
                AccCOAList = _voucherManager.GetAllAcc_COA_ByLevel(1);

                //formatCOA();
                //AccCOAList = lst;


                ddlAccountHead.DataSource = AccCOAList;
                ddlAccountHead.DataTextField = "COAName";
                ddlAccountHead.DataValueField = "COAKey";
                ddlAccountHead.DataBind();
                ddlAccountHead.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlAccountHead.SelectedIndex = 0;


            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private CustomList<Acc_COA> lst = new CustomList<Acc_COA>();

        private void formatCOA()
        {
            lst.Clear();
            foreach (Acc_COA item in AccCOAList)
            {
                if (item.ParentKey == null)
                {
                    Acc_COA atom = new Acc_COA();
                    atom.COAKey = item.COAKey;
                    atom.COALevel = item.COALevel;
                    atom.COAName = item.COAName;
                    atom.ParentKey = item.ParentKey;
                    atom.COACode = item.COACode;
                    atom.COACodeClient = item.COACodeClient;
                    atom.IsActive = item.IsActive;
                    atom.IsPostingHead = item.IsPostingHead;
                    lst.Add(atom);
                    FillChild(atom, item.COAKey);

                }
            }
        }

        public int FillChild(Acc_COA parent, Int64 coaKey)
        {
            CustomList<Acc_COA> list = AccCOAList.FindAll(p => p.ParentKey == coaKey);

            if (list.Count > 0)
            {
                foreach (Acc_COA item in list)
                {
                    Acc_COA atom = new Acc_COA();
                    atom.COAKey = item.COAKey;
                    atom.COALevel = item.COALevel;
                    atom.COAName = item.COAName.PadLeft(item.COAName.Length + ((item.COALevel - 1) * 5), '-');
                    atom.ParentKey = item.ParentKey;
                    atom.COACode = item.COACode;
                    atom.COACodeClient = item.COACodeClient;
                    atom.IsActive = item.IsActive;
                    atom.IsPostingHead = item.IsPostingHead;
                    lst.Add(atom);
                    FillChild(atom, item.COAKey);
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        #endregion
        #region Button Event
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Account"] = "Ledger";
                Session["OrgKey"] = ddlCompany.SelectedValue;
                Session["FromDate"] = txtFromDate.Text;
                Session["ToDate"] = txtToDate.Text;
                Session["COAKey"] = ddlAccountHead.SelectedValue;
                Report.ReportPath = Server.MapPath(@"~\ASTReports\GeneralLedger.rdl");
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