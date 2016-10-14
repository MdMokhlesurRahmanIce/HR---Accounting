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
using System.Data.SqlClient;
using System.Text;

namespace Hr.Web.UI.Payroll
{
    public partial class AttendancePaymentInfo : PageBase
    {
        AttPaymentInfoManager manager = new AttPaymentInfoManager();
        #region session variables
        private CustomList<AttPaymentRuleCriteria> AttPaymentRuleCriteriaList
        {
            get
            {
                if (Session["AttendancePaymentInfo_AttPaymentRuleCriteriaList"] == null)
                    return new CustomList<AttPaymentRuleCriteria>();
                else
                    return (CustomList<AttPaymentRuleCriteria>)Session["AttendancePaymentInfo_AttPaymentRuleCriteriaList"];
            }
            set
            {
                Session["AttendancePaymentInfo_AttPaymentRuleCriteriaList"] = value;
            }
        }
        private CustomList<LeavePolicyMaster> LeavePolicyList
        {
            get
            {
                if (Session["AttendancePaymentInfo_LeavePolicyList"] == null)
                    return new CustomList<LeavePolicyMaster>();
                else
                    return (CustomList<LeavePolicyMaster>)Session["AttendancePaymentInfo_LeavePolicyList"];
            }
            set
            {
                Session["AttendancePaymentInfo_LeavePolicyList"] = value;
            }
        }
        private CustomList<AttPaymentRuleAmount> AttPaymentRuleAmountList
        {
            get
            {
                if (Session["AttendancePaymentInfo_AttPaymentRuleAmountList"] == null)
                    return new CustomList<AttPaymentRuleAmount>();
                else
                    return (CustomList<AttPaymentRuleAmount>)Session["AttendancePaymentInfo_AttPaymentRuleAmountList"];
            }
            set
            {
                Session["AttendancePaymentInfo_AttPaymentRuleAmountList"] = value;
            }
        }
        private CustomList<SalaryHead> SalaryHeadList
        {
            get
            {
                if (Session["AttendancePaymentInfo_SalaryHeadList"] == null)
                    return new CustomList<SalaryHead>();
                else
                    return (CustomList<SalaryHead>)Session["AttendancePaymentInfo_SalaryHeadList"];
            }
            set
            {
                Session["AttendancePaymentInfo_SalaryHeadList"] = value;
            }
        }
        private CustomList<AttPaymentRule> AttPaymentRuleList
        {
            get
            {
                if (Session["AttendancePaymentInfo_AttPaymentRuleList"] == null)
                    return new CustomList<AttPaymentRule>();
                else
                    return (CustomList<AttPaymentRule>)Session["AttendancePaymentInfo_AttPaymentRuleList"];
            }
            set
            {
                Session["AttendancePaymentInfo_AttPaymentRuleList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSession();
                InitializeCombo();
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                AttPaymentRuleCriteriaList = new CustomList<AttPaymentRuleCriteria>();
                LeavePolicyList = new CustomList<LeavePolicyMaster>();
                AttPaymentRuleAmountList = new CustomList<AttPaymentRuleAmount>();
               // LeavePolicyList = manager.GetAllLV_LeavePolicyMasterForAttPaymentInfo();
                SalaryHeadList = new CustomList<SalaryHead>();
                AttPaymentRuleList = new CustomList<AttPaymentRule>();
                SalaryHeadList = manager.GetAllSalaryHead();
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
                ddlSalaryHead.DataSource = SalaryHeadList;
                ddlSalaryHead.DataTextField = "HeadName";
                ddlSalaryHead.DataValueField = "SalaryHeadKey";
                ddlSalaryHead.DataBind();
                ddlSalaryHead.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlSalaryHead.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnDefine_Click(object sender, EventArgs e)
        {
            try
            {
                //Start Att Payment Rule
                AttPaymentRule pRObj = new AttPaymentRule();
                pRObj.AttPaymentRuleCode = txtAttPaymentRuleName.Text;
                if (rdoAbsenteeism.Checked)
                    pRObj.RuleFor = "AbsenteeismRule";
                else if (rdoLate.Checked)
                    pRObj.RuleFor = "LateRule";
                else if (rdoEarlyOut.Checked)
                    pRObj.RuleFor = "EarlyOutRule";
                else if (rdoLateAndEarlyOut.Checked)
                    pRObj.RuleFor = "LateAndEarlyOutRule";
                else if (rdoAttBonus.Checked)
                    pRObj.RuleFor = "AttBonusRule";
                else if (rdoHolidayBonus.Checked)
                    pRObj.RuleFor = "HolidayBonusRule";

                if (rdoCalendar.Checked)
                {
                    pRObj.DaysInMonth = 0;
                    pRObj.isCalander = true;
                }
                else if (rdoWorking.Checked)
                {
                    pRObj.DaysInMonth = 0;
                    pRObj.isWorking = true;
                    if (chkExcludeWeekend.Checked)
                        pRObj.ExcludingWeek = true;
                    if (chkExcludeHoliday.Checked)
                        pRObj.ExcludingHoliday = true;
                }
                else if (rdoFixed.Checked)
                {
                    pRObj.DaysInMonth = txtDays.Text.ToInt();
                }
                if (rdoNoOfLate.Checked)
                    pRObj.IsNoOfLate = true;
                if (rdoConsecutiveLate.Checked)
                    pRObj.IsNoOfLate = false;
                if (txtLateDays.Text != "")
                    pRObj.LateDays = txtLateDays.Text.ToInt();
                if(rdoDays.Checked)
                    pRObj.LateActionIsDays = true;
                if(rdoHours.Checked)
                    pRObj.LateActionIsDays = false;
                if (txtLateDays.Text != "")
                    pRObj.LateAction = txtLateDays.Text.ToInt();
                AttPaymentRuleList.Add(pRObj);
                //End Att Payment Rule
                //Start Payment policy
                AttPaymentRuleAmount attPayRuleAmount = AttPaymentRuleAmountList.Find(f => f.SalaryHeadID==txtPaymentName.Text);
                CheckBox rdoFixedUC = (CheckBox)ucSalaryRule.FindControl("rdoFixed");
                if (rdoFixedUC.Checked)
                {
                    attPayRuleAmount.sCriteria = "Fixed";
                    TextBox txtParentHeadAmount=(TextBox)ucSalaryRule.FindControl("txtParentHeadAmount");
                    attPayRuleAmount.ParentHeadValue = txtParentHeadAmount.Text.ToDecimal();
                }
                CheckBox rdoPercentage = (CheckBox)ucSalaryRule.FindControl("rdoPercentage");
                if (rdoPercentage.Checked)
                {
                    attPayRuleAmount.sCriteria = "Percentage";
                    DropDownList ddlParentHead = (DropDownList)ucSalaryRule.FindControl("ddlParentHead");
                    TextBox txtParentHeadAmount = (TextBox)ucSalaryRule.FindControl("txtParentHeadAmount");
                    attPayRuleAmount.ParentHeadValue = txtParentHeadAmount.Text.ToDecimal();
                    attPayRuleAmount.ParentHeadID = ddlParentHead.SelectedValue;
                }
                CheckBox rdoPartial = (CheckBox)ucSalaryRule.FindControl("rdoPartial");
                if (rdoPartial.Checked)
                {
                    attPayRuleAmount.sCriteria = "Partial";
                    DropDownList ddlParentHead = (DropDownList)ucSalaryRule.FindControl("ddlParentHead");
                    TextBox txtParentHeadAmount = (TextBox)ucSalaryRule.FindControl("txtParentHeadAmount");
                    attPayRuleAmount.ParentHeadValue = txtParentHeadAmount.Text.ToDecimal();
                    attPayRuleAmount.ParentHeadID = ddlParentHead.SelectedValue;
                    DropDownList ddlPartialHead = (DropDownList)ucSalaryRule.FindControl("ddlPartialHead");
                    TextBox txtPartialHeadValue = (TextBox)ucSalaryRule.FindControl("txtPartialHeadValue");
                    attPayRuleAmount.PartialHeadValue = txtPartialHeadValue.Text.ToDecimal();
                    attPayRuleAmount.PartialHeadID = ddlPartialHead.SelectedValue;
                    CheckBox rdoHigher = (CheckBox)ucSalaryRule.FindControl("rdoHigher");
                    if (rdoHigher.Checked)
                        attPayRuleAmount.IsHigher = true;
                    CheckBox rdoLower = (CheckBox)ucSalaryRule.FindControl("rdoLower");
                    if (rdoLower.Checked)
                        attPayRuleAmount.IsHigher = false;
                }
                CheckBox rdoFixed1 = (CheckBox)ucSalaryRule.FindControl("rdoFixed1");
                CheckBox rdoProportionate = (CheckBox)ucSalaryRule.FindControl("rdoProportionate");
                if (rdoFixed1.Checked)
                    attPayRuleAmount.IsFixed = true;
                if(rdoProportionate.Checked)
                    attPayRuleAmount.IsFixed = false;
                attPayRuleAmount.ReportHeadID = ddlSalaryHead.SelectedValue;
                //End Payment Policy

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}