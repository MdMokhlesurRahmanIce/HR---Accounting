using System;
using ASL.DATA;

namespace ST.ImageHandler
{
    public partial class ImageViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //imgPicture.ImageUrl = Session["ImageViewerImagePath"].ToString();
            if (Request.QueryString["fileName"].IsNotNullOrEmpty())
                imgPicture.ImageUrl = Request.QueryString["fileName"];
        }
    }
}
