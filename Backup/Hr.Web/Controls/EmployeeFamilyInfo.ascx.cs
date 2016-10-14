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
    public partial class EmployeeFamilyInfo : EmpBase
    {
        #region Fileds
        public readonly EmployeeManager _empManager;
        public readonly MonthlySalarProcessManager _salaryManager;
        #endregion

        #region Properties
        private CustomList<HRM_EmpFamDet> EmpFamDetList
        {
            get
            {
                if (Session["EmployeeBasicInformation_EmpFamDetList"] == null)
                    return new CustomList<HRM_EmpFamDet>();
                else
                    return (CustomList<HRM_EmpFamDet>)Session["EmployeeBasicInformation_EmpFamDetList"];
            }
            set
            {
                Session["EmployeeBasicInformation_EmpFamDetList"] = value;
            }
        }
        private CustomList<Gen_Relation> RelationList
        {
            get
            {
                if (Session["EmployeeBasicInformation_RelationList"] == null)
                    return new CustomList<Gen_Relation>();
                else
                    return (CustomList<Gen_Relation>)Session["EmployeeBasicInformation_RelationList"];
            }
            set
            {
                Session["EmployeeBasicInformation_RelationList"] = value;
            }
        }
        private CustomList<Gen_LookupEnt> OccupationList
        {
            get
            {
                if (Session["EmployeeBasicInformation_OccupationList"] == null)
                    return new CustomList<Gen_LookupEnt>();
                else
                    return (CustomList<Gen_LookupEnt>)Session["EmployeeBasicInformation_OccupationList"];
            }
            set
            {
                Session["EmployeeBasicInformation_OccupationList"] = value;
            }
        }
        #endregion

        #region Ctor
        public EmployeeFamilyInfo()
        {
            _empManager = new EmployeeManager();
            _salaryManager = new MonthlySalarProcessManager();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SessionInitialization();
                PopulateCombo();
            }
        }

        private void SessionInitialization()
        {
            EmpFamDetList = new CustomList<HRM_EmpFamDet>();
            RelationList = _empManager.GetAllRelation();
            OccupationList = _empManager.GetAllGen_LookupEnt(enumsHr.enumEntitySetup.Occupation);
        }

        private void PopulateCombo()
        {
            #region Occupation
            ddlFILOccupation.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Occupation);
            ddlFILOccupation.DataTextField = "ElementName";
            ddlFILOccupation.DataValueField = "ElementKey";
            ddlFILOccupation.DataBind();
            ddlFILOccupation.Items.Insert(0, new ListItem() { Value = "", Text = "" });

            ddlFOccupation.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Occupation);
            ddlFOccupation.DataTextField = "ElementName";
            ddlFOccupation.DataValueField = "ElementKey";
            ddlFOccupation.DataBind();
            ddlFOccupation.Items.Insert(0, new ListItem() { Value = "", Text = "" });

            ddlMILOccupation.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Occupation);
            ddlMILOccupation.DataTextField = "ElementName";
            ddlMILOccupation.DataValueField = "ElementKey";
            ddlMILOccupation.DataBind();
            ddlMILOccupation.Items.Insert(0, new ListItem() { Value = "", Text = "" });

            ddlMOccupation.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Occupation);
            ddlMOccupation.DataTextField = "ElementName";
            ddlMOccupation.DataValueField = "ElementKey";
            ddlMOccupation.DataBind();
            ddlMOccupation.Items.Insert(0, new ListItem() { Value = "", Text = "" });

            ddlOccupation.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Occupation);
            ddlOccupation.DataTextField = "ElementName";
            ddlOccupation.DataValueField = "ElementKey";
            ddlOccupation.DataBind();
            ddlOccupation.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion

            #region Marital Status
            ddlMeritalStatus.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.MaritalStatus);
            ddlMeritalStatus.DataTextField = "ElementName";
            ddlMeritalStatus.DataValueField = "ElementKey";
            ddlMeritalStatus.DataBind();
            ddlMeritalStatus.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
        }

        internal void PopulateControl()
        {
            var famList = _empManager.GetAllEmpFamByEmpKey(EmpKey);
            var fam = new HRM_EmpFamily();
            if (famList == null || famList.Count == 0) return;
            else fam = famList[0];

            hfEmpFamKey.Value = fam.EmpFamilyKey.ToString();
            txtDateOfBirth.Text = fam.SpouseDOB.ToString(ASL.STATIC.StaticInfo.GridDateFormat);
            txtFatherInLawsName.Text = fam.FatherInLaw;
            txtFathersName.Text = fam.Father;
            txtFDateOfBirth.Text = fam.FatherDOB.ToString(ASL.STATIC.StaticInfo.GridDateFormat);
            txtMDateOfBirth.Text = fam.MotherDOB.ToString(ASL.STATIC.StaticInfo.GridDateFormat);
            txtMotherInLowsName.Text = fam.MotherInLaw;
            txtMothersName.Text = fam.Mother;
            txtSpouseName.Text = fam.SpouseName;
            txtComment.Text = fam.Remark;
            if (fam.FatherInLawOccupation > 0)
                ddlFILOccupation.SelectedValue = fam.FatherInLawOccupation.ToString();
            if (fam.FatherOccupation > 0)
                ddlFOccupation.SelectedValue = fam.FatherOccupation.ToString();
            if (fam.MeritalStatus > 0)
                ddlMeritalStatus.SelectedValue = fam.MeritalStatus.ToString();
            if (fam.MotherInLawOccupation > 0)
                ddlMILOccupation.SelectedValue = fam.MotherInLawOccupation.ToString();
            if (fam.MotherOccupation > 0)
                ddlMOccupation.SelectedValue = fam.MotherOccupation.ToString();
            if (fam.SpouseOccupation > 0)
                ddlOccupation.SelectedValue = fam.SpouseOccupation.ToString();

            // EmpFamDetList = _empManager.GetAllFamDetByFamKey(fam.EmpFamilyKey.ToString());
        }

        private void GetValueFromControl(HRM_EmpFamily fam)
        {
            fam.EmpKey = EmpKey.ToInt();
            fam.EmpFamilyKey = hfEmpFamKey.Value.ToInt();

            fam.SpouseDOB = txtDateOfBirth.Text == "" ? DateTime.MinValue : txtDateOfBirth.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
            fam.FatherInLaw = txtFatherInLawsName.Text;
            fam.Father = txtFathersName.Text;
            fam.FatherDOB = txtFDateOfBirth.Text == "" ? DateTime.MinValue : txtFDateOfBirth.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
            fam.MotherDOB = txtMDateOfBirth.Text == "" ? DateTime.MinValue : txtMDateOfBirth.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
            fam.MotherInLaw = txtMotherInLowsName.Text;
            fam.Mother = txtMothersName.Text;
            fam.SpouseName = txtSpouseName.Text;

            fam.Remark = txtComment.Text;

            if (ddlFILOccupation.SelectedValue != "")
                fam.FatherInLawOccupation = Convert.ToInt32(ddlFILOccupation.SelectedValue);
            if (ddlFOccupation.SelectedValue != "")
                fam.FatherOccupation = Convert.ToInt32(ddlFOccupation.SelectedValue);
            if (ddlMeritalStatus.SelectedValue != "")
                fam.MeritalStatus = ddlMeritalStatus.SelectedValue.ToInt();
            if (ddlMILOccupation.SelectedValue != "")
                fam.MotherInLawOccupation = Convert.ToInt32(ddlMILOccupation.SelectedValue);
            if (ddlMOccupation.SelectedValue != "")
                fam.MotherOccupation = Convert.ToInt32(ddlMOccupation.SelectedValue);
            if (ddlOccupation.SelectedValue != "")
                fam.SpouseOccupation = Convert.ToInt32(ddlOccupation.SelectedValue);
        }

        public void ClearControl()
        {
            txtDateOfBirth.Text = "";
            txtFatherInLawsName.Text = "";
            txtFathersName.Text = "";
            txtFDateOfBirth.Text = "";
            txtMDateOfBirth.Text = "";
            txtMotherInLowsName.Text = "";
            txtMothersName.Text = "";
            txtSpouseName.Text = "";
            ddlFILOccupation.SelectedValue = "";
            ddlFOccupation.SelectedValue = "";
            ddlMeritalStatus.SelectedValue = "";
            ddlMILOccupation.SelectedValue = "";
            ddlMOccupation.SelectedValue = "";
            ddlOccupation.SelectedValue = "";

            SessionInitialization();
        }

        internal void Save(ArrayList empInfo)
        {
            var empFam = new HRM_EmpFamily();
            GetValueFromControl(empFam);

            var empFamList = new CustomList<HRM_EmpFamily>() { empFam };
            var empFamDet = (CustomList<HRM_EmpFamDet>)EmpFamDetList;

            empInfo.Add(empFamList);
            empInfo.Add(empFamDet);
        }

        internal void Update(ArrayList empInfo)
        {
            if (Session["EmpKey"] == null)
                return;

            var empKey = Session["EmpKey"].ToString();

            var empAddr = new HRM_EmpFamily();
            GetValueFromControl(empAddr);
            var existingFamily = _empManager.GetAllEmpFamByEmpKey(empKey);
            if (existingFamily.Count != 0)
                empAddr.SetModified();

            var empFam = new CustomList<HRM_EmpFamily>() { empAddr };
            var empFamDet = (CustomList<HRM_EmpFamDet>)EmpFamDetList;
            empInfo.Add(empFam);
            empInfo.Add(empFamDet);
        }

        internal void Delete()
        {
            var empAddr = new HRM_EmpFamily();
            GetValueFromControl(empAddr);
            empAddr.Delete();

            var empFam = new CustomList<HRM_EmpFamily>() { empAddr };
            var empFamDet = (CustomList<HRM_EmpFamDet>)EmpFamDetList;
            empFamDet.ForEach(x => x.Delete());

            _empManager.SaveChild(ref empFam, ref empFamDet);
            _empManager.SaveEmpFam(ref empFam, ref empFamDet);
        }
    }
}