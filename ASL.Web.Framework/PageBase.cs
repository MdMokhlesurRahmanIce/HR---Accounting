using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using ASL.Security.DAO;
using ASL.Security.BLL;
using ASL.DATA;
using ASL.STATIC;
using System.Web.UI.WebControls;

namespace ASL.Web.Framework
{
    public class PageBase : InternalPage
    {
        public Boolean RequiresAuthorization = false;
        public Boolean enterintoLoadEvent = true;
        private String thisPage = string.Empty;

        protected internal FormAccessRights accessRights
        {
            get
            {
                if (ViewState["accessRights"].IsNull())
                    return new FormAccessRights();
                else
                    return (FormAccessRights)ViewState["accessRights"];
            }
            set
            {
                ViewState["accessRights"] = value;
            }
        }
        public new User CurrentUserSession
        {
            get { return base.CurrentUserSession as User; }
            set
            {
                base.CurrentUserSession = value;
            }
        }

        public new List<String> OpenPages
        {
            get { return base.OpenPages as List<String>; }
            set
            {
                base.OpenPages = value;
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            thisPage = Request.Url.Segments[Request.Url.Segments.Length - 1].Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];

            if (Request.Params["theme"].IsNotNull())
            {
                Theme = Request.Params["theme"];
                Session["Static_theme"] = Request.Params["theme"];
            }
            else if (Session["Static_theme"].IsNotNull() && Theme.IsNotNullOrEmpty())
            {
                Theme = (String)Session["Static_theme"];
            }
            base.OnPreInit(e);
        }

        protected override void OnInit(EventArgs e)
        {
            if (RequiresAuthorization)
            {
                ProcessValidation();
            }
            base.OnInit(e);
        }

        protected override void OnInitComplete(EventArgs e)
        {
            if (Request.QueryString.Get("_clearSession").IsNotNullOrEmpty() && !thisPage.Equals("Home"))
            {
                if (Request.QueryString.Get("_clearSession") == "yes")
                {
                    //Clear page session here....
                    try
                    {
                        ClearSessionVariables();
                    }
                    catch { };
                    enterintoLoadEvent = false;
                }
            }
            base.OnInitComplete(e);
        }
        private void ClearSessionVariables()
        {
            //one instance of a page
            try
            {
                this.OpenPages.Remove(thisPage);
            }
            catch
            {
                throw new Exception("Error while removing from Open Pages List");
            }
            //end

            List<String> sessonList = new List<String>();
            foreach (String sessionName in Session.Keys)
            {
                if (sessionName.StartsWith(thisPage))
                    sessonList.Add(sessionName);
            }
            foreach (String sessionName in sessonList)
            {
                Session[sessionName] = null;
                Session.Remove(sessionName);
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            if (IsPostBack.IsFalse() && RequiresAuthorization)
            {
                GetFormAccess();
            }
            base.OnPreLoad(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }


        protected override void OnLoadComplete(EventArgs e)
        {
            string _isPostBack = Request.QueryString.Get("_isPostBack");
            if (_isPostBack == "yes") Session["_isPostBack"] = "yes";
            else Session["_isPostBack"] = "no";

            base.OnLoadComplete(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
        }

        public String StatusPageMessage
        {
            set { Session["ShowStatus_Message"] = value; }
            get
            {
                if (Session["ShowStatus_Message"].IsNull())
                    return null;
                else
                    return (String)Session["ShowStatus_Message"];
            }
        }

        protected void ProcessValidation()
        {
            //one instance of a page
            if (IsPostBack.IsFalse() && OpenPages.IsNotNull() && Request.QueryString.Get("_clearSession").NotEquals("yes"))
            {
                string _isPostBack = Request.QueryString.Get("_isPostBack");
                _isPostBack = _isPostBack.IsNull() ? "" : _isPostBack;

                if (_isPostBack == "yes") Session["_isPostBack"] = "yes";

                if (_isPostBack.Equals("yes") || (Session["_isPostBack"].IsNotNull() && Session["_isPostBack"].Equals("yes")))
                {
                    Session["_isPostBack"] = "yes";
                    return;
                }

                if (ProcessRedirect())
                {
                    //Response.Redirect("~/Security/Message.htm");
                }
                else
                {
                    if (this.OpenPages.Contains(thisPage).IsFalse())
                    {
                        this.OpenPages.Add(thisPage);
                    }
                }
            }
            //End ...........................

            if (IsUserAuthorized().IsFalse())
            {
                Response.Redirect("~/UI/Security/Login.aspx?back_url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
        }
        /// <summary>
        /// one instance of a page
        /// </summary>
        /// <returns></returns>
        private Boolean ProcessRedirect()
        {
            if (thisPage.ToLower() == "reportprint" || thisPage.ToLower() == "default" || thisPage.ToLower() == "home") return false;
            if (OpenPages.Contains(thisPage))
                return true;
            return false;
        }

        public Boolean IsUserAuthorized()
        {
            if (CurrentUserSession.IsNull())
                return false;

            return CurrentUserSession.IsLoggedIn;
        }

        protected internal void GetFormAccess()
        {
            SecurityManager manager = new SecurityManager();

            String formName = string.Empty;

#if DEBUG
            {
                formName = Request.Url.AbsolutePath;
            }
#else
            {
                formName = Request.Url.AbsolutePath.Replace(@"/ERP","");
            }
#endif

            if (CurrentUserSession.IsAdmin)
            {
                accessRights = new FormAccessRights();
                accessRights.CanSelect = true;
                accessRights.CanInsert = true;
                accessRights.CanUpdate = true;
                accessRights.CanDelete = true;
            }
            else
            {
                this.accessRights = manager.GetFormAccessRights(CurrentUserSession.UserCode, formName);
            }
        }

        #region User Authentication.
        /// <summary>
        /// Check User Authentication
        /// </summary>
        /// <param name="saveItemList"></param>
        /// <returns></returns>
        protected internal Boolean CheckUserAuthentication(params IEnumerable[] saveItemList)
        {
            try
            {
                foreach (IEnumerable itemList in saveItemList)
                {
                    CustomList<BaseItem> baseList = itemList.ToCustomList<BaseItem>();
                    if (accessRights.CanInsert.IsFalse() && baseList.Find(p => p.IsAdded).IsNotNull())
                    {
                        this.ErrorMessage = ("You have no permission to add any information from this page.");
                        return false;
                    }
                    else if (accessRights.CanUpdate.IsFalse() && baseList.Find(p => p.IsModified).IsNotNull())
                    {
                        this.ErrorMessage = ("You have no permission to update any information in this page.");
                        return false;
                    }
                    else if (accessRights.CanDelete.IsFalse() && baseList.Find(p => p.IsDeleted).IsNotNull())
                    {
                        this.ErrorMessage = ("You have no permission to delete any information in this page.");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected internal Boolean CheckUserAuthentication(params BaseItem[] saveItems)
        {
            try
            {
                foreach (BaseItem item in saveItems)
                {
                    if (accessRights.CanInsert.IsFalse() && item.IsAdded)
                    {
                        this.ErrorMessage = ("You have no permission to add any information from this page.");
                        return false;
                    }
                    else if (accessRights.CanUpdate.IsFalse() && item.IsModified)
                    {
                        this.ErrorMessage = ("You have no permission to update any information in this page.");
                        return false;
                    }
                    else if (accessRights.CanDelete.IsFalse() && item.IsDeleted)
                    {
                        this.ErrorMessage = ("You have no permission to delete any information in this page.");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region Error Message
        public string ErrorMessage
        {
            set
            {
                Control control = this.FindControlRecursive("lblMsg");
                if (control != null)
                {
                    var ctrlLabel = control as Label;
                    ctrlLabel.Text = value;
                    ctrlLabel.Visible = true;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "error-message", "showServerMsg('error')", true);
                }
                else
                {
                    throw new Exception("could not find control 'lblMsg'");
                }
            }
        }

        public string SuccessMessage
        {
            set
            {
                Control control = this.FindControlRecursive("lblMsg");
                if (control != null)
                {
                    var ctrlLabel = control as Label;
                    ctrlLabel.Text = value;
                    ctrlLabel.Visible = true;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "error-message", "showServerMsg('success')", true);
                }
                else
                {
                    throw new Exception("could not find control 'lblMsg'");
                }
            }
        }
        #endregion
    }
}