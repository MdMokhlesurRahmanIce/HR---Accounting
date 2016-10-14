using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ACC.DAO
{
    [Serializable]
    public class Acc_VoucherDet : BaseItem
    {
        public Acc_VoucherDet()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _VoucherDetKey;
        [Browsable(true), DisplayName("VoucherDetKey")]
        public System.Int64 VoucherDetKey
        {
            get
            {
                return _VoucherDetKey;
            }
            set
            {
                if (PropertyChanged(_VoucherDetKey, value))
                    _VoucherDetKey = value;
            }
        }

        private System.Int64? _UserKey;
        [Browsable(true), DisplayName("UserKey")]
        public System.Int64? UserKey
        {
            get
            {
                return _UserKey;
            }
            set
            {
                if (PropertyChanged(_UserKey, value))
                    _UserKey = value;
            }
        }

        private System.String _EmpCode;
        [Browsable(true), DisplayName("EmpCode")]
        public System.String EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                if (PropertyChanged(_EmpCode, value))
                    _EmpCode = value;
            }
        }

        private System.String _EmpName;
        [Browsable(true), DisplayName("EmpName")]
        public System.String EmpName
        {
            get
            {
                return _EmpName;
            }
            set
            {
                if (PropertyChanged(_EmpName, value))
                    _EmpName = value;
            }
        }

        private System.Int32? _ContactID;
        [Browsable(true), DisplayName("ContactID")]
        public System.Int32? ContactID
        {
            get
            {
                return _ContactID;
            }
            set
            {
                if (PropertyChanged(_ContactID, value))
                    _ContactID = value;
            }
        }

        private System.Int64 _VoucherKey;
        [Browsable(true), DisplayName("VoucherKey")]
        public System.Int64 VoucherKey
        {
            get
            {
                return _VoucherKey;
            }
            set
            {
                if (PropertyChanged(_VoucherKey, value))
                    _VoucherKey = value;
            }
        }

        private System.Int64 _COAKey;
        [Browsable(true), DisplayName("COAKey")]
        public System.Int64 COAKey
        {
            get
            {
                return _COAKey;
            }
            set
            {
                if (PropertyChanged(_COAKey, value))
                    _COAKey = value;
            }
        }

        private System.Decimal _Dr;
        [Browsable(true), DisplayName("Dr")]
        public System.Decimal Dr
        {
            get
            {
                return _Dr;
            }
            set
            {
                if (PropertyChanged(_Dr, value))
                    _Dr = value;
            }
        }

        private System.Decimal _Cr;
        [Browsable(true), DisplayName("Cr")]
        public System.Decimal Cr
        {
            get
            {
                return _Cr;
            }
            set
            {
                if (PropertyChanged(_Cr, value))
                    _Cr = value;
            }
        }

        private System.DateTime _EntryDate;
        [Browsable(true), DisplayName("EntryDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EntryDate
        {
            get
            {
                return _EntryDate;
            }
            set
            {
                if (PropertyChanged(_EntryDate, value))
                    _EntryDate = value;
            }
        }

        private System.Int64 _EntryUserKey;
        [Browsable(true), DisplayName("EntryUserKey")]
        public System.Int64 EntryUserKey
        {
            get
            {
                return _EntryUserKey;
            }
            set
            {
                if (PropertyChanged(_EntryUserKey, value))
                    _EntryUserKey = value;
            }
        }

        private System.DateTime _LastUpdateDate;
        [Browsable(true), DisplayName("LastUpdateDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime LastUpdateDate
        {
            get
            {
                return _LastUpdateDate;
            }
            set
            {
                if (PropertyChanged(_LastUpdateDate, value))
                    _LastUpdateDate = value;
            }
        }

        private System.Int64 _LastUpdateUserKey;
        [Browsable(true), DisplayName("LastUpdateUserKey")]
        public System.Int64 LastUpdateUserKey
        {
            get
            {
                return _LastUpdateUserKey;
            }
            set
            {
                if (PropertyChanged(_LastUpdateUserKey, value))
                    _LastUpdateUserKey = value;
            }
        }
        private System.String _COAName;
        [Browsable(true), DisplayName("COAName")]
        public System.String COAName
        {
            get
            {
                return _COAName;
            }
            set
            {
                if (PropertyChanged(_COAName, value))
                    _COAName = value;
            }
        }

        private System.DateTime _VoucherDate;
        [Browsable(true), DisplayName("VoucherDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime VoucherDate
        {
            get
            {
                return _VoucherDate;
            }
            set
            {
                if (PropertyChanged(_VoucherDate, value))
                    _VoucherDate = value;
            }
        }

        private System.Int32 _SL;
        [Browsable(true), DisplayName("SL")]
        public System.Int32 SL
        {
            get
            {
                return _SL;
            }
            set
            {
                if (PropertyChanged(_SL, value))
                    _SL = value;
            }
        }

        private System.Decimal _Bal;
        [Browsable(true), DisplayName("Bal")]
        public System.Decimal Bal
        {
            get
            {
                return _Bal;
            }
            set
            {
                if (PropertyChanged(_Bal, value))
                    _Bal = value;
            }
        }

        private System.String _COACode;
        [Browsable(true), DisplayName("COACode")]
        public System.String COACode
        {
            get
            {
                return _COACode;
            }
            set
            {
                if (PropertyChanged(_COACode, value))
                    _COACode = value;
            }
        }

        private System.String _VoucherNo;
        [Browsable(true), DisplayName("VoucherNo")]
        public System.String VoucherNo
        {
            get
            {
                return _VoucherNo;
            }
            set
            {
                if (PropertyChanged(_VoucherNo, value))
                    _VoucherNo = value;
            }
        }

        private System.String _PayRec;
        [Browsable(true), DisplayName("PayRec")]
        public System.String PayRec
        {
            get
            {
                return _PayRec;
            }
            set
            {
                if (PropertyChanged(_PayRec, value))
                    _PayRec = value;
            }
        }

        private System.String _VoucherDesc;
        [Browsable(true), DisplayName("VoucherDesc")]
        public System.String VoucherDesc
        {
            get
            {
                return _VoucherDesc;
            }
            set
            {
                if (PropertyChanged(_VoucherDesc, value))
                    _VoucherDesc = value;
            }
        }

        private System.String _Flag;
        [Browsable(true), DisplayName("Flag")]
        public System.String Flag
        {
            get
            {
                return _Flag;
            }
            set
            {
                if (PropertyChanged(_Flag, value))
                    _Flag = value;
            }
        }

        private System.String _Criteria;
        [Browsable(true), DisplayName("Criteria")]
        public System.String Criteria
        {
            get
            {
                return _Criteria;
            }
            set
            {
                if (PropertyChanged(_Criteria, value))
                    _Criteria = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _UserKey, _ContactID, _VoucherKey, _COAKey, _Dr, _Cr, _EntryDate.Value(StaticInfo.DateFormat), _EntryUserKey, _LastUpdateDate.Value(StaticInfo.DateFormat), _LastUpdateUserKey, _Criteria };
            else if (IsModified)
                parameterValues = new Object[] { _VoucherDetKey, _UserKey, _ContactID, _VoucherKey, _COAKey, _Dr, _Cr, _EntryDate.Value(StaticInfo.DateFormat), _EntryUserKey, _LastUpdateDate.Value(StaticInfo.DateFormat), _LastUpdateUserKey, _Criteria };
            else if (IsDeleted)
                parameterValues = new Object[] { _VoucherDetKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _VoucherDetKey = reader.GetInt64("VoucherDetKey");
            _UserKey = reader.GetInt64("UserKey");
            _ContactID = reader.GetInt32("ContactID");
            _VoucherKey = reader.GetInt64("VoucherKey");
            _COAKey = reader.GetInt64("COAKey");
            _Dr = reader.GetDecimal("Dr");
            _Cr = reader.GetDecimal("Cr");
            _EntryDate = reader.GetDateTime("EntryDate");
            _EntryUserKey = reader.GetInt64("EntryUserKey");
            _LastUpdateDate = reader.GetDateTime("LastUpdateDate");
            _LastUpdateUserKey = reader.GetInt64("LastUpdateUserKey");
            _Criteria = reader.GetString("Criteria");
            SetUnchanged();
        }
        private void SetDataTransaction(IDataRecord reader)
        {
            _VoucherDate = reader.GetDateTime("VoucherDate");
            _VoucherNo = reader.GetString("VoucherNo");
            _PayRec = reader.GetString("PayRec");
            _VoucherDesc = reader.GetString("VoucherDesc");
            _Dr = reader.GetDecimal("Dr");
            _Cr = reader.GetDecimal("Cr");
            SetUnchanged();
        }
        private void SetDataTransaction1(IDataRecord reader)
        {
            //_VoucherNo = reader.GetString("VoucherNo");
            _VoucherDate = reader.GetDateTime("VoucherDate");
            _COAName = reader.GetString("COAName");
            _Dr = reader.GetDecimal("Dr");
            _Cr = reader.GetDecimal("Cr");
            SetUnchanged();
        }
        private void SetDataBS(IDataRecord reader)
        {
            //_SL = reader.GetInt32("SL");
            _COAName = reader.GetString("COAName");
            _COACode = reader.GetString("COACode");
            _Bal = reader.GetDecimal("Bal");
            SetUnchanged();
        }
        private void SetDataTB(IDataRecord reader)
        {

            _COAName = reader.GetString("COAName");
            _Bal = reader.GetDecimal("Bal");
            // _VoucherDate = reader.GetDateTime("VoucherDate");
            //_Dr = reader.GetDecimal("Dr");
            //_Cr = reader.GetDecimal("Cr");
            SetUnchanged();
        }
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            const String sql = "select *from Acc_VoucherDet";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetData(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                Acc_VoucherDetCollection.InsertSpName = "spInsertAcc_VoucherDet";
                Acc_VoucherDetCollection.UpdateSpName = "spUpdateAcc_VoucherDet";
                Acc_VoucherDetCollection.DeleteSpName = "spDeleteAcc_VoucherDet";
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int64 voucherKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "select VoucherDetKey,UserKey,ContactID,VoucherKey,COAKey,Convert(Decimal(18,2),Dr)Dr,Convert(Decimal(18,2),Cr)Cr,EntryDate,EntryUserKey,LastUpdateDate,LastUpdateUserKey,Criteria from Acc_VoucherDet Where VoucherKey=" + voucherKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetData(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                Acc_VoucherDetCollection.InsertSpName = "spInsertAcc_VoucherDet";
                Acc_VoucherDetCollection.UpdateSpName = "spUpdateAcc_VoucherDet";
                Acc_VoucherDetCollection.DeleteSpName = "spDeleteAcc_VoucherDet";
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int64 voucherKey, string fromDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "EXEC spGetVoucherDet " + voucherKey + ",'" + fromDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    ///newAcc_VoucherDet.SetData(reader);
                    newAcc_VoucherDet._VoucherDetKey = reader.GetInt64("VoucherDetKey");
                    newAcc_VoucherDet._VoucherKey = reader.GetInt64("VoucherKey");
                    newAcc_VoucherDet._COAKey = reader.GetInt64("COAKey");
                    newAcc_VoucherDet._Dr = reader.GetDecimal("Dr");
                    newAcc_VoucherDet._Cr = reader.GetDecimal("Cr");
                    newAcc_VoucherDet._EntryDate = reader.GetDateTime("EntryDate");
                    newAcc_VoucherDet._EntryUserKey = reader.GetInt64("EntryUserKey");
                    newAcc_VoucherDet._LastUpdateDate = reader.GetDateTime("LastUpdateDate");
                    newAcc_VoucherDet._LastUpdateUserKey = reader.GetInt64("LastUpdateUserKey");
                    newAcc_VoucherDet._Bal = reader.GetDecimal("Bal");
                    //newAcc_VoucherDet._Flag = reader.GetString("Flag");
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                Acc_VoucherDetCollection.InsertSpName = "spInsertAcc_VoucherDet";
                Acc_VoucherDetCollection.UpdateSpName = "spUpdateAcc_VoucherDet";
                Acc_VoucherDetCollection.DeleteSpName = "spDeleteAcc_VoucherDet";
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<Acc_VoucherDet> CheckBankAndCashVoucher(string searchStr)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "EXEC spCheckCashAndBank " + searchStr;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet._VoucherNo = reader.GetString("VoucherNo");
                    newAcc_VoucherDet._Cr = reader.GetDecimal("Cr");
                    newAcc_VoucherDet._Bal = reader.GetDecimal("Bal");
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<Acc_VoucherDet> GetAllSOList()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "EXEC spGetAllEmpList";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet._EmpName = reader.GetString("EmpName");
                    newAcc_VoucherDet._COAKey = reader.GetInt64("COAKey");
                    newAcc_VoucherDet._COAName = reader.GetString("COAName");
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        public static CustomList<Acc_VoucherDet> GetSOList()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "EXEC spGetAllSOList";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.UserKey = reader.GetInt64("EmpKey");
                    newAcc_VoucherDet.EmpCode = reader.GetString("EmpCode");
                    newAcc_VoucherDet._EmpName = reader.GetString("EmpName");
                    newAcc_VoucherDet._COAKey = reader.GetInt64("COAKey");
                    newAcc_VoucherDet._COAName = reader.GetString("COAName");
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        public static Acc_VoucherDet CheckToDelete(Int64 COAKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            //CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "select Top 1 *  from Acc_VoucherDet Where COAKey=" + COAKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                while (reader.Read())
                {  
                    newAcc_VoucherDet.SetData(reader);
                }
                return newAcc_VoucherDet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int32 orgKey, Int32 isPost, string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_PeriodicTrans " + orgKey + ",'" + fromDate + "','" + toDate + "'," + isPost;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataTransaction1(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDetTB(Int32 orgKey, string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_TB " + orgKey + ",'" + fromDate + "','" + toDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataTB(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int32 orgKey, string fromDate, string toDate, Int32 head)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_Ledger " + head + "," + orgKey + ",'" + fromDate + "','" + toDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataTransaction(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static Decimal GetAllAcc_VoucherDet(Int32 orgKey, string fromDate, string toDate, Int32 head, string spName)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Decimal balance = 0.0M;
            string search = "";
            search = head + "," + orgKey + ",'" + fromDate + "','" + toDate + "'";
            try
            {
                String sql = "EXEC " + spName + " " + search + "";
                Object oppBal = conManager.ExecuteScalarWrapper(sql);
                balance = Convert.ToDecimal(oppBal);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return balance;
        }

        public static long GetExistingVoucher(String voucherDate, Int64 head, Int64 userKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Int64 cOAKey=0 ;
            string search = "";
            search = "'" + voucherDate + "'," + head + "," + userKey;
            try
            {
                String sql = "EXEC spGetExistingSales " + search;
                Object obj = conManager.ExecuteScalarWrapper(sql);
                if (obj.IsNotNull())
                cOAKey = Convert.ToInt64(obj);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return cOAKey;
        }

        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDetPL(Int32 orgKey, string fromDate, string toDate, Int32 fYKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_PL " + fYKey + "," + orgKey + ",'" + fromDate + "','" + toDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataBS(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDetBS(Int32 orgKey, string fromDate, string toDate, Int32 fYKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_BS " + fYKey + "," + orgKey + ",'" + fromDate + "','" + toDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataBS(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<Acc_VoucherDet> GetReceiptHeadList(Int64 empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec spGetReceiptHeadList " + empKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet._COAKey = reader.GetInt64("COAKey");
                    newAcc_VoucherDet._COAName = reader.GetString("COAName");
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static void GetAllYearEndProcess(Int32 fYKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            //CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();


            IDataReader reader = null;
            try
            {
                String sql = "EXEC Acc_YearEnd " + fYKey + "";
                conManager.OpenDataReader(sql, out reader);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static Decimal GetBal(Int64 userKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);

            Decimal Bal = 0.0M;
            try
            {
                String sql = "spGetCustomerWiseBal " + userKey + "";
                Object empcode = conManager.ExecuteScalarWrapper(sql);
                if (empcode.IsNotNull())
                Bal = Convert.ToDecimal(empcode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return Bal;
        }
        public static Decimal GetBal(Int32 contactID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);

            Decimal Bal = 0.0M;
            try
            {
                String sql = "spGetSupplierWiseBal " + contactID + "";
                Object empcode = conManager.ExecuteScalarWrapper(sql);
                Bal = Convert.ToDecimal(empcode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return Bal;
        }
    }
}
