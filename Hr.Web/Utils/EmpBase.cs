using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hr.Web.Utils
{
   public class EmpBase : System.Web.UI.UserControl
    {

        private System.String _EmpKey;
        public System.String EmpKey
        {
            get
            {
                if (Session["EmpKey"] == null)
                    return "0";
                else
                    return Session["EmpKey"].ToString();
            }
            set
            {
                Session["EmpKey"] = value;
            }
        }
    }
}