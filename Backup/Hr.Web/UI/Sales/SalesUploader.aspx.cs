using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACC.BLL;
using ACC.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Hr.BLL;
using ASL.Web.Framework;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;
using System.Data;
using System.Data.OleDb;
using ASL.Hr.DAO;

namespace Hr.Web.UI.Sales
{
    public partial class SalesUploader : PageBase
    {
        SalesUploadController _manager = new SalesUploadController();
        VoucherManager manager = new VoucherManager();
        protected bool IsValidDataForUpload;
        #region Session
        private CustomList<SalesUploadFromExcel> DailySoWiseSalesList
        {
            get
            {
                if (Session["SalesUploader_DailySoWiseSalesList"] == null)
                    return new CustomList<SalesUploadFromExcel>();
                else
                    return (CustomList<SalesUploadFromExcel>)Session["SalesUploader_DailySoWiseSalesList"];
            }
            set
            {
                Session["SalesUploader_DailySoWiseSalesList"] = value;
            }
        }
        private CustomList<ErrorList> errorList
        {
            get
            {
                if (Session["SalesUploader_errorList"] == null)
                    return new CustomList<ErrorList>();
                else
                    return (CustomList<ErrorList>)Session["SalesUploader_errorList"];
            }
            set
            {
                Session["SalesUploader_errorList"] = value;
            }
        }
        #endregion
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSession();
                InisilizeCombo();
            }
        }
        #endregion
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            String savePath = this.Server.MapPath(@"~\Content\Uploads\");
            if (FileUpload1.HasFile)
            {
                savePath += FileUpload1.FileName;
                FileUpload1.SaveAs(savePath);
                TakeActionOnFile(savePath);
            }
        }
        private void InitializeSession()
        {
            DailySoWiseSalesList = new CustomList<SalesUploadFromExcel>();
            errorList = new CustomList<ErrorList>();
        }
        private void InisilizeCombo()
        {
            //Loading Company
            ddlCompany_nc.DataSource = manager.GetCompany();
            ddlCompany_nc.DataTextField = "HKName";
            ddlCompany_nc.DataValueField = "HKID";
            ddlCompany_nc.DataBind();
        }
        void TakeActionOnFile(string filePath)
        {
            //if (IsValidDataForUpload)
            //{
            var dt = _GetDataFromFile(filePath);
            DisplayFileData(dt);
            //UploadFileData(dt);
            //CopyDataToDatabase(dt);
            //  }
        }
        private void DisplayFileData(DataTable dt)
        {
            try
            {
                CustomList<Acc_VoucherDet> SOList = _manager.GetSOList();
                DailySoWiseSalesList = new CustomList<SalesUploadFromExcel>();
                CustomList<Hr_MasterSetup> CommissionAndVATList = Hr_MasterSetup.GetAllHr_MasterCommissionAndVATPercent();
                errorList = new CustomList<ErrorList>();
                foreach (DataRow d in dt.Rows)
                {
                    ErrorList errorObj = new ErrorList();
                    SalesUploadFromExcel newObj = new SalesUploadFromExcel();
                    string SOName = d["Sales Officer(SO)"].ToString();
                    if (SOName == "")
                        continue;
                    Acc_VoucherDet checkSO = SOList.Find(f => f.EmpName.Trim() == SOName.Trim());
                    if (checkSO.IsNotNull())
                    {
                        //if (d["Code"].ToString() != "")
                        //    newObj.Code = d["Code"].ToString();
                        if (d["Sales Officer(SO)"].ToString() != "")
                            newObj.SOName = d["Sales Officer(SO)"].ToString();
                        if (d["Section"].ToString() != "")
                            newObj.Section = d["Section"].ToString();
                        if (d["Gross Sales"].ToString() != "")
                            newObj.Gross = Convert.ToDecimal(d["Gross Sales"]);
                        if (d["Free Sales"].ToString() != "")
                            newObj.FreeSales = Convert.ToDecimal(d["Free Sales"]);
                        if (d["Commission"].ToString() != "")
                            newObj.Commission = Convert.ToDecimal(d["Commission"]);
                        if (d["Net Sales"].ToString() != "")
                            newObj.Cash = Convert.ToDecimal(d["Net Sales"]);
                        if (d["PD Commission"].ToString().IsNotNullOrEmpty())
                            newObj.PDC = Convert.ToDecimal(d["PD Commission"]);

                        //newObj.DistributorCom = Math.Round((newObj.Gross * Convert.ToDecimal(CommissionAndVATList[0].ItemValue) / 100), 2);//Convert.ToDecimal("3.82299") / 100;
                        decimal distributorCom = Math.Round((newObj.Gross * Convert.ToDecimal(CommissionAndVATList[0].ItemValue) / 100), 2);
                        newObj.DistributorCom = distributorCom;
                        newObj.VAT = Math.Round((newObj.Gross * Convert.ToDecimal(CommissionAndVATList[1].ItemValue) / 100), 2);// Convert.ToDecimal("0.60203") / 100;
                        newObj.Inventory = Math.Round((newObj.Gross * Convert.ToDecimal(CommissionAndVATList[2].ItemValue) / 100), 2);// Convert.ToDecimal("95.57496") / 100; ;
                        newObj.Cash = newObj.Cash - newObj.PDC;
                        DailySoWiseSalesList.Add(newObj);
                    }
                    else
                    {
                        errorObj.EmpName = SOName;
                        errorObj.Error = "Please Check Employee Name In database!";
                        errorList.Add(errorObj);
                    }
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private static DataTable _GetDataFromFile(string filePath)
        {
            DataTable dt = new DataTable();
            //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\""
            String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
            //String excelConnString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"", filePath);
            //Create Connection to Excel work book 
            using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
            {
                //Create OleDbCommand to fetch data from Excel 
                using (OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]", excelConnection))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        private void SetDataFromControlToObject(ref CustomList<Acc_Voucher> lstAccVoucher)
        {
            try
            {
                Acc_Voucher obj = lstAccVoucher[0];
                obj.VoucherTypeKey = 5;
                obj.VoucherDate = txtVoucherDate_nc.Text.ToDateTime(StaticInfo.GridDateFormatAcc);
                obj.OrgKey = Convert.ToInt64(ddlCompany_nc.SelectedValue);
                obj.VoucherDesc = txtVoucherDescription.Text;
                obj.EntryUserKey = CurrentUserSession.UserKey;
                obj.EntryDate = DateTime.Now;
                obj.DField_1 = null;
                obj.DField_2 = null;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<Acc_VoucherDet> empList = _manager.GetSOList();
                //CustomList<Acc_VoucherDet> SOList = _manager.GetSOList();
                CustomList<Acc_VoucherDet> VoucherList = new CustomList<Acc_VoucherDet>();
                if (errorList.Count != 0)
                {
                    this.ErrorMessage = "Please Upload Again!";
                    return;
                }
                errorList = new CustomList<ErrorList>();
                Int64 freeSales = Hr_MasterSetup.GetAllHr_MasterSetup("FreeSales");

                foreach (SalesUploadFromExcel vD in DailySoWiseSalesList)
                {
                    ErrorList objErrorList = new ErrorList();
                    try
                    {

                        Acc_VoucherDet obj = empList.Find(f => f.EmpName.Trim() == vD.SOName.Trim());
                        objErrorList.EmpName = vD.SOName;
                        long cOAKey = manager.GetExistingVoucher(txtVoucherDate_nc.Text.ToString(), Convert.ToInt64(freeSales), Convert.ToInt64(obj.UserKey));

                        CustomList<Acc_Voucher> lstAccVoucher = new CustomList<Acc_Voucher>();
                        if (lstAccVoucher.Count == 0)
                        {
                            Acc_Voucher newVoucher = new Acc_Voucher();
                            if (cOAKey != 0)
                                newVoucher.SetModified();
                            lstAccVoucher.Add(newVoucher);
                        }
                        SetDataFromControlToObject(ref lstAccVoucher);

                        Acc_VoucherDet createVoucher = new Acc_VoucherDet();
                        createVoucher.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("GrossSales");
                        createVoucher.UserKey = obj.UserKey;
                        createVoucher.Dr = vD.Gross;
                        createVoucher.EntryDate = DateTime.Now;
                        createVoucher.EntryUserKey = CurrentUserSession.UserKey;
                        createVoucher.Criteria = "Sales";
                        if (cOAKey != 0)
                            createVoucher.SetModified();
                        VoucherList.Add(createVoucher);

                        Acc_VoucherDet DistCommissionVoucher = new Acc_VoucherDet();
                        DistCommissionVoucher.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("Dist Commission");
                        DistCommissionVoucher.UserKey = obj.UserKey;
                        DistCommissionVoucher.Cr = vD.DistributorCom;
                        DistCommissionVoucher.EntryDate = DateTime.Now;
                        DistCommissionVoucher.EntryUserKey = CurrentUserSession.UserKey;
                        DistCommissionVoucher.Criteria = "Sales";
                        if (cOAKey != 0)
                            DistCommissionVoucher.SetModified();
                        VoucherList.Add(DistCommissionVoucher);

                        Acc_VoucherDet VATVoucher = new Acc_VoucherDet();
                        VATVoucher.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("VAT");
                        VATVoucher.UserKey = obj.UserKey;
                        VATVoucher.Cr = vD.VAT;
                        VATVoucher.EntryDate = DateTime.Now;
                        VATVoucher.EntryUserKey = CurrentUserSession.UserKey;
                        VATVoucher.Criteria = "Sales";
                        if (cOAKey != 0)
                            VATVoucher.SetModified();
                        VoucherList.Add(VATVoucher);

                        Acc_VoucherDet InventoryVoucher = new Acc_VoucherDet();
                        InventoryVoucher.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("Inventory");
                        InventoryVoucher.UserKey = obj.UserKey;
                        InventoryVoucher.Cr = vD.Inventory;
                        InventoryVoucher.EntryDate = DateTime.Now;
                        InventoryVoucher.EntryUserKey = CurrentUserSession.UserKey;
                        InventoryVoucher.Criteria = "Sales";
                        if (cOAKey != 0)
                            InventoryVoucher.SetModified();
                        VoucherList.Add(InventoryVoucher);

                        Acc_VoucherDet receivableToVoucher = new Acc_VoucherDet();
                        receivableToVoucher.COAKey = obj.COAKey;
                        receivableToVoucher.UserKey = obj.UserKey;
                        receivableToVoucher.Dr = vD.Cash;
                        receivableToVoucher.EntryDate = DateTime.Now;
                        receivableToVoucher.EntryUserKey = CurrentUserSession.UserKey;
                        receivableToVoucher.Criteria = "Sales";
                        if (cOAKey != 0)
                            receivableToVoucher.SetModified();
                        VoucherList.Add(receivableToVoucher);

                        Acc_VoucherDet FreeSalesVoucher = new Acc_VoucherDet();
                        FreeSalesVoucher.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("FreeSales");
                        FreeSalesVoucher.UserKey = obj.UserKey;
                        FreeSalesVoucher.Dr = vD.FreeSales;
                        FreeSalesVoucher.EntryDate = DateTime.Now;
                        FreeSalesVoucher.EntryUserKey = CurrentUserSession.UserKey;
                        FreeSalesVoucher.Criteria = "Sales";
                        if (cOAKey != 0)
                            FreeSalesVoucher.SetModified();
                        VoucherList.Add(FreeSalesVoucher);

                        Acc_VoucherDet CommissionVoucher = new Acc_VoucherDet();
                        CommissionVoucher.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("Commission");
                        CommissionVoucher.UserKey = obj.UserKey;
                        CommissionVoucher.Dr = vD.Commission;
                        CommissionVoucher.EntryDate = DateTime.Now;
                        CommissionVoucher.EntryUserKey = CurrentUserSession.UserKey;
                        CommissionVoucher.Criteria = "Sales";
                        if (cOAKey != 0)
                            CommissionVoucher.SetModified();
                        VoucherList.Add(CommissionVoucher);

                        //by shantonu
                        Acc_VoucherDet pdCommissionVoucher = new Acc_VoucherDet();
                        pdCommissionVoucher.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("PD Commission");
                        pdCommissionVoucher.UserKey = obj.UserKey;
                        pdCommissionVoucher.Cr = vD.PDC;
                        pdCommissionVoucher.EntryDate = DateTime.Now;
                        pdCommissionVoucher.EntryUserKey = CurrentUserSession.UserKey;
                        pdCommissionVoucher.Criteria = "Sales";
                        if (cOAKey != 0)
                            pdCommissionVoucher.SetModified();
                        VoucherList.Add(pdCommissionVoucher);

                        Acc_VoucherDet GrossVoucher = new Acc_VoucherDet();
                        GrossVoucher.COAKey = Hr_MasterSetup.GetAllHr_MasterSetup("GrossSales");
                        GrossVoucher.UserKey = obj.UserKey;
                        GrossVoucher.Cr = vD.Gross;
                        GrossVoucher.EntryDate = DateTime.Now;
                        GrossVoucher.EntryUserKey = CurrentUserSession.UserKey;
                        GrossVoucher.Criteria = "Sales";
                        if (cOAKey != 0)
                            GrossVoucher.SetModified();
                        VoucherList.Add(GrossVoucher);

                        string prifix = "JV";
                        manager.SavePFVoucher(ref lstAccVoucher, ref VoucherList, prifix);
                        objErrorList.Error = "Upload Successfully.";
                        errorList.Add(objErrorList);
                    }
                    catch (SqlException ex)
                    {
                        objErrorList.Error = ExceptionHelper.getSqlExceptionMessage(ex);
                        errorList.Add(objErrorList);
                    }
                    catch (Exception ex)
                    {
                        objErrorList.Error = (ExceptionHelper.getExceptionMessage(ex));
                        errorList.Add(objErrorList);
                    }
                    // this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg + ". Voucher No: " + manager.VoucherID);
                }
                this.SuccessMessage = ("Sales Upload Compleated. Please See Log File.");
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
    }
}