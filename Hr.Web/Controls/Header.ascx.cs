using System;
using System.Web;
using System.Web.UI.WebControls;
using ASL.DATA;
using ASL.Security.BLL;
using ASL.STATIC;
using Application = ASL.Security.DAO.Application;
using ASL.Web.Framework;

namespace Hr.Web.Controls
{
    public partial class Header : System.Web.UI.UserControl
    {
        User _user = (User)HttpContext.Current.Session["CurrentUserSession"];

        private CustomList<Application> _applications
        {
            get
            {
                if (ViewState["_applications"] == null)
                    return null;
                else return (CustomList<Application>)ViewState["_applications"];
            }
            set
            {
                ViewState["_applications"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((PageBase)Page).enterintoLoadEvent) return;
            if (!IsPostBack)
            {
                ApplicationManager manager = new ApplicationManager();
                _applications = manager.GetAllApplication();
            }
            populateControl();
        }

        private void populateControl()
        {
            dlApplications.DataSource = _applications;
            dlApplications.DataBind();
            dlApplications.ItemStyle.VerticalAlign = VerticalAlign.Top;
            dlApplications.AlternatingItemStyle.VerticalAlign = VerticalAlign.Top;
        }

        protected void dlApplications_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int ApplicationID = Convert.ToInt32((((HiddenField)e.Item.FindControl("HiddenField1")).Value));

                ASL.Security.DAO.Application application = _applications.Find(p => p.ApplicationID == ApplicationID.ToString());

                ((Image)e.Item.FindControl("picMenuItem")).ImageUrl = GetImageUrl(application.ApplicationLogoPath);
            }
        }

        private string GetImageUrl(string imageName)
        {
            try
            {
                return StaticInfo.ImageViewPath + "/ApplicationLogo/" + imageName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dlApplications_ItemCommand(object source, DataListCommandEventArgs e)
        {
            _user.CurrentApplicationID = int.Parse(e.CommandArgument.ToString());
            //((leftMenu)this.Page.Master.FindControl("leftMenu1")).RenderMenus();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Security/Login.aspx");
        }
    }
}