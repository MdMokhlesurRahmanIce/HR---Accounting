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
using ReportSuite.DAO;

namespace Hr.Web.Controls
{
    public partial class ucEmpSearch : System.Web.UI.UserControl
    {
        EmpSearchManager manager = new EmpSearchManager();
        #region Session Variable
        private CustomList<EmpFilterSets> FilterSetsList
        {
            get
            {
                if (Session["ucEmpSearch_FilterSetsList"] == null)
                    return new CustomList<EmpFilterSets>();
                else
                    return (CustomList<EmpFilterSets>)Session["ucEmpSearch_FilterSetsList"];
            }
            set
            {
                Session["ucEmpSearch_FilterSetsList"] = value;
            }
        }
        private CustomList<HouseKeepingValue> EntityList
        {
            get
            {
                if (Session["ucEmpSearch_EntityList"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["ucEmpSearch_EntityList"];
            }
            set
            {
                Session["ucEmpSearch_EntityList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmployeeName.Attributes.Add("readonly", "true");
            if (!IsPostBack)
            {
                InitializeSession();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget == "SearchEmployee")
                {
                    HRM_Emp searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Emp;
                    if (searchEmp.IsNotNull())
                    {
                        CustomList<HRM_Emp> empList = new CustomList<HRM_Emp>();
                        txtEmployeeName.Text = searchEmp.EmpName;
                        empList.Add(searchEmp);
                        Session["View_EmpList"] = empList;
                    }
                }

            }
        }
        #region All Methods
        private void InitializeSession()
        {
            FilterSetsList = new CustomList<EmpFilterSets>();
            foreach (EntityList EL in manager.GetAllEntityList())
            {
                EmpFilterSets fSObj = new EmpFilterSets();
                fSObj.EntityID = EL.EntityID;
                fSObj.ColumnName = EL.EntityName;
                fSObj.Operators = "=";
                fSObj.ColumnValue = "";
                fSObj.OrAnd = "And";
                FilterSetsList.Add(fSObj);
            }

            EntityList = new CustomList<HouseKeepingValue>();
        }
        #endregion
        #region button event
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //CommonHelper.CreateSearchString();
                CustomList<HRM_Emp> EmpList = manager.doSearch();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");

                StaticInfo.SearchItem(EmpList, "Emp Info", "SearchEmployee", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 500, GlobalEnums.enumSearchType.StoredProcedured);
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