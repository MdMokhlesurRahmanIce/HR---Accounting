using System;
using System.ComponentModel;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ASL.DATA;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.Web.Framework;
using System.Data.SqlClient;

namespace Hr.Web.UI.LeaveManagement
{
    public partial class LeavePolicy : PageBase
    {
        LeavePolicyManager ManagerLeavePolicy = new LeavePolicyManager();
        #region Constructur
        public LeavePolicy()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        //private CustomList<LeavePolicyMaster> _LVPolicyMasterList
        //{
        //    get
        //    {
        //        if (Session["LeavePolicy_LVPolicyMasterList"] == null)
        //            return new CustomList<LeavePolicyMaster>();
        //        else
        //            return (CustomList<LeavePolicyMaster>)Session["LeavePolicy_LVPolicyMasterList"];
        //    }
        //    set
        //    {
        //        Session["LeavePolicy_LVPolicyMasterList"] = value;
        //    }
        //}
        private CustomList<LeavePolicyMaster> _SaveOrEditableLVPolicyMasterInfo
        {
            get
            {
                if (Session["SaveOrEditableLVPolicyMasterInfo"] == null)
                    return new CustomList<LeavePolicyMaster>();
                else
                    return (CustomList<LeavePolicyMaster>)Session["SaveOrEditableLVPolicyMasterInfo"];
            }
            set
            {
                Session["SaveOrEditableLVPolicyMasterInfo"] = value;
            }
        }
        private CustomList<LeavePolicyDetails> _LVPolicyDetList
        {
            get
            {
                if (Session["LeavePolicy_LVPolicyDetList"] == null)
                    return new CustomList<LeavePolicyDetails>();
                else
                    return (CustomList<LeavePolicyDetails>)Session["LeavePolicy_LVPolicyDetList"];
            }
            set
            {
                Session["LeavePolicy_LVPolicyDetList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                //ClientScript.RegisterClientScriptBlock(GetType(), "IsPostBack", "var isPostBack = true;", true);
                InitializeSession();
                InitializeControl();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
            }
        }
        #region All Methods
        private void InitializeControl()
        {
            txtLeavePolicyID.Visible = false;
            txtStartAfter.Text = "0";
            ddlLVPolicyId.DataSource = ManagerLeavePolicy.GetAllLeavePolicyMaster();
            ddlLVPolicyId.DataTextField = "Details";
            ddlLVPolicyId.DataValueField = "LeavePolicyID";
            ddlLVPolicyId.DataBind();
            ddlLVPolicyId.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlLVPolicyId.SelectedIndex = 0;
        }
        private void PopulateLeavePolicyInformation(LeavePolicyMaster leavePolicy)
        {
            try
            {
                ResetAllRadioButton();
                SetDataInControls(leavePolicy);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetDataInControls(LeavePolicyMaster leavePolicy)
        {
            try
            {
                txtLeavePolicyID.Text = leavePolicy.LeavePolicyID.ToString();
                txtLeaveType.Text = leavePolicy.LeaveType;
                txtDescription.Text = leavePolicy.PolicyDescription;
                if (leavePolicy.LeaveDayFixed.IsTrue())
                {
                    rdoFixedForALL.Checked = true;
                    rdoProportionateForNew.Checked = false;
                    rdoBasedOnWorkingDays.Checked = false;
                    rdoBaseonServiceLength.Checked = false;
                }
                else if (leavePolicy.LeaveDayProp.IsTrue())
                {
                    rdoProportionateForNew.Checked = true;
                }
                else if (leavePolicy.LeavedayBasedOnWDays.IsTrue())
                {
                    rdoBasedOnWorkingDays.Checked = true;
                    txtWorkingDays.Text = leavePolicy.WorkingDays.ToString();
                    txtWorkingDays.Visible = true;

                    string[] items = leavePolicy.DayStatus.Split(',');
                    if (items.Count() != 0)
                    {
                        for (int i = 1; i <= items.Count(); i++)
                        {
                            switch (items[i - 1])
                            {
                                case "P":
                                    chkP.Checked = true;
                                    break;
                                case "PH":
                                    chkPH.Checked = true;
                                    break;
                                case "PW":
                                    chkPW.Checked = true;
                                    break;
                                case "L":
                                    chkL.Checked = true;
                                    break;
                                case "W":
                                    chkW.Checked = true;
                                    break;
                                case "H":
                                    chkH.Checked = true;
                                    break;
                                case "A":
                                    chkA.Checked = true;
                                    break;
                                case "LV":
                                    chkLV.Checked = true;
                                    break;
                                case "LW":
                                    chkLW.Checked = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                }
                else if (leavePolicy.LeavedaysBasedOnSLength.IsTrue())
                {
                    rdoBaseonServiceLength.Checked = true;

                }
                txtLeaveDays.Text = leavePolicy.LeaveDays.ToString();
                if (leavePolicy.LeaveAllocType == "Prop")
                {
                    rdoEndofLeaveCalander.Checked = true;
                    rdoInstant.Checked = false;
                }
                else
                {
                    rdoEndofLeaveCalander.Checked = false;
                    rdoInstant.Checked = true;
                }
                if (leavePolicy.LeaveCalculationDepandsOn == "DOJ")
                {
                    rdoDOJ.Checked = true;
                    rdoDOC.Checked = false;
                }
                else
                {
                    rdoDOJ.Checked = false;
                    rdoDOC.Checked = true;
                }

                txtStartAfter.Text = leavePolicy.StartAfter.ToString();
                if (leavePolicy.CalenderType == "Emp")
                {
                    rdoEmployee.Checked = true;

                }
                else
                {
                    rdoCompany.Checked = true;
                }

                chkAllowAdvanceLeave.Checked = leavePolicy.IsAllowAdvanceLeave;
                chkAllowPreecedingHW.Checked = leavePolicy.AllowPreceedingHolidays;
                chkAllowSucceedingHW.Checked = leavePolicy.AllowSucceedingHolidays;
                chkAllowSandwitch.Checked = leavePolicy.AllowSandwitch;
                if (leavePolicy.IsHourlyLeave)
                {
                    chkAllowHourlyLeave.Checked = true;
                    if (leavePolicy.IsHourlyLeaveAdjust)
                    {
                        chkAdjustfromtotalLVBalance.Checked = true;
                        txtHours.Text = leavePolicy.AdjustedHour.ToString();


                    }
                }
                else
                {
                    chkAllowHourlyLeave.Checked = false;
                    chkAdjustfromtotalLVBalance.Checked = false;
                }
                if (leavePolicy.IsCarryForword)
                {
                    chkLeaveCarryForword.Checked = true;
                    txtYearlyMaxDays.Text = leavePolicy.YearlyMaxDays.ToString();
                    txtMaxAccumulation.Text = leavePolicy.MaxAccumulation.ToString();
                }
                else
                {
                    chkLeaveCarryForword.Checked = false;
                    txtYearlyMaxDays.Text = string.Empty;
                    txtMaxAccumulation.Text = string.Empty;
                }
                if (leavePolicy.IsConsecutiveLimit)
                {
                    chkConsicutiveLimit.Checked = true;
                    txtDays.Text = leavePolicy.ConsecutiveLimitDays.ToString();
                }
                else
                {
                    chkConsicutiveLimit.Checked = false;
                    txtDays.Text = string.Empty;

                }


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
                _LVPolicyDetList = new CustomList<LeavePolicyDetails>();
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
                //ddlLVPolicyId.SelectedIndex = 0;
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void ResetAllRadioButton()
        {
            try
            {
                rdoDOJ.Checked = true;
                rdoEmployee.Checked = true;
                rdoInstant.Checked = true;
                rdoFixedForALL.Checked = true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControls(ref CustomList<LeavePolicyMaster> lstLeavePolicyMaster)
        {
            try
            {
                LeavePolicyMaster objLPM = lstLeavePolicyMaster[0];
                objLPM.LeavePolicyID = txtLeavePolicyID.Text.ToInt();
                objLPM.LeaveType = txtLeaveType.Text;
                objLPM.PolicyDescription = txtDescription.Text;
                if (rdoFixedForALL.Checked)
                {
                    objLPM.LeaveCategory = txtLeaveType.Text;
                    objLPM.LeaveDayFixed = true;
                    objLPM.LeaveDayProp = false;
                    objLPM.LeavedayBasedOnWDays = false;
                    objLPM.LeavedaysBasedOnSLength = false;
                    //objLPM.WorkingDays = string.Empty;
                    objLPM.LeaveDays = txtLeaveDays.Text.ToInt();

                }
                if (rdoProportionateForNew.Checked)
                {
                    objLPM.LeaveCategory = txtLeaveType.Text;
                    objLPM.LeaveDayFixed = false;
                    objLPM.LeaveDayProp = true;
                    objLPM.LeavedayBasedOnWDays = false;
                    objLPM.LeavedaysBasedOnSLength = false;
                    //objLPM.WorkingDays = txtWorkingDays.Text.ToInt();
                    objLPM.LeaveDays = txtLeaveDays.Text.ToInt();
                }
                if (rdoBasedOnWorkingDays.Checked)
                {
                    objLPM.LeaveCategory = txtLeaveType.Text;
                    objLPM.LeaveDayFixed = false;
                    objLPM.LeaveDayProp = false;
                    objLPM.LeavedayBasedOnWDays = true;
                    objLPM.LeavedaysBasedOnSLength = false;
                    objLPM.WorkingDays = txtWorkingDays.Text.ToInt();
                    objLPM.LeaveDays = txtLeaveDays.Text.ToInt();

                    string countableDays = "";
                    if (chkAll.Checked) countableDays = "";
                    else
                    {
                        if (chkP.Checked) countableDays = "P,";
                        if (chkL.Checked) countableDays = "L,";
                        if (chkW.Checked) countableDays = "W,";
                        if (chkPW.Checked) countableDays = "PW,";
                        if (chkLW.Checked) countableDays = "LW,";
                        if (chkH.Checked) countableDays = "H,";
                        if (chkPH.Checked) countableDays = "PH,";
                        if (chkA.Checked) countableDays = "A,";
                        if (chkLV.Checked) countableDays = "LV,";
                    }
                    countableDays = countableDays.Length > 0 ? countableDays.Substring(0, countableDays.Length - 1) : string.Empty;
                    objLPM.DayStatus = countableDays;
                }
                if (rdoBaseonServiceLength.Checked)
                {

                    objLPM.LeaveDayFixed = false;
                    objLPM.LeaveDayProp = false;
                    objLPM.LeavedayBasedOnWDays = false;

                    objLPM.LeavedaysBasedOnSLength = true;
                }


                //////////////////////
                if (rdoDOJ.Checked)
                    objLPM.LeaveCalculationDepandsOn = "DOJ";
                else
                    objLPM.LeaveCalculationDepandsOn = "DOC";
                if (txtStartAfter.Text == "")
                {
                    objLPM.StartAfter = 0;
                }
                else
                {
                    objLPM.StartAfter = txtStartAfter.Text.ToInt();
                }
                if (rdoCompany.Checked)
                    objLPM.CalenderType = "Com";
                else
                    objLPM.CalenderType = "Emp";
                if (rdoEndofLeaveCalander.Checked)
                    objLPM.LeaveAllowcationProcess = "Prop";
                else
                    objLPM.LeaveAllowcationProcess = "Instant";

                objLPM.IsAllowAdvanceLeave = chkAllowAdvanceLeave.Checked;
                objLPM.AllowPreceedingHolidays = chkAllowPreecedingHW.Checked;
                objLPM.AllowSucceedingHolidays = chkAllowSucceedingHW.Checked;
                objLPM.AllowSandwitch = chkAllowSandwitch.Checked;
                if (chkAllowHourlyLeave.Checked)
                {
                    objLPM.IsHourlyLeave = chkAllowHourlyLeave.Checked;
                }
                if (chkAdjustfromtotalLVBalance.Checked)
                {
                    objLPM.IsHourlyLeaveAdjust = chkAdjustfromtotalLVBalance.Checked;
                    objLPM.AdjustedHour = txtHours.Text.ToInt();
                }
                if (chkLeaveCarryForword.Checked)
                {
                    objLPM.IsCarryForword = chkLeaveCarryForword.Checked;
                    objLPM.YearlyMaxDays = txtYearlyMaxDays.Text.ToInt();
                    objLPM.MaxAccumulation = txtMaxAccumulation.Text.ToInt();
                }
                if (chkConsicutiveLimit.Checked)
                {
                    objLPM.IsConsecutiveLimit = chkConsicutiveLimit.Checked;
                    objLPM.ConsecutiveLimitDays = txtDays.Text.ToInt();
                }

                if (objLPM.AddedBy.IsNullOrEmpty())
                {
                    objLPM.AddedBy = "System"; //CurrentUserSession.UserCode;
                    objLPM.DateAdded = DateTime.Now;
                }
                //if (objLPM.LeavePolicyID == 0 || objLPM.LeavePolicyID == -1)
                //    objLPM.SetAdded();
                //else objLPM.SetModified();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region Button Event
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearControls();
                ddlLVPolicyId.Visible = false;
                txtLeavePolicyID.Visible = true;
                txtLeavePolicyID.Text = StaticInfo.NewIDString;
                InitializeSession();
                _SaveOrEditableLVPolicyMasterInfo = new CustomList<LeavePolicyMaster>();
                ResetAllRadioButton();
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
                //if(  txtLeavePolicyID.Visible.IsTrue())
                // {


                // }
                CustomList<LeavePolicyMaster> lstLeavePolicyMaster = _SaveOrEditableLVPolicyMasterInfo;
                if (lstLeavePolicyMaster.Count == 0)
                {
                    LeavePolicyMaster newLeavePolicy = new LeavePolicyMaster();
                    lstLeavePolicyMaster.Add(newLeavePolicy);
                }
                CustomList<LeavePolicyDetails> lstLeavePolicyDet = new CustomList<LeavePolicyDetails>();
                if (rdoBaseonServiceLength.Checked)
                {
                    lstLeavePolicyDet = _LVPolicyDetList;
                }
                SetDataFromControls(ref lstLeavePolicyMaster);

                // if (!CheckUserAuthentication(lstLeavePolicyMaster, lstLeavePolicyDet)) return;
                int SID = 0;
                ManagerLeavePolicy.SaveLeavePolicy(ref lstLeavePolicyMaster, ref lstLeavePolicyDet, ref SID);
                if (SID != 0)
                {
                    ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                    txtLeavePolicyID.Visible = false;
                    ddlLVPolicyId.Visible = true;
                }
                else
                    ((PageBase)this.Page).SuccessMessage = "Record Updated Successfully";


                CustomList<LeavePolicyMaster> MasterList = ManagerLeavePolicy.GetAllLeavePolicyMaster();

                ddlLVPolicyId.DataSource = MasterList;
                ddlLVPolicyId.DataTextField = "Details";
                ddlLVPolicyId.DataValueField = "LeavePolicyID";
                ddlLVPolicyId.DataBind();
                ddlLVPolicyId.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlLVPolicyId.SelectedIndex = 0;
                if (SID != 0)
                {
                    ddlLVPolicyId.SelectedValue = SID.ToString();
                    _SaveOrEditableLVPolicyMasterInfo[0] = MasterList.Find(f => f.LeavePolicyID == SID);
                }
                else ddlLVPolicyId.SelectedValue = lstLeavePolicyMaster[0].LeavePolicyID.ToString();



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
                //CustomList<LeavePolicyMaster> items = manager.GetAllLeavePolicyMaster();
                //Dictionary<string, string> columns = new Dictionary<string, string>();

                //columns.Add("LeavePolicyID", "LeavePolicyID");
                //columns.Add("LeaveType", "Leave Type");
                //columns.Add("PolicyDescription", "Policy Description");

                //StaticInfo.SearchItem(items, "Leave Policy", "SearchLeavePolicyMaster", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(LeavePolicyMaster), columns), 500);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<LeavePolicyMaster> lstLeavePolicyMaster = _SaveOrEditableLVPolicyMasterInfo;
                CustomList<LeavePolicyDetails> lstLVPolicyDet = _LVPolicyDetList;
                lstLeavePolicyMaster.ForEach(f => f.Delete());
                lstLVPolicyDet.ForEach(f => f.Delete());
                //   if (CheckUserAuthentication(lstLeavePolicyMaster, lstLVPolicyDet).IsFalse()) return;
                ManagerLeavePolicy.DeleteLeavePolicy(ref lstLeavePolicyMaster, ref lstLVPolicyDet);

                InitializeSession();
                InitializeControl();
                ClearControls();
                ResetAllRadioButton();
                //  this.SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                _LVPolicyDetList = new CustomList<LeavePolicyDetails>();
                txtLeavePolicyID.Visible = false;
                ddlLVPolicyId.Visible = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        protected void ddlLVPolicyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SaveOrEditableLVPolicyMasterInfo = ManagerLeavePolicy.GetAllLeavePolicyMaster().FindAll(f => f.LeavePolicyID == ddlLVPolicyId.SelectedValue.ToInt());
            //ManagerLeavePolicy.GetSelectedLeavePolicyMaster(ddlLVPolicyId.SelectedValue.ToInt());
            _LVPolicyDetList = ManagerLeavePolicy.GetAllLeavePolicyDetails(ddlLVPolicyId.SelectedValue.ToInt());
            SetDataInControls(_SaveOrEditableLVPolicyMasterInfo[0]);

        }
    }
}
