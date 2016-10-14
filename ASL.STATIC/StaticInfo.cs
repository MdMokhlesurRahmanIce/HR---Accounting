using System;
using System.Collections;
using System.Data;
using System.Reflection;
using ASL.DAL;
using ASL.DATA;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ASL.STATIC
{
    public class StaticInfo
    {
        public static String[] GridDateFormatArray = new String[] { "dd/MM/yyyy", "MM/dd/yyyy" };
        public const String GridDateFormat = "MM/dd/yyyy";
        public const String GridDateFormatAcc = "dd/MM/yyyy";
        public const String DateFormat = "yyyy-MMM-dd";
        public const String TimeFormat = "hh:mm:ss tt";
        public const String DateTimeFormat = "yyyy-MM-dd hh:mm:ss.mmm";
        public const String NewIDString = "****<< NEW >>****";
        public const String NewIDStringForChild = "**<< NEW >>**";
        public const String ERPTitle = "ERP";
        public const String SearchSessionVarName = "ctl00_grdSearchGrid";
        public const String SearchColumnConfigSessionVarName = "SearchColumnConfig";
        public const String SearchArg = "SearchArg";
        public const String GlobalSearchType = "GlobalSearchType";
        public const String encString = "Windows123?/";
        public const String EmpListSessionVarName = "View_EmpList";

        #region Message Templates
        public const String SavedSuccessfullyMsg = "Record saved successfully";
        public const String SaveErrorMsg = "Record could not be saved.";
        public const String UpdatedSuccessfullyMsg = "Changes updated successfully";
        public const String DeletedSuccessfullyMsg = "Record deleted successfully";
        public const String DeletedErrorMsg = "Record could not be deleted.";
        public const String MessageCss = "message";
        public const String ErrorCss = "error";
        public const String ErrorCssHP = "errorHP";
        #endregion

        public static CompanyEntity CurrentCompany = new CompanyEntity();

        /// <summary>
        /// Generate Unique Id for any Table
        /// </summary>
        /// <param name="fieldName">Class name/Tablename for which this function is calling.</param>
        /// <param name="codeLength">Length of the code.</param>
        /// <param name="date">Date to generate date wise unique id</param>
        /// <param name="dateFormat">Format of the date to be applied in Unique id</param>        
        /// <param name="prefix">For prefix =true or for suffix =false</param>
        /// <param name="delimeter">Delemeter to be added for example "/" or "-"</param>
        /// <param name="suffix">Suffix code</param>
        /// <returns>returns the generated Unique Id</returns>
        public static String MakeUniqueCode(String fieldName, int codeLength, String date, String dateFormat,
            String prefix, String delimeter, String suffix)
        {
            String uniqueCode = String.Empty;
            String maxId = String.Empty;
            int lengthWithoutCode = 0;

            try
            {


                String sql = "Exec spMakeCode '" + fieldName + "','" + DateTime.Parse(date).ToString("yyyy") + "'";
                CustomList<Signature> listSignature = Signature.GetSignatureForUniqueCode(sql);

                if (listSignature.Count > 0)
                {
                    maxId = listSignature[0].LastNumber.ToString();
                }

                if (prefix.Length > 0 && suffix.Length > 0)
                {
                    lengthWithoutCode = dateFormat.Length +
                        prefix.Length + delimeter.Length * 3 + suffix.Length;

                    if (lengthWithoutCode > codeLength)
                    {
                        throw (new Exception("Unique Code length will exceed the length specified!"));
                    }

                    uniqueCode = prefix + delimeter + DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId +
                        delimeter + suffix;
                }
                else if (prefix.Length > 0)
                {
                    lengthWithoutCode = dateFormat.Length +
                        prefix.Length + delimeter.Length * 2;

                    if (lengthWithoutCode > codeLength)
                    {
                        throw (new Exception("Unique Code length will exceed the length specified!"));
                    }

                    uniqueCode = prefix + delimeter + DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId.PadLeft((codeLength - lengthWithoutCode), char.Parse("0"));

                    uniqueCode = prefix + delimeter + DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId;
                }
                else if (suffix.Length > 0)
                {
                    lengthWithoutCode = dateFormat.Length +
                        delimeter.Length * 2 + suffix.Length;

                    if (lengthWithoutCode > codeLength)
                    {
                        throw (new Exception("Unique Code length will exceed the length specified!"));
                    }

                    uniqueCode = DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId +
                        delimeter + suffix;
                }
                else
                {
                    lengthWithoutCode = dateFormat.Length + delimeter.Length;

                    if (lengthWithoutCode > codeLength)
                    {
                        throw (new Exception("Unique Code length will exceed the length specified!"));
                    }
                    uniqueCode = DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId;

                }

                return uniqueCode;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static String MakeUniqueCode(ref ConnectionManager conSys, String fieldName, int codeLength, String date, String dateFormat,
            String prefix, String delimeter, String suffix)
        {
            String uniqueCode = String.Empty;
            String maxId = String.Empty;
            int lengthWithoutCode = 0;

            try
            {


                String sql = "Exec spMakeCode '" + fieldName + "','" + DateTime.Parse(date).ToString("yyyy") + "'";
                CustomList<Signature> listSignature = Signature.GetSignatureForUniqueCode(ref conSys, sql);

                if (listSignature.Count > 0)
                {
                    maxId = listSignature[0].LastNumber.ToString();
                }

                if (prefix.Length > 0 && suffix.Length > 0)
                {
                    lengthWithoutCode = dateFormat.Length +
                        prefix.Length + delimeter.Length * 3 + suffix.Length;

                    if (lengthWithoutCode > codeLength)
                    {
                        throw (new Exception("Unique Code length will exceed the length specified!"));
                    }

                    uniqueCode = prefix + delimeter + DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId +
                        delimeter + suffix;
                }
                else if (prefix.Length > 0)
                {
                    lengthWithoutCode = dateFormat.Length +
                        prefix.Length + delimeter.Length * 2;

                    if (lengthWithoutCode > codeLength)
                    {
                        throw (new Exception("Unique Code length will exceed the length specified!"));
                    }

                    uniqueCode = prefix + delimeter + DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId.PadLeft((codeLength - lengthWithoutCode), char.Parse("0"));

                    uniqueCode = prefix + delimeter + DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId;
                }
                else if (suffix.Length > 0)
                {
                    lengthWithoutCode = dateFormat.Length +
                        delimeter.Length * 2 + suffix.Length;

                    if (lengthWithoutCode > codeLength)
                    {
                        throw (new Exception("Unique Code length will exceed the length specified!"));
                    }

                    uniqueCode = DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId +
                        delimeter + suffix;
                }
                else
                {
                    lengthWithoutCode = dateFormat.Length + delimeter.Length;

                    if (lengthWithoutCode > codeLength)
                    {
                        throw (new Exception("Unique Code length will exceed the length specified!"));
                    }
                    uniqueCode = DateTime.Parse(date).ToString(dateFormat) +
                        delimeter + maxId;

                }

                return uniqueCode;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static Int32 GetUniqueCodeWithoutSignature(ref  ConnectionManager objCon, Boolean requiredTransaction, String strTableName, String strFieldName,
String strPrefix)
        {
            String sql = "";
            Int32 strMaxId = 0;

            try
            {
                sql = "Exec spGetIDWithoutSignature '" +
                    strTableName + "','" + strFieldName + "','" +
                    strPrefix + "'";

                IDataReader reader;
                objCon.OpenDataReader(sql, out reader, CommandBehavior.Default, requiredTransaction);
                while (reader.Read())
                {
                    strMaxId = Convert.ToInt32(reader["MaxId"]);
                }

                reader.Close();
                return strMaxId;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static Object ReturnValueByDataType(String dataType, String value)
        {
            try
            {
                switch (dataType)
                {
                    case "System.DateTime":
                        return DateTime.Parse(value);
                    case "System.Decimal":
                        return Decimal.Parse(value);
                    case "System.Int16":
                        return Int16.Parse(value);
                    case "System.Int32":
                        return Int32.Parse(value);
                    case "System.Int64":
                        return Int64.Parse(value);
                    case "System.Double":
                        return Double.Parse(value);
                    case "System.Boolean":
                        return Boolean.Parse(value);
                    default:
                        return value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SearchItem(IList List, String SearchTitle, String SearchFor, String HiddenColumns)
        {
            try
            {
                System.Web.HttpContext.Current.Session[GlobalSearchType] = null;
                SearchItem(List, SearchTitle, SearchFor, HiddenColumns, false, String.Empty);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void SearchItem(IList List, String SearchTitle, String SearchFor, String HiddenColumns, int WWidth)
        {
            try
            {
                System.Web.HttpContext.Current.Session[GlobalSearchType] = null;
                SearchItem(List, SearchTitle, SearchFor, HiddenColumns, false, String.Empty, WWidth, String.Empty);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void SearchItem(IList List, String SearchTitle, String SearchFor, IList columnConfigList)
        {
            try
            {
                System.Web.HttpContext.Current.Session[GlobalSearchType] = null;
                System.Web.HttpContext.Current.Session[SearchColumnConfigSessionVarName] = columnConfigList;
                SearchItem(List, SearchTitle, SearchFor, String.Empty, false, String.Empty);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void SearchItem(IList List, String SearchTitle, String SearchFor, IList columnConfigList, int WWidth)
        {
            try
            {
                System.Web.HttpContext.Current.Session[GlobalSearchType] = null;
                System.Web.HttpContext.Current.Session[SearchColumnConfigSessionVarName] = columnConfigList;
                SearchItem(List, SearchTitle, SearchFor, String.Empty, false, String.Empty, WWidth, String.Empty);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //zaki - overloaded mehtod - to provide a flag (enum) "searchType"
        public static void SearchItem(IList List, String SearchTitle, String SearchFor, IList columnConfigList, int WWidth, GlobalEnums.enumSearchType searchType)
        {
            try
            {
                System.Web.HttpContext.Current.Session[GlobalSearchType] = searchType;
                System.Web.HttpContext.Current.Session[SearchColumnConfigSessionVarName] = columnConfigList;
                SearchItem(List, SearchTitle, SearchFor, String.Empty, false, String.Empty, WWidth, String.Empty);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void SearchItem(IList List, String SearchTitle, String SearchFor, String HiddenColumns, bool MultipleSelect, String Selected_VID)
        {
            try
            {
                System.Web.UI.Page page = System.Web.HttpContext.Current.CurrentHandler as System.Web.UI.Page;

                System.Web.HttpContext.Current.Session[SearchSessionVarName] = List;
                String script = "javascript:LoadSearchGrid('" + SearchTitle + "','" + SearchFor + "','" + HiddenColumns + "'," + MultipleSelect.ToString().ToLower() + ",'" + Selected_VID + "');";
                if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("clientScript"))
                {
                    page.ClientScript.RegisterStartupScript(typeof(StaticInfo), "clientScript", script, true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void SearchItem(IList List, String SearchTitle, String SearchFor, String HiddenColumns, bool MultipleSelect, String Selected_VID, int WWidth, String MustSelectedVids)
        {
            try
            {
                System.Web.UI.Page page = System.Web.HttpContext.Current.CurrentHandler as System.Web.UI.Page;

                System.Web.HttpContext.Current.Session[SearchSessionVarName] = List;
                String script = "javascript:LoadSearchGrid('" + SearchTitle + "','" + SearchFor + "','" + HiddenColumns + "'," + MultipleSelect.ToString().ToLower() + ",'" + Selected_VID + "'," + WWidth + ",'" + MustSelectedVids + "');";
                if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("clientScript"))
                {
                    page.ClientScript.RegisterStartupScript(typeof(StaticInfo), "clientScript", script, true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void SearchItem(IList List, String SearchTitle, String SearchFor, String HiddenColumns, bool MultipleSelect, String Selected_VID, int WWidth)
        {
            try
            {
                System.Web.HttpContext.Current.Session[GlobalSearchType] = null;
                SearchItem(List, SearchTitle, SearchFor, HiddenColumns, MultipleSelect, Selected_VID, WWidth, String.Empty);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void SearchItem(IList List, String SearchTitle, String SearchFor, IList columnConfigList, bool MultipleSelect, String Selected_VID)
        {
            try
            {
                System.Web.HttpContext.Current.Session[GlobalSearchType] = null;
                System.Web.HttpContext.Current.Session[SearchColumnConfigSessionVarName] = columnConfigList;
                SearchItem(List, SearchTitle, SearchFor, String.Empty, MultipleSelect, Selected_VID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void SearchItem(IList List, String SearchTitle, String SearchFor, IList columnConfigList, bool MultipleSelect, String Selected_VID, int WWidth, String MustSelectedVids)
        {
            try
            {
                System.Web.HttpContext.Current.Session[GlobalSearchType] = null;
                System.Web.HttpContext.Current.Session[SearchColumnConfigSessionVarName] = columnConfigList;
                SearchItem(List, SearchTitle, SearchFor, String.Empty, MultipleSelect, Selected_VID, WWidth, MustSelectedVids);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void RegisterClientScript(String script)
        {
            try
            {
                RegisterClientScript(script, "clientScript");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void RegisterClientScript(String script, String scriptKey)
        {
            try
            {
                System.Web.UI.Page page = System.Web.HttpContext.Current.CurrentHandler as System.Web.UI.Page;

                if (!page.ClientScript.IsStartupScriptRegistered(scriptKey))
                {
                    page.ClientScript.RegisterStartupScript(typeof(StaticInfo), scriptKey, script, true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public static string getImageUrl(int option)
        //{
        //    switch (option)
        //    {
        //        case 1:
        //            return "/images/green-icon1.jpg";
        //        case 2:
        //            return "/images/yellow-icon1.jpg";
        //        case 3:
        //            return "/images/red-icon1.jpg";
        //        case 4:
        //            return "/images/orange-icon1.jpg";
        //        case 5:
        //            return "/images/grey-icon1.jpg";
        //        default:
        //            return "";
        //    }
        //}

        public static int GetEnumValue(Type enumType, String value)
        {
            if (value == "Integer")
                value = "Int32";
            else if (value == "Float")
                value = "Double";
            int i = -1;
            i = (int)Enum.Parse(enumType, value);
            return i;
        }
    }
}
