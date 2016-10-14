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
    public partial class OtherSalaryRule : PageBase
    {
        OtherSalaryRuleManager manager = new OtherSalaryRuleManager();
        #region Session variables
        private CustomList<SalaryHead> SalaryHeadList
        {
            get
            {
                if (Session["OtherSalaryRule_SalaryHeadList"] == null)
                    return new CustomList<SalaryHead>();
                else
                    return (CustomList<SalaryHead>)Session["OtherSalaryRule_SalaryHeadList"];
            }
            set
            {
                Session["OtherSalaryRule_SalaryHeadList"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.OtherSalaryRule> OtherSalaryRuleList
        {
            get
            {
                if (Session["OtherSalaryRule_OtherSalaryRuleList"] == null)
                    return new CustomList<ASL.Hr.DAO.OtherSalaryRule>();
                else
                    return (CustomList<ASL.Hr.DAO.OtherSalaryRule>)Session["OtherSalaryRule_OtherSalaryRuleList"];
            }
            set
            {
                Session["OtherSalaryRule_OtherSalaryRuleList"] = value;
            }
        }
        private CustomList<HourWisePayment> HourWisePaymentList
        {
            get
            {
                if (Session["OtherSalaryRule_HourWisePaymentList"] == null)
                    return new CustomList<HourWisePayment>();
                else
                    return (CustomList<HourWisePayment>)Session["OtherSalaryRule_HourWisePaymentList"];
            }
            set
            {
                Session["OtherSalaryRule_HourWisePaymentList"] = value;
            }
        }
        private CustomList<LeavePolicyMaster> LeaveTypeList
        {
            get
            {
                if (Session["OtherSalaryRule_LeaveTypeList"] == null)
                    return new CustomList<LeavePolicyMaster>();
                else
                    return (CustomList<LeavePolicyMaster>)Session["OtherSalaryRule_LeaveTypeList"];
            }
            set
            {
                Session["OtherSalaryRule_LeaveTypeList"] = value;
            }
        }
        private CustomList<ShiftPlan> ShiftPlanList
        {
            get
            {
                if (Session["OtherSalaryRule_ShiftPlanList"] == null)
                    return new CustomList<ShiftPlan>();
                else
                    return (CustomList<ShiftPlan>)Session["OtherSalaryRule_ShiftPlanList"];
            }
            set
            {
                Session["OtherSalaryRule_ShiftPlanList"] = value;
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
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget == "SearchOtherSalaryRole")
                {
                    OtherSalaryRuleList = new CustomList<ASL.Hr.DAO.OtherSalaryRule>();
                    ASL.Hr.DAO.OtherSalaryRule searchOtherSalaryRule = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as ASL.Hr.DAO.OtherSalaryRule;
                    if (searchOtherSalaryRule.IsNotNull())
                    {
                        PopulateControls(searchOtherSalaryRule);
                        OtherSalaryRuleList.Add(searchOtherSalaryRule);
                        HourWisePaymentList = manager.GetAllHourWisePayment(searchOtherSalaryRule.RuleKey);
                        if (HourWisePaymentList.Count() != 0)
                            chkHourWisePayment.Checked = true;
                    }
                }
            }
        }
        #region All Methods
        private void PopulateControls(ASL.Hr.DAO.OtherSalaryRule oSR)
        {
            try
            {
                //ID = oSR.RuleKey;
                txtOtherSalaryRuleName.Text = oSR.RuleName;
                txtDescription.Text = oSR.Description;
                if (oSR.IsAttBased)
                {
                    rdoPersonalAttn.Checked = true;
                    //dayStatus.Style.Add("display", "inline-block");
                }
                else
                    rdoInGeneral.Checked = true;
                ddlSalaryHead.SelectedValue = oSR.EffectedSalaryHeadID;
                string[] items = oSR.DayStatus.Split(',');
                for (int i = 0; i <= items.Count() - 1; i++)
                {
                    switch (items[i])
                    {
                        case "'P'":
                            chkP.Checked = true;
                            break;
                        case "'L'":
                            chkL.Checked = true;
                            break;
                        case "'A'":
                            chkA.Checked = true;
                            break;
                        case "'LV'":
                            chkLV.Checked = true;
                            break;
                        case "'W'":
                            chkW.Checked = true;
                            break;
                        case "'PW'":
                            chkPW.Checked = true;
                            break;
                        case "'LW'":
                            chkLW.Checked = true;
                            break;
                        case "'H'":
                            chkH.Checked = true;
                            break;
                        case "'PH'":
                            chkPH.Checked = true;
                            break;
                        case "'LH'":
                            chkLH.Checked = true;
                            break;
                        default:
                            break;

                    }
                }
                if (oSR.Shift.IsNotNullOrEmpty())
                {
                    chkConsiderspecificShift.Checked = true;
                    shift.Style.Add("display", "inline");
                    string[] shiftItems = oSR.Shift.Split(',');
                    foreach (ShiftPlan sP in ShiftPlanList)
                    {
                        for (int i = 0; i < shiftItems.Count(); i++)
                        {
                            if (shiftItems[i] == "'" + sP.ShiftID + "'")
                                sP.IsChecked = true;
                        }
                    }
                }
                if (chkLV.Checked)
                {
                    specificLeave.Style.Add("display", "inline");
                    if (oSR.LeaveType.IsNotNullOrEmpty())
                    {
                        chkSpecificLeaveType.Checked = true;
                        string[] LeaveTypes = oSR.LeaveType.Split(',');

                        foreach (LeavePolicyMaster lPM in LeaveTypeList)
                        {
                            for (int i = 0; i < LeaveTypes.Count(); i++)
                            {
                                if (LeaveTypes[i] == "'" + lPM.LeavePolicyID + "'")
                                    lPM.IsChecked = true;
                            }
                        }
                        Leave.Style.Add("display", "inline");
                    }
                }
                if (oSR.IsFixed)
                    rdoFixed.Checked = true;
                else
                    rdoPercentage.Checked = true;
                ddlSalaryHead1.SelectedValue = oSR.SalaryHeadID;
                txtAmount.Text = oSR.Amount.ToString();
                if (oSR.DivisibleFactorType == 1)
                    ddlFixedPerDay.Checked = true;
                else
                    rdoCalculative.Checked = true;
                if (oSR.Factor == 1)
                    rdoCalendar.Checked = true;
                else if (oSR.Factor == 2)
                    rdoWorking.Checked = true;
                else if (oSR.Factor == 3)
                    rdoFixed1.Checked = true;
                if (oSR.Days.IsNotNull())
                    txtDays.Text = oSR.Days.ToString();
                chkExcludeWeekend.Checked = oSR.IsWExclude;
                chkExcludeHoliday.Checked = oSR.IsHExclude;
                oSR.SetModified();

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
                SalaryHeadList = new CustomList<SalaryHead>();
                OtherSalaryRuleList = new CustomList<ASL.Hr.DAO.OtherSalaryRule>();
                HourWisePaymentList = new CustomList<HourWisePayment>();
                LeaveTypeList = new CustomList<LeavePolicyMaster>();
                ShiftPlanList = new CustomList<ShiftPlan>();
                SalaryHeadList = manager.GetAllSalaryHead();
                LeaveTypeList = manager.GetLeaveType();
                ShiftPlanList = manager.GetAllShift();
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
        private void ClearControls()
        {
            try
            {
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
                InitializeSession();
                rdoPersonalAttn.Checked = true;
                rdoFixed.Checked = true;
                ddlFixedPerDay.Checked = true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControlToObject(ref CustomList<ASL.Hr.DAO.OtherSalaryRule> lstOtherSalaryRule)
        {
            try
            {
                ASL.Hr.DAO.OtherSalaryRule oSR = lstOtherSalaryRule[0];
                //ASL.Hr.DAO.OtherSalaryRule searchOtherSalaryRule = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as ASL.Hr.DAO.OtherSalaryRule;
                //if (searchOtherSalaryRule.RuleKey != 0)
                //    oSR.RuleKey = searchOtherSalaryRule.RuleKey;
                oSR.RuleName = txtOtherSalaryRuleName.Text;
                oSR.Description = txtDescription.Text;
                if (rdoPersonalAttn.Checked)
                    oSR.IsAttBased = rdoPersonalAttn.Checked;
                else
                    oSR.IsAttBased = rdoInGeneral.Checked;
                oSR.EffectedSalaryHeadID = ddlSalaryHead.SelectedValue;
                oSR.SalaryHeadID = ddlSalaryHead1.SelectedValue;
                if (rdoFixed.Checked)
                    oSR.IsFixed = rdoFixed.Checked;
                else
                    oSR.IsFixed = rdoPercentage.Checked;
                oSR.Amount = txtAmount.Text.ToDecimal();
                // oSR.DayStatus=
                string dayStatus = "";
                if (chkP.Checked)
                    dayStatus = "'P'";
                if (chkL.Checked)
                {
                    if (dayStatus == "")
                        dayStatus = "'L'";
                    else
                        dayStatus = dayStatus + ",'L'";
                }
                if (chkA.Checked)
                {
                    if (dayStatus == "")
                        dayStatus = "'A'";
                    else
                        dayStatus = dayStatus + ",'A'";
                }
                if (chkLV.Checked)
                {
                    if (dayStatus == "")
                        dayStatus = "'LV'";
                    else
                        dayStatus = dayStatus + ",'LV'";
                }
                if (chkW.Checked)
                {
                    if (dayStatus == "")
                        dayStatus = "'W'";
                    else
                        dayStatus = dayStatus + ",'W'";
                }
                if (chkPW.Checked)
                {
                    if (dayStatus == "")
                        dayStatus = "'PW'";
                    else
                        dayStatus = dayStatus + ",'PW'";
                }
                if (chkPH.Checked)
                {
                    if (dayStatus == "")
                        dayStatus = "'PH'";
                    else
                        dayStatus = dayStatus + ",'PH'";
                }
                if (chkLW.Checked)
                {
                    if (dayStatus == "")
                        dayStatus = "'LW'";
                    else
                        dayStatus = dayStatus + ",'LW'";
                }
                if (chkH.Checked)
                {
                    if (dayStatus == "")
                        dayStatus = "'H'";
                    else
                        dayStatus = dayStatus + ",'H'";
                }
                if (chkLH.Checked)
                {
                    if (dayStatus == "")
                        dayStatus = "'LH'";
                    else
                        dayStatus = dayStatus + ",'LH'";
                }
                oSR.DayStatus = dayStatus;
                if (ddlFixedPerDay.Checked)
                    oSR.DivisibleFactorType = 1;
                else
                    oSR.DivisibleFactorType = 2;
                //oSR.Factor=
                if (rdoCalendar.Checked)
                    oSR.Factor = 1;
                else if (rdoWorking.Checked)
                    oSR.Factor = 2;
                else
                    oSR.Factor = 3;
                if (chkExcludeWeekend.Checked)
                    oSR.IsWExclude = chkExcludeWeekend.Checked;
                else
                    oSR.IsWExclude = false;
                if (chkExcludeHoliday.Checked)
                    oSR.IsHExclude = chkExcludeHoliday.Checked;
                else
                    oSR.IsHExclude = false;
                if (txtDays.Text != "")
                    oSR.Days = Convert.ToDecimal(txtDays.Text);
                string shiftID = "";
                foreach (ShiftPlan sP in ShiftPlanList)
                {
                    if (sP.IsChecked)
                    {
                        if (shiftID == "")
                        {
                            shiftID = "'" + sP.ShiftID.ToString() + "'";
                        }
                        else
                        {
                            shiftID = "," + shiftID + "'" + sP.ShiftID.ToString() + "'";
                        }
                    }
                }
                oSR.Shift = shiftID;
                string leaveType = "";
                foreach (LeavePolicyMaster lPM in LeaveTypeList)
                {
                    if (lPM.IsChecked)
                    {
                        if (leaveType == "")
                            leaveType = "'" + lPM.LeavePolicyID.ToString() + "'";
                        else
                            leaveType = "," + leaveType + "'" + lPM.LeavePolicyID.ToString() + "'";
                    }
                }
                oSR.LeaveType = leaveType;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.OtherSalaryRule> lstOtherSalaryRule = OtherSalaryRuleList;
                if (lstOtherSalaryRule.Count == 0)
                {
                    ASL.Hr.DAO.OtherSalaryRule newObj = new ASL.Hr.DAO.OtherSalaryRule();
                    lstOtherSalaryRule.Add(newObj);
                }
                SetDataFromControlToObject(ref lstOtherSalaryRule);
                CustomList<HourWisePayment> lstHourWisePayment = HourWisePaymentList;
                manager.SaveOtherSalaryRule(ref lstOtherSalaryRule, ref lstHourWisePayment);
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
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
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.OtherSalaryRule> items = manager.GetAllOtherSalaryRule();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("RuleName", "Role Name");

                StaticInfo.SearchItem(items, "Other Salary Role", "SearchOtherSalaryRole", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(ASL.Hr.DAO.OtherSalaryRule), columns), 500);
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
    }
}