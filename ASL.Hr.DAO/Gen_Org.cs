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
    public class Gen_Org : BaseItem
    {
        public Gen_Org()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _OrgKey;
        [Browsable(true), DisplayName("OrgKey")]
        public System.Int32 OrgKey
        {
            get
            {
                return _OrgKey;
            }
            set
            {
                if (PropertyChanged(_OrgKey, value))
                    _OrgKey = value;
            }
        }

        private System.Int32 _OrgParentKey;
        [Browsable(true), DisplayName("OrgParentKey")]
        public System.Int32 OrgParentKey
        {
            get
            {
                return _OrgParentKey;
            }
            set
            {
                if (PropertyChanged(_OrgParentKey, value))
                    _OrgParentKey = value;
            }
        }

        private System.String _OrgName;
        [Browsable(true), DisplayName("OrgName")]
        public System.String OrgName
        {
            get
            {
                return _OrgName;
            }
            set
            {
                if (PropertyChanged(_OrgName, value))
                    _OrgName = value;
            }
        }

        private System.String _OrgCode;
        [Browsable(true), DisplayName("OrgCode")]
        public System.String OrgCode
        {
            get
            {
                return _OrgCode;
            }
            set
            {
                if (PropertyChanged(_OrgCode, value))
                    _OrgCode = value;
            }
        }

        private System.Int32 _OrgLevel;
        [Browsable(true), DisplayName("OrgLevel")]
        public System.Int32 OrgLevel
        {
            get
            {
                return _OrgLevel;
            }
            set
            {
                if (PropertyChanged(_OrgLevel, value))
                    _OrgLevel = value;
            }
        }

        private System.DateTime _EstDate;
        [Browsable(true), DisplayName("EstDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EstDate
        {
            get
            {
                return _EstDate;
            }
            set
            {
                if (PropertyChanged(_EstDate, value))
                    _EstDate = value;
            }
        }

        private System.String _OrgAddr;
        [Browsable(true), DisplayName("OrgAddr")]
        public System.String OrgAddr
        {
            get
            {
                return _OrgAddr;
            }
            set
            {
                if (PropertyChanged(_OrgAddr, value))
                    _OrgAddr = value;
            }
        }

        private System.String _OrgDesc;
        [Browsable(true), DisplayName("OrgDesc")]
        public System.String OrgDesc
        {
            get
            {
                return _OrgDesc;
            }
            set
            {
                if (PropertyChanged(_OrgDesc, value))
                    _OrgDesc = value;
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

        private System.String _T_Field1;
        [Browsable(true), DisplayName("T_Field1")]
        public System.String T_Field1
        {
            get
            {
                return _T_Field1;
            }
            set
            {
                if (PropertyChanged(_T_Field1, value))
                    _T_Field1 = value;
            }
        }

        private System.String _T_Field2;
        [Browsable(true), DisplayName("T_Field2")]
        public System.String T_Field2
        {
            get
            {
                return _T_Field2;
            }
            set
            {
                if (PropertyChanged(_T_Field2, value))
                    _T_Field2 = value;
            }
        }

        private System.String _D_Field1;
        [Browsable(true), DisplayName("D_Field1")]
        public System.String D_Field1
        {
            get
            {
                return _D_Field1;
            }
            set
            {
                if (PropertyChanged(_D_Field1, value))
                    _D_Field1 = value;
            }
        }

        private System.String _N_Field1;
        [Browsable(true), DisplayName("N_Field1")]
        public System.String N_Field1
        {
            get
            {
                return _N_Field1;
            }
            set
            {
                if (PropertyChanged(_N_Field1, value))
                    _N_Field1 = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _OrgParentKey, _OrgName, _OrgCode, _OrgLevel, _EstDate.Value(StaticInfo.DateFormat), _OrgAddr, _OrgDesc, _Remarks, _T_Field1, _T_Field2, _D_Field1, _N_Field1 };
            else if (IsModified)
                parameterValues = new Object[] { _OrgParentKey, _OrgName, _OrgCode, _OrgLevel, _EstDate.Value(StaticInfo.DateFormat), _OrgAddr, _OrgDesc, _Remarks, _T_Field1, _T_Field2, _D_Field1, _N_Field1 };
            else if (IsDeleted)
                parameterValues = new Object[] { _OrgKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _OrgKey = reader.GetInt32("OrgKey");
            _OrgParentKey = reader.GetInt32("OrgParentKey");
            _OrgName = reader.GetString("OrgName");
            _OrgCode = reader.GetString("OrgCode");
            _OrgLevel = reader.GetInt32("OrgLevel");
            _EstDate = reader.GetDateTime("EstDate");
            _OrgAddr = reader.GetString("OrgAddr");
            _OrgDesc = reader.GetString("OrgDesc");
            _Remarks = reader.GetString("Remarks");
            _T_Field1 = reader.GetString("T_Field1");
            _T_Field2 = reader.GetString("T_Field2");
            _D_Field1 = reader.GetString("D_Field1");
            _N_Field1 = reader.GetString("N_Field1");
            SetUnchanged();
        }
        public static CustomList<Gen_Org> GetAllGen_Org()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_Org> Gen_OrgCollection = new CustomList<Gen_Org>();
            IDataReader reader = null;
            const String sql = "Select * from Gen_Org";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_Org newGen_Org = new Gen_Org();
                    newGen_Org.SetData(reader);
                    Gen_OrgCollection.Add(newGen_Org);
                }
                Gen_OrgCollection.InsertSpName = "spInsertGen_Org";
                Gen_OrgCollection.UpdateSpName = "spUpdateGen_Org";
                Gen_OrgCollection.DeleteSpName = "spDeleteGen_Org";
                return Gen_OrgCollection;
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