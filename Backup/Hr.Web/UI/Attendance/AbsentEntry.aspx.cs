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
using Hr.Web.Controls;
using System.Collections;
using System.Data.SqlClient;

namespace Hr.Web.UI.Attendance
{
    public partial class AbsentEntry : PageBase
    {
        AbsentEntryManager _manager = new AbsentEntryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToShortDateString();
                txtToDate.Text = DateTime.Today.ToShortDateString();
            }
        }
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<HRM_Emp> empList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> checkedEmpList = empList.FindAll(f=>f.IsChecked);
                CustomList<ASL.Hr.DAO.AbsentEntry> AbsentList = new CustomList<ASL.Hr.DAO.AbsentEntry>();
                TimeSpan ts = (txtToDate.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat) - txtFromDate.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat));
                int days = ts.Days + 1;
                for (int i = 0; i < days; i++)
                {
                    foreach (HRM_Emp emp in checkedEmpList)
                    {
                        ASL.Hr.DAO.AbsentEntry newObj = new ASL.Hr.DAO.AbsentEntry();
                        newObj.EmpID = emp.EmpKey;
                        newObj.AbsentDate = txtFromDate.Text.ToDateTime().AddDays(i);
                        AbsentList.Add(newObj);
                        
                    }
                }
                if (AbsentList.Count != 0)
                {
                    //if (!CheckUserAuthentication(AbsentList)) return;
                    _manager.SaveAbsentList(ref AbsentList);
                   
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<HRM_Emp> empList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> checkedEmpList = empList.FindAll(f => f.IsChecked);
                CustomList<ASL.Hr.DAO.AbsentEntry> AbsentList = new CustomList<ASL.Hr.DAO.AbsentEntry>();
                TimeSpan ts = (txtToDate.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat) - txtFromDate.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat));
                int days = ts.Days + 1;
                for (int i = 0; i < days; i++)
                {
                    foreach (HRM_Emp emp in checkedEmpList)
                    {
                        ASL.Hr.DAO.AbsentEntry newObj = new ASL.Hr.DAO.AbsentEntry();
                        newObj.EmpID = emp.EmpKey;
                        newObj.AbsentDate = txtFromDate.Text.ToDateTime().AddDays(i);
                        newObj.Delete();
                        AbsentList.Add(newObj);
                    }
                }
                if (AbsentList.Count != 0)
                {
                    //if (!CheckUserAuthentication(AbsentList)) return;
                    _manager.SaveAbsentList(ref AbsentList);
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
        #endregion
    }
}