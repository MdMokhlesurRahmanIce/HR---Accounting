using System;
using System.Collections.Generic;
using System.Data;
using ASL.DAL;
using ASL.DATA;

namespace ASL.STATIC
{
    [Serializable]
    public class CompanyEntity : BaseItem
    {
        public CompanyEntity()
        {
            SetAdded();
        }

        #region Properties
        public System.String CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                if (PropertyChanged(_CompanyID, value))
                    _CompanyID = value;
            }
        }
        private String _CompanyID;
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
        private String _CompanyName;
        public System.String CompanyAddress
        {
            get
            {
                return _CompanyAddress;
            }
            set
            {
                if (PropertyChanged(_CompanyAddress, value))
                    _CompanyAddress = value;
            }
        }
        private String _CompanyAddress;
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
        private String _AddedBy;
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
        private DateTime _DateAdded;
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
        private String _UpdatedBy;
        public System.DateTime DateUpdated
        {
            get
            {
                return _DateUpdated;
            }
            set
            {
                if (PropertyChanged(_DateUpdated, value))
                    _DateUpdated = value;
            }
        }
        private DateTime _DateUpdated;
        public System.String TinNo
        {
            get
            {
                return _TinNo;
            }
            set
            {
                if (PropertyChanged(_TinNo, value))
                    _TinNo = value;
            }
        }
        private String _TinNo;
        public System.String VatRegNo
        {
            get
            {
                return _VatRegNo;
            }
            set
            {
                if (PropertyChanged(_VatRegNo, value))
                    _VatRegNo = value;
            }
        }
        private String _VatRegNo;
        public System.String IRCNo
        {
            get
            {
                return _IRCNo;
            }
            set
            {
                if (PropertyChanged(_IRCNo, value))
                    _IRCNo = value;
            }
        }
        private String _IRCNo;
        public System.DateTime IRC_ExpiryDate
        {
            get
            {
                return _IRC_ExpiryDate;
            }
            set
            {
                if (PropertyChanged(_IRC_ExpiryDate, value))
                    _IRC_ExpiryDate = value;
            }
        }
        private DateTime _IRC_ExpiryDate;
        public System.String BD_Bank_RegNo
        {
            get
            {
                return _BD_Bank_RegNo;
            }
            set
            {
                if (PropertyChanged(_BD_Bank_RegNo, value))
                    _BD_Bank_RegNo = value;
            }
        }
        private String _BD_Bank_RegNo;
        public System.String EPBRegnNo
        {
            get
            {
                return _EPBRegnNo;
            }
            set
            {
                if (PropertyChanged(_EPBRegnNo, value))
                    _EPBRegnNo = value;
            }
        }
        private String _EPBRegnNo;
        public System.String CCIRegNo
        {
            get
            {
                return _CCIRegNo;
            }
            set
            {
                if (PropertyChanged(_CCIRegNo, value))
                    _CCIRegNo = value;
            }
        }
        private String _CCIRegNo;
        public System.DateTime CCIRegDate
        {
            get
            {
                return _CCIRegDate;
            }
            set
            {
                if (PropertyChanged(_CCIRegDate, value))
                    _CCIRegDate = value;
            }
        }
        private DateTime _CCIRegDate;
        public System.String InventoryDB
        {
            get
            {
                return _InventoryDB;
            }
            set
            {
                if (PropertyChanged(_InventoryDB, value))
                    _InventoryDB = value;
            }
        }
        private String _InventoryDB;
        public System.String OTSDB
        {
            get
            {
                return _OTSDB;
            }
            set
            {
                if (PropertyChanged(_OTSDB, value))
                    _OTSDB = value;
            }
        }
        private String _OTSDB;
        public System.String HRM5DB
        {
            get
            {
                return _HRM5DB;
            }
            set
            {
                if (PropertyChanged(_HRM5DB, value))
                    _HRM5DB = value;
            }
        }
        private String _HRM5DB;
        public System.String FabricControlDB
        {
            get
            {
                return _FabricControlDB;
            }
            set
            {
                if (PropertyChanged(_FabricControlDB, value))
                    _FabricControlDB = value;
            }
        }
        private String _FabricControlDB;
        public System.String FAMDB
        {
            get
            {
                return _FAMDB;
            }
            set
            {
                if (PropertyChanged(_FAMDB, value))
                    _FAMDB = value;
            }
        }
        private String _FAMDB;
        public System.String SysManDB
        {
            get
            {
                return _SysManDB;
            }
            set
            {
                if (PropertyChanged(_SysManDB, value))
                    _SysManDB = value;
            }
        }
        private String _SysManDB;
        public System.String WashingWrinkleFreeDB
        {
            get
            {
                return _WashingWrinkleFreeDB;
            }
            set
            {
                if (PropertyChanged(_WashingWrinkleFreeDB, value))
                    _WashingWrinkleFreeDB = value;
            }
        }
        private String _WashingWrinkleFreeDB;
        public System.String ACCTDB
        {
            get
            {
                return _ACCTDB;
            }
            set
            {
                if (PropertyChanged(_ACCTDB, value))
                    _ACCTDB = value;
            }
        }
        private String _ACCTDB;
        public System.Boolean IsDefault
        {
            get
            {
                return _IsDefault;
            }
            set
            {
                if (PropertyChanged(_IsDefault, value))
                    _IsDefault = value;
            }
        }
        private Boolean _IsDefault;
        public System.String ProductionDB
        {
            get
            {
                return _ProductionDB;
            }
            set
            {
                if (PropertyChanged(_ProductionDB, value))
                    _ProductionDB = value;
            }
        }
        private String _ProductionDB;
        public System.String GSDDB
        {
            get
            {
                return _GSDDB;
            }
            set
            {
                if (PropertyChanged(_GSDDB, value))
                    _GSDDB = value;
            }
        }
        private String _GSDDB;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _CompanyID, _CompanyName, _CompanyAddress, _AddedBy, _DateAdded.Value(StaticInfo.DateTimeFormat), _UpdatedBy, _DateUpdated.Value(StaticInfo.DateTimeFormat), _TinNo, _VatRegNo, _IRCNo, _IRC_ExpiryDate.Value(StaticInfo.DateFormat), _BD_Bank_RegNo, _EPBRegnNo, _CCIRegNo, _CCIRegDate.Value(StaticInfo.DateFormat), _InventoryDB, _OTSDB, _HRM5DB, _FabricControlDB, _FAMDB, _SysManDB, _WashingWrinkleFreeDB, _ACCTDB, _IsDefault, _ProductionDB, _GSDDB };
            else if (IsModified)
                parameterValues = new Object[] { _CompanyID, _CompanyName, _CompanyAddress, _AddedBy, _DateAdded.Value(StaticInfo.DateTimeFormat), _UpdatedBy, _DateUpdated.Value(StaticInfo.DateTimeFormat), _TinNo, _VatRegNo, _IRCNo, _IRC_ExpiryDate.Value(StaticInfo.DateFormat), _BD_Bank_RegNo, _EPBRegnNo, _CCIRegNo, _CCIRegDate.Value(StaticInfo.DateFormat), _InventoryDB, _OTSDB, _HRM5DB, _FabricControlDB, _FAMDB, _SysManDB, _WashingWrinkleFreeDB, _ACCTDB, _IsDefault, _ProductionDB, _GSDDB };
            else if (IsDeleted)
                parameterValues = new Object[] { _CompanyID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _CompanyID = reader.GetString("CompanyID");
            _CompanyName = reader.GetString("CompanyName");
            _CompanyAddress = reader.GetString("CompanyAddress");
            _AddedBy = reader.GetString("AddedBy");
            _DateAdded = reader.GetDateTime("DateAdded");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            _TinNo = reader.GetString("TinNo");
            _VatRegNo = reader.GetString("VatRegNo");
            _IRCNo = reader.GetString("IRCNo");
            _IRC_ExpiryDate = reader.GetDateTime("IRC_ExpiryDate");
            _BD_Bank_RegNo = reader.GetString("BD_Bank_RegNo");
            _EPBRegnNo = reader.GetString("EPBRegnNo");
            _CCIRegNo = reader.GetString("CCIRegNo");
            _CCIRegDate = reader.GetDateTime("CCIRegDate");
            _InventoryDB = reader.GetString("InventoryDB");
            _OTSDB = reader.GetString("OTSDB");
            _HRM5DB = reader.GetString("HRM5DB");
            _FabricControlDB = reader.GetString("FabricControlDB");
            _FAMDB = reader.GetString("FAMDB");
            _SysManDB = reader.GetString("SysManDB");
            _WashingWrinkleFreeDB = reader.GetString("WashingWrinkleFreeDB");
            _ACCTDB = reader.GetString("ACCTDB");
            _IsDefault = reader.GetBoolean("IsDefault");
            _ProductionDB = reader.GetString("ProductionDB");
            _GSDDB = reader.GetString("GSDDB");
            SetUnchanged();

            if (_IsDefault)
                StaticInfo.CurrentCompany = this;
        }
        public static CustomList<CompanyEntity> GetAllCompanyEntity()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<CompanyEntity> companyEntityCollection = new CustomList<CompanyEntity>();
            IDataReader reader = null;
            const String sql = "Select * From Company_Entity";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CompanyEntity newCompanyEntity = new CompanyEntity();
                    newCompanyEntity.SetData(reader);
                    companyEntityCollection.Add(newCompanyEntity);
                }
                return companyEntityCollection;
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

        public static CustomList<CompanyEntity> GetAllCompanyEntityWithBlankRecode()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<CompanyEntity> companyEntityCollection = new CustomList<CompanyEntity>();
            IDataReader reader = null;
            const String sql = "Select * From Company_Entity";
            AddBlankRecord(companyEntityCollection);
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CompanyEntity newCompanyEntity = new CompanyEntity();
                    newCompanyEntity.SetData(reader);
                    companyEntityCollection.Add(newCompanyEntity);
                }
                reader.Close();
                return companyEntityCollection;
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

        private static void AddBlankRecord(CustomList<CompanyEntity> companyEntityCollection)
        {
            CompanyEntity newCompanyEntityCollection = new CompanyEntity();
            newCompanyEntityCollection._CompanyID = String.Empty;
            companyEntityCollection.Add(newCompanyEntityCollection);
        }

    }
}