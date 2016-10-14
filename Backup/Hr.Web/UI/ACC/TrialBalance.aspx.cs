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
    public partial class TrialBalance : PageBase
    {
        TBManager manager = new TBManager();
        VoucherManager _voucherManager = new VoucherManager();
        #region Constructur
        public TrialBalance()
        {
            RequiresAuthorization = true;
        }
        #endregion
        private CustomList<Acc_VoucherDet> SummaryBalanceList
        {
            get
            {
                if (Session["TrialBalance_SummaryBalanceList"] == null)
                    return new CustomList<Acc_VoucherDet>();
                else
                    return (CustomList<Acc_VoucherDet>)Session["TrialBalance_SummaryBalanceList"];
            }
            set
            {
                Session["TrialBalance_SummaryBalanceList"] = value;
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
                SummaryBalanceList = new CustomList<Acc_VoucherDet>();
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
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Account"] = "TrialBalance";
                Session["OrgKey"] = ddlCompany.SelectedValue;
                Session["FromDate"] = txtFromDate.Text;
                Session["ToDate"] = txtToDate.Text;
                Report.ReportPath = Server.MapPath(@"~\ASTReports\TrialBalance.rdl");
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