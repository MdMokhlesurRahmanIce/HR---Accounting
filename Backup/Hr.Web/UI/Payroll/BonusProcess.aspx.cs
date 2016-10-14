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
    public partial class BonusProcess : PageBase
    {
        BonusProcessManager manager = new BonusProcessManager();
        #region Session
        private CustomList<BonusProcessDetail> BonusProcessDetailList
        {
            get
            {
                if (Session["BonusProcess_BonusProcessDetailList"] == null)
                    return new CustomList<BonusProcessDetail>();
                else
                    return (CustomList<BonusProcessDetail>)Session["BonusProcess_BonusProcessDetailList"];
            }
            set
            {
                Session["BonusProcess_BonusProcessDetailList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeCombo();
                InitializeSession();
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            BonusProcessDetailList = new CustomList<BonusProcessDetail>();
        }
        private void InitializeCombo()
        {
            #region Salary Year Month
            ddlyearno.DataSource = manager.GetAllSalaryYear();
            ddlyearno.DataTextField = "CharType";
            ddlyearno.DataValueField = "CharType";
            ddlyearno.DataBind();
            ddlyearno.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
        }
        #endregion
        #region Combo Event
        protected void ddlyearno_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomList<Settings> obj = manager.GetAllSalaryMonths(ddlyearno.SelectedValue);
            ddlMonthNo.DataSource = obj;
            ddlMonthNo.DataTextField = "Data1";
            ddlMonthNo.DataValueField = "NumType";
            ddlMonthNo.DataBind();
            ddlMonthNo.Items.Insert(0, new ListItem() { Value = "", Text = "" });
        }
        #endregion
    }
}