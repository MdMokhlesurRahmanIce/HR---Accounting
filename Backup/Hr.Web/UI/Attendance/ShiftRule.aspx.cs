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

namespace Hr.Web.UI.Attendance
{
    public partial class ShiftRule : PageBase
    {
        ShiftRuleManager manager = new ShiftRuleManager();
        #region Constructur
        public ShiftRule()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<ASL.Hr.DAO.ShiftRule> ShiftRuleMasterList
        {
            get
            {
                if (Session["ShiftRule_ShiftRuleMasterList"] == null)
                    return new CustomList<ASL.Hr.DAO.ShiftRule>();
                else
                    return (CustomList<ASL.Hr.DAO.ShiftRule>)Session["ShiftRule_ShiftRuleMasterList"];
            }
            set
            {
                Session["ShiftRule_ShiftRuleMasterList"] = value;
            }
        }
        private CustomList<ShiftRuleDetail> ShiftRuleDetailList
        {
            get
            {
                if (Session["ShiftRule_ShiftRuleDetailList"] == null)
                    return new CustomList<ShiftRuleDetail>();
                else
                    return (CustomList<ShiftRuleDetail>)Session["ShiftRule_ShiftRuleDetailList"];
            }
            set
            {
                Session["ShiftRule_ShiftRuleDetailList"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.ShiftPlan> ShiftPlanList
        {
            get
            {
                if (Session["ShiftRule_ShiftPlanList"] == null)
                    return new CustomList<ASL.Hr.DAO.ShiftPlan>();
                else
                    return (CustomList<ASL.Hr.DAO.ShiftPlan>)Session["ShiftRule_ShiftPlanList"];
            }
            set
            {
                Session["ShiftRule_ShiftPlanList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeSession();
                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (eventTarget == "SearchShiftRule")
                    {
                        ASL.Hr.DAO.ShiftRule searchShiftRule = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as ASL.Hr.DAO.ShiftRule;
                        ShiftRuleMasterList = new CustomList<ASL.Hr.DAO.ShiftRule>();
                        ShiftRuleMasterList.Add(searchShiftRule);
                        if (searchShiftRule.IsNotNull())
                            PopulateShiftRuleInfo(searchShiftRule);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region All Methods
        private void PopulateShiftRuleInfo(ASL.Hr.DAO.ShiftRule shiftRule)
        {
            try
            {
                txtShiftRuleCode.Text = shiftRule.ShiftRuleCode;
                txtDescription.Text = shiftRule.Description;
                chkDefaultShiftRule.Checked = shiftRule.IsDefaultRule;

                ShiftRuleDetailList = manager.GetAllShiftRuleDetail(shiftRule.ShiftRuleKey);
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
                ShiftRuleDetailList = new CustomList<ShiftRuleDetail>();
                ShiftPlanList = new CustomList<ASL.Hr.DAO.ShiftPlan>();
                ShiftRuleMasterList = new CustomList<ASL.Hr.DAO.ShiftRule>();
                ShiftPlanList = manager.GetAllShiftPlan();
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
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControlToObj(ref CustomList<ASL.Hr.DAO.ShiftRule> lstShiftRule)
        {
            try
            {
                ASL.Hr.DAO.ShiftRule obj = lstShiftRule[0];
                obj.ShiftRuleCode = txtShiftRuleCode.Text;
                obj.Description = txtDescription.Text; ;
                obj.IsDefaultRule = chkDefaultShiftRule.Checked;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        #region Button Event
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                ShiftRuleDetailList = new CustomList<ShiftRuleDetail>();
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
                InitializeSession();
                ShiftRuleDetailList = new CustomList<ShiftRuleDetail>();
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
                CustomList<ASL.Hr.DAO.ShiftRule> lstShiftRule = (CustomList<ASL.Hr.DAO.ShiftRule>)ShiftRuleMasterList;
                if (lstShiftRule.Count == 0)
                {
                    ASL.Hr.DAO.ShiftRule newShiftRule = new ASL.Hr.DAO.ShiftRule();
                    lstShiftRule.Add(newShiftRule);
                }
                SetDataFromControlToObj(ref lstShiftRule);
                CustomList<ASL.Hr.DAO.ShiftRuleDetail> lstShiftRuleDetail = (CustomList<ASL.Hr.DAO.ShiftRuleDetail>)ShiftRuleDetailList;

                if (!CheckUserAuthentication(lstShiftRule, lstShiftRuleDetail)) return;
                manager.SaveShiftRule(lstShiftRule, lstShiftRuleDetail);
                ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
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
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.ShiftRule> items = manager.GetAllShiftRule();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("ShiftRuleCode", "Shift Rule Code");
                columns.Add("Discription", "Discription");

                StaticInfo.SearchItem(items, "Shift Rule Info", "SearchShiftRule", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(ShiftRule), columns), 500);
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
                    CustomList<ASL.Hr.DAO.ShiftRule> lstShiftRule = ShiftRuleMasterList.Copy();
                    CustomList<ShiftRuleDetail> lstShiftRuleDetail = ShiftRuleDetailList.Copy();
                    lstShiftRule.ForEach(f=>f.Delete());
                    lstShiftRuleDetail.ForEach(f=>f.Delete());
                    if (CheckUserAuthentication(lstShiftRule, lstShiftRuleDetail).IsFalse()) return;
                    manager.DeleteShiftRule(lstShiftRule, lstShiftRuleDetail);
                    ClearControls();
                    InitializeSession();
                    this.ErrorMessage = (StaticInfo.DeletedSuccessfullyMsg);
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
        #endregion
        #endregion
    }
}