using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC; 

namespace ASL.Security.DAO
{
	[Serializable]
	public class Company_Entity : BaseItem
	{
		public Company_Entity()
		{
			SetAdded();
		}
		
#region Properties
		[Browsable(true), DisplayName("CompanyID")]
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
		private System.String _CompanyID;
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
		private System.String _CompanyName;

        [Browsable(true), DisplayName("Company_Name")]
        public System.String Company_Name
        {
            get
            {
                return _Company_Name;
            }
            set
            {
                if (PropertyChanged(_Company_Name, value))
                    _Company_Name = value;
            }
        }
        private System.String _Company_Name;

		[Browsable(true), DisplayName("CompanyAddress")]
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
		private System.String _CompanyAddress;

        [Browsable(true), DisplayName("Company_Address")]
        public System.String Company_Address
        {
            get
            {
                return _Company_Address;
            }
            set
            {
                if (PropertyChanged(_Company_Address, value))
                    _Company_Address = value;
            }
        }
        private System.String _Company_Address;

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
		private System.String _AddedBy;
		[Browsable(true), DisplayName("DateAdded")]
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
		private System.DateTime _DateAdded;
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
		private System.String _UpdatedBy;
		[Browsable(true), DisplayName("DateUpdated")]
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
		private System.DateTime _DateUpdated;
		[Browsable(true), DisplayName("TinNo")]
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
		private System.String _TinNo;
		[Browsable(true), DisplayName("VatRegNo")]
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
		private System.String _VatRegNo;
		[Browsable(true), DisplayName("IRCNo")]
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
		private System.String _IRCNo;
		[Browsable(true), DisplayName("IRC_ExpiryDate")]
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
		private System.DateTime _IRC_ExpiryDate;
		[Browsable(true), DisplayName("BD_Bank_RegNo")]
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
		private System.String _BD_Bank_RegNo;
		[Browsable(true), DisplayName("EPBRegnNo")]
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
		private System.String _EPBRegnNo;
		[Browsable(true), DisplayName("CCIRegNo")]
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
		private System.String _CCIRegNo;
		[Browsable(true), DisplayName("CCIRegDate")]
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
		private System.DateTime _CCIRegDate;
		[Browsable(true), DisplayName("InventoryDB")]
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
		private System.String _InventoryDB;
		[Browsable(true), DisplayName("OTSDB")]
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
		private System.String _OTSDB;
		[Browsable(true), DisplayName("HRM5DB")]
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
		private System.String _HRM5DB;
		[Browsable(true), DisplayName("FabricControlDB")]
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
		private System.String _FabricControlDB;
		[Browsable(true), DisplayName("FAMDB")]
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
		private System.String _FAMDB;
		[Browsable(true), DisplayName("SysManDB")]
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
		private System.String _SysManDB;
		[Browsable(true), DisplayName("WashingWrinkleFreeDB")]
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
		private System.String _WashingWrinkleFreeDB;
		[Browsable(true), DisplayName("ACCTDB")]
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
		private System.String _ACCTDB;
		[Browsable(true), DisplayName("IsDefault")]
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
		private System.Boolean _IsDefault;
		[Browsable(true), DisplayName("ProductionDB")]
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
		private System.String _ProductionDB;
		[Browsable(true), DisplayName("GSDDB")]
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
		private System.String _GSDDB;
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_CompanyID,_CompanyName,_CompanyAddress,_AddedBy,_DateAdded.Value(StaticInfo.DateFormat),_UpdatedBy,_DateUpdated.Value(StaticInfo.DateFormat),_TinNo,_VatRegNo,_IRCNo,_IRC_ExpiryDate.Value(StaticInfo.DateFormat),_BD_Bank_RegNo,_EPBRegnNo,_CCIRegNo,_CCIRegDate.Value(StaticInfo.DateFormat),_InventoryDB,_OTSDB,_HRM5DB,_FabricControlDB,_FAMDB,_SysManDB,_WashingWrinkleFreeDB,_ACCTDB,_IsDefault,_ProductionDB,_GSDDB};
			else if (IsModified)
				parameterValues = new Object[] {_CompanyID,_CompanyName,_CompanyAddress,_AddedBy,_DateAdded.Value(StaticInfo.DateFormat),_UpdatedBy,_DateUpdated.Value(StaticInfo.DateFormat),_TinNo,_VatRegNo,_IRCNo,_IRC_ExpiryDate.Value(StaticInfo.DateFormat),_BD_Bank_RegNo,_EPBRegnNo,_CCIRegNo,_CCIRegDate.Value(StaticInfo.DateFormat),_InventoryDB,_OTSDB,_HRM5DB,_FabricControlDB,_FAMDB,_SysManDB,_WashingWrinkleFreeDB,_ACCTDB,_IsDefault,_ProductionDB,_GSDDB};
			else if (IsDeleted)
				parameterValues = new Object[] {_CompanyID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_CompanyID = reader.GetString("CompanyID");
			_Company_Name = reader.GetString("Company_Name");
			_Company_Address = reader.GetString("Company_Address");
			SetUnchanged();
		}
		public static CustomList<Company_Entity> GetAllCompany_Entity()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
			CustomList<Company_Entity> Company_EntityCollection = new CustomList<Company_Entity>();
			const String sql = "Select *from Company";
            IDataReader reader = null; ;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Company_Entity newCompany_Entity = new Company_Entity();
					newCompany_Entity.SetData(reader);
					Company_EntityCollection.Add(newCompany_Entity);
				}
				reader.Close();
				Company_EntityCollection.SelectSpName = "spSelectCompany_Entity";
				Company_EntityCollection.InsertSpName = "spInsertCompany_Entity";
				Company_EntityCollection.UpdateSpName = "spUpdateCompany_Entity";
				Company_EntityCollection.SelectSpName = "spDeleteCompany_Entity";
				return Company_EntityCollection;
			}
			catch(Exception ex)
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
