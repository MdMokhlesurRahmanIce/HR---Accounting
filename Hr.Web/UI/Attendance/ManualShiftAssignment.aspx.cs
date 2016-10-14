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
    public partial class ManualShiftAssignment : PageBase
    {
        ManualShiftAssignmentManager manager = new ManualShiftAssignmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeCombo();
            }
        }
        #region All Methods
        private void InitializeCombo()
        {
            try
            {
                //Loding Shift 
              ddlSelectShift.DataSource = manager.GetAllShiftPlanShiftRoster();
              ddlSelectShift.DataTextField = "ALISE";
              ddlSelectShift.DataValueField = "ShiftID";
              ddlSelectShift.DataBind();
              ddlSelectShift.Items.Insert(0, new ListItem(String.Empty, String.Empty));
              ddlSelectShift.SelectedIndex = 0;

              txtFromDate.Text = DateTime.Now.ToShortDateString();
              txtToDate.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}