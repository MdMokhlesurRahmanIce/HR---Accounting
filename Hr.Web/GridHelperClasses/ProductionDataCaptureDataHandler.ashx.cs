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
    /// Summary description for ProductionDataCaptureDataHandler
    /// </summary>
    public class ProductionDataCaptureDataHandler : IHttpHandler, IRequiresSessionState
    {
        private String SessionVarName { get; set; }
        private ProductionDataCaptureCallBackMode callBackMode;
        private ProductionDataCaptureCallBackMode DataCallMode
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
                callBackMode = (ProductionDataCaptureCallBackMode)StaticInfo.GetEnumValue(typeof(ProductionDataCaptureCallBackMode), callMode);
                if (callMode.CompareTo("RateDynamicGrid").IsZero())
                {
                    callBackMode = ProductionDataCaptureCallBackMode.RateDynamicGrid;
                }
                //if (callMode.CompareTo("DataCaptureDynamicGrid").IsZero())
                //{
                //    callBackMode = ProductionDataCaptureCallBackMode.DataCaptureDynamicGrid;
                //}
                if (callMode.CompareTo("AddToGrid").IsZero())
                {
                    callBackMode = ProductionDataCaptureCallBackMode.AddToGrid;
                }
                if (callMode.CompareTo("TodayEntryList").IsZero())
                {
                    callBackMode = ProductionDataCaptureCallBackMode.TodayEntryList;
                }
                if (callMode.CompareTo("UpdateDataCaptureGrid").IsZero())
                {
                    callBackMode = ProductionDataCaptureCallBackMode.UpdateDataCaptureGrid;
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
                    case ProductionDataCaptureCallBackMode.RateDynamicGrid:
                        RateDynamicGrid();
                        return;
                    //case ProductionDataCaptureCallBackMode.DataCaptureDynamicGrid:
                    //    DataCaptureDynamicGrid();
                    //    return;
                    case ProductionDataCaptureCallBackMode.AddToGrid:
                        AddToGrid();
                        return;
                    case ProductionDataCaptureCallBackMode.TodayEntryList:
                        TodayEntryList();
                        return;
                    case ProductionDataCaptureCallBackMode.UpdateDataCaptureGrid:
                        UpdateDataCaptureGrid();
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
        private void UpdateDataCaptureGrid()
        {
            try
            {
                String refSourceString = String.Empty;
                DataCaptureManager manager = new DataCaptureManager();
                String vid = HttpContext.Current.Request.QueryString["VID"];
                CustomList<ProductionDataCapture> ProductionDataCaptureList = (CustomList<ProductionDataCapture>)HttpContext.Current.Session["DataCapture_DataCaptureDynamicGridList"];
                ProductionDataCapture item = ProductionDataCaptureList.Find(f=>f.VID==vid.ToInt());
                refSourceString =item.EmpCode+";"+item.DataCaptureRateRuleID+";"+item.Qty.ToString()+";"+item.Rate.ToString()+";"+item.ProcessDate.ToShortDateString();

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
        private void TodayEntryList()
        {
            try
            {
                String refSourceString = String.Empty;
                DataCaptureManager manager = new DataCaptureManager();
                String dateText = HttpContext.Current.Request.QueryString["DateText"];
                CustomList<ProductionDataCapture> ProductionDataCaptureList = manager.GetAllProductionDataCapture(dateText);
                CustomList<HRM_Emp> Emplist = manager.GetAllHRM_Emp();
                foreach (ProductionDataCapture pDC in ProductionDataCaptureList)
                {
                    HRM_Emp item = Emplist.Find(f => f.EmpKey == pDC.EmpKey);
                    pDC.EmpCode = item.EmpCode;
                    pDC.EmpName = item.EmpName;
                    pDC.Value = pDC.Qty * pDC.Rate;
                }
                HttpContext.Current.Session["DataCapture_DataCaptureDynamicGridList"] = ProductionDataCaptureList;

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
        private void AddToGrid()
        {
            try
            {
                String refSourceString = String.Empty;
                DataCaptureManager manager = new DataCaptureManager();
                String empCode = HttpContext.Current.Request.QueryString["EmpCode"];
                String qty = HttpContext.Current.Request.QueryString["Qty"];
                String rateID = HttpContext.Current.Request.QueryString["RateID"];
                String rate = HttpContext.Current.Request.QueryString["Rate"];
                String captureDate = HttpContext.Current.Request.QueryString["CaptureDate"];
                CustomList<ProductionDataCapture> ProductionDataCaptureList = (CustomList<ProductionDataCapture>)HttpContext.Current.Session["DataCapture_DataCaptureDynamicGridList"];
                CustomList<ProductionDataCapture> EmpListList = manager.GetAllProductionDataCaptureEmp(empCode);
                ProductionDataCapture item = ProductionDataCaptureList.Find(f => f.EmpCode == empCode);
                if (item.IsNull())
                {
                    ProductionDataCapture newObj = new ProductionDataCapture();
                    newObj.EmpCode = empCode;
                    if (EmpListList.Count != 0)
                    {
                        newObj.EmpKey = EmpListList[0].EmpKey;
                        newObj.EmpName = EmpListList[0].EmpName;
                    }
                    newObj.DataCaptureRateRuleID = rateID;
                    newObj.Qty = qty.ToInt();
                    newObj.Rate = rate.ToDecimal();
                    newObj.Value = newObj.Qty * newObj.Rate;
                    newObj.ProcessDate = captureDate.ToDateTime();
                    ProductionDataCaptureList.Add(newObj);
                }
                else
                {
                    item.DataCaptureRateRuleID = rateID;
                    item.Qty = qty.ToInt();
                    item.Rate = rate.ToDecimal();
                    item.Value = item.Qty * item.Rate;
                    item.ProcessDate = captureDate.ToDateTime();
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
        //private void DataCaptureDynamicGrid()
        //{
        //    String ColumnName = "";
        //    try
        //    {
        //        DataCaptureManager manager = new DataCaptureManager();
        //        CustomList<DataCaptureConfiguration> FieldList = manager.GetAllDataCaptureConfigurationForDataCapture();

        //        String columnsCaption = "VID";

        //        String colModel = " " +
        //                        " { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' } @" +
        //                        " { 'name': 'EmpKey', 'index': 'EmpKey','hidden': false, editable: true, width: 70} @" +
        //                        " { 'name': 'EmpName', 'index': 'EmpName','hidden': false, editable: false, width: 100} @" +
        //                        " { 'name': 'Department', 'index': 'Department','hidden': false, editable: false, width: 100} ";


        //        //if (FieldList.IsNotNull())
        //        //{
        //        //    int headCount = 1;
        //        //    foreach (DataCaptureConfiguration list in FieldList)
        //        //    {
        //        //        if (headCount == 1)
        //        //            HttpContext.Current.Session["Rate_HouseKeepingValueList1"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
        //        //        if (headCount == 2)
        //        //            HttpContext.Current.Session["Rate_HouseKeepingValueList2"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
        //        //        if (headCount == 3)
        //        //            HttpContext.Current.Session["Rate_HouseKeepingValueList3"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
        //        //        if (headCount == 4)
        //        //            HttpContext.Current.Session["Rate_HouseKeepingValueList4"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
        //        //        if (headCount == 5)
        //        //            HttpContext.Current.Session["Rate_HouseKeepingValueList5"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
        //        //        columnsCaption += "," + list.Field;
        //        //        colModel += "@ { 'name': 'Key" + headCount + "', 'index': 'Key" + headCount + "','hidden': false, editable: true, width: 70, editrules: { required: true }, edittype: 'select', formatter: 'select', editoptions: {style:'width:100%', value: GetDropDownSource('SessionVarName=Rate_HouseKeepingValueList" + headCount + "&NeedBlank=true&DataTextField=HKName&DataValueField=HKID')}} ";
        //        //        headCount++;
        //        //    }
        //        //}
        //        columnsCaption += ",EmpCode,EmpName,Department";
        //        //colModel += "@ { 'name': 'Rate', 'index': 'Rate','hidden': false, editable: true, width: 50, editrules: { required: true,number: true}} ";
        //        ColumnName = columnsCaption + "|" + colModel;


        //        HttpContext.Current.Response.Clear();
        //        HttpContext.Current.Response.ContentType = "text/plain";
        //        HttpContext.Current.Response.Write(ColumnName);
        //        HttpContext.Current.Response.Flush();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void RateDynamicGrid()
        {
            String ColumnName = "";
            try
            {
                RateManager manager = new RateManager();
                CustomList<DataCaptureConfiguration> FieldList = manager.GetAllDataCaptureConfigurationForRate();

                String columnsCaption = "VID";

                String colModel = " " +
                                " { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' }";


                if (FieldList.IsNotNull())
                {
                    int headCount = 1;
                    foreach (DataCaptureConfiguration list in FieldList)
                    {
                        if (headCount == 1)
                            HttpContext.Current.Session["Rate_HouseKeepingValueList1"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
                        if (headCount == 2)
                            HttpContext.Current.Session["Rate_HouseKeepingValueList2"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
                        if (headCount == 3)
                            HttpContext.Current.Session["Rate_HouseKeepingValueList3"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
                        if (headCount == 4)
                            HttpContext.Current.Session["Rate_HouseKeepingValueList4"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
                        if (headCount == 5)
                            HttpContext.Current.Session["Rate_HouseKeepingValueList5"] = manager.GetAllHouseKeepingValueForDropdown(list.Field);
                        columnsCaption += "," + list.Field;
                        colModel += "@ { 'name': 'Key" + headCount + "', 'index': 'Key" + headCount + "','hidden': false, editable: true, width: 70, editrules: { required: true }, edittype: 'select', formatter: 'select', editoptions: {style:'width:100%', value: GetDropDownSource('SessionVarName=Rate_HouseKeepingValueList" + headCount + "&NeedBlank=true&DataTextField=HKName&DataValueField=HKID')}} ";
                        headCount++;
                    }
                }
                columnsCaption += ",Rate";
                colModel += "@ { 'name': 'Rate', 'index': 'Rate','hidden': false, editable: true, width: 50, editrules: { required: true,number: true}} ";
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}