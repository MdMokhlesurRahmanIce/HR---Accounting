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
    public class BonusProcessDetail : BaseItem
    {
        public BonusProcessDetail()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _ProcessDetailID;
        [Browsable(true), DisplayName("ProcessDetailID")]
        public System.Int64 ProcessDetailID
        {
            get
            {
                return _ProcessDetailID;
            }
            set
            {
                if (PropertyChanged(_ProcessDetailID, value))
                    _ProcessDetailID = value;
            }
        }

        private System.Int32 _ProcessID;
        [Browsable(true), DisplayName("ProcessID")]
        public System.Int32 ProcessID
        {
            get
            {
                return _ProcessID;
            }
            set
            {
                if (PropertyChanged(_ProcessID, value))
                    _ProcessID = value;
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

        private System.Decimal _BonusAmount;
        [Browsable(true), DisplayName("BonusAmount")]
        public System.Decimal BonusAmount
        {
            get
            {
                return _BonusAmount;
            }
            set
            {
                if (PropertyChanged(_BonusAmount, value))
                    _BonusAmount = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ProcessDetailID, _ProcessID, _EmpKey, _BonusAmount };
            else if (IsModified)
                parameterValues = new Object[] { _ProcessDetailID, _ProcessID, _EmpKey, _BonusAmount };
            else if (IsDeleted)
                parameterValues = new Object[] { _ProcessDetailID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ProcessDetailID = reader.GetInt64("ProcessDetailID");
            _ProcessID = reader.GetInt32("ProcessID");
            _EmpKey = reader.GetInt64("EmpKey");
            _BonusAmount = reader.GetDecimal("BonusAmount");
            SetUnchanged();
        }
        public static CustomList<BonusProcessDetail> GetAllBonusProcessDetail()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<BonusProcessDetail> BonusProcessDetailCollection = new CustomList<BonusProcessDetail>();
            IDataReader reader = null;
            const String sql = "select *from BonusProcessDetail";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    BonusProcessDetail newBonusProcessDetail = new BonusProcessDetail();
                    newBonusProcessDetail.SetData(reader);
                    BonusProcessDetailCollection.Add(newBonusProcessDetail);
                }
                BonusProcessDetailCollection.InsertSpName = "spInsertBonusProcessDetail";
                BonusProcessDetailCollection.UpdateSpName = "spUpdateBonusProcessDetail";
                BonusProcessDetailCollection.DeleteSpName = "spDeleteBonusProcessDetail";
                return BonusProcessDetailCollection;
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