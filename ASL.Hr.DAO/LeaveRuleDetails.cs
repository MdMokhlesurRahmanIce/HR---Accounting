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
    public class LeaveRuleDetails : BaseItem
    {
        public LeaveRuleDetails()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _LeaveRuleDetailsKey;
        [Browsable(true), DisplayName("LeaveRuleDetailsKey")]
        public System.Int32 LeaveRuleDetailsKey
        {
            get
            {
                return _LeaveRuleDetailsKey;
            }
            set
            {
                if (PropertyChanged(_LeaveRuleDetailsKey, value))
                    _LeaveRuleDetailsKey = value;
            }
        }

        private System.Int32 _LeaveRuleKey;
        [Browsable(true), DisplayName("LeaveRuleKey")]
        public System.Int32 LeaveRuleKey
        {
            get
            {
                return _LeaveRuleKey;
            }
            set
            {
                if (PropertyChanged(_LeaveRuleKey, value))
                    _LeaveRuleKey = value;
            }
        }

        private System.Int32 _LeavePolicyId;
        [Browsable(true), DisplayName("LeavePolicyId")]
        public System.Int32 LeavePolicyId
        {
            get
            {
                return _LeavePolicyId;
            }
            set
            {
                if (PropertyChanged(_LeavePolicyId, value))
                    _LeavePolicyId = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _LeaveRuleKey, _LeavePolicyId };
            else if (IsModified)
                parameterValues = new Object[] { _LeaveRuleDetailsKey,_LeaveRuleKey, _LeavePolicyId };
            else if (IsDeleted)
                parameterValues = new Object[] { _LeaveRuleDetailsKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _LeaveRuleDetailsKey = reader.GetInt32("LeaveRuleDetailsKey");
            _LeaveRuleKey = reader.GetInt32("LeaveRuleKey");
            _LeavePolicyId = reader.GetInt32("LeavePolicyId");
            SetUnchanged();
        }
        public static CustomList<LeaveRuleDetails> GetAllLeaveRuleDetails()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveRuleDetails> LeaveRuleDetailsCollection = new CustomList<LeaveRuleDetails>();
            IDataReader reader = null;
            const String sql = "select * from LeaveRuleDetails";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveRuleDetails newLeaveRuleDetails = new LeaveRuleDetails();
                    newLeaveRuleDetails.SetData(reader);
                    LeaveRuleDetailsCollection.Add(newLeaveRuleDetails);
                }
                LeaveRuleDetailsCollection.InsertSpName = "spInsertLeaveRuleDetails";
                LeaveRuleDetailsCollection.UpdateSpName = "spUpdateLeaveRuleDetails";
                LeaveRuleDetailsCollection.DeleteSpName = "spDeleteLeaveRuleDetails";
                return LeaveRuleDetailsCollection;
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
        public static CustomList<LeaveRuleDetails> GetSelectedLeaveRuleDetails(int LeaveRuleKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveRuleDetails> LeaveRuleDetailsCollection = new CustomList<LeaveRuleDetails>();
            IDataReader reader = null;
            String sql = "select * from LeaveRuleDetails where LeaveRuleKey = "+ LeaveRuleKey+"";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveRuleDetails newLeaveRuleDetails = new LeaveRuleDetails();
                    newLeaveRuleDetails.SetData(reader);
                    LeaveRuleDetailsCollection.Add(newLeaveRuleDetails);
                }
                LeaveRuleDetailsCollection.InsertSpName = "spInsertLeaveRuleDetails";
                LeaveRuleDetailsCollection.UpdateSpName = "spUpdateLeaveRuleDetails";
                LeaveRuleDetailsCollection.DeleteSpName = "spDeleteLeaveRuleDetails";
                return LeaveRuleDetailsCollection;
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