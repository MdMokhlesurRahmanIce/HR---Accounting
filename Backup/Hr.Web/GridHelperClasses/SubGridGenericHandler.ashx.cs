using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using ASL.DATA;
using System.ComponentModel;
using System.Globalization;
using ASL.STATIC;
using System.Linq;

namespace Hr.Web.GridHelperClasses
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SubGridGenericHandler : IHttpHandler, IRequiresSessionState
    {
        private static DataTable SourceTable { get; set; }
        private int TotalRows { get; set; }
        private int Totalpages { get; set; }
        private int CurrentPage { get; set; }
        private int PageRecords { get; set; }
        private Boolean DataSourceSorted { get; set; }
        private String SessionVarName { get; set; }
        private String UserDataString { get; set; }
        private String AggregateColumn { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                SessionVarName = context.Request.QueryString["SessionVarName"];

                AggregateColumn = context.Request.QueryString["AggregateColumn"];
                if (AggregateColumn.IsNullOrEmpty())
                    AggregateColumn = String.Empty;

                UserDataString = context.Request.QueryString["FooterRowCaption"];
                if (UserDataString.IsNullOrEmpty())
                    UserDataString = String.Empty;

                GetFilterList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetFilterList()
        {
            try
            {
                IEnumerable retrievedData = (IEnumerable)HttpContext.Current.Session[SessionVarName];
                CustomList<BaseItem> retrievedDataList = retrievedData.ToCustomList<BaseItem>();
                String expression = String.Empty;
                foreach (String colName in HttpContext.Current.Request.QueryString)
                {
                    if (colName != "SessionVarName" && colName != "rows"
                        && colName != "page" && colName != "sidx"
                        && colName != "sord" && colName != "_search"
                        && colName != "nd" && colName != "nd_" && colName != "id"
                        && colName != "AggregateColumn" && colName != "FooterRowCaption")
                    {
                        String colValue = HttpContext.Current.Request.QueryString[colName];
                        if (!String.IsNullOrEmpty(expression))
                            expression += " And ";
                        //
                        expression += MakePredicateString(colName, colValue);
                    }
                }

                if (!String.IsNullOrEmpty(expression))
                    retrievedDataList = retrievedDataList.FindAll(PredicateBuilder.Build<BaseItem>(expression));
                //
                PerformRequestData(retrievedDataList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private String MakePredicateString(String colName, String colValue)
        {
            try
            {

                String[] colArray = colName.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (colArray.Length == 2)
                {
                    if (colArray[1] == "DateTime" || colArray[1] == "System.DateTime")
                        return "Convert.ToDateTime(item.GetType().GetProperty($" + colArray[0] + "$).GetValue(item, null)) == DateTime.ParseExact($" + colValue + "$, $" + StaticInfo.GridDateFormat + "$, System.Globalization.CultureInfo.InvariantCulture)";
                    else
                        return "item.GetType().GetProperty($" + colName + "$).GetValue(item, null).ToString() == $" + colValue + "$";
                }
                else
                    return "item.GetType().GetProperty($" + colName + "$).GetValue(item, null).ToString() == $" + colValue + "$";
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void LoadUserData()
        {
            try
            {
                var strColumn = AggregateColumn.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (DataColumn dc in SourceTable.Columns)
                {
                    if (dc.DataType != typeof(String) && dc.DataType != typeof(DateTime) && dc.DataType != typeof(Boolean))
                    {
                        try
                        {
                            String strColumnWith_Agg_Type = strColumn.Find(item => item.Contains("[" + dc.ColumnName + "]:"));
                            if (strColumnWith_Agg_Type.IsNotNullOrEmpty())
                            {
                                String[] arrColumnWith_Agg_Type = strColumnWith_Agg_Type.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                if (arrColumnWith_Agg_Type[0].ToUpper() == "[" + dc.ColumnName.ToUpper() + "]")
                                {
                                    Object val = SourceTable.Compute(arrColumnWith_Agg_Type[1] + "(" + dc.ColumnName + ")", String.Empty);
                                    if (UserDataString.IsNotNullOrEmpty())
                                        UserDataString += String.Format(",\"{0}\":\"{1}\"", dc.ColumnName, val);
                                    else
                                        UserDataString += String.Format("\"{0}\":\"{1}\"", dc.ColumnName, val);
                                }
                            }
                        }
                        catch
                        {
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void PerformRequestData(IEnumerable retrievedData)
        {
            try
            {
                String pagerString = String.Empty;
                String rowData = String.Empty;

                rowData = LoadStringData(retrievedData);

                pagerString = "{";
                pagerString += "totalpages: '" + Totalpages + "', ";
                pagerString += "currentpage: '" + CurrentPage + "', ";
                pagerString += "pagerecords: '" + PageRecords + "',";
                pagerString += "rows: ";
                pagerString += rowData;
                LoadUserData();
                if (UserDataString.IsNotNullOrEmpty())
                {
                    pagerString += String.Format(",\"userdata\":");
                    pagerString += "{";
                    pagerString += String.Format("{0}", UserDataString);
                    pagerString += "}";
                }
                pagerString += "}";
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/javascript";
                HttpContext.Current.Response.Write(pagerString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private String LoadStringData(IEnumerable retrievedData)
        {
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Request.QueryString["rows"]);
                int num2 = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
                String expression = HttpContext.Current.Request.QueryString["sidx"];
                String direction = HttpContext.Current.Request.QueryString["sord"];
                String search = HttpContext.Current.Request.QueryString["_search"];

                DataView defaultView = ObtainDataTableFromIEnumerable(retrievedData).DefaultView;
                PerformSearch(defaultView, search);

                if (!DataSourceSorted)
                {
                    PerformSort(defaultView, expression, direction);
                }
                else
                {
                    new GridSort(expression, direction);
                }

                SourceTable = defaultView.ToTable();
                TotalRows = 0;
                int num3 = (TotalRows > 0) ? TotalRows : SourceTable.Rows.Count;
                int num4 = (num3 > 0) ? Convert.ToInt32((int)(num3 / num)) : 1;
                if ((num3 % num) != 0)
                {
                    num4++;
                }
                int startIndex = (num2 * num) - num;
                int endIndex = (num3 > (num2 * num)) ? (startIndex + num) : num3;
                int num7 = (num3 > (num2 * num)) ? num : (endIndex - startIndex);
                if (TotalRows > 0)
                {
                    startIndex = 0;
                    endIndex = SourceTable.Rows.Count;
                }
                StringBuilder jsonString = new StringBuilder();
                jsonString.Append("[");
                for (int i = startIndex; i < endIndex; i++)
                {
                    jsonString.Append("{");
                    foreach (DataColumn dc in SourceTable.Columns)
                    {
                        if (dc.DataType == typeof(DateTime) && dc.ExtendedProperties.Count.IsNotZero() && SourceTable.Rows[i][dc.Ordinal] != DBNull.Value)
                        {
                            try
                            {
                                String dateValue = SourceTable.Rows[i][dc.Ordinal].ToString().Equals(String.Empty) ? String.Empty : Convert.ToDateTime(SourceTable.Rows[i][dc.Ordinal]).ToString(dc.ExtendedProperties["DateFormat"].ToString());
                                jsonString.AppendFormat("\"{0}\":\"{1}\",", dc.ColumnName, dateValue);
                            }
                            catch
                            {
                                jsonString.AppendFormat("\"{0}\":\"{1}\",", dc.ColumnName, SourceTable.Rows[i][dc.Ordinal].ToString());
                            };
                        }
                        else
                        {
                            //jsonString.AppendFormat("\"{0}\":\"{1}\",", dc.ColumnName, SourceTable.Rows[i][dc.Ordinal].ToString().Replace("\"", "''"));
                            jsonString.AppendFormat("\"{0}\":\"{1}\",", dc.ColumnName, SourceTable.Rows[i][dc.Ordinal].ToString().Replace("\"", "\\\"").Replace("\r", " ").Replace("\n", " "));
                        }
                    }
                    jsonString.Append("}");
                    jsonString.Replace(",}", "},");
                }
                jsonString.Append("]");
                jsonString.Replace(",]", "]");

                CurrentPage = num2;
                PageRecords = num3;
                Totalpages = num4;

                return jsonString.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private DataTable ObtainDataTableFromIEnumerable(IEnumerable ien)
        {
            try
            {
                //Referencing "column" variable
                DataColumn column = null;

                //Creating a list of "DataColumn" to hold the primary key columns of the table
                List<DataColumn> keys = new List<DataColumn>();

                IEnumerable tempien = (IEnumerable)HttpContext.Current.Session[SessionVarName];

                Type actualType = tempien.GetType();
                if (actualType == typeof(Object))
                    throw new System.ArgumentException("Object is not a CustomList<T> or List<T> instance.", "Obj");

                Type itemType = actualType.GetGenericArguments()[0];
                //PropertyInfo[] properties = itemType.GetProperties();

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(itemType);

                DataTable table = new DataTable();
                foreach (PropertyDescriptor info in properties)
                {
                    if (info.IsBrowsable.IsFalse() && info.Name.NotEquals("VID")) continue;
                    Type propertyType = info.PropertyType;

                    CustomAttributes.FormatString attribs = (CustomAttributes.FormatString)info.Attributes[typeof(CustomAttributes.FormatString)];

                    //Getting "IsPrimary" custom attribute of the property
                    //Object[] attribs = info.GetCustomAttributes(typeof(CustomAttributes.IsPrimaryAttribute), false);

                    //Getting "FormatString" custom attribute of the property
                    //Object[] attribs = info.GetCustomAttributes(typeof(CustomAttributes.FormatString), false);

                    if (propertyType.IsGenericType && (propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        propertyType = Nullable.GetUnderlyingType(propertyType);
                    }

                    //Line commented
                    //table.Columns.Add(info.Name, propertyType);

                    //Creating a new column and adding it to the table
                    column = new DataColumn(info.Name, propertyType);
                    table.Columns.Add(column);

                    //If "IsPrimary" custom attribute of the property is true, then adding the column to the "keys" list
                    //if ((attribs.Length > 0) && ((CustomAttributes.IsPrimaryAttribute)attribs[0]).IsPrimary)
                    //{
                    //    keys.Add(column);
                    //}

                    //If "FormatString" custom attribute of the property is true, then adding the column to the "Expression"
                    if ((attribs.IsNotNull()) && attribs.Format.IsNotNullOrEmpty())
                    {
                        column.ExtendedProperties.Add("DateFormat", attribs.Format);
                    }
                }

                foreach (Object obj2 in ien)
                {
                    if (((BaseItem)obj2).IsDeleted) continue;

                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor info2 in properties)
                    {
                        if (info2.IsBrowsable.IsFalse() && info2.Name.NotEquals("VID")) continue;
                        Object obj3 = info2.GetValue(obj2);
                        if (obj3.IsNotNull())
                        {
                            if (info2.PropertyType == typeof(DateTime))
                            {
                                row[info2.Name] = obj3.Equals(DateTime.MinValue) ? DBNull.Value : obj3;
                            }
                            else
                                row[info2.Name] = obj3;
                        }
                        else
                        {
                            row[info2.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }

                try
                {
                    //Setting Primary Key of the table
                    table.PrimaryKey = keys.ToArray();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PerformSearch(DataView view, String search)
        {
            try
            {
                if (!String.IsNullOrEmpty(search) && Convert.ToBoolean(search))
                {
                    String text = HttpContext.Current.Request.QueryString["filters"];
                    String text2 = HttpContext.Current.Request.QueryString["searchField"];
                    String searchString = HttpContext.Current.Request.QueryString["searchString"];
                    String searchOperation = HttpContext.Current.Request.QueryString["searchOper"];
                    if (String.IsNullOrEmpty(text) && !String.IsNullOrEmpty(text2))
                    {
                        new Searching(text2, searchString, searchOperation).PerformSearch(view, search);
                    }
                    else if (!String.IsNullOrEmpty(text))
                    {
                        new MultipleSearching(text).PerformSearch(view);
                    }
                    //else if (this.ToolBarSettings.ShowSearchToolBar)
                    //{
                    //    new ToolBarSearching(this).PerformSearch(view, false);
                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PerformSort(DataView view, String expression, String direction)
        {
            try
            {
                if (!String.IsNullOrEmpty(expression))
                {
                    GridSort e = new GridSort(expression, direction);

                    view.Sort = String.Format("{0} {1}", expression, direction);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
