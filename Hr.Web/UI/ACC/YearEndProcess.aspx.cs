using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACC.BLL;
using ACC.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;


namespace Hr.Web.UI.ACC
{
    public partial class YearEndProcess : PageBase
    {
        YearEndManager manager = new YearEndManager();
        #region Constructur
        public YearEndProcess()
        {
            RequiresAuthorization = true;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeCombo();
            }
        }
        #region All Methods
        private void InitializeCombo()
        {
            try
            {
                //Loding FY
                CustomList<Gen_AccFY> lstFY = manager.GetAllGen_AccFY();
                ddlFY.DataSource = lstFY;
                ddlFY.DataTextField = "FYName";
                ddlFY.DataValueField = "FYKey";
                ddlFY.DataBind();
                //ddlFY.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                //ddlFY.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}