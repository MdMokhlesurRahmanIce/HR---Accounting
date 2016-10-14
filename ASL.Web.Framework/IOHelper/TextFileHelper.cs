using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ASL.DATA;
using System.IO;

namespace ASL.Web.Framework.IOHelper
{
    public class TextFileHelper : IDisposable
    {
        private FileUpload _fileUpload;
        private string _fileName;

        public TextFileHelper(FileUpload fp,  string fileName)
        {
            _fileUpload = fp;
            _fileName = fileName;
        }

        public bool ImportFile()
        {
            try
            {
                if (_fileName.IsNotNullOrEmpty())
                {
                    var fileInfo = new FileInfo(_fileUpload.FileName);
                    File.WriteAllBytes(_fileName, _fileUpload.FileBytes);
                    return true;
                }
                return false;
            }
            catch (IOException ex)
            {
                throw new Exception(ExceptionHelper.getIOExceptionMessage(ex));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
