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
using System.Data.SqlClient;
using ASL.DATA;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.Web.Framework;


namespace Hr.Web.UI.LeaveManagement
{
    public partial class LeaveRule : PageBase
    {
        #region Session Variable

        LeavePolicyManager ManagerLeavePolicy = new LeavePolicyManager();
        LeaveRuleManager ManagerLeaveRule = new LeaveRuleManager();
        //Leavepo ManagerLeaveRuleDetail = new LeaveRuleDetailManager();
        //LeaveRuleManager ManagerLeaveRule = new LeaveRuleManager();
        private CustomList<LeavePolicyMaster> _LeavePolicyMaster
        {
            get
            {
                if (Session["LeaveRule_LeavePolicyMaster"] == null)
                    return new CustomList<LeavePolicyMaster>();
                else
                    return (CustomList<LeavePolicyMaster>)Session["LeaveRule_LeavePolicyMaster"];
            }
            set
            {
                Session["LeaveRule_LeavePolicyMaster"] = value;
            }
        }
        private CustomList<LeavePolicyMaster> _LeavePolicyMasterToDisplayOrSave
        {
            get
            {
                if (Session["LeaveRule_LeavePolicyMasterToDisplayOrSave"] == null)
                    return new CustomList<LeavePolicyMaster>();
                else
                    return (CustomList<LeavePolicyMaster>)Session["LeaveRule_LeavePolicyMasterToDisplayOrSave"];
            }
            set
            {
                Session["LeaveRule_LeavePolicyMasterToDisplayOrSave"] = value;
            }
        }

        private CustomList<ASL.Hr.DAO.LeaveRuleMaster> _LeaveRule
        {
            get
            {
                if (Session["LeaveRule_LeaveRule"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveRuleMaster>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveRuleMaster>)Session["LeaveRule_LeaveRule"];
            }
            set
            {
                Session["LeaveRule_LeaveRule"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.LeaveRuleMaster> _LeaveRuleMasterForSave
        {
            get
            {
                if (Session["LeaveRule_LeaveRuleForSave"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveRuleMaster>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveRuleMaster>)Session["LeaveRule_LeaveRuleForSave"];
            }
            set
            {
                Session["LeaveRule_LeaveRuleForSave"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSession();
                InitializeControls();
            }



        }
        #region All Methods
        private void InitializeControls()
        {
            ddlLeaveRuleKey.Visible = true;
            txtLeaveRule.Visible = false;
            _LeavePolicyMaster = ManagerLeavePolicy.GetAllLeavePolicyMaster();
            _LeaveRule = ManagerLeaveRule.GetAllLeaveRuleMaster();



            if (_LeaveRule.Count != 0)
            {
                ddlLeaveRuleKey.DataSource = _LeaveRule;
                ddlLeaveRuleKey.DataTextField = "LeaveRuleCode";
                ddlLeaveRuleKey.DataValueField = "LeaveRuleKey";
                ddlLeaveRuleKey.DataBind();
                ddlLeaveRuleKey.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlLeaveRuleKey.SelectedIndex = 0;
            }
            if (_LeavePolicyMaster.Count != 0)
            {
                ddlLVPolicyId.DataSource = _LeavePolicyMaster;
                ddlLVPolicyId.DataTextField = "Details";
                ddlLVPolicyId.DataValueField = "LeavePolicyId";
                ddlLVPolicyId.DataBind();
                ddlLVPolicyId.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlLVPolicyId.SelectedIndex = 0;
            }


        }
        private void InitializeSession()
        {

            _LeaveRule = new CustomList<ASL.Hr.DAO.LeaveRuleMaster>();
            _LeavePolicyMaster = new CustomList<LeavePolicyMaster>();
            _LeavePolicyMasterToDisplayOrSave = new CustomList<LeavePolicyMaster>();


        }
        private void CleareControls()
        {
            txtLeaveRule.Text = string.Empty;
            txtDescription.Text = string.Empty;
            // _LeavePolicyMaster = new CustomList<LeavePolicyMaster>();
            _LeavePolicyMasterToDisplayOrSave = new CustomList<LeavePolicyMaster>();
        }


        #endregion

        #region Button Event
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                // ClearControls();
                //LeaveBreakInfoList = new CustomList<LeaveBreakInfo>();
                _LeaveRuleMasterForSave = new CustomList<ASL.Hr.DAO.LeaveRuleMaster>();
                ddlLeaveRuleKey.Visible = false;
                txtLeaveRule.Visible = true;
                CleareControls();
                //txtLeaveId.Text = StaticInfo.NewIDString;
                //     _LeavePlanMasterForSave = new CustomList<LeavePlanMaster>();
                //   _LeaveBreak = new CustomList<LeaveBreakInfo>();
                //txtDescription.Enabled = true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            CleareControls();
            ddlLeaveRuleKey.Visible = true;
            ddlLeaveRuleKey.SelectedValue = string.Empty;
            txtLeaveRule.Visible = false;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.LeaveRuleMaster> lstLeaveRule = _LeaveRuleMasterForSave;

                if (lstLeaveRule.Count != 0)
                {
                    lstLeaveRule.ForEach(f => f.Delete());
                    CustomList<ASL.Hr.DAO.LeaveRuleDetails> lstLeaveRuleDetails = ManagerLeaveRule.GetSelectedLeaveRuleDetails(lstLeaveRule[0].LeaveRuleKey);
                    lstLeaveRuleDetails.ForEach(f => f.Delete());

                    //if (CheckUserAuthentication(lstLeavePlan, lstLeaveBreakInfo).IsFalse()) return;
                    ManagerLeaveRule.DeleteLeaveRule(ref lstLeaveRule, ref lstLeaveRuleDetails);
                    CleareControls();
                    InitializeSession();
                    InitializeControls();
                    ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                }

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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.LeaveRuleMaster> lstLeaveRule = (CustomList<ASL.Hr.DAO.LeaveRuleMaster>)_LeaveRuleMasterForSave;
                if (lstLeaveRule.IsNull() || lstLeaveRule.Count == 0)
                {
                    ASL.Hr.DAO.LeaveRuleMaster newLeaveRule = new ASL.Hr.DAO.LeaveRuleMaster();
                    lstLeaveRule.Add(newLeaveRule);
                }
                SetDataFromControlToObj(ref lstLeaveRule);
                CustomList<ASL.Hr.DAO.LeavePolicyMaster> lstLeaveRuleDetails = (CustomList<ASL.Hr.DAO.LeavePolicyMaster>)_LeavePolicyMasterToDisplayOrSave;
                int SID = 0;

                //  if (!CheckUserAuthentication(lstLeavePlan, lstLeaveBreakInfo)) return;
                ManagerLeaveRule.SaveLeaveRule(ref lstLeaveRule, ref lstLeaveRuleDetails, ref SID);


                txtLeaveRule.Visible = false;
                ddlLeaveRuleKey.Visible = true;
                _LeaveRule = ManagerLeaveRule.GetAllLeaveRuleMaster();

                ddlLeaveRuleKey.DataSource = _LeaveRule;
                ddlLeaveRuleKey.DataTextField = "LeaveRuleCode";
                ddlLeaveRuleKey.DataValueField = "LeaveRuleKey";
                ddlLeaveRuleKey.DataBind();
                ddlLeaveRuleKey.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlLeaveRuleKey.SelectedIndex = 0;

                if (SID != 0)
                {

                    ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                    ddlLeaveRuleKey.SelectedValue = SID.ToString();
                }
                else
                {
                    this.SuccessMessage = "Record Updated Successfully";
                    ddlLeaveRuleKey.SelectedValue = lstLeaveRule[0].LeaveRuleKey.ToString();
                }

                //LeaveRuleDetailList = ManagerLeaveRuleDetail.GetSelectedLeaveRuleDetail(SID);
                _LeaveRuleMasterForSave[0] = _LeaveRule.Find(f => f.LeaveRuleKey == SID);

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
        #endregion

        protected void ddlLeaveRuleKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomList<ASL.Hr.DAO.LeaveRuleMaster> SR = ManagerLeaveRule.GetSelectedLeaveRule(ddlLeaveRuleKey.SelectedValue.ToInt());
            CustomList<LeaveRuleDetails> LRD = ManagerLeaveRule.GetSelectedLeaveRuleDetails(ddlLeaveRuleKey.SelectedValue.ToInt());

            if (SR.Count != 0)
            {
                _LeaveRuleMasterForSave = SR;
                SetDataFromObjectToControl(ref SR);
            }
            else CleareControls();
            if (LRD.Count != 0)
            {
                CustomList<LeavePolicyMaster> obj = new CustomList<LeavePolicyMaster>();
                foreach (LeaveRuleDetails a in LRD)
                {
                    obj.Add(_LeavePolicyMaster.Find(f => f.LeavePolicyID == a.LeavePolicyId));
                }
                _LeavePolicyMasterToDisplayOrSave = obj;
            }

        }
        private void SetDataFromObjectToControl(ref CustomList<ASL.Hr.DAO.LeaveRuleMaster> SR)
        {
            if (SR[0].IsNotNull())
            {
                txtDescription.Text = SR[0].Description;
            }

        }
        private void SetDataFromControlToObj(ref CustomList<ASL.Hr.DAO.LeaveRuleMaster> PassedLeaveRule)
        {
            ASL.Hr.DAO.LeaveRuleMaster obj = PassedLeaveRule[0];
            if (txtLeaveRule.Visible.IsTrue())
            {
                obj.LeaveRuleCode = txtLeaveRule.Text;

            }
            else
            {
                obj.LeaveRuleCode = ddlLeaveRuleKey.SelectedItem.Text;
            }
            obj.Description = txtDescription.Text;
            if (obj.LeaveRuleKey == 0)
                obj.SetAdded();

            else obj.SetModified();

        }
        protected void ddlLVPolicyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_LeavePolicyMasterToDisplayOrSave.Count == 0)
            {
                _LeavePolicyMasterToDisplayOrSave = _LeavePolicyMaster.FindAll(f => f.LeavePolicyID == ddlLVPolicyId.SelectedValue.ToInt());
            }
            else
            {
                if (_LeavePolicyMasterToDisplayOrSave.Find(f => f.LeavePolicyID == ddlLVPolicyId.SelectedValue.ToInt()).IsNotNull())
                    ((PageBase)this.Page).ErrorMessage = "This Policy Is Already Tagged";
                else
                    _LeavePolicyMasterToDisplayOrSave.Add(_LeavePolicyMaster.Find(f => f.LeavePolicyID == ddlLVPolicyId.SelectedValue.ToInt()));
            }

        }

        
    }
}
