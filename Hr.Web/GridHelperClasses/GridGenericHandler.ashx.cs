using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using ASL.DATA;
using System.Linq;

namespace Hr.Web.GridHelperClasses
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GridGenericHandler : IHttpHandler, IRequiresSessionState
    {
        private static DataTable SourceTable { get; set; }
        private Boolean CallModeResolved { get; set; }
        private int TotalRows { get; set; }
        private int Totalpages { get; set; }
        private int CurrentPage { get; set; }
        private int PageRecords { get; set; }
        private Boolean DataSourceSorted { get; set; }
        private String SessionVarName { get; set; }
        private String UserDataString { get; set; }
        /// <summary>
        /// this variable
        /// </summary>
        private String AggregateColumn { get; set; }

        private CallBackMode callBackMode;
        public CallBackMode AjaxCallBackMode
        {
            get
            {
                if (CallModeResolved.IsFalse())
                {
                    ResolveCallBackMode();
                }
                return callBackMode;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                SessionVarName = context.Request.QueryString["SessionVarName"];
                IEnumerable retrievedData = (IEnumerable)context.Session[SessionVarName];
                if (retrievedData.IsNull()) return;

                AggregateColumn = context.Request.QueryString["AggregateColumn"];
                if (AggregateColumn.IsNullOrEmpty())
                    AggregateColumn = String.Empty;

                UserDataString = context.Request.QueryString["FooterRowCaption"];
                if (UserDataString.IsNullOrEmpty())
                    UserDataString = String.Empty;

                String vid_Ref = context.Request.QueryString["vid_Ref"];
                String parentColumnName = context.Request.QueryString["ParentColumnName"];
                String parentColumnValue = context.Request.QueryString["ParentColumnValue"];

                if (vid_Ref.IsNotNullOrEmpty() && vid_Ref.NotEquals("null"))
                {
                    filterRetrievedData(ref retrievedData, vid_Ref);
                    OnDataSourceViewSelectCallback(retrievedData);
                }
                else if (parentColumnName.IsNotNullOrEmpty() && parentColumnValue.IsNotNullOrEmpty())
                    filterRetrievedDataDataSourceView(retrievedData, parentColumnName, parentColumnValue);
                else
                    OnDataSourceViewSelectCallback(retrievedData);

            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
        private void filterRetrievedDataDataSourceView(IEnumerable retrievedData, String parentColumnName, String parentColumnValue)
        {
            try
            {
                CustomList<BaseItem> retrievedDataList = retrievedData.ToCustomList<BaseItem>();
                retrievedDataList = retrievedDataList.FindAll(p => p.GetType().GetProperty(parentColumnName).GetValue(p, null).ToString() == parentColumnValue);
                OnDataSourceViewSelectCallback(retrievedDataList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void filterRetrievedData(ref IEnumerable retrievedData, string vid_Ref)
        {
            try
            {
                String SessionVarName_Ref = HttpContext.Current.Request.QueryString["SessionVarName_Ref"];
                String filterCol_Ref = HttpContext.Current.Request.QueryString["filterCol_Ref"];
                String filterCol = HttpContext.Current.Request.QueryString["filterCol"];

                if ((SessionVarName_Ref.IsNull()) || filterCol_Ref.IsNull() || filterCol.IsNull())
                {
                    throw new Exception("Arguments are not specified.");
                }

                IEnumerable refData = (IEnumerable)HttpContext.Current.Session[SessionVarName_Ref];
                CustomList<BaseItem> refDataList = refData.ToCustomList<BaseItem>();


                BaseItem refRow = refDataList.Find(p => p.VID == vid_Ref.ToInt());

                if ((refRow.IsNull()) || (refRow.State == ItemState.Detached))
                {
                    foreach (Object item in retrievedData)
                    {
                        ((BaseItem)item).Delete();
                    }
                }
                else
                {
                    Object refColValue = refRow.GetType().GetProperty(filterCol_Ref).GetValue(refRow, null);

                    if (refColValue.IsNotNull())
                    {
                        CustomList<BaseItem> retrievedDataList = retrievedData.ToCustomList<BaseItem>();
                        CustomList<BaseItem> retrievedDataListTmp = null;
                        retrievedDataListTmp = retrievedDataList.FindAll(p => p.GetType().GetProperty(filterCol).GetValue(p, null).ToString() == refColValue.ToString());

                        foreach (BaseItem item in retrievedData)
                        {
                            //retrievedDataListTmp.Find(p => p.VID != item.VID).Delete();
                            BaseItem obj = retrievedDataListTmp.Find(p => p.VID == item.VID);
                            if (obj.IsNull()) item.Delete();
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("Error occured while filtering retrieved data.");
            }
        }

        private void ResolveCallBackMode()
        {
            try
            {
                CallModeResolved = true;
                if (IsGridRequest())
                {
                    String str4;
                    String str = HttpContext.Current.Request.Form["oper"];
                    String str2 = HttpContext.Current.Request.QueryString["editMode"];
                    String str3 = HttpContext.Current.Request.QueryString["_search"];

                    String str5 = HttpContext.Current.Request.QueryString["addDummyRecord"];
                    if (str5 == "true")
                    {
                        callBackMode = CallBackMode.AddDummyRecord;
                        return;
                    }
                    String str6 = HttpContext.Current.Request.QueryString["editbyforce"];
                    if (str6 == "true")
                    {
                        callBackMode = CallBackMode.EditByForce;
                        return;
                    }

                    callBackMode = CallBackMode.RequestData;
                    if (str.IsNotNullOrEmpty() && ((str4 = str).IsNotNull()))
                    {
                        if (str4 == "add")
                        {
                            callBackMode = CallBackMode.AddRow;
                            return;
                        }
                        if (str4 == "edit")
                        {
                            callBackMode = CallBackMode.EditRow;
                            return;
                        }
                        if (str4 == "del")
                        {
                            callBackMode = CallBackMode.DeleteRow;
                            return;
                        }
                    }
                    if (str2.IsNotNullOrEmpty())
                    {
                        callBackMode = CallBackMode.EditRow;
                    }
                    if (str3.IsNotNullOrEmpty() && str3.ToBoolean())
                    {
                        callBackMode = CallBackMode.Search;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Boolean IsGridRequest()
        {
            try
            {
                String str = HttpContext.Current.Request.QueryString["jqGridID"];
                return str.IsNotNullOrEmpty();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnDataSourceViewSelectCallback(IEnumerable retrievedData)
        {
            try
            {
                switch (AjaxCallBackMode)
                {
                    case CallBackMode.RequestData:
                    case CallBackMode.Search:
                        PerformRequestData(retrievedData);
                        return;

                    case CallBackMode.EditRow:
                        PerformRowEdit();
                        return;

                    case CallBackMode.AddRow:
                        PerformRowAdd();
                        return;

                    case CallBackMode.DeleteRow:
                        PerformRowDelete();
                        return;

                    case CallBackMode.AddDummyRecord:
                        PerformRowAddDummy();
                        return;
                    case CallBackMode.EditByForce:
                        PerformEditByForce();
                        return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

                String vid_Ref = HttpContext.Current.Request.QueryString["vid_Ref"];
                String NeedSetUncahage = HttpContext.Current.Request.QueryString["NeedSetUncahage"];
                if (NeedSetUncahage != "false")
                {
                    if (vid_Ref.IsNotNull())
                    {
                        foreach (BaseItem item in retrievedData)
                        {
                            item.SetUnchanged();
                        }
                    }
                }

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
        public Boolean IsReusable
        {
            get
            {
                return false;
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

                if (DataSourceSorted.IsFalse())
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
                        if (dc.DataType == typeof(DateTime) && dc.ExtendedProperties.Count != 0 && SourceTable.Rows[i][dc.Ordinal] != DBNull.Value)
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

        private void PerformSearch(DataView view, String search)
        {
            try
            {
                if (search.IsNotNullOrEmpty() && search.ToBoolean())
                {
                    String text = HttpContext.Current.Request.QueryString["filters"];
                    String text2 = HttpContext.Current.Request.QueryString["searchField"];
                    String searchString = HttpContext.Current.Request.QueryString["searchString"];
                    String searchOperation = HttpContext.Current.Request.QueryString["searchOper"];
                    if (text.IsNullOrEmpty() && text2.IsNotNullOrEmpty())
                    {
                        new Searching(text2, searchString, searchOperation).PerformSearch(view, search);
                    }
                    else if (text.IsNotNullOrEmpty())
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
                if (expression.IsNotNullOrEmpty())
                {
                    if (expression.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length != 1)
                        direction = String.Empty;

                    GridSort e = new GridSort(expression, direction);

                    view.Sort = String.Format("{0} {1}", expression, direction);

                }
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

        private String ObjectToJSONString(Object emplist)
        {
            //DataContractJsonSerializer serilizer = new DataContractJsonSerializer(emplist.GetType());
            //MemoryStream ms = new MemoryStream();
            //serilizer.WriteObject(ms, emplist);
            //return Encoding.Default.GetString(ms.ToArray());
            throw new NotImplementedException("this method is not implemented in GridGenericHandler.cs");
        }

        private void PerformRowEdit()
        {
            try
            {
                NameValueCollection values = new NameValueCollection();
                foreach (String str in HttpContext.Current.Request.Form.Keys)
                {
                    if (str.NotEquals("oper"))
                    {
                        values[str] = HttpContext.Current.Request.Form[str];
                    }
                }
                GridRowEdit e = new GridRowEdit
                {
                    RowData = values,
                    RowKey = values["id"]
                };
                String str3 = HttpContext.Current.Request.QueryString["parentRowID"];
                if (str3.IsNotNullOrEmpty())
                {
                    e.ParentRowKey = str3;
                }

                HandleUpdate(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void HandleUpdate(GridRowEdit e)
        {
            try
            {
                IEnumerable retrievedData = (IEnumerable)HttpContext.Current.Session[SessionVarName];
                foreach (Object obj in retrievedData)
                {
                    if (((BaseItem)obj).VID == e.RowKey.ToInt())
                    {
                        foreach (String key in e.RowData.AllKeys)
                        {
                            if (key.Equals("id")) continue;
                            PropertyInfo property = obj.GetType().GetProperty(key);
                            if (property.IsNull()) continue;
                            String format = String.Empty;
                            Object[] attribs = property.GetCustomAttributes(typeof(CustomAttributes.FormatString), false);
                            if ((attribs.Length > 0) && ((CustomAttributes.FormatString)attribs[0]).Format.IsNotNullOrEmpty())
                            {
                                format = ((CustomAttributes.FormatString)attribs[0]).Format;
                            }

                            Object value = GetActualValueFromGridRow(property.PropertyType.ToString(), e.RowData[key], format);
                            property.SetValue(obj, value, null);
                        }
                        if (((BaseItem)obj).State == ItemState.Detached)
                            ((BaseItem)obj).SetAdded();

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Object GetActualValueFromGridRow(String dataType, String value)
        {
            return GetActualValueFromGridRow(dataType, value, String.Empty);
        }
        public Object GetActualValueFromGridRow(String dataType, String value, String format)
        {
            try
            {
                switch (dataType)
                {
                    case "System.DateTime":
                        if (value.IsNullOrEmpty()) return DateTime.MinValue;
                        if (format.IsNotNullOrEmpty())
                        {
                            CultureInfo provider = CultureInfo.InvariantCulture;
                            return DateTime.ParseExact(value, format, provider);
                        }
                        else
                            return DateTime.Parse(value);
                    case "System.Decimal":
                        return Decimal.Parse(value.IfEmptyThenZero());
                    case "System.Int16":
                        return Int16.Parse(value.IfEmptyThenZero());
                    case "System.Int32":
                        return Int32.Parse(value.IfEmptyThenZero());
                    case "System.Int64":
                        return Int64.Parse(value.IfEmptyThenZero());
                    case "System.Double":
                        return Double.Parse(value.IfEmptyThenZero());
                    case "System.Boolean":
                        //The following checkings are needed as JqGrid check box re
                        if (value.ToString().ToLower().Equals("no"))
                            return false;
                        else if (value.ToString().ToLower().Equals("yes"))
                            return true;
                        else if (value.ToString().ToLower().Equals("0"))
                            return false;
                        else if (value.ToString().ToLower().Equals("1"))
                            return true;
                        else if (value.ToString().ToLower().Equals("off"))
                            return false;
                        else if (value.ToString().ToLower().Equals("on"))
                            return true;
                        else return Boolean.Parse(value);
                    default:
                        return value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PerformRowAddDummy()
        {
            try
            {
                NameValueCollection values = new NameValueCollection();
                foreach (String str in HttpContext.Current.Request.QueryString.Keys)
                {
                    if (str.NotEquals("oper") && str.NotEquals("SessionVarName")
                        && str.NotEquals("addDummyRecord")
                        && str.NotEquals("jqGridID"))
                    {
                        values[str] = HttpContext.Current.Request.QueryString[str];
                    }
                }
                GridRowAdd e = new GridRowAdd
                {
                    RowData = values,
                };

                IList retrievedData = (IList)HttpContext.Current.Session[SessionVarName];

                Type actualType = retrievedData.GetType();

                if (actualType == typeof(Object))
                    throw new System.ArgumentException("Object is not a CustomList<T> or List<T> instance.", "Obj");

                Type itemType = actualType.GetGenericArguments()[0];

                Object newItem = Activator.CreateInstance(itemType);

                foreach (String key in e.RowData.AllKeys)
                {
                    if (key.Equals("id")) continue;
                    PropertyInfo property = newItem.GetType().GetProperty(key);

                    if (property.IsNull()) continue;
                    String format = String.Empty;
                    Object[] attribs = property.GetCustomAttributes(typeof(CustomAttributes.FormatString), false);
                    if ((attribs.Length > 0) && ((CustomAttributes.FormatString)attribs[0]).Format.IsNotNullOrEmpty())
                    {
                        format = ((CustomAttributes.FormatString)attribs[0]).Format;
                    }
                    Object value = GetActualValueFromGridRow(property.PropertyType.ToString(), e.RowData[key], format);
                    property.SetValue(newItem, value, null);
                }
                try
                {
                    ((BaseItem)newItem).SetDetached();
                    retrievedData.Add(newItem);
                }
                catch
                {
                    throw new Exception("No record found!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PerformRowAdd()
        {
            try
            {
                NameValueCollection values = new NameValueCollection();
                foreach (String text in HttpContext.Current.Request.Form.Keys)
                {
                    values[text] = HttpContext.Current.Request.Form[text];
                }
                GridRowAdd e = new GridRowAdd();
                e.RowData = values;
                //String text2 = HttpContext.Current.Request.QueryString["parentRowID"];
                //if (!String.IsNullOrEmpty(text2))
                //{
                //    e.ParentRowKey = text2;
                //}

                Hashtable parentKeys = new Hashtable();
                foreach (String key in HttpContext.Current.Request.QueryString.Keys)
                {
                    if (key.NotEquals("jqGridID") && key.NotEquals("editMode") && key.NotEquals("SessionVarName"))
                        parentKeys.Add(key, HttpContext.Current.Request.QueryString[key]);
                }
                e.ParentRowKeys = parentKeys;
                HandleInsert(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void HandleInsert(GridRowAdd e)
        {
            try
            {
                IList retrievedData = (IList)HttpContext.Current.Session[SessionVarName];

                Type actualType = retrievedData.GetType();

                //Commented - Not checking whethere the object "actualType" is a List/CustomList type or not. It is assumed that
                //this object is always List/CustomList type.

                //Type genericType = typeof(CustomList<>);

                //while ((actualType != typeof(object)) && !(actualType.IsGenericType && (actualType.GetGenericTypeDefinition() == genericType)))
                //{
                //    actualType = actualType.BaseType;
                //}

                if (actualType == typeof(object))
                    throw new System.ArgumentException("Object is not a CustomList<T> or List<T> instance.", "Obj");

                Type itemType = actualType.GetGenericArguments()[0];

                Object newItem = Activator.CreateInstance(itemType);

                try
                {
                    retrievedData.Add(newItem);
                }
                catch
                {
                    throw new Exception("No record found!");
                }

                try
                {
                    String celValue = String.Empty;
                    foreach (String key in e.RowData.AllKeys)
                    {
                        if (key.Equals("oper")) continue;
                        PropertyInfo property = newItem.GetType().GetProperty(key);
                        if (property.IsNull()) continue;

                        if (e.ParentRowKeys.Contains(key))
                            celValue = e.ParentRowKeys[key].ToString();
                        else
                            celValue = e.RowData[key];

                        String format = String.Empty;
                        Object[] attribs = property.GetCustomAttributes(typeof(CustomAttributes.FormatString), false);
                        if ((attribs.Length > 0) && ((CustomAttributes.FormatString)attribs[0]).Format.IsNotNullOrEmpty())
                        {
                            format = ((CustomAttributes.FormatString)attribs[0]).Format;
                        }

                        Object value = GetActualValueFromGridRow(property.PropertyType.ToString(), celValue, format);
                        property.SetValue(newItem, value, null);
                    }
                }
                catch
                {
                    throw new Exception("Error occured while assigning new value into object");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PerformRowDelete()
        {
            try
            {
                NameValueCollection values = new NameValueCollection();
                foreach (String text in HttpContext.Current.Request.Form.Keys)
                {
                    values[text] = HttpContext.Current.Request.Form[text];
                }
                GridRowDelete e = new GridRowDelete();
                e.RowKey = values["id"];

                HandleDelete(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void HandleDelete(GridRowDelete e)
        {
            try
            {
                IEnumerable retrievedData = (IEnumerable)HttpContext.Current.Session[SessionVarName];
                foreach (Object obj in retrievedData)
                {
                    if (((BaseItem)obj).VID == e.RowKey.ToInt())
                    {
                        ((BaseItem)obj).Delete();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PerformEditByForce()
        {
            try
            {
                NameValueCollection values = new NameValueCollection();
                foreach (String str in HttpContext.Current.Request.QueryString.Keys)
                {
                    if (str.NotEquals("oper") && str.NotEquals("SessionVarName")
                        && str.NotEquals("editbyforce")
                        && str.NotEquals("jqGridID"))
                    {
                        values[str] = HttpContext.Current.Request.QueryString[str];
                    }
                }
                GridRowEdit e = new GridRowEdit
                {
                    RowData = values,
                    RowKey = values["id"]
                };


                IEnumerable retrievedData = (IEnumerable)HttpContext.Current.Session[SessionVarName];
                foreach (Object obj in retrievedData)
                {

                    if (((BaseItem)obj).VID == e.RowKey.ToInt())
                    {
                        foreach (String key in e.RowData.AllKeys)
                        {
                            if (key.Equals("id")) continue;
                            PropertyInfo property = obj.GetType().GetProperty(key);
                            if (property.IsNull()) continue;

                            String format = String.Empty;
                            Object[] attribs = property.GetCustomAttributes(typeof(CustomAttributes.FormatString), false);
                            if ((attribs.Length > 0) && ((CustomAttributes.FormatString)attribs[0]).Format.IsNotNullOrEmpty())
                            {
                                format = ((CustomAttributes.FormatString)attribs[0]).Format;
                            }

                            Object value = GetActualValueFromGridRow(property.PropertyType.ToString(), e.RowData[key], format);
                            property.SetValue(obj, value, null);
                        }
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
