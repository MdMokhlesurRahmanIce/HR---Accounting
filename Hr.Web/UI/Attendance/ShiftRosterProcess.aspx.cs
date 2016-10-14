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

namespace Hr.Web.UI.Attendance
{
    public partial class ShiftRosterProcess : PageBase
    {
        ShiftRosterManager manager = new ShiftRosterManager();
        #region Constructur
        public ShiftRosterProcess()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable

        private CustomList<ShiftRoster> ShiftRosterList
        {
            get
            {
                if (Session["ShiftRosterProcess_ShiftRosterList"] == null)
                    return new CustomList<ShiftRoster>();
                else
                    return (CustomList<ShiftRoster>)Session["ShiftRosterProcess_ShiftRosterList"];
            }
            set
            {
                Session["ShiftRosterProcess_ShiftRosterList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSession();
            }
        }
        #region All Methods 
        private void InitializeSession()
        {
            try
            {
                //ShiftPlanList = new CustomList<ASL.Hr.DAO.ShiftPlan>();
                //ShiftPlanList = manager.GetAllShiftPlanShiftRoster();
                ShiftRosterList = new CustomList<ShiftRoster>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}