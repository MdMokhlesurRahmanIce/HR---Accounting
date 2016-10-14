using System;
using System.Collections.Generic;
using System.Web.UI;

namespace ASL
{
    public class InternalPage : Page
    {
        protected Object CurrentUserSession
        {
            get
            {
                return Session["CurrentUserSession"];
            }
            set
            {
                Session["CurrentUserSession"] = value;
            }
        }

        protected List<String> OpenPages
        {
            get
            {
                return (List<String>)Session["OpenPages"];
            }
            set
            {
                Session["OpenPages"] = value;
            }
        }
    }
}
