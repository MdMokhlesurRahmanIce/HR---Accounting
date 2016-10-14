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

namespace Hr.Web.UI.HRActivities
{
    public partial class BonusPolicyDeclaration : PageBase
    {
        BonusPolicyManager manager = new BonusPolicyManager();
        #region Constructur

        #endregion
        #region Session Event
        private CustomList<BonusPolicyMaster> BonusPolicyMasterList
        {
            get
            {
                if (Session["BonusPolicyDeclaration_BonusPolicyMasterList"] == null)
                    return new CustomList<BonusPolicyMaster>();
                else
                    return (CustomList<BonusPolicyMaster>)Session["BonusPolicyDeclaration_BonusPolicyMasterList"];
            }
            set
            {
                Session["BonusPolicyDeclaration_BonusPolicyMasterList"] = value;
            }
        }

        private CustomList<BonusPolicyDetails> BonusPolicyDetailList
        {
            get
            {
                if (Session["BonusPolicyDeclaration_BonusPolicyDetailList"] == null)
                    return new CustomList<BonusPolicyDetails>();
                else
                    return (CustomList<BonusPolicyDetails>)Session["BonusPolicyDeclaration_BonusPolicyDetailList"];
            }
            set
            {
                Session["BonusPolicyDeclaration_BonusPolicyDetailList"] = value;
            }
        }
        private CustomList<PopulateDropdownList> DropdownList
        {
            get
            {
                if (Session["BonusPolicyDeclaration_DropdownList"] == null)
                    return new CustomList<PopulateDropdownList>();
                else
                    return (CustomList<PopulateDropdownList>)Session["BonusPolicyDeclaration_DropdownList"];
            }
            set
            {
                Session["BonusPolicyDeclaration_DropdownList"] = value;
            }
        }
        private CustomList<PopulateDropdownList> DropdownFixedOrProrataList
        {
            get
            {
                if (Session["BonusPolicyDeclaration_DropdownFixedOrProrataList"] == null)
                    return new CustomList<PopulateDropdownList>();
                else
                    return (CustomList<PopulateDropdownList>)Session["BonusPolicyDeclaration_DropdownFixedOrProrataList"];
            }
            set
            {
                Session["BonusPolicyDeclaration_DropdownFixedOrProrataList"] = value;
            }
        }
        private CustomList<SalaryHead> SalaryHeadList
        {
            get
            {
                if (Session["BonusPolicyDeclaration_SalaryHeadList"] == null)
                    return new CustomList<SalaryHead>();
                else
                    return (CustomList<SalaryHead>)Session["BonusPolicyDeclaration_SalaryHeadList"];
            }
            set
            {
                Session["BonusPolicyDeclaration_SalaryHeadList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeCombo();
                    InitializeSession();
                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (Request["__EVENTTARGET"] == "SearchBonusPolicy")
                    {
                        BonusPolicyMasterList = new CustomList<BonusPolicyMaster>();
                        BonusPolicyMaster searchBonusPolicyMaster = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as BonusPolicyMaster;
                        BonusPolicyMasterList.Add(searchBonusPolicyMaster);
                        if (searchBonusPolicyMaster.IsNotNull())
                        {
                            PopulateBonusPolicyInformation(searchBonusPolicyMaster);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region All Methods
        private void PopulateBonusPolicyInformation(BonusPolicyMaster bonusPolicyMaster)
        {
            try
            {
                txtBonusCode.Text = bonusPolicyMaster.PolicyCode;
                txtBonusName.Text = bonusPolicyMaster.PolicyName;
                ddlBonusType.SelectedValue = bonusPolicyMaster.BonusType.ToString();
                txtDescription.Text = bonusPolicyMaster.Description;
                ddlAvailFrom.SelectedValue = bonusPolicyMaster.AvailFrom.ToString();
                txtAfterDays.Text = bonusPolicyMaster.AfterDays.ToString();
                #region Child
                BonusPolicyDetailList = manager.GetAllBonusPolicyDetails(bonusPolicyMaster.PolicyID);
                #endregion
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
                BonusPolicyMasterList = new CustomList<BonusPolicyMaster>();
                BonusPolicyDetailList = new CustomList<BonusPolicyDetails>();
                DropdownList = new CustomList<PopulateDropdownList>();
                foreach (int value in Enum.GetValues(typeof(enumsHr.enumCalculationMethod)))
                {
                    DropdownList.Add(new PopulateDropdownList
                    {
                        Text = Enum.GetName(typeof(enumsHr.enumCalculationMethod), value),
                        ValueField = value
                    });
                }
                DropdownFixedOrProrataList = new CustomList<PopulateDropdownList>();
                foreach (int value in Enum.GetValues(typeof(enumsHr.enumEmpCriteria)))
                {
                    DropdownFixedOrProrataList.Add(new PopulateDropdownList
                    {
                        Text = Enum.GetName(typeof(enumsHr.enumEmpCriteria), value),
                        ValueField = value
                    });
                }
                SalaryHeadList = manager.GetAllSalaryHeadForSalaryRule();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            ddlBonusType.DataSource = manager.GetAllGen_LookupEnt(enumsHr.enumEntitySetup.BonusType);
            ddlBonusType.DataTextField = "ElementName";
            ddlBonusType.DataValueField = "ElementKey";
            ddlBonusType.DataBind();
            ddlBonusType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlBonusType.SelectedIndex = 0;

            //Loading Method
            CustomList<PopulateDropdownList> lstMethod = new CustomList<PopulateDropdownList>();
            foreach (int value in Enum.GetValues(typeof(enumsHr.enumAvailFrom)))
            {
                lstMethod.Add(new PopulateDropdownList
                {
                    Text = Enum.GetName(typeof(enumsHr.enumAvailFrom), value),
                    ValueField = value
                });
            }
            ddlAvailFrom.DataSource = lstMethod;
            ddlAvailFrom.DataTextField = "Text";
            ddlAvailFrom.DataValueField = "ValueField";
            ddlAvailFrom.DataBind();
            ddlAvailFrom.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlAvailFrom.SelectedIndex = 0;
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
        private void SetDataFromControlToObj(ref CustomList<BonusPolicyMaster> lstBonusPolicyMaster)
        {
            try
            {
                BonusPolicyMaster obj = lstBonusPolicyMaster[0];
                obj.PolicyCode = txtBonusCode.Text;
                obj.PolicyName = txtBonusName.Text;
                obj.BonusType = ddlBonusType.SelectedValue.ToInt();
                obj.Description = txtDescription.Text;
                obj.AvailFrom = ddlAvailFrom.SelectedValue.ToInt();
                obj.AfterDays = txtAfterDays.Text.ToInt();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<BonusPolicyMaster> lstBonusPolicyMaster = BonusPolicyMasterList;

                if (lstBonusPolicyMaster.Count != 0)
                {
                    lstBonusPolicyMaster.ForEach(f => f.Delete());
                    CustomList<BonusPolicyDetails> lstBonusPolicyDetails = BonusPolicyDetailList;
                    lstBonusPolicyDetails.ForEach(f => f.Delete());

                    //if (CheckUserAuthentication(lstLeavePlan, lstLeaveBreakInfo).IsFalse()) return;
                    manager.DeleteBonusPolicy(ref lstBonusPolicyMaster, ref lstBonusPolicyDetails);
                    ClearControls();
                    InitializeSession();
                    ((PageBase)this.Page).SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
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
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<BonusPolicyMaster> items = manager.GetAllBonusPolicyMaster();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("PolicyCode", "Policy Code");
                columns.Add("PolicyName", "Policy Name");

                StaticInfo.SearchItem(items, "Bonus Policy", "SearchBonusPolicy", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(BonusPolicyMaster), columns), 500);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<BonusPolicyMaster> lstBonusPolicyMaster = BonusPolicyMasterList;
                if (lstBonusPolicyMaster.Count == 0)
                {
                    BonusPolicyMaster newBonusPolicyMaster = new BonusPolicyMaster();
                    lstBonusPolicyMaster.Add(newBonusPolicyMaster);
                }
                SetDataFromControlToObj(ref lstBonusPolicyMaster);
                CustomList<BonusPolicyDetails> lstBonusPolicyDetails = (CustomList<BonusPolicyDetails>)BonusPolicyDetailList;

                //if (!CheckUserAuthentication(lstBank, lstBankBranch)) return;
                manager.SaveBonusPolicy(ref lstBonusPolicyMaster, ref lstBonusPolicyDetails);
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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                InitializeSession();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                ClearControls();
                InitializeSession();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}