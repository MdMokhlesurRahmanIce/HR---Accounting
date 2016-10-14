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
    public class BonusPolicyDetails : BaseItem
    {
        public BonusPolicyDetails()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _PolicyDetailID;
        [Browsable(true), DisplayName("PolicyDetailID")]
        public System.Int32 PolicyDetailID
        {
            get
            {
                return _PolicyDetailID;
            }
            set
            {
                if (PropertyChanged(_PolicyDetailID, value))
                    _PolicyDetailID = value;
            }
        }

        private System.Int32 _PolicyID;
        [Browsable(true), DisplayName("PolicyID")]
        public System.Int32 PolicyID
        {
            get
            {
                return _PolicyID;
            }
            set
            {
                if (PropertyChanged(_PolicyID, value))
                    _PolicyID = value;
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

        private System.Int64 _MaxDays;
        [Browsable(true), DisplayName("MaxDays")]
        public System.Int64 MaxDays
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

        private System.Int32 _CalculationType;
        [Browsable(true), DisplayName("CalculationType")]
        public System.Int32 CalculationType
        {
            get
            {
                return _CalculationType;
            }
            set
            {
                if (PropertyChanged(_CalculationType, value))
                    _CalculationType = value;
            }
        }

        private System.Int32 _HeadID;
        [Browsable(true), DisplayName("HeadID")]
        public System.Int32 HeadID
        {
            get
            {
                return _HeadID;
            }
            set
            {
                if (PropertyChanged(_HeadID, value))
                    _HeadID = value;
            }
        }

        private System.Decimal _Percentage;
        [Browsable(true), DisplayName("Percentage")]
        public System.Decimal Percentage
        {
            get
            {
                return _Percentage;
            }
            set
            {
                if (PropertyChanged(_Percentage, value))
                    _Percentage = value;
            }
        }

        private System.Decimal _Amount;
        [Browsable(true), DisplayName("Amount")]
        public System.Decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                if (PropertyChanged(_Amount, value))
                    _Amount = value;
            }
        }

        private System.Int32 _Method;
        [Browsable(true), DisplayName("Method")]
        public System.Int32 Method
        {
            get
            {
                return _Method;
            }
            set
            {
                if (PropertyChanged(_Method, value))
                    _Method = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _PolicyID, _MinDays, _MaxDays, _CalculationType, _HeadID, _Percentage, _Amount, _Method };
            else if (IsModified)
                parameterValues = new Object[] { _PolicyDetailID, _PolicyID, _MinDays, _MaxDays, _CalculationType, _HeadID, _Percentage, _Amount, _Method };
            else if (IsDeleted)
                parameterValues = new Object[] { _PolicyDetailID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _PolicyDetailID = reader.GetInt32("PolicyDetailID");
            _PolicyID = reader.GetInt32("PolicyID");
            _MinDays = reader.GetInt32("MinDays");
            _MaxDays = reader.GetInt64("MaxDays");
            _CalculationType = reader.GetInt32("CalculationType");
            _HeadID = reader.GetInt32("HeadID");
            _Percentage = reader.GetDecimal("Percentage");
            _Amount = reader.GetDecimal("Amount");
            _Method = reader.GetInt32("Method");
            SetUnchanged();
        }
        public static CustomList<BonusPolicyDetails> GetAllBonusPolicyDetails(Int32 policyID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<BonusPolicyDetails> BonusPolicyDetailsCollection = new CustomList<BonusPolicyDetails>();
            IDataReader reader = null;
            String sql = "select *from BonusPolicyDetails where PolicyID=" + policyID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    BonusPolicyDetails newBonusPolicyDetails = new BonusPolicyDetails();
                    newBonusPolicyDetails.SetData(reader);
                    BonusPolicyDetailsCollection.Add(newBonusPolicyDetails);
                }
                return BonusPolicyDetailsCollection;
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
