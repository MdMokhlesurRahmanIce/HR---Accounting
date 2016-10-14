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
    public class Organization : BaseItem
    {
        public Organization()
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

        private System.String _CompanyName;
        [Browsable(true), DisplayName("CompanyName")]
        public System.String CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                if (PropertyChanged(_CompanyName, value))
                    _CompanyName = value;
            }
        }

        private System.String _BranchName;
        [Browsable(true), DisplayName("BranchName")]
        public System.String BranchName
        {
            get
            {
                return _BranchName;
            }
            set
            {
                if (PropertyChanged(_BranchName, value))
                    _BranchName = value;
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
                parameterValues = new Object[] { _OrgKey, _OrgParentKey, _OrgName, _OrgCode, _OrgLevel, _EstDate.Value(StaticInfo.DateFormat), _OrgAddr, _OrgDesc, _Remarks, _T_Field1, _T_Field2, _D_Field1, _N_Field1 };
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
            _CompanyName = reader.GetString("CompanyName");
            _BranchName = reader.GetString("BranchName");
            SetUnchanged();
        }

        private void SetDataByOrgID(IDataRecord reader)
        {
            _OrgKey = reader.GetInt32("OrgKey");
            _OrgName = reader.GetString("OrgName");

            SetUnchanged();
        }

        public static CustomList<Organization> GetAllOrganization(int codeLen)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Organization> OrganizationCollection = new CustomList<Organization>();
            IDataReader reader = null;
            String sql = "select CompanyName=Left(OrgCode,2),BranchName=Left(OrgCode,4),* from Gen_Org where LEN(OrgCode)=" + codeLen;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Organization newOrganization = new Organization();
                    newOrganization.SetData(reader);
                    OrganizationCollection.Add(newOrganization);
                }
                OrganizationCollection.InsertSpName = "spInsertGen_Org";
                OrganizationCollection.UpdateSpName = "spUpdateGen_Org";
                OrganizationCollection.DeleteSpName = "spDeleteGen_Org";
                return OrganizationCollection;
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
        public static CustomList<Organization> GetAllOrganizationById(int orgKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Organization> OrganizationCollection = new CustomList<Organization>();
            IDataReader reader = null;
            String sql = "select OrgKey,OrgName from Gen_Org where OrgParentKey=" + orgKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Organization newOrganization = new Organization();
                    newOrganization.SetDataByOrgID(reader);
                    OrganizationCollection.Add(newOrganization);
                }
                return OrganizationCollection;
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
        public static CustomList<Organization> GetAllOrg()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Organization> OrganizationCollection = new CustomList<Organization>();
            IDataReader reader = null;
            String sql = "select CompanyName=Left(OrgCode,2),BranchName=Left(OrgCode,4), * from Gen_Org ";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Organization newOrganization = new Organization();
                    newOrganization.SetData(reader);
                    OrganizationCollection.Add(newOrganization);
                }
                OrganizationCollection.InsertSpName = "spInsertGen_Org";
                OrganizationCollection.UpdateSpName = "spUpdateGen_Org";
                OrganizationCollection.DeleteSpName = "spDeleteGen_Org";
                return OrganizationCollection;
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
