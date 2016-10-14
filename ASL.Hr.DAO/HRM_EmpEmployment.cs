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
    public class HRM_EmpEmployment : BaseItem
    {
        public HRM_EmpEmployment()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _EmpEmployKey;
        [Browsable(true), DisplayName("EmpEmployKey")]
        public System.Int64 EmpEmployKey
        {
            get
            {
                return _EmpEmployKey;
            }
            set
            {
                if (PropertyChanged(_EmpEmployKey, value))
                    _EmpEmployKey = value;
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

        private System.String _EmployerName;
        [Browsable(true), DisplayName("EmployerName")]
        public System.String EmployerName
        {
            get
            {
                return _EmployerName;
            }
            set
            {
                if (PropertyChanged(_EmployerName, value))
                    _EmployerName = value;
            }
        }

        private System.String _LastDesigKey;
        [Browsable(true), DisplayName("LastDesigKey")]
        public System.String LastDesigKey
        {
            get
            {
                return _LastDesigKey;
            }
            set
            {
                if (PropertyChanged(_LastDesigKey, value))
                    _LastDesigKey = value;
            }
        }

        private System.DateTime _DateFrom;
        [Browsable(true), DisplayName("DateFrom"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateFrom
        {
            get
            {
                return _DateFrom;
            }
            set
            {
                if (PropertyChanged(_DateFrom, value))
                    _DateFrom = value;
            }
        }

        private System.DateTime _DateTo;
        [Browsable(true), DisplayName("DateTo"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateTo
        {
            get
            {
                return _DateTo;
            }
            set
            {
                if (PropertyChanged(_DateTo, value))
                    _DateTo = value;
            }
        }

        private System.String _EmployerAddr;
        [Browsable(true), DisplayName("EmployerAddr")]
        public System.String EmployerAddr
        {
            get
            {
                return _EmployerAddr;
            }
            set
            {
                if (PropertyChanged(_EmployerAddr, value))
                    _EmployerAddr = value;
            }
        }

        private System.String _JobDesc;
        [Browsable(true), DisplayName("JobDesc")]
        public System.String JobDesc
        {
            get
            {
                return _JobDesc;
            }
            set
            {
                if (PropertyChanged(_JobDesc, value))
                    _JobDesc = value;
            }
        }

        private System.String _Remark;
        [Browsable(true), DisplayName("Remark")]
        public System.String Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                if (PropertyChanged(_Remark, value))
                    _Remark = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _EmployerName, _LastDesigKey, _DateFrom.Value(StaticInfo.DateFormat), _DateTo.Value(StaticInfo.DateFormat), _EmployerAddr, _JobDesc, _Remark };
            else if (IsModified)
                parameterValues = new Object[] { _EmpEmployKey, _EmpKey, _EmployerName, _LastDesigKey, _DateFrom.Value(StaticInfo.DateFormat), _DateTo.Value(StaticInfo.DateFormat), _EmployerAddr, _JobDesc, _Remark };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpEmployKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EmpEmployKey = reader.GetInt64("EmpEmployKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmployerName = reader.GetString("EmployerName");
            _LastDesigKey = reader.GetString("LastDesigKey");
            _DateFrom = reader.GetDateTime("DateFrom");
            _DateTo = reader.GetDateTime("DateTo");
            _EmployerAddr = reader.GetString("EmployerAddr");
            _JobDesc = reader.GetString("JobDesc");
            _Remark = reader.GetString("Remark");
            SetUnchanged();
        }
        public static CustomList<HRM_EmpEmployment> GetAllHRM_EmpEmployment()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpEmployment> HRM_EmpEmploymentCollection = new CustomList<HRM_EmpEmployment>();
            IDataReader reader = null;
            const String sql = "select * from HRM_EmpEmployment";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpEmployment newHRM_EmpEmployment = new HRM_EmpEmployment();
                    newHRM_EmpEmployment.SetData(reader);
                    HRM_EmpEmploymentCollection.Add(newHRM_EmpEmployment);
                }
                HRM_EmpEmploymentCollection.InsertSpName = "spInsertHRM_EmpEmployment";
                HRM_EmpEmploymentCollection.UpdateSpName = "spUpdateHRM_EmpEmployment";
                HRM_EmpEmploymentCollection.DeleteSpName = "spDeleteHRM_EmpEmployment";
                return HRM_EmpEmploymentCollection;
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

        public static CustomList<HRM_EmpEmployment> GetAllEmpHistByEmpKey(string EmpKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpEmployment> HRM_EmpEmploymentCollection = new CustomList<HRM_EmpEmployment>();
            IDataReader reader = null;
            String sql = "select * from HRM_EmpEmployment where empkey = " + EmpKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpEmployment newHRM_EmpEmployment = new HRM_EmpEmployment();
                    newHRM_EmpEmployment.SetData(reader);
                    HRM_EmpEmploymentCollection.Add(newHRM_EmpEmployment);
                }
                HRM_EmpEmploymentCollection.InsertSpName = "spInsertHRM_EmpEmployment";
                HRM_EmpEmploymentCollection.UpdateSpName = "spUpdateHRM_EmpEmployment";
                HRM_EmpEmploymentCollection.DeleteSpName = "spDeleteHRM_EmpEmployment";
                return HRM_EmpEmploymentCollection;
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