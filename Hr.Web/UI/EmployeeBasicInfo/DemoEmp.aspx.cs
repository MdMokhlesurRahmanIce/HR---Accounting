using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Web.Framework;
using ASL.DATA;
using System.ComponentModel;
using ASL.STATIC;
using System.Data;
using System.Data.SqlClient;
using ASL.Hr.DAO;
using ASL.DAL;
using ASL.Hr.BLL;
using System.Collections;
using ReportSuite.DAO;

namespace Hr.Web.UI.EmployeeBasicInfo
{
    public partial class DemoEmp : PageBase
    {
       

        #region Session Variables
        DemoEmpManager empManager = new DemoEmpManager();
        DemoEmpMaster empMaster = new DemoEmpMaster();
        private CustomList<ASL.Hr.DAO.DemoEmpMaster> _emp
        {
            get
            {
                if (Session["DemoEmp_emp"] == null)
                    return new CustomList<ASL.Hr.DAO.DemoEmpMaster>();
                else
                    return (CustomList<ASL.Hr.DAO.DemoEmpMaster>)Session["DemoEmp_emp"];
            }
            set
            {
                Session["DemoEmp_emp"] = value;
            }
        }

        private CustomList<ASL.Hr.DAO.DemoEmpMaster> _empMasterForSave
        {
            get
            {
                if (Session["DemoEmp_empForSave"] == null)
                    return new CustomList<ASL.Hr.DAO.DemoEmpMaster>();
                else
                    return (CustomList<ASL.Hr.DAO.DemoEmpMaster>)Session["DemoEmp_empForSave"];
            }
            set
            {
                Session["DemoEmp_empForSave"] = value;
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
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSession();
                InitializeControls();
            }
            

        }

        private void InitializeSession()
        {
            
            _emp = new CustomList<ASL.Hr.DAO.DemoEmpMaster>();
            _empMasterForSave = new CustomList<DemoEmpMaster>();
        }

        private void InitializeControls()
        {
            ddlempCodeKey.Visible = false;
            txtempCode.Visible = true;
            _emp = empManager.GetAllempMaster();


            if (_emp.Count != 0)
            {
                ddlempCodeKey.DataSource = _emp;
                ddlempCodeKey.DataTextField = "empCode";
                ddlempCodeKey.DataValueField = "empCode";
                ddlempCodeKey.DataBind();
                ddlempCodeKey.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlempCodeKey.SelectedIndex = 0;
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Using Class
            try
            {

                CustomList<ASL.Hr.DAO.DemoEmpMaster> lstemp = (CustomList<ASL.Hr.DAO.DemoEmpMaster>)_empMasterForSave;
                if (lstemp.IsNull() || lstemp.Count == 0)
                {
                    ASL.Hr.DAO.DemoEmpMaster newemp = new ASL.Hr.DAO.DemoEmpMaster();
                    lstemp.Add(newemp);
                }
                SetDataFromControlToObj(ref lstemp);
                            
                empManager.SaveEmp(ref lstemp);


                txtempCode.Visible = false;
                ddlempCodeKey.Visible = true;
                _emp = empManager.GetAllempMaster();

                ddlempCodeKey.DataSource = _emp;
                ddlempCodeKey.DataTextField = "empCode";
                ddlempCodeKey.DataValueField = "empCode";
                ddlempCodeKey.DataBind();
                ddlempCodeKey.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlempCodeKey.SelectedIndex = 0;
                
                ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                ddlempCodeKey.SelectedValue = lstemp[0].empCode.ToString();
            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
                
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
            #endregion
        }
           
        private void SetDataFromControlToObj(ref ASL.DATA.CustomList<DemoEmpMaster> lstemp)
        {
            ASL.Hr.DAO.DemoEmpMaster obj = lstemp[0];
            if (txtempCode.Visible.IsTrue())
            {
                obj.empCode = Convert.ToInt32(txtempCode.Text);              
                

            }
               
            else
            {
                obj.empCode = Convert.ToInt32(ddlempCodeKey.SelectedItem.Text);
            }
            obj.empName = txtempName.Text;
            obj.Doj = Convert.ToDateTime(txtdojDate.Text);
            obj.Doc = Convert.ToDateTime(txtdocDate.Text);
            
        }

        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            _empMasterForSave = new CustomList<ASL.Hr.DAO.DemoEmpMaster>();
            txtempCode.Visible = true;
            ddlempCodeKey.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {               

                CustomList<ASL.Hr.DAO.DemoEmpMaster> lstemp = new CustomList<DemoEmpMaster>();
                empMaster.empCode = Convert.ToInt32(ddlempCodeKey.SelectedValue);
                empMaster.empName = txtempName.Text;
                empMaster.Doj = Convert.ToDateTime(txtdojDate.Text);
                empMaster.Doc = Convert.ToDateTime(txtdocDate.Text);

                lstemp.Add(empMaster);

                if (lstemp.Count != 0)
                {
                    lstemp.ForEach(f => f.Delete());
                    empManager.DeleteEmp(lstemp);
                    InitializeSession();
                    _emp = empManager.GetAllempMaster();
                    this.SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {

            _empMasterForSave = new CustomList<ASL.Hr.DAO.DemoEmpMaster>();
            txtempCode.Visible = false;
            ddlempCodeKey.Visible = true;
        }

        #region DropDown
        protected void ddlempCodeKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomList<ASL.Hr.DAO.DemoEmpMaster> SR = empManager.GetSelectedemp(ddlempCodeKey.SelectedValue.ToInt());


            if (SR.Count != 0)
            {
                _empMasterForSave = SR;
                SetDataFromObjectToControl(ref SR);
            }

            //else CleareControls();


        }

        private void SetDataFromObjectToControl(ref CustomList<DemoEmpMaster> SR)
        {
            if (SR[0].IsNotNull())
            {
                txtempName.Text = SR[0].empName;
                txtdojDate.Text = SR[0].Doj.ToString();
                txtdocDate.Text = SR[0].Doc.ToString();
            }
            
        }
        
        #endregion

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //Session["Account"] = "DemoDataSet";
                Session["empCode"] = ddlempCodeKey.SelectedValue;
                Session["empName"] = txtdojDate.Text;
                Session["Doj"] = txtdojDate.Text;
                Session["Doc"] = txtdocDate.Text;
                Report.ReportPath = Server.MapPath(@"~\ASTReports\DemoReport.rdl");
                String script = "javascript:ShowReportViewer();";
                if (ClientScript.IsClientScriptBlockRegistered("scriptShowReportViewer").IsFalse())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptShowReportViewer", script, true);
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        


    }
           
}
