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

namespace Hr.Web.GridHelperClasses
{
    /// <summary>
    /// Summary description for LV_DataHandler
    /// </summary>
    public class LV_DataHandler : IHttpHandler, IRequiresSessionState
    {
        private String SessionVarName { get; set; }
        private LVDataCallBackMode callBackMode;
        private LVDataCallBackMode DataCallMode
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
                callBackMode = (LVDataCallBackMode)StaticInfo.GetEnumValue(typeof(LVDataCallBackMode), callMode);
                if (callMode.CompareTo("LeaveTrans_CheckSelectedGridRow").IsZero())
                {
                    callBackMode = LVDataCallBackMode.LeaveTrans_CheckSelectedGridRow;
                }
                //if (callMode.CompareTo("AddNewEmploymentHistory").IsZero())
                //{
                //    callBackMode = LVDataCallBackMode.AddNewEmploymentHistory;
                //}
                //if (callMode.CompareTo("ShowAllEmpForLV").IsZero())
                //{
                //    callBackMode = LVDataCallBackMode.ShowAllEmpForLV;
                //}
                if (callMode.CompareTo("LV_SetHour").IsZero())
                {
                    callBackMode = LVDataCallBackMode.LV_SetHour;
                }
                //if (callMode.CompareTo("LV_DaysTransList").IsZero())
                //{
                //    callBackMode = LVDataCallBackMode.LV_DaysTransList;
                //}
                //if (callMode.CompareTo("LV_HourlyTransList").IsZero())
                //{
                //    callBackMode = LVDataCallBackMode.LV_HourlyTransList;
                //}
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
                    case LVDataCallBackMode.LeaveTrans_CheckSelectedGridRow:
                        LeaveTrans_CheckSelectedGridRow();
                        return;
                    //case LVDataCallBackMode.AddNewEmploymentHistory:
                    //    AddNewEmploymentHistory();
                    //    return;
                    case LVDataCallBackMode.LV_SetHour:
                        LV_SetHour();
                        return;
                    //case LVDataCallBackMode.LV_DaysTransList:
                    //    LV_DaysTransList();
                    //    return;
                    //case LVDataCallBackMode.LV_HourlyTransList:
                    //    LV_HourlyTransList();
                    //    return;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private void AddNewEmploymentHistory()
        //{
        //    try
        //    {
        //        String response = String.Empty;

        //        CustomList<EmployeeEmploymentHistory> EmployeeEmploymentHistoryList = (CustomList<EmployeeEmploymentHistory>)HttpContext.Current.Session["EmployeeBasicInfo_EmploymentHistoryList"];
        //        EmployeeEmploymentHistory newEmploymentHistory = new EmployeeEmploymentHistory();
        //        EmployeeEmploymentHistoryList.Add(newEmploymentHistory);
        //        HttpContext.Current.Session["EmployeeBasicInfo_EmploymentHistoryList"] = EmployeeEmploymentHistoryList;

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
        private void LeaveTrans_CheckSelectedGridRow()
        {
            try
            {
                //  + '&LeaveFrom=' + + '&LeaveTo=' + + '&LeaveDays=' + + '&LeaveReason=' + + '&LeaveAvailPlace=' +  + '&=' + ContactNo,

                String response = "";
                String LeaveType = HttpContext.Current.Request.QueryString["LeaveType"];
                String LeaveFrom = HttpContext.Current.Request.QueryString["LeaveFrom"];
                String LeaveTo = HttpContext.Current.Request.QueryString["LeaveTo"];
                String LeaveDays = HttpContext.Current.Request.QueryString["LeaveDays"];
                String LeaveReason = HttpContext.Current.Request.QueryString["LeaveReason"];
                String LeaveAvailPlace = HttpContext.Current.Request.QueryString["LeaveAvailPlace"];
                String ContactNo = HttpContext.Current.Request.QueryString["ContactNo"];

                LeaveTransApproved LeaveTrans = HttpContext.Current.Session["SelectedGridRow"] as LeaveTransApproved;
                if (LeaveTrans.IsNotNull())
                {
                    if (LeaveTrans.TransID.ToString() == "")
                        LeaveType = "";
                    if (//LeaveTrans.TransID.ToString() == LeaveTransCode && 
                        LeaveTrans.LeaveType == LeaveType &&
                        LeaveTrans.FromDate.ToShortDateString() == LeaveFrom && LeaveTrans.ToDate.ToShortDateString() == LeaveTo &&
                        LeaveTrans.LeaveDays == LeaveDays.ToDecimal() && LeaveTrans.LeaveReason == LeaveReason)
                        response = "TRUE";
                    else
                        response = "FALSE";
                }
                else
                    response = "TRUE";

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
        //private void LV_HourlyTransList()
        //{
        //    try
        //    {
        //        String refSourceString = String.Empty;
        //        String region = HttpContext.Current.Request.QueryString["Region"];
        //        String remarks = HttpContext.Current.Request.QueryString["Remarks"];
        //        String availingAddress = HttpContext.Current.Request.QueryString["AvailingAddress"];
        //        String emergencyContact = HttpContext.Current.Request.QueryString["EmergencyContact"];
        //        String leaveType = HttpContext.Current.Request.QueryString["LeaveType"];
        //        String workDate = HttpContext.Current.Request.QueryString["WorkDate"];
        //        String from = HttpContext.Current.Request.QueryString["From"];
        //        String to = HttpContext.Current.Request.QueryString["To"];
        //        String leaveHours = HttpContext.Current.Request.QueryString["LeaveHours"];
        //        CustomList<HRM_Emp> empList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
        //        CustomList<HRM_Emp> checkedEmpList = empList.FindAll(f => f.IsChecked);
        //        CustomList<LeaveTransApproved> HLTList = new CustomList<LeaveTransApproved>();
        //        foreach (HRM_Emp e in checkedEmpList)
        //        {
        //            LeaveTransApproved obj = new LeaveTransApproved();
        //            obj.EmpKey = e.EmpKey;
        //            obj.EmpCode = e.EmpCode;
        //            obj.EmpName = e.EmpName;
        //            obj.LeaveReason = region;
        //            obj.LeaveAvailPlace = availingAddress;
        //            obj.LeavePolicyID = leaveType;
        //            obj.LeaveDate = workDate.ToDateTime(StaticInfo.GridDateFormat);
        //            obj.LeaveFrom = from;
        //            obj.LeaveTo = to;
        //            string[] items = leaveHours.Split(':');
        //            obj.TotalHour = (items[0] + "." + items[1]).ToDecimal();
        //            HLTList.Add(obj);
        //        }
        //        HttpContext.Current.Session["LeaveTransaction_DayLVTransList"] = HLTList;

        //        HttpContext.Current.Response.Clear();
        //        HttpContext.Current.Response.ContentType = "text/plain";
        //        HttpContext.Current.Response.Write(refSourceString);
        //        HttpContext.Current.Response.Flush();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //private void LV_DaysTransList()
        //{
        //    try
        //    {
        //        String refSourceString = String.Empty;
        //        String region = HttpContext.Current.Request.QueryString["Region"];
        //        String remarks = HttpContext.Current.Request.QueryString["Remarks"];
        //        String availingAddress = HttpContext.Current.Request.QueryString["AvailingAddress"];
        //        String emergencyContact = HttpContext.Current.Request.QueryString["EmergencyContact"];
        //        String leaveType = HttpContext.Current.Request.QueryString["LeaveType"];
        //        String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
        //        String toDate = HttpContext.Current.Request.QueryString["ToDate"];
        //        String leaveDays = HttpContext.Current.Request.QueryString["LeaveDays"];

        //        CustomList<HRM_Emp> empList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
        //        CustomList<HRM_Emp> checkedEmpList = empList.FindAll(f => f.IsChecked);
        //        CustomList<LeaveTransApproved> LTAList = new CustomList<LeaveTransApproved>();
        //        foreach (HRM_Emp e in checkedEmpList)
        //        {
        //            LeaveTransApproved obj = new LeaveTransApproved();
        //            obj.EmpKey = e.EmpKey;
        //            obj.EmpCode = e.EmpCode;
        //            obj.EmpName = e.EmpName;
        //            obj.ShiftID = e.ShiftID;
        //            obj.Shift = e.Shift;
        //            obj.LeaveReason = region;
        //            obj.LeaveAvailPlace = availingAddress;
        //            obj.LeavePolicyID = leaveType;
        //            obj.FromDate = fromDate.ToDateTime();
        //            obj.ToDate = toDate.ToDateTime();
        //            obj.LeaveDays = leaveDays.ToInt();
        //            LTAList.Add(obj);
        //        }
        //        HttpContext.Current.Session["LeaveTransaction_DayLVTransList"] = LTAList;

        //        HttpContext.Current.Response.Clear();
        //        HttpContext.Current.Response.ContentType = "text/plain";
        //        HttpContext.Current.Response.Write(refSourceString);
        //        HttpContext.Current.Response.Flush();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        private void LV_SetHour()
        {
            try
            {
                String refSourceString = String.Empty;
                String dateText = HttpContext.Current.Request.QueryString["DateText"];
                String to = HttpContext.Current.Request.QueryString["To"];
                if (to.ToDateTime() > dateText.ToDateTime())
                {
                    TimeSpan ts = to.ToDateTime() - dateText.ToDateTime();
                    int hour = ts.Hours;
                    int minutes = ts.Minutes;

                    refSourceString = hour.ToString() + "." + minutes.ToString();
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
        //private void ShowAllEmpForLV()
        //{
        //    try
        //    {
        //        String refSourceString = String.Empty;
        //        String spName = HttpContext.Current.Request.QueryString["SpName"];
        //        EmpSearchManager manager = new EmpSearchManager();

        //        CustomList<HRM_Emp> EmpList = manager.GetAllViewEmp(spName);
        //        HttpContext.Current.Session["View_LVEmpList"] = EmpList;

        //        HttpContext.Current.Response.Clear();
        //        HttpContext.Current.Response.ContentType = "text/plain";
        //        HttpContext.Current.Response.Write(refSourceString);
        //        HttpContext.Current.Response.Flush();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}