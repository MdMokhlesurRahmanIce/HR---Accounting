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
    public partial class SearchOrEditVoucher : PageBase
    {
        VoucherManager manager = new VoucherManager();
        #region Constructur
        public SearchOrEditVoucher()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<Acc_Voucher> AccVoucherList
        {
            get
            {
                if (Session["SearchOrEditVoucher_AccVoucherList"] == null)
                    return new CustomList<Acc_Voucher>();
                else
                    return (CustomList<Acc_Voucher>)Session["SearchOrEditVoucher_AccVoucherList"];
            }
            set
            {
                Session["SearchOrEditVoucher_AccVoucherList"] = value;
            }
        }
        private CustomList<Acc_VoucherType> AccVoucherTypeList
        {
            get
            {
                if (Session["SearchOrEditVoucher_AccVoucherTypeList"] == null)
                    return new CustomList<Acc_VoucherType>();
                else
                    return (CustomList<Acc_VoucherType>)Session["SearchOrEditVoucher_AccVoucherTypeList"];
            }
            set
            {
                Session["SearchOrEditVoucher_AccVoucherTypeList"] = value;
            }
        }
        private CustomList<Acc_VoucherDet> AccVoucherDetList
        {
            get
            {
                if (Session["SearchOrEditVoucher_AccVoucherDetList"] == null)
                    return new CustomList<Acc_VoucherDet>();
                else
                    return (CustomList<Acc_VoucherDet>)Session["SearchOrEditVoucher_AccVoucherDetList"];
            }
            set
            {
                Session["SearchOrEditVoucher_AccVoucherDetList"] = value;
            }
        }
        private CustomList<Acc_COA> AccCOAList
        {
            get
            {
                if (Session["SearchOrEditVoucher_AccCOAList"] == null)
                    return new CustomList<Acc_COA>();
                else
                    return (CustomList<Acc_COA>)Session["SearchOrEditVoucher_AccCOAList"];
            }
            set
            {
                Session["SearchOrEditVoucher_AccCOAList"] = value;
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
        #endregion
    }
}