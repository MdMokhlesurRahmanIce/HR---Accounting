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
    public class EmployeeEmergencyInfo : BaseItem
    {
        public EmployeeEmergencyInfo()
        {
            SetAdded();
        }

        #region Properties


        private System.Int64 _ID;
        [Browsable(true), DisplayName("ID")]
        public System.Int64 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (PropertyChanged(_ID, value))
                    _ID = value;
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

        private System.String _ContactPerson;
        [Browsable(true), DisplayName("ContactPerson")]
        public System.String ContactPerson
        {
            get
            {
                return _ContactPerson;
            }
            set
            {
                if (PropertyChanged(_ContactPerson, value))
                    _ContactPerson = value;
            }
        }

        private System.String _Address;
        [Browsable(true), DisplayName("Address")]
        public System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                if (PropertyChanged(_Address, value))
                    _Address = value;
            }
        }

        private System.String _CellNo;
        [Browsable(true), DisplayName("CellNo")]
        public System.String CellNo
        {
            get
            {
                return _CellNo;
            }
            set
            {
                if (PropertyChanged(_CellNo, value))
                    _CellNo = value;
            }
        }

        private System.String _LandPhone;
        [Browsable(true), DisplayName("LandPhone")]
        public System.String LandPhone
        {
            get
            {
                return _LandPhone;
            }
            set
            {
                if (PropertyChanged(_LandPhone, value))
                    _LandPhone = value;
            }
        }

        private System.String _Relation;
        [Browsable(true), DisplayName("Relation")]
        public System.String Relation
        {
            get
            {
                return _Relation;
            }
            set
            {
                if (PropertyChanged(_Relation, value))
                    _Relation = value;
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

        private System.String _AddedDate;
        [Browsable(true), DisplayName("AddedDate")]
        public System.String AddedDate
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _ContactPerson, _Address, _CellNo, _LandPhone, _Relation, _AddedBy, _AddedDate, _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
            else if (IsModified)
                parameterValues = new Object[] { _ID, _EmpKey, _ContactPerson, _Address, _CellNo, _LandPhone, _Relation, _AddedBy, _AddedDate, _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
            else if (IsDeleted)
                parameterValues = new Object[] { _ID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ID = reader.GetInt64("ID");
            _EmpKey = reader.GetInt64("EmpKey");
            _ContactPerson = reader.GetString("ContactPerson");
            _Address = reader.GetString("Address");
            _CellNo = reader.GetString("CellNo");
            _LandPhone = reader.GetString("LandPhone");
            _Relation = reader.GetString("Relation");
            _AddedBy = reader.GetString("AddedBy");
            _AddedDate = reader.GetString("AddedDate");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _UpdatedDate = reader.GetDateTime("UpdatedDate");
            SetUnchanged();
        }
        public static CustomList<EmployeeEmergencyInfo> GetAllEmployeeEmergencyInfo()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<EmployeeEmergencyInfo> EmployeeEmergencyInfoCollection = new CustomList<EmployeeEmergencyInfo>();
            IDataReader reader = null;
            const String sql = "select * from EmployeeEmergencyInfo";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    EmployeeEmergencyInfo newEmployeeEmergencyInfo = new EmployeeEmergencyInfo();
                    newEmployeeEmergencyInfo.SetData(reader);
                    EmployeeEmergencyInfoCollection.Add(newEmployeeEmergencyInfo);
                }
                EmployeeEmergencyInfoCollection.InsertSpName = "spInsertEmployeeEmergencyInfo";
                EmployeeEmergencyInfoCollection.UpdateSpName = "spUpdateEmployeeEmergencyInfo";
                EmployeeEmergencyInfoCollection.DeleteSpName = "spDeleteEmployeeEmergencyInfo";
                return EmployeeEmergencyInfoCollection;
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
        public static CustomList<EmployeeEmergencyInfo> GetAllEmployeeEmergencyInfo(long EmpKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<EmployeeEmergencyInfo> EmployeeEmergencyInfoCollection = new CustomList<EmployeeEmergencyInfo>();
            IDataReader reader = null;
            String sql = string.Format("select * from EmployeeEmergencyInfo Where EmpKey='" + EmpKey + "'");
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    EmployeeEmergencyInfo newEmployeeEmergencyInfo = new EmployeeEmergencyInfo();
                    newEmployeeEmergencyInfo.SetData(reader);
                    EmployeeEmergencyInfoCollection.Add(newEmployeeEmergencyInfo);
                }
                EmployeeEmergencyInfoCollection.InsertSpName = "spInsertEmployeeEmergencyInfo";
                EmployeeEmergencyInfoCollection.UpdateSpName = "spUpdateEmployeeEmergencyInfo";
                EmployeeEmergencyInfoCollection.DeleteSpName = "spDeleteEmployeeEmergencyInfo";
                return EmployeeEmergencyInfoCollection;
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