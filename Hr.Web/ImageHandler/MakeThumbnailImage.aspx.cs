using System;
using ASL.DATA;

namespace ST.ImageHandler
{
    public partial class MakeThumbnailImage : System.Web.UI.Page
    {
        protected void Page_Load(Object sender, EventArgs e)
        {
            if (Request.QueryString["fileName"].IsNullOrEmpty())
                return;
            // get the file name -- fall800.jpg
            String file = Request.QueryString["fileName"];

            // create an image object, using the filename we just retrieved
            System.Drawing.Image image = System.Drawing.Image.FromFile(file);

            // create the actual thumbnail image
            System.Drawing.Image thumbnailImage = image.GetThumbnailImage(120, 105, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);

            //// make a memory stream to work with the image bytes
            //MemoryStream imageStream = new MemoryStream();

            // put the image into the memory stream
            Response.ContentType = "image/jpeg";
            thumbnailImage.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            ////// make byte array the same size as the image
            ////Byte[] imageContent = new Byte[imageStream.Length];

            ////// rewind the memory stream
            ////imageStream.Position = 0;

            ////// load the byte array with the image
            ////imageStream.Read(imageContent, 0, (int)imageStream.Length);

            ////// return byte array to caller with image type
            ////Response.ContentType = "image/jpeg";
            ////Response.BinaryWrite(imageContent);
        }
        /// <summary>
        /// Required, but not used
        /// </summary>
        /// <returns>true</returns>
        public Boolean ThumbnailCallback()
        {
            return true;
        }
    }
}
