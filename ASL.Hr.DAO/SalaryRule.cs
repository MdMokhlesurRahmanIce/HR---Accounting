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
    public class SalaryRule : BaseItem
    {
        public SalaryRule()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _SalaryRuleKey;
        [Browsable(true), DisplayName("SalaryRuleKey")]
        public System.Int32 SalaryRuleKey
        {
            get
            {
                return _SalaryRuleKey;
            }
            set
            {
                if (PropertyChanged(_SalaryRuleKey, value))
                    _SalaryRuleKey = value;
            }
        }

        private System.String _SalaryRuleCode;
        [Browsable(true), DisplayName("SalaryRuleCode")]
        public System.String SalaryRuleCode
        {
            get
            {
                return _SalaryRuleCode;
            }
            set
            {
                if (PropertyChanged(_SalaryRuleCode, value))
                    _SalaryRuleCode = value;
            }
        }

        private System.Int32 _SalaryHeadKey;
        [Browsable(true), DisplayName("SalaryHeadKey")]
        public System.Int32 SalaryHeadKey
        {
            get
            {
                return _SalaryHeadKey;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadKey, value))
                    _SalaryHeadKey = value;
            }
        }

        private System.String _sCriteria;
        [Browsable(true), DisplayName("sCriteria")]
        public System.String sCriteria
        {
            get
            {
                return _sCriteria;
            }
            set
            {
                if (PropertyChanged(_sCriteria, value))
                    _sCriteria = value;
            }
        }

        private System.String _ParentHeadID;
        [Browsable(true), DisplayName("ParentHeadID")]
        public System.String ParentHeadID
        {
            get
            {
                return _ParentHeadID;
            }
            set
            {
                if (PropertyChanged(_ParentHeadID, value))
                    _ParentHeadID = value;
            }
        }

        private System.Decimal _ParentHeadValue;
        [Browsable(true), DisplayName("ParentHeadValue")]
        public System.Decimal ParentHeadValue
        {
            get
            {
                return _ParentHeadValue;
            }
            set
            {
                if (PropertyChanged(_ParentHeadValue, value))
                    _ParentHeadValue = value;
            }
        }

        private System.String _PartialHeadID;
        [Browsable(true), DisplayName("PartialHeadID")]
        public System.String PartialHeadID
        {
            get
            {
                return _PartialHeadID;
            }
            set
            {
                if (PropertyChanged(_PartialHeadID, value))
                    _PartialHeadID = value;
            }
        }

        private System.Decimal _PartialHeadValue;
        [Browsable(true), DisplayName("PartialHeadValue")]
        public System.Decimal PartialHeadValue
        {
            get
            {
                return _PartialHeadValue;
            }
            set
            {
                if (PropertyChanged(_PartialHeadValue, value))
                    _PartialHeadValue = value;
            }
        }

        private System.Boolean _IsFixed;
        [Browsable(true), DisplayName("IsFixed")]
        public System.Boolean IsFixed
        {
            get
            {
                return _IsFixed;
            }
            set
            {
                if (PropertyChanged(_IsFixed, value))
                    _IsFixed = value;
            }
        }

        private System.Boolean _IsHigher;
        [Browsable(true), DisplayName("IsHigher")]
        public System.Boolean IsHigher
        {
            get
            {
                return _IsHigher;
            }
            set
            {
                if (PropertyChanged(_IsHigher, value))
                    _IsHigher = value;
            }
        }

        private System.String _Formula1;
        [Browsable(true), DisplayName("Formula1")]
        public System.String Formula1
        {
            get
            {
                return _Formula1;
            }
            set
            {
                if (PropertyChanged(_Formula1, value))
                    _Formula1 = value;
            }
        }

        private System.String _Formula2;
        [Browsable(true), DisplayName("Formula2")]
        public System.String Formula2
        {
            get
            {
                return _Formula2;
            }
            set
            {
                if (PropertyChanged(_Formula2, value))
                    _Formula2 = value;
            }
        }
        private System.String _HeadName;
        [Browsable(true), DisplayName("HeadName")]
        public System.String HeadName
        {
            get
            {
                return _HeadName;
            }
            set
            {
                if (PropertyChanged(_HeadName, value))
                    _HeadName = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _SalaryRuleCode, _SalaryHeadKey, _sCriteria, _ParentHeadID, _ParentHeadValue, _PartialHeadID, _PartialHeadValue, _IsFixed, _IsHigher, _Formula1, _Formula2 };
            else if (IsModified)
                parameterValues = new Object[] { _SalaryRuleCode, _SalaryHeadKey, _sCriteria, _ParentHeadID, _ParentHeadValue, _PartialHeadID, _PartialHeadValue, _IsFixed, _IsHigher, _Formula1, _Formula2 };
            else if (IsDeleted)
                parameterValues = new Object[] { _SalaryRuleCode };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SalaryRuleKey = reader.GetInt32("SalaryRuleKey");
            _SalaryRuleCode = reader.GetString("SalaryRuleCode");
            _SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
            _sCriteria = reader.GetString("sCriteria");
            _ParentHeadID = reader.GetString("ParentHeadID");
            _ParentHeadValue = reader.GetDecimal("ParentHeadValue");
            _PartialHeadID = reader.GetString("PartialHeadID");
            _PartialHeadValue = reader.GetDecimal("PartialHeadValue");
            _IsFixed = reader.GetBoolean("IsFixed");
            _IsHigher = reader.GetBoolean("IsHigher");
            _Formula1 = reader.GetString("Formula1");
            _Formula2 = reader.GetString("Formula2");
            SetUnchanged();
        }
        private void SetDataFoumula(IDataRecord reader)
        {
            _SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
            _Formula2 = reader.GetString("Formula2");
            _HeadName = reader.GetString("HeadName");
            _IsFixed = reader.GetBoolean("IsFixed");
            _SalaryRuleCode = reader.GetString("SalaryRuleCode");
            _ParentHeadID = reader.GetString("ParentHeadID");
            _ParentHeadValue = reader.GetDecimal("ParentHeadValue");
            SetUnchanged();
        }
        private void SetDataSalaryInfoGridValidation(IDataRecord reader)
        {
            _ParentHeadID = reader.GetString("ParentHeadID");
            _ParentHeadValue = reader.GetDecimal("ParentHeadValue");
            _PartialHeadID = reader.GetString("PartialHeadID");
            _PartialHeadValue = reader.GetDecimal("PartialHeadValue");
            SetUnchanged();
        }
        public static CustomList<SalaryRule> GetAllSalaryRule()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryRule> SalaryRuleCollection = new CustomList<SalaryRule>();
            IDataReader reader = null;
            const String sql = "select *from SalaryRule";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryRule newSalaryRule = new SalaryRule();
                    newSalaryRule.SetData(reader);
                    SalaryRuleCollection.Add(newSalaryRule);
                }
                SalaryRuleCollection.InsertSpName = "spInsertSalaryRule";
                SalaryRuleCollection.UpdateSpName = "spUpdateSalaryRule";
                SalaryRuleCollection.DeleteSpName = "spDeleteSalaryRule";
                return SalaryRuleCollection;
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
        public static CustomList<SalaryRule> GetAllSalaryRuleFormula(string salaryRuleCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryRule> SalaryRuleCollection = new CustomList<SalaryRule>();
            IDataReader reader = null;
            String sql = "Exec spGetSalaryRule '" + salaryRuleCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryRule newSalaryRule = new SalaryRule();
                    newSalaryRule.SetDataFoumula(reader);
                    SalaryRuleCollection.Add(newSalaryRule);
                }
                return SalaryRuleCollection;
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
        public static SalaryRuleBackup SalaryInfoGridValidation(string salaryRuleCode, Int32 salaryHead)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            SalaryRuleBackup newSalaryRule = new SalaryRuleBackup();
            IDataReader reader = null;
            String sql = "select ParentHeadID,ParentHeadValue,PartialHeadID,PartialHeadValue,IsFormula from SalaryRuleBackup Where SalaryRuleCode='" + salaryRuleCode + "' And SalaryHeadKey=" + salaryHead;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {

                    //newSalaryRule.SetDataSalaryInfoGridValidation(reader);
                    newSalaryRule .ParentHeadID = reader.GetString("ParentHeadID");
                    newSalaryRule.ParentHeadValue = reader.GetDecimal("ParentHeadValue");
                    newSalaryRule.PartialHeadID = reader.GetString("PartialHeadID");
                    newSalaryRule.PartialHeadValue = reader.GetDecimal("PartialHeadValue");
                    newSalaryRule.IsFormula = reader.GetBoolean("IsFormula");
                }
                return newSalaryRule;
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