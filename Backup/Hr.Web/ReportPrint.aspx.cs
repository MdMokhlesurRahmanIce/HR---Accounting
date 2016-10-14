using System;
using System.Collections.Generic;
using System.Data;
using ASL.DATA;
using Microsoft.Reporting.WebForms;
using ReportSuite.DAO;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using System.Web.UI.WebControls;
using ReportSuite.BLL;
using ASL.Web.Framework;
using System.IO;

namespace Hr.Web.Reports
{
    public partial class ReportPrint : PageBase
    {
        #region Constructur
        public ReportPrint()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Value
        private PrinterSetup PrinterSettings
        {
            get
            {
                if (Session["PrinterSetup"] == null)
                    return new PrinterSetup();
                else
                    return (PrinterSetup)Session["PrinterSetup"];
            }
            set
            {
                Session["PrinterSetup"] = value;
            }
        }
        private int CurrentPage
        {
            get
            {
                if (Session["CurrentPage"].IsNull())
                    return -1;
                else
                    return (int)Session["CurrentPage"];
            }
            set
            {
                Session["CurrentPage"] = value;
            }
        }
        private RDLReportDocument Report
        {
            get
            {
                if (Session["ReportViewer_Report"].IsNull())
                    Session["ReportViewer_Report"] = new RDLReportDocument();
                //
                return (RDLReportDocument)Session["ReportViewer_Report"];
            }
            set
            {
                Session["ReportViewer_Report"] = value;
            }
        }
        private List<RDLReportDocument> SubReportList
        {
            get
            {
                if (Session["ReportViewer_SubReportDocument"].IsNull())
                    Session["ReportViewer_SubReportDocument"] = new List<RDLReportDocument>();
                //
                return (List<RDLReportDocument>)Session["ReportViewer_SubReportDocument"];
            }
            set
            {
                Session["ReportViewer_SubReportDocument"] = value;
            }
        }
        private DataSet ReportDataSources
        {
            get
            {
                if (Session["VoucherReportViewer_Account"].IsNull())
                    return new DataSet();
                else
                    return (DataSet)Session["VoucherReportViewer_Account"];
            }
            set
            {
                Session["VoucherReportViewer_Account"] = value;
            }
        }
        #endregion

        #region Page event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                rbAllPages.Checked = true;
                rbPortrait.Checked = true;
                if (!IsPostBack)
                {
                    GetAllPrinter();
                }
                if (Request["__EVENTTARGET"] == "postBackFromParent")
                {
                    string selectPrinterSettings = Request["__EVENTARGUMENT"].ToString();
                    string[] printerSetting = selectPrinterSettings.Split(new char[] { ';' });
                    string printerName = printerSetting[0];
                    int noOfCopies = printerSetting[1].ToInt();
                    bool isLandscape = (printerSetting[2] == "true") ? false : true;
                    bool isAllPages = (printerSetting[3] == "true") ? true : false;
                    bool isCurrentpage = (printerSetting[4] == "true") ? true : false;
                    bool isPageRange = (printerSetting[5] == "true") ? true : false;
                    int fromPage = printerSetting[6].ToInt();
                    int toPage = printerSetting[7].ToInt();
                    PrintReport(printerName, isLandscape, noOfCopies, isAllPages, isCurrentpage, isPageRange, fromPage, toPage);
                }
                //Init Evants
                rpViewer.Drillthrough += new DrillthroughEventHandler(rpViewer_Drillthrough);
                //
                if (IsPostBack)
                {
                    rpViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                    return;
                }
                rpViewer.Reset();

                rpViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                rpViewer.ProcessingMode = ProcessingMode.Local;
                rpViewer.LocalReport.DataSources.Clear();

                //rpViewer.LocalReport.ReportPath = Report.ReportPath;
                rpViewer.LocalReport.LoadReportDefinition(Report.GetCustomTextReader(Report.ReportPath));

                rpViewer.LocalReport.DisplayName = Report.Name;
                rpViewer.LocalReport.EnableExternalImages = true;
                rpViewer.LocalReport.EnableHyperlinks = true;
                //rpViewer.LocalReport.ReportPath = Report.ReportPath;

                LoadSubReportDefinition();
                string value = (string)Session["Account"];
                switch (value)
                {
                    case "Transaction":
                        LoadReportSourceData(value);
                        break;
                    case "TrialBalance":
                        LoadReportSourceData(value);
                        break;
                    case "BalanceSheet":
                        LoadReportSourceData(value);
                        break;
                    case "IncomeStatement":
                        LoadReportSourceData(value);
                        break;
                    case "Ledger":
                        LoadReportSourceData(value);
                        break;
                    case "Voucher":
                        LoadReportSourceData(value);
                        break;
                    default:
                        {
                            SetDataSource(Report.dsSource);
                            SetParameter();
                            rpViewer.LocalReport.Refresh();
                        }
                        break;

                }

                //SetDataSource(Report.dsSource);
                //SetParameter();
                //rpViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                //this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        protected void rpViewer_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            try
            {
                // Handle local drillthrough only
                if (e.Report is ServerReport) return;

                LocalReport localreport = (LocalReport)e.Report;

                RDLReportDocument drillReport = new RDLReportDocument(e.ReportPath);
                drillReport.ReportPathWithOutName = Report.ReportPathWithOutName;
                drillReport.Load(String.Format(@"{0}\{1}.{2}", Report.ReportPathWithOutName, e.ReportPath, "rdl"));

                drillReport.LoadSourceDataSet(localreport.OriginalParametersToDrillthrough);

                localreport.DataSources.Clear();
                localreport.LoadReportDefinition(drillReport.GetCustomTextReader(drillReport.ReportPath));
                localreport.DisplayName = drillReport.Name;
                SetDataSource(drillReport.dsSource, localreport);

                ReportParameter[] Parameters = new ReportParameter[drillReport.Parameters.Count];
                int i = 0;
                foreach (RDLParameter rpParam in drillReport.Parameters)
                {
                    Parameters[i] = new ReportParameter();
                    Parameters[i].Name = rpParam.Name;
                    Parameters[i].Values.Add(rpParam.Value.ToString());
                    i++;

                }
                localreport.Refresh();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            try
            {
                RDLReportDocument subReport = SubReportList.Find(item => item.Name == e.ReportPath);
                if (subReport.IsNotNull())
                {
                    subReport.LoadSubReportSourceDataSet(e.Parameters);
                    ReportDataSource rdSource = null;
                    foreach (DataTable dtTable in subReport.dsSource.Tables)
                    {
                        rdSource = new ReportDataSource();
                        rdSource.Name = dtTable.TableName;
                        rdSource.Value = dtTable.DefaultView;
                        e.DataSources.Add(rdSource);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        #endregion

        #region All Method
        private void SetReportParameters(string value, Microsoft.Reporting.WebForms.ReportViewer rptViewer)
        {
            try
            {
                switch (value)
                {
                    case "Transaction":
                        {
                            String orgKey = (String)Session["OrgKey"];
                            String fromDate = (String)Session["FromDate"];
                            String toDate = (String)Session["ToDate"];
                            Boolean isPost = (Boolean)Session["IsPost"];
                            string proved = "0";
                            if (isPost == false)
                                proved = "0";
                            else
                                proved = "1";
                            List<ReportParameter> paramList = new List<ReportParameter>();

                            ReportParameter company = new ReportParameter();
                            company.Name = "OrgKey";
                            company.Values.Add(orgKey);
                            paramList.Add(company);

                            ReportParameter fDate = new ReportParameter();
                            fDate.Name = "DateFrom";
                            fDate.Values.Add(fromDate);
                            paramList.Add(fDate);

                            ReportParameter tDate = new ReportParameter();
                            tDate.Name = "DateTo";
                            tDate.Values.Add(toDate);
                            paramList.Add(tDate);

                            ReportParameter approved = new ReportParameter();
                            approved.Name = "IsPost";
                            approved.Values.Add(proved);
                            paramList.Add(approved);

                            rptViewer.LocalReport.SetParameters(paramList);
                            break;
                        }
                    case "TrialBalance":
                        {
                            String fYKey = (String)Session["FYKey"];
                            String orgKey = (String)Session["OrgKey"];
                            String fromDate = (String)Session["FromDate"];
                            String toDate = (String)Session["ToDate"];
                            List<ReportParameter> paramList = new List<ReportParameter>();

                            ReportParameter fiscalYear = new ReportParameter();
                            fiscalYear.Name = "FYKey";
                            fiscalYear.Values.Add(fYKey);
                            paramList.Add(fiscalYear);

                            ReportParameter company = new ReportParameter();
                            company.Name = "OrgKey";
                            company.Values.Add(orgKey);
                            paramList.Add(company);

                            ReportParameter fDate = new ReportParameter();
                            fDate.Name = "DateFrom";
                            fDate.Values.Add(fromDate);
                            paramList.Add(fDate);

                            ReportParameter tDate = new ReportParameter();
                            tDate.Name = "DateTo";
                            tDate.Values.Add(toDate);
                            paramList.Add(tDate);

                            rpViewer.LocalReport.SetParameters(paramList);
                            break;
                        }
                    case "IncomeStatement":
                        {
                            String fYKey = (String)Session["FYKey"];
                            String orgKey = (String)Session["OrgKey"];
                            String fromDate = (String)Session["FromDate"];
                            String toDate = (String)Session["ToDate"];
                            List<ReportParameter> paramList = new List<ReportParameter>();

                            ReportParameter fiscalYear = new ReportParameter();
                            fiscalYear.Name = "FYKey";
                            fiscalYear.Values.Add(fYKey);
                            paramList.Add(fiscalYear);

                            ReportParameter company = new ReportParameter();
                            company.Name = "OrgKey";
                            company.Values.Add(orgKey);
                            paramList.Add(company);

                            ReportParameter fDate = new ReportParameter();
                            fDate.Name = "DateFrom";
                            fDate.Values.Add(fromDate);
                            paramList.Add(fDate);

                            ReportParameter tDate = new ReportParameter();
                            tDate.Name = "DateTo";
                            tDate.Values.Add(toDate);
                            paramList.Add(tDate);

                            rpViewer.LocalReport.SetParameters(paramList);
                            break;
                        }
                    case "Voucher":
                        {
                            String voucherNo = (String)Session["VoucherNo"];
                            String orgKey = (String)Session["OrgKey"];
                            List<ReportParameter> paramList = new List<ReportParameter>();

                            ReportParameter voucher = new ReportParameter();
                            voucher.Name = "VoucherNo";
                            voucher.Values.Add(voucherNo);
                            paramList.Add(voucher);

                            ReportParameter company = new ReportParameter();
                            company.Name = "OrgKey";
                            company.Values.Add(orgKey);
                            paramList.Add(company);

                            rpViewer.LocalReport.SetParameters(paramList);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void LoadReportSourceData(string value)
        {
            try
            {
                DataSet CompanyList = new DataSet();
                Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();
                switch (value)
                {
                    case "Transaction":
                        {
                            String orgKey = (String)Session["OrgKey"];
                            String fromDate = (String)Session["FromDate"];
                            String toDate = (String)Session["ToDate"];
                            Boolean isPost = (Boolean)Session["IsPost"];
                            if (orgKey.IsNotNullOrEmpty())
                            {
                                ReportManager manager = new ReportManager();
                                CompanyList = manager.GetCompany(orgKey);
                                ReportDataSources = manager.GetTransactionDataSources(orgKey, fromDate, toDate, isPost);
                            }
                            rview.LocalReport.ReportPath = Report.ReportPath;
                            ReportDataSource companyDatasource = new ReportDataSource("Company", CompanyList.Tables["spGetCompany"]);
                            ReportDataSource masterDatasource = new ReportDataSource("PeriodicalTransaction", ReportDataSources.Tables["Acc_Rpt_PeriodicTrans"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(masterDatasource);
                            SetReportParameters(value, rview);
                            OpenReportInPDF(rview);
                            //rpViewer.LocalReport.Refresh();

                            break;
                        }
                    case "TrialBalance":
                        {
                            String orgKey = (String)Session["OrgKey"];
                            String fromDate = (String)Session["FromDate"];
                            String toDate = (String)Session["ToDate"];
                            if (orgKey.IsNotNullOrEmpty())
                            {
                                ReportManager manager = new ReportManager();
                                CompanyList = manager.GetCompany(orgKey);
                                ReportDataSources = manager.GetTrialBalanceDataSources(orgKey, fromDate, toDate);
                            }
                            rview.LocalReport.ReportPath = Report.ReportPath;
                            ReportDataSource companyDatasource = new ReportDataSource("Company", CompanyList.Tables["spGetCompany"]);
                            ReportDataSource masterDatasource = new ReportDataSource("TrialBalance", ReportDataSources.Tables["Acc_Rpt_TB"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(masterDatasource);
                            SetReportParameters(value, rview);
                            OpenReportInPDF(rview);
                            //rview.LocalReport.Refresh();

                            break;
                        }
                    case "BalanceSheet":
                        {
                            String orgKey = (String)Session["OrgKey"];
                            String fromDate = (String)Session["FromDate"];
                            String toDate = (String)Session["ToDate"];
                            String fY = (String)Session["FYKey"];
                            if (orgKey.IsNotNullOrEmpty())
                            {
                                ReportManager manager = new ReportManager();
                                CompanyList = manager.GetCompany(orgKey);
                                ReportDataSources = manager.GetBalanceSheetDataSources(orgKey, fromDate, toDate, fY);
                            }
                            rview.LocalReport.ReportPath = Report.ReportPath;
                            ReportDataSource companyDatasource = new ReportDataSource("Company", CompanyList.Tables["spGetCompany"]);
                            ReportDataSource masterDatasource = new ReportDataSource("BalanceSheet", ReportDataSources.Tables["Acc_Rpt_BS"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(masterDatasource);
                            SetReportParameters(value, rview);
                            OpenReportInPDF(rview);
                            //rview.LocalReport.Refresh();

                            break;
                        }
                    case "IncomeStatement":
                        {
                            String orgKey = (String)Session["OrgKey"];
                            String fromDate = (String)Session["FromDate"];
                            String toDate = (String)Session["ToDate"];
                            String fY = (String)Session["FYKey"];
                            if (orgKey.IsNotNullOrEmpty())
                            {
                                ReportManager manager = new ReportManager();
                                CompanyList = manager.GetCompany(orgKey);
                                ReportDataSources = manager.GetIncomeStatementDataSources(orgKey, fromDate, toDate, fY);
                            }
                            rview.LocalReport.ReportPath = Report.ReportPath;
                            ReportDataSource companyDatasource = new ReportDataSource("Company", CompanyList.Tables["spGetCompany"]);
                            ReportDataSource masterDatasource = new ReportDataSource("IncomeStatement", ReportDataSources.Tables["Acc_Rpt_PL"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(masterDatasource);
                            SetReportParameters(value, rview);
                            OpenReportInPDF(rview);
                            //rview.LocalReport.Refresh();

                            break;
                        }
                    case "Ledger":
                        {
                            String orgKey = (String)Session["OrgKey"];
                            String fromDate = (String)Session["FromDate"];
                            String toDate = (String)Session["ToDate"];
                            String COAKey = (String)Session["COAKey"];
                            if (orgKey.IsNotNullOrEmpty())
                            {
                                ReportManager manager = new ReportManager();
                                CompanyList = manager.GetCompany(orgKey);
                                ReportDataSources = manager.GetLedgerDataSources(orgKey, fromDate, toDate, COAKey);
                            }
                            rview.LocalReport.ReportPath = Report.ReportPath;
                            ReportDataSource companyDatasource = new ReportDataSource("Company", CompanyList.Tables["spGetCompany"]);
                            ReportDataSource masterDatasource = new ReportDataSource("PeriodicalTransaction", ReportDataSources.Tables["Acc_Rpt_Ledger"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            ReportDataSource openingDatasource = new ReportDataSource("Opening", ReportDataSources.Tables["Acc_Rpt_Ledger;2"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            ReportDataSource periodicalDatasource = new ReportDataSource("Periodical", ReportDataSources.Tables["Acc_Rpt_Ledger;3"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            ReportDataSource closingDatasource = new ReportDataSource("Closing", ReportDataSources.Tables["Acc_Rpt_Ledger;4"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);

                            rview.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(masterDatasource);
                            rview.LocalReport.DataSources.Add(openingDatasource);
                            rview.LocalReport.DataSources.Add(periodicalDatasource);
                            rview.LocalReport.DataSources.Add(closingDatasource);
                            SetReportParameters(value, rview);
                            OpenReportInPDF(rview);
                            //rview.LocalReport.Refresh();

                            break;
                        }
                    case "Voucher":
                        {
                            String orgKey = (String)Session["OrgKey"];
                            String voucherNo = (String)Session["VoucherNo"];
                            if (orgKey.IsNotNullOrEmpty())
                            {
                                ReportManager manager = new ReportManager();
                                CompanyList = manager.GetCompany(orgKey);
                                ReportDataSources = manager.GetVoucherDataSources(voucherNo);
                            }
                            rview.LocalReport.ReportPath = Report.ReportPath;
                            ReportDataSource companyDatasource = new ReportDataSource("Company", CompanyList.Tables["spGetCompany"]);
                            ReportDataSource masterDatasource = new ReportDataSource("Voucher", ReportDataSources.Tables["spPreviewVoucher"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(masterDatasource);
                            SetReportParameters(value, rview);
                            OpenReportInPDF(rview);
                            //rview.LocalReport.Refresh();

                            break;
                        }
                    case "DemoEmp":
                        {
                            String empCode = (String)Session["empCode"];
                            String empName = (String)Session["empName"];
                            if (empCode.IsNotNullOrEmpty())
                            {
                                ReportManager manager = new ReportManager();
                                CompanyList = manager.GetCompany(empCode);
                                ReportDataSources = manager.GetVoucherDataSources(empName);
                            }
                            rview.LocalReport.ReportPath = Report.ReportPath;
                            ReportDataSource companyDatasource = new ReportDataSource("Company", CompanyList.Tables["spGetCompany"]);
                            ReportDataSource masterDatasource = new ReportDataSource("Voucher", ReportDataSources.Tables["spPreviewVoucher"]); rpViewer.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(companyDatasource);
                            rview.LocalReport.DataSources.Add(masterDatasource);
                            SetReportParameters(value, rview);
                            OpenReportInPDF(rview);
                            //rview.LocalReport.Refresh();

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                //Message.ShowErrorMessage("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        private void OpenReportInPDF(Microsoft.Reporting.WebForms.ReportViewer rpViewerObj)
        {
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo = "<DeviceInfo>" + "<OutputFormat>PDF</OutputFormat>" + "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //Render the report
            renderedBytes = rpViewerObj.LocalReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=UniSoftReport." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }
        private void GetAllPrinter()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                ddlPrinterName.Items.Add(new ListItem(printer, printer));
            }
            ddlPrinterName.Items.Insert(0, new ListItem("Select Printer", ""));
        }
        private void LoadSubReportDefinition()
        {
            try
            {
                foreach (RDLReportDocument subReport in SubReportList)
                {
                    subReport.InitializeReportParameter();
                    rpViewer.LocalReport.LoadSubreportDefinition(subReport.Name, Report.GetCustomTextReader(subReport.ReportPath));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetDataSource(DataSet dsSource)
        {
            ReportDataSource rdSource = null;
            foreach (DataTable dtTable in dsSource.Tables)
            {
                rdSource = new ReportDataSource();
                rdSource.Name = dtTable.TableName;
                rdSource.Value = dtTable.DefaultView;
                rpViewer.LocalReport.DataSources.Add(rdSource);
            }
        }
        private void SetDataSource(DataSet dsSource, LocalReport report)
        {
            ReportDataSource rdSource = null;
            foreach (DataTable dtTable in dsSource.Tables)
            {
                rdSource = new ReportDataSource();
                rdSource.Name = dtTable.TableName;
                rdSource.Value = dtTable.DefaultView;
                report.DataSources.Add(rdSource);
            }
        }
        private void SetParameter()
        {
            ReportParameter[] Parameters = new ReportParameter[Report.Parameters.Count];
            int i = 0;
            foreach (RDLParameter rpParam in this.Report.Parameters)
            {
                if (rpParam.Value.ToString() == "") rpParam.Value = "0";
                Parameters[i] = new ReportParameter();
                Parameters[i].Name = rpParam.Name;
                Parameters[i].Values.Add(rpParam.Value.ToString());
                i++;
            }
            //Parameters[0] = new ReportParameter();
            //Parameters[0].Name = "OrgKey";
            //Parameters[0].Values.Add("1");
            //Parameters[1] = new ReportParameter();
            //Parameters[1].Name = "Date";
            //Parameters[1].Values.Add("09/02/2013");
            rpViewer.LocalReport.SetParameters(Parameters);
        }
        private void PrintReport(string printerName, bool isLandscape, int noOfCopies, bool isAllPages, bool isCurrentpage, bool isPageRange, int fromPage, int toPage)
        {
            try
            {
                CurrentPage = rpViewer.CurrentPage;

                ReportPrintDocument rptPrintDoc = new ReportPrintDocument(rpViewer.LocalReport, isLandscape);
                rptPrintDoc.PrinterSettings.PrinterName = printerName;
                rptPrintDoc.NoofCopies = noOfCopies;
                if (isAllPages == true)
                {
                }
                else if (isCurrentpage == true)
                {
                    rptPrintDoc.PageRange = true;
                    rptPrintDoc.FromPage = CurrentPage;
                    rptPrintDoc.ToPage = CurrentPage;
                }
                else
                {
                    rptPrintDoc.PageRange = true;
                    rptPrintDoc.FromPage = fromPage;
                    rptPrintDoc.ToPage = toPage;
                }
                rptPrintDoc.Print();
            }
            catch (Exception ex)
            {
                Response.Output.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
