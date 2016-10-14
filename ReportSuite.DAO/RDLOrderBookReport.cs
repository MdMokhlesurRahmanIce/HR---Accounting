using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using ASL.DATA;

namespace ReportSuite.DAO
{
    public class RDLOrderBookReport
    {
        XmlDocument xmlReportDocument = null;
        DataColumnCollection reportColumns = null;
        XmlElement reportItems = null;
        XmlElement tableEle = null;
        XmlElement tableRows = null;
        XmlElement tableRow = null;
        XmlElement tableCells = null;
        XmlElement tableCell = null;

        XmlAttribute attr = null;
        XmlElement textbox = null;
        XmlElement style = null;
        XmlElement borderStyle = null;
        XmlElement borderWidth = null;

        public RDLOrderBookReport()
        {
        }
        public XmlElement AddElement(XmlElement parent, String name, String value)
        {
            XmlElement newelement = parent.OwnerDocument.CreateElement(name,
                "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition");
            parent.AppendChild(newelement);
            if (value != null) newelement.InnerText = value;
            return newelement;
        }
        private void AddCompanyHeader(XmlElement body, String headerText)
        {
            try
            {
                reportItems = AddElement(body, "ReportItems", null);

                AddTextBox("HeaderCaption", "Ananta Order Book", "12pt", "Center", "Left", "Right", "Top");
                AddElement(textbox, "Height", "0.25in");
                AddElement(textbox, "Width", "3.40in");
                AddElement(textbox, "Left", "0.05in");
                AddElement(style, "FontWeight", "700");
                AddTextBox("HeaderCaptionDate", headerText, "10pt", "Left", "Left", "Right");
                AddElement(textbox, "Top", "0.25in");
                AddElement(textbox, "Height", "0.25in");
                AddElement(textbox, "Width", "3.40in");
                AddElement(textbox, "Left", "0.05in");

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddReportTable()
        {
            try
            {
                tableEle = AddElement(reportItems, "Table", null);
                attr = tableEle.Attributes.Append(xmlReportDocument.CreateAttribute("Name"));
                attr.Value = "OrderBook";
                AddElement(tableEle, "DataSetName", "DataSet1");
                AddElement(tableEle, "Top", "0.5in");
                AddElement(tableEle, "Left", "0.05in");
                AddElement(tableEle, "Height", "0.5in");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddReportColumns()
        {
            try
            {
                XmlElement tablixColumns = AddElement(tableEle, "TableColumns", null);
                XmlElement tablixColumn = null;

                foreach (DataColumn dc in reportColumns)
                {
                    tablixColumn = AddElement(tablixColumns, "TableColumn", null);
                    if (dc.ColumnName.StartsWith("DF"))
                        AddElement(tablixColumn, "Width", ".30in");
                    else if (dc.ColumnName.StartsWith("Description"))
                        AddElement(tablixColumn, "Width", "1.30in");
                    else if (dc.ColumnName.StartsWith("InputDate"))
                        AddElement(tablixColumn, "Width", ".30in");
                    else if (dc.ColumnName.StartsWith("Emb") || dc.ColumnName.StartsWith("Prn") || dc.ColumnName.StartsWith("Wash"))
                        AddElement(tablixColumn, "Width", ".20in");
                    else
                        AddElement(tablixColumn, "Width", ".60in");
                    if (dc.ColumnName == "Buyer" || dc.ColumnName == "Department")
                    {
                        XmlElement visibility = AddElement(tablixColumn, "Visibility", null);
                        AddElement(visibility, "Hidden", "true");
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddReportHeader()
        {
            try
            {
                String lastColName = String.Empty;
                String monthName = String.Empty;
                Int32 colSpanNo = 0;
                //Header First Row
                XmlElement header = AddElement(tableEle, "Header", null);
                AddElement(header, "RepeatOnNewPage", "true");
                //TablixRows element
                tableRows = AddElement(header, "TableRows", null);
                //TablixRow element
                tableRow = AddElement(tableRows, "TableRow", null);
                AddElement(tableRow, "Height", "0.15in");
                tableCells = AddElement(tableRow, "TableCells", null);
                foreach (DataColumn dc in reportColumns)
                {
                    lastColName = dc.ColumnName;
                    if (dc.ColumnName.StartsWith("DF"))
                    {
                        String mName = GetMonthNameFromCaption(dc.ColumnName);
                        if (monthName.IsNullOrEmpty() || monthName.Equals(mName))
                        {
                            colSpanNo++;
                            monthName = mName;
                            continue;
                        }
                        tableCell = AddElement(tableCells, "TableCell", null);
                        AddElement(tableCell, "ColSpan", colSpanNo.ToString());
                        reportItems = AddElement(tableCell, "ReportItems", null);

                        AddTextBox(String.Format("Header{0}", dc.ColumnName), monthName, "4pt", "Center", "Default");

                        monthName = mName;
                        colSpanNo = 1;
                    }
                    else
                    {
                        tableCell = AddElement(tableCells, "TableCell", null);
                        reportItems = AddElement(tableCell, "ReportItems", null);

                        AddTextBox(String.Format("Header{0}", dc.ColumnName), dc.ColumnName, "4pt", "Center", "Left", "Right", "Top");
                    }
                }

                //Last Month
                tableCell = AddElement(tableCells, "TableCell", null);
                AddElement(tableCell, "ColSpan", colSpanNo.ToString());
                reportItems = AddElement(tableCell, "ReportItems", null);


                AddTextBox(String.Format("HeaderL{0}", lastColName), monthName, "4pt", "Center", "Default");

                //Header Scecond Row
                tableRow = AddElement(tableRows, "TableRow", null);
                AddElement(tableRow, "Height", "0.15in");
                tableCells = AddElement(tableRow, "TableCells", null);
                foreach (DataColumn dc in reportColumns)
                {
                    tableCell = AddElement(tableCells, "TableCell", null);
                    reportItems = AddElement(tableCell, "ReportItems", null);
                    if (dc.ColumnName.StartsWith("DF"))
                        AddTextBox(String.Format("Header1{0}", dc.ColumnName), GetColumnCaption(dc.ColumnName), "4pt", "Center", "Default");
                    else
                        AddTextBox(String.Format("Header1{0}", dc.ColumnName), GetColumnCaption(dc.ColumnName), "4pt", "Center", "Left", "Right", "Bottom");

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddReportDetails()
        {
            try
            {
                XmlElement details = AddElement(tableEle, "Details", null);
                //TablixRows element
                tableRows = AddElement(details, "TableRows", null);
                //TablixRow element
                tableRow = AddElement(tableRows, "TableRow", null);
                AddElement(tableRow, "Height", "0.15in");
                tableCells = AddElement(tableRow, "TableCells", null);
                foreach (DataColumn dc in reportColumns)
                {
                    tableCell = AddElement(tableCells, "TableCell", null);
                    reportItems = AddElement(tableCell, "ReportItems", null);
                    if (dc.ColumnName.StartsWith("DF"))
                        AddTextBox(dc.ColumnName, String.Format("=IIf(Fields!{0}.Value = 0, {1}{1}, Fields!{0}.Value)", dc.ColumnName, "\""), "4pt", "Right", "Default");
                    else
                    {
                        if (dc.DataType == typeof(DateTime))
                        {
                            AddTextBox(dc.ColumnName, String.Format("=Fields!{0}.Value", dc.ColumnName), "4pt", "Left", "Default");
                            AddElement(style, "Format", "dd MMM");
                        }
                        else
                            AddTextBox(dc.ColumnName, String.Format("=Fields!{0}.Value", dc.ColumnName), "4pt", "Left", "Default");
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddTextBox(String columnName, String value, String fontSize, String textAlign, params String[] arraBorderStyle)
        {
            try
            {
                AddTextBox(columnName, value, fontSize, textAlign, false, arraBorderStyle);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddTextBox(String columnName, String value, String fontSize, String textAlign, Boolean fontWeight, params String[] arraBorderStyle)
        {
            try
            {
                textbox = AddElement(reportItems, "Textbox", null);
                attr = textbox.Attributes.Append(xmlReportDocument.CreateAttribute("Name"));
                attr.Value = columnName;
                AddElement(textbox, "Value", value);
                //AddElement(textbox, "HideDuplicates", "DataSet1");
                style = AddElement(textbox, "Style", null);
                //Padding the Text Box
                AddElement(style, "PaddingTop", "2pt");
                AddElement(style, "PaddingBottom", "2pt");
                AddElement(style, "PaddingLeft", "2pt");
                AddElement(style, "PaddingRight", "2pt");
                AddElement(style, "FontSize", fontSize);
                AddElement(style, "TextAlign", textAlign);
                //
                if (arraBorderStyle.Length.IsNotZero())
                {
                    borderStyle = AddElement(style, "BorderStyle", null);
                    foreach (String bStyle in arraBorderStyle)
                    {
                        AddElement(borderStyle, bStyle, "Solid");
                    }
                    borderWidth = AddElement(style, "BorderWidth", null);
                    AddElement(borderWidth, "Default", "0.25pt");
                    if (fontWeight)
                        AddElement(style, "FontWeight", "700");
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public TextReader GetCustomTextReader(String reportPath, DataColumnCollection columns, List<RDLParameter> parameters)
        {
            try
            {
                TextReader reader = null;
                XmlNamespaceManager nsManager = null;
                XmlNodeList nodList = null;
                //
                xmlReportDocument = new XmlDocument();
                try
                {
                    xmlReportDocument.Load(reportPath);
                }
                catch { }
                reportColumns = columns;
                //Remove Filter Option from Report.
                nsManager = new XmlNamespaceManager(xmlReportDocument.NameTable);
                nsManager.AddNamespace("ns", "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition");
                nodList = xmlReportDocument.SelectNodes("//ns:Report/ns:DataSets/ns:DataSet/ns:Filters", nsManager);
                //
                foreach (XmlNode RemoveNode in nodList)
                {
                    RemoveNode.ParentNode.RemoveChild(RemoveNode);
                }
                //Remove Fields Option from Report.
                nodList = xmlReportDocument.SelectNodes("//ns:Report/ns:DataSets/ns:DataSet/ns:Fields", nsManager);
                foreach (XmlNode RemoveNode in nodList)
                {
                    RemoveNode.ParentNode.RemoveChild(RemoveNode);
                }
                //Add Fields in Report
                nodList = xmlReportDocument.SelectNodes("//ns:Report/ns:DataSets/ns:DataSet", nsManager);
                XmlElement dataset = (XmlElement)nodList[0];
                XmlElement fields = AddElement(dataset, "Fields", null);
                foreach (DataColumn dc in reportColumns)
                {
                    XmlElement field = AddElement(fields, "Field", null);
                    attr = field.Attributes.Append(xmlReportDocument.CreateAttribute("Name"));
                    attr.Value = dc.ColumnName;
                    AddElement(field, "DataField", dc.ColumnName);
                }
                //Get Body Element from Report
                nodList = xmlReportDocument.SelectNodes("//ns:Report/ns:Body", nsManager);
                XmlElement body = (XmlElement)nodList[0];
                //Add Company Caption in Report
                AddCompanyHeader(body, String.Format("From {0} To {1}", Convert.ToDateTime(parameters[0].Value).Date.ToShortDateString(), Convert.ToDateTime(parameters[1].Value).Date.ToShortDateString()));
                //Add Table in Report
                AddReportTable();
                //Add All Columns in Report
                AddReportColumns();
                //Add Groups
                XmlElement tableGroups = AddElement(tableEle, "TableGroups", null);
                AddTableGroup(tableGroups, "Buyer", true);
                AddTableGroup(tableGroups, "Department", false);
                //
                AddReportHeader();
                //
                AddReportDetails();
                //Save XML document to file
                //xmlReportDocument.Save(@"C:\OrderBook.rdlc");
                reader = new System.IO.StringReader(xmlReportDocument.OuterXml);
                return reader;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void AddTableGroup(XmlElement tableGroups, String groupName, Boolean fontWeight)
        {
            try
            {
                String allDepartment = "ALL DEPARTMENT";
                if (groupName == "Department")
                    allDepartment = String.Empty;
                Int32 colspan = 0;
                String monthName = String.Empty;

                XmlElement tableGroup = AddElement(tableGroups, "TableGroup", null);

                XmlElement grouping = AddElement(tableGroup, "Grouping", null);

                attr = grouping.Attributes.Append(xmlReportDocument.CreateAttribute("Name"));
                attr.Value = String.Format("{0}_Group", groupName);

                XmlElement groupExpressions = AddElement(grouping, "GroupExpressions", null);
                AddElement(groupExpressions, "GroupExpression", String.Format("=Fields!{0}.Value", groupName));


                //Group Header
                XmlElement groupHeader = AddElement(tableGroup, "Header", null);
                //TablixRows element
                tableRows = AddElement(groupHeader, "TableRows", null);
                //TablixRow element (details row)
                tableRow = AddElement(tableRows, "TableRow", null);
                AddElement(tableRow, "Height", "0.15in");
                tableCells = AddElement(tableRow, "TableCells", null);
                // TablixCell element (first cell)
                colspan = reportColumns.Count;

                tableCell = AddElement(tableCells, "TableCell", null);
                AddElement(tableCell, "ColSpan", colspan.ToString());
                reportItems = AddElement(tableCell, "ReportItems", null);


                AddTextBox(String.Format("GroupHeaderMergeCell_{0}", groupName), String.Format("={0} {1} : {0} + Fields!{1}.Value", "\"", groupName), "4pt", "Left", "Default");
                AddElement(style, "FontWeight", "700");

                //Group Footer
                XmlElement groupFooter = AddElement(tableGroup, "Footer", null);
                //TablixRows element
                tableRows = AddElement(groupFooter, "TableRows", null);



                if (groupName == "Buyer")
                {
                    //Blank Row
                    tableRow = AddElement(tableRows, "TableRow", null);
                    AddElement(tableRow, "Height", "0.15in");
                    tableCells = AddElement(tableRow, "TableCells", null);

                    colspan = reportColumns.Count;

                    tableCell = AddElement(tableCells, "TableCell", null);
                    AddElement(tableCell, "ColSpan", colspan.ToString());
                    reportItems = AddElement(tableCell, "ReportItems", null);
                    AddTextBox(String.Format("GroupHeaderMergeCell_{0}_Blank", groupName), String.Empty, "4pt", "Left");
                }

                //TablixRow element
                tableRow = AddElement(tableRows, "TableRow", null);
                AddElement(tableRow, "Height", "0.15in");
                tableCells = AddElement(tableRow, "TableCells", null);
                colspan = 0;
                foreach (DataColumn dc in reportColumns)
                {
                    if (dc.ColumnName.StartsWith("DF").IsFalse())
                    {
                        colspan++;
                        continue;
                    }
                    if (colspan > 0)
                    {
                        tableCell = AddElement(tableCells, "TableCell", null);
                        AddElement(tableCell, "ColSpan", colspan.ToString());
                        reportItems = AddElement(tableCell, "ReportItems", null);

                        AddTextBox(String.Format("FooterMergeCell_{0}", groupName), String.Format("=Fields!{1}.Value + {0} {2} : Weekly Total {0}", "\"", groupName, allDepartment), "4pt", "Right", fontWeight, "Default");

                        colspan = 0;
                    }

                    tableCell = AddElement(tableCells, "TableCell", null);
                    reportItems = AddElement(tableCell, "ReportItems", null);

                    AddTextBox(String.Format("GroupFooter_{0}_{1}", dc.ColumnName, groupName), String.Format("=IIf(Sum(Fields!{0}.Value, {1}{2}{1}) = 0, {1}{1}, Sum(Fields!{0}.Value, {1}{2}{1}))", dc.ColumnName, "\"", String.Format("{0}_Group", groupName)), "4pt", "Right", fontWeight, "Default");

                }

                //Group Footer 2                
                tableRow = AddElement(tableRows, "TableRow", null);
                AddElement(tableRow, "Height", "0.15in");
                tableCells = AddElement(tableRow, "TableCells", null);
                monthName = String.Empty;
                colspan = 0;
                String sumString = "=";
                int colspan1 = 0;
                foreach (DataColumn dc in reportColumns)
                {
                    if (dc.ColumnName.StartsWith("DF"))
                    {
                        if (colspan1 > 0)
                        {
                            tableCell = AddElement(tableCells, "TableCell", null);
                            AddElement(tableCell, "ColSpan", colspan1.ToString());
                            reportItems = AddElement(tableCell, "ReportItems", null);

                            AddTextBox(String.Format("FooterMergeCell1_{0}", groupName), String.Format("=Fields!{1}.Value + {0} {2} : Monthly Total {0}", "\"", groupName, allDepartment), "4pt", "Right", fontWeight, "Default");

                            colspan1 = 0;
                        }
                        String mName = GetMonthNameFromCaption(dc.ColumnName);
                        if (monthName.IsNullOrEmpty() || monthName.Equals(mName))
                        {
                            sumString += String.Format("Sum(Fields!{0}.Value, {1}{2}{1})+", dc.ColumnName, "\"", String.Format("{0}_Group", groupName));
                            colspan++;
                            monthName = mName;
                            continue;
                        }
                        sumString = sumString.Substring(0, sumString.Length - 1);
                        tableCell = AddElement(tableCells, "TableCell", null);
                        AddElement(tableCell, "ColSpan", colspan.ToString());
                        reportItems = AddElement(tableCell, "ReportItems", null);

                        AddTextBox(String.Format("GroupFooter1_{0}_{1}", dc.ColumnName, groupName), sumString, "4pt", "Right", fontWeight, "Default");

                        monthName = mName;
                        sumString = "=";
                        colspan = 1;
                    }
                    else
                        colspan1++;
                }


                //Last Month
                sumString = sumString.Substring(0, sumString.Length - 1);
                tableCell = AddElement(tableCells, "TableCell", null);
                AddElement(tableCell, "ColSpan", colspan.ToString());
                reportItems = AddElement(tableCell, "ReportItems", null);

                AddTextBox(String.Format("GroupFooter1L_{0}_{1}", monthName.Replace(" ", ""), groupName), sumString, "4pt", "Right", fontWeight, "Default");
                if (groupName == "Buyer")
                {
                    //Blank Row
                    tableRow = AddElement(tableRows, "TableRow", null);
                    AddElement(tableRow, "Height", "0.15in");
                    tableCells = AddElement(tableRow, "TableCells", null);

                    colspan = reportColumns.Count;

                    tableCell = AddElement(tableCells, "TableCell", null);
                    AddElement(tableCell, "ColSpan", colspan.ToString());
                    reportItems = AddElement(tableCell, "ReportItems", null);
                    AddTextBox(String.Format("GroupHeaderMergeCell_{0}_Blank1", groupName), String.Empty, "4pt", "Left");
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private String GetColumnCaption(String actualCaption)
        {
            try
            {
                String retString = String.Empty;
                if (actualCaption.StartsWith("DF"))
                {
                    int DateNo = actualCaption.Substring(4).ToInt();
                    if (DateNo == 0)
                        retString = String.Empty;
                    else if (DateNo == 1)
                        retString = "1st";
                    else if (DateNo == 2)
                        retString = "2nd";
                    else if (DateNo == 3)
                        retString = "3rd";
                    else
                        retString = DateNo.ToString() + "th";
                }
                //else
                //    retString = actualCaption;
                //


                return retString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private String GetMonthNameFromCaption(String actualCaption)
        {
            try
            {
                String retString = String.Empty;
                if (actualCaption.NotEquals("DFOrderQty"))
                {
                    int monthNo = actualCaption.Substring(2, 2).ToInt();
                    //
                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    retString = mfi.GetMonthName(monthNo);
                }
                else
                    retString = "Order Qty";
                return retString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
