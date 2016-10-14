using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using ASL.DATA;
using System.Data.SqlClient;
using ASL.Security.BLL;
using ASL.Security.DAO;
using ASL.STATIC;
using ASL.Hr.DAO;
using ASL.Hr.BLL;
using ReportSuite.BLL;
using ReportSuite.DAO;
using ASL.Web.Framework;
using System.Text.RegularExpressions;
using Enc = ASL.STATIC.EncDec;
using ASL.DAL;
using ACC.DAO;
using ACC.BLL;


namespace Hr.Web.GridHelperClasses
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DataHandler : IHttpHandler, IRequiresSessionState
    {
        private String SessionVarName { get; set; }
        private DataCallBackMode callBackMode;
        private DataCallBackMode DataCallMode
        {
            get
            {
                ResolveCallBackMode();
                return callBackMode;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                CallbackFunction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ResolveCallBackMode()
        {
            try
            {
                String callMode = HttpContext.Current.Request.QueryString["CallMode"];
                callBackMode = (DataCallBackMode)StaticInfo.GetEnumValue(typeof(DataCallBackMode), callMode);
                if (callMode.CompareTo("DuplicateBankNameCheck").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateBankNameCheck;
                }
                else if (callMode.CompareTo("getRowCount").IsZero())
                {
                    callBackMode = DataCallBackMode.getRowCount;
                }
                else if (callMode.CompareTo("AllSelectOrUnselect").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectOrUnselect;
                }
                else if (callMode.CompareTo("ShowAllCheckOrUncheck").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowAllCheckOrUncheck;
                }
                else if (callMode.CompareTo("PopulateGrideWithMenu").IsZero())
                {
                    callBackMode = DataCallBackMode.PopulateGrideWithMenu;
                }
                else if (callMode.CompareTo("AllSelectCheckedOrUnchecked").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectCheckedOrUnchecked;
                }
                else if (callMode.CompareTo("AllInsertCheckedOrUnchecked").IsZero())
                {
                    callBackMode = DataCallBackMode.AllInsertCheckedOrUnchecked;
                }
                else if (callMode.CompareTo("AllUpdateCheckedOrUnchecked").IsZero())
                {
                    callBackMode = DataCallBackMode.AllUpdateCheckedOrUnchecked;
                }
                else if (callMode.CompareTo("AllDeleteCheckedOrUnchecked").IsZero())
                {
                    callBackMode = DataCallBackMode.AllDeleteCheckedOrUnchecked;
                }
                else if (callMode.CompareTo("MenuAllCheckOrUncheck").IsZero())
                {
                    callBackMode = DataCallBackMode.MenuAllCheckOrUncheck;
                }
                else if (callMode.CompareTo("GetCompanyWiseEmpList").IsZero())
                {
                    callBackMode = DataCallBackMode.GetCompanyWiseEmpList;
                }
                else if (callMode.CompareTo("ShowAllEmpForAttProcess").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowAllEmpForAttProcess;
                }
                else if (callMode.CompareTo("ModifyAttProcess").IsZero())
                {
                    callBackMode = DataCallBackMode.ModifyAttProcess;
                }
                else if (callMode.CompareTo("ClearEmployeeAttendanceGrid").IsZero())
                {
                    callBackMode = DataCallBackMode.ClearEmployeeAttendanceGrid;
                }
                else if (callMode.CompareTo("IsDefaultEmpAtt").IsZero())
                {
                    callBackMode = DataCallBackMode.IsDefaultEmpAtt;
                }
                else if (callMode.CompareTo("EmployeeInformationFind").IsZero())
                {
                    callBackMode = DataCallBackMode.EmployeeInformationFind;
                }
                else if (callMode.CompareTo("DateDifference").IsZero())
                {
                    callBackMode = DataCallBackMode.DateDifference;
                }
                else if (callMode.CompareTo("FilterByEntityType").IsZero())
                {
                    callBackMode = DataCallBackMode.FilterByEntityType;
                }
                else if (callMode.CompareTo("AddNewSetting").IsZero())
                {
                    callBackMode = DataCallBackMode.AddNewSetting;
                }
                else if (callMode.CompareTo("SaveValidData").IsZero())
                {
                    callBackMode = DataCallBackMode.SaveValidData;
                }
                else if (callMode.CompareTo("DuplicateSlabTypeCheck").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateSlabTypeCheck;
                }
                else if (callMode.CompareTo("getRowCountFromDatabase").IsZero())
                {
                    callBackMode = DataCallBackMode.getRowCountFromDatabase;
                }
                else if (callMode.CompareTo("ShowAllEmpForOutOfOfficeEntry").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowAllEmpForOutOfOfficeEntry;
                }
                else if (callMode.CompareTo("OutOfOfficeEntry").IsZero())
                {
                    callBackMode = DataCallBackMode.OutOfOfficeEntry;
                }
                else if (callMode.CompareTo("ClearOutOfOfficeInfoGrid").IsZero())
                {
                    callBackMode = DataCallBackMode.ClearOutOfOfficeInfoGrid;
                }
                else if (callMode.CompareTo("ShowAllEmpForAttProcessForRowData").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowAllEmpForAttProcessForRowData;
                }
                else if (callMode.CompareTo("DuplicateEntityNameCheck").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateEntityNameCheck;
                }
                else if (callMode.CompareTo("ParentList").IsZero())
                {
                    callBackMode = DataCallBackMode.ParentList;
                }
                else if (callMode.CompareTo("SearchOption").IsZero())
                {
                    callBackMode = DataCallBackMode.SearchOption;
                }
                else if (callMode.CompareTo("SalaryProcessSave").IsZero())
                {
                    callBackMode = DataCallBackMode.SalaryProcessSave;
                }
                else if (callMode.CompareTo("SetSelectedParameterValueInParameterGridForSearch").IsZero())
                {
                    callBackMode = DataCallBackMode.SetSelectedParameterValueInParameterGridForSearch;
                }
                else if (callMode.CompareTo("ShowAllEmpForCalendar").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowAllEmpForCalendar;
                }
                else if (callMode.CompareTo("CheckOrUnCheckWeekend").IsZero())
                {
                    callBackMode = DataCallBackMode.CheckOrUnCheckWeekend;
                }
                else if (callMode.CompareTo("AllSelectOrAllClear").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectOrAllClear;
                }
                else if (callMode.CompareTo("AllSelectOrAllClearEmp").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectOrAllClearEmp;
                }
                else if (callMode.CompareTo("ShiftRosterProcessSave").IsZero())
                {
                    callBackMode = DataCallBackMode.ShiftRosterProcessSave;
                }
                else if (callMode.CompareTo("Cal_ShowEmpListWithDayStatus").IsZero())
                {
                    callBackMode = DataCallBackMode.Cal_ShowEmpListWithDayStatus;
                }
                else if (callMode.CompareTo("Cal_SaveEmpListWithDayStatus").IsZero())
                {
                    callBackMode = DataCallBackMode.Cal_SaveEmpListWithDayStatus;
                }
                else if (callMode.CompareTo("ShowCalendar").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowCalendar;
                }
                else if (callMode.CompareTo("SearchEmp").IsZero())
                {
                    callBackMode = DataCallBackMode.SearchEmp;
                }
                else if (callMode.CompareTo("SaveEmpListWithAssignOT").IsZero())
                {
                    callBackMode = DataCallBackMode.SaveEmpListWithAssignOT;
                }
                else if (callMode.CompareTo("OTAssignList").IsZero())
                {
                    callBackMode = DataCallBackMode.OTAssignList;
                }
                else if (callMode.CompareTo("ApproveORUnApprovedOTAssignment").IsZero())
                {
                    callBackMode = DataCallBackMode.ApproveORUnApprovedOTAssignment;
                }
                else if (callMode.CompareTo("ManualProcessEmpList").IsZero())
                {
                    callBackMode = DataCallBackMode.ManualProcessEmpList;
                }
                else if (callMode.CompareTo("ShiftRoster").IsZero())
                {
                    callBackMode = DataCallBackMode.ShiftRoster;
                }
                else if (callMode.CompareTo("ManualShiftAssign").IsZero())
                {
                    callBackMode = DataCallBackMode.ManualShiftAssign;
                }
                else if (callMode.CompareTo("DuplicateSalaryHead").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateSalaryHead;
                }
                else if (callMode.CompareTo("SalaryRule").IsZero())
                {
                    callBackMode = DataCallBackMode.SalaryRule;
                }
                //else if (callMode.CompareTo("SaveSalaryRule").IsZero())
                //{
                //    callBackMode = DataCallBackMode.SaveSalaryRule;
                //}
                else if (callMode.CompareTo("ManualAttProcess").IsZero())
                {
                    callBackMode = DataCallBackMode.ManualAttProcess;
                }
                else if (callMode.CompareTo("OutOfOfficeEmpList").IsZero())
                {
                    callBackMode = DataCallBackMode.OutOfOfficeEmpList;
                }
                else if (callMode.CompareTo("SaveOutOfOfficeEntry").IsZero())
                {
                    callBackMode = DataCallBackMode.SaveOutOfOfficeEntry;
                }
                else if (callMode.CompareTo("ApprovalOfManualEntry").IsZero())
                {
                    callBackMode = DataCallBackMode.ApprovalOfManualEntry;
                }
                else if (callMode.CompareTo("AllSelectOrAllClearUserWiseEmp").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectOrAllClearUserWiseEmp;
                }
                else if (callMode.CompareTo("ShowAllCheckOrUncheckUserWiseEmp").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowAllCheckOrUncheckUserWiseEmp;
                }
                else if (callMode.CompareTo("ApproveAttManual").IsZero())
                {
                    callBackMode = DataCallBackMode.ApproveAttManual;
                }
                else if (callMode.CompareTo("GetHeadWiseRule").IsZero())
                {
                    callBackMode = DataCallBackMode.GetHeadWiseRule;
                }
                else if (callMode.CompareTo("GetAllSalaryRuleCalculateFormula").IsZero())
                {
                    callBackMode = DataCallBackMode.GetAllSalaryRuleCalculateFormula;
                }
                else if (callMode.CompareTo("SetActualValue").IsZero())
                {
                    callBackMode = DataCallBackMode.SetActualValue;
                }
                else if (callMode.CompareTo("ShowAllEmpForManualAtt").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowAllEmpForManualAtt;
                }
                else if (callMode.CompareTo("EditableSalaryInfoGrid").IsZero())
                {
                    callBackMode = DataCallBackMode.EditableSalaryInfoGrid;
                }
                else if (callMode.CompareTo("MiscAllowDedEntryDynamicGrid").IsZero())
                {
                    callBackMode = DataCallBackMode.MiscAllowDedEntryDynamicGrid;
                }
                else if (callMode.CompareTo("_SearchByEmpCode").IsZero())
                {
                    callBackMode = DataCallBackMode._SearchByEmpCode;
                }
                else if (callMode.CompareTo("Lotus_12_SearchEmpList").IsZero())
                {
                    callBackMode = DataCallBackMode.Lotus_12_SearchEmpList;
                }
                else if (callMode.CompareTo("DefinePaymentPolicy").IsZero())
                {
                    callBackMode = DataCallBackMode.DefinePaymentPolicy;
                }
                else if (callMode.CompareTo("GetFromDateAndToDate").IsZero())
                {
                    callBackMode = DataCallBackMode.GetFromDateAndToDate;
                }
                else if (callMode.CompareTo("SalaryProcess").IsZero())
                {
                    callBackMode = DataCallBackMode.SalaryProcess;
                }
                else if (callMode.CompareTo("SearchEmpList").IsZero())
                {
                    callBackMode = DataCallBackMode.SearchEmpList;
                }
                else if (callMode.CompareTo("LoanDefination").IsZero())
                {
                    callBackMode = DataCallBackMode.LoanDefination;
                }
                else if (callMode.CompareTo("LoanAdjustment").IsZero())
                {
                    callBackMode = DataCallBackMode.LoanAdjustment;
                }
                else if (callMode.CompareTo("LatestNews").IsZero())
                {
                    callBackMode = DataCallBackMode.LatestNews;
                }
                else if (callMode.CompareTo("SeparationProcess").IsZero())
                {
                    callBackMode = DataCallBackMode.SeparationProcess;
                }
                else if (callMode.CompareTo("SeparationDataSave").IsZero())
                {
                    callBackMode = DataCallBackMode.SeparationDataSave;
                }
                else if (callMode.CompareTo("ChangePassword").IsZero())
                {
                    callBackMode = DataCallBackMode.ChangePassword;
                }
                else if (callMode.CompareTo("AddNewCustomerInfo").IsZero())
                {
                    callBackMode = DataCallBackMode.AddNewCustomerInfo;
                }
                else if (callMode.CompareTo("AddNewEmergencyInfo").IsZero())
                {
                    callBackMode = DataCallBackMode.AddNewEmergencyInfo;
                }
                else if (callMode.CompareTo("AddNewOtherSkillInfo").IsZero())
                {
                    callBackMode = DataCallBackMode.AddNewOtherSkillInfo;
                }
                else if (callMode.CompareTo("DuplicateFiscalYearCheck").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateFiscalYearCheck;
                }
                else if (callMode.CompareTo("AllSelectOrAllClearLeaveApproval").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectOrAllClearLeaveApproval;
                }
                else if (callMode.CompareTo("AllSelectOrAllClearHourlyLeaveApproval").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectOrAllClearHourlyLeaveApproval;
                }
                else if (callMode.CompareTo("ShiftRoster2").IsZero())
                {
                    callBackMode = DataCallBackMode.ShiftRoster2;
                }
                else if (callMode.CompareTo("SelectUpLoadDevice").IsZero())
                {
                    callBackMode = DataCallBackMode.SelectUpLoadDevice;
                }
                else if (callMode.CompareTo("ShowExistingOutOfOfficeEntry").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowExistingOutOfOfficeEntry;
                }
                else if (callMode.CompareTo("ShowEmpRelatedApproval").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowEmpRelatedApproval;
                }
                else if (callMode.CompareTo("GetAttnSummary").IsZero())
                {
                    callBackMode = DataCallBackMode.GetAttnSummary;
                }
                else if (callMode.CompareTo("searchPostingVoucher").IsZero())
                {
                    callBackMode = DataCallBackMode.searchPostingVoucher;
                }
                else if (callMode.CompareTo("searchVoucher").IsZero())
                {
                    callBackMode = DataCallBackMode.searchVoucher;
                }
                else if (callMode.CompareTo("CheckTransaction").IsZero())
                {
                    callBackMode = DataCallBackMode.CheckTransaction;
                }
                else if (callMode.CompareTo("GetSearchVoucherDet").IsZero())
                {
                    callBackMode = DataCallBackMode.GetSearchVoucherDet;
                }
                else if (callMode.CompareTo("DuplicateAccHeadCheck").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateAccHeadCheck;
                }
                else if (callMode.CompareTo("YearEndProcess").IsZero())
                {
                    callBackMode = DataCallBackMode.YearEndProcess;
                }
                else if (callMode.CompareTo("searchTransaction").IsZero())
                {
                    callBackMode = DataCallBackMode.searchTransaction;
                }
                else if (callMode.CompareTo("searchTB").IsZero())
                {
                    callBackMode = DataCallBackMode.searchTB;
                }
                else if (callMode.CompareTo("searchBalanceSheet").IsZero())
                {
                    callBackMode = DataCallBackMode.searchBalanceSheet;
                }
                else if (callMode.CompareTo("searchLedger").IsZero())
                {
                    callBackMode = DataCallBackMode.searchLedger;
                }
                else if (callMode.CompareTo("searchProfitLoss").IsZero())
                {
                    callBackMode = DataCallBackMode.searchProfitLoss;
                }
                else if (callMode.CompareTo("ShowAllCheckOrUncheck1").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowAllCheckOrUncheck1;
                }
                else if (callMode.CompareTo("GetVoucherDet").IsZero())
                {
                    callBackMode = DataCallBackMode.GetVoucherDet;
                }
                else if (callMode.CompareTo("AllSelectOrAllClearGridChecknbox").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectOrAllClearGridChecknbox;
                }
                else if (callMode.CompareTo("DuplicateAccFiscalYearCheck").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateAccFiscalYearCheck;
                }
                else if (callMode.CompareTo("AddOrEditVoucher").IsZero())
                {
                    callBackMode = DataCallBackMode.AddOrEditVoucher;
                }
                else if (callMode.CompareTo("SetControlForEdit").IsZero())
                {
                    callBackMode = DataCallBackMode.SetControlForEdit;
                }
                else if (callMode.CompareTo("GetCommissionAndVATPercent").IsZero())
                {
                    callBackMode = DataCallBackMode.GetCommissionAndVATPercent;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CallbackFunction()
        {
            try
            {
                switch (DataCallMode)
                {
                    case DataCallBackMode.getRowCount:
                        getRowCount();
                        return;
                    case DataCallBackMode.SetSelectedParameterValueInParameterGrid:
                        SetSelectedParameterValueInParameterGrid();
                        return;
                    case DataCallBackMode.InitParameterTableValue:
                        InitParameterTableValue();
                        return;
                    case DataCallBackMode.PopulateGrideWithMenu:
                        PopulateGrideWithMenu();
                        return;
                    case DataCallBackMode.AllSelectCheckedOrUnchecked:
                        AllSelectCheckedOrUnchecked();
                        return;
                    case DataCallBackMode.AllInsertCheckedOrUnchecked:
                        AllInsertCheckedOrUnchecked();
                        return;
                    case DataCallBackMode.AllUpdateCheckedOrUnchecked:
                        AllUpdateCheckedOrUnchecked();
                        return;
                    case DataCallBackMode.AllDeleteCheckedOrUnchecked:
                        AllDeleteCheckedOrUnchecked();
                        return;
                    case DataCallBackMode.MenuAllCheckOrUncheck:
                        MenuAllCheckOrUncheck();
                        return;
                    case DataCallBackMode.AddNewCustomerInfo:
                        AddNewCustomerInfo();
                        return;
                    case DataCallBackMode.ShowAllEmpForAttProcess:
                        ShowAllEmpForAttProcess();
                        return;
                    case DataCallBackMode.ModifyAttProcess:
                        ModifyAttProcess();
                        return;
                    case DataCallBackMode.ClearEmployeeAttendanceGrid:
                        ClearEmployeeAttendanceGrid();
                        return;
                    case DataCallBackMode.IsDefaultEmpAtt:
                        IsDefaultEmpAtt();
                        return;
                    case DataCallBackMode.EmployeeInformationFind:
                        EmployeeInformationFind();
                        return;
                    case DataCallBackMode.DateDifference:
                        DateDifference();
                        return;
                    case DataCallBackMode.SaveValidData:
                        SaveValidData();
                        return;
                    case DataCallBackMode.DuplicateSlabTypeCheck:
                        DuplicateSlabTypeCheck();
                        return;
                    case DataCallBackMode.getRowCountFromDatabase:
                        getRowCountFromDatabase();
                        return;
                    case DataCallBackMode.ShowAllEmpForOutOfOfficeEntry:
                        ShowAllEmpForOutOfOfficeEntry();
                        return;
                    case DataCallBackMode.OutOfOfficeEntry:
                        OutOfOfficeEntry();
                        return;
                    case DataCallBackMode.ClearOutOfOfficeInfoGrid:
                        ClearOutOfOfficeInfoGrid();
                        return;
                    case DataCallBackMode.ShowAllEmpForAttProcessForRowData:
                        ShowAllEmpForAttProcessForRowData();
                        return;
                    case DataCallBackMode.DuplicateEntityNameCheck:
                        DuplicateEntityNameCheck();
                        return;
                    case DataCallBackMode.ParentList:
                        ParentList();
                        return;
                    case DataCallBackMode.SearchOption:
                        SearchOption();
                        return;
                    case DataCallBackMode.SetSelectedParameterValueInParameterGridForSearch:
                        SetSelectedParameterValueInParameterGridForSearch();
                        return;
                    case DataCallBackMode.ShowAllEmpForCalendar:
                        ShowAllEmpForCalendar();
                        return;
                    case DataCallBackMode.CheckOrUnCheckWeekend:
                        CheckOrUnCheckWeekend();
                        return;
                    case DataCallBackMode.AllSelectOrAllClear:
                        AllSelectOrAllClear();
                        return;
                    case DataCallBackMode.AllSelectOrAllClearEmp:
                        AllSelectOrAllClearEmp();
                        return;
                    case DataCallBackMode.Cal_ShowEmpListWithDayStatus:
                        Cal_ShowEmpListWithDayStatus();
                        return;
                    case DataCallBackMode.Cal_SaveEmpListWithDayStatus:
                        Cal_SaveEmpListWithDayStatus();
                        return;
                    case DataCallBackMode.ShowCalendar:
                        ShowCalendar();
                        return;
                    case DataCallBackMode.ShowAllCheckOrUncheck:
                        ShowAllCheckOrUncheck();
                        return;
                    case DataCallBackMode.SearchEmp:
                        SearchEmp();
                        return;
                    case DataCallBackMode.SaveEmpListWithAssignOT:
                        SaveEmpListWithAssignOT();
                        return;
                    case DataCallBackMode.OTAssignList:
                        OTAssignList();
                        return;
                    case DataCallBackMode.ApproveORUnApprovedOTAssignment:
                        ApproveORUnApprovedOTAssignment();
                        return;
                    case DataCallBackMode.ManualProcessEmpList:
                        ManualProcessEmpList();
                        return;
                    case DataCallBackMode.ShiftRoster:
                        ShiftRoster();
                        return;
                    case DataCallBackMode.ManualShiftAssign:
                        ManualShiftAssign();
                        return;
                    case DataCallBackMode.DuplicateSalaryHead:
                        DuplicateSalaryHead();
                        return;
                    case DataCallBackMode.SalaryRule:
                        SalaryRule();
                        return;
                    //case DataCallBackMode.SaveSalaryRule:
                    //    SaveSalaryRule();
                    //    return;
                    case DataCallBackMode.ManualAttProcess:
                        ManualAttProcess();
                        return;
                    case DataCallBackMode.GetAttnSummary:
                        GetAttnSummary();
                        return;

                    case DataCallBackMode.OutOfOfficeEmpList:
                        OutOfOfficeEmpList();
                        return;
                    case DataCallBackMode.SaveOutOfOfficeEntry:
                        SaveOutOfOfficeEntry();
                        return;
                    case DataCallBackMode.ApprovalOfManualEntry:
                        ApprovalOfManualEntry();
                        return;
                    case DataCallBackMode.AllSelectOrAllClearUserWiseEmp:
                        AllSelectOrAllClearUserWiseEmp();
                        return;
                    case DataCallBackMode.ShowAllCheckOrUncheckUserWiseEmp:
                        ShowAllCheckOrUncheckUserWiseEmp();
                        return;
                    case DataCallBackMode.ApproveAttManual:
                        ApproveAttManual();
                        return;
                    case DataCallBackMode.GetHeadWiseRule:
                        GetHeadWiseRule();
                        return;
                    case DataCallBackMode.GetAllSalaryRuleCalculateFormula:
                        GetAllSalaryRuleCalculateFormula();
                        return;
                    case DataCallBackMode.SetActualValue:
                        SetActualValue();
                        return;
                    case DataCallBackMode.ShowAllEmpForManualAtt:
                        ShowAllEmpForManualAtt();
                        return;
                    case DataCallBackMode.EditableSalaryInfoGrid:
                        EditableSalaryInfoGrid();
                        return;
                    case DataCallBackMode.MiscAllowDedEntryDynamicGrid:
                        MiscAllowDedEntryDynamicGrid();
                        return;
                    case DataCallBackMode._SearchByEmpCode:
                        _SearchByEmpCode();
                        return;
                    case DataCallBackMode.Lotus_12_SearchEmpList:
                        Lotus_12_SearchEmpList();
                        return;
                    case DataCallBackMode.FilterByEntityType:
                        FilterByEntityType();
                        return;
                    case DataCallBackMode.DefinePaymentPolicy:
                        DefinePaymentPolicy();
                        return;
                    case DataCallBackMode.SearchEmpList:
                        SearchEmpList();
                        return;
                    case DataCallBackMode.LoanDefination:
                        LoanDefination();
                        return;
                    case DataCallBackMode.LoanAdjustment:
                        LoanAdjustment();
                        return;
                    case DataCallBackMode.LatestNews:
                        LatestNews();
                        return;
                    case DataCallBackMode.SeparationProcess:
                        SeparationProcess();
                        return;
                    case DataCallBackMode.SeparationDataSave:
                        SeparationDataSave();
                        return;
                    case DataCallBackMode.ChangePassword:
                        ChangePassword();
                        return;
                    case DataCallBackMode.AddNewEmergencyInfo:
                        AddNewEmergencyInfo();
                        return;
                    case DataCallBackMode.AddNewOtherSkillInfo:
                        AddNewOtherSkillInfo();
                        return;
                    case DataCallBackMode.DuplicateFiscalYearCheck:
                        DuplicateFiscalYearCheck();
                        return;
                    case DataCallBackMode.AllSelectOrAllClearLeaveApproval:
                        AllSelectOrAllClearLeaveApproval();
                        return;
                    case DataCallBackMode.AllSelectOrAllClearHourlyLeaveApproval:
                        AllSelectOrAllClearHourlyLeaveApproval();
                        return;
                    case DataCallBackMode.SelectUpLoadDevice:
                        SelectUpLoadDevice();
                        return;
                    case DataCallBackMode.ShowExistingOutOfOfficeEntry:
                        ShowExistingOutOfOfficeEntry();
                        return;
                    case DataCallBackMode.ShowEmpRelatedApproval:
                        ShowEmpRelatedApproval();
                        return;
                    case DataCallBackMode.ShiftRoster2:
                        ShiftRoster2();
                        return;
                    case DataCallBackMode.AddNewSetting:
                        AddNewSetting();
                        return;
                    case DataCallBackMode.ShiftRosterProcessSave:
                        ShiftRosterProcessSave();
                        return;
                    case DataCallBackMode.SalaryProcess:
                        SalaryProcess();
                        return;
                    case DataCallBackMode.GetFromDateAndToDate:
                        GetFromDateAndToDate();
                        return;
                    case DataCallBackMode.SalaryProcessSave:
                        SalaryProcessSave();
                        return;
                    case DataCallBackMode.searchPostingVoucher:
                        searchPostingVoucher();
                        return;
                    case DataCallBackMode.searchVoucher:
                        searchVoucher();
                        return;
                    case DataCallBackMode.CheckTransaction:
                        CheckTransaction();
                        return;
                    case DataCallBackMode.GetSearchVoucherDet:
                        GetSearchVoucherDet();
                        return;
                    case DataCallBackMode.DuplicateAccHeadCheck:
                        DuplicateAccHeadCheck();
                        return;
                    case DataCallBackMode.YearEndProcess:
                        YearEndProcess();
                        return;
                    case DataCallBackMode.searchTransaction:
                        searchTransaction();
                        return;
                    case DataCallBackMode.searchTB:
                        searchTB();
                        return;
                    case DataCallBackMode.searchBalanceSheet:
                        searchBalanceSheet();
                        return;
                    case DataCallBackMode.searchLedger:
                        searchLedger();
                        return;
                    case DataCallBackMode.searchProfitLoss:
                        searchProfitLoss();
                        return;
                    case DataCallBackMode.GetVoucherDet:
                        GetVoucherDet();
                        return;
                    case DataCallBackMode.ShowAllCheckOrUncheck1:
                        ShowAllCheckOrUncheck1();
                        return;
                    case DataCallBackMode.AllSelectOrAllClearGridChecknbox:
                        AllSelectOrAllClearGridChecknbox();
                        return;
                    case DataCallBackMode.DuplicateAccFiscalYearCheck:
                        DuplicateAccFiscalYearCheck();
                        return;
                    case DataCallBackMode.AddOrEditVoucher:
                        AddOrEditVoucher();
                        return;
                    case DataCallBackMode.SetControlForEdit:
                        SetControlForEdit();
                        return;
                    case DataCallBackMode.GetCommissionAndVATPercent:
                        GetCommissionAndVATPercent();
                        return;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetCommissionAndVATPercent()
        {
            try
            {
                String refSourceString = String.Empty;
                CustomList<Hr_MasterSetup> CommissionAndVATList = Hr_MasterSetup.GetAllHr_MasterCommissionAndVATPercent();
                foreach (Hr_MasterSetup mS in CommissionAndVATList)
                {
                    if (refSourceString.IsNullOrEmpty())
                        refSourceString = mS.ItemValue;
                    else
                        refSourceString = refSourceString + "," + mS.ItemValue;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetControlForEdit()
        {
            try
            {
                String refSourceString = String.Empty;
                String rowID = HttpContext.Current.Request.QueryString["rowid"];
                CustomList<Acc_VoucherDet> AccVoucherDetList = (CustomList<Acc_VoucherDet>)HttpContext.Current.Session["PFVoucher_AccVoucherDetList"];
                Acc_VoucherDet obj = AccVoucherDetList.Find(f => f.VID == rowID.ToInt());
                refSourceString = obj.COAKey.ToString() + "," + obj.Dr + "," + obj.Cr;
                HttpContext.Current.Session["rowID"] = rowID.ToInt();
                HttpContext.Current.Session["COAKey"] = obj.COAKey.ToString();

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddOrEditVoucher()
        {
            try
            {
                String refSourceString = String.Empty;
                String drHead = HttpContext.Current.Request.QueryString["drHead"];
                String drAmount = HttpContext.Current.Request.QueryString["drAmount"];
                String crHead = HttpContext.Current.Request.QueryString["crHead"];
                String crAmount = HttpContext.Current.Request.QueryString["crAmount"];
                CustomList<Acc_VoucherDet> AccVoucherDetList = (CustomList<Acc_VoucherDet>)HttpContext.Current.Session["PFVoucher_AccVoucherDetList"];
                Int32? rowID = null;
                string COAKey = null;
                if (HttpContext.Current.Session["rowID"].IsNotNull())
                    rowID = (Int32)HttpContext.Current.Session["rowID"];
                if (HttpContext.Current.Session["COAKey"].IsNotNull())
                    COAKey = (string)HttpContext.Current.Session["COAKey"];
                if (COAKey.IsNotNullOrEmpty())
                {
                    Acc_VoucherDet obj = AccVoucherDetList.Find(f => f.VID == rowID);
                    if (obj.IsNotNull())
                    {
                        if (obj.Cr == 0)
                        {
                            obj.COAKey = Convert.ToInt64(drHead);
                            obj.Dr = drAmount.ToDecimal();
                        }
                        else
                        {
                            obj.COAKey = Convert.ToInt64(crHead);
                            obj.Cr = crAmount.ToDecimal();
                        }
                        HttpContext.Current.Session["rowID"] = "";
                        HttpContext.Current.Session["COAKey"] = "";
                        HttpContext.Current.Session["PFVoucher_AccVoucherDetList"] = AccVoucherDetList;
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.ContentType = "text/plain";
                        HttpContext.Current.Response.Write(refSourceString);
                        HttpContext.Current.Response.Flush();
                        return;
                    }
                }

                if (drHead.IsNotNullOrEmpty())
                {
                    Acc_VoucherDet objVoucherDet = AccVoucherDetList.Find(f => f.COAKey == Convert.ToInt64(drHead));
                    if (objVoucherDet.IsNotNull())
                    {
                        objVoucherDet.COAKey = Convert.ToInt64(drHead);
                        objVoucherDet.Dr = drAmount.ToDecimal();
                    }
                    else
                    {
                        Acc_VoucherDet obj = new Acc_VoucherDet();
                        obj.COAKey = Convert.ToInt64(drHead);
                        obj.Dr = drAmount.ToDecimal();
                        AccVoucherDetList.Add(obj);
                    }
                }
                if (crHead.IsNotNullOrEmpty())
                {
                    Acc_VoucherDet objVoucherDet = AccVoucherDetList.Find(f => f.COAKey == Convert.ToInt64(crHead));
                    if (objVoucherDet.IsNotNull())
                    {
                        objVoucherDet.COAKey = Convert.ToInt64(crHead);
                        objVoucherDet.Cr = crAmount.ToDecimal();
                    }
                    else
                    {
                        Acc_VoucherDet obj = new Acc_VoucherDet();
                        obj.COAKey = Convert.ToInt64(crHead);
                        obj.Cr = crAmount.ToDecimal();
                        AccVoucherDetList.Add(obj);
                    }
                }
                HttpContext.Current.Session["PFVoucher_AccVoucherDetList"] = AccVoucherDetList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void DuplicateAccFiscalYearCheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String FYName = HttpContext.Current.Request.QueryString["FYName"];
                String VID = HttpContext.Current.Request.QueryString["VID"];
                String SDate = HttpContext.Current.Request.QueryString["SDate"];
                String EDate = HttpContext.Current.Request.QueryString["EDate"];
                CustomList<Gen_AccFY> List = (CustomList<Gen_AccFY>)HttpContext.Current.Session["Acc_FiscalYear_Gen_AccFYList"];


                CustomList<Gen_AccFY> objlist;
                if (VID == "-1")
                    objlist = List.FindAll(p =>
                                    (p.FYName == FYName)
                                    ||
                                    (
                                        ((SDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate) && (SDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                        ||
                                        ((EDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate) && (EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                    )
                            );
                else
                    objlist = List.FindAll(p =>
                                (p.VID != VID.ToInt())
                                &&
                                (
                                    (p.FYName == FYName)
                                    ||
                                    (
                                        ((SDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate) && (SDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                        ||
                                        ((EDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate)) && (EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                    )
                             );

                //if (VID == "-1")

                //    objlist = List.FindAll(p => p.FYName == FYName || ((SDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate && SDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate) || (EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate) && EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate));
                //else
                //    objlist = List.FindAll(p => p.VID != VID.ToInt() && (p.FYName == FYName || ((SDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate && SDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate) || (EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate) && EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate)));


                if (objlist.Count > 0)
                {
                    refSourceString = "Duplicate";
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllSelectOrAllClearGridChecknbox()
        {
            try
            {
                String refSourceString = String.Empty;
                String status = HttpContext.Current.Request.QueryString["Status"];
                CustomList<Acc_Voucher> AccVoucherList = (CustomList<Acc_Voucher>)HttpContext.Current.Session["PostingVoucher_AccVoucherList"];
                foreach (Acc_Voucher aV in AccVoucherList)
                {
                    aV.IsApproved = status.ToBoolean();
                }
                HttpContext.Current.Session["PostingVoucher_AccVoucherList"] = AccVoucherList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ShowAllCheckOrUncheck1()
        {
            try
            {
                String refSourceString = String.Empty;
                String sessionVarName = HttpContext.Current.Request.QueryString["SessionVarName"];
                IEnumerable Items = (IEnumerable)HttpContext.Current.Session[sessionVarName];
                CustomList<BaseItem> baseItems = Items.ToCustomList<BaseItem>();
                foreach (BaseItem bi in baseItems)
                {
                    object check = bi.GetType().GetProperty("IsApproved").GetValue(bi, null);
                    if (!Convert.ToBoolean(check))
                    {
                        refSourceString = "True";
                        break;
                    }
                }
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void GetVoucherDet()
        {
            try
            {
                String refSourceString = String.Empty;
                VoucherManager manager = new VoucherManager();
                String voucherKey = HttpContext.Current.Request.QueryString["VoucherKey"];
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                CustomList<Acc_VoucherDet> VoucherDetList = manager.GetAllAcc_VoucherDet(voucherKey.ToInt(), fromDate);
                HttpContext.Current.Session["PostingVoucher_AccVoucherDetList"] = VoucherDetList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void searchProfitLoss()
        {
            try
            {
                String refSourceString = String.Empty;
                ProfitLossManager manager = new ProfitLossManager();
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String orgKey = HttpContext.Current.Request.QueryString["OrgKey"];
                String fYKey = HttpContext.Current.Request.QueryString["FYKey"];
                CustomList<Acc_VoucherDet> TransactionLis = manager.GetAllAcc_VoucherDetPL(orgKey.ToInt(), fromDate, toDate, fYKey.ToInt());
                HttpContext.Current.Session["ProfitLoss_ProfitLossList"] = TransactionLis;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void searchLedger()
        {
            try
            {
                String refSourceString = String.Empty;
                TransactionManager manager = new TransactionManager();
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String orgKey = HttpContext.Current.Request.QueryString["OrgKey"];
                String head = HttpContext.Current.Request.QueryString["Head"];
                Decimal opBal = manager.GetAllAcc_VoucherDet(orgKey.ToInt(), fromDate, toDate, head.ToInt(), "[dbo].[Acc_Rpt_Ledger];2");
                Decimal periodicalBal = manager.GetAllAcc_VoucherDet(orgKey.ToInt(), fromDate, toDate, head.ToInt(), "[dbo].[Acc_Rpt_Ledger];3");
                Decimal ClosingBal = manager.GetAllAcc_VoucherDet(orgKey.ToInt(), fromDate, toDate, head.ToInt(), "[dbo].[Acc_Rpt_Ledger];4");
                refSourceString = Math.Round(opBal, 2).ToString() + "," + Math.Round(periodicalBal, 2).ToString() + "," + Math.Round(ClosingBal, 2).ToString();
                CustomList<Acc_VoucherDet> TransactionLis = manager.GetAllAcc_VoucherDet(orgKey.ToInt(), fromDate, toDate, head.ToInt());
                HttpContext.Current.Session["Ledger_AccVoucherDetList"] = TransactionLis;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void searchBalanceSheet()
        {
            try
            {
                String refSourceString = String.Empty;
                BalanceSheetManager manager = new BalanceSheetManager();
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String orgKey = HttpContext.Current.Request.QueryString["OrgKey"];
                String fYKey = HttpContext.Current.Request.QueryString["FYKey"];
                CustomList<Acc_VoucherDet> TransactionLis = manager.GetAllAcc_VoucherDetBS(orgKey.ToInt(), fromDate, toDate, fYKey.ToInt());
                HttpContext.Current.Session["BalanceSheet_BalanceSheetList"] = TransactionLis;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void searchTB()
        {
            try
            {
                String refSourceString = String.Empty;
                TBManager manager = new TBManager();
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String orgKey = HttpContext.Current.Request.QueryString["OrgKey"];
                CustomList<Acc_VoucherDet> TransactionLis = manager.GetAllAcc_VoucherDetTB(orgKey.ToInt(), fromDate, toDate);
                foreach (Acc_VoucherDet vD in TransactionLis)
                {
                    if (vD.Bal < 0)
                        vD.Cr = Math.Round(Math.Abs(vD.Bal), 2);
                    else
                        vD.Dr = Math.Round(Math.Abs(vD.Bal), 2);
                }
                HttpContext.Current.Session["TrialBalance_SummaryBalanceList"] = TransactionLis;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void searchTransaction()
        {
            try
            {
                String refSourceString = String.Empty;
                TransactionManager manager = new TransactionManager();
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String orgKey = HttpContext.Current.Request.QueryString["OrgKey"];
                String isPost = HttpContext.Current.Request.QueryString["IsPost"];
                CustomList<Acc_VoucherDet> TransactionLis = manager.GetAllAcc_VoucherDet(orgKey.ToInt(), isPost.ToInt(), fromDate, toDate);
                HttpContext.Current.Session["Transaction_AccVoucherDetList"] = TransactionLis;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void YearEndProcess()
        {
            try
            {
                String refSourceString = String.Empty;
                YearEndManager manager = new YearEndManager();
                String fYKey = HttpContext.Current.Request.QueryString["FYKey"];
                manager.GetAllYearEndProcess(fYKey.ToInt());

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void DuplicateAccHeadCheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String cOAKey = HttpContext.Current.Request.QueryString["COAKey"];
                String vid = HttpContext.Current.Request.QueryString["VID"];
                CustomList<Acc_VoucherDet> List = (CustomList<Acc_VoucherDet>)HttpContext.Current.Session["PFVoucher_AccVoucherDetList"];

                Acc_VoucherDet Acc_VoucherDetObj = List.Find(f => f.COAKey == cOAKey.ToInt() && f.VID != vid.ToInt());
                Acc_VoucherDet chkAdded = List.Find(f => f.COAKey == cOAKey.ToInt() && f.VID != vid.ToInt() && f.IsAdded);
                if ((Acc_VoucherDetObj.IsNotNull() && !Acc_VoucherDetObj.IsDeleted) || (Acc_VoucherDetObj.IsNotNull() && chkAdded.IsNotNull()))
                {
                    refSourceString = "False";
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void GetSearchVoucherDet()
        {
            try
            {
                String refSourceString = String.Empty;
                VoucherManager manager = new VoucherManager();
                String voucherKey = HttpContext.Current.Request.QueryString["VoucherKey"];
                CustomList<Acc_VoucherDet> VoucherDetList = manager.GetAllAcc_VoucherDet(voucherKey.ToInt());
                HttpContext.Current.Session["SearchOrEditVoucher_AccVoucherDetList"] = VoucherDetList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void CheckTransaction()
        {
            try
            {
                String retString = "";
                CustomList<Acc_VoucherDet> voucherDetList = (CustomList<Acc_VoucherDet>)HttpContext.Current.Session["PFVoucher_AccVoucherDetList"];
                retString = voucherDetList.Count.ToString();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(retString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void searchVoucher()
        {
            try
            {
                String refSourceString = String.Empty;
                VoucherManager manager = new VoucherManager();
                String searchStr = HttpContext.Current.Request.QueryString["SearchStr"];
                CustomList<Acc_Voucher> SearchVoucherList = manager.GetAllAcc_VoucherSearch(searchStr, "");
                HttpContext.Current.Session["SearchOrEditVoucher_AccVoucherList"] = SearchVoucherList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void searchPostingVoucher()
        {
            try
            {
                String refSourceString = String.Empty;
                VoucherManager manager = new VoucherManager();
                String searchStr = HttpContext.Current.Request.QueryString["SearchStr"];
                CustomList<Acc_Voucher> SearchVoucherList = manager.GetAllAcc_VoucherSearch(searchStr);
                HttpContext.Current.Session["PostingVoucher_AccVoucherList"] = SearchVoucherList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ShowEmpRelatedApproval()
        {
            try
            {
                String refSourceString = String.Empty;
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String selectionCritaria = HttpContext.Current.Request.QueryString["SelectionCritaria"];
                ApprovalManager manager = new ApprovalManager();
                CustomList<HRM_Emp> EmpList = new CustomList<HRM_Emp>();
                if (selectionCritaria == "1")
                {
                    EmpList = manager.GetNewEmpApproval(fromDate, toDate);
                }
                else if (selectionCritaria == "3")
                {
                    EmpList = manager.GetEmpSeparationApproval(fromDate, toDate);
                }
                else if (selectionCritaria == "2")
                {
                    EmpList = manager.GetEmpSeparationReActivation(fromDate, toDate);
                }

                HttpContext.Current.Session["EmployeeInfoComonApproval_EmpList"] = EmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddNewCustomerInfo()
        {
            try
            {
                String response = String.Empty;

                CustomList<CustomerWisePer> CustomerInfoList = (CustomList<CustomerWisePer>)HttpContext.Current.Session["CustomerInfo_PerchentageList"];
                CustomerWisePer newCustomerInfo = new CustomerWisePer();
                CustomerInfoList.Add(newCustomerInfo);
                HttpContext.Current.Session["CustomerInfo_PerchentageList"] = CustomerInfoList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddNewSetting()
        {
            try
            {
                String response = String.Empty;

                CustomList<Settings> SettingsList = (CustomList<Settings>)HttpContext.Current.Session["Settings_SettingsList"];
                Settings newSettings = new Settings();
                SettingsList.Add(newSettings);
                HttpContext.Current.Session["Settings_SettingsList"] = SettingsList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ShowExistingOutOfOfficeEntry()
        {
            try
            {
                OutOffOfficeEntryManager manager = new OutOffOfficeEntryManager();
                String response = String.Empty;
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                string empKey = "";
                CustomList<HRM_Emp> empList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> checkedEmpList = empList.FindAll(f => f.IsChecked);
                foreach (HRM_Emp e in checkedEmpList)
                {
                    if (empKey == "")
                        empKey = e.EmpKey.ToString();
                    else
                        empKey = empKey + "," + e.EmpKey.ToString();
                }
                if (empKey == "")
                    empKey = "0";
                HttpContext.Current.Session["EmpOutOffOfficeEntry_EmpList"] = manager.GetExistingEntry(fromDate, toDate, empKey);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SelectUpLoadDevice()
        {
            try
            {
                String response = String.Empty;
                String device = HttpContext.Current.Request.QueryString["Device"];
                if (!Atten_Device.GetIsFileUpload(device.ToInt()))
                    response = "false";
                else
                    response = "true";

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void DuplicateFiscalYearCheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String FYName = HttpContext.Current.Request.QueryString["FYName"];
                String VID = HttpContext.Current.Request.QueryString["VID"];
                String Orgkey = HttpContext.Current.Request.QueryString["Orgkey"];
                String SDate = HttpContext.Current.Request.QueryString["SDate"];
                String EDate = HttpContext.Current.Request.QueryString["EDate"];
                CustomList<Gen_FY> List = (CustomList<Gen_FY>)HttpContext.Current.Session["FiscalYear_Gen_FYList"];


                CustomList<Gen_FY> objlist;
                if (VID == "-1")

                    objlist = List.FindAll(p =>
                                (p.OrgKey == Orgkey.ToInt())
                                &&
                                (
                                    (p.FYName == FYName)
                                    ||
                                    (
                                        ((SDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate) && (SDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                        ||
                                        ((EDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate) && (EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                    )
                                 )
                            );
                else
                    objlist = List.FindAll(p =>
                                (p.OrgKey == Orgkey.ToInt())
                                &&
                                (p.VID != VID.ToInt())
                                &&
                                (
                                    (p.FYName == FYName)
                                    ||
                                    (
                                        ((SDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate) && (SDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                        ||
                                    //(EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate) && EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate)
                                        ((EDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate)) && (EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                    )
                             );

                if (objlist.Count > 0)
                {
                    refSourceString = "Duplicate";
                }


                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddNewOtherSkillInfo()
        {
            try
            {
                String response = String.Empty;

                CustomList<OtherSkillInfo> OtherSkillInfoList = (CustomList<OtherSkillInfo>)HttpContext.Current.Session["EmployeeBasicInfo_OtherSkillInfo"];
                OtherSkillInfo newOtherSkillInfo = new OtherSkillInfo();
                OtherSkillInfoList.Add(newOtherSkillInfo);
                HttpContext.Current.Session["EmployeeBasicInfo_OtherSkillInfo"] = OtherSkillInfoList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AddNewEmergencyInfo()
        {
            try
            {
                String response = String.Empty;

                CustomList<EmployeeEmergencyInfo> EmergencyInfoList = (CustomList<EmployeeEmergencyInfo>)HttpContext.Current.Session["EmployeeBasicInfo_EmployeeEmergencyInfoList"];
                EmployeeEmergencyInfo newEmergencyInfo = new EmployeeEmergencyInfo();
                EmergencyInfoList.Add(newEmergencyInfo);
                HttpContext.Current.Session["EmployeeBasicInfo_EmployeeEmergencyInfoList"] = EmergencyInfoList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ChangePassword()
        {
            String refSourceString = String.Empty;
            try
            {
                User currentUser = (User)HttpContext.Current.Session["CurrentUserSession"];

                String oldPass = HttpContext.Current.Request.QueryString["OldPassword"];
                String newPass = HttpContext.Current.Request.QueryString["NewPassword"];

                string passwordOld = Enc.Encrypt(oldPass.Trim(), ASL.STATIC.StaticInfo.encString);
                string passwordNew = Enc.Encrypt(newPass.Trim(), ASL.STATIC.StaticInfo.encString);

                String savedPassword = currentUser.Password;

                if (savedPassword == passwordOld)
                {
                    ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
                    String sql = "Update [User] Set Password = '" + passwordNew + "' where UserCode = '" + currentUser.UserCode + "'";
                    conManager.ExecuteNonQueryWrapper(sql);
                    refSourceString = "True," + "Saved Successfully.";
                }
                else
                {
                    refSourceString = "False," + "Old password do not match.";
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                refSourceString = "False," + ex.Message;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
                //throw ex;
            }
        }
        private void SeparationDataSave()
        {
            try
            {
                String refSourceString = String.Empty;
                SeparationManager ManagerSeparation = new SeparationManager();

                CustomList<SeparationGrid> SeparationList = (CustomList<SeparationGrid>)HttpContext.Current.Session["EmployeeSeperation_SeparationGrid"];
                ManagerSeparation.SaveSeparation(ref SeparationList);
                CustomList<SeparationGrid> ob = new CustomList<SeparationGrid>();
                HttpContext.Current.Session["EmployeeSeperation_SeparationGrid"] = ob;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SeparationProcess()
        {
            try
            {
                String refSourceString = String.Empty;

                String Cause = HttpContext.Current.Request.QueryString["Cause"];
                String Remarks = HttpContext.Current.Request.QueryString["Remarks"];
                String Action = HttpContext.Current.Request.QueryString["Action"];
                String EffectedDate = HttpContext.Current.Request.QueryString["EffectedDate"];
                String Note = HttpContext.Current.Request.QueryString["Note"];

                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> EmpListForSeparation = EmpList.FindAll(f => f.IsChecked);
                CustomList<SeparationGrid> SeparatedEmpListForSave = new CustomList<SeparationGrid>();

                foreach (HRM_Emp e in EmpListForSeparation)
                {

                    SeparationGrid S = new SeparationGrid();
                    S.EmployeeKey = e.EmpKey;
                    S.EmployeeCode = e.EmpCode;
                    S.EmployeeName = e.EmpName;
                    S.Designation = e.Designation;
                    S.Department = e.Department;
                    S.SeparationCause = Cause;
                    S.AdditionalRemarks = Remarks;
                    S.Notes = Note;
                    S.EffectiveDate = EffectedDate.ToDateTime();
                    S.AddedDate = DateTime.Now;

                    S.Action = Action;
                    S.IsEffected = false;
                    S.IsBlackListed = false;
                    S.BlackListCause = null;

                    S.SetAdded();
                    SeparatedEmpListForSave.Add(S);
                }
                HttpContext.Current.Session["EmployeeSeperation_SeparationGrid"] = SeparatedEmpListForSave;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void LatestNews()
        {
            try
            {
                String refSourceString = String.Empty;
                LatestNewsManager manager = new LatestNewsManager();
                CustomList<LatestNews> LatestNewsList = new CustomList<LatestNews>();
                LatestNewsList = manager.GetAllLatestNewsForDisplay();
                foreach (LatestNews lN in LatestNewsList)
                {
                    if (refSourceString.IsNullOrEmpty())
                        refSourceString = lN.NewsDetails;
                    else
                        refSourceString = refSourceString + "," + lN.NewsDetails;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void LoanAdjustment()
        {
            try
            {
                String refSourceString = String.Empty;
                //EmployeeManager manager = new EmployeeManager();

                String vid = HttpContext.Current.Request.QueryString["VID"];
                String criteria = HttpContext.Current.Request.QueryString["Criteria"];
                CustomList<LoanProcess> LoanProcessList = (CustomList<LoanProcess>)HttpContext.Current.Session["LoanAndAdvancedManagement_LoanProcessList"];
                LoanProcess current = LoanProcessList.Find(f => f.VID == vid.ToInt());
                LoanProcess next = LoanProcessList.Find(f => f.VID == vid.ToInt() + 1);
                LoanProcess previous = LoanProcessList.Find(f => f.VID == vid.ToInt() - 1);
                if (criteria == "1")
                {
                    next.InstallmentAmount = next.InstallmentAmount + current.InstallmentAmount;
                    current.Balance = current.Balance + current.InstallmentAmount;
                    next.Balance = current.Balance - next.InstallmentAmount;
                    current.InstallmentAmount = 0;
                }
                if (criteria == "2")
                {
                    if (previous.IsNotNull())
                    {
                        current.InstallmentAmount = next.InstallmentAmount + current.InstallmentAmount;
                        current.Balance = previous.Balance - current.InstallmentAmount;
                        next.Balance = current.Balance;
                        next.InstallmentAmount = 0;
                    }
                }
                if (criteria == "4")
                {
                    LoanProcess lP = new LoanProcess();
                    String interval = HttpContext.Current.Request.QueryString["Interval"];
                    LoanProcess obj = LoanProcessList.Find(f => f.PaymentSequence == LoanProcessList.Count());
                    lP.PaymentSequence = LoanProcessList.Count + 1;
                    lP.InstallmentDate = obj.InstallmentDate.AddMonths(interval.ToInt());
                    lP.InstallmentAmount = current.InstallmentAmount;
                    lP.Balance = 0;
                    current.Balance = current.Balance + current.InstallmentAmount;
                    current.InstallmentAmount = 0;
                    LoanProcessList.Add(lP);
                    Decimal Bal = current.Balance;
                    foreach (LoanProcess sP in LoanProcessList)
                    {
                        if (sP.PaymentSequence > current.PaymentSequence)
                        {
                            sP.Balance = Bal - sP.InstallmentAmount;
                            Bal = sP.Balance;
                        }
                    }
                }
                if (criteria == "3")
                {
                    //LoanProcess lP = new LoanProcess();
                    //String interval = HttpContext.Current.Request.QueryString["Interval"];
                    //LoanProcess obj = LoanProcessList.Find(f => f.PaymentSequence == LoanProcessList.Count());
                    //lP.PaymentSequence = LoanProcessList.Count + 1;
                    //lP.InstallmentDate = obj.InstallmentDate.AddMonths(interval.ToInt());
                    //lP.InstallmentAmount = current.InstallmentAmount;
                    //lP.Balance = 0;
                    current.Balance = current.Balance + current.InstallmentAmount;
                    int existingInstallment = LoanProcessList.Count - current.PaymentSequence;
                    Decimal installmentAmoun = 0.0M;
                    installmentAmoun = current.Balance / existingInstallment;
                    //LoanProcessList.Add(lP);
                    Decimal Bal = current.Balance;
                    foreach (LoanProcess sP in LoanProcessList)
                    {
                        if (sP.PaymentSequence > current.PaymentSequence)
                        {
                            sP.InstallmentAmount = installmentAmoun;
                            sP.Balance = Bal - sP.InstallmentAmount;
                            Bal = sP.Balance;
                        }
                    }
                    current.InstallmentAmount = 0;
                }
                if (criteria == "5")
                {
                    Decimal installmentAmount = current.InstallmentAmount;
                    CustomList<LoanProcess> AdjustWithCurrentList = new CustomList<LoanProcess>();
                    foreach (LoanProcess lP in LoanProcessList)
                    {
                        if (lP.VID > vid.ToInt())
                        {
                            installmentAmount += lP.InstallmentAmount;
                        }
                        else
                        {
                            AdjustWithCurrentList.Add(lP);
                        }
                    }
                    LoanProcess lPObj = AdjustWithCurrentList.Find(f => f.VID == vid.ToInt());
                    if (lPObj.IsNotNull())
                    {
                        lPObj.InstallmentAmount = installmentAmount;
                        lPObj.Balance = 0;
                    }
                    HttpContext.Current.Session["LoanAndAdvancedManagement_LoanProcessList"] = AdjustWithCurrentList;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void LoanDefination()
        {
            try
            {
                String refSourceString = String.Empty;
                EmployeeManager manager = new EmployeeManager();

                String amt = HttpContext.Current.Request.QueryString["Amt"];
                String firstInstallmentDate = HttpContext.Current.Request.QueryString["firstInstallmentDate"];
                String monthInterval = HttpContext.Current.Request.QueryString["MonthInterval"];
                String installmentOrAmount = HttpContext.Current.Request.QueryString["InstallmentOrAmount"];
                String installment = HttpContext.Current.Request.QueryString["Installment"];
                String Monthly = HttpContext.Current.Request.QueryString["Monthly"];
                CustomList<LoanProcess> LoanProcessList = new CustomList<LoanProcess>();
                Decimal amount = 0.0M;
                amount = amt.ToDecimal();
                int interval = monthInterval.ToInt();
                if (installment == "1")
                {
                    Decimal installmentAmount = 0.0M;
                    installmentAmount = amt.ToDecimal() / installmentOrAmount.ToInt();
                    for (int i = 0; i < installmentOrAmount.ToInt(); i++)
                    {
                        LoanProcess lP = new LoanProcess();
                        lP.PaymentSequence = i + 1;
                        lP.InstallmentDate = firstInstallmentDate.ToDateTime().AddMonths(interval - 1);
                        lP.InstallmentAmount = installmentAmount;
                        lP.Balance = amount - installmentAmount;
                        amount = amount - installmentAmount;
                        interval++;
                        LoanProcessList.Add(lP);
                    }
                }
                else
                {
                    Decimal installmentAmount = installmentOrAmount.ToDecimal();
                    int i = 1;
                    do
                    {
                        LoanProcess lP = new LoanProcess();
                        lP.PaymentSequence = i;
                        lP.InstallmentDate = firstInstallmentDate.ToDateTime().AddMonths(interval - 1);
                        lP.InstallmentAmount = installmentAmount;
                        lP.Balance = amount - installmentAmount;
                        amount = amount - installmentAmount;
                        interval++;
                        i++;
                        LoanProcessList.Add(lP);
                    } while (amount > installmentAmount);
                    LoanProcess lPObj = new LoanProcess();
                    lPObj.PaymentSequence = i;
                    lPObj.InstallmentDate = firstInstallmentDate.ToDateTime().AddMonths(interval - 1);
                    lPObj.InstallmentAmount = amount;
                    lPObj.Balance = 0;
                    LoanProcessList.Add(lPObj);
                }
                HttpContext.Current.Session["LoanAndAdvancedManagement_LoanProcessList"] = LoanProcessList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SearchEmpList()
        {
            try
            {
                String refSourceString = String.Empty;
                EmployeeManager manager = new EmployeeManager();

                String searchString = HttpContext.Current.Request.QueryString["SearchString"];
                CustomList<HRM_Emp> empList = manager.GetEmpInfo(searchString);
                if (empList.Count != 0)
                {
                    HttpContext.Current.Session["LoanAndAdvancedManagement_EmployeeList"] = empList;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void DefinePaymentPolicy()
        {
            try
            {
                String refSourceString = String.Empty;
                String paymentName = HttpContext.Current.Request.QueryString["PaymentName"];
                String calculation = HttpContext.Current.Request.QueryString["Calculation"];
                String reportHead = HttpContext.Current.Request.QueryString["ReportHead"];
                CustomList<AttPaymentRuleAmount> PaymentList = (CustomList<AttPaymentRuleAmount>)HttpContext.Current.Session["AttendancePaymentInfo_AttPaymentRuleAmountList"];
                AttPaymentRuleAmount paymentObj = PaymentList.Find(f => f.AttPaymentRuleID == paymentName);
                if (paymentObj.IsNotNull())
                {
                    paymentObj.Calculation = calculation;
                    paymentObj.ReportHeadID = reportHead;
                }
                else
                {
                    AttPaymentRuleAmount obj = new AttPaymentRuleAmount();
                    obj.SalaryHeadID = paymentName;
                    obj.Calculation = calculation;
                    obj.ReportHeadID = reportHead;
                    PaymentList.Add(obj);
                }
                HttpContext.Current.Session["AttendancePaymentInfo_AttPaymentRuleAmountList"] = PaymentList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void FilterByEntityType()
        {
            try
            {
                String refSourceString = String.Empty;

                String entityType = HttpContext.Current.Request.QueryString["EntityType"];
                CustomList<Gen_LookupEnt> LookupEntListByEntityTypte = new CustomList<Gen_LookupEnt>();
                CustomList<Gen_LookupEnt> LookupEntList = (CustomList<Gen_LookupEnt>)HttpContext.Current.Session["LookupEnt_LookupEntList"];
                LookupEntListByEntityTypte = LookupEntList.FindAll(f => f.EntityKey == entityType.ToInt());
                HttpContext.Current.Session["LookupEnt_LookupEntListByEntityType"] = LookupEntListByEntityTypte;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void Lotus_12_SearchEmpList()
        {
            try
            {
                String refSourceString = String.Empty;
                EmployeeManager manager = new EmployeeManager();

                String searchString = HttpContext.Current.Request.QueryString["SearchString"];
                CustomList<HRM_Emp> empList = manager.GetEmpInfo(searchString);
                if (empList.Count != 0)
                {
                    HttpContext.Current.Session["EmployeeBasicInformation_EmployeeList"] = empList;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void _SearchByEmpCode()
        {
            try
            {
                String refSourceString = String.Empty;
                String selectionCriteria = HttpContext.Current.Request.QueryString["SelectionCriteria"];
                String empCode = HttpContext.Current.Request.QueryString["EmpCode"];
                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                HRM_Emp item = new HRM_Emp();
                switch (selectionCriteria)
                {
                    case "EmpCode":
                        item = EmpList.Find(f => f.EmpCode.ToUpper() == empCode.ToUpper());
                        EmpList.Remove(item);
                        EmpList.Insert(0, item);
                        break;
                }
                if (item.IsNull())
                    refSourceString = "false";
                else
                    item.IsChecked = true;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void MiscAllowDedEntryDynamicGrid()
        {
            String ColumnName = "";
            try
            {
                CustomList<SalaryHead> HeadList = (CustomList<SalaryHead>)HttpContext.Current.Session["MiscAllowDedEntry_SalaryHeadList"];
                CustomList<SalaryHead> CheckedHeadList = HeadList.FindAll(f => f.IsChecked);
                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<MiscEntryDynamicGrid> MiscEntryDynamicGridList = new CustomList<MiscEntryDynamicGrid>();
                CustomList<HRM_Emp> CheckedEmpList = EmpList.FindAll(f => f.IsChecked);
                foreach (HRM_Emp e in CheckedEmpList)
                {
                    MiscEntryDynamicGrid newObj = new MiscEntryDynamicGrid();
                    newObj.EmpKey = e.EmpKey;
                    newObj.EmpCode = e.EmpCode;
                    newObj.EmpName = e.EmpName;
                    int headCount = 1;
                    foreach (SalaryHead sH in CheckedHeadList)
                    {
                        if (headCount == 1)
                        {
                            newObj.HeadName1 = sH.DefaultAmount.ToString();
                            newObj.SalaryHeadKey1 = sH.SalaryHeadKey;
                        }
                        else if (headCount == 2)
                        {
                            newObj.HeadName2 = sH.DefaultAmount.ToString();
                            newObj.SalaryHeadKey2 = sH.SalaryHeadKey;
                        }
                        else if (headCount == 3)
                        {
                            newObj.HeadName3 = sH.DefaultAmount.ToString();
                            newObj.SalaryHeadKey3 = sH.SalaryHeadKey;
                        }
                        else if (headCount == 4)
                        {
                            newObj.HeadName4 = sH.DefaultAmount.ToString();
                            newObj.SalaryHeadKey4 = sH.SalaryHeadKey;
                        }
                        else if (headCount == 5)
                        {
                            newObj.HeadName5 = sH.DefaultAmount.ToString();
                            newObj.SalaryHeadKey5 = sH.SalaryHeadKey;
                        }
                        else if (headCount == 6)
                        {
                            newObj.HeadName6 = sH.DefaultAmount.ToString();
                            newObj.SalaryHeadKey6 = sH.SalaryHeadKey;
                        }
                        else if (headCount == 7)
                        {
                            newObj.HeadName7 = sH.DefaultAmount.ToString();
                            newObj.SalaryHeadKey7 = sH.SalaryHeadKey;
                        }
                        //else if (headCount == 8)
                        //{
                        //    newObj.HeadName8 = sH.DefaultAmount.ToString();
                        //    newObj.SalaryHeadKey8 = sH.SalaryHeadKey;
                        //}
                        headCount++;
                    }
                    MiscEntryDynamicGridList.Add(newObj);
                }
                HttpContext.Current.Session["MiscAllowDedEntry_MiscEntryDynamicGridList"] = MiscEntryDynamicGridList;

                String columnsCaption = "VID,Code,Name";

                String colModel = " " +
                                " { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' } @" +
                                " { 'name': 'EmpCode', 'index': 'EmpCode','hidden': false, editable: false, width: 120} @" +
                                " { 'name': 'EmpName', 'index': 'EmpName','hidden': false, editable: false, width: 50} ";


                if (CheckedHeadList.IsNotNull())
                {
                    int headCount = 1;
                    foreach (SalaryHead list in CheckedHeadList)
                    {
                        columnsCaption += "," + list.HeadName;
                        colModel += "@ { 'name': 'HeadName" + headCount + "', 'index': 'HeadName" + headCount + "','hidden': false, editable: true, width: 50, editrules: { required: true }, 'align':'right', editrules: {number:true,required: true},editoptions: {style:'text-align:right;width:96%'}} ";
                        headCount++;
                    }
                }
                columnsCaption += ",Remarks";
                colModel += "@ { 'name': 'Remarks', 'index': 'Remarks','hidden': false, editable: true, width: 100} ";
                ColumnName = columnsCaption + "|" + colModel;


                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(ColumnName);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void EditableSalaryInfoGrid()
        {
            try
            {
                String refSourceString = String.Empty;
                String id = HttpContext.Current.Request.QueryString["VID"];
                CustomList<EmployeeSalaryTemp> EmployeeSalaryTempList = (CustomList<EmployeeSalaryTemp>)HttpContext.Current.Session["SalaryInfoEntry_grdSalaryEntryList"];
                EmployeeSalaryTemp sRB = EmployeeSalaryTempList.Find(f => f.VID == id.ToInt());
                SalaryRuleBackup objSalaryRule = ASL.Hr.DAO.SalaryRule.SalaryInfoGridValidation(sRB.SalaryRuleCode, sRB.SalaryHeadKey);
                if (objSalaryRule.ParentHeadID.IsNullOrEmpty() && objSalaryRule.IsFormula == false)//objSalaryRule.ParentHeadValue != 0)
                    refSourceString = "true";
                else
                    refSourceString = "false";


                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void SetActualValue()
        {
            try
            {
                String refSourceString = String.Empty;
                EmpSearchManager manager = new EmpSearchManager();
                String vID = HttpContext.Current.Request.QueryString["VID"];
                CustomList<EmpFilterSets> FilterSetList = (CustomList<EmpFilterSets>)HttpContext.Current.Session["ucEmpSearch_FilterSetsList"];
                EmpFilterSets obj = FilterSetList.Find(f => f.VID == vID.ToInt());

                Int32 parent = manager.GetAllEntityList(obj.EntityID.ToString());
                EmpFilterSets checkParent = ((CustomList<EmpFilterSets>)HttpContext.Current.Session["ucEmpSearch_FilterSetsList"]).Find(f => f.EntityID == parent);
                if (parent != 0 && checkParent.ColumnValue != "")
                {
                    string search = "select Distinct HKV.*from HousekeepingHierarchy HKH  INNER JOIN HouseKeepingValue HKV ON  HKV.HKID=HKH.HKID where HKH.ParentID IN(" + checkParent.ColumnValue + ") and HKV.EntityID=" + obj.EntityID;
                    CustomList<HouseKeepingValue> ElementList = manager.GetAllHouseKeepingValue(search, "");
                    HttpContext.Current.Session["ucEmpSearch_EntityList"] = ElementList;
                }
                else
                {
                    CustomList<HouseKeepingValue> ElementList = manager.GetAllHouseKeepingValue(obj.EntityID.ToString());
                    HttpContext.Current.Session["ucEmpSearch_EntityList"] = ElementList;
                }
                CustomList<HouseKeepingValue> FilterValueList = (CustomList<HouseKeepingValue>)HttpContext.Current.Session["ucEmpSearch_EntityList"];
                string[] items = obj.DisplaySeletedColumnValue.Split(',');
                int count = items.Count();
                obj.ColumnValue = "";
                for (int i = 0; i < count; i++)
                {
                    HouseKeepingValue hKVObj = FilterValueList.Find(f => f.HKName == items[i]);
                    if (hKVObj.IsNotNull())
                    {
                        obj.ColumnValue += hKVObj.HKID.ToString() + ",";
                    }
                }
                obj.ColumnValue = obj.ColumnValue.Length > 0 ? obj.ColumnValue.Substring(0, obj.ColumnValue.Length - 1) : string.Empty;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void GetAllSalaryRuleCalculateFormula()
        {
            try
            {
                SalaryInfoEntryManager manager = new SalaryInfoEntryManager();
                SalaryComponentHelper sCH = new SalaryComponentHelper();
                String refSourceString = String.Empty;
                String salaryRuleCode = HttpContext.Current.Request.QueryString["SalaryRuleCode"];
                CustomList<SalaryRule> SalaryRuleList = manager.GetAllSalaryRuleFormula(salaryRuleCode);
                String flag = HttpContext.Current.Request.QueryString["Flag"];
                if (flag == "1")
                {
                    CustomList<EmployeeSalaryTemp> EmpSalaryRuleList = (CustomList<EmployeeSalaryTemp>)HttpContext.Current.Session["SalaryInfoEntry_grdSalaryEntryList"];
                    foreach (SalaryRule sR in SalaryRuleList)
                    {
                        if (sR.ParentHeadID.IsNullOrEmpty() && sR.ParentHeadValue != 0)
                        {
                            EmployeeSalaryTemp objTES = EmpSalaryRuleList.Find(f => f.SalaryHeadKey == sR.SalaryHeadKey);
                            sR.Formula1 = objTES.Amount.ToString();
                            sR.Formula2 = objTES.Amount.ToString();
                        }
                    }
                }

                CustomList<EmployeeSalaryTemp> _EmpSalaryTemp = sCH.DecodeFormula(ref SalaryRuleList);
                HttpContext.Current.Session["SalaryInfoEntry_grdSalaryEntryList"] = _EmpSalaryTemp;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void GetHeadWiseRule()
        {
            try
            {
                DailyAttendanceManger manager = new DailyAttendanceManger();
                String refSourceString = String.Empty;
                String id = HttpContext.Current.Request.QueryString["VID"];
                CustomList<SalaryRuleBackup> SalaryRuleList = (CustomList<SalaryRuleBackup>)HttpContext.Current.Session["SalaryRule_grdSalaryRuleList"];
                SalaryRuleBackup sRB = SalaryRuleList.Find(f => f.VID == id.ToInt());
                if (sRB.ParentHeadID == "" && sRB.IsFormula == false)//sRB.ParentHeadValue != 0)
                {
                    refSourceString = "Fixed," + sRB.SalaryHeadKey + "," + sRB.IsFixed + "," + sRB.ParentHeadValue;
                }
                else if (sRB.ParentHeadID != "" && sRB.PartialHeadValue == 0)
                {
                    refSourceString = "Percentage," + sRB.SalaryHeadKey + "," + sRB.IsFixed + "," + sRB.ParentHeadValue + "," + sRB.ParentHeadID;
                }
                else if (sRB.ParentHeadID != "" && sRB.PartialHeadValue != 0)
                {
                    refSourceString = "Partial," + sRB.SalaryHeadKey + "," + sRB.IsFixed + "," + sRB.ParentHeadValue + "," + sRB.ParentHeadID + "," + sRB.PartialHeadID + "," + sRB.PartialHeadValue + "," + sRB.IsHigher;
                }
                else if (sRB.ParentHeadID == "" && sRB.ParentHeadValue == 0)
                {
                    refSourceString = "Formula," + sRB.SalaryHeadKey + "," + sRB.IsFixed + "," + sRB.Formula1;
                }
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void ApproveAttManual()
        {
            try
            {
                ApprovalOfManualEntryManager manager = new ApprovalOfManualEntryManager();
                String refSourceString = String.Empty;
                String currentUser = HttpContext.Current.Request.QueryString["CurrentUser"];
                CustomList<AttendanceManualModification> AttManualApprove = (CustomList<AttendanceManualModification>)HttpContext.Current.Session["ApprovalOfManualEntry_AttManualList"];
                CustomList<AttendanceManualModification> SaveManualList = AttManualApprove.FindAll(f => f.IsChecked);
                SaveManualList.ForEach(f => f.ApprovedDate = DateTime.Now.ToShortDateString());
                SaveManualList.ForEach(f => f.ApprovedBy = currentUser);
                CustomList<DailyAttendance> ManualDailyAtt = new CustomList<DailyAttendance>();
                foreach (AttendanceManualModification aMM in SaveManualList)
                {
                    DailyAttendance dA = new DailyAttendance();
                    dA.EmpKey = aMM.EmpKey;
                    dA.Workdate = aMM.Workdate;
                    dA.ShiftID = aMM.ShiftID.ToString();
                    dA.InTime = aMM.CInTime;
                    dA.OutTime = aMM.COutTime;
                    dA.LateHour = aMM.LateHour;
                    dA.EarlyOutHour = aMM.EarlyOutHour;
                    dA.PayHour = aMM.PayHour;
                    dA.OTHour = aMM.OTHour;
                    dA.DayStatus = aMM.CDayStatus;
                    dA.IsManual = true;
                    dA.ModificationID = aMM.ModificationID.ToString();
                    ManualDailyAtt.Add(dA);
                }
                manager.SaveAttManual(SaveManualList, ManualDailyAtt);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void ApprovalOfManualEntry()
        {
            try
            {
                ApprovalOfManualEntryManager manager = new ApprovalOfManualEntryManager();
                String refSourceString = String.Empty;

                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                CustomList<AttendanceManualModification> AttManualList = manager.GetEmpAttManualApproved(fromDate, toDate);
                HttpContext.Current.Session["ApprovalOfManualEntry_AttManualList"] = AttManualList;

                CustomList<HRM_Emp> UserList = new CustomList<HRM_Emp>();
                UserList = manager.ManualEntryUserList();
                HttpContext.Current.Session["ApprovalOfManualEntry_UserList"] = UserList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void SaveOutOfOfficeEntry()
        {
            try
            {
                OutOffOfficeEntryManager manager = new OutOffOfficeEntryManager();
                String refSourceString = String.Empty;
                CustomList<OutOfOfficeInfo> OutOfOfficeEntryList = (CustomList<OutOfOfficeInfo>)HttpContext.Current.Session["EmpOutOffOfficeEntry_EmpList"];
                OutOfOfficeEntryList.ForEach(f => f.SetAdded());
                manager.SaveOutOfOfficeEntry(ref OutOfOfficeEntryList);
                OutOfOfficeEntryList = new CustomList<OutOfOfficeInfo>();
                HttpContext.Current.Session["EmpOutOffOfficeEntry_EmpList"] = OutOfOfficeEntryList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void OutOfOfficeEmpList()
        {
            try
            {
                OutOffOfficeEntryManager manager = new OutOffOfficeEntryManager();
                String refSourceString = String.Empty;
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String startTime = HttpContext.Current.Request.QueryString["StartTime"];
                String endTime = HttpContext.Current.Request.QueryString["EndTime"];
                String visit = HttpContext.Current.Request.QueryString["Visit"];
                String stayingArea = HttpContext.Current.Request.QueryString["StayingArea"];
                String reason = HttpContext.Current.Request.QueryString["Reason"];
                String remarks = HttpContext.Current.Request.QueryString["Remarks"];
                String currentUser = HttpContext.Current.Request.QueryString["CurrentUser"];
                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> CheckedEmpList = EmpList.FindAll(f => f.IsChecked);
                TimeSpan ts = (toDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat) - fromDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat));
                int days = ts.Days + 1;
                CustomList<OutOfOfficeInfo> OutOfOfficeEmpList = new CustomList<OutOfOfficeInfo>();
                foreach (HRM_Emp e in CheckedEmpList)
                {
                    for (int i = 0; i < days; i++)
                    {
                        OutOfOfficeInfo obj = new OutOfOfficeInfo();
                        obj.EmpKey = e.EmpKey;
                        obj.EmpCode = e.EmpCode;
                        obj.EmpName = e.EmpName;
                        obj.Date = fromDate.ToDateTime(StaticInfo.GridDateFormat).AddDays(i);
                        obj.StartTime = startTime;
                        obj.EndTime = endTime;
                        obj.Project = visit;
                        obj.StayPlace = stayingArea;
                        obj.Reason = reason;
                        obj.Remarks = remarks;
                        obj.AddedBy = currentUser;
                        obj.AddedDate = DateTime.Now;
                        OutOfOfficeEmpList.Add(obj);
                    }
                }
                HttpContext.Current.Session["EmpOutOffOfficeEntry_EmpList"] = OutOfOfficeEmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ManualAttProcess()
        {
            try
            {
                DailyAttendanceManger manager = new DailyAttendanceManger();
                String refSourceString = String.Empty;
                String currentUser = HttpContext.Current.Request.QueryString["CurrentUser"];
                String inTimeBuffer = HttpContext.Current.Request.QueryString["InTimeBuffer"];
                String outTimeBuffer = HttpContext.Current.Request.QueryString["OutTimeBuffer"];
                String lunchInBuffer = HttpContext.Current.Request.QueryString["LunchInBuffer"];
                String lunchOutBuffer = HttpContext.Current.Request.QueryString["LunchOutBuffer"];
                String Type = HttpContext.Current.Request.QueryString["Type"];
                if (inTimeBuffer.IsNotNullOrEmpty())
                {
                    manager.ChangeMasterSetupValue(inTimeBuffer, "InTimeBuffer");
                }
                if (outTimeBuffer.IsNotNullOrEmpty())
                {
                    manager.ChangeMasterSetupValue(outTimeBuffer, "OutTimeBuffer");
                }
                if (lunchInBuffer.IsNotNullOrEmpty())
                {
                    manager.ChangeMasterSetupValue(lunchInBuffer, "LunchInBuffer");
                }
                if (lunchOutBuffer.IsNotNullOrEmpty())
                {
                    manager.ChangeMasterSetupValue(lunchOutBuffer, "LunchOutBuffer");
                }
                CustomList<AttendanceManualModification> AttManualList = (CustomList<AttendanceManualModification>)HttpContext.Current.Session["AttendanceManual_DailyManualAttendanceList"];
                AttManualList.ForEach(f => f.AddedBy = currentUser);
                AttManualList.ForEach(f => f.AddedDate = DateTime.Now);
                //AttManualList.FindAll(f => f.Delete() == "").ForEach(f => f.IsDeleted = true);
                if (Type == "Delete")
                {
                    //AttManualList.ForEach(f => f.Delete());
                    AttManualList.ForEach(f => f.IsDeleted = true);

                }
                //CustomList<AttendanceManualModification> AddedOrModifiedList = AttManualList.FindAll(f => f.IsModified || f.IsAdded);
                //AddedOrModifiedList.ForEach(f => f.AddedBy = currentUser);
                //AddedOrModifiedList.ForEach(f => f.AddedDate = DateTime.Now);
                //AddedOrModifiedList.ForEach(s=>s.InTime=s.InDate.ToShortDateString()+" "+s.InTime);
                //AddedOrModifiedList.ForEach(s => s.OutTime = s.OutDate.ToShortDateString() + " " + s.OutTime);
                manager.SaveAttManual(ref AttManualList);
                CustomList<AttendanceManualModification> obj = new CustomList<AttendanceManualModification>();
                HttpContext.Current.Session["AttendanceManual_DailyManualAttendanceList"] = obj;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void SalaryRule()
        {
            try
            {
                SalaryRuleManager manager = new SalaryRuleManager();
                String refSourceString = String.Empty;
                String strValue = HttpContext.Current.Request.QueryString["StrValue"];
                string[] items = strValue.Split(',');
                CustomList<SalaryRuleBackup> SalaryRuleBackupList = new CustomList<SalaryRuleBackup>();
                SalaryRuleBackupList = (CustomList<SalaryRuleBackup>)HttpContext.Current.Session["SalaryRule_grdSalaryRuleList"];
                SalaryRuleBackup sRB = SalaryRuleBackupList.Find(f => f.SalaryHeadKey == items[1].ToInt());

                if (sRB.IsNull())
                {
                    sRB = new SalaryRuleBackup();
                    SalaryRuleBackupList.Add(sRB);
                }

                switch (items[0])
                {
                    case "Fixed":
                        sRB.SalaryHeadKey = items[1].ToInt();
                        if (items[2] == "true")
                        {
                            sRB.IsFixed = true;
                            sRB.Formula1 = items[3] + ",It is fixed";
                            sRB.Formula2 = items[3];

                        }
                        else
                        {
                            sRB.IsFixed = false;
                            sRB.Formula1 = items[3] + ",It is proportionate";
                            sRB.Formula2 = items[3];
                        }
                        sRB.ParentHeadValue = items[3].ToDecimal();
                        sRB.DateAdded = DateTime.Now;
                        break;
                    case "Percentage":
                        sRB.SalaryHeadKey = items[1].ToInt();
                        if (items[2] == "true")
                        {
                            sRB.IsFixed = true;
                            sRB.Formula1 = items[3] + "% of " + items[4] + ",It is fixed";
                            sRB.Formula2 = "@" + items[4] + "@ * " + items[3] + "/" + 100;
                        }
                        else
                        {
                            sRB.IsFixed = false;
                            sRB.Formula1 = items[3] + "% of " + items[4] + ",It is proportionate";
                            sRB.Formula2 = "@" + items[4] + "@ * " + items[3] + "/" + 100;
                        }
                        sRB.ParentHeadValue = items[3].ToDecimal();
                        sRB.ParentHeadID = items[4];
                        sRB.DateAdded = DateTime.Now;
                        break;
                    case "Partial":
                        sRB.SalaryHeadKey = items[1].ToInt();
                        if (items[2] == "true")
                        {
                            sRB.IsFixed = true;
                            if (items[5] == "")
                            {
                                sRB.Formula1 = items[3] + "% of " + items[4] + " and " + items[6] + ",It is fixed";
                                sRB.Formula2 = "@" + items[4] + "@*" + items[3] + "/" + 100;
                            }
                            else
                            {
                                sRB.Formula1 = items[3] + "% of " + items[4] + " or " + items[6] + "% of " + items[5] + ",It is fixed";
                                sRB.Formula2 = "(@" + items[4] + "@*" + items[3] + "/" + 100 + ")or(@" + items[5] + "@*" + items[6] + "/" + 100 + ")";
                                //decimal first = DecodeFormula("(@" + items[4] + "@*" + items[3] + "/" + 100 + ")");
                            }
                        }
                        else
                        {
                            sRB.IsFixed = false;
                            if (items[5] == "")
                            {
                                sRB.Formula1 = items[3] + "% of " + items[4] + " and " + items[6] + ",It is fixed";
                                sRB.Formula2 = "(@" + items[4] + "@*" + items[3] + "/" + 100 + ") + " + items[6];
                            }
                            else
                            {
                                sRB.Formula1 = items[3] + "% of " + items[4] + " or " + items[6] + "% of " + items[5] + ",It is proportionate";
                                sRB.Formula2 = "(@" + items[4] + "@*" + items[3] + "/" + 100 + ")+(@" + items[5] + "@*" + items[6] + "/" + 100 + ")";
                            }
                        }
                        sRB.ParentHeadValue = items[3].ToDecimal();
                        sRB.ParentHeadID = items[4];
                        sRB.PartialHeadID = items[5];
                        sRB.PartialHeadValue = items[6].ToDecimal();
                        if (items[7] == "true")
                            sRB.IsHigher = true;
                        sRB.DateAdded = DateTime.Now;
                        break;
                    case "Formula":
                        sRB.SalaryHeadKey = items[1].ToInt();
                        if (items[2] == "true")
                        {
                            sRB.IsFixed = true;
                            sRB.Formula1 = items[3] + ",It is fixed";
                            string[] parts = items[3].Split('=');
                            sRB.Formula2 = parts[1];
                        }
                        else
                        {
                            sRB.IsFixed = false;
                            sRB.Formula1 = items[3] + ",It is proportionate";
                            string[] parts = items[3].Split('=');
                            sRB.Formula2 = parts[1];
                        }
                        sRB.IsFormula = true;
                        sRB.DateAdded = DateTime.Now;
                        break;
                    default:
                        break;
                }

                HttpContext.Current.Session["SalaryRule_grdSalaryRuleList"] = SalaryRuleBackupList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        //private decimal DecodeFormula(string formula)
        //{
        //    try
        //    {
        //                           var pattern = new Regex(@"(\@.*?\@)", RegexOptions.IgnorePatternWhitespace);

        //                           foreach (Match m in pattern.Matches(formula.ToUpper()))
        //           {
        //              string[] parts = m.Groups[1].Value.Split('@');
        //              //SalaryRule obj = ruleDetails.Find(f => f.HeadName.ToUpper().Trim() == parts[1].ToUpper().Trim());
        //              item.Formula2 = item.Formula2.ToUpper().Replace(m.Groups[1].Value, obj.Formula2);
        //           }
        //           NCalc.Expression exp = new NCalc.Expression(item.Formula2);
        //           object ret = exp.Evaluate();
        //           item.Formula2 = ret.ToString();

        //           decimal val = 0M;
        //           EmployeeSalaryTemp eST = new EmployeeSalaryTemp();
        //           eST.SalaryRuleCode = item.SalaryRuleCode;
        //           eST.SalaryHeadKey = item.SalaryHeadKey;
        //           eST.IsFixed = item.IsFixed;
        //           if (decimal.TryParse(item.Formula2, out val))
        //               eST.Amount =Math.Round(val,2);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
        private void DuplicateSalaryHead()
        {
            try
            {
                String refSourceString = String.Empty;
                String salaryHead = HttpContext.Current.Request.QueryString["HeadName"];
                String vid = HttpContext.Current.Request.QueryString["VID"];
                CustomList<SalaryHead> SalarySubHeadList = (CustomList<SalaryHead>)HttpContext.Current.Session["SalaryHead_grdSalarySubHeadList"];

                SalaryHead HeadNameObj = null;
                if (vid.IsNullOrEmpty())
                {
                    HeadNameObj = SalarySubHeadList.Find(f => f.HeadName == salaryHead);
                }
                else
                {
                    HeadNameObj = SalarySubHeadList.Find(f => f.HeadName == salaryHead && f.VID != vid.ToInt());
                }

                if ((HeadNameObj.IsNotNull() && !HeadNameObj.IsDeleted))
                {
                    refSourceString = "False";
                }
                else refSourceString = "True";

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ManualShiftAssign()
        {
            try
            {
                ManualShiftAssignmentManager manager = new ManualShiftAssignmentManager();
                String refSourceString = String.Empty;
                String strSearch = HttpContext.Current.Request.QueryString["StrSearch"];
                String shiftId = HttpContext.Current.Request.QueryString["ShiftID"];
                string isDelete = HttpContext.Current.Request.QueryString["IsDelete"];
                DateTime fromDate = HttpContext.Current.Request.QueryString["FromDate"].ToDateTime();
                DateTime toDate = HttpContext.Current.Request.QueryString["ToDate"].ToDateTime();


                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> CheckedEmpList = EmpList.FindAll(f => f.IsChecked);
                CustomList<ShiftRoster> ManualShiftAssignList = new CustomList<ShiftRoster>();
                if (strSearch != "")
                {
                    // string[] items = strSearch.Split(',');

                    //TimeSpan ts = (toDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat) - fromDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat));
                    //int days = ts.Days + 1;
                    foreach (HRM_Emp e in CheckedEmpList)
                    {
                        for (DateTime d = fromDate; d <= toDate; d.AddDays(+1))
                        {
                            DateTime shiftDate = d;

                            ShiftRoster newSR = new ShiftRoster();
                            newSR.EmpCode = e.EmpCode;
                            newSR.EmpKey = e.EmpKey;
                            newSR.PunchCardNo = e.PunchCardNo;
                            newSR.EmpName = e.EmpName;
                            newSR.ShiftDate = shiftDate;
                            newSR.ShiftID = shiftId.ToInt();
                            newSR.Type = "Manual Assigned";
                            newSR.IsApproved = true;

                            if (isDelete == "true")
                                newSR.IsDelete = true;
                            ManualShiftAssignList.Add(newSR);
                            d = d.AddDays(1);
                        }
                    }
                    manager.SaveShiftRosterManualAssignment(ref ManualShiftAssignList);
                }
                else
                {
                    foreach (HRM_Emp e in CheckedEmpList)
                    {
                        ShiftRoster newSR = new ShiftRoster();
                        newSR.EmpKey = e.EmpKey;
                        newSR.ShiftID = shiftId.ToInt();
                        ManualShiftAssignList.Add(newSR);
                    }
                    manager.UpdateManualShift(ref ManualShiftAssignList);
                }

                CustomList<HRM_Emp> obj = new CustomList<HRM_Emp>();
                HttpContext.Current.Session["View_EmpList"] = obj;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void ShiftRoster2()
        {
            try
            {
                String refSourceString = String.Empty;
                ShiftRosterManager manager = new ShiftRosterManager();
                ASL.Hr.BLL.TempEmpManager TempCodeManager = new TempEmpManager();
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String flagSave = HttpContext.Current.Request.QueryString["Save"];
                CustomList<HRM_Emp> WEmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> lstEmpList = WEmpList.FindAll(f => f.IsModified);

                CustomList<TempEmpCode> TempCode = new CustomList<TempEmpCode>();
                string tableName = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                HttpContext.Current.Session["TableName"] = tableName;
                foreach (HRM_Emp e in lstEmpList)
                {
                    TempEmpCode obj = new TempEmpCode();
                    obj.TableName = tableName;
                    obj.EmpKey = e.EmpKey;

                    TempCode.Add(obj);
                }
                TempCodeManager.SaveSettings(ref TempCode);

                CustomList<ShiftRoster> SRP = manager.ProcessShiftRoster(fromDate, toDate, tableName);
                HttpContext.Current.Session["ShiftRosterProcess_ShiftRosterList"] = SRP;


            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }

        }

        private void ShiftRosterProcessSave()
        {
            try
            {
                String refSourceString = String.Empty;
                ShiftRosterManager manager = new ShiftRosterManager();
                ASL.Hr.BLL.TempEmpManager TempCodeManager = new TempEmpManager();
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String Action = HttpContext.Current.Request.QueryString["Action"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String flagSave = HttpContext.Current.Request.QueryString["Save"];
                CustomList<HRM_Emp> WEmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> lstEmpList = WEmpList.FindAll(f => f.IsModified);

                CustomList<TempEmpCode> TempCode = new CustomList<TempEmpCode>();
                string tableName = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                HttpContext.Current.Session["TableName"] = tableName;
                foreach (HRM_Emp e in lstEmpList)
                {
                    TempEmpCode obj = new TempEmpCode();
                    obj.TableName = tableName;
                    obj.EmpKey = e.EmpKey;

                    TempCode.Add(obj);
                }
                TempCodeManager.SaveSettings(ref TempCode);
                CustomList<ShiftRoster> SRP = manager.DeleteExistingShiftRoster(fromDate, toDate, tableName);
                CustomList<ShiftRoster> SaveableShiftRosterList = (CustomList<ShiftRoster>)HttpContext.Current.Session["ShiftRosterProcess_ShiftRosterList"];
                // CustomList<ShiftRoster> SaveShiftRosterList = SaveableShiftRosterList.FindAll(f => f.IsAdded);
                foreach (ShiftRoster S in SaveableShiftRosterList)
                {
                    S.SetAdded();
                }
                if (Action == "Save")
                {
                    manager.SaveShiftRoster(ref SaveableShiftRosterList);
                }
                CustomList<ShiftRoster> Blankobj = new CustomList<ShiftRoster>();
                HttpContext.Current.Session["ShiftRosterProcess_ShiftRosterList"] = Blankobj;
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }

        }

        private void ShiftRoster()
        {
            try
            {
                String refSourceString = String.Empty;
                ShiftRosterManager manager = new ShiftRosterManager();
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String flagSave = HttpContext.Current.Request.QueryString["Save"];
                CustomList<HRM_Emp> WEmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> lstEmpList = WEmpList.FindAll(f => f.IsModified);
                CustomList<ShiftRule> ShiftRuleList = manager.GetAllShiftRule();
                CustomList<ShiftRuleDetail> ShiftRuleDetailList = manager.GetAllShiftRuleDetail();
                CustomList<ShiftRoster> ShiftRosterList = new CustomList<ASL.Hr.DAO.ShiftRoster>();
                CustomList<ShiftRoster> ProcessedShiftRosterList = manager.GetAllProcessedShiftRoster(fromDate, toDate);
                TimeSpan ts = (toDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat) - fromDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat));
                int days = ts.Days + 1;
                foreach (ShiftRule sR in ShiftRuleList)
                {
                    int firstShift = 0;
                    int firstShiftID = 0;
                    int secondShift = 0;
                    int secondShiftID = 0;
                    int thirdShift = 0;
                    int thirdShiftID = 0;
                    string firstShiftName = "";
                    string secondShiftName = "";
                    string thirdShiftName = "";
                    int count = 0;
                    CustomList<HRM_Emp> RuleWiseEmpList = lstEmpList.FindAll(f => f.ShiftRuleKey == sR.ShiftRuleKey);
                    CustomList<ShiftRuleDetail> RuleWiseShiftPlanList = ShiftRuleDetailList.FindAll(f => f.ShiftRuleKey == sR.ShiftRuleKey);
                    foreach (ShiftRuleDetail sRD in RuleWiseShiftPlanList)
                    {
                        if (count == 0)
                        {
                            firstShift = sRD.Days;
                            firstShiftID = sRD.ShiftID.ToInt();
                            firstShiftName = sRD.ALISE;
                        }
                        if (count == 1)
                        {
                            secondShift = sRD.Days;
                            secondShiftID = sRD.ShiftID.ToInt();
                            secondShiftName = sRD.ALISE;
                        }
                        if (count == 2)
                        {
                            thirdShift = sRD.Days;
                            thirdShiftID = sRD.ShiftID.ToInt();
                            thirdShiftName = sRD.ALISE;
                        }
                        count++;
                    }
                    foreach (HRM_Emp e in RuleWiseEmpList)
                    {
                        int rosterCount = 0;
                        for (int i = 1; i <= days; i++)
                        {
                            rosterCount++;
                            DateTime shiftDate = fromDate.ToDateTime(StaticInfo.GridDateFormat).AddDays(i - 1);

                            ShiftRoster newSR = new ShiftRoster();
                            newSR.EmpCode = e.EmpCode;
                            newSR.EmpKey = e.EmpKey;
                            newSR.PunchCardNo = e.PunchCardNo;
                            newSR.EmpName = e.EmpName;
                            newSR.ShiftDate = shiftDate;
                            if (firstShift >= rosterCount)
                            {
                                newSR.ShiftID = firstShiftID;
                                newSR.ShiftType = firstShiftName;
                            }
                            else if ((firstShift + secondShift) >= rosterCount)
                            {
                                newSR.ShiftID = secondShiftID;
                                newSR.ShiftType = secondShiftName;
                            }
                            else if ((firstShift + secondShift + thirdShift) >= rosterCount)
                            {
                                newSR.ShiftID = thirdShiftID;
                                newSR.ShiftType = thirdShiftName;
                            }
                            if ((firstShift + secondShift + thirdShift) == rosterCount) rosterCount = 0;
                            ShiftRoster obj = ProcessedShiftRosterList.Find(f => f.EmpKey == newSR.EmpKey && f.ShiftDate == newSR.ShiftDate && f.ShiftID == newSR.ShiftID);
                            if (obj.IsNotNull() && !obj.IsApproved)
                            {
                                newSR.SetModified();
                                newSR.ModifiedOrApprovedFlag = "M";
                            }
                            else if (obj.IsNotNull() && obj.IsApproved)
                            {
                                newSR.SetUnchanged();
                                newSR.ModifiedOrApprovedFlag = "A";
                            }
                            ShiftRosterList.Add(newSR);
                        }
                    }
                }

                if (flagSave == "Save")
                {
                    CustomList<ShiftRoster> SaveShiftRosterList = ShiftRosterList.FindAll(f => f.IsAdded);
                    manager.SaveShiftRoster(ref SaveShiftRosterList);
                }
                else
                {
                    HttpContext.Current.Session["ShiftRosterProcess_ShiftRosterList"] = ShiftRosterList;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void ManualProcessEmpList()
        {
            try
            {
                DailyAttendanceManger manager = new DailyAttendanceManger();
                EmployeeManager managerEmp = new EmployeeManager();
                String refSourceString = String.Empty;
                String spName = HttpContext.Current.Request.QueryString["SpName"];
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String str = HttpContext.Current.Request.QueryString["Str"];
                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                String strBuffer = HttpContext.Current.Request.QueryString["StrBuffer"];
                String remarks = HttpContext.Current.Request.QueryString["Remarks"];
                string[] items = strBuffer.Split(',');
                CustomList<HRM_Emp> CheckedEmpList = EmpList.FindAll(f => f.IsChecked);
                CustomList<HRM_Emp> EmpApplicableShift = managerEmp.DateRangWiseEmpApplicableShift(fromDate, toDate);
                TimeSpan ts = (toDate.ToDateTime() - fromDate.ToDateTime());
                int days = ts.Days + 1;
                CustomList<AttendanceManualModification> ManualAttList = new CustomList<AttendanceManualModification>();
                CustomList<AttendanceManualModification> DalilyAttList = new CustomList<AttendanceManualModification>();
                if (items[20] == "overriteexistingPunch" && items[21] == "false")
                    DalilyAttList = manager.GetAllAttForManualProcess(spName, fromDate, toDate, str);
                string Msg = "";
                foreach (HRM_Emp e in CheckedEmpList)
                {
                    for (int i = 0; i < days; i++)
                    {
                        AttendanceManualModification obj = new AttendanceManualModification();
                        DateTime CompareDate = fromDate.ToDateTime().AddDays(i);
                        HRM_Emp H = new HRM_Emp();
                        H = EmpApplicableShift.Find(f => f.EmpKey == e.EmpKey && f.Workdate.ToDateTime() == CompareDate);

                        AttendanceManualModification emp = new AttendanceManualModification();
                        if (H.IsNotNull())
                        {
                            if (DalilyAttList.Find(f => f.EmpKey == H.EmpKey && f.ShiftID == H.ShiftID && f.Workdate == CompareDate).IsNotNull())
                            {
                                emp = DalilyAttList.Find(f => f.EmpKey == H.EmpKey && f.ShiftID == H.ShiftID && f.Workdate == CompareDate);
                            }
                        }
                        if (H.IsNull())
                        {
                            Msg = Msg + "Emp Code: " + e.EmpCode.ToString();
                            if (e.Workdate.IsNotNull())
                            {
                                Msg = Msg + " for  Work date : " + e.Workdate.ToString() + "\n";
                            }
                            else Msg = Msg + " for  Work date : Not Defined!" + "\n";

                        }
                        else
                        {
                            if (emp.EmpKey.IsNull() || emp.EmpKey == 0)
                            // if employee has no existing attendance
                            {
                                obj.EmpKey = e.EmpKey;
                                obj.EmpCode = e.EmpCode;
                                obj.EmpName = e.EmpName;

                                if (items[14] == "wHExists" && items[15] == "true")
                                {
                                    int count = manager.IsWH(e.EmpKey, CompareDate.ToString("MM/dd/yy"));
                                    if (count != 0)
                                        continue;
                                }
                                if (items[16] == "leaveExists" && items[17] == "true")
                                {
                                    int count = manager.IsLeave(e.EmpKey, CompareDate.ToString("MM/dd/yy"));
                                    if (count != 0)
                                        continue;
                                }
                                obj.Workdate = fromDate.ToDateTime().AddDays(i);

                                obj.ShiftID = H.ShiftID;
                                obj.CShiftID = H.ShiftID.ToString();
                                obj.Alias = H.Alias;
                                //obj.InDate = obj.Workdate;


                                obj.ShiftInTime = H.ShiftIntime;
                                obj.ShiftOutTime = H.ShiftOutTime;
                                obj.LateMargin = H.LateMargin;
                                obj.Remarks = remarks;
                                obj.CDayStatus = "P";
                                obj.InDate = obj.Workdate.ToShortDateString();
                                obj.InTime = obj.InTime;
                                obj.OutDate = obj.OutDate;
                                obj.OutTime = obj.OutTime;
                                //Intime
                                if (items[22] == "IsInTime" && items[23] == "true")
                                {
                                    obj.CInDate = obj.Workdate.ToShortDateString();

                                    if (items[0] == "shiftInTime" && items[1] != "")
                                    {
                                        if (items[10] == "makeLate" && items[11] != "")
                                        {
                                            obj.CInTime = H.ShiftIntime.ToDateTime().AddMinutes(items[11].ToInt()).ToString("hh:mm:ss tt");
                                        }
                                        else
                                            obj.CInTime = BufferInTime(items[1].ToInt(), H.ShiftIntime);
                                    }
                                    else
                                    {
                                        if (items[10] == "makeLate" && items[11] != "")
                                        {
                                            obj.CInTime = H.ShiftIntime.ToDateTime().AddMinutes(H.LateMargin.ToInt()).ToString("hh:mm:ss tt");
                                        }
                                        obj.CInTime = H.ShiftIntime.ToDateTime().ToString("hh:mm:ss tt");
                                    }

                                }
                                else
                                {
                                    obj.CInDate = null;
                                    obj.CInTime = null;


                                }

                                //Out Time
                                if (items[24] == "IsOutTime" && items[25] == "true")
                                {
                                    if ((items[18] == "makeLunchOut" && items[19] == "true") || (items[6] == "makeEarlyOut" && items[7] != "0" && items[7] != "")
                                                    || (items[4] == "withOT" && items[5] != "" && items[5] != "0"))
                                    {
                                        if (items[18] == "makeLunchOut" && items[19] == "true")
                                        {
                                            obj.COutTime = BufferOutTime(items[9].ToInt(), H.LunchOutTime);
                                        }
                                        else
                                        {
                                            if (items[4] == "withOT" && items[5] != "")
                                            {
                                                obj.COutTime = BufferOutTime(items[3].ToInt(), obj.ShiftOutTime.ToDateTime().AddMinutes(items[5].ToInt()).ToString("hh:mm:ss tt"));
                                                obj.OT = items[5].ToDecimal();
                                                obj.COT = items[5].ToDecimal();
                                            }
                                            if (items[6] == "makeEarlyOut" && items[7] != "0" && items[7] != "")
                                            {
                                                obj.COutTime = e.ShiftOutTime.ToDateTime().AddMinutes(-items[7].ToInt()).ToString("hh:mm:ss tt");

                                            }
                                        }



                                    }
                                    else
                                    {
                                        obj.COutTime = BufferOutTime(items[9].ToInt(), H.ShiftOutTime);
                                    }
                                    if (e.ShiftInDate == e.ShiftOutDate)
                                    {
                                        //obj.OutDate = obj.Workdate;
                                        obj.COutDate = obj.Workdate.ToShortDateString();
                                    }
                                    else
                                    {
                                        //obj.OutDate = obj.Workdate.AddDays(1);
                                        obj.COutDate = obj.Workdate.AddDays(1).ToShortDateString();
                                    }
                                }
                                else
                                {
                                    obj.COutDate = null;
                                    obj.COutTime = null;
                                }


                                if (items[26] == "IsLunchOutTime" && items[27] == "true")
                                {
                                    if (items[8] == "LunchOutTime" && items[9] != "0")
                                    {
                                        obj.LunchOutTime = BufferOutTime(items[9].ToInt(), H.LunchOutTime);
                                    }
                                    else
                                    {
                                        obj.LunchOutTime = e.LunchOutTime;
                                    }
                                }
                                if (items[28] == "IsLunchIn" && items[29] == "true")
                                {
                                    if (items[12] == "lunchInTime" && items[13] != "0")
                                    {
                                        obj.LunchInTime = BufferInTime(items[13].ToInt(), H.LunchInTime);
                                    }
                                    else
                                    {
                                        obj.LunchInTime = e.LunchInTime;
                                    }
                                }
                            }
                            else
                            // If Emp Has Existing Attendance
                            {
                                obj.EmpKey = e.EmpKey;
                                obj.EmpCode = e.EmpCode;
                                obj.EmpName = e.EmpName;
                                obj.Workdate = emp.Workdate;
                                obj.ShiftID = H.ShiftID;



                                obj.InDate = emp.InDate.ToDateTime().ToShortDateString();
                                obj.InTime = emp.InTime.ToDateTime().ToString("hh:mm:ss tt");



                                obj.OutDate = emp.OutDate.ToDateTime().ToShortDateString();
                                obj.OutTime = emp.OutTime.ToDateTime().ToString("hh:mm:ss tt");



                                obj.DayStatus = emp.DayStatus;
                                obj.OT = emp.OTHour;
                                obj.CShiftID = H.ShiftID.ToString();
                                obj.COT = emp.OTHour;
                                obj.Alias = e.Shift;
                                obj.ShiftInTime = H.ShiftIntime;
                                obj.ShiftOutTime = H.ShiftOutTime;
                                obj.LateMargin = H.LateMargin;
                                obj.Remarks = remarks;
                                if (items[14] == "wHExists" && items[15] == "true")
                                {
                                    int count = manager.IsWH(e.EmpKey, CompareDate.ToString("MM/dd/yy"));
                                    if (count != 0)
                                        continue;
                                }
                                if (items[16] == "leaveExists" && items[17] == "true")
                                {
                                    int count = manager.IsLeave(e.EmpKey, CompareDate.ToString("MM/dd/yy"));
                                    if (count != 0)
                                        continue;
                                }


                                obj.CDayStatus = "P";
                                // Out Time
                                if (items[24] == "IsOutTime" && items[25] == "true")
                                {
                                    obj.COutDate = emp.COutDate.ToDateTime().ToShortDateString();
                                    if ((items[18] == "makeLunchOut" && items[19] == "true") || (items[6] == "makeEarlyOut" && items[7] != "0" && items[7] != "")
                                                    || (items[4] == "withOT" && items[5] != "" && items[5] != "0"))
                                    {
                                        if (items[18] == "makeLunchOut" && items[19] == "true")
                                        {
                                            obj.COutTime = BufferOutTime(items[9].ToInt(), emp.LunchOutTime).ToDateTime().ToString("hh:mm:ss tt"); ;
                                        }
                                        else
                                        {
                                            if (items[4] == "withOT" && items[5] != "")
                                            {
                                                obj.COutTime = BufferOutTime(items[3].ToInt(), obj.ShiftOutTime.ToDateTime().AddMinutes(items[5].ToInt()).ToString("hh:mm:ss tt"));
                                                obj.COutDate = obj.ShiftOutTime.ToDateTime().AddMinutes(items[5].ToInt()).ToShortDateString();
                                                obj.OT = items[5].ToDecimal();
                                                obj.COT = items[5].ToDecimal();
                                            }
                                            if (items[6] == "makeEarlyOut" && items[7] != "0" && items[7] != "")
                                            {
                                                obj.COutTime = e.ShiftOutTime.ToDateTime().AddMinutes(-items[7].ToInt()).ToString("hh:mm:ss tt");

                                            }
                                        }



                                    }
                                    else
                                    {
                                        //obj.COutTime = BufferOutTime(items[9].ToInt(), H.ShiftOutTime);
                                        obj.COutTime = (emp.COutTime.IsNull() || emp.COutTime == "") ? BufferOutTime(items[9].ToInt(), H.ShiftOutTime).ToDateTime().ToString("hh:mm:ss tt") : emp.COutTime.ToDateTime().ToString("hh:mm:ss tt");

                                    }


                                }
                                else
                                {
                                    obj.COutDate = null;
                                    obj.COutTime = null;
                                }

                                if (items[22] == "IsInTime" && items[23] == "true")
                                {
                                    obj.CInDate = emp.CInDate.ToDateTime().ToShortDateString();
                                    obj.CInTime = (emp.CInTime.IsNull() || emp.CInTime == "") ? BufferInTime(items[1].ToInt(), H.ShiftIntime).ToDateTime().ToString("hh:mm:ss tt") : emp.CInTime.ToDateTime().ToString("hh:mm:ss tt");
                                    //emp.CInTime.ToDateTime().ToString("hh:mm:ss tt");
                                    if (items[10] == "makeLate" && items[11] != "")
                                    {
                                        obj.CInTime = H.ShiftIntime.ToDateTime().AddMinutes(items[11].ToInt()).ToString("hh:mm:ss tt");
                                    }

                                }
                                else
                                {

                                    obj.CInTime = null;
                                    obj.CInDate = null;
                                }



                                // Lunch  Time 
                                if (items[26] == "IsLunchOutTime" && items[27] == "true")
                                {
                                    if (items[8] == "LunchOutTime" && items[9] != "0")
                                    {
                                        obj.LunchOutTime = BufferOutTime(items[9].ToInt(), emp.LunchOutTime);
                                    }
                                    else
                                    {
                                        obj.LunchOutTime = emp.LunchOutTime;
                                    }
                                }
                                if (items[28] == "IsLunchIn" && items[29] == "true")
                                {
                                    if (items[12] == "lunchInTime" && items[13] != "0")
                                    {
                                        obj.LunchInTime = BufferInTime(items[13].ToInt(), emp.LunchInTime);
                                    }
                                    else
                                    {
                                        obj.LunchInTime = emp.LunchInTime;
                                    }
                                }
                            }
                            ManualAttList.Add(obj);
                        }

                    }
                }
                HttpContext.Current.Session["AttendanceManual_DailyManualAttendanceList"] = ManualAttList;



                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private string BufferInTime(Int32 buffertime, string time)
        {
            try
            {
                DateTimeOffset value1 = new DateTimeOffset();
                value1 = DateTimeOffset.Parse(time);
                TimeSpan timeSpan = TimeSpan.FromMinutes(buffertime);
                DateTimeOffset value = StaticRandom.RandomInTime(value1, timeSpan);
                string test = value.ToString();
                string val = value.ToString("hh:mm:ss tt");
                return val;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private string BufferOutTime(Int32 buffertime, string time)
        {
            try
            {
                DateTimeOffset value1 = new DateTimeOffset();
                value1 = DateTimeOffset.Parse(time);
                TimeSpan timeSpan = TimeSpan.FromMinutes(buffertime);
                DateTimeOffset value = StaticRandom.RandomOutTime(value1, timeSpan);
                string test = value.ToString();
                string val = value.ToString("hh:mm:ss tt");
                return val;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void ApproveORUnApprovedOTAssignment()
        {
            try
            {
                OTAssignmentManager manager = new OTAssignmentManager();
                String refSourceString = String.Empty;
                CustomList<OTAssignment> OTAssignmentList = (CustomList<OTAssignment>)HttpContext.Current.Session["OTAssignmentApproval_OTAssignmentList"];
                OTAssignmentList.ForEach(f => f.IsApproved = f.IsChecked);
                CustomList<OTAssignment> ModifiedOTAssignmentList = OTAssignmentList.FindAll(f => f.IsModified);
                manager.SaveOTAssignment(ModifiedOTAssignmentList);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);

            }
        }
        private void OTAssignList()
        {
            try
            {
                OTAssignmentManager manager = new OTAssignmentManager();
                String refSourceString = String.Empty;
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                CustomList<OTAssignment> OTAssignList = manager.GetAllOTAssignment(fromDate, toDate);
                HttpContext.Current.Session["OTAssignmentApproval_OTAssignmentList"] = OTAssignList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SaveEmpListWithAssignOT()
        {
            try
            {
                String refSourceString = String.Empty;
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String OTType = HttpContext.Current.Request.QueryString["OTType"];
                String OTHour = HttpContext.Current.Request.QueryString["OTHour"];
                String chkAssignOT = HttpContext.Current.Request.QueryString["chkAssignOT"];
                String chkPunchOT = HttpContext.Current.Request.QueryString["chkPunchOT"];
                String isLower = HttpContext.Current.Request.QueryString["isLower"];
                String isHigher = HttpContext.Current.Request.QueryString["isHigher"];
                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                int totalDays = DateTime.Parse(toDate, CultureInfo.GetCultureInfo("en-gb")).Subtract(DateTime.Parse(fromDate, CultureInfo.GetCultureInfo("en-gb"))).Days;
                CustomList<HRM_Emp> lstEmpList = EmpList.FindAll(f => f.IsChecked);
                CustomList<OTAssignment> DateWiseEmpList = new CustomList<OTAssignment>();
                for (int i = 0; i <= totalDays; i++)
                {
                    foreach (HRM_Emp e in lstEmpList)
                    {
                        OTAssignment oTAssignment = new OTAssignment();
                        oTAssignment.EmpKey = e.EmpKey;
                        oTAssignment.WorkDate = DateTime.Parse(fromDate, CultureInfo.GetCultureInfo("en-gb")).AddDays(i);
                        oTAssignment.OTType = OTType;
                        oTAssignment.OTHour = OTHour.ToDecimal();
                        oTAssignment.IsAssignOTOnly = chkAssignOT.ToBoolean();
                        oTAssignment.IsPunchOTOnly = chkPunchOT.ToBoolean();
                        oTAssignment.IsHigher = isHigher.ToBoolean();
                        oTAssignment.IsLower = isLower.ToBoolean();
                        DateWiseEmpList.Add(oTAssignment);
                    }
                }
                OTAssignmentManager manager = new OTAssignmentManager();
                manager.SaveOTAssignment(DateWiseEmpList);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SearchEmp()
        {
            try
            {
                //CommonHelper.CreateSearchString();
                EmpSearchManager manager = new EmpSearchManager();
                CustomList<HRM_Emp> EmpList = manager.doSearch();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");

                StaticInfo.SearchItem(EmpList, "Emp Info", "SearchEmployee", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 500, GlobalEnums.enumSearchType.StoredProcedured);
            }
            catch (SqlException ex)
            {
                string errorMsg = ExceptionHelper.getSqlExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);
            }
            catch (Exception ex)
            {
                string errorMsg = ExceptionHelper.getExceptionMessage(ex);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(errorMsg);
            }
        }
        private void ShowAllCheckOrUncheckUserWiseEmp()
        {
            try
            {
                String refSourceString = String.Empty;
                String sessionVarName = HttpContext.Current.Request.QueryString["SessionVarName"];
                String sessionVarNameSubGrid = HttpContext.Current.Request.QueryString["SessionVarNameSubGrid"];
                String userCode = HttpContext.Current.Request.QueryString["UserCode"];
                IEnumerable Items = (IEnumerable)HttpContext.Current.Session[sessionVarName];
                IList SubGridEmpList = (IList)HttpContext.Current.Session[sessionVarNameSubGrid];
                CustomList<BaseItem> baseItems = Items.ToCustomList<BaseItem>();
                foreach (BaseItem bi in baseItems)
                {
                    object check = bi.GetType().GetProperty("IsChecked").GetValue(bi, null);
                    object addedBy = bi.GetType().GetProperty("UserCode").GetValue(bi, null);
                    if (addedBy.ToString() == userCode)
                    {
                        foreach (Object O in SubGridEmpList)
                        {
                            object addedBySubGrid = O.GetType().GetProperty("AddedBy").GetValue(O, null);
                            if (addedBySubGrid.ToString() == userCode)
                            {
                                O.GetType().GetProperty("IsChecked").SetValue(O, Convert.ToBoolean(check), null);
                                //object checkSubGrid = O.GetType().GetProperty("IsChecked").GetValue(O, null);
                                //if (!Convert.ToBoolean(checkSubGrid))
                                //{
                                //    refSourceString = "False";
                                //}
                            }
                        }
                    }
                    if (!Convert.ToBoolean(check))
                    {
                        refSourceString = "True";
                    }

                }


                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void ShowAllCheckOrUncheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String sessionVarName = HttpContext.Current.Request.QueryString["SessionVarName"];
                IEnumerable Items = (IEnumerable)HttpContext.Current.Session[sessionVarName];
                CustomList<BaseItem> baseItems = Items.ToCustomList<BaseItem>();
                foreach (BaseItem bi in baseItems)
                {
                    object check = bi.GetType().GetProperty("IsChecked").GetValue(bi, null);
                    if (!Convert.ToBoolean(check))
                    {
                        refSourceString = "True";
                        break;
                    }
                }
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void ShowCalendar()
        {
            try
            {
                String refSourceString = String.Empty;
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];

                int totalDays = DateTime.Parse(toDate).Subtract(DateTime.Parse(fromDate)).Days; //DateTime.Parse(toDate, CultureInfo.GetCultureInfo("en-gb")).Subtract(DateTime.Parse(fromDate, CultureInfo.GetCultureInfo("en-gb"))).Days;
                CustomList<WHCalendar> DayList = new CustomList<WHCalendar>();
                for (int i = 0; i <= totalDays; i++)
                {
                    WHCalendar calObj = new WHCalendar();
                    calObj.Date = DateTime.Parse(fromDate).AddDays(i);
                    calObj.DateName = DateTime.Parse(fromDate).AddDays(i).ToString("dddd");
                    DayList.Add(calObj);
                }
                HttpContext.Current.Session["WHDeclaration_WHCalendarList"] = DayList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void Cal_SaveEmpListWithDayStatus()
        {
            try
            {
                String refSourceString = String.Empty;
                WHDeclarationManager manager = new WHDeclarationManager();

                CustomList<WHCalendar> lstWHEmpList = new CustomList<WHCalendar>();
                CustomList<WHCalendar> DeletedList = new CustomList<WHCalendar>();
                lstWHEmpList = (CustomList<WHCalendar>)HttpContext.Current.Session["WHDeclaration_WHEmpList"];
                if (lstWHEmpList.Count == 0)
                {
                    String dayType = HttpContext.Current.Request.QueryString["DayType"];
                    String remarks = HttpContext.Current.Request.QueryString["Remarks"];
                    String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                    String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                    String unCheckedDaysWillDeleteAutomatically = HttpContext.Current.Request.QueryString["UnCheckedDaysWillDeleteAutomatically"];
                    CustomList<WHCalendar> WHCalendarDateList = (CustomList<WHCalendar>)HttpContext.Current.Session["WHDeclaration_WHCalendarList"];
                    CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                    CustomList<WHCalendar> lstDate = WHCalendarDateList.FindAll(f => f.IsChecked);
                    CustomList<HRM_Emp> lstEmpList = EmpList.FindAll(f => f.IsChecked);
                    CustomList<WHCalendar> GetSaveCalList = manager.GetAllWHCalendar(fromDate, toDate, dayType);
                    DeletedList = GetSaveCalList;
                    foreach (HRM_Emp e in lstEmpList)
                    {
                        foreach (WHCalendar d in lstDate)
                        {
                            WHCalendar wHC = new WHCalendar();
                            wHC.EmpKey = e.EmpKey;
                            wHC.EmpCode = e.EmpCode;
                            wHC.EmpName = e.EmpName;
                            wHC.ShiftID = e.ShiftID.ToString();
                            wHC.Shift = e.Shift;
                            wHC.DateName = d.DateName;
                            wHC.WorkOffDate = d.Date;
                            wHC.DayType = dayType;
                            wHC.Remarks = remarks;
                            if (!unCheckedDaysWillDeleteAutomatically.ToBoolean())
                            {
                                WHCalendar obj = GetSaveCalList.Find(f => f.WorkOffDate == d.Date && f.EmpKey == e.EmpKey);
                                if (obj.IsNotNull())
                                {
                                    wHC.CalendarKey = obj.CalendarKey;
                                    wHC.IsSaved = true;
                                    wHC.SetModified();
                                }
                            }
                            else
                            {
                                DeletedList.Find(f => f.EmpKey == e.EmpKey).Delete();
                            }
                            lstWHEmpList.Add(wHC);
                        }
                    }

                    HttpContext.Current.Session["WHDeclaration_WHEmpList"] = lstWHEmpList;
                }
                // String settings = HttpContext.Current.Request.QueryString["Settings"];
                //if (settings == "DeleteALL")
                //lstWHEmpList.ForEach(f => f.Delete());
                manager.SaveEmpWiseCal(ref DeletedList, ref lstWHEmpList);
                CustomList<WHCalendar> Blankobj = new CustomList<WHCalendar>();
                HttpContext.Current.Session["WHDeclaration_WHEmpList"] = Blankobj;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void Cal_ShowEmpListWithDayStatus()
        {
            try
            {
                String refSourceString = String.Empty;
                WHDeclarationManager manager = new WHDeclarationManager();
                CustomList<WHCalendar> lstWHEmpList = new CustomList<WHCalendar>();
                String dayType = HttpContext.Current.Request.QueryString["DayType"];
                String remarks = HttpContext.Current.Request.QueryString["Remarks"];
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String unCheckedDaysWillDeleteAutomatically = HttpContext.Current.Request.QueryString["UnCheckedDaysWillDeleteAutomatically"];
                CustomList<WHCalendar> WHCalendarDateList = (CustomList<WHCalendar>)HttpContext.Current.Session["WHDeclaration_WHCalendarList"];
                CustomList<HRM_Emp> WEmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<WHCalendar> lstDate = WHCalendarDateList.FindAll(f => f.IsChecked);
                CustomList<HRM_Emp> lstEmpList = WEmpList.FindAll(f => f.IsChecked);
                CustomList<WHCalendar> GetSaveCalList = manager.GetAllWHCalendar(fromDate, toDate, dayType);
                foreach (HRM_Emp e in lstEmpList)
                {
                    foreach (WHCalendar d in lstDate)
                    {
                        WHCalendar wHC = new WHCalendar();
                        wHC.EmpKey = e.EmpKey;
                        wHC.EmpCode = e.EmpCode;
                        wHC.EmpName = e.EmpName;
                        wHC.ShiftID = e.ShiftID.ToString();
                        wHC.Shift = e.Shift;
                        wHC.DateName = d.DateName;
                        wHC.WorkOffDate = d.Date;
                        wHC.DayType = dayType;
                        wHC.Remarks = remarks;
                        if (!unCheckedDaysWillDeleteAutomatically.ToBoolean())
                        {
                            WHCalendar obj = GetSaveCalList.Find(f => f.WorkOffDate == d.Date && f.EmpKey == e.EmpKey);
                            if (obj.IsNotNull())
                            {
                                wHC.CalendarKey = obj.CalendarKey;
                                wHC.IsSaved = true;
                                wHC.SetModified();
                            }
                        }
                        lstWHEmpList.Add(wHC);
                    }
                }

                HttpContext.Current.Session["WHDeclaration_WHEmpList"] = lstWHEmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllSelectOrAllClearEmp()
        {
            try
            {
                String refSourceString = String.Empty;
                String status = HttpContext.Current.Request.QueryString["Status"];
                String sessionVarName = HttpContext.Current.Request.QueryString["SessionVarName"];
                //CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session[StaticInfo.EmpListSessionVarName];
                IList EmpList = (IList)HttpContext.Current.Session[sessionVarName];
                foreach (Object O in EmpList)
                {
                    O.GetType().GetProperty("IsChecked").SetValue(O, status.ToBoolean(), null);
                }
                HttpContext.Current.Session[sessionVarName] = EmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllSelectOrAllClearUserWiseEmp()
        {
            try
            {
                String refSourceString = String.Empty;
                String status = HttpContext.Current.Request.QueryString["Status"];
                String sessionVarName = HttpContext.Current.Request.QueryString["SessionVarName"];
                String sessionVarNameSubGrid = HttpContext.Current.Request.QueryString["SessionVarNameSubGrid"];
                IList ParentUserList = (IList)HttpContext.Current.Session[sessionVarName];
                IList SubGridEmpList = (IList)HttpContext.Current.Session[sessionVarNameSubGrid];
                foreach (Object O in ParentUserList)
                {
                    O.GetType().GetProperty("IsChecked").SetValue(O, status.ToBoolean(), null);
                }
                foreach (Object O in SubGridEmpList)
                {
                    O.GetType().GetProperty("IsChecked").SetValue(O, status.ToBoolean(), null);
                }
                HttpContext.Current.Session[sessionVarName] = ParentUserList;
                HttpContext.Current.Session[sessionVarNameSubGrid] = SubGridEmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllSelectOrAllClearHourlyLeaveApproval()
        {
            try
            {
                String refSourceString = String.Empty;
                String status = HttpContext.Current.Request.QueryString["Status"];
                String checkbox = HttpContext.Current.Request.QueryString["Checkbox"];
                CustomList<HourlyLeaveTrans> UnApprovedList = (CustomList<HourlyLeaveTrans>)HttpContext.Current.Session["LeaveTransactionApproval_HourlyLeaveApproval"];
                if (checkbox == "chkHourlyForwarded")
                {
                    foreach (HourlyLeaveTrans lTA in UnApprovedList)
                    {
                        lTA.IsForwarded = status.ToBoolean();
                    }
                }
                else if (checkbox == "chkHourlyRecomended")
                {
                    foreach (HourlyLeaveTrans lTA in UnApprovedList)
                    {
                        lTA.IsRecomended = status.ToBoolean();
                    }
                }
                else if (checkbox == "chkHourlyApproved")
                {
                    foreach (HourlyLeaveTrans lTA in UnApprovedList)
                    {
                        lTA.IsApproved = status.ToBoolean();
                    }
                }
                else if (checkbox == "chkHourlyRejected")
                {
                    foreach (HourlyLeaveTrans lTA in UnApprovedList)
                    {
                        lTA.IsRejected = status.ToBoolean();
                    }
                }
                HttpContext.Current.Session["LeaveTransactionApproval_HourlyLeaveApproval"] = UnApprovedList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllSelectOrAllClearLeaveApproval()
        {
            try
            {
                String refSourceString = String.Empty;
                String status = HttpContext.Current.Request.QueryString["Status"];
                String checkbox = HttpContext.Current.Request.QueryString["Checkbox"];
                CustomList<LeaveTransApproved> UnApprovedList = (CustomList<LeaveTransApproved>)HttpContext.Current.Session["LeaveTransactionApproval_DayLeaveApproval"];
                if (checkbox == "chkForwarded")
                {
                    foreach (LeaveTransApproved lTA in UnApprovedList)
                    {
                        lTA.IsForwarded = status.ToBoolean();
                    }
                }
                else if (checkbox == "chkRecomended")
                {
                    foreach (LeaveTransApproved lTA in UnApprovedList)
                    {
                        lTA.IsRecomended = status.ToBoolean();
                    }
                }
                else if (checkbox == "chkApproved")
                {
                    foreach (LeaveTransApproved lTA in UnApprovedList)
                    {
                        lTA.IsApproved = status.ToBoolean();
                    }
                }
                else if (checkbox == "chkRejected")
                {
                    foreach (LeaveTransApproved lTA in UnApprovedList)
                    {
                        lTA.IsRejected = status.ToBoolean();
                    }
                }
                HttpContext.Current.Session["LeaveTransactionApproval_DayLeaveApproval"] = UnApprovedList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllSelectOrAllClear()
        {
            try
            {
                String refSourceString = String.Empty;
                String status = HttpContext.Current.Request.QueryString["Status"];
                CustomList<WHCalendar> WHCalendarList = (CustomList<WHCalendar>)HttpContext.Current.Session["WHDeclaration_WHCalendarList"];
                foreach (WHCalendar WHC in WHCalendarList)
                {
                    WHC.IsChecked = status.ToBoolean();
                }
                HttpContext.Current.Session["WHDeclaration_WHCalendarList"] = WHCalendarList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void CheckOrUnCheckWeekend()
        {
            try
            {
                String refSourceString = String.Empty;
                String weekend = HttpContext.Current.Request.QueryString["Weekend"];
                String status = HttpContext.Current.Request.QueryString["Status"];
                CustomList<WHCalendar> WHCalendarList = (CustomList<WHCalendar>)HttpContext.Current.Session["WHDeclaration_WHCalendarList"];
                foreach (WHCalendar WHC in WHCalendarList)
                {
                    if (WHC.DateName == weekend)
                    {
                        WHC.IsChecked = status.ToBoolean();
                    }
                }
                HttpContext.Current.Session["WHDeclaration_WHCalendarList"] = WHCalendarList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void GetFromDateAndToDate()
        {
            try
            {
                String refSourceString = String.Empty;
                SettingsManager Manager = new SettingsManager();
                String YearNo = HttpContext.Current.Request.QueryString["YearNo"];
                String MonthNo = HttpContext.Current.Request.QueryString["MonthNo"];


                CustomList<Settings> SettingsInfo = Manager.GetFromDateToDate(YearNo, MonthNo);
                HttpContext.Current.Session[StaticInfo.EmpListSessionVarName] = SettingsInfo;
                refSourceString = SettingsInfo[0].DATA1 + "," + SettingsInfo[0].DATA2 + "," + SettingsInfo[0].DATA3;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SalaryProcess()
        {
            try
            {
                String refSourceString = String.Empty;
                TempEmpManager TempCodeManager = new TempEmpManager();
                String spName = HttpContext.Current.Request.QueryString["SpName"];
                String YearNo = HttpContext.Current.Request.QueryString["YearNo"];
                String MonthNo = HttpContext.Current.Request.QueryString["MonthNo"];
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                SalaryProcessManager manager = new SalaryProcessManager();
                CustomList<HRM_Emp> WEmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> lstEmpList = WEmpList.FindAll(f => f.IsModified);

                //----------------------TempEmpListForSalary Table-----------------------------
                CustomList<TempEmpListForSalary> lstemp = new CustomList<TempEmpListForSalary>();


                foreach (HRM_Emp e in lstEmpList)
                {
                    ASL.Hr.DAO.TempEmpListForSalary newemp = new ASL.Hr.DAO.TempEmpListForSalary();
                    newemp.EmpKey = e.EmpKey;
                    lstemp.Add(newemp);

                }

                manager.DeleteTempEmpListSalary();
                manager.SaveTempEmpListSalary(ref lstemp);

                //CustomList<TempEmpCode> TempCode = new CustomList<TempEmpCode>();
                //string tableName = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                //HttpContext.Current.Session["TableName"] = tableName;
                //foreach (HRM_Emp e in lstEmpList)
                //{
                //    TempEmpCode obj = new TempEmpCode();
                //    obj.TableName = tableName;
                //    obj.EmpKey = e.EmpKey;

                //    TempCode.Add(obj);
                //}
                //TempCodeManager.SaveSettings(ref TempCode);
                //CustomList<SalaryProcess> objProcessedSalary = manager.doSalaryProcess(spName, YearNo, MonthNo, fromDate, toDate, tableName);


                //HttpContext.Current.Session["SalaryProcess_SalaryProcessList"] = objProcessedSalary;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        private void SalaryProcessSave()
        {
            try
            {
                String refSourceString = String.Empty;


                SalaryProcessManager manager = new SalaryProcessManager();
                TempEmpManager tempEmpManager = new TempEmpManager();

                CustomList<SalaryProcess> objSalaryProcessForSave = new CustomList<ASL.Hr.DAO.SalaryProcess>();
                objSalaryProcessForSave = (CustomList<SalaryProcess>)HttpContext.Current.Session["SalaryProcess_SalaryProcessList"];

                CustomList<TempEmpCode> objTempEmp = new CustomList<TempEmpCode>();
                string tableName = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                foreach (SalaryProcess e in objSalaryProcessForSave)
                {
                    TempEmpCode t = new TempEmpCode();
                    t.EmpKey = e.EmpKey;
                    if (objTempEmp.Find(f => f.EmpKey == t.EmpKey).IsNull())
                    {
                        t.TableName = tableName;
                        t.SetAdded();
                        objTempEmp.Add(t);
                    }
                    e.SetAdded();
                }

                string YearNo = objSalaryProcessForSave[0].YearNo.ToString();
                string MonthNo = objSalaryProcessForSave[0].MonthNo.ToString();
                HttpContext.Current.Session["TableName"] = tableName;
                tempEmpManager.SaveSettings(ref objTempEmp);

                manager.deleteProcessedSalary(tableName, YearNo, MonthNo);
                manager.SaveSalaryProcess(ref objSalaryProcessForSave);


                CustomList<SalaryProcess> objBlank = new CustomList<ASL.Hr.DAO.SalaryProcess>();
                HttpContext.Current.Session["SalaryProcess_SalaryProcessList"] = objBlank;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ShowAllEmpForCalendar()
        {
            try
            {
                String refSourceString = String.Empty;
                String spName = HttpContext.Current.Request.QueryString["SpName"];
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                EmpSearchManager manager = new EmpSearchManager();

                CustomList<HRM_Emp> EmpList = manager.GetAllViewEmp(spName, fromDate, toDate);
                HttpContext.Current.Session[StaticInfo.EmpListSessionVarName] = EmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ShowAllEmpForManualAtt()
        {
            try
            {
                String refSourceString = String.Empty;
                String spName = HttpContext.Current.Request.QueryString["SpName"];
                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                String str = HttpContext.Current.Request.QueryString["Str"];
                EmpSearchManager manager = new EmpSearchManager();

                CustomList<HRM_Emp> EmpList = manager.GetAllViewEmp(spName, fromDate, toDate, str);
                HttpContext.Current.Session[StaticInfo.EmpListSessionVarName] = EmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitParameterTableValue()
        {
            try
            {
                String columnName = HttpContext.Current.Request.QueryString["ColumnName"];
                ParameterValueManager manager = new ParameterValueManager();
                String response = "TRUE";

                //Filter
                CustomList<FilterSets> filterSetList = (CustomList<FilterSets>)HttpContext.Current.Session["ReportViewer_FilterSetList"];
                CustomList<ParameterFilterValue> filterValueList = new CustomList<ParameterFilterValue>();
                SetValue();
                //if (columnName == "Branch")
                //{
                //    FilterSets objCompany = filterSetList.Find(f => f.ColumnName == "Company");
                //    if (objCompany.ColumnActualValue == "")
                //    {
                //        throw new Exception("Please Select Company.");
                //    }
                //    else
                //    {
                //        filterValueList = manager.GetReportValue(objCompany.ColumnActualValue);
                //        HttpContext.Current.Session["ReportViewer_FilterValueList"] = filterValueList;
                //    }
                //}
                //else if (columnName == "Department")
                //{
                //    FilterSets objBranch = filterSetList.Find(f => f.ColumnName == "Branch");
                //    if (objBranch.ColumnActualValue == "")
                //    {
                //        throw new Exception("Please Select Branch.");
                //    }
                //    else
                //    {
                //        filterValueList = manager.GetReportValue(objBranch.ColumnActualValue);
                //        HttpContext.Current.Session["ReportViewer_FilterValueList"] = filterValueList;
                //    }
                //}
                //else if (columnName == "FiscalYear")
                //{
                //    FilterSets objCompany = filterSetList.Find(f => f.ColumnName == "Company");
                //    if (objCompany.ColumnActualValue == "")
                //    {
                //        throw new Exception("Please Select Company.");
                //    }
                //    else
                //    {
                //        filterValueList = manager.GetReportValueFY(objCompany.ColumnActualValue);
                //        HttpContext.Current.Session["ReportViewer_FilterValueList"] = filterValueList;
                //    }
                //}
                //else if (columnName == "Designation")
                //{
                //    FilterSets objCompany = filterSetList.Find(f => f.ColumnName == "Company");
                //    if (objCompany.ColumnActualValue == "")
                //    {
                //        throw new Exception("Please Select Company.");
                //    }
                //    else
                //    {
                //        filterValueList = manager.GetReportValueDesig(objCompany.ColumnActualValue);
                //        HttpContext.Current.Session["ReportViewer_FilterValueList"] = filterValueList;
                //    }
                //}
                //else if (columnName == "EmpName")
                //{
                //    FilterSets objDepartment = filterSetList.Find(f => f.ColumnName == "Department");
                //    FilterSets objBranch = filterSetList.Find(f => f.ColumnName == "Branch");
                //    FilterSets objCompany = filterSetList.Find(f => f.ColumnName == "Company");
                //    string search = "";
                //    if (objCompany.ColumnActualValue != "")
                //    {
                //        search = "@OrgKey=" + objCompany.ColumnActualValue;
                //    }
                //    if (objBranch.ColumnActualValue != "")
                //    {
                //        search = search + ",@BranchKey=" + objBranch.ColumnActualValue;
                //    }
                //    if (objDepartment.ColumnActualValue != "")
                //    {
                //        search = search + ",@DepartmentKey=" + objDepartment.ColumnActualValue;
                //    }
                //    if (search != "")
                //    {
                //        filterValueList = manager.GetReportValueEmp(search);
                //        HttpContext.Current.Session["ReportViewer_FilterValueList"] = filterValueList;
                //    }
                //    else
                //    {
                //        throw new Exception("Please Select Company.");
                //    }
                //}
                //else
                //{
                //    SetValue();
                //}
                //Filter

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(ex);
            }
        }
        private void SetValue()
        {
            try
            {
                DataTable dtParamValues = null;
                String columnName = HttpContext.Current.Request.QueryString["ColumnName"];
                String displayColumnName = String.Format("{0}DisplayMember", columnName);
                String actualValuesColumnName = String.Format("{0}ActualValues", columnName);
                CustomList<FilterSets> filterSetList = (CustomList<FilterSets>)HttpContext.Current.Session["ReportViewer_FilterSetList"];
                if (columnName.IsNotNullOrEmpty())
                {
                    CustomList<ParameterFilterValue> filterValueList = new CustomList<ParameterFilterValue>();
                    DataSet ParameterValues = (DataSet)HttpContext.Current.Session["ReportViewer_ParameterValues"];
                    if (ParameterValues.Tables["ParameterValues"].Columns.Contains(columnName))
                    {
                        if (ParameterValues.Tables["ParameterValues"].Columns.Contains(actualValuesColumnName))
                            dtParamValues = ParameterValues.Tables["ParameterValues"].DefaultView.ToTable(true, columnName, actualValuesColumnName);
                        else
                        {
                            dtParamValues = ParameterValues.Tables["ParameterValues"].DefaultView.ToTable(true, columnName);
                            displayColumnName = columnName;
                        }
                        foreach (DataRow dr in dtParamValues.Rows)
                        {
                            filterValueList.Add(new ParameterFilterValue { Values = dr[columnName].ToString(), DisplayMember = dr[columnName].ToString(), ActualValues = dr[actualValuesColumnName].ToString() });
                        }
                    }
                    HttpContext.Current.Session["ReportViewer_FilterValueList"] = filterValueList;
                }
                return;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetSelectedParameterValueInParameterGrid()
        {
            try
            {
                String vid = HttpContext.Current.Request.QueryString["vid"];
                String selectedVids = HttpContext.Current.Request.QueryString["SelectedVids"];
                String response = "TRUE";
                String selectedValues = String.Empty;
                String selectedActualValues = String.Empty;
                if (vid.IsNotNullOrEmpty() && selectedVids.IsNotNullOrEmpty())
                {
                    CustomList<FilterSets> filterSetList = (CustomList<FilterSets>)HttpContext.Current.Session["ReportViewer_FilterSetList"];
                    CustomList<ParameterFilterValue> FilterValueList = (CustomList<ParameterFilterValue>)HttpContext.Current.Session["ReportViewer_FilterValueList"];

                    FilterSets filterItem = filterSetList.Find(item => item.VID == vid.ToInt());
                    //shamim For Filter
                    /*if (filterItem.ColumnName == "Company")
                    {
                        CustomList<FilterSets> BranchAndDepartment = filterSetList.FindAll(f => f.ColumnName == "Branch" || f.ColumnName == "Department" || f.ColumnName == "FiscalYear" || f.ColumnName == "EmpName");
                        foreach (FilterSets fS in BranchAndDepartment)
                        {
                            FilterSets fSObj = filterSetList.Find(f => f.ColumnName == fS.ColumnName);
                            {
                                fSObj.Operators = "=";
                                fSObj.ColumnValue = "";
                                fSObj.ColumnActualValue = "";
                            }
                        }
                    }
                    if (filterItem.ColumnName == "Branch")
                    {
                        FilterSets objDepartment = filterSetList.Find(f => f.ColumnName == "Department");
                        objDepartment.Operators = "=";
                        objDepartment.ColumnValue = "";
                        objDepartment.ColumnActualValue = "";
                        FilterSets objEmpName = filterSetList.Find(f => f.ColumnName == "EmpName");
                        objEmpName.Operators = "=";
                        objEmpName.ColumnValue = "";
                        objEmpName.ColumnActualValue = "";
                    }
                    if (filterItem.ColumnName == "Department")
                    {
                        FilterSets objEmpName = filterSetList.Find(f => f.ColumnName == "EmpName");
                        objEmpName.Operators = "=";
                        objEmpName.ColumnValue = "";
                        objEmpName.ColumnActualValue = "";
                    }*/
                    //End Filter
                    if (filterItem.IsNotNull())
                    {
                        String[] vidList = selectedVids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        CustomList<ParameterFilterValue> searchList = FilterValueList.FindAll(p => vidList.Contains(p.VID.ToString()));
                        if (searchList.Count > 1)
                        {
                            foreach (ParameterFilterValue param in searchList)
                            {
                                selectedValues += String.Format("{0},", param.Values);
                                selectedActualValues += String.Format("{0},", param.ActualValues);
                            }
                            filterItem.Operators = "In";
                            if (selectedValues.IsNotNullOrEmpty())
                                selectedValues = selectedValues.Substring(0, selectedValues.Length - 1);
                            if (selectedActualValues.IsNotNullOrEmpty())
                                selectedActualValues = selectedActualValues.Substring(0, selectedActualValues.Length - 1);
                        }
                        else
                        {
                            foreach (ParameterFilterValue param in searchList)
                            {
                                selectedValues = param.Values;
                                selectedActualValues = param.ActualValues;
                            }
                        }
                        filterItem.ColumnValue = selectedValues;
                        filterItem.ColumnActualValue = selectedActualValues;
                    }
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetSelectedParameterValueInParameterGridForSearch()
        {
            try
            {
                String vid = HttpContext.Current.Request.QueryString["vid"];
                String selectedVids = HttpContext.Current.Request.QueryString["SelectedVids"];
                String response = "TRUE";
                String selectedValues = String.Empty;
                String selectedDisplayValues = String.Empty;
                EmpSearchManager manager = new EmpSearchManager();
                if (vid.IsNotNullOrEmpty() && selectedVids.IsNotNullOrEmpty())
                {
                    CustomList<EmpFilterSets> filterSetList = (CustomList<EmpFilterSets>)HttpContext.Current.Session["ucEmpSearch_FilterSetsList"];
                    CustomList<HouseKeepingValue> FilterValueList = (CustomList<HouseKeepingValue>)HttpContext.Current.Session["ucEmpSearch_EntityList"];

                    string previousColumnValue = "";
                    EmpFilterSets filterItem = filterSetList.Find(item => item.VID == vid.ToInt());
                    if (filterItem.IsNotNull())
                    {
                        //previousColumnValue = filterItem.ColumnValue;
                        String[] vidList = selectedVids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        CustomList<HouseKeepingValue> searchList = FilterValueList.FindAll(p => vidList.Contains(p.VID.ToString()));
                        if (searchList.Count > 1)
                        {
                            foreach (HouseKeepingValue param in searchList)
                            {
                                selectedValues += String.Format("{0},", param.HKID);
                                selectedDisplayValues += String.Format("{0},", param.HKName);
                            }
                            filterItem.Operators = "In";
                            if (selectedValues.IsNotNullOrEmpty())
                            {
                                selectedValues = selectedValues.Substring(0, selectedValues.Length - 1);
                                selectedDisplayValues = selectedDisplayValues.Substring(0, selectedDisplayValues.Length - 1);
                            }
                        }
                        else
                        {
                            foreach (HouseKeepingValue param in searchList)
                            {
                                selectedValues = param.HKID.ToString();
                                selectedDisplayValues = param.HKName;
                            }
                        }
                        filterItem.ColumnValue = selectedValues;
                        filterItem.DisplaySeletedColumnValue = selectedDisplayValues;
                        previousColumnValue = selectedValues;
                    }
                    /*do
                    {
                        if (previousColumnValue != "")
                        {
                            string search = "select Distinct HKV.*from HousekeepingHierarchy HKH  INNER JOIN HouseKeepingValue HKV ON  HKV.HKID=HKH.HKID where HKH.ParentID IN(" + previousColumnValue + ")";
                            CustomList<HouseKeepingValue> ElementList = manager.GetAllHouseKeepingValue(search, "");
                            if (ElementList.Count != 0)
                            {
                                previousColumnValue = filterSetList.Find(f => f.EntityID == ElementList[0].EntityID).ColumnValue;
                                filterSetList.Find(f => f.EntityID == ElementList[0].EntityID).DisplaySeletedColumnValue = "";
                                filterSetList.Find(f => f.EntityID == ElementList[0].EntityID).Operators = "=";
                            }
                            else
                            {
                                previousColumnValue = "";
                            }
                        }
                    } while (previousColumnValue != "");*/
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SearchOption()
        {
            try
            {
                String response = String.Empty;
                EmpSearchManager manager = new EmpSearchManager();
                String entityId = HttpContext.Current.Request.QueryString["EntityID"];

                Int32 parent = manager.GetAllEntityList(entityId);
                EmpFilterSets checkParent = ((CustomList<EmpFilterSets>)HttpContext.Current.Session["ucEmpSearch_FilterSetsList"]).Find(f => f.EntityID == parent);
                if (parent != 0 && checkParent.IsNotNull())
                {
                    string search = "select Distinct HKV.*from HousekeepingHierarchy HKH  INNER JOIN HouseKeepingValue HKV ON  HKV.HKID=HKH.HKID where HKH.ParentID IN(" + checkParent.ColumnValue + ") and HKV.EntityID=" + entityId.ToInt();
                    CustomList<HouseKeepingValue> ElementList = manager.GetAllHouseKeepingValue(search, "");
                    HttpContext.Current.Session["ucEmpSearch_EntityList"] = ElementList;
                }
                else
                {
                    CustomList<HouseKeepingValue> ElementList = manager.GetAllHouseKeepingValue(entityId);
                    HttpContext.Current.Session["ucEmpSearch_EntityList"] = ElementList;
                }



                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ParentList()
        {
            try
            {
                String refSourceString = String.Empty;
                String entityKey = HttpContext.Current.Request.QueryString["EntityKey"];
                HKEntryManager manager = new HKEntryManager();
                CustomList<HouseKeepingValue> HKValueList = new CustomList<HouseKeepingValue>();
                HttpContext.Current.Session["HouseKeepingEntry_ParentList"] = HKValueList;

                Int32 parent = manager.GetAllEntityList(entityKey);
                if (parent != 0)
                {
                    CustomList<HouseKeepingValue> HKList = manager.GetAllHouseKeepingValue(parent.ToString());
                    HttpContext.Current.Session["HouseKeepingEntry_ParentList"] = HKList;
                }

                refSourceString = parent.ToString();

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void DuplicateEntityNameCheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String entityName = HttpContext.Current.Request.QueryString["EntityName"];
                String vid = HttpContext.Current.Request.QueryString["VID"];
                CustomList<EntityList> EntityList = (CustomList<EntityList>)HttpContext.Current.Session["Entity_EntityList"];

                EntityList entityNameObj = EntityList.Find(f => f.EntityName.ToLower() == entityName.ToLower() && f.VID != vid.ToInt());
                EntityList chkAdded = EntityList.Find(f => f.EntityName.ToLower() == entityName.ToLower() && f.VID != vid.ToInt() && f.IsAdded);
                if ((entityNameObj.IsNotNull() && !entityNameObj.IsDeleted) || (entityNameObj.IsNotNull() && chkAdded.IsNotNull()))
                {
                    refSourceString = "True";
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void GetAttnSummary()
        {
            try
            {
                String refSourceString = String.Empty;
                String response = "";
                String Workdate = HttpContext.Current.Request.QueryString["Workdate"];
                DailyAttendanceManger dailyAttManger = new DailyAttendanceManger();
                CustomList<ASL.Hr.DAO.AttnendanceSummary> AttnSummaryOfLastProcessDate = dailyAttManger.GetAllAttnendanceSummary(Workdate);

                response = "Total Employee : " + AttnSummaryOfLastProcessDate[0].TotalEmployee.ToString() + ", Attn Processed : " + AttnSummaryOfLastProcessDate[0].ProcessedEmployee.ToString() +
                    ", Present : " + AttnSummaryOfLastProcessDate[0].Present.ToString() + ", Late : " + AttnSummaryOfLastProcessDate[0].Late.ToString() + ", Absent : " + AttnSummaryOfLastProcessDate[0].Absent.ToString() +
                ", Leave : " + AttnSummaryOfLastProcessDate[0].Leave.ToString() + ", WH : " + AttnSummaryOfLastProcessDate[0].WH.ToString() + ", Others : " +
                AttnSummaryOfLastProcessDate[0].Others.ToString();




                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ShowAllEmpForAttProcessForRowData()
        {
            try
            {
                String refSourceString = String.Empty;

                String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                String toDate = HttpContext.Current.Request.QueryString["toDate"];
                String Settings = HttpContext.Current.Request.QueryString["Str"];
                //AttendanceManager manager = new AttendanceManager();
                string PW = "3", PH = "3", PLV = "3", SinglePunch = "2";
                if (Settings.IsNotNull())
                {
                    string[] items = Settings.Split(',');
                    if (items[1] == "true") PW = "1"; else if (items[3] == "true") PW = "2"; else PW = "3";
                    if (items[7] == "true") PH = "1"; else if (items[9] == "true") PH = "2"; else PH = "3";
                    if (items[13] == "true") PLV = "1"; else if (items[15] == "true") PLV = "2"; else PLV = "3";
                    if (items[19] == "true") SinglePunch = "1"; else SinglePunch = "2";
                }





                DailyAttendanceManger manager = new DailyAttendanceManger();
                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> CheckedEmpList = EmpList.FindAll(f => f.IsChecked);
                String searchStr = "";
                foreach (HRM_Emp e in CheckedEmpList)
                {
                    if (searchStr == "")
                        searchStr = e.EmpKey.ToString();
                    else
                        searchStr = searchStr + "," + e.EmpKey.ToString();
                }
                //manager.SaveTmpAttEmp(ref CheckedEmpList);
                CustomList<DailyAttendance> DailyAttendanceList = manager.GetAllAttForDailyAttendanceProcess(fromDate, toDate, searchStr, PW, PH, PLV, SinglePunch);
                //foreach()

                //CustomList<DailyAttendance> FinalAttendanceList = new CustomList<DailyAttendance>();
                //FinalAttendanceList = DailyAttendanceList.FindAll(f => f.Workdate != DateTime.MinValue);
                //FinalAttendanceList.ForEach(f => f.SetAdded());

                //TimeSpan ts = (toDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat) - fromDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat));
                //int days = ts.Days + 1;
                //foreach (DailyAttendance e in DailyAttendanceList)
                //{
                //    for (int i = 0; i < days; i++)
                //    {
                //        DateTime workDate = fromDate.ToDateTime(StaticInfo.GridDateFormat).AddDays(i);
                //        DailyAttendance dA = FinalAttendanceList.Find(f => f.EmpKey == e.EmpKey && f.Workdate == workDate && f.ShiftID == e.ShiftID);
                //        if (dA.IsNull())
                //        {
                //            DailyAttendance dAObj = new DailyAttendance();
                //            dAObj.EmpKey = e.EmpKey;
                //            dAObj.EmpCode = e.EmpCode;
                //            dAObj.EmpName = e.EmpName;
                //            dAObj.ShiftID = e.ShiftID;
                //            dAObj.ALISE = e.ALISE;
                //            dAObj.ShiftIntime = e.ShiftIntime;
                //            dAObj.ShiftOutTime = e.ShiftOutTime;
                //            dAObj.Workdate = workDate;
                //            dAObj.DayStatus = manager.GetDayStatus(e.EmpKey, e.ShiftID.ToInt(), workDate.ToString("dd/MM/yyyy"));
                //            FinalAttendanceList.Add(dAObj);
                //        }
                //    }
                //}

                HttpContext.Current.Session["AttendanceProcess_DailyAttendanceList"] = (CustomList<DailyAttendance>)DailyAttendanceList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ClearOutOfOfficeInfoGrid()
        {
            try
            {
                String refSourceString = String.Empty;

                CustomList<OutOfOfficeInfo> OutOfOfficeInfoList = new CustomList<OutOfOfficeInfo>();
                HttpContext.Current.Session["OutOfOfficeEntry_EmpList"] = OutOfOfficeInfoList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void OutOfOfficeEntry()
        {
            try
            {
                String refSourceString = String.Empty;

                OutOffOfficeEntryManager manager = new OutOffOfficeEntryManager();
                CustomList<OutOfOfficeInfo> OutOfOfficeInfoList = (CustomList<OutOfOfficeInfo>)HttpContext.Current.Session["OutOfOfficeEntry_EmpList"];
                CustomList<OutOfOfficeInfo> ModifiedList = OutOfOfficeInfoList.FindAll(f => f.IsModified);
                foreach (OutOfOfficeInfo OOI in ModifiedList)
                {
                    if (OOI.IsDefault && OOI.RowID == 0)
                    {
                        OOI.SetAdded();
                    }
                    else if (OOI.RowID != 0 && !OOI.IsDefault)
                    {
                        OOI.Delete();
                    }
                }
                manager.SaveOutOfOfficeEntry(ref ModifiedList);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ShowAllEmpForOutOfOfficeEntry()
        {
            try
            {
                String refSourceString = String.Empty;


                String date = HttpContext.Current.Request.QueryString["Date"];
                OutOffOfficeEntryManager manager = new OutOffOfficeEntryManager();
                CustomList<OutOfOfficeInfo> OutOfOfficeInfoList = manager.GetAllOutOutOfOfficeEntry(date);
                HttpContext.Current.Session["OutOfOfficeEntry_EmpList"] = OutOfOfficeInfoList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SaveValidData()
        {
            try
            {
                String refSourceString = String.Empty;

                AttendanceManager manager = new AttendanceManager();
                CustomList<ATT_IO> ValidDeviceDataList = (CustomList<ATT_IO>)HttpContext.Current.Session["AttendImport_AttValidDataList"];
                manager.SaveAtt_IO(ref ValidDeviceDataList);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #region DateDifference
        private void DateDifference()
        {
            try
            {
                String response = "";
                String strStartDate = HttpContext.Current.Request.QueryString["StartDate"];
                String strEndDate = HttpContext.Current.Request.QueryString["EndDate"];

                if (String.IsNullOrEmpty(strStartDate) == false && String.IsNullOrEmpty(strEndDate) == false)
                {
                    if (strStartDate != "" && strEndDate != "")
                    {
                        TimeSpan ts = (strEndDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat) - strStartDate.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat));
                        response = ts.Days.ToString();
                    }
                }
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Employee Information
        private void EmployeeInformationFind()
        {
            try
            {
                String response = "";
                String strEmployeeCode = HttpContext.Current.Request.QueryString["strEmployeeCode"];
                HRM_Emp Emp = new HRM_Emp(); ;
                Emp = HRM_Emp.GetEmployeeServiceInformation(strEmployeeCode);

                if (Emp.IsNotNull())
                {
                    response += " { EmpKey:'" + Emp.EmpKey + "'";
                    response += ",EmpName:'" + Emp.EmpName + "'";
                    //response += ",OrgDesc:'" + Emp.OrgDesc + "'";
                    //response += ",DesigName:'" + Emp.DesigName + "'";
                    //response += ",Grade:'" + Emp.Grade + "'";
                    //response += ",GradeKey:'" + Emp.GradeKey + "'";
                    //response += ",OrgKey:'" + Emp.OrgKey + "'";
                    //response += ",Department:'" + Emp.Department + "'";
                    //response += ",EmpTypeName:'" + Emp.EmpTypeName + "'";
                    //response += ",DOJ:'" + Emp.DOJ.ToString(ASL.STATIC.StaticInfo.GridDateFormat) + "'";
                    //response += ",ExamName:'" + Emp.ExamName + "'";
                    //response += ",EmpPresentExpre:'" + Emp.EmpPresentExpre.ToString() + "'";
                    //response += ",ActualExperiance:'" + Emp.ActualExperiance.ToString() + "' }";

                }
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        private void IsDefaultEmpAtt()
        {
            try
            {
                String refSourceString = String.Empty;

                String id = HttpContext.Current.Request.QueryString["ID"];
                CustomList<ATT_IO> ClearGridList = new CustomList<ATT_IO>();
                CustomList<ATT_IO> EmpAttList = (CustomList<ATT_IO>)HttpContext.Current.Session["EmployeeAttendace_AttList"];
                ATT_IO ObjAIO = EmpAttList.Find(f => f.VID == id.ToInt());
                if (ObjAIO.IsDefault)
                {
                    ObjAIO.InTime = "09:15:00".ToDateTime().TimeOfDay;
                    ObjAIO.OutTime = "06:00:00".ToDateTime().TimeOfDay;
                }
                else
                {
                    ObjAIO.InTime = "00:00:00".ToDateTime().TimeOfDay;
                    ObjAIO.OutTime = "00:00:00".ToDateTime().TimeOfDay;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ClearEmployeeAttendanceGrid()
        {
            try
            {
                String refSourceString = String.Empty;
                CustomList<ATT_IO> ClearGridList = new CustomList<ATT_IO>();
                HttpContext.Current.Session["EmployeeAttendace_AttList"] = ClearGridList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ModifyAttProcess()
        {
            try
            {
                String refSourceString = String.Empty;

                AttendanceManager manager = new AttendanceManager();
                String date = HttpContext.Current.Request.QueryString["Date"];
                CustomList<ATT_IO> EmpAttList = (CustomList<ATT_IO>)HttpContext.Current.Session["EmployeeAttendace_AttList"];
                CustomList<ATT_IO> ModifiedEmpAttList = EmpAttList.FindAll(f => f.IsModified);
                foreach (ATT_IO att in ModifiedEmpAttList)
                {
                    att.SetAdded();
                    att.AttDate = date.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
                    att.IsManual = true;
                }
                manager.SaveAtt_IO(ref ModifiedEmpAttList);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ShowAllEmpForAttProcess()
        {
            try
            {
                String refSourceString = String.Empty;

                String date = HttpContext.Current.Request.QueryString["Date"];
                AttendanceManager manager = new AttendanceManager();
                CustomList<ATT_IO> AttEmpList = manager.GetAllAttForManualProcess(date);
                HttpContext.Current.Session["EmployeeAttendace_AttList"] = AttEmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void EmployeeServiceInfo()
        {
            try
            {
                String refSourceString = String.Empty;
                String empKey = HttpContext.Current.Request.QueryString["empKey"];
                HRM_Emp Emp = new HRM_Emp(); ;
                if (String.IsNullOrEmpty(empKey) == false)
                {
                    Emp = HRM_Emp.GetEmployeeServiceInformation(empKey);
                }
                refSourceString = Emp.EmpName + "|";
                //refSourceString += Emp.DesigName + "|";
                //refSourceString += Emp.DesigName + "|";
                //refSourceString += Emp.Department + "|";
                //refSourceString += Emp.EmpTypeName + "|";
                //refSourceString += Emp.ExamName + "|";
                //refSourceString += Emp.EmpPresentExpre + "|";
                //refSourceString += Emp.DOJ + "|";
                //refSourceString += Emp.PermanentDate + "|";
                //refSourceString += Emp.Grade + "|";
                //refSourceString += Emp.Department + "|";
                //refSourceString += Emp.ActualExperiance + "|";

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void MenuAllCheckOrUncheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String columnName = HttpContext.Current.Request.QueryString["ColumnName"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                if (columnName == "CanInsert")
                {
                    Menu objInsert = MenuList.Find(f => f.CanInsert == false);
                    if (objInsert.IsNotNull())
                    {
                        refSourceString = "True";
                    }
                }
                else if (columnName == "CanSelect")
                {
                    Menu objSelect = MenuList.Find(f => f.CanSelect == false);
                    if (objSelect.IsNotNull())
                    {
                        refSourceString = "True";
                    }
                }
                else if (columnName == "CanUpdate")
                {
                    Menu objUpdate = MenuList.Find(f => f.CanUpdate == false);
                    if (objUpdate.IsNotNull())
                    {
                        refSourceString = "True";
                    }
                }
                else if (columnName == "CanDelete")
                {
                    Menu objDelete = MenuList.Find(f => f.CanDelete == false);
                    if (objDelete.IsNotNull())
                    {
                        refSourceString = "True";
                    }
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllDeleteCheckedOrUnchecked()
        {
            try
            {
                String refSourceString = String.Empty;
                String chkOrUnUnchk = HttpContext.Current.Request.QueryString["ChkOrUnchk"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                foreach (Menu m in MenuList)
                {
                    m.CanDelete = chkOrUnUnchk.ToBoolean();
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllUpdateCheckedOrUnchecked()
        {
            try
            {
                String refSourceString = String.Empty;
                String chkOrUnUnchk = HttpContext.Current.Request.QueryString["ChkOrUnchk"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                foreach (Menu m in MenuList)
                {
                    m.CanUpdate = chkOrUnUnchk.ToBoolean();
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void AllInsertCheckedOrUnchecked()
        {
            try
            {
                String refSourceString = String.Empty;
                String chkOrUnUnchk = HttpContext.Current.Request.QueryString["ChkOrUnchk"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                foreach (Menu m in MenuList)
                {
                    m.CanInsert = chkOrUnUnchk.ToBoolean();
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void AllSelectCheckedOrUnchecked()
        {
            try
            {
                String refSourceString = String.Empty;
                String chkOrUnUnchk = HttpContext.Current.Request.QueryString["ChkOrUnchk"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                foreach (Menu m in MenuList)
                {
                    m.CanSelect = chkOrUnUnchk.ToBoolean();
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void PopulateGrideWithMenu()
        {
            try
            {
                SecurityManager manager = new SecurityManager();
                String response = String.Empty;
                String applicationID = HttpContext.Current.Request.QueryString["ApplicationID"];
                CustomList<ASL.Security.DAO.Menu> menu = manager.GetAllMenuByApplicationID(applicationID.ToString());
                CustomList<Menu> MenuList = new CustomList<Menu>();
                MenuList = menu.FindAll(f => f.FormName != "");
                CustomList<RuleDetails> SecurityRuleDetailList = (CustomList<RuleDetails>)HttpContext.Current.Session["SecurityRule_SecurityRuleDetailList"];
                foreach (ASL.Security.DAO.Menu m in MenuList)
                {
                    CustomList<RuleDetails> tSROList = SecurityRuleDetailList.FindAll(f => f.ObjectID == m.MenuID && f.ApplicationID == m.ApplicationID);
                    foreach (RuleDetails tSRO in tSROList)
                    {
                        m.CanInsert = tSRO.CanInsert;
                        m.CanSelect = tSRO.CanSelect;
                        m.CanUpdate = tSRO.CanUpdate;
                        m.CanDelete = tSRO.CanDelete;
                    }
                }
                HttpContext.Current.Session["SecurityRule_MenuList"] = MenuList;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //private void InitParameterTableValue()
        //{
        //    try
        //    {
        //        DataTable dtParamValues = null;
        //        String columnName = HttpContext.Current.Request.QueryString["ColumnName"];
        //        String displayColumnName = String.Format("{0}DisplayMember", columnName);
        //        String response = "TRUE";
        //        if (columnName.IsNotNullOrEmpty())
        //        {
        //            CustomList<ParameterFilterValue> filterValueList = new CustomList<ParameterFilterValue>();
        //            DataSet ParameterValues = (DataSet)HttpContext.Current.Session["ReportViewer_ParameterValues"];
        //            if (ParameterValues.Tables["ParameterValues"].Columns.Contains(columnName))
        //            {
        //                if (ParameterValues.Tables["ParameterValues"].Columns.Contains(displayColumnName))
        //                    dtParamValues = ParameterValues.Tables["ParameterValues"].DefaultView.ToTable(true, columnName, displayColumnName);
        //                else
        //                {
        //                    dtParamValues = ParameterValues.Tables["ParameterValues"].DefaultView.ToTable(true, columnName);
        //                    displayColumnName = columnName;
        //                }
        //                foreach (DataRow dr in dtParamValues.Rows)
        //                {
        //                    filterValueList.Add(new ParameterFilterValue { Values = dr[columnName].ToString(), DisplayMember = dr[displayColumnName].ToString() });
        //                }
        //            }

        //            HttpContext.Current.Session["ReportViewer_FilterValueList"] = filterValueList;
        //        }

        //        HttpContext.Current.Response.Clear();
        //        HttpContext.Current.Response.ContentType = "text/plain";
        //        HttpContext.Current.Response.Write(response);
        //        HttpContext.Current.Response.Flush();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //private void SetSelectedParameterValueInParameterGrid()
        //{
        //    try
        //    {
        //        String vid = HttpContext.Current.Request.QueryString["vid"];
        //        String selectedVids = HttpContext.Current.Request.QueryString["SelectedVids"];
        //        String response = "TRUE";
        //        String selectedValues = String.Empty;
        //        if (vid.IsNotNullOrEmpty() && selectedVids.IsNotNullOrEmpty())
        //        {
        //            CustomList<FilterSets> filterSetList = (CustomList<FilterSets>)HttpContext.Current.Session["ReportViewer_FilterSetList"];
        //            CustomList<ParameterFilterValue> FilterValueList = (CustomList<ParameterFilterValue>)HttpContext.Current.Session["ReportViewer_FilterValueList"];

        //            FilterSets filterItem = filterSetList.Find(item => item.VID == vid.ToInt());
        //            if (filterItem.IsNotNull())
        //            {
        //                String[] vidList = selectedVids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //                CustomList<ParameterFilterValue> searchList = FilterValueList.FindAll(p => vidList.Contains(p.VID.ToString()));
        //                if (searchList.Count > 1)
        //                {
        //                    foreach (ParameterFilterValue param in searchList)
        //                    {
        //                        selectedValues += String.Format("{0},", param.Values);
        //                    }
        //                    filterItem.Operators = "In";
        //                    if (selectedValues.IsNotNullOrEmpty())
        //                        selectedValues = selectedValues.Substring(0, selectedValues.Length - 1);
        //                }
        //                else
        //                {
        //                    foreach (ParameterFilterValue param in searchList)
        //                    {
        //                        selectedValues = param.Values;
        //                    }
        //                }
        //                filterItem.ColumnValue = selectedValues;
        //            }
        //        }

        //        HttpContext.Current.Response.Clear();
        //        HttpContext.Current.Response.ContentType = "text/plain";
        //        HttpContext.Current.Response.Write(response);
        //        HttpContext.Current.Response.Flush();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        private void getRowCount()
        {
            try
            {
                int retVal = 0;
                String sessionname = HttpContext.Current.Request.QueryString["sessionName"];
                IEnumerable ien = (IEnumerable)HttpContext.Current.Session[sessionname];

                if (ien == null)
                {
                    retVal = 0;
                }
                else
                {
                    CustomList<BaseItem> obj = ien.ToCustomList<BaseItem>();
                    retVal = obj.Count;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(retVal + 1);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void getRowCountFromDatabase()
        {
            try
            {
                OTSlabManager manager = new OTSlabManager();
                Int32 rowCount = manager.RowCount();

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(rowCount + 1);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void DuplicateSlabTypeCheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String slabType = HttpContext.Current.Request.QueryString["SlabType"];
                String vid = HttpContext.Current.Request.QueryString["VID"];
                CustomList<OTSlab> SlabTypeList = (CustomList<OTSlab>)HttpContext.Current.Session["OTSlab_OTSlabList"];

                OTSlab slabTypeObj = SlabTypeList.Find(f => f.SlabType == slabType && f.VID != vid.ToInt());
                OTSlab chkAdded = SlabTypeList.Find(f => f.SlabType == slabType && f.VID != vid.ToInt() && f.IsAdded);
                if ((slabTypeObj.IsNotNull() && !slabTypeObj.IsDeleted) || (slabTypeObj.IsNotNull() && chkAdded.IsNotNull()))
                {
                    refSourceString = "True";
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ProManSys_Checked()
        {
            try
            {
                String refSourceString = String.Empty;
                CustomList<RuleDetails> SecurityRuleDetailList = new CustomList<RuleDetails>();
                CustomList<ASL.Security.DAO.Menu> MenuList = (CustomList<ASL.Security.DAO.Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                CustomList<TempRuleDetails> TempSecurityRuleDetailList = (CustomList<TempRuleDetails>)HttpContext.Current.Session["SecurityRule_TempSecurityRuleDetailList"];
                string hfApplicationID = (string)HttpContext.Current.Session["ApplicationID"];
                string PersonName = (string)HttpContext.Current.Session["PersonName"];
                string CompanyID = (string)HttpContext.Current.Session["CompanyID"];
                CustomList<ASL.Security.DAO.Menu> SelectedMenuList = MenuList.FindAll(f => f.IsModified);
                foreach (ASL.Security.DAO.Menu M in SelectedMenuList)
                {
                    if (M.CanInsert || M.CanSelect || M.CanUpdate || M.CanDelete)
                    {
                        RuleDetails objNewSRO = new RuleDetails();
                        objNewSRO.ApplicationID = M.ApplicationID;
                        objNewSRO.ObjectID = M.MenuID;
                        objNewSRO.ObjectType = "Menu";
                        objNewSRO.CanInsert = M.CanInsert;
                        objNewSRO.CanSelect = M.CanSelect;
                        objNewSRO.CanUpdate = M.CanUpdate;
                        objNewSRO.CanDelete = M.CanDelete;
                        SecurityRuleDetailList.Add(objNewSRO);
                    }
                }

                CustomList<Application> ApplicationList = (CustomList<Application>)HttpContext.Current.Session["SecurityRule_ApplicationList"];
                foreach (Application a in ApplicationList)
                {
                    CustomList<RuleDetails> upDate = SecurityRuleDetailList.FindAll(f => f.ApplicationID == a.ApplicationID);
                    CustomList<RuleDetails> newUpdate = new CustomList<RuleDetails>();
                    newUpdate = upDate.FindAll(f => f.CanInsert == true || f.CanSelect == true || f.CanUpdate == true || f.CanDelete == true);
                    if (newUpdate.Count != 0)
                        a.IsSaved = true;
                    else
                        a.IsSaved = false;
                }

                HttpContext.Current.Session["SecurityRule_MenuList"] = MenuList;
                HttpContext.Current.Session["SecurityRule_SecurityRuleDetailList"] = SecurityRuleDetailList;
                HttpContext.Current.Session["SecurityRule_TempSecurityRuleDetailList"] = TempSecurityRuleDetailList;
                HttpContext.Current.Session["SecurityRule_ApplicationList"] = ApplicationList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
