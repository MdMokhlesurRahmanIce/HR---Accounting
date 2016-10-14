using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
//using log4net;
namespace ASL.Web.Framework
{
    public class ExceptionHelper
    {
        public static string getSqlExceptionMessage(SqlException ex)
        {
           // log4net.ILog logger = log4net.LogManager.GetLogger(typeof(log4net.Appender.RollingFileAppender));
            string.Format("Error Code:{0}. Message:{1}. StackTrace:{2}", ex.ErrorCode, ex.Message, ex.StackTrace);

            switch (ex.Number)
            {
                case 2601:
                    return "Cannot insert duplicate record. The statement has been terminated.";
                case 547:
                    return "Reference exists. Cannot delete the record. The statement has been terminated.";
                default:
                    return ex.Message;
            }
        }

        public static string getExceptionMessage(Exception ex)
        {
           // log4net.ILog logger = log4net.LogManager.GetLogger(typeof(log4net.Appender.RollingFileAppender));
            string.Format("Message:{0}. StackTrace:{1}", ex.Message, ex.StackTrace);
            return ex.Message;
        }

        public static string getIOExceptionMessage(IOException ex)
        {
            // log4net.ILog logger = log4net.LogManager.GetLogger(typeof(log4net.Appender.RollingFileAppender));
            string.Format("Message:{0}. StackTrace:{1}", ex.Message, ex.StackTrace);
            return ex.Message;
        }
    }
}
