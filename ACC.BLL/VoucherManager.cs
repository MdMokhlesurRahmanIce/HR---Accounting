using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.DAL;
using ACC.DAO;
using ASL.Hr.DAO;
using ASL.STATIC;
using System.Data;
using System.Data.SqlClient;


namespace ACC.BLL
{
    public class VoucherManager
    {
        private String voucherID = String.Empty;
        public String VoucherID
        {
            get { return voucherID; }
        }
        public CustomList<Acc_COA> GetAllAcc_COA()
        {
            return Acc_COA.GetAllAcc_COA();
        }
        public CustomList<HRM_Emp> doSearch()
        {
            return HRM_Emp.doSearch("");
        }
        public CustomList<Acc_COA> GetAllAcc_COA_CashInHand()
        {
            return Acc_COA.GetAllAcc_COA_CashInHand();
        }
        public CustomList<Acc_COA> GetAllAcc_COA_CashAtBank()
        {
            return Acc_COA.GetAllAcc_COA_CashAtBank();
        }
        public CustomList<Acc_COA> GetAllAcc_COA_ByLevel(int isSubsidiary)
        {
            return Acc_COA.GetAllAcc_COA_ByLevel(isSubsidiary);
        }
        public CustomList<Acc_COA> GetAllAcc_COAGetPayable()
        {
            return Acc_COA.GetAllAcc_COAGetPayable();
        }
        public CustomList<Acc_COA> GetAllAcc_COAGetReceivable()
        {
            return Acc_COA.GetAllAcc_COAGetReceivable();
        }
        public Decimal GetBal(Int32 contactID)
        {
            return Acc_VoucherDet.GetBal(contactID);
        }
        public long GetExistingVoucher(String voucherDate, Int64 head, Int64 userKey)
        {
            return Acc_VoucherDet.GetExistingVoucher(voucherDate, head, userKey);
        }
        public Decimal GetBal(Int64 UserKey)
        {
            return Acc_VoucherDet.GetBal(UserKey);
        }
        public CustomList<Contact> GetAllContact()
        {
            return Contact.GetAllContact();
        }
        public CustomList<Acc_COA> GetAllAcc_COA_ByLevelAll(int isSubsidiary, int voucherType)
        {
            return Acc_COA.GetAllAcc_COA_ByLevelAll(isSubsidiary, voucherType);
        }
        public CustomList<ACC.DAO.Organization> GetAllCompany(string empCode, Int32 isAdmin)
        {
            return ACC.DAO.Organization.GetAllOrganization(empCode, isAdmin);
        }
        public CustomList<ACC.DAO.Organization> GetAllCompany()
        {
            return ACC.DAO.Organization.GetAllOrganization(2);
        }
        public CustomList<HouseKeepingValue> GetCompany()
        {
            return HouseKeepingValue.GetCompany();
        }
        public CustomList<Acc_VoucherType> GetAllAcc_VoucherType()
        {
            return Acc_VoucherType.GetAllAcc_VoucherType();
        }
        public CustomList<Acc_VoucherType> GetAllAcc_VoucherTypeForPurchase()
        {
            return Acc_VoucherType.GetAllAcc_VoucherTypeForPurchase();
        }
        public CustomList<Acc_VoucherType> GetAllAcc_VoucherTypePayment()
        {
            return Acc_VoucherType.GetAllAcc_VoucherTypePayment();
        }
        public CustomList<Acc_VoucherType> GetAllAcc_VoucherTypeReceipt()
        {
            return Acc_VoucherType.GetAllAcc_VoucherTypeReceipt();
        }
        public CustomList<Acc_Voucher> GetAllAcc_Voucher()
        {
            return Acc_Voucher.GetAllAcc_Voucher();
        }
        public Acc_Voucher GetAllAcc_Voucher(string voucherNo)
        {
            return Acc_Voucher.GetAllAcc_Voucher(voucherNo);
        }
        public CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int64 voucherKey, string fromDate)
        {
            return Acc_VoucherDet.GetAllAcc_VoucherDet(voucherKey, fromDate);
        }
        public CustomList<Acc_VoucherDet> GetReceiptHeadList(Int64 empKey)
        {
            return Acc_VoucherDet.GetReceiptHeadList(empKey);
        }
        public CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int64 voucherKey)
        {
            return Acc_VoucherDet.GetAllAcc_VoucherDet(voucherKey);
        }
        public CustomList<HRM_Emp> GetAllSO()
        {
            return HRM_Emp.GetAllSO();
        }
        //Posting Voucher
        public CustomList<Acc_Voucher> GetAllAcc_VoucherSearch(string searchStr)
        {
            return Acc_Voucher.GetAllAcc_VoucherSearch(searchStr);
        }
        public CustomList<Acc_VoucherDet> CheckBankAndCashVoucher(string searchStr)
        {
            return Acc_VoucherDet.CheckBankAndCashVoucher(searchStr);
        }
        
        //End
        //Search Voucher
        public CustomList<Acc_Voucher> GetAllAcc_VoucherSearch(string searchStr, string blank)
        {
            return Acc_Voucher.GetAllAcc_VoucherSearch(searchStr, blank);
        }
        //end
        public void SavePFVoucher(ref CustomList<Acc_Voucher> AccVoucherList, ref CustomList<Acc_VoucherDet> AccVoucherDetList, string prifix)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                blnTranStarted = true;
                conManager.BeginTransaction();

                ReSetSPName(ref AccVoucherList, ref AccVoucherDetList);
                if (AccVoucherList[0].VoucherNo.IsNullOrEmpty())
                {
                    GetNewVoucherID(ref conManager, blnTranStarted, ref AccVoucherList, prifix);
                }
                else
                {
                    string[] items = AccVoucherList[0].VoucherNo.Split('-');
                    if (prifix != items[0])
                    {
                        string prifix1 = prifix + "-" + items[1];
                        voucherID = prifix1;
                        AccVoucherList[0].VoucherNo = prifix1;
                    }
                    else
                        voucherID = AccVoucherList[0].VoucherNo;
                }
                blnTranStarted = true;

                if (AccVoucherList[0].IsAdded)
                {
                    object scope_Identity = conManager.InsertData(blnTranStarted, AccVoucherList);
                    AccVoucherList[0].VoucherKey = Convert.ToInt64(scope_Identity);
                }
                else
                {
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, AccVoucherList);
                }
                CustomList<Acc_VoucherDet> AddedVoucherDetList = AccVoucherDetList.FindAll(f => f.IsAdded);
                foreach (Acc_VoucherDet aVD in AddedVoucherDetList)
                {
                    aVD.VoucherKey = AccVoucherList[0].VoucherKey;
                }
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, AccVoucherDetList);

                conManager.CommitTransaction();
                AccVoucherList.AcceptChanges();
                AccVoucherDetList.AcceptChanges();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    blnTranStarted = false;
                    conManager.Dispose();
                }
            }
        }
        private void ReSetSPName(ref CustomList<Acc_Voucher> AccVoucherList, ref CustomList<Acc_VoucherDet> AccVoucherDetList)
        {
            #region Acc Voucher
            AccVoucherList.InsertSpName = "spInsertAcc_Voucher";
            AccVoucherList.UpdateSpName = "spUpdateAcc_Voucher";
            AccVoucherList.DeleteSpName = "spDeleteAcc_Voucher";
            #endregion
            #region Acc Voucher Det
            AccVoucherDetList.InsertSpName = "spInsertAcc_VoucherDet";
            AccVoucherDetList.UpdateSpName = "spUpdateAcc_VoucherDet";
            AccVoucherDetList.DeleteSpName = "spDeleteAcc_VoucherDet";
            #endregion
        }
        private void GetNewVoucherID(ref ConnectionManager conManager, bool requiredTransaction, ref CustomList<Acc_Voucher> AccVoucherList, string prifix)
        {
            String newAccVoucherID = String.Empty;
            try
            {
                CustomList<Acc_Voucher> tempAccVoucherList = AccVoucherList.FindAll(f => f.IsAdded);
                if (tempAccVoucherList.Count != 0)
                {
                    string prifix1 = prifix + "-";
                    newAccVoucherID = Convert.ToString(StaticInfo.GetUniqueCodeWithoutSignature(ref conManager, requiredTransaction, "Acc_Voucher", "VoucherNo", prifix1));
                    tempAccVoucherList[0].VoucherNo = prifix1 + newAccVoucherID;
                    voucherID = prifix1 + newAccVoucherID;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void DeleteVoucher(ref CustomList<Acc_VoucherDet> VoucherDetList, ref CustomList<Acc_Voucher> VoucherList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPName(ref VoucherList, ref VoucherDetList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, VoucherDetList, VoucherList);
                conManager.CommitTransaction();
                VoucherDetList.AcceptChanges();
                VoucherList.AcceptChanges();
            }
            catch (Exception ex)
            {
                conManager.RollBack();
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    blnTranStarted = false;
                    conManager.Dispose();
                }
            }
        }
        //Posting Voucher
        public void SavePostVoucher(ref CustomList<Acc_Voucher> AccVoucherList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                //ReSetSPName(ref AccVoucherList); spUpdateAcc_VoucherPost
                AccVoucherList.UpdateSpName = "spUpdateAcc_VoucherPost";
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, AccVoucherList);

                conManager.CommitTransaction();
                AccVoucherList.AcceptChanges();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    blnTranStarted = false;
                    conManager.Dispose();
                }
            }
        }

        
        //end

        
    }
}

