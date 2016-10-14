using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.DATA;
using System.Text;
using System.Data.SqlClient;
using ASL.Web.Framework;
using System.IO;
using Hr.Web.UI.EmployeeBasicInfo;
using System.Configuration;
using Hr.Web.Utils;
using System.Collections;

namespace Hr.Web.Controls
{
    public partial class EmployeeGeneralInfo : EmpBase
    {
        #region Fileds
        public readonly EmployeeManager _empManager;
        public readonly MonthlySalarProcessManager _salaryManager;
        #endregion

        #region Ctor
        public EmployeeGeneralInfo()
        {
            _empManager = new EmployeeManager();
            _salaryManager = new MonthlySalarProcessManager();
        }
        #endregion
        #region Session Variable
        private CustomList<Gen_LookupEnt> _BloodGroupList
        {
            get
            {
                if (Session["EmployeeBasicInfo_BloodGroupList"] == null)
                    return new CustomList<Gen_LookupEnt>();
                else
                    return (CustomList<Gen_LookupEnt>)Session["EmployeeBasicInfo_BloodGroupList"];
            }
            set
            {
                Session["EmployeeBasicInfo_BloodGroupList"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCombo();

                string empcode = Request.QueryString.Get("empcode");
                if (empcode.IsNotNullOrEmpty())
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "loadEmp_postback", "loadEmp_postback()", true);
                }
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);


                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "Pback")
                {
                    string empcode = Request.QueryString.Get("empcode");
                    var emp = _empManager.GetEmpByCode(empcode);
                    #region populate other tab
                    var page = this.Page as EmployeeBasicInformation;
                    page.PopulteControl(emp);
                    #endregion
                }
            }
        }

        private void PopulatePage(string empcode)
        {
            var emp = _empManager.GetEmpByCode(empcode);
            PopulateCombo();
            PopulateControl(emp);

            (this.Parent.FindControl("btnSave") as Button).Visible = false;
            (this.Parent.FindControl("btnUpdate") as Button).Visible = true;
            // (this.Parent.FindControl("btnDelete") as Button).Visible = true;
        }
        public void PopulateControl()
        {
            //var emp = _empManager.GetEmpByCode(txtEmpCode.Text);
            var emp = _empManager.GetEmpByCode("");
            PopulateCombo();
            PopulateControl(emp);
        }

        internal void PopulateControl(HRM_Emp searchEmp)
        {
            hfEmpKey.Value = searchEmp.EmpKey.ToString();
            EmpKey = searchEmp.EmpKey.ToString();
            if (searchEmp.Salutation != 0)
                ddlSalutation.SelectedValue = ddlSalutation.Items.FindByValue(searchEmp.Salutation.ToString()) == null ? "" : ddlSalutation.Items.FindByValue(searchEmp.Salutation.ToString()).Value;
            txtFirstName.Text = searchEmp.FirstName;
            txtMiddleName.Text = searchEmp.MiddleName;
            txtLastName.Text = searchEmp.LastName;
            txtNickName.Text = searchEmp.NickName;
            txtDateOfBirth.Text = searchEmp.DOB.ToShortDateString() == "1/1/0001" ? "" : searchEmp.DOB.ToString(ASL.STATIC.StaticInfo.GridDateFormat);
            int ServiceLength = txtDateOfBirth.Text =="" ? 0 : DateTime.Now.Subtract(DateTime.Parse(txtDateOfBirth.Text)).Days;
            txtYrs.Text = (ServiceLength / 365).ToString();
            txtYrs.Enabled = false;
            txtMonth.Text = ((ServiceLength % 365) / 30).ToString();
            txtMonth.Enabled = false;
            if (searchEmp.ReligionKey != 0)
                ddlRelegion.SelectedValue = ddlRelegion.Items.FindByValue(searchEmp.ReligionKey.ToString()) == null ? "" : ddlRelegion.Items.FindByValue(searchEmp.ReligionKey.ToString()).Value;
            if (searchEmp.EthnicKey != 0)
                ddlEthnicGroup.SelectedValue = ddlEthnicGroup.Items.FindByValue(searchEmp.EthnicKey.ToString()) == null ? "" : ddlEthnicGroup.Items.FindByValue(searchEmp.EthnicKey.ToString()).Value;
            if (!string.IsNullOrEmpty(searchEmp.BloodGroup))
                ddlBloodGroup.SelectedValue = ddlBloodGroup.Items.FindByValue(searchEmp.BloodGroup) == null ? "" : ddlBloodGroup.Items.FindByValue(searchEmp.BloodGroup).Value;
            ddlNationlity.SelectedValue = ddlNationlity.Items.FindByValue(searchEmp.Nationality) == null ? "" : ddlNationlity.Items.FindByValue(searchEmp.Nationality).Value;
            txtNationalID.Text = searchEmp.NationalID;
            if (!string.IsNullOrEmpty(searchEmp.Gender))
                ddlGender.SelectedValue = ddlGender.Items.FindByValue(searchEmp.Gender) == null ? "" : ddlGender.Items.FindByValue(searchEmp.Gender).Value;
            txtPassportNumber.Text = searchEmp.PassportNumber;
            txtTaxNumber.Text = searchEmp.TaxNumber;
            txtDrivingLicenceNumber.Text = searchEmp.DrivingLicenceNumber;
            txtFatherName.Text = searchEmp.FatherName;
            txtMotherName.Text = searchEmp.MotherName;
            if (searchEmp.Salutation != 0)
                ddlMaritalStatus.SelectedValue = ddlMaritalStatus.Items.FindByValue(searchEmp.MaritalStatus.ToString()) == null ? "" : ddlMaritalStatus.Items.FindByValue(searchEmp.MaritalStatus.ToString()).Value;
            txtSpouseName.Text = searchEmp.SpouseName;
            txtSpouseOccupation.Text = searchEmp.SpouseOccupation;
            if (searchEmp.NoOfChieldren.IsNotNull())
                txtNoOfChieldren.Text = searchEmp.NoOfChieldren.ToString();
            txtPhoneNo.Text = searchEmp.PhoneNo;
            txtLandPhone.Text = searchEmp.LandPhone;
            txtEmail.Text = searchEmp.Email;
            // if (searchEmp.Yrs.IsNotNull())
            //    txtYrs.Text = searchEmp.Yrs.ToString();
            // if (searchEmp.Month.IsNotNull())
            //    txtMonth.Text = searchEmp.Month.ToString();
            txtWeight.Text = searchEmp.Weight;
            txtHight.Text = searchEmp.Hight;
            txtPersonalRemarks.Text = searchEmp.PerRemarks;
            txtEmpStatus.Text = searchEmp.EmpStatus.ToString();
            txtRemarks.Text = searchEmp.Remarks;
            imgSignature.ImageUrl = ResolveUrl(searchEmp.Signature);
            (ctrlPictureUpload.FindControl("imgEmp") as Image).ImageUrl = ResolveUrl(searchEmp.EmpPicture);
        }

        private void GetAllOrgKey(int orgKey, out string comKey, out string branKey, out string depKey)
        {
            comKey = ""; branKey = ""; depKey = "";

            var allOrg = Organization.GetAllOrg();
            var currentOrg = allOrg.Find(x => x.OrgKey == orgKey);

            if (currentOrg.OrgCode.Length == 2)
                comKey = currentOrg.OrgKey.ToString();
            else if (currentOrg.OrgCode.Length == 4)
            {
                var comCode = new string(currentOrg.OrgCode.Take(2).ToArray());
                comKey = allOrg.Where(x => x.OrgCode.Length == 2 && x.OrgCode.Contains(comCode)).FirstOrDefault().OrgKey.ToString();
                branKey = currentOrg.OrgKey.ToString();
            }
            else if (currentOrg.OrgCode.Length == 6)
            {
                var comCode = new string(currentOrg.OrgCode.Take(2).ToArray());
                comKey = allOrg.Where(x => x.OrgCode.Length == 2 && x.OrgCode.Contains(comCode)).FirstOrDefault().OrgKey.ToString();

                var branCode = new string(currentOrg.OrgCode.Take(4).ToArray());
                branKey = allOrg.Where(x => x.OrgCode.Length == 4 && x.OrgCode.Contains(branCode)).FirstOrDefault().OrgKey.ToString();

                depKey = currentOrg.OrgKey.ToString();
            }
        }

        private void PopulateCombo()
        {
            #region Religion
            ddlRelegion.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Religion);
            ddlRelegion.DataTextField = "ElementName";
            ddlRelegion.DataValueField = "ElementKey";
            ddlRelegion.DataBind();
            ddlRelegion.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion

            #region Salutation
            ddlSalutation.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Salutation);
            ddlSalutation.DataTextField = "ElementName";
            ddlSalutation.DataValueField = "ElementKey";
            ddlSalutation.DataBind();
            ddlSalutation.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion

            #region Ethnic group
            ddlEthnicGroup.DataSource = _empManager.GetAllEthnic();
            ddlEthnicGroup.DataTextField = "EthnicName";
            ddlEthnicGroup.DataValueField = "EthnicKey";
            ddlEthnicGroup.DataBind();
            ddlEthnicGroup.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion

            #region Blood group
            _BloodGroupList = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.BloodGroup);
            ddlBloodGroup.DataSource = _BloodGroupList;
            ddlBloodGroup.DataTextField = "ElementName";
            ddlBloodGroup.DataValueField = "ElementKey";
            ddlBloodGroup.DataBind();
            ddlBloodGroup.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion

            #region nationality
            ddlNationlity.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Nationality);
            ddlNationlity.DataTextField = "ElementName";
            ddlNationlity.DataValueField = "ElementKey";
            ddlNationlity.DataBind();
            ddlNationlity.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion

            #region Marital Status
            ddlMaritalStatus.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.MaritalStatus);
            ddlMaritalStatus.DataTextField = "ElementName";
            ddlMaritalStatus.DataValueField = "ElementKey";
            ddlMaritalStatus.DataBind();
            ddlMaritalStatus.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion

            #region Marital Status
            ddlGender.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Gender);
            ddlGender.DataTextField = "ElementName";
            ddlGender.DataValueField = "ElementKey";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
        }

        public void SaveEmpGeneralInfo(ArrayList empInfo)
        {
            var empGenInfo = new HRM_Emp();
            GetValueFromControl(empGenInfo);

            var list = new CustomList<HRM_Emp>() { empGenInfo };
            empInfo.Add(list);

            imgSignature.ImageUrl = ResolveUrl(empGenInfo.Signature);
            (ctrlPictureUpload.FindControl("imgEmp") as Image).ImageUrl = ResolveUrl(empGenInfo.EmpPicture);
        }

        private void GetValueFromControl(HRM_Emp empInfo)
        {
            if (hfEmpKey.Value.IsNullOrEmpty())
                hfEmpKey.Value = "0";
            empInfo.EmpKey = Convert.ToInt64(hfEmpKey.Value);
            TextBox txtEmpCode = (TextBox)Parent.FindControl("ctrlEmpSearch2").FindControl("txtSearch");
            empInfo.EmpCode = txtEmpCode.Text;
            empInfo.Salutation = ddlSalutation.SelectedValue.ToInt();
            empInfo.FirstName = txtFirstName.Text;
            empInfo.MiddleName = txtMiddleName.Text;
            empInfo.LastName = txtLastName.Text;
            empInfo.NickName = txtNickName.Text;
            empInfo.EmpName = String.Format("{0} / {1} {2}", txtFirstName.Text, txtMiddleName.Text, txtLastName.Text);
            if (!string.IsNullOrEmpty(txtDateOfBirth.Text))
                empInfo.DOB = txtDateOfBirth.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
            if (ddlRelegion.SelectedValue != "")
                empInfo.ReligionKey = ddlRelegion.SelectedValue.ToInt();
            if (ddlEthnicGroup.SelectedValue != "")
                empInfo.EthnicKey = ddlEthnicGroup.SelectedValue.ToInt();
            if (ddlBloodGroup.SelectedValue != "")
                empInfo.BloodGroup = ddlBloodGroup.SelectedValue;
            empInfo.Nationality = ddlNationlity.SelectedValue;
            empInfo.NationalID = txtNationalID.Text;
            empInfo.Gender = ddlGender.SelectedValue;
            empInfo.PassportNumber = txtPassportNumber.Text;
            empInfo.TaxNumber = txtTaxNumber.Text;
            empInfo.DrivingLicenceNumber = txtDrivingLicenceNumber.Text;
            empInfo.Remarks = txtRemarks.Text;
            empInfo.FatherName = txtFatherName.Text;
            empInfo.MotherName = txtMotherName.Text;
            empInfo.MaritalStatus = ddlMaritalStatus.SelectedValue.ToInt();
            empInfo.SpouseName = txtSpouseName.Text;
            empInfo.SpouseOccupation = txtSpouseOccupation.Text;
            empInfo.NoOfChieldren = txtNoOfChieldren.Text.IfEmptyOrNullThenNull();
            empInfo.PhoneNo = txtPhoneNo.Text;
            empInfo.LandPhone = txtLandPhone.Text;
            empInfo.Email = txtEmail.Text;
            empInfo.Yrs = txtYrs.Text.IfEmptyOrNullThenNull();
            empInfo.Month = txtMonth.Text.IfEmptyOrNullThenNull();
            empInfo.Weight = txtWeight.Text;
            empInfo.Hight = txtHight.Text;
            empInfo.PerRemarks = txtPersonalRemarks.Text;
            empInfo.EmpPicture = GetEmpPicture() == string.Empty ? (ctrlPictureUpload.FindControl("imgEmp") as Image).ImageUrl : GetEmpPicture();
            empInfo.Signature = GetSignature() == string.Empty ? imgSignature.ImageUrl : GetSignature();
            if (txtEmpStatus.Text == "")
                empInfo.EmpStatus = "InActive";
            else
                empInfo.EmpStatus = txtEmpStatus.Text;
        }

        private string GetSignature()
        {
            var picture = fuSignature;

            if (picture != null && !string.IsNullOrEmpty(picture.FileName))
            {
                var fileInfo = new FileInfo(picture.FileName);
                var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                var path = Server.MapPath(ConfigurationManager.AppSettings["empImagePath"]) + fileName;
                var dbPath = ConfigurationManager.AppSettings["empImagePath"] + fileName;
                File.WriteAllBytes(path, picture.FileBytes);
                return dbPath;
            }
            return string.Empty;
        }

        private string GetEmpPicture()
        {
            var picture = ctrlPictureUpload.FindControl("btnPictureLoad") as FileUpload;

            if (picture != null && !string.IsNullOrEmpty(picture.FileName))
            {
                var fileInfo = new FileInfo(picture.FileName);
                var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                var path = Server.MapPath(ConfigurationManager.AppSettings["empImagePath"]) + fileName;
                var dbPath = ConfigurationManager.AppSettings["empImagePath"] + fileName;
                File.WriteAllBytes(path, picture.FileBytes);
                return dbPath;
            }
            return string.Empty;
        }

        internal void UpdateEmpGeneralInfo(ArrayList empInfo)
        {
            var genInfo = new HRM_Emp();
            GetValueFromControl(genInfo);
            genInfo.SetModified();

            var empInfoList = new CustomList<HRM_Emp>() { genInfo };
            empInfo.Add(empInfoList);

            imgSignature.ImageUrl = ResolveUrl(genInfo.Signature);
            (ctrlPictureUpload.FindControl("imgEmp") as Image).ImageUrl = ResolveUrl(genInfo.EmpPicture);
        }

        internal bool DeleteEmpGeneralInfo()
        {
            var empInfo = new HRM_Emp();
            GetValueFromControl(empInfo);
            empInfo.Delete();

            var empInfoList = new CustomList<HRM_Emp>() { empInfo };
            return _empManager.SaveEmpGeneralInfo(ref empInfoList);
        }
    }
}