using System;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using ASL.DATA;
using ASL.Hr.DAO;
using System.Text;

namespace Hr.Web.GridHelperClasses
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class MultiDropdownSource : IHttpHandler, IRequiresSessionState
    {
        public Boolean IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                String response = GenerateReturnString();
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

        private String GenerateReturnString()
        {
            try
            {
                String mode = HttpContext.Current.Request.QueryString["mode"];
                String thisval = "";

                switch (mode)
                {
                    case "onSelectMode_Key1":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        CustomList<HouseKeepingValue> retrievedData = HouseKeepingValue.GetAllHouseKeepingValueForDropdown(thisval.ToInt());
                        return MakeString(retrievedData);
                    case "onSelectMode_Key2":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        retrievedData = HouseKeepingValue.GetAllHouseKeepingValueForDropdown(thisval.ToInt());
                        return MakeString(retrievedData);
                    case "onSelectMode_Key3":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        retrievedData = HouseKeepingValue.GetAllHouseKeepingValueForDropdown(thisval.ToInt());
                        return MakeString(retrievedData);
                    case "onSelectMode_Key4":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        retrievedData = HouseKeepingValue.GetAllHouseKeepingValueForDropdown(thisval.ToInt());
                        return MakeString(retrievedData);
                    case "onSelectMode_Key5":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        retrievedData = HouseKeepingValue.GetAllHouseKeepingValueForDropdown(thisval.ToInt());
                        return MakeString(retrievedData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }

        private String MakeString(CustomList<HouseKeepingValue> retDataFiltered)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<option value=-1>--Select--</option>");
            //retDataFiltered.Sort();

            foreach (HouseKeepingValue item in retDataFiltered)
            {
                if ((item.HKID == null) || (item.HKID.ToString() == String.Empty)) continue;
                if (item.HKName == null)
                    item.HKName = String.Empty;

                sb.Append("<option value=");
                sb.Append(item.HKID);
                sb.Append(">");
                sb.Append(item.HKName);
                sb.Append("</option>");
            }

            return sb.ToString();
        }
        //private String MakeStringAllowDed(CustomList<HR_AllowDed> retDataFiltered)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<option value=-1>--Select--</option>");
        //    //retDataFiltered.Sort();

        //    foreach (HR_AllowDed item in retDataFiltered)
        //    {
        //        if ((item.AllowDedType == null) || (item.AllowDedType.ToString() == String.Empty)) continue;
        //        if (item.AllowDedName == null)
        //            item.AllowDedName = String.Empty;

        //        sb.Append("<option value=");
        //        sb.Append(item.AllowDedType);
        //        sb.Append(">");
        //        sb.Append(item.AllowDedName);
        //        sb.Append("</option>");
        //    }

        //    return sb.ToString();
        //}

    }
}