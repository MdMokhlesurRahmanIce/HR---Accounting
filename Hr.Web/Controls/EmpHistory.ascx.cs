using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.DATA;
using ASL.Hr.DAO;
using Hr.Web.Utils;
using System.Collections;

namespace Hr.Web.Controls
{
    public partial class EmpHistory : EmpBase
    {
        #region Fileds
        public readonly EmployeeManager _empManager;
        public readonly MonthlySalarProcessManager _salaryManager;
        #endregion

        #region Properties
        private CustomList<HRM_EmpEmployment> EmpHistList
        {
            get
            {
                if (Session["EmployeeBasicInformation_EmpHistList"] == null)
                    return new CustomList<HRM_EmpEmployment>();
                else
                    return (CustomList<HRM_EmpEmployment>)Session["EmployeeBasicInformation_EmpHistList"];
            }
            set
            {
                Session["EmployeeBasicInformation_EmpHistList"] = value;
            }
        }
        private CustomList<Designation> DesigList
        {
            get
            {
                if (Session["EmployeeBasicInformation_DesigList"] == null)
                    return new CustomList<Designation>();
                else
                    return (CustomList<Designation>)Session["EmployeeBasicInformation_DesigList"];
            }
            set
            {
                Session["EmployeeBasicInformation_DesigList"] = value;
            }
        }
        #endregion

        #region Ctor
        public EmpHistory()
        {
            _empManager = new EmployeeManager();
            _salaryManager = new MonthlySalarProcessManager();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                InitializationSession();
                //PopulateCombo();                
            }
        }

        public void InitializationSession()
        {
            // EmpHistList = _empManager.GetAllEmpHistByEmpKey(EmpKey);
            //if (EmpHistList == null)
            EmpHistList = new CustomList<HRM_EmpEmployment>();
            DesigList = _empManager.GetAllDesignation();
        }

        private void PopulateCombo()
        {
            #region Designation
            //ddlDesignation.DataSource = _empManager.GetAllDesignation();
            //ddlDesignation.DataTextField = "DesigName";
            //ddlDesignation.DataValueField = "DesigKey";
            //ddlDesignation.DataBind();
            //ddlDesignation.Items.Insert(0, new ListItem() { Value = "0", Text = "" });
            #endregion
        }

        internal void PopulateControl()
        {
            InitializationSession();

            //hfEmpHistKey.Value = eh.EmpEmployKey.ToString();

            //txtAddress.Text = eh.EmployerAddr;
            //txtEmpName.Text = eh.EmployerName;
            //txtFrom.Text = eh.DateFrom.ToShortDateString();
            //txtJobDescription.Text = eh.JobDesc;
            //txtRemarks.Text = eh.Remark;
            //txtTo.Text = eh.DateTo.ToShortDateString();
            //ddlDesignation.SelectedValue = eh.LastDesigKey.ToString();
        }

        private void GetValueFromControl(HRM_EmpEmployment eh)
        {
            var empKey = Session["EmpKey"].ToString();

            //eh.DateFrom = Convert.ToDateTime(txtFrom.Text);
            //eh.DateTo = Convert.ToDateTime(txtTo.Text);
            //eh.EmpKey = Convert.ToInt64(empKey);
            //eh.EmployerAddr = txtAddress.Text;
            //eh.EmployerName = txtEmpName.Text;
            //eh.JobDesc = txtJobDescription.Text;
            //eh.LastDesigKey = ddlDesignation.SelectedValue.ToInt();
            //eh.Remark = txtRemarks.Text;
        }

        //private void ClearControl()
        //{
        //    //txtAddress.Text = "";
        //    //txtEmpName.Text = "";
        //    //txtFrom.Text = "";
        //    //txtJobDescription.Text = "";
        //    //txtRemarks.Text = "";
        //    //txtTo.Text = "";
        //    //ddlDesignation.SelectedValue = "0";
        //}

        internal void Save(ArrayList empInfo)
        {
            var empHist = (CustomList<HRM_EmpEmployment>)EmpHistList;
            empInfo.Add(empHist);
        }

        internal void Update(ArrayList empInfo)
        {
            Save(empInfo);
            //var empKey = Session["EmpKey"].ToString();
            //var existingAddr = _empManager.GetAllEmpFamByEmpKey(empKey);
            //if (existingAddr.Count == 0)
            //    Save();

            //var empAddr = new HRM_EmpFamily();
            //GetValueFromControl(empAddr);
            //empAddr.SetUnchanged();
            //empAddr.SetModified();

            //var empFam = new CustomList<HRM_EmpFamily>() { empAddr };
            //var empFamDet = (CustomList<HRM_EmpFamDet>)EmpFamDetList;
            //_empManager.SaveEmpFam(ref empFam, ref empFamDet);
        }

        internal void Delete()
        {
            EmpHistList.ForEach(x => x.Delete());
            //Save();
            //var empAddr = new HRM_EmpFamily();
            //GetValueFromControl(empAddr);
            //empAddr.SetUnchanged();
            //empAddr.SetDetached();

            //var empFam = new CustomList<HRM_EmpFamily>() { empAddr };
            //var empFamDet = (CustomList<HRM_EmpFamDet>)EmpFamDetList;
            //_empManager.SaveEmpFam(ref empFam, ref empFamDet);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var eh = new HRM_EmpEmployment();
            GetValueFromControl(eh);
            EmpHistList.Add(eh);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var empHistKey = hfEmpHistKey.Value.ToInt();
            var eh = EmpHistList.Find(x => x.EmpEmployKey == empHistKey);
            GetValueFromControl(eh);
            eh.SetModified();
        }
    }
}