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

namespace Hr.Web.UI.Payroll
{
    public partial class SalaryHeadCreation : PageBase
    {
        #region Session Variable
        SalaryHead_Manager manager = new SalaryHead_Manager();
        #region Constructur
        public SalaryHeadCreation()
        {
            RequiresAuthorization = true;
        }
        #endregion
        private CustomList<HouseKeepingValue> grdSalaryHeadList
        {
            get
            {
                if (Session["SalaryHead_grdSalaryHeadList"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["SalaryHead_grdSalaryHeadList"];
            }
            set
            {
                Session["SalaryHead_grdSalaryHeadList"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.SalaryHead> grdSalarySubHeadList
        {
            get
            {
                if (Session["SalaryHead_grdSalarySubHeadList"] == null)
                    return new CustomList<ASL.Hr.DAO.SalaryHead>();
                else
                    return (CustomList<ASL.Hr.DAO.SalaryHead>)Session["SalaryHead_grdSalarySubHeadList"];
            }
            set
            {
                Session["SalaryHead_grdSalarySubHeadList"] = value;
            }
        }

        private void InitializeSession()
        {
            try
            {
                grdSalaryHeadList = manager.GetAllHeadType();
                grdSalarySubHeadList = new CustomList<ASL.Hr.DAO.SalaryHead>();
                grdSalarySubHeadList = manager.GetSalSubHead();

            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
            }

        }
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                CustomList<SalaryHead> Salary_HeadList = grdSalarySubHeadList;
                CustomList<SalaryHead> AddedAndModifiedList = Salary_HeadList.FindAll(f => f.IsAdded || f.IsModified || f.IsDeleted);
                if (!CheckUserAuthentication(AddedAndModifiedList, AddedAndModifiedList)) return;
                manager.SaveSalaryHead(ref AddedAndModifiedList);
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
        #endregion
    }
}