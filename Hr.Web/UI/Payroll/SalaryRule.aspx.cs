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
using Enc = ASL.STATIC.EncDec;

namespace Hr.Web.UI.Payroll
{
    public partial class SalaryRule : PageBase
    {
        SalaryRuleManager manager = new SalaryRuleManager();
        #region Constractor
        public SalaryRule()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Variable
        private CustomList<SalaryRuleBackup> grdSalaryRuleList
        {
            get
            {
                if (Session["SalaryRule_grdSalaryRuleList"] == null)
                    return new CustomList<SalaryRuleBackup>();
                else
                    return (CustomList<SalaryRuleBackup>)Session["SalaryRule_grdSalaryRuleList"];
            }
            set
            {
                Session["SalaryRule_grdSalaryRuleList"] = value;
            }
        }
        private CustomList<SalaryHead> SalaryHeadList
        {
            get
            {
                if (Session["SalaryRule_SalaryHeadList"] == null)
                    return new CustomList<SalaryHead>();
                else
                    return (CustomList<SalaryHead>)Session["SalaryRule_SalaryHeadList"];
            }
            set
            {
                Session["SalaryRule_SalaryHeadList"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
                txtApproveBy_nc.Text = Enc.Decrypt(CurrentUserSession.UserName, ASL.STATIC.StaticInfo.encString);
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget == "SearchSalaryRule")
                {
                    SalaryRuleBackup searchSalaryRule = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as SalaryRuleBackup;
                    if (searchSalaryRule.IsNotNull())
                    {
                        txtSalaryRuleID.Text = searchSalaryRule.SalaryRuleCode;
                        grdSalaryRuleList = manager.GetAllSalaryRuleBackup(searchSalaryRule.SalaryRuleCode);
                        if (grdSalaryRuleList.Count != 0)
                        {
                            chkApproved.Checked = grdSalaryRuleList[0].IsApproved;
                            txtApprovalDate.Text = grdSalaryRuleList[0].ApprovalDate == DateTime.MinValue ? string.Empty : grdSalaryRuleList[0].ApprovalDate.ToShortDateString();
                            txtApproveBy_nc.Text = grdSalaryRuleList[0].ApproveBy;
                        }
                    }
                }
            }
        }

        #region All Method
        private void InitializeSession()
        {
            try
            {
                grdSalaryRuleList = new CustomList<SalaryRuleBackup>();
                SalaryHeadList = new CustomList<SalaryHead>();
                SalaryHeadList = manager.GetAllSalaryHeadForSalaryRule();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion

        #region Button Event
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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                txtSalaryRuleID.Text = StaticInfo.NewIDString;
                RadioButton rdoObj = (RadioButton)ucSalaryRule.FindControl("rdoFixed");
                RadioButton rdoHigher = (RadioButton)ucSalaryRule.FindControl("rdoHigher");
                RadioButton rdoFixed1 = (RadioButton)ucSalaryRule.FindControl("rdoFixed1");
                rdoObj.Checked = true;
                rdoHigher.Checked = true;
                rdoFixed1.Checked = true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<SalaryRuleBackup> items = manager.GetAllSalaryRuleBackup();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("SalaryRuleCode", "Salary Rule Code");

                StaticInfo.SearchItem(items, "Shift Rule Info", "SearchSalaryRule", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(SalaryRuleBackup), columns), 500);
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<SalaryRuleBackup> lstSalaryRuleBackup = grdSalaryRuleList;
                if (lstSalaryRuleBackup.Count != 0)
                {
                    lstSalaryRuleBackup.ForEach(f => f.Delete());
                    if (CheckUserAuthentication(lstSalaryRuleBackup).IsFalse()) return;
                    manager.DeletelstSalaryRuleBackup(ref lstSalaryRuleBackup);
                    ClearControls();
                    this.SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<SalaryRuleBackup> SalaryRuleBackupList = new CustomList<SalaryRuleBackup>();
                SalaryRuleBackupList = (CustomList<SalaryRuleBackup>)HttpContext.Current.Session["SalaryRule_grdSalaryRuleList"];
                CustomList<ASL.Hr.DAO.SalaryRule> SRList = new CustomList<ASL.Hr.DAO.SalaryRule>();
                CustomList<ASL.Hr.DAO.SalaryRule> DeletedSRList = new CustomList<ASL.Hr.DAO.SalaryRule>();
                if (chkApproved.Checked && chkApproved.Enabled)
                {
                    foreach (SalaryRuleBackup sRB in SalaryRuleBackupList)
                    {
                        sRB.ApprovalDate = txtApprovalDate.Text.ToDateTime();
                        sRB.ApproveBy = txtApproveBy_nc.Text;
                        sRB.IsApproved = chkApproved.Checked;

                        ASL.Hr.DAO.SalaryRule sR = new ASL.Hr.DAO.SalaryRule();
                        sR.SalaryRuleCode = sRB.SalaryRuleCode;
                        sR.SalaryHeadKey = sRB.SalaryHeadKey;
                        sR.sCriteria = sRB.sCriteria;
                        sR.ParentHeadID = sRB.ParentHeadID;
                        sR.ParentHeadValue = sRB.ParentHeadValue;
                        sR.PartialHeadID = sRB.PartialHeadID;
                        sR.PartialHeadValue = sRB.PartialHeadValue;
                        sR.IsFixed = sRB.IsFixed;
                        sR.IsHigher = sRB.IsHigher;
                        sR.Formula1 = sRB.Formula1;
                        sR.Formula2 = sRB.Formula2;
                        SRList.Add(sR);

                        ASL.Hr.DAO.SalaryRule deletedSR = new ASL.Hr.DAO.SalaryRule();
                        deletedSR.SalaryRuleCode = sRB.SalaryRuleCode;
                        deletedSR.Delete();
                        DeletedSRList.Add(deletedSR);
                    }
                }
                if (SalaryRuleBackupList.Count != 0)
                {
                    if (!CheckUserAuthentication(SalaryRuleBackupList, SRList, DeletedSRList)) return;
                    manager.SaveSalaryRule(ref SalaryRuleBackupList, ref DeletedSRList, ref SRList);
                    txtSalaryRuleID.Text = manager.SalaryRuleCode;
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

        #region All Methods
        private void ClearControls()
        {
            try
            {
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
                grdSalaryRuleList = new CustomList<SalaryRuleBackup>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}