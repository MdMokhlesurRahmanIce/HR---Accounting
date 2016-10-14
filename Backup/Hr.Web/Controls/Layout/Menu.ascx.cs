using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.DATA;
using ASL.Security.DAO;
using System.Text;
using ASL.Web.Framework;
using System.Configuration;

namespace Hr.Web.Controls.Layout
{
    public partial class Menu : System.Web.UI.UserControl
    {
        #region Fields
        string root = ConfigurationManager.AppSettings["urlRoot"];
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            populateMenu();
        }

        private void populateMenu()
        {
            //if (((PageBase)this.Page).CurrentUserSession.IsNull()) return;
            if (((PageBase)this.Page).CurrentUserSession.IsNull())
            {
                HttpContext.Current.Response.Redirect("~/Security/Login.aspx?back_url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            var userCode = ((PageBase)this.Page).CurrentUserSession.UserCode;
            var appCode = ((PageBase)this.Page).CurrentUserSession.CurrentApplicationID;

            CustomList<LeftMenuItems> allMenu = LeftMenuItems.GetAllLeftMenuItemsByUserCodeAndApplicationID(userCode, appCode);
            string moduleName = string.Empty;
            var currentModule = GetCurrentModule(Request.Url, out moduleName);
            var sb = new StringBuilder();

           var selectedMenu = allMenu.Where(m => m.MenuType.Contains("Home"));

           foreach (var item in selectedMenu)
           {
               if (allMenu.Where(m => m.ParentID == item.ObjectID).Count() > 0)// && string.IsNullOrWhiteSpace(m.FormName)).Count() > 0)
               {
                   sb.Append("<li>");
                   var href = item.FormName == "" ? "#" : ResolveUrl(item.FormName);
                   sb.Append("<a class=\"multi\" href=\" " + root + href + "\">" + item.DisplayMember + "</a>");
                   sb.Append("<ul>");
                   foreach (var inner in allMenu.FindAll(m => m.ParentID == item.ObjectID && m.MenuType!="Home"))
                   {
                       href = inner.FormName == "" ? "#" : ResolveUrl(inner.FormName);
                       sb.Append("<li><a href=\"" + root + href + "\">" + inner.DisplayMember + "</a></li>");
                   }
                   sb.Append("</ul>");
                   sb.Append("</li><li>|</li>");
               }
               //else
               //{
               //    sb.Append("<li>");
               //    var href = item.FormName == "" ? "#" : ResolveUrl(item.FormName);
               //    sb.Append("<a href=\" " + root + href + "\">" + item.DisplayMember + "</a>");
               //    sb.Append("</li><li>|</li>");
               //}
           }
            var menuText = "<div class=\"menu\"><nav><ul>" + new String((new String(sb.ToString().Reverse().Skip(10).ToArray())).Reverse().ToArray()) + "</ul></nav></div>";

            ltrMenu.Text = menuText;
        }

        private string GetCurrentModule(Uri uri, out string moduleName)
        {
            var layers = uri.Segments.ToList();
            var layer = uri.Segments.Count();
            var port = uri.Port;

            if (string.IsNullOrEmpty(root))
                switch (layer)
                {
                    case 0:
                    case 1:
                    case 2:
                        moduleName = "HOME";
                        return "layer1";
                    case 3:
                        moduleName = layers[1].Split('/')[0].ToUpper();
                        return "layer2";
                    case 4:
                    case 5:
                        moduleName = layers[2].Split('/')[0].ToUpper();
                        return "layer3";
                    default:
                        moduleName = "HOME";
                        return "layer1";
                }
            else
                switch (layer)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        moduleName = "HOME";
                        return "layer1";
                    case 4:
                        moduleName = layers[2].Split('/')[0].ToUpper();
                        return "layer2";
                    case 5:
                    case 6:
                        moduleName = layers[3].Split('/')[0].ToUpper();
                        return "layer3";
                    default:
                        moduleName = "HOME";
                        return "layer1";
                }
        }
    }
}