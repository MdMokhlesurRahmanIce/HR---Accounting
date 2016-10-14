using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using ASL.DATA;

namespace Hr.Web.GridHelperClasses
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DropDownSource : IHttpHandler, IRequiresSessionState
    {
        private String SessionVarName { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                SessionVarName = context.Request.QueryString["SessionVarName"];
                String acField = context.Request.QueryString["acField"];
                string BuyerName = context.Request.QueryString["BuyerName"];
                String response = String.Empty;

                IEnumerable retrievedData = (IEnumerable)context.Session[SessionVarName];
                if (retrievedData.IsNotNull())
                {
                    if (acField.IsNotNullOrEmpty())
                        response = GenerateReturnStringAutoComplete(retrievedData);
                    else
                        response = GenerateReturnString(retrievedData);

                }
                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.Write(response);
                context.Response.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String GenerateReturnStringAutoComplete(IEnumerable retrievedData)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                String acField = HttpContext.Current.Request.QueryString["acField"];
                String BuyerCode = HttpContext.Current.Request.QueryString["BuyerCode"];

                if (acField.IsNullOrEmpty()) return String.Empty;


                Object tmpDataTextField = null;

                foreach (Object item in retrievedData)
                {
                    tmpDataTextField = item.GetType().GetProperty(acField).GetValue(item, null);
                    if (tmpDataTextField.IsNull() || tmpDataTextField.ToString() == string.Empty) continue;

                    sb.Append(tmpDataTextField);
                    sb.Append(";");
                }

                //deleting ";" char at the end of the String 
                if (sb.Length > 1)
                    sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private String GenerateReturnString(IEnumerable retrievedData)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                String DataTextField = HttpContext.Current.Request.QueryString["DataTextField"];
                String DataValueField = HttpContext.Current.Request.QueryString["DataValueField"];
                String needBlank = HttpContext.Current.Request.QueryString["NeedBlank"];

                Object tmpDataValueField = null;
                Object tmpDataTextField = null;

                if (needBlank.IsNullOrEmpty())
                    sb.Append("-1:--Select--;");
                else if (needBlank.CompareTo("Empty").IsZero())
                    sb.Append(":--Select--;");
                else
                    sb.Append(" : ;");

                //
                foreach (Object item in retrievedData)
                {
                    tmpDataValueField = item.GetType().GetProperty(DataValueField).GetValue(item, null);
                    tmpDataTextField = item.GetType().GetProperty(DataTextField).GetValue(item, null);

                    if ((tmpDataValueField.IsNull()) || (tmpDataValueField.ToString().IsNullOrEmpty())) continue;
                    if (tmpDataTextField.IsNull())
                        tmpDataTextField = String.Empty;

                    sb.Append(tmpDataValueField);
                    sb.Append(":");
                    sb.Append(tmpDataTextField);
                    sb.Append(";");

                    /*
                        *  if the following codes are used instead, the respective dropdown will include any blank item available in the list

                        sb.Append(item.GetType().GetProperty(DataValueField).GetValue(item, null));
                        sb.Append(":");
                        sb.Append(item.GetType().GetProperty(DataTextField).GetValue(item, null));
                        sb.Append(";");
                    */
                }

                //deleting ";" char at the end of the String 
                if (sb.Length > 1)
                    sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
