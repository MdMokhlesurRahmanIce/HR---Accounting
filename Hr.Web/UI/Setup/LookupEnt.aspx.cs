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

namespace Hr.Web.UI.Setup
{
    public partial class LookupEnt : PageBase
    {
        LookupEntManager manager = new LookupEntManager();
        #region Constructur
        public LookupEnt()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<Gen_LookupEnt> LookupEntList
        {
            get
            {
                if (Session["LookupEnt_LookupEntList"] == null)
                    return new CustomList<Gen_LookupEnt>();
                else
                    return (CustomList<Gen_LookupEnt>)Session["LookupEnt_LookupEntList"];
            }
            set
            {
                Session["LookupEnt_LookupEntList"] = value;
            }
        }

        private CustomList<Gen_LookupEnt> LookupEntListByEntityType
        {
            get
            {
                if (Session["LookupEnt_LookupEntListByEntityType"] == null)
                    return new CustomList<Gen_LookupEnt>();
                else
                    return (CustomList<Gen_LookupEnt>)Session["LookupEnt_LookupEntListByEntityType"];
            }
            set
            {
                Session["LookupEnt_LookupEntListByEntityType"] = value;
            }
        }

        #endregion
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeCombo();
                    InitializeSession();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region All Methods
        private void InitializeCombo()
        {

            //Loading Entity Type
            CustomList<PopulateDropdownList> lstDropdown = new CustomList<PopulateDropdownList>();
            foreach (int value in Enum.GetValues(typeof(enumsHr.enumEntitySetup)))
            {
                //if (value == 1) continue;
                lstDropdown.Add(new PopulateDropdownList
                {
                    Text = Enum.GetName(typeof(enumsHr.enumEntitySetup), value),
                    ValueField = value
                });
            }

           ddlEntityType.DataSource = lstDropdown;
           ddlEntityType.DataTextField = "Text";
           ddlEntityType.DataValueField = "ValueField";
           ddlEntityType.DataBind();
           ddlEntityType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
           ddlEntityType.SelectedIndex = 0;
        }
        private void InitializeSession()
        {
            try
            {
                LookupEntList = new CustomList<Gen_LookupEnt>();
                LookupEntList = manager.GetAllGen_LookupEnt();
                LookupEntListByEntityType = new CustomList<Gen_LookupEnt>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<Gen_LookupEnt> LookupEnt = (CustomList<Gen_LookupEnt>)LookupEntListByEntityType;
                foreach (Gen_LookupEnt lUE in LookupEnt)
                {
                    if (lUE.IsAdded)
                    {
                        lUE.EntityKey = ddlEntityType.SelectedValue.ToInt();
                    }
                }
                if (LookupEnt.IsNotNull())
                {
                    if (!CheckUserAuthentication(LookupEnt)) return;
                    manager.SaveLookupEnt(ref LookupEnt);
                    LookupEntList = manager.GetAllGen_LookupEnt();
                    this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                }
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