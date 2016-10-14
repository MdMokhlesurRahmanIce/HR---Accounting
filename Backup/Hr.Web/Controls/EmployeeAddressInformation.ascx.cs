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
using Hr.Web.Utils;
using System.Collections;

namespace Hr.Web.Controls
{
    public partial class EmployeeAddressInformation : EmpBase
    {
        #region property

        private CustomList<EmployeeEmergencyInfo> EmployeeEmergencyInfoList
        {
            get
            {
                if (Session["EmployeeBasicInfo_EmployeeEmergencyInfoList"] == null)
                    return new CustomList<EmployeeEmergencyInfo>();
                else
                    return (CustomList<EmployeeEmergencyInfo>)Session["EmployeeBasicInfo_EmployeeEmergencyInfoList"];
            }
            set
            {
                Session["EmployeeBasicInfo_EmployeeEmergencyInfoList"] = value;
            }
        }
        #endregion
        #region Fileds
        public readonly EmployeeManager _empManager;
        public readonly MonthlySalarProcessManager _salaryManager;
        #endregion

        #region Ctor
        public EmployeeAddressInformation()
        {
            _empManager = new EmployeeManager();
            _salaryManager = new MonthlySalarProcessManager();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopulateCombo();
                InitializeSession();
            }
        }

        internal void PopulateCombo()
        {
            txtPreCOL.Visible = false;
            
            txtVillageLo.Visible = false;

            txtPerVillLo.Visible = false;
            txtPerCOLo.Visible = false;
            
            #region Country
            CustomList<Gen_Country> CountryList = _empManager.GetAllCountry();
            ddlCountry.DataSource = CountryList;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryKey";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem() { Value = "", Text = "" });

            ddlPerCountry.DataSource = CountryList;
            ddlPerCountry.DataTextField = "CountryName";
            ddlPerCountry.DataValueField = "CountryKey";
            ddlPerCountry.DataBind();
            ddlPerCountry.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region District
            CustomList<Gen_District> DistrictList = _empManager.GetAllDistrict();
            ddlDistrict.DataSource = DistrictList;
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "DistrictKey";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem() { Value = "", Text = "" });

            ddlPerDistrict.DataSource = DistrictList;
            ddlPerDistrict.DataTextField = "DistrictName";
            ddlPerDistrict.DataValueField = "DistrictKey";
            ddlPerDistrict.DataBind();
            ddlPerDistrict.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region City
            CustomList<Gen_LookupEnt> CityList = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.City);
            ddlCity.DataSource = CityList;
            ddlCity.DataTextField = "ElementName";
            ddlCity.DataValueField = "ElementKey";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem() { Value = "", Text = "" });

            ddlPerCity.DataSource = CityList;
            ddlPerCity.DataTextField = "ElementName";
            ddlPerCity.DataValueField = "ElementKey";
            ddlPerCity.DataBind();
            ddlPerCity.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region State
            CustomList<Gen_LookupEnt> StateList = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.State);
            ddlState.DataSource = StateList;
            ddlState.DataTextField = "ElementName";
            ddlState.DataValueField = "ElementKey";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem() { Value = "", Text = "" });

            ddlPerState.DataSource = StateList;
            ddlPerState.DataTextField = "ElementName";
            ddlPerState.DataValueField = "ElementKey";
            ddlPerState.DataBind();
            ddlPerState.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
        }

        public void InitializeSession()
        {
            try
            {
                EmployeeEmergencyInfoList = new CustomList<EmployeeEmergencyInfo>();
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        internal void PopulateControl()
        {
            if (EmpKey == "0")
                return;

            HRM_EmpAddr addr = _empManager.GetAllEmpAddrByEmpKey(EmpKey).FirstOrDefault();
            if (addr == null) addr = new HRM_EmpAddr();
            EmployeeEmergencyInfoList = new CustomList<EmployeeEmergencyInfo>();
            EmployeeEmergencyInfoList = _empManager.GetAllEmployeeEmergencyInfo(Convert.ToInt64(EmpKey));

            hfEmpAddrKey.Value = addr.EmpAddrKey.ToString();

            ddlCountry.SelectedValue = ddlCountry.Items.FindByValue(addr.PreCountryKey.ToString()) == null ? "" : ddlCountry.Items.FindByValue(addr.PreCountryKey.ToString()).Value;
            ddlDistrict.SelectedValue = ddlDistrict.Items.FindByValue(addr.PreDistrictKey.ToString()) == null ? "" : ddlDistrict.Items.FindByValue(addr.PreDistrictKey.ToString()).Value;
            ddlCity.SelectedValue = ddlCity.Items.FindByValue(addr.PreCity.ToString()) == null ? "" : ddlCity.Items.FindByValue(addr.PreCity.ToString()).Value;
            ddlState.SelectedValue = ddlState.Items.FindByValue(addr.PreState.ToString()) == null ? "" : ddlState.Items.FindByValue(addr.PreState.ToString()).Value;
            txtPS.Text = addr.PrePS;
            txtPSLo.Text = addr.BPrePS;
            txtPostOffice.Text = addr.PrePO;
            txtPostalCodeLo.Text = addr.BPrePO;
            txtPreCO.Text = addr.CareOf;
            txtPreCOL.Text = addr.BCareOf;
            txtPostOfficeLo.Text = addr.PrePO;
            txtVillage.Text = addr.PreVillage;
            txtVillageLo.Text = addr.BPreVillage;
            txtPostalCode.Text = addr.PrePostalCode;
            txtPostalCodeLo.Text = addr.BPrePostalCode;
            txtAdditional.Text = addr.PreAdditional;
            txtAdditionalLo.Text = addr.BPreAdditional;

            ddlPerCountry.SelectedValue = ddlPerCountry.Items.FindByValue(addr.PerCountryKey.ToString()) == null ? "" : ddlPerCountry.Items.FindByValue(addr.PerCountryKey.ToString()).Value;
            ddlPerDistrict.SelectedValue = ddlPerDistrict.Items.FindByValue(addr.PerDistrictKey.ToString()) == null ? "" : ddlPerDistrict.Items.FindByValue(addr.PerDistrictKey.ToString()).Value;
            ddlPerCity.SelectedValue = ddlPerCity.Items.FindByValue(addr.PerCity.ToString()) == null ? "" : ddlPerCity.Items.FindByValue(addr.PerCity.ToString()).Value;
            ddlPerState.SelectedValue = ddlPerState.Items.FindByValue(addr.PerState.ToString()) == null ? "" : ddlPerState.Items.FindByValue(addr.PerState.ToString()).Value;
            txtPerPS.Text = addr.PerPS;
            txtPerPSLo.Text = addr.BPerPS;
            txtPerPostOffice.Text = addr.PerPO;
            txtPerPostOfficeLO.Text = addr.BPerPO;
            txtPerCO.Text = addr.PerCareOf;
            txtPerCOLo.Text = addr.BPerCareOf;
            txtPerVill.Text = addr.PerVillage;
            txtPerVillLo.Text = addr.BPerVillage;
            txtPerPC.Text = addr.PerPostalCode;
            txtPerPCLo.Text = addr.BPrePostalCode;
            txtPerAdditional.Text = addr.PerAdditional;
            txtPerAdditionalLo.Text = addr.BPerAdditional;
        }

        internal void GetValueFromControl(HRM_EmpAddr addr)
        {
            addr.EmpKey = EmpKey.ToInt();

            addr.EmpAddrKey = hfEmpAddrKey.Value.ToInt();

            addr.PreCountryKey = ddlCountry.SelectedValue.IfEmptyOrNullThenNull();
            addr.PreDistrictKey = ddlDistrict.SelectedValue.IfEmptyOrNullThenNull();
            addr.PreCity = ddlCity.SelectedValue.IfEmptyOrNullThenNull();
            addr.PreState = ddlState.SelectedValue.IfEmptyOrNullThenNull();
            addr.PrePS = txtPS.Text;
            addr.PrePO = txtPostOfficeLo.Text;
            addr.BPrePS = txtPSLo.Text;
            addr.PrePO = txtPostOffice.Text;
            addr.BPrePO = txtPostalCodeLo.Text;
            addr.CareOf = txtPreCO.Text;
            addr.BCareOf = txtPreCOL.Text;
            addr.PreVillage = txtVillage.Text;
            addr.BPreVillage = txtVillageLo.Text;
            addr.PrePostalCode = txtPostalCode.Text;
            addr.BPrePostalCode = txtPostalCodeLo.Text;
            addr.PreAdditional = txtAdditional.Text;
            addr.BPreAdditional = txtAdditionalLo.Text;

            addr.PerCountryKey = ddlPerCountry.SelectedValue.IfEmptyOrNullThenNull();
            addr.PerDistrictKey = ddlPerDistrict.SelectedValue.IfEmptyOrNullThenNull();
            addr.PerCity = ddlPerCity.SelectedValue.IfEmptyOrNullThenNull();
            addr.PerState = ddlPerState.SelectedValue.IfEmptyOrNullThenNull();
            addr.PerPS = txtPerPS.Text;
            addr.BPerPS = txtPerPSLo.Text;
            addr.PerPO = txtPerPostOffice.Text;
            addr.BPerPO = txtPerPostOfficeLO.Text;
            addr.PerCareOf = txtPerCO.Text;
            addr.BPerCareOf = txtPerCOLo.Text;
            addr.PerVillage = txtPerVill.Text;
            addr.BPerVillage = txtPerVillLo.Text;
            addr.PerPostalCode = txtPerPC.Text;
            addr.BPrePostalCode = txtPerPCLo.Text;
            addr.PerAdditional = txtPerAdditional.Text;
            addr.BPerAdditional = txtPerAdditionalLo.Text;
        }

        internal void SaveEmpAddr(ArrayList empInfo)
        {
            var empAddr = new HRM_EmpAddr();
            GetValueFromControl(empAddr);
            var list = new CustomList<HRM_EmpAddr>() { empAddr };
            empInfo.Add(list);
            CustomList<EmployeeEmergencyInfo> EmergencyList = (CustomList<EmployeeEmergencyInfo>)EmployeeEmergencyInfoList;
            empInfo.Add(EmergencyList);
        }

        internal void UpdateEmpAddr(ArrayList empInfo)
        {
            var empAddr = new HRM_EmpAddr();
            GetValueFromControl(empAddr);
            CustomList<HRM_Emp> empList=(CustomList<HRM_Emp>)empInfo[0];
            var existingAddr = _empManager.GetAllEmpAddrByEmpKey(empList[0].EmpKey.ToString());
            if (existingAddr.Count != 0)
                empAddr.SetModified();

            var empInfoList = new CustomList<HRM_EmpAddr>() { empAddr };
            empInfo.Add(empInfoList);
            CustomList<EmployeeEmergencyInfo> EmergencyList = (CustomList<EmployeeEmergencyInfo>)EmployeeEmergencyInfoList;
            empInfo.Add(EmergencyList);
        }

        internal bool DeleteEmpAddr()
        {
            var empAddr = new HRM_EmpAddr();
            GetValueFromControl(empAddr);
            empAddr.Delete();

            var empInfoList = new CustomList<HRM_EmpAddr>() { empAddr };
            return _empManager.SaveEmpAddr(ref empInfoList);
        }
    }
}