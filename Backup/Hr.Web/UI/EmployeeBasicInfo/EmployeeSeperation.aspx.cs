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

namespace Hr.Web.UI.EmployeeBasicInfo
{
    public partial class EmployeeSeperation : PageBase
    {
        #region Session Variables
        private CustomList<SeparationGrid> SeparationGrid
        {
            get
            {
                if (Session["EmployeeSeperation_SeparationGrid"] == null)
                    return new CustomList<SeparationGrid>();
                else
                    return (CustomList<SeparationGrid>)Session["EmployeeSeperation_SeparationGrid"];
            }
            set
            {
                Session["EmployeeSeperation_SeparationGrid"] = value;
            }
        }
        private CustomList<Gen_LookupEnt> _SepCause
        {
            get
            {
                if (Session["EmployeeSeperation_Cause"] == null)
                    return new CustomList<Gen_LookupEnt>();
                else
                    return (CustomList<Gen_LookupEnt>)Session["EmployeeSeperation_Cause"];
            }
            set
            {
                Session["EmployeeSeperation_Cause"] = value;
            }
        }
        private CustomList<Gen_LookupEnt> _SepAction
        {
            get
            {
                if (Session["EmployeeSeperation_Action"] == null)
                    return new CustomList<Gen_LookupEnt>();
                else
                    return (CustomList<Gen_LookupEnt>)Session["EmployeeSeperation_Action"];
            }
            set
            {
                Session["EmployeeSeperation_Action"] = value;
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
            SeparationGrid = new CustomList<SeparationGrid>();
        }
        private void InitializeCombo()
        {
            try
            {
                _SepCause = Gen_LookupEnt.GetAllGen_LookupEnt(14);
                ddlCause.DataSource = _SepCause;
                ddlCause.DataTextField = "ElementName";
                ddlCause.DataValueField = "ElementKey";
                ddlCause.DataBind();
                ddlCause.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCause.SelectedIndex = 0;

                _SepAction = Gen_LookupEnt.GetAllGen_LookupEnt(15);
                ddlAction.DataSource = _SepAction;
                ddlAction.DataTextField = "ElementName";
                ddlAction.DataValueField = "ElementKey";
                ddlAction.DataBind();
                ddlAction.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlAction.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        #endregion
    }
}