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
using ASL.Web.Framework;
using System.Data.SqlClient;
using System.Text;

namespace Hr.Web.UI.ACC
{
    public partial class PostingVoucher : PageBase
    {
        VoucherManager manager = new VoucherManager();
        #region Constructur
        public PostingVoucher()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<Acc_Voucher> AccVoucherList
        {
            get
            {
                if (Session["PostingVoucher_AccVoucherList"] == null)
                    return new CustomList<Acc_Voucher>();
                else
                    return (CustomList<Acc_Voucher>)Session["PostingVoucher_AccVoucherList"];
            }
            set
            {
                Session["PostingVoucher_AccVoucherList"] = value;
            }
        }
        private CustomList<Acc_VoucherType> AccVoucherTypeList
        {
            get
            {
                if (Session["PostingVoucher_AccVoucherTypeList"] == null)
                    return new CustomList<Acc_VoucherType>();
                else
                    return (CustomList<Acc_VoucherType>)Session["PostingVoucher_AccVoucherTypeList"];
            }
            set
            {
                Session["PostingVoucher_AccVoucherTypeList"] = value;
            }
        }
        private CustomList<Acc_VoucherDet> AccVoucherDetList
        {
            get
            {
                if (Session["PostingVoucher_AccVoucherDetList"] == null)
                    return new CustomList<Acc_VoucherDet>();
                else
                    return (CustomList<Acc_VoucherDet>)Session["PostingVoucher_AccVoucherDetList"];
            }
            set
            {
                Session["PostingVoucher_AccVoucherDetList"] = value;
            }
        }
        private CustomList<Acc_COA> AccCOAList
        {
            get
            {
                if (Session["PostingVoucher_AccCOAList"] == null)
                    return new CustomList<Acc_COA>();
                else
                    return (CustomList<Acc_COA>)Session["PostingVoucher_AccCOAList"];
            }
            set
            {
                Session["PostingVoucher_AccCOAList"] = value;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeSession();
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #region All Method
        private void InitializeSession()
        {
            try
            {
                AccVoucherList = new CustomList<Acc_Voucher>();
                AccVoucherTypeList = new CustomList<Acc_VoucherType>();
                AccVoucherTypeList = manager.GetAllAcc_VoucherType();
                AccVoucherDetList = new CustomList<Acc_VoucherDet>();
                AccCOAList = manager.GetAllAcc_COA_ByLevel(1);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private string GetSearchStr()
        {
            string searchStr = "";
            TextBox fromDate = (TextBox)ctrlVoucher.FindControl("txtDateFrom");
            TextBox toDate = (TextBox)ctrlVoucher.FindControl("txtDateTo");
            DropDownList vouchertype = (DropDownList)ctrlVoucher.FindControl("ddlVoucherType");
            TextBox voucherNo = (TextBox)ctrlVoucher.FindControl("txtVoucherNo");
            TextBox payOrRecipient = (TextBox)ctrlVoucher.FindControl("txtPayOrRecipient");
            TextBox voucherDescription = (TextBox)ctrlVoucher.FindControl("txtVoucherDescription");
            if (fromDate.Text != "")
                searchStr = "@FromDate='" + fromDate.Text + "'";
            if (toDate.Text != "")
                searchStr = searchStr + ",@ToDate='" + toDate.Text + "'";
            if (vouchertype.SelectedValue != "")
                searchStr = searchStr + ",@VoucherType=" + vouchertype.SelectedValue;
            if (voucherNo.Text != "")
                searchStr = searchStr + ",@VoucherNo=" + voucherNo.Text;
            if (payOrRecipient.Text != "")
                searchStr = searchStr + ",@PayOrRecipient=" + payOrRecipient.Text;
            if (voucherDescription.Text != "")
                searchStr = searchStr + ",@VoucherDescription=" + voucherDescription.Text;
            return searchStr;
        }
        #endregion
        #region Button Event
        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                // string voucherNo = "Cr excet the balance of the following voucherno: ";
                //string showVoucherNo = "";
                string searchStr = GetSearchStr();
                CustomList<Acc_Voucher> lstAccVoucher = AccVoucherList;
                CustomList<Acc_Voucher> modifiedVoucher = lstAccVoucher.FindAll(f => f.IsApproved);
                //CustomList<Acc_VoucherDet> TempVoucherDetList = manager.CheckBankAndCashVoucher(searchStr);
                //To Do Balance Check During Posting
                //foreach (Acc_Voucher vD in modifiedVoucher)
                //{
                //    Acc_VoucherDet vDObj = TempVoucherDetList.Find(f=>f.VoucherNo==vD.VoucherNo);
                //    if (vDObj.IsNotNull())
                //    {
                //        if (vDObj.Cr > vDObj.Bal)
                //        {
                //            if (showVoucherNo == "")
                //                showVoucherNo = voucherNo + vD.VoucherNo;
                //            else
                //                showVoucherNo = showVoucherNo + "," + vD.VoucherNo;
                //        }
                //    }
                //}
                //if (showVoucherNo != "")
                //{
                //    this.ErrorMessage = (showVoucherNo);
                //    return;
                //}
                modifiedVoucher.ForEach(s => s.IsPost = 1);
                modifiedVoucher.ForEach(s => s.PostDate = DateTime.Now);
                modifiedVoucher.ForEach(s => s.PostBy = CurrentUserSession.UserKey);
                manager.SavePostVoucher(ref modifiedVoucher);
                CustomList<Acc_Voucher> UncheckedVoucher = lstAccVoucher.FindAll(f => f.IsApproved.IsFalse());
                HttpContext.Current.Session["PostingVoucher_AccVoucherList"] = UncheckedVoucher;
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
        #endregion
    }
}