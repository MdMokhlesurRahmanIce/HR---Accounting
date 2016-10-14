using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASL
{
    public partial class SiteLoggedOff : System.Web.UI.MasterPage
    {
        public String srvMsg = String.Empty;
        public String srvMsgCss = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            lblServerMsg.Text = srvMsg;
            lblServerMsg.CssClass = srvMsgCss;
            base.OnPreRender(e);
        }
    }
}
