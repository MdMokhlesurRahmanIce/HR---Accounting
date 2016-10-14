using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web;
using System.Xml;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using Microsoft.Reporting.WebForms;


namespace ReportSuite.DAO
{
    public class RDLReportDocument
    {
        public RDLReportDocument()
        {
        }
        public RDLReportDocument(String name)
        {
            Name = name;
            dsreport = new RDLDataSet();
            dssource = new DataSet();
            parameters = new List<RDLParameter>();
            fields = new List<RDLColumn>();
            bodyTablesName = new List<String>();
            filterSetList = new CustomList<FilterSets>();
        }
        private XmlDocument xmlDocument = null;

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private String connectionString;
        public String ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        //
        private String reportPathWithOutName = String.Empty;
        public String ReportPathWithOutName
        {
            get { return reportPathWithOutName; }
            set { reportPathWithOutName = value; }
        }
        //
        private String reportPath;
        public String ReportPath
        {
            get { return reportPath; }
            set { reportPath = value; }
        }
        //
        private DataSet dssource;
        public DataSet dsSource
        {
            get { return dssource; }
            set { dssource = value; }
        }
        //
        private RDLDataSet dsreport;
        public RDLDataSet dsReport
        {
            get { return dsreport; }
            set { dsreport = value; }
        }
        private CustomList<FilterSets> filterSetList;
        public CustomList<FilterSets> FilterSetList
        {
            get { return filterSetList; }
            set { filterSetList = value; }
        }
        //
        private List<RDLParameter> parameters = null;
        public List<RDLParameter> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }
        //
        private List<RDLColumn> fields = null;
        public List<RDLColumn> Fields
        {
            get { return fields; }
            set { fields = value; }
        }
        //
        private List<String> bodyTablesName = null;
        public List<String> BodyTablesName
        {
            get { return bodyTablesName; }
            set { bodyTablesName = value; }
        }
        //
        private List<RDLReportDocument> SubReportList
        {
            get
            {
                if (HttpContext.Current.Session["ReportViewer_SubReportDocument"].IsNull())
                    HttpContext.Current.Session["ReportViewer_SubReportDocument"] = new List<RDLReportDocument>();
                //
                return (List<RDLReportDocument>)HttpContext.Current.Session["ReportViewer_SubReportDocument"];
            }
            set
            {
                HttpContext.Current.Session["ReportViewer_SubReportDocument"] = value;
            }
        }
        //
        public void LoadFilterTable(DataColumnCollection dcCollection)
        {
            filterSetList = new CustomList<FilterSets>();
            FilterSets newFilter;
            RDLColumn rc;
            foreach (RDLParameter rp in Parameters)
            {
                newFilter = new FilterSets();
                string[] items = rp.Name.Split('_');
                if (items.Length == 2)
                {
                    newFilter.ColumnName = items[0];
                    newFilter.Caption = "*";
                }
                else
                {
                    newFilter.ColumnName = rp.Name;
                }
                newFilter.DataType = rp.DbType.ToString();
                newFilter.TableName = "Parameter";
                newFilter.OrAnd = "And";
                newFilter.Operators = "=";
                //newFilter.Caption = "***";
                newFilter.IsParameter = true;
                filterSetList.Add(newFilter);

            }
            foreach (DataColumn dc in dcCollection)
            {
                rc = Fields.Find(item => item.Name == dc.ColumnName);
                if (rc.IsNotNull())
                {
                    if (filterSetList.Find(item => item.ColumnName == dc.ColumnName && (item.TableName == "Parameter" || item.TableName == rc.TableName)).IsNull())
                    {
                        newFilter = new FilterSets();
                        newFilter.ColumnName = rc.Name;
                        newFilter.DataType = rc.DataType;
                        newFilter.TableName = rc.TableName;
                        newFilter.OrAnd = "And";
                        newFilter.Operators = "=";
                        newFilter.IsParameter = false;
                        filterSetList.Add(newFilter);
                    }
                }
            }
            //foreach (String tableName in BodyTablesName)
            //{
            //    //Expression
            //    newFilter = new FilterSets();
            //    newFilter.ColumnName = "Expression";
            //    newFilter.DataType = "Expression";
            //    newFilter.TableName = tableName;
            //    newFilter.OrAnd = "And";
            //    newFilter.Operators = "=";
            //    newFilter.IsParameter = false;
            //    filterSetList.Add(newFilter);
            //}
        }
        //
        public void Load(String reportPath)
        {
            ReportPath = reportPath;
            LoadReportBodyTables();
            LoadReportDataSet();
            LoadReportParameters();
            LoadSubReportInfo();
        }

        private XmlNodeList GetCustomNodeList(String rdlcTagName)
        {
            try
            {
                if (xmlDocument.IsNull())
                {
                    xmlDocument = new XmlDocument();
                    try
                    {
                        xmlDocument.Load(ReportPath);
                    }
                    catch { }
                }

                XmlNodeList nodList = xmlDocument.GetElementsByTagName(rdlcTagName);
                return nodList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private XmlNodeList GetCustomNodeList(object rdlcSource)
        {
            try
            {
                if (xmlDocument.IsNull())
                {
                    xmlDocument = new XmlDocument();
                    try
                    {
                        xmlDocument.Load(this.ReportPath);
                    }
                    catch { }
                }

                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDocument.NameTable);
                nsManager.AddNamespace("ns", "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition");
                XmlNodeList nodList = xmlDocument.SelectNodes(rdlcSource.ToString(), nsManager);
                return nodList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void LoadReportBodyTables()
        {
            XmlNodeList xmlItems = GetCustomNodeList("DataSetName");
            foreach (XmlNode nod in xmlItems)
            {
                if (bodyTablesName.Contains(nod.InnerText).IsFalse())
                    bodyTablesName.Add(nod.InnerText);
            }
        }
        private void LoadSubReportInfo()
        {
            RDLReportDocument subRep;
            String reportName = String.Empty;
            XmlNodeList xmlItems = GetCustomNodeList("Subreport");
            foreach (XmlNode nod in xmlItems)
            {
                reportName = nod["ReportName"].InnerText;
                if (SubReportList.Find(item => item.Name == reportName).IsNull())
                {
                    subRep = new RDLReportDocument(reportName);
                    subRep.ReportPathWithOutName = reportPathWithOutName;
                    subRep.Load(String.Format(@"{0}\{1}.{2}", reportPathWithOutName, reportName, "rdlc"));
                    SubReportList.Add(subRep);
                }
            }

        }
        private void LoadReportDataSet()
        {
            try
            {
                dsreport.Tables.Clear();
                fields.Clear();
                XmlNodeList xmlDataSet = GetCustomNodeList("DataSet");
                XmlNodeList ndSearchList = null;
                RDLTable rtTable = null;
                RDLParameter sqlParam = null;
                RDLColumn ReportColumn = null;

                foreach (XmlNode xmlTable in xmlDataSet)
                {
                    rtTable = new RDLTable();
                    rtTable.TableName = xmlTable.Attributes["Name"].InnerText;
                    try
                    {
                        rtTable.CommandType = (CommandType)StaticInfo.GetEnumValue(typeof(CommandType), xmlTable["Query"]["CommandType"].InnerText);
                    }
                    catch { rtTable.CommandType = CommandType.Text; }
                    //
                    rtTable.CommandText = xmlTable["Query"]["CommandText"].InnerText;
                    //For Parameters
                    try
                    {
                        ndSearchList = xmlTable["Query"]["QueryParameters"].ChildNodes;
                    }
                    catch { ndSearchList = null; }
                    if (ndSearchList.IsNotNull())
                    {
                        foreach (XmlNode xmlParam in ndSearchList)
                        {
                            sqlParam = new RDLParameter();
                            sqlParam.Name = xmlParam.Attributes["Name"].InnerText;
                            sqlParam.Prompt = GetSQLParamField(xmlParam["Value"].InnerText).ToString();
                            rtTable.Parameters.Add(sqlParam);
                        }
                    }
                    //
                    //For Fields
                    try
                    {
                        ndSearchList = xmlTable["Fields"].ChildNodes;
                    }
                    catch { ndSearchList = null; }

                    if (ndSearchList.IsNotNull())
                    {
                        foreach (XmlNode xmlColumn in ndSearchList)
                        {
                            ReportColumn = new RDLColumn();
                            ReportColumn.TableName = rtTable.TableName;
                            ReportColumn.Name = xmlColumn.Attributes["Name"].Value;
                            try
                            {
                                ReportColumn.DataType = xmlColumn["rd:TypeName"].InnerText;
                            }
                            catch
                            {
                                ReportColumn.DataType = "System.Calculate";
                            }
                            //
                            rtTable.Columns.Add(ReportColumn);
                            if (bodyTablesName.Contains(rtTable.TableName))
                                fields.Add(ReportColumn);
                        }
                    }
                    //
                    dsreport.Tables.Add(rtTable);

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void LoadSourceDataSet(string empCode, ref DataTable dt)
        {
            DataSet dsTemp = new DataSet();
            dsSource = new DataSet();

            foreach (RDLTable rtTable in dsreport.Tables)
            {
                string search = "";
                foreach (RDLParameter param in rtTable.Parameters)
                {
                    FilterSets fSL = new FilterSets();
                    string[] items = param.Prompt.Split('_');
                    if (items.Length == 2)
                        fSL = filterSetList.Find(item => item.IsParameter && item.ColumnName == items[0]);
                    else
                        fSL = filterSetList.Find(item => item.IsParameter && item.ColumnName == param.Prompt);
                    //FilterSets fSL = filterSetList.Find(item => item.IsParameter);
                    if (param.Prompt == "EmpCode")
                        search += "@" + param.Prompt + "='" + empCode + "',";
                    else if (fSL.ColumnActualValue != "")
                        search += "@" + param.Prompt + "='" + fSL.ColumnActualValue + "',";
                    else if (fSL.ColumnActualValue == "" && fSL.ColumnValue != "")
                        search += "@" + param.Prompt + "='" + fSL.ColumnValue + "',";
                    //if ((items.Length == 2 && fSL.ColumnActualValue == "") && (items.Length == 2 && fSL.ColumnValue == ""))
                    //{
                    //    checkedRequiredField = items[0] + " is required.";
                    //    return;
                    //}
                }
                if (search != "")
                    search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;
                String sql = "EXEC " + rtTable.CommandText + " " + search + "";
                LoadReportSourceDataSet(ref dsTemp, sql);
                dsTemp.Tables[0].TableName = rtTable.TableName;
                //dsSource.Tables.Add(dsTemp.Tables[rtTable.TableName].Copy());
                dt = dsTemp.Tables[rtTable.TableName].Copy();
            }
        }

        public void LoadSourceDataSet(ref string checkedRequiredField, ref DataTable dt)
        {
            DataSet dsTemp = new DataSet();
            dsSource = new DataSet();

            foreach (RDLTable rtTable in dsreport.Tables)
            {
                string search = "";
                foreach (RDLParameter param in rtTable.Parameters)
                {
                    FilterSets fSL = new FilterSets();
                    string[] items = param.Prompt.Split('_');
                    if (items.Length == 2)
                        fSL = filterSetList.Find(item => item.IsParameter && item.ColumnName == items[0]);
                    else
                        fSL = filterSetList.Find(item => item.IsParameter && item.ColumnName == param.Prompt);
                    //FilterSets fSL = filterSetList.Find(item => item.IsParameter);
                    if (fSL.ColumnActualValue != "")
                        search += "@" + param.Prompt + "='" + fSL.ColumnActualValue + "',";
                    if (fSL.ColumnActualValue == "" && fSL.ColumnValue != "")
                        search += "@" + param.Prompt + "='" + fSL.ColumnValue + "',";
                    if ((items.Length == 2 && fSL.ColumnActualValue == "") && (items.Length == 2 && fSL.ColumnValue == ""))
                    {
                        checkedRequiredField = items[0] + " is required.";
                        return;
                    }
                    //if (items.Length == 2 && fSL.ColumnActualValue == "" && fSL.ColumnValue=="")
                    //{
                    //    checkedRequiredField = items[0] + " is required.";
                    //    return;
                    //}
                }
                if (search != "")
                    search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;
                String sql = "EXEC " + rtTable.CommandText + " " + search + "";
                LoadReportSourceDataSet(ref dsTemp, sql);
                dsTemp.Tables[0].TableName = rtTable.TableName;
                //dsSource.Tables.Add(dsTemp.Tables[rtTable.TableName].Copy());
                dt = dsTemp.Tables[rtTable.TableName].Copy();
            }
        }
        private void LoadReportParameters()
        {
            try
            {
                parameters.Clear();
                XmlNodeList xmlParameters = GetCustomNodeList("ReportParameter");
                RDLParameter rpParam = null;

                foreach (XmlNode xmlParam in xmlParameters)
                {
                    rpParam = new RDLParameter();
                    rpParam.Name = xmlParam.Attributes["Name"].InnerText;
                    rpParam.DbType = (DbType)StaticInfo.GetEnumValue(typeof(DbType), xmlParam["DataType"].InnerText);
                    rpParam.Prompt = xmlParam["Prompt"].InnerText;
                    rpParam.Value = xmlParam["Prompt"].InnerText;
                    parameters.Add(rpParam);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetSQLParametersValue()
        {
            try
            {
                CustomList<FilterSets> searchList = new CustomList<FilterSets>();//filterSetList.FindAll(item => item.IsParameter && item.ColumnValue.IsNullOrEmpty());
                if (searchList.Count.IsNotZero())
                {
                    throw new Exception("Parameter can not be blank. ");
                }
                //SQL Parameters
                foreach (RDLTable rt in dsreport.Tables)
                {
                    //Shamim
                    foreach (RDLParameter param in rt.Parameters)
                    {
                        searchList = filterSetList.FindAll(item => item.IsParameter && item.ColumnName == param.Prompt);
                        if (searchList.Count == 1)
                        {
                            SetValue(param, searchList[0]);
                        }
                        else
                            param.Value = String.Empty;
                    }
                    //shamim
                }
                //Report Parameters
                foreach (RDLParameter param in parameters)
                {
                    searchList = filterSetList.FindAll(item => item.IsParameter && item.ColumnName == param.Name);
                    if (searchList.Count == 1)
                    {
                        SetValue(param, searchList[0]);
                    }
                    else
                        param.Value = String.Empty;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        private void SetValue(RDLParameter param, FilterSets value)
        {
            try
            {
                param.DbType = (DbType)StaticInfo.GetEnumValue(typeof(DbType), value.DataType);
                switch (param.DbType)
                {
                    case DbType.DateTime:
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        if (value.ColumnValue == "")
                        {
                            param.Value = String.Empty;
                            break;
                        }
                        param.Value = DateTime.ParseExact(value.ColumnValue, StaticInfo.GridDateFormat, provider).ToString(StaticInfo.DateFormat);
                        break;
                    case DbType.Int16:
                        param.Value = Convert.ToInt16(value.ColumnValue);
                        break;
                    case DbType.Int32:
                        param.Value = Convert.ToInt32(value.ColumnValue);
                        break;
                    case DbType.Int64:
                        param.Value = Convert.ToInt64(value.ColumnValue);
                        break;
                    case DbType.Double:
                        param.Value = Convert.ToDouble(value.ColumnValue);
                        break;
                    case DbType.Decimal:
                        param.Value = Convert.ToDecimal(value.ColumnValue);
                        break;
                    case DbType.Boolean:
                        param.Value = Convert.ToBoolean(value.ColumnValue);
                        break;
                    default:
                        param.Value = value.ColumnValue;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SetFilterValue()
        {
            try
            {
                String filterString = String.Empty;
                foreach (String TableName in BodyTablesName)
                {
                    filterString = String.Empty;
                    CustomList<FilterSets> searchList = filterSetList.FindAll(item => item.IsParameter.IsFalse() && item.TableName == TableName && item.ColumnValue.IsNotNullOrEmpty());
                    //CustomList<FilterSets> searchList = filterSetList.FindAll(item => item.IsParameter.IsFalse() && item.TableName == TableName);
                    foreach (FilterSets filter in searchList)
                    {
                        if (filter.Operators == "In"
                            || filter.Operators == "Not In")
                        {
                            filterString += filter.ColumnName + " " + filter.Operators + " (" + GetInOperatorString(filter.ColumnValue) + ") And ";
                        }
                        else
                        {
                            if (filter.ColumnName == "Expression")
                            {
                                filterString += filter.ColumnValue + " And ";
                            }
                            else
                            {
                                if (filter.DataType == "DateTime" || filter.DataType == "System.DateTime")
                                {
                                    CultureInfo provider = CultureInfo.InvariantCulture;
                                    DateTime datevalue = DateTime.ParseExact(filter.ColumnValue, StaticInfo.GridDateFormat, provider);
                                    filterString += filter.ColumnName + " " + filter.Operators + " '" + datevalue.ToString(StaticInfo.DateFormat) + "' And ";
                                }
                                else
                                    filterString += filter.ColumnName + " " + filter.Operators + " '" + filter.ColumnValue + "' And ";
                            }
                        }
                    }
                    //
                    if (filterString.Length.IsNotZero())
                    {
                        filterString = filterString.Substring(0, filterString.Length - 4);
                        dsSource.Tables[TableName].DefaultView.RowFilter = filterString;
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        private String GetInOperatorString(String Expression)
        {
            try
            {
                String strTemp = "";
                String[] strArray = Expression.Split(',', '|', '*', '!');
                foreach (String str in strArray)
                {
                    strTemp += "'" + str + "',";
                }
                //
                return strTemp;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private object GetSQLParamField(String Expression)
        {
            try
            {
                Object value = null;
                int index = Expression.IndexOf("!") + 1;
                int length = Expression.IndexOf(".");
                value = Expression.Substring(index, length - index);
                return value;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InitializeReportParameter()
        {
            try
            {
                foreach (RDLTable rtTable in dsreport.Tables)
                {
                    foreach (RDLParameter param in rtTable.Parameters)
                    {
                        param.Value = DBNull.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void LoadSourceDataSet(ref string checkedRequiredField,string supervisorKey)
        {
            DataSet dsTemp = new DataSet();
            dsSource = new DataSet();

            foreach (RDLTable rtTable in dsreport.Tables)
            {
                string search = "";
                if (supervisorKey.IsNotNullOrEmpty())
                    search += "@Supervisor='" +supervisorKey + "',";
                foreach (RDLParameter param in rtTable.Parameters)
                {
                    FilterSets fSL = new FilterSets();
                    string[] items = param.Prompt.Split('_');
                    if (items.Length == 2)
                        fSL = filterSetList.Find(item => item.IsParameter && item.ColumnName == items[0]);
                    else
                        fSL = filterSetList.Find(item => item.IsParameter && item.ColumnName == param.Prompt);
                    //FilterSets fSL = filterSetList.Find(item => item.IsParameter);
                    if (fSL.ColumnActualValue != "")
                    {
                        search += "@" + param.Prompt + "='" + fSL.ColumnActualValue + "',";
                        param.Value = fSL.ColumnActualValue;
                    }
                    if (fSL.ColumnActualValue == "" && fSL.ColumnValue != "")
                    {
                        search += "@" + param.Prompt + "='" + fSL.ColumnValue + "',";
                        param.Value = fSL.ColumnValue;
                    }
                    if ((items.Length == 2 && fSL.ColumnActualValue == "") && (items.Length == 2 && fSL.ColumnValue == ""))
                    {
                        checkedRequiredField = items[0] + " is required.";
                        return;
                    }
                    //if (items.Length == 2 && fSL.ColumnActualValue == "" && fSL.ColumnValue=="")
                    //{
                    //    checkedRequiredField = items[0] + " is required.";
                    //    return;
                    //}
                }
                if (search != "")
                    search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;
                String sql = "EXEC " + rtTable.CommandText + " " + search + "";
                LoadReportSourceDataSet(ref dsTemp, sql);
                dsTemp.Tables[0].TableName = rtTable.TableName;
                dsSource.Tables.Add(dsTemp.Tables[rtTable.TableName].Copy());
            }
        }
        public void LoadSourceDataSet(IList<ReportParameter> parameters)
        {
            int i = 0;
            DataSet dsTemp = new DataSet();
            dsSource = new DataSet();
            IDbDataParameter[] sqlParam;

            foreach (RDLTable rtTable in dsreport.Tables)
            {
                sqlParam = new IDbDataParameter[rtTable.Parameters.Count];
                i = 0;
                foreach (RDLParameter param in rtTable.Parameters)
                {
                    sqlParam[i] = new SqlParameter();
                    sqlParam[i].ParameterName = param.Name;
                    sqlParam[i].DbType = param.DbType;

                    foreach (ReportParameter paramInfo in parameters)
                    {
                        if (paramInfo.Name == param.Prompt)
                        {
                            sqlParam[i].Value = paramInfo.Values[0];
                            param.Value = paramInfo.Values[0];
                            break;
                        }
                    }
                    i++;
                }
                LoadReportSourceDataSet(ref dsTemp, rtTable.CommandType, rtTable.CommandText, sqlParam);
                dsTemp.Tables[0].TableName = rtTable.TableName;
                dsSource.Tables.Add(dsTemp.Tables[rtTable.TableName].Copy());
            }
        }
        public void LoadSubReportSourceDataSet(ReportParameterInfoCollection reportParameters)
        {
            int i = 0;
            DataSet dsTemp = new DataSet();
            IDbDataParameter[] sqlParam;
            Boolean needToLoad = false;
            foreach (RDLTable rtTable in dsreport.Tables)
            {
                sqlParam = new IDbDataParameter[rtTable.Parameters.Count];
                i = 0;
                foreach (RDLParameter param in rtTable.Parameters)
                {
                    sqlParam[i] = new SqlParameter();
                    sqlParam[i].ParameterName = param.Name;
                    sqlParam[i].DbType = param.DbType;

                    foreach (ReportParameterInfo paramInfo in reportParameters)
                    {
                        if (paramInfo.Name == param.Prompt)
                        {
                            sqlParam[i].Value = paramInfo.Values[0];
                            if (param.Value.NotEquals(paramInfo.Values[0]))
                                needToLoad = true;
                            param.Value = paramInfo.Values[0];
                            break;
                        }
                    }
                    i++;
                }
                //
                if (needToLoad)
                {
                    LoadReportSourceDataSet(ref dsTemp, rtTable.CommandType, rtTable.CommandText, sqlParam);
                    dsTemp.Tables[0].TableName = rtTable.TableName;
                    if (dsSource.Tables.Contains(rtTable.TableName))
                        dsSource.Tables.Remove(rtTable.TableName);
                    dsSource.Tables.Add(dsTemp.Tables[rtTable.TableName].Copy());
                }
            }
        }
        public TextReader GetCustomTextReader(String reportPath)
        {
            try
            {
                XmlDocument xmlReportDocument = null;
                TextReader reader = null;
                XmlNamespaceManager nsManager = null;
                XmlNodeList nodList = null;
                //
                if (xmlReportDocument.IsNull())
                {
                    xmlReportDocument = new XmlDocument();
                    try
                    {
                        xmlReportDocument.Load(reportPath);
                    }
                    catch { }
                }


                //Remove Filter Option from Report.
                nsManager = new XmlNamespaceManager(xmlReportDocument.NameTable);
                nsManager.AddNamespace("ns", "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition");
                nodList = xmlReportDocument.SelectNodes("//ns:Report/ns:DataSets/ns:DataSet/ns:Filters", nsManager);
                //
                foreach (XmlNode RemoveNode in nodList)
                {
                    RemoveNode.ParentNode.RemoveChild(RemoveNode);
                }


                ////Remove Report Parameter Option from Report.
                //nodList = xmlReportDocument.SelectNodes("//ns:Report/ns:ReportParameters", nsManager);
                //foreach (XmlNode RemoveNode in nodList)
                //{
                //    RemoveNode.ParentNode.RemoveChild(RemoveNode);
                //}
                ////Remove Query Parameter Option from Report.
                //nodList = xmlReportDocument.SelectNodes("//ns:Report/ns:DataSets/ns:DataSet/ns:Query/ns:QueryParameters", nsManager);
                //foreach (XmlNode RemoveNode in nodList)
                //{
                //    RemoveNode.ParentNode.RemoveChild(RemoveNode);
                //}
                //
                reader = new System.IO.StringReader(xmlReportDocument.OuterXml);
                return reader;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void LoadReportSourceDataSet(ref DataSet dsRef, CommandType cmdType, String strCmdText, IDbDataParameter[] sqlParam)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            IDataReader reader = null;
            try
            {
                if (sqlParam.IsNull() || sqlParam.Length.IsZero())
                    conManager.OpenDataReader(strCmdText, out reader);
                else
                    conManager.OpenDataReader(out reader, strCmdText, sqlParam);
                //
                dsRef = Util.DataReaderToDataSet(reader);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader.IsNotNull() && reader.IsClosed.IsFalse())
                    reader.Close();
            }
        }

        private void LoadReportSourceDataSet(ref DataSet dsRef, string sql)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            IDataReader reader = null;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                dsRef = Util.DataReaderToDataSet(reader);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader.IsNotNull() && reader.IsClosed.IsFalse())
                    reader.Close();
            }
        }
    }
}
