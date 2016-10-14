using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace AST.Web.Hr
{
    public partial class FileDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var downloadPath = Request.QueryString["dp"];
            var fn = Request.QueryString["fn"];
            if (downloadPath != null && fn != null)
            {
                ProcessDownload(downloadPath.ToString(), fn.ToString());
            }
        }
        private void ProcessDownload(string path, string fn)
        {
            try
            {
                var fi = new FileInfo(path);
                Response.ContentType = GetContentType(path);
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fn + fi.Extension);

                Response.TransmitFile(MapPath(path));
                Response.End();
            }
            catch (IOException iex)
            {
                Response.Output.WriteLine(iex.Message);
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Output.WriteLine(ex.Message);
                Response.End();
            }
        }

        private string GetContentType(string fileName)
        {

            string contentType = "application/octetstream";

            string ext = System.IO.Path.GetExtension(fileName).ToLower();

            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

            if (registryKey != null && registryKey.GetValue("Content Type") != null)

                contentType = registryKey.GetValue("Content Type").ToString();

            return contentType;

        }
    }
}