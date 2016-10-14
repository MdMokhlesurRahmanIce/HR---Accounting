using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;
using Hr.Web.Controls;
using System.Collections;
using System.IO;
using System.Configuration;
using ASL.Web.Framework.IOHelper;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;


namespace Hr.Web.UI.Payroll
{
    public partial class UploadFromExcelForSalaryProcess : PageBase
    {
        AttendImportManager _manager = new AttendImportManager();
        AttendanceManager _AttManager = new AttendanceManager();
        private List<string> _excludeList;
        #region Session Variable
        private CustomList<ATT_IO> AttValidDataList
        {
            get
            {
                if (Session["AttendImport_AttValidDataList"] == null)
                    return new CustomList<ATT_IO>();
                else
                    return (CustomList<ATT_IO>)Session["AttendImport_AttValidDataList"];
            }
            set
            {
                Session["AttendImport_AttValidDataList"] = value;
            }
        }
        private CustomList<ATT_IO> AttRejectedList
        {
            get
            {
                if (Session["AttendImport_AttRejectedList"] == null)
                    return new CustomList<ATT_IO>();
                else
                    return (CustomList<ATT_IO>)Session["AttendImport_AttRejectedList"];
            }
            set
            {
                Session["AttendImport_AttRejectedList"] = value;
            }
        }
        #endregion
        public UploadFromExcelForSalaryProcess()
        {
            _excludeList = new List<string>();
            _excludeList.Add("0");
            _excludeList.Add("1");
            _excludeList.Add("2");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                AttValidDataList = new CustomList<ATT_IO>();
                AttRejectedList = new CustomList<ATT_IO>();
              
            }
        }
        #region All Methods
      

        private void PopulateCombo()
        {
            #region Device
            try
            {



            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = "Import failed:" + ex.Message;
            }
            #endregion
        }
        #endregion
        protected void btnImport_Click(object sender, EventArgs e)
        {

           
        }

        private void processList(List<ATT_IO_Temp> items)
        {
            try
            {
                CustomList<ATT_IO> daoList = new CustomList<ATT_IO>();
                CustomList<ATT_IO> rejectList = new CustomList<ATT_IO>();
                EmployeeManager empManager = new EmployeeManager();
                CustomList<HRM_Emp> allEmp = empManager.GetEmpGeneralInfo();
                foreach (HRM_Emp e in allEmp)
                {
                    var q = items.FindAll(f => f.PunchCardNo == e.PunchCard).OrderBy(x => x.PTime).ToList();
                    string pTime = "";
                    double differenceTime = 0;
                    foreach (var vItem in q)
                    {
                        if (pTime == "")
                        {
                            pTime = vItem.PTime;
                        }
                        else
                        {
                            TimeSpan punch1 = new TimeSpan(int.Parse(pTime.Substring(0, 2)), int.Parse(pTime.Substring(3, 2)), int.Parse(pTime.Substring(6, 2)));//pTime.ToDateTime();
                            TimeSpan punch2 = new TimeSpan(int.Parse(vItem.PTime.Substring(0, 2)), int.Parse(vItem.PTime.Substring(3, 2)), int.Parse(vItem.PTime.Substring(6, 2)));
                            differenceTime = (punch2.TotalSeconds - punch1.TotalSeconds);
                            pTime = vItem.PTime;
                        }

                        ATT_IO item = new ATT_IO();

                        item.EmpCode = e.EmpCode;
                        item.WorkDate = vItem.WorkDate;
                        item.PTime = vItem.PTime;
                        item.PunchCardNo = vItem.PunchCardNo;
                        item.DeviceID = vItem.DeviceID;
                        item.AddedBy = CurrentUserSession.UserName;
                        item.DateAdded = DateTime.Now;

                      
                    }
                }
                AttValidDataList = daoList;
                AttRejectedList = rejectList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void processList(List<DiviceData> items)
        {
            try
            {
                CustomList<ATT_IO> daoList = new CustomList<ATT_IO>();
                CustomList<ATT_IO> rejectList = new CustomList<ATT_IO>();
                EmployeeManager empManager = new EmployeeManager();
                CustomList<HRM_Emp> allEmp = empManager.GetEmpGeneralInfo();
                foreach (HRM_Emp e in allEmp)
                {
                    var q = items.FindAll(f => f.CardNum == e.PunchCardNo).OrderBy(x => x.CTime).ToList();
                    string pTime = "";
                    double differenceTime = 0;
                    foreach (var vItem in q)
                    {
                        if (pTime == "")
                        {
                            pTime = vItem.CTime;
                        }
                        else
                        {
                            TimeSpan punch1 = new TimeSpan(int.Parse(pTime.Substring(0, 2)), int.Parse(pTime.Substring(2, 2)), int.Parse(pTime.Substring(4, 2)));
                            TimeSpan punch2 = new TimeSpan(int.Parse(vItem.CTime.Substring(0, 2)), int.Parse(vItem.CTime.Substring(2, 2)), int.Parse(vItem.CTime.Substring(4, 2)));
                            differenceTime = (punch2.TotalSeconds - punch1.TotalSeconds);
                            pTime = vItem.CTime;
                        }

                        ATT_IO item = new ATT_IO();
                        item.EmpCode = e.EmpCode;
                        item.WorkDate = DateTime.ParseExact(vItem.CDate.Substring(0, 4) + "-" + vItem.CDate.Substring(4, 2) + "-" + vItem.CDate.Substring(6, 2), "yyyy-MM-dd", null);
                        item.PunchCardNo = vItem.CardNum;
                        item.PunchType = "";
                        item.PTime = new TimeSpan(int.Parse(vItem.CTime.Substring(0, 2)), int.Parse(vItem.CTime.Substring(2, 2)), int.Parse(vItem.CTime.Substring(4, 2))).ToString();
                        item.AddedBy = CurrentUserSession.UserName;
                        item.DateAdded = DateTime.Now;

                       
                    }
                }
                AttValidDataList = daoList;
                AttRejectedList = rejectList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void processList(CustomList<DiviceData> items)
        {
            try
            {
                CustomList<ATT_IO> daoList = new CustomList<ATT_IO>();
                CustomList<ATT_IO> rejectList = new CustomList<ATT_IO>();
                EmployeeManager empManager = new EmployeeManager();
                CustomList<HRM_Emp> allEmp = empManager.GetEmpGeneralInfo();
                foreach (HRM_Emp e in allEmp)
                {
                    var q = items.FindAll(f => f.CardNum.Trim() == e.PunchCard).OrderBy(x => x.nDateTime).ToList();
                    Int32 pTime = 0;
                    double differenceTime = 0;
                    foreach (var vItem in q)
                    {
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        DateTime d = origin.AddSeconds(vItem.nDateTime);
                        string date = d.ToShortDateString();
                        string time = d.ToShortTimeString();
                        if (pTime == 0)
                        {
                            pTime = vItem.nDateTime;
                        }
                        else
                        {
                            differenceTime = (vItem.nDateTime - pTime);
                            pTime = vItem.nDateTime;
                        }

                        ATT_IO item = new ATT_IO();
                        item.EmpCode = e.EmpCode;
                        item.WorkDate = date.ToDateTime();
                        item.PunchCardNo = vItem.CardNum;
                        item.PunchType = "";
                        item.PTime = time.ToString();
                        item.AddedBy = CurrentUserSession.UserName;
                        item.DateAdded = DateTime.Now;

                    }
                }
                AttValidDataList = daoList;
                AttRejectedList = rejectList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ATT_IO_Temp> processFileData(string fileContent, string fullFileName)
        {
            List<ATT_IO_Temp> items = new List<ATT_IO_Temp>();

            if (fileContent.IsNotNullOrEmpty())
            {
                DateTime attDate = DateTime.Now;

                string[] str = fileContent.Replace("\n", ",").Split(',');

                int atoms = str.Count();
                int counter = 0;
                foreach (string s in str)
                {
                    if (counter < str.Length - 1)
                    {
                        ATT_IO_Temp newObj = new ATT_IO_Temp();
                        string[] item = s.Split(':');

                        newObj.DeviceID = item[0];
                        newObj.PunchCardNo = item[1];
                        newObj.WorkDate = DateTime.ParseExact(item[2].Substring(0, 4) + "-" + item[2].Substring(4, 2) + "-" + item[2].Substring(6, 2), "yyyy-MM-dd", null);
                        newObj.PTime = new TimeSpan(int.Parse(item[3].Substring(0, 2)), int.Parse(item[3].Substring(2, 2)), int.Parse(item[3].Substring(4, 2))).ToString();
                        items.Add(newObj);
                        counter++;
                    }
                }
            }
            else throw new Exception("Empty file");

            return items;
        }
        private List<ATT_IO_Temp> processFileDataSemicolonSeparated(string fileContent, string fullFileName)
        {
            List<ATT_IO_Temp> items = new List<ATT_IO_Temp>();

            if (fileContent.IsNotNullOrEmpty())
            {
                DateTime attDate = DateTime.Now;
                string[] str = fileContent.Replace("\n", ",").Split(',');
                int atoms = str.Count();
                int counter = 0;
                foreach (string s in str)
                {
                   
                }
            }
            else throw new Exception("Empty file");
            return items;
        }
        private List<DiviceData> processFileData(OleDbConnection ConnStr)
        {
            OleDbConnection conn = null;
            List<DiviceData> items = new List<DiviceData>();
            try
            {
               

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return items;

        }

        private bool isInExcludeList(string machineNo)
        {
            if (_excludeList.Contains(machineNo)) return true;
            return false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AttendanceManager manager = new AttendanceManager();
                CustomList<ATT_IO> ValidDeviceDataList = (CustomList<ATT_IO>)HttpContext.Current.Session["AttendImport_AttValidDataList"];
                manager.SaveAtt_IO(ref ValidDeviceDataList);
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
            }
            catch (SqlException ex)
            {
                this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
           
        }


        //protected void ddlFileExtension_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (!Atten_Device.GetIsFileUpload(ddlFileExtension.SelectedValue.ToInt()))
        //        btnBrowse.Visible = false;
        //    else
        //        btnBrowse.Visible = true;
        //}
    }
}