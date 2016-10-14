using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Hr.DAO
{
    [Serializable]
    public class LeavePolicyDetails : BaseItem
    {
        public LeavePolicyDetails()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _LeavePolicyDetKey;
        [Browsable(true), DisplayName("LeavePolicyDetKey")]
        public System.Int32 LeavePolicyDetKey
        {
            get
            {
                return _LeavePolicyDetKey;
            }
            set
            {
                if (PropertyChanged(_LeavePolicyDetKey, value))
                    _LeavePolicyDetKey = value;
            }
        }

        private System.Int32 _LeavePolicyID;
        [Browsable(true), DisplayName("LeavePolicyID")]
        public System.Int32 LeavePolicyID
        {
            get
            {
                return _LeavePolicyID;
            }
            set
            {
                if (PropertyChanged(_LeavePolicyID, value))
                    _LeavePolicyID = value;
            }
        }

        private System.Int32 _MinDays;
        [Browsable(true), DisplayName("MinDays")]
        public System.Int32 MinDays
        {
            get
            {
                return _MinDays;
            }
            set
            {
                if (PropertyChanged(_MinDays, value))
                    _MinDays = value;
            }
        }

        private System.Int32 _MaxDays;
        [Browsable(true), DisplayName("MaxDays")]
        public System.Int32 MaxDays
        {
            get
            {
                return _MaxDays;
            }
            set
            {
                if (PropertyChanged(_MaxDays, value))
                    _MaxDays = value;
            }
        }

        private System.Int32 _WorkingDays;
        [Browsable(true), DisplayName("WorkingDays")]
        public System.Int32 WorkingDays
        {
            get
            {
                return _WorkingDays;
            }
            set
            {
                if (PropertyChanged(_WorkingDays, value))
                    _WorkingDays = value;
            }
        }

        private System.Int32 _LeaveDays;
        [Browsable(true), DisplayName("LeaveDays")]
        public System.Int32 LeaveDays
        {
            get
            {
                return _LeaveDays;
            }
            set
            {
                if (PropertyChanged(_LeaveDays, value))
                    _LeaveDays = value;
            }
        }

        private System.Int32 _MaxAllocation;
        [Browsable(true), DisplayName("MaxAllocation")]
        public System.Int32 MaxAllocation
        {
            get
            {
                return _MaxAllocation;
            }
            set
            {
                if (PropertyChanged(_MaxAllocation, value))
                    _MaxAllocation = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _LeavePolicyID, _MinDays, _MaxDays, _WorkingDays, _LeaveDays, _MaxAllocation };
            else if (IsModified)
                parameterValues = new Object[] { _LeavePolicyID, _MinDays, _MaxDays, _WorkingDays, _LeaveDays, _MaxAllocation };
            else if (IsDeleted)
                parameterValues = new Object[] { _LeavePolicyDetKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _LeavePolicyDetKey = reader.GetInt32("LeavePolicyDetKey");
            _LeavePolicyID = reader.GetInt32("LeavePolicyID");
            _MinDays = reader.GetInt32("MinDays");
            _MaxDays = reader.GetInt32("MaxDays");
            _WorkingDays = reader.GetInt32("WorkingDays");
            _LeaveDays = reader.GetInt32("LeaveDays");
            _MaxAllocation = reader.GetInt32("MaxAllocation");
            SetUnchanged();
        }
        public static CustomList<LeavePolicyDetails> GetAllLeavePolicyDetails()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeavePolicyDetails> LeavePolicyDetailsCollection = new CustomList<LeavePolicyDetails>();
            IDataReader reader = null;
            const String sql = "select * from LeavePolicyDetails";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeavePolicyDetails newLeavePolicyDetails = new LeavePolicyDetails();
                    newLeavePolicyDetails.SetData(reader);
                    LeavePolicyDetailsCollection.Add(newLeavePolicyDetails);
                }
                LeavePolicyDetailsCollection.InsertSpName = "spInsertLeavePolicyDetails";
                LeavePolicyDetailsCollection.UpdateSpName = "spUpdateLeavePolicyDetails";
                LeavePolicyDetailsCollection.DeleteSpName = "spDeleteLeavePolicyDetails";
                return LeavePolicyDetailsCollection;
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
        public static CustomList<LeavePolicyDetails> GetAllLeavePolicyDetails(int leavePolicyID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeavePolicyDetails> LeavePolicyDetailsCollection = new CustomList<LeavePolicyDetails>();
            IDataReader reader = null;
            String sql = "select *from LeavePolicyDetails where LeavePolicyID= " + leavePolicyID + "";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeavePolicyDetails newLeavePolicyDetails = new LeavePolicyDetails();
                    newLeavePolicyDetails.SetData(reader);
                    LeavePolicyDetailsCollection.Add(newLeavePolicyDetails);
                }
                LeavePolicyDetailsCollection.InsertSpName = "spInsertLeavePolicyDetails";
                LeavePolicyDetailsCollection.UpdateSpName = "spUpdateLeavePolicyDetails";
                LeavePolicyDetailsCollection.DeleteSpName = "spDeleteLeavePolicyDetails";
                return LeavePolicyDetailsCollection;
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
