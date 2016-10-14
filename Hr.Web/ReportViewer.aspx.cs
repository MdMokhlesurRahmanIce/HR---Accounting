using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using ASL.DATA;
using ReportSuite.DAO;
using ASL.Web.Framework;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;
using Microsoft.Reporting.WebForms;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace Hr.Web.Reports
{
    public partial class ReportViewer : PageBase
    {
        private const String ParamTableName = "ParameterValues";

        #region Constructur
        public ReportViewer()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Value
        private CustomList<ReportSuiteMenu> ReportMenuList
        {
            get
            {
                if (Session["ReportViewer_ReportSuiteMenu"].IsNull())
                    Session["ReportViewer_ReportSuiteMenu"] = new CustomList<ReportSuiteMenu>();
                //
                return (CustomList<ReportSuiteMenu>)Session["ReportViewer_ReportSuiteMenu"];
            }
            set
            {
                Session["ReportViewer_ReportSuiteMenu"] = value;
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
        private DataSet ParameterValues
        {
            get
            {
                if (Session["ReportViewer_ParameterValues"].IsNull())
                    Session["ReportViewer_ParameterValues"] = new DataSet();
                //
                return (DataSet)Session["ReportViewer_ParameterValues"];
            }
            set
            {
                Session["ReportViewer_ParameterValues"] = value;
            }
        }
        private CustomList<FilterSets> FilterSetList
        {
            get
            {
                if (Session["ReportViewer_FilterSetList"].IsNull())
                    Session["ReportViewer_FilterSetList"] = new CustomList<FilterSets>();
                //
                return (CustomList<FilterSets>)Session["ReportViewer_FilterSetList"];
            }
            set
            {
                Session["ReportViewer_FilterSetList"] = value;
            }
        }
        private CustomList<ParameterFilterValue> FilterValueList
        {
            get
            {
                if (Session["ReportViewer_FilterValueList"].IsNull())
                    Session["ReportViewer_FilterValueList"] = new CustomList<ParameterFilterValue>();
                //
                return (CustomList<ParameterFilterValue>)Session["ReportViewer_FilterValueList"];
            }
            set
            {
                Session["ReportViewer_FilterValueList"] = value;
            }
        }
        #endregion

        #region Page event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (enterintoLoadEvent.IsFalse()) return;
                if (IsPostBack.IsFalse())
                {
                    FilterSetList = new CustomList<FilterSets>();
                    FilterValueList = new CustomList<ParameterFilterValue>();
                    ReportSuite.BLL.ReportSuite reportSuite = new ReportSuite.BLL.ReportSuite(ASL.STATIC.ConnectionName.HR);
                    string empcode = Request.QueryString.Get("empCode");
                    string empKey = Request.QueryString.Get("EmpKey");
                    if (empcode.IsNullOrEmpty())
                    {
                        ReportMenuList = reportSuite.GetReportSuiteMenu(CurrentUserSession.UserCode);
                    }
                    else
                    {
                        ReportMenuList = reportSuite.GetReportSuiteMenu();
                    }
                    LoadMenu();
                    treeMenu.CollapseAll();
                    if (treeMenu.Nodes.Count > 0)
                        treeMenu.Nodes[0].Expand();
                }
            }
            catch (Exception ex)
            {
                //Message.ShowErrorMessage("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        #endregion

        #region Button event
        protected void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string checkedRequiredField = "";
                DataTable dt = new DataTable();
                Report.LoadSourceDataSet(ref checkedRequiredField, ref dt);
                foreach (DataRow dR in dt.Rows)
                {
                    string email = dR["OfficialEmail"].ToString().Trim();
                    if (email.IsNullOrEmpty())
                        continue;
                    Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();
                    rview.LocalReport.ReportPath = Session["reportPath"].ToString();
                    DataTable dt1 = new DataTable();
                    Report.LoadSourceDataSet(dR["EmpKey"].ToString(), ref dt1);


                    ReportDataSource rdSource = null;
                    //foreach (DataTable dtTable in Report.dsSource.Tables)
                    //{
                    rdSource = new ReportDataSource();
                    rdSource.Name = dt1.TableName;
                    rdSource.Value = dt1.DefaultView;
                    rview.LocalReport.DataSources.Add(rdSource);
                    //}

                    string mimeType, encoding, extension;
                    string[] streamids; Microsoft.Reporting.WebForms.Warning[] warnings;
                    string format = "PDF";
                    byte[] bytes = rview.LocalReport.Render(format, "", out mimeType, out encoding, out extension, out streamids, out warnings);


                    using (MemoryStream input = new MemoryStream(bytes))
                    {
                        using (MemoryStream output = new MemoryStream())
                        {
                            string password = "pass@123";
                            PdfReader reader = new PdfReader(input);
                            PdfEncryptor.Encrypt(reader, output, true, password, password, PdfWriter.ALLOW_SCREENREADERS);
                            bytes = output.ToArray();
                            //Response.ContentType = "application/pdf";
                            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            //Response.BinaryWrite(bytes);
                            //Response.End();
                        }
                    }

                    //save the pdf byte to the folder

                    string savePath = ConfigurationManager.AppSettings["PaySlipFile"];
                    var path = System.Web.HttpContext.Current.Server.MapPath(savePath) + dR["EmpKey"].ToString() + "-" + dR["EmpName"].ToString() + ".pdf";
                    //var fullFileName = path  + fileInfo.Extension;
                    FileStream fs = new FileStream(path, FileMode.Create);
                    byte[] data = new byte[fs.Length];
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    //SendEmailWithReportAttachment obj = new SendEmailWithReportAttachment();
                    //obj.Email(dR["EmpKey"].ToString(), email, path);
                    MailMessage msg = new MailMessage();

                    //msg.To.Add("samnur_iu@yahoo.com");
                    msg.To.Add(email);
                    MailAddress frmAdd = new MailAddress("Saju_Saha@apl.com");
                    msg.From = frmAdd;

                    ////Check user enter CC address or not
                    //if (ccId != "")
                    //{
                    //    msg.CC.Add(ccId);
                    //}
                    ////Check user enter BCC address or not
                    //if (bccId != "")
                    //{
                    //    msg.Bcc.Add(bccId);
                    //}
                    msg.Subject = "Pay Slip";
                    //Check for attachment is there
                    //if (FileUpload1.HasFile)
                    //{
                    //    msg.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
                    //}
                    msg.IsBodyHtml = true;
                    msg.Body = "This is system generated mail.";

                    Attachment attach = new Attachment(path);
                    msg.Attachments.Add(attach);
                    //MailAttachment attachment = new MailAttachment(Server.MapPath("test.txt")); //create the attachment
                    //mail.Attachments.Add(attachment);	//add the attachment
                    //SmtpClient mailClient = new SmtpClient("smtp.mail.yahoo.com", 25);
                    SmtpClient mailClient = new SmtpClient("mail.@D1.ad.apl.com",1408);
                    NetworkCredential NetCrd = new NetworkCredential("Saju_Saha@apl.com", "@ukhiya1*44");
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = NetCrd;
                    mailClient.EnableSsl = true;
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mailClient.Send(msg);
                    attach.Dispose();
                    msg.Dispose();
                    mailClient.Dispose();

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void treeMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                if (treeMenu.SelectedNode.IsNotNull() && treeMenu.SelectedNode.ImageToolTip.IsNotNullOrEmpty())
                {
                    ReportSuite.BLL.ReportSuite reportSuite = new ReportSuite.BLL.ReportSuite(ASL.STATIC.ConnectionName.HR);
                    String reportPath = String.Empty;
                    reportPath = AppDomain.CurrentDomain.BaseDirectory + "ASTReports\\" + treeMenu.SelectedNode.ImageToolTip;
                    Session["reportPath"] = reportPath;
                    if (System.IO.File.Exists(reportPath).IsFalse())
                    {
                        Response.Write("File does not exist.");
                        return;
                    }

                    ParameterValues = new DataSet();
                    ParameterValues = reportSuite.LoadReportParameterInfoFromDB(treeMenu.SelectedNode.Value.ToInt());
                    ParameterValues.Tables[0].TableName = ParamTableName;

                    Session["ReportID"] = treeMenu.SelectedNode.Value.ToString();

                    SubReportList = new List<RDLReportDocument>();
                    Report = new RDLReportDocument(treeMenu.SelectedNode.Text);
                    Report.ReportPathWithOutName = treeMenu.SelectedNode.ToolTip;
                    Report.Load(reportPath);
                    Report.LoadFilterTable(ParameterValues.Tables[ParamTableName].Columns);
                    FilterSetList = Report.FilterSetList;
                }
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string checkedRequiredField = "";
                ResetSession();
                string empKey = Request.QueryString.Get("EmpKey");
                Report.LoadSourceDataSet(ref checkedRequiredField, empKey);
                //string empKey = Request.QueryString.Get("empCode");
                //Report.LoadSourceDataSet(ref checkedRequiredField, empKey);
                if (checkedRequiredField != "")
                {
                    ((PageBase)this.Page).ErrorMessage = checkedRequiredField;
                    return;
                }
                Report.SetFilterValue();
                String script = "javascript:ShowReportViewer();";
                if (ClientScript.IsClientScriptBlockRegistered("scriptShowReportViewer").IsFalse())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptShowReportViewer", script, true);
                }
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (FilterSets filter in FilterSetList)
                {
                    filter.ColumnValue = String.Empty;
                }
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        #endregion

        #region All Method
        private void ResetSession()
        {
            Session["Voucher"] = "";
        }
        private void LoadMenu()
        {
            try
            {
                TreeNode parentNode;
                CustomList<ReportSuiteMenu> parentList = ReportMenuList.FindAll(item => item.REPORTID == item.PARENT_KEY);
                foreach (ReportSuiteMenu parent in parentList)
                {
                    parentNode = new TreeNode();
                    parentNode.Text = parent.NODE_TEXT;
                    parentNode.Value = parent.REPORTID.ToString();

                    LoadChildNodes(parentNode, parent.REPORTID);
                    treeMenu.Nodes.Add(parentNode);
                }
                //
                //treeMenu.ExpandAll();
                treeMenu.SelectedNodeStyle.ForeColor = System.Drawing.Color.Red;
                treeMenu.HoverNodeStyle.ForeColor = System.Drawing.Color.Gray;
                treeMenu.NodeStyle.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void LoadChildNodes(TreeNode parentNode, int parentID)
        {
            try
            {
                TreeNode aNode;
                CustomList<ReportSuiteMenu> childList = ReportMenuList.FindAll(item => item.PARENT_KEY == parentID && item.REPORTID != parentID);
                foreach (ReportSuiteMenu child in childList)
                {

                    aNode = new TreeNode();
                    aNode.Text = child.NODE_TEXT;
                    aNode.Value = child.REPORTID.ToString();
                    aNode.ImageUrl = @"~\images\node.Png";
                    aNode.ToolTip = AppDomain.CurrentDomain.BaseDirectory + "Reports";//child.REPORT_PATH_NAME;
                    //aNode.ImageToolTip = String.Format(@"{0}\{1}", child.REPORT_PATH_NAME, child.REPORT_NAME);
                    aNode.ImageToolTip = child.REPORT_NAME;
                    parentNode.ChildNodes.Add(aNode);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

    }
}

