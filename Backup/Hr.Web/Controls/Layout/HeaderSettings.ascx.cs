using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hr.Web.Controls.Layout
{
    public partial class HeaderSettings : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            //TODO
            //Store logout info (datetime, etc..) in the database.
            Session.Abandon();
            Response.Redirect("~/UI/Security/Login.aspx");
        } 
    }
}