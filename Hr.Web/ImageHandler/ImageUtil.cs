using System;
using System.Drawing;
using System.IO;
using ASL.STATIC;
using System.Web;


namespace ST.ImageHandler
{
    public class ImageUtil
    {
        internal static String GetSessionID()
        {
            return HttpContext.Current.Session.SessionID;
        }

        public static Image ByteArrayToImage(Byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static void SavePictureInServer(String fileName, Byte[] byteImage)
        {
            try
            {
                String savePath = StaticInfo.ImageTmpSavePath + "/" + fileName;

                Image image = ByteArrayToImage(byteImage);
                if (!File.Exists(savePath))
                {
                    if (!Directory.Exists(StaticInfo.ImageTmpSavePath))
                        Directory.CreateDirectory(StaticInfo.ImageTmpSavePath);

                    image.Save(savePath);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //public static void SaveResizePictureInServer(String fileName, Image image)
        //{
        //    try
        //    {
        //        String savePath = StaticInfo.ImageTmpSavePath + "/Resize" + fileName;

        //        if (!File.Exists(savePath))
        //        {
        //            if (!Directory.Exists(StaticInfo.ImageTmpSavePath))
        //                Directory.CreateDirectory(StaticInfo.ImageTmpSavePath);

        //            image.Save(savePath);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public static void SavePictureInServer(String styleId, String fileName)
        //{
        //    try
        //    {
        //        String saveDir = StaticInfo.ImageSavePath + "/" + styleId + "/";
        //        String savePath = StaticInfo.ImageSavePath + "/" + styleId + "/" + fileName;

        //        if (!File.Exists(savePath))
        //        {
        //            if (!Directory.Exists(saveDir))
        //                Directory.CreateDirectory(saveDir);

        //            String sourcePath = GetFilePathFromTemporaryFiles(fileName);
        //            File.Copy(sourcePath, savePath, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //private static String GetFilePathFromTemporaryFiles(String fileName)
        //{
        //    try
        //    {
        //        return StaticInfo.ImageTmpSavePath + "/" + fileName;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static string GetPictureViewPathFromServer(String fileName, ImageSaveOption saveOption)
        //{
        //    try
        //    {
        //        if (saveOption == ImageSaveOption.Temporary)
        //        {
        //            return StaticInfo.ImageTmpViewPath + "/" + fileName;
        //        }
        //        else
        //        {
        //            return StaticInfo.ImageViewPath + "/" + fileName;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public static void SaveDocumentInServer(String fileName, HttpPostedFile myFile)
        //{
        //    String savePath = StaticInfo.ImageTmpSavePath + "/" + fileName;
        //    // Get size of uploaded file
        //    int nFileLen = myFile.ContentLength;

        //    // make sure the size of the file is > 0
        //    if (nFileLen > 0)
        //    {
        //        // Allocate a buffer for reading of the file
        //        Byte[] myData = new Byte[nFileLen];

        //        // Read uploaded file from the Stream
        //        myFile.InputStream.Read(myData, 0, nFileLen);

        //        if (!File.Exists(savePath))
        //        {
        //            if (!Directory.Exists(StaticInfo.ImageTmpSavePath))
        //                Directory.CreateDirectory(StaticInfo.ImageTmpSavePath);

        //            // Write data into a file
        //            WriteToFile(savePath, myData);
        //        }
        //    }

        //}

        //public static void SaveDocumentInServer(String styleId, String fileName)
        //{
        //    try
        //    {
        //        String saveDir = StaticInfo.ImageSavePath + "/" + styleId + "/";
        //        String savePath = StaticInfo.ImageSavePath + "/" + styleId + "/" + fileName;

        //        if (!File.Exists(savePath))
        //        {
        //            if (!Directory.Exists(saveDir))
        //                Directory.CreateDirectory(saveDir);

        //            String sourcePath = GetFilePathFromTemporaryFiles(fileName);
        //            File.Copy(sourcePath, savePath, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        // Writes file to current folder
        private static void WriteToFile(String filePath, Byte[] Buffer)
        {
            // Create a file
            FileStream newFile = new FileStream(filePath, FileMode.Create);

            // Write data to the file
            newFile.Write(Buffer, 0, Buffer.Length);

            // Close file
            newFile.Close();
        }

        public static void DeleteFileFromServer(String styleId, String fileName)
        {
            try
            {
                String savePath = StaticInfo.ImageSavePath + @"/" + styleId + "/" + fileName;
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }


}
