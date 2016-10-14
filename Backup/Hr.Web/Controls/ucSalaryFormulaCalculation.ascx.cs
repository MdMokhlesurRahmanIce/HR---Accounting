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

namespace Hr.Web.Controls
{
    public partial class ucSalaryFormulaCalculation : System.Web.UI.UserControl
    {
        SalaryInfoEntryManager manager = new SalaryInfoEntryManager();
        #region Session Variable
        private CustomList<EmployeeSalaryTemp> grdSalaryEntryList
        {
            get
            {
                if (Session["SalaryInfoEntry_grdSalaryEntryList"] == null)
                    return new CustomList<EmployeeSalaryTemp>();
                else
                    return (CustomList<EmployeeSalaryTemp>)Session["SalaryInfoEntry_grdSalaryEntryList"];
            }
            set
            {
                Session["SalaryInfoEntry_grdSalaryEntryList"] = value;
            }
        }
        private CustomList<SalaryHead> SalaryHeadList
        {
            get
            {
                if (Session["SalaryInfoEntry_SalaryHeadList"] == null)
                    return new CustomList<SalaryHead>();
                else
                    return (CustomList<SalaryHead>)Session["SalaryInfoEntry_SalaryHeadList"];
            }
            set
            {
                Session["SalaryInfoEntry_SalaryHeadList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializieCombo();
                InitializeSession();
            }
        }
        #region All Method
        private void InitializeSession()
        {
            try
            {
                grdSalaryEntryList = new CustomList<EmployeeSalaryTemp>();
                SalaryHeadList = new CustomList<SalaryHead>();
                SalaryHeadList = manager.GetAllSalaryHeadForSalaryRule();
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        private void InitializieCombo()
        {
            try
            {
                ddlSalaryRule.DataSource = manager.GetAllSalaryRuleBackup();
                ddlSalaryRule.DataTextField = "SalaryRuleCode";
                ddlSalaryRule.DataValueField = "SalaryRuleCode";
                ddlSalaryRule.DataBind();
                ddlSalaryRule.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlSalaryRule.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}