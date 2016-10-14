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

namespace Hr.Web.UI.Payroll
{
    public partial class LoanType : PageBase
    {
        LoanTypeManager manager = new LoanTypeManager();
        #region Constructur
        public LoanType()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<ASL.Hr.DAO.LoanType> LoanTypeList
        {
            get
            {
                if (Session["LoanType_LoanTypeList"] == null)
                    return new CustomList<ASL.Hr.DAO.LoanType>();
                else
                    return (CustomList<ASL.Hr.DAO.LoanType>)Session["LoanType_LoanTypeList"];
            }
            set
            {
                Session["LoanType_LoanTypeList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    //InitializeCombo();
                    InitializeSession();
                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (Request["__EVENTTARGET"] == "SearchLoanType")
                    {
                        LoanTypeList = new CustomList<ASL.Hr.DAO.LoanType>();
                        ASL.Hr.DAO.LoanType searchLoan = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as ASL.Hr.DAO.LoanType;
                        LoanTypeList.Add(searchLoan);
                        if (searchLoan.IsNotNull())
                        {
                            PopulateBankInformation(searchLoan);
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
        private void PopulateBankInformation(ASL.Hr.DAO.LoanType loanType)
        {
            try
            {
                txtLoanType.Text = loanType.LoanType1;
                txtDescription.Text = loanType.Description;
                txtMaximumPercenttage.Text = loanType.MaxPercent.ToString();
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
                LoanTypeList = new CustomList<ASL.Hr.DAO.LoanType>();            }
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
        private void SetDataFromControlToObj(ref CustomList<ASL.Hr.DAO.LoanType> lstLoanType)
        {
            try
            {
                ASL.Hr.DAO.LoanType obj = lstLoanType[0];
                obj.LoanType1 = txtLoanType.Text;
                obj.Description = txtDescription.Text;
                obj.MaxPercent = txtMaximumPercenttage.Text.ToDecimal();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.LoanType> items = manager.GetAllLoanType();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("LoanType", "Loan Type");

                StaticInfo.SearchItem(items, "LoanType", "SearchLoanType", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(ASL.Hr.DAO.LoanType), columns), 500);
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
                CustomList<ASL.Hr.DAO.LoanType> lstLoanType = LoanTypeList;
                if (lstLoanType.Count == 0)
                {
                    ASL.Hr.DAO.LoanType newLoanType = new ASL.Hr.DAO.LoanType();
                    lstLoanType.Add(newLoanType);
                }
                SetDataFromControlToObj(ref lstLoanType);

                //if (!CheckUserAuthentication(lstBank)) return;
                manager.SaveLoanType(ref lstLoanType);
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