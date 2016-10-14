using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ASL.DATA;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.Web.Framework;


namespace Hr.Web.UI.LeaveManagement
{
    public partial class UploadLeaveInfo : PageBase
    {
   static DataTable dtExcelRecords = new DataTable();

     
       
       
        private void InitializeSession()
        {
            if (!IsPostBack)
            {
            
            }
           // SearchList = ManagerEmployeeSearch.GetAllEmployeeSearch();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
           InitializeSession();
           
        }
        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string FileName = GridView1.Caption;

            string Extension = Path.GetExtension(FileName);

            string FilePath = Server.MapPath(FolderPath + FileName);



            //Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
            // Import_To_Grid(FilePath, Extension, pp.SelectedItem.Text);

            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();

        }
        
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            CustomList<LeaveTransApproved> LT = new CustomList<LeaveTransApproved>();
            LeaveTransApproved LTA = new LeaveTransApproved();
            LeavePolicyManager LPM = new LeavePolicyManager();
            EmployeeManager EmpManager = new EmployeeManager();
            string connectionString = "";
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string fileLocation = Server.MapPath("~/App_Data/" + fileName);
                FileUpload1.SaveAs(fileLocation);

                //Check whether file extension is xls or xslx

                /* for multi format data
                 connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + @";Extended Properties=" + Convert.ToChar(34).ToString() + @"Excel 8.0;Imex=1;HDR=Yes;" + Convert.ToChar(34).ToString();
                 */

                if (fileExtension == ".xls")
                {
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (fileExtension == ".xlsx")
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }

                //Create OleDB Connection and OleDb Command

                OleDbConnection con = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);

                DataTable tempEmcelRecords = new DataTable();
                con.Open();
                DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                dAdapter.SelectCommand = cmd;
                dAdapter.Fill(dtExcelRecords);
                con.Close();
                
                
                DataTable dt = new DataTable();
                
                
             //   PropertyDescriptorCollection lstPropertie = TypeDescriptor.GetProperties(EmpClass);
                          
                foreach (DataColumn columns in dtExcelRecords.Columns)
                {
                    if (columns.ToString().ToUpper() == "EmployeeCode".ToUpper() ||
                        columns.ToString().ToUpper() == "LeavePolicyId".ToUpper() ||
                        columns.ToString().ToUpper() == "LeaveType" ||
                        columns.ToString().ToUpper() == "FromDate".ToUpper() ||
                        columns.ToString().ToUpper() == "ToDate".ToUpper() ||
                        columns.ToString().ToUpper() == "LeaveDays".ToUpper() ||
                        columns.ToString().ToUpper() == "Reason".ToUpper() ||
                        columns.ToString().ToUpper() == "AppliedDate" ||
                        columns.ToString().ToUpper() == "ShiftId" ||
                        columns.ToString().ToUpper() == "LeaveAvailPlace" ||
                        columns.ToString().ToUpper() == "Contact" )
                    {




                    }
                    else tempEmcelRecords.Columns.Add(columns.ToString());
                        //dtExcelRecords.Columns.Remove(columns.ToString());
                    
                }

                foreach (DataColumn c in tempEmcelRecords.Columns)
                {
                    dtExcelRecords.Columns.Remove(c.ToString());

                }
                CustomList<HRM_Emp> EmpList = new CustomList<HRM_Emp>();
                CustomList<LeavePolicyMaster> LeavePolicy = new CustomList<LeavePolicyMaster>();
                LeavePolicy = LPM.GetAllLeavePolicyMaster();
                EmpList = EmpManager.GetActiveEmpCodeAndEmpKeyOnly();
                foreach (DataRow r in dtExcelRecords.Rows)
                {
                    if (r["EmployeeCode"].IsNull() || r["EmployeeCode"].ToString() == "" || r["FromDate"].IsNull() || r["ToDate"].IsNull())
                    {
                       
                    }
                    else
                    {
                        string s = r["EmployeeCode"].ToString();
                        LTA.EmpKey = EmpList.Find(f => f.EmpCode == "302929").EmpKey;
                        LTA.LeavePolicyID = LeavePolicy.Find(f => f.LeaveType == r["LeaveType"].ToString()).LeavePolicyID.ToString();
                        LTA.FromDate = r["FromDate"].ToString().ToDateTime();
                        LTA.ToDate = r["ToDate"].ToString().ToDateTime();
                        LTA.LeaveDays = r["LeaveDays"].ToString().ToInt();
                        LTA.LeaveReason = r["Reason"].ToString();
                        LTA.LeaveAvailPlace = r["Contac"].ToString();
                        LT.Add(LTA);
                    }

                }

                GridView1.DataSource = dtExcelRecords;
                GridView1.DataBind();

/*
                foreach (DataRow dr in dtExcelRecords.Rows)
                {
                    foreach (HR.DAO.Menu M in FieldMenuInfo)
                    {
                        if ((HKWM.Find(f => f.HKName.ToUpper() == dr[M.DisplayMember.ToString()].ToString().ToUpper() &&
                            f.MenuID == M.MenuID).IsNull()) && HKInfoForSave.Find(p => p.HKName.ToUpper()== dr[M.DisplayMember.ToString()].ToString().ToUpper()
                            && p.MenuID.ToInt() == M.MenuID).IsNull())
                        {
                            HKInfo H = new HKInfo();
                            H.HKName= dr[M.DisplayMember.ToString()].ToString();
                            H.MenuID= M.MenuID.ToString();
                            H.AddedBy = "Upload";
                            H.AddedDate = DateTime.Now;
                            HKInfoForSave.Add(H);

                        }

                    }
                }

                _HKEntry = HKInfoForSave;


                GridView1.DataSource = dtExcelRecords;
                GridView1.DataBind();*/
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridView1.EditIndex = -1;
            //GridView1.DataSource = items;
            //GridView1.DataBind();
         //   Message.ShowMessage("Hi It's Working");
            //Message.ShowMessageBox("Hi It's Working");
           // txtSearched.Text = GridView1.SelectedIndex.ToString();
            //txtSearched.Text = GridView1.Rows[GridView1.SelectedIndex];

        }

       
    }
    
}