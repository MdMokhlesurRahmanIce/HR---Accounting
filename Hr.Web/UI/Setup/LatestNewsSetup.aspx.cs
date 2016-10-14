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
using System.Data.SqlClient;

namespace Hr.Web.UI.Setup
{
    public partial class LatestNewsSetup : PageBase
    {
        LatestNewsManager _manager = new LatestNewsManager();
        #region Constructur
        public LatestNewsSetup()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variables
        private CustomList<LatestNews> LatestNewsList
        {
            get
            {
                if (Session["LatestNewsSetup_LatestNewsList"] == null)
                    return new CustomList<LatestNews>();
                else
                    return (CustomList<LatestNews>)Session["LatestNewsSetup_LatestNewsList"];
            }
            set
            {
                Session["LatestNewsSetup_LatestNewsList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack.IsFalse())
            {
                LatestNewsList = new CustomList<LatestNews>();
                LatestNewsList = _manager.GetAllLatestNews();
            }
        }
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<LatestNews> LatestNews = LatestNewsList;

                if (!CheckUserAuthentication(LatestNews)) return;
                _manager.SaveLatestNews(ref LatestNews);
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
            }
            catch (SqlException ex)
            {
                this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        #endregion
    }
}