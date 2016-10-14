using System;
using System.Web;
using System.Text;
using System.Web.SessionState;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;


namespace ASL.Hr.DAO
{
    [Serializable]
    public class TransferAndPromotionHistory : BaseItem
    {
        public TransferAndPromotionHistory()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _ChangeID;
        [Browsable(true), DisplayName("ChangeID")]
        public System.Int32 ChangeID
        {
            get
            {
                return _ChangeID;
            }
            set
            {
                if (PropertyChanged(_ChangeID, value))
                    _ChangeID = value;
            }
        }

        private System.Int64 _EmpKey;
        [Browsable(true), DisplayName("EmpKey")]
        public System.Int64 EmpKey
        {
            get
            {
                return _EmpKey;
            }
            set
            {
                if (PropertyChanged(_EmpKey, value))
                    _EmpKey = value;
            }
        }

        private System.Int32 _PreHKEntryID;
        [Browsable(true), DisplayName("PreHKEntryID")]
        public System.Int32 PreHKEntryID
        {
            get
            {
                return _PreHKEntryID;
            }
            set
            {
                if (PropertyChanged(_PreHKEntryID, value))
                    _PreHKEntryID = value;
            }
        }

        private System.Int32 _CurrentHKEntryID;
        [Browsable(true), DisplayName("CurrentHKEntryID")]
        public System.Int32 CurrentHKEntryID
        {
            get
            {
                return _CurrentHKEntryID;
            }
            set
            {
                if (PropertyChanged(_CurrentHKEntryID, value))
                    _CurrentHKEntryID = value;
            }
        }

        private System.String _PreHKEntryName;
        [Browsable(true), DisplayName("PreHKEntryName")]
        public System.String PreHKEntryName
        {
            get
            {
                return _PreHKEntryName;
            }
            set
            {
                if (PropertyChanged(_PreHKEntryName, value))
                    _PreHKEntryName = value;
            }
        }

        private System.String _CurrentHKEntryName;
        [Browsable(true), DisplayName("CurrentHKEntryName")]
        public System.String CurrentHKEntryName
        {
            get
            {
                return _CurrentHKEntryName;
            }
            set
            {
                if (PropertyChanged(_CurrentHKEntryName, value))
                    _CurrentHKEntryName = value;
            }
        }

        private System.DateTime _EffectiveDate;
        [Browsable(true), DisplayName("EffectiveDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EffectiveDate
        {
            get
            {
                return _EffectiveDate;
            }
            set
            {
                if (PropertyChanged(_EffectiveDate, value))
                    _EffectiveDate = value;
            }
        }

        private System.DateTime _ToDate;
        [Browsable(true), DisplayName("ToDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                if (PropertyChanged(_ToDate, value))
                    _ToDate = value;
            }
        }

        private System.Int32 _Type;
        [Browsable(true), DisplayName("Type")]
        public System.Int32 Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (PropertyChanged(_Type, value))
                    _Type = value;
            }
        }

        private System.String _StatusType;
        [Browsable(true), DisplayName("StatusType")]
        public System.String StatusType
        {
            get
            {
                return _StatusType;
            }
            set
            {
                if (PropertyChanged(_StatusType, value))
                    _StatusType = value;
            }
        }

        private System.Int32 _EntityID;
        [Browsable(true), DisplayName("EntityID")]
        public System.Int32 EntityID
        {
            get
            {
                return _EntityID;
            }
            set
            {
                if (PropertyChanged(_EntityID, value))
                    _EntityID = value;
            }
        }

        private System.String _EntityName;
        [Browsable(true), DisplayName("EntityName")]
        public System.String EntityName
        {
            get
            {
                return _EntityName;
            }
            set
            {
                if (PropertyChanged(_EntityName, value))
                    _EntityName = value;
            }
        }

        private System.DateTime _NextReviewDate;
        [Browsable(true), DisplayName("NextReviewDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime NextReviewDate
        {
            get
            {
                return _NextReviewDate;
            }
            set
            {
                if (PropertyChanged(_NextReviewDate, value))
                    _NextReviewDate = value;
            }
        }
        private System.String _Remarks;
        [Browsable(true), DisplayName("Remarks")]
        public System.String Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                if (PropertyChanged(_Remarks, value))
                    _Remarks = value;
            }
        }
        private System.String _AddedBy;
        [Browsable(true), DisplayName("AddedBy")]
        public System.String AddedBy
        {
            get
            {
                return _AddedBy;
            }
            set
            {
                if (PropertyChanged(_AddedBy, value))
                    _AddedBy = value;
            }
        }

        private System.DateTime _AddedDate;
        [Browsable(true), DisplayName("AddedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime AddedDate
        {
            get
            {
                return _AddedDate;
            }
            set
            {
                if (PropertyChanged(_AddedDate, value))
                    _AddedDate = value;
            }
        }

        private System.String _UpdatedBy;
        [Browsable(true), DisplayName("UpdatedBy")]
        public System.String UpdatedBy
        {
            get
            {
                return _UpdatedBy;
            }
            set
            {
                if (PropertyChanged(_UpdatedBy, value))
                    _UpdatedBy = value;
            }
        }

        private System.DateTime _UpdatedDate;
        [Browsable(true), DisplayName("UpdatedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime UpdatedDate
        {
            get
            {
                return _UpdatedDate;
            }
            set
            {
                if (PropertyChanged(_UpdatedDate, value))
                    _UpdatedDate = value;
            }
        }

        private System.String _ApproveBy;
        [Browsable(true), DisplayName("ApproveBy")]
        public System.String ApproveBy
        {
            get
            {
                return _ApproveBy;
            }
            set
            {
                if (PropertyChanged(_ApproveBy, value))
                    _ApproveBy = value;
            }
        }

        private System.DateTime _ApproveDate;
        [Browsable(true), DisplayName("ApproveDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ApproveDate
        {
            get
            {
                return _ApproveDate;
            }
            set
            {
                if (PropertyChanged(_ApproveDate, value))
                    _ApproveDate = value;
            }
        }

        private System.Boolean _IsPermanentTransfer;
        [Browsable(true), DisplayName("IsPermanentTransfer")]
        public System.Boolean IsPermanentTransfer
        {
            get
            {
                return _IsPermanentTransfer;
            }
            set
            {
                if (PropertyChanged(_IsPermanentTransfer, value))
                    _IsPermanentTransfer = value;
            }
        }

        private System.Boolean _IsChecked;
        [Browsable(true), DisplayName("IsChecked")]
        public System.Boolean IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                if (PropertyChanged(_IsChecked, value))
                    _IsChecked = value;
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
        private System.String _Designation;
        [Browsable(true), DisplayName("Designation")]
        public System.String Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                if (PropertyChanged(_Designation, value))
                    _Designation = value;
            }
        }
        private System.String _Department;
        [Browsable(true), DisplayName("Department")]
        public System.String Department
        {
            get
            {
                return _Department;
            }
            set
            {
                if (PropertyChanged(_Department, value))
                    _Department = value;
            }
        }
        private System.String _ElementName;
        [Browsable(true), DisplayName("ElementName")]
        public System.String ElementName
        {
            get
            {
                return _ElementName;
            }
            set
            {
                if (PropertyChanged(_ElementName, value))
                    _ElementName = value;
            }
        }
        private System.DateTime _DOJ;
        [Browsable(true), DisplayName("DOJ"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DOJ
        {
            get
            {
                return _DOJ;
            }
            set
            {
                if (PropertyChanged(_DOJ, value))
                    _DOJ = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _PreHKEntryID, _CurrentHKEntryID, _PreHKEntryName, _CurrentHKEntryName, _EffectiveDate.Value(StaticInfo.DateFormat), _ToDate.Value(StaticInfo.DateFormat), _Type, _StatusType, _EntityID, _EntityName, _Remarks, _NextReviewDate.Value(StaticInfo.DateFormat), _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat), _ApproveBy, _ApproveDate.Value(StaticInfo.DateFormat), _IsPermanentTransfer };
            else if (IsModified)
                parameterValues = new Object[] { _EmpKey, _PreHKEntryID, _CurrentHKEntryID, _PreHKEntryName, _CurrentHKEntryName, _EffectiveDate.Value(StaticInfo.DateFormat), _ToDate.Value(StaticInfo.DateFormat), _Type, _StatusType, _EntityID, _EntityName, _Remarks, _NextReviewDate.Value(StaticInfo.DateFormat), _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat), _ApproveBy, _ApproveDate.Value(StaticInfo.DateFormat), _IsPermanentTransfer };
            else if (IsDeleted)
                parameterValues = new Object[] { _ChangeID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ChangeID = reader.GetInt32("ChangeID");
            _EmpKey = reader.GetInt64("EmpKey");
            _PreHKEntryID = reader.GetInt32("PreHKEntryID");
            _CurrentHKEntryID = reader.GetInt32("CurrentHKEntryID");
            _PreHKEntryName = reader.GetString("PreHKEntryName");
            _CurrentHKEntryName = reader.GetString("CurrentHKEntryName");
            _EffectiveDate = reader.GetDateTime("EffectiveDate");
            _ToDate = reader.GetDateTime("EffectiveDate");
            _Type = reader.GetInt32("Type");
            _StatusType = reader.GetString("StatusType");
            _EntityID = reader.GetInt32("EntityID");
            _EntityName = reader.GetString("EntityName");
            _Remarks = reader.GetString("Remarks");
            _NextReviewDate = reader.GetDateTime("NextReviewDate");
            _AddedBy = reader.GetString("AddedBy");
            _AddedDate = reader.GetDateTime("AddedDate");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _UpdatedDate = reader.GetDateTime("UpdatedDate");
            _ApproveBy = reader.GetString("ApproveBy");
            _ApproveDate = reader.GetDateTime("ApproveDate");
            _IsPermanentTransfer = reader.GetBoolean("IsPermanentTransfer");
            SetUnchanged();
        }
        public void SetData2(IDataRecord reader)
        {

            _EmpKey = reader.GetInt64("EmpKey");
            _PreHKEntryID = reader.GetInt32("PreHKEntryID");
            _PreHKEntryName = reader.GetString("PreHKEntryName");
            _StatusType = reader.GetString("StatusType");
            _EntityID = reader.GetInt32("EntityID");
            _EntityName = reader.GetString("EntityName");
            SetUnchanged();
        }
        public static CustomList<TransferAndPromotionHistory> GetAllTransferAndPromotionHistory()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TransferAndPromotionHistory> TransferAndPromotionHistoryCollection = new CustomList<TransferAndPromotionHistory>();
            IDataReader reader = null;
            const String sql = "select * from TransferAndPromotionHistory";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TransferAndPromotionHistory newTransferAndPromotionHistory = new TransferAndPromotionHistory();
                    newTransferAndPromotionHistory.SetData(reader);
                    TransferAndPromotionHistoryCollection.Add(newTransferAndPromotionHistory);
                }
                return TransferAndPromotionHistoryCollection;
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
        public static CustomList<TransferAndPromotionHistory> GetAllExistingInfoForPromotion(string EmpCode, int promotionOrTransferCritaria)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TransferAndPromotionHistory> TransferAndPromotionHistoryCollection = new CustomList<TransferAndPromotionHistory>();
            IDataReader reader = null;
            String sql = "exec spGetPromotionCriteria '" + EmpCode + "'";// +promotionOrTransferCritaria;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TransferAndPromotionHistory newTransferAndPromotionHistory = new TransferAndPromotionHistory();
                    newTransferAndPromotionHistory.SetData2(reader);
                    TransferAndPromotionHistoryCollection.Add(newTransferAndPromotionHistory);
                }
                return TransferAndPromotionHistoryCollection;
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
        public static CustomList<TransferAndPromotionHistory> GetAllEmpForTransferApproval()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TransferAndPromotionHistory> TransferAndPromotionHistoryCollection = new CustomList<TransferAndPromotionHistory>();
            IDataReader reader = null;
            String sql = "exec spGetTransferEmp";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TransferAndPromotionHistory newTransferAndPromotionHistory = new TransferAndPromotionHistory();
                    newTransferAndPromotionHistory.EmpKey = reader.GetInt64("EmpKey");
                    newTransferAndPromotionHistory.EmpCode = reader.GetString("EmpCode");
                    newTransferAndPromotionHistory.EmpName = reader.GetString("EmpName");
                    newTransferAndPromotionHistory.DOJ = reader.GetDateTime("DOJ");
                    newTransferAndPromotionHistory.Designation = reader.GetString("Designation");
                    newTransferAndPromotionHistory.Department = reader.GetString("Department");
                    newTransferAndPromotionHistory.ElementName = reader.GetString("ElementName");
                    newTransferAndPromotionHistory.EffectiveDate = reader.GetDateTime("EffectiveDate");
                    newTransferAndPromotionHistory.AddedBy = reader.GetString("AddedBy");
                    newTransferAndPromotionHistory.AddedDate = reader.GetDateTime("AddedDate");
                    TransferAndPromotionHistoryCollection.Add(newTransferAndPromotionHistory);
                }
                return TransferAndPromotionHistoryCollection;
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
        public static CustomList<TransferAndPromotionHistory> GetAllTransferApproval()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TransferAndPromotionHistory> TransferAndPromotionHistoryCollection = new CustomList<TransferAndPromotionHistory>();
            IDataReader reader = null;
            String sql = "exec spGetTransferApproval";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TransferAndPromotionHistory newTransferAndPromotionHistory = new TransferAndPromotionHistory();
                    newTransferAndPromotionHistory.EmpKey = reader.GetInt64("EmpKey");
                    newTransferAndPromotionHistory.EntityID = reader.GetInt32("EntityID");
                    newTransferAndPromotionHistory.EntityName = reader.GetString("EntityName");
                    newTransferAndPromotionHistory.PreHKEntryID = reader.GetInt32("PreHKEntryID");
                    newTransferAndPromotionHistory.PreHKEntryName = reader.GetString("PreHKEntryName");
                    newTransferAndPromotionHistory.CurrentHKEntryID = reader.GetInt32("CurrentHKEntryID");
                    newTransferAndPromotionHistory.CurrentHKEntryName = reader.GetString("CurrentHKEntryName");
                    TransferAndPromotionHistoryCollection.Add(newTransferAndPromotionHistory);
                }
                return TransferAndPromotionHistoryCollection;
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
        public static CustomList<TransferAndPromotionHistory> GetAllEmpForPromotionApproval()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TransferAndPromotionHistory> TransferAndPromotionHistoryCollection = new CustomList<TransferAndPromotionHistory>();
            IDataReader reader = null;
            String sql = "exec spGetPromotionEmp";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TransferAndPromotionHistory newTransferAndPromotionHistory = new TransferAndPromotionHistory();
                    newTransferAndPromotionHistory.EmpKey = reader.GetInt64("EmpKey");
                    newTransferAndPromotionHistory.EmpCode = reader.GetString("EmpCode");
                    newTransferAndPromotionHistory.EmpName = reader.GetString("EmpName");
                    newTransferAndPromotionHistory.DOJ = reader.GetDateTime("DOJ");
                    newTransferAndPromotionHistory.Designation = reader.GetString("Designation");
                    newTransferAndPromotionHistory.Department = reader.GetString("Department");
                    newTransferAndPromotionHistory.ElementName = reader.GetString("ElementName");
                    newTransferAndPromotionHistory.EffectiveDate = reader.GetDateTime("EffectiveDate");
                    newTransferAndPromotionHistory.AddedBy = reader.GetString("AddedBy");
                    newTransferAndPromotionHistory.AddedDate = reader.GetDateTime("AddedDate");
                    TransferAndPromotionHistoryCollection.Add(newTransferAndPromotionHistory);
                }
                return TransferAndPromotionHistoryCollection;
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
        public static CustomList<TransferAndPromotionHistory> GetAllPromotionApproval()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TransferAndPromotionHistory> TransferAndPromotionHistoryCollection = new CustomList<TransferAndPromotionHistory>();
            IDataReader reader = null;
            String sql = "exec spGetPromotionApproval";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TransferAndPromotionHistory newTransferAndPromotionHistory = new TransferAndPromotionHistory();
                    newTransferAndPromotionHistory.EmpKey = reader.GetInt64("EmpKey");
                    newTransferAndPromotionHistory.EntityID = reader.GetInt32("EntityID");
                    newTransferAndPromotionHistory.EntityName = reader.GetString("EntityName");
                    newTransferAndPromotionHistory.PreHKEntryID = reader.GetInt32("PreHKEntryID");
                    newTransferAndPromotionHistory.PreHKEntryName = reader.GetString("PreHKEntryName");
                    newTransferAndPromotionHistory.CurrentHKEntryID = reader.GetInt32("CurrentHKEntryID");
                    newTransferAndPromotionHistory.CurrentHKEntryName = reader.GetString("CurrentHKEntryName");
                    TransferAndPromotionHistoryCollection.Add(newTransferAndPromotionHistory);
                }
                return TransferAndPromotionHistoryCollection;
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
    }
}