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
    public partial class BasedOnSalaryCalculation : System.Web.UI.UserControl
    {
        SalaryRuleManager manager = new SalaryRuleManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeDropdown();
            }
        }
        #region All Methods
        private void InitializeDropdown()
        {
            try
            {
                //Loding Salary Head 
                ddlSalaryHead.DataSource = manager.GetAllSalaryHeadForSalaryRule();
                ddlSalaryHead.DataTextField = "HeadName";
                ddlSalaryHead.DataValueField = "SalaryHeadKey";
                ddlSalaryHead.DataBind();
                ddlSalaryHead.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlSalaryHead.SelectedIndex = 0;

               ddlParentHead.DataSource = manager.GetAllSalaryHeadForSalaryRule();
               ddlParentHead.DataTextField = "HeadName";
               ddlParentHead.DataValueField = "SalaryHeadKey";
               ddlParentHead.DataBind();
               ddlParentHead.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlParentHead.SelectedIndex = 0;

               ddlPartialHead.DataSource = manager.GetAllSalaryHeadForSalaryRule();
               ddlPartialHead.DataTextField = "HeadName";
               ddlPartialHead.DataValueField = "SalaryHeadKey";
               ddlPartialHead.DataBind();
               ddlPartialHead.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlPartialHead.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}