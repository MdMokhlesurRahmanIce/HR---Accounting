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
    public class SalaryRuleBackup : BaseItem
    {
        public SalaryRuleBackup()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _SalaryRuleBackupKey;
        [Browsable(true), DisplayName("SalaryRuleBackupKey")]
        public System.Int32 SalaryRuleBackupKey
        {
            get
            {
                return _SalaryRuleBackupKey;
            }
            set
            {
                if (PropertyChanged(_SalaryRuleBackupKey, value))
                    _SalaryRuleBackupKey = value;
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

        private System.Boolean _IsFormula;
        [Browsable(true), DisplayName("IsFormula")]
        public System.Boolean IsFormula
        {
            get
            {
                return _IsFormula;
            }
            set
            {
                if (PropertyChanged(_IsFormula, value))
                    _IsFormula = value;
            }
        }

        private System.Boolean _IsApproved;
        [Browsable(true), DisplayName("IsApproved")]
        public System.Boolean IsApproved
        {
            get
            {
                return _IsApproved;
            }
            set
            {
                if (PropertyChanged(_IsApproved, value))
                    _IsApproved = value;
            }
        }

        private System.DateTime _DateAdded;
        [Browsable(true), DisplayName("DateAdded"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateAdded
        {
            get
            {
                return _DateAdded;
            }
            set
            {
                if (PropertyChanged(_DateAdded, value))
                    _DateAdded = value;
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
        private System.DateTime _ApprovalDate;
        [Browsable(true), DisplayName("ApprovalDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ApprovalDate
        {
            get
            {
                return _ApprovalDate;
            }
            set
            {
                if (PropertyChanged(_ApprovalDate, value))
                    _ApprovalDate = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _SalaryRuleCode, _SalaryHeadKey, _sCriteria, _ParentHeadID, _ParentHeadValue, _PartialHeadID, _PartialHeadValue, _IsFixed, _IsHigher, _Formula1, _Formula2, _IsFormula, _IsApproved, _DateAdded.Value(StaticInfo.DateFormat), _AddedBy, _ApprovalDate.Value(StaticInfo.DateFormat), _ApproveBy };
            else if (IsModified)
                parameterValues = new Object[] { _SalaryRuleBackupKey, _SalaryRuleCode, _SalaryHeadKey, _sCriteria, _ParentHeadID, _ParentHeadValue, _PartialHeadID, _PartialHeadValue, _IsFixed, _IsHigher, _Formula1, _Formula2, _IsFormula, _IsApproved, _DateAdded.Value(StaticInfo.DateFormat), _AddedBy, _ApprovalDate.Value(StaticInfo.DateFormat), _ApproveBy };
            else if (IsDeleted)
                parameterValues = new Object[] { _SalaryRuleBackupKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SalaryRuleBackupKey = reader.GetInt32("SalaryRuleBackupKey");
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
            _IsFormula = reader.GetBoolean("IsFormula");
            _IsApproved = reader.GetBoolean("IsApproved");
            _DateAdded = reader.GetDateTime("DateAdded");
            _AddedBy = reader.GetString("AddedBy");
            _ApprovalDate = reader.GetDateTime("ApprovalDate");
            _ApproveBy = reader.GetString("ApproveBy");
            SetUnchanged();
        }
        private void SetDataSalaryRuleCode(IDataRecord reader)
        {
            _SalaryRuleCode = reader.GetString("SalaryRuleCode");
            SetUnchanged();
        }
        public static CustomList<SalaryRuleBackup> GetAllSalaryRuleBackup(string salaryRuleCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryRuleBackup> SalaryRuleBackupCollection = new CustomList<SalaryRuleBackup>();
            IDataReader reader = null;
            String sql = "select *from SalaryRuleBackup Where SalaryRuleCode='" + salaryRuleCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryRuleBackup newSalaryRuleBackup = new SalaryRuleBackup();
                    newSalaryRuleBackup.SetData(reader);
                    SalaryRuleBackupCollection.Add(newSalaryRuleBackup);
                }
                SalaryRuleBackupCollection.InsertSpName = "spInsertSalaryRuleBackup";
                SalaryRuleBackupCollection.UpdateSpName = "spUpdateSalaryRuleBackup";
                SalaryRuleBackupCollection.DeleteSpName = "spDeleteSalaryRuleBackup";
                return SalaryRuleBackupCollection;
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
        public static CustomList<SalaryRuleBackup> GetAllSalaryRuleBackup()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryRuleBackup> SalaryRuleBackupCollection = new CustomList<SalaryRuleBackup>();
            IDataReader reader = null;
            String sql = "select Distinct SalaryRuleCode from SalaryRuleBackup ";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryRuleBackup newSalaryRuleBackup = new SalaryRuleBackup();
                    newSalaryRuleBackup.SetDataSalaryRuleCode(reader);
                    SalaryRuleBackupCollection.Add(newSalaryRuleBackup);
                }
                SalaryRuleBackupCollection.InsertSpName = "spInsertSalaryRuleBackup";
                SalaryRuleBackupCollection.UpdateSpName = "spUpdateSalaryRuleBackup";
                SalaryRuleBackupCollection.DeleteSpName = "spDeleteSalaryRuleBackup";
                return SalaryRuleBackupCollection;
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
        public static CustomList<SalaryRuleBackup> doSearch(string whereClause)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryRuleBackup> SalaryRuleBackupCollection = new CustomList<SalaryRuleBackup>();
            IDataReader reader = null;
            String sql = string.Format("select Distinct SalaryRuleCode from SalaryRuleBackup Where 1=1 {0}", whereClause);
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryRuleBackup newSalaryRuleBackup = new SalaryRuleBackup();
                    newSalaryRuleBackup.SetDataSalaryRuleCode(reader);
                    SalaryRuleBackupCollection.Add(newSalaryRuleBackup);
                }
                return SalaryRuleBackupCollection;
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