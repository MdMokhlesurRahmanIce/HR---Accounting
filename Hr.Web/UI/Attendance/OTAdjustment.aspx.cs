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
    public partial class OTAdjustment : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack.IsFalse())
            //{
            //    Session["View_EmpList"] = new CustomList<HRM_Emp>();
            //}
        }
    }
}