using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using ASL.DATA;
using System.Collections.Generic;
using ASL.STATIC;
using ASL.Web.Framework;
using ASL.Hr.DAO;

namespace Hr.Web.GridHelperClasses
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SearchGridHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //empcode
            String mode = context.Request.QueryString["SearchMode"];

            if (mode == "_SearchByEmpCode")
            {
                String empCode = context.Request.QueryString["empCode"];
                context.Session[StaticInfo.SearchSessionVarName] = getEmpByCode(empCode);
            }

            IEnumerable retrievedData = (IEnumerable)context.Session[StaticInfo.SearchSessionVarName];
            if (retrievedData.IsNull()) return;

            if (mode.IsNullOrEmpty() || mode.Equals("Load"))
            {
                String columnString = String.Empty;
                columnString = GetGridColumn(retrievedData);
                context.Response.ContentType = "text/plain";
                context.Response.Write(columnString);
            }
            else
            {
                String MultiSelect = HttpContext.Current.Request.QueryString["MultiSelect"];
                String[] vids = context.Request.QueryString["SelectedVids"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                CustomList<BaseItem> retrievedDataList = retrievedData.ToCustomList<BaseItem>();
                retrievedDataList = retrievedDataList.FindAll(p => vids.Contains(p.VID.ToString()));
                if (MultiSelect.IsNullOrEmpty() || MultiSelect.ToBoolean().IsFalse())
                {
                    context.Session[ASL.STATIC.StaticInfo.SearchSessionVarName] = retrievedDataList.Count.IsZero() ? null : retrievedDataList[0];
                }
                else
                    context.Session[ASL.STATIC.StaticInfo.SearchSessionVarName] = retrievedDataList;

                if (retrievedDataList.Count > 0)
                {
                    try
                    {
                        if (retrievedDataList[0].GetType().GetProperty("EmpKey") != null)
                        {
                            context.Response.ContentType = "text/plain";
                            context.Response.Write(retrievedDataList[0].GetType().GetProperty("EmpKey").GetValue(retrievedDataList[0], null).ToString() == "0" ? 0 : 1);
                        }
                    }
                    finally
                    {
                    }
                }
            }
        }

        private CustomList<HRM_Emp> getEmpByCode(string empCode)
        {
            HRM_Emp searchEmp = HRM_Emp.GetEmployeeServiceInformation(empCode);
            CustomList<HRM_Emp> _list = new CustomList<HRM_Emp>();
            _list.Add(searchEmp);

            return _list;
        }

        public Boolean IsReusable
        {
            get
            {
                return false;
            }
        }
        private String GetGridColumn(IEnumerable retrievedData)
        {
            try
            {

                String HideColumns = HttpContext.Current.Request.QueryString["HideColumns"];
                if (HideColumns.IsNullOrEmpty()) HideColumns = String.Empty;
                String[] arrayColumn = HideColumns.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Type actualType = retrievedData.GetType();
                if (actualType == typeof(Object))
                    throw new System.ArgumentException("Object is not a CustomList<T> or List<T> instance.", "Obj");

                Type objectType = actualType.GetGenericArguments()[0];
                String columnsCaption = "VID,";
                StringBuilder tempCols = new StringBuilder();
                StringBuilder columnsString = new StringBuilder();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(objectType);
                List<ASL.Web.Framework.SearchColumnConfig> congigList = (List<ASL.Web.Framework.SearchColumnConfig>)HttpContext.Current.Session[StaticInfo.SearchColumnConfigSessionVarName];

                String caption = String.Empty;
                tempCols.Append("{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' }@ ");
                foreach (PropertyDescriptor propDes in properties)
                {
                    caption = propDes.DisplayName;
                    if (congigList.IsNotNull() && congigList.Count.IsNotZero())
                    {
                        ASL.Web.Framework.SearchColumnConfig config = congigList.Find(item => item.ColumnName == propDes.Name);
                        if (config.IsNotNull())
                        {
                            if (config.Hiden) continue;
                            caption = config.Caption;
                        }
                    }
                    if (arrayColumn.Contains(propDes.Name, new StringEqualityComparer())) continue;
                    if (propDes.IsBrowsable.IsFalse()) continue;
                    if (propDes.PropertyType == typeof(DateTime))
                        tempCols.Append("{ 'name': '" + propDes.Name + "', 'index': '" + propDes.Name + "', 'width': 50, searchoptions: {dataInit:datePick, sopt: ['eq','ne','lt','le','gt','ge','in','ni'] }}@ ");
                    else
                        tempCols.Append("{ 'name': '" + propDes.Name + "', 'index': '" + propDes.Name + "', 'width': 50, searchoptions: { sopt: ['cn','bw','ew','eq','ne','lt','le','gt','ge','bn','in','ni','en','nc'] }}@ ");

                    columnsCaption += String.Format("{0},", caption);
                }
                columnsCaption += "]";
                columnsCaption = columnsCaption.Replace(",]", " | ");

                tempCols.Append("]");

                columnsString.Append(columnsCaption);
                columnsString.Append(tempCols.ToString().Replace("@ ]", ""));

                //Dispose the variable from session
                HttpContext.Current.Session[StaticInfo.SearchColumnConfigSessionVarName] = null;
                HttpContext.Current.Session.Remove(StaticInfo.SearchColumnConfigSessionVarName);

                return columnsString.ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
