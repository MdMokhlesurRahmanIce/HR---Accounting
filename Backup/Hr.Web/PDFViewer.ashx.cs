using System;
using System.Web;

namespace Hr.Web
{
    /// <summary>
    /// Summary description for PDFViewer
    /// </summary>
    public class PDFViewer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
          context.Response.ContentType = "Application/pdf";
          context.Response.WriteFile(@"C:\Downloads\2830.pdf");
          context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}