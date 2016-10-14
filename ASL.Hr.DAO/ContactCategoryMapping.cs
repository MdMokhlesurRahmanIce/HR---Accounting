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
	public class ContactCategoryMapping : BaseItem
	{
		public ContactCategoryMapping()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _CategoryID;
		[Browsable(true), DisplayName("CategoryID")]
		public System.Int32 CategoryID 
		{
			get
			{
				return _CategoryID;
			}
			set
			{
			if (PropertyChanged(_CategoryID, value))
					_CategoryID = value;
			}
		}

		private System.Int32 _ContractID;
		[Browsable(true), DisplayName("ContractID")]
		public System.Int32 ContractID 
		{
			get
			{
				return _ContractID;
			}
			set
			{
			if (PropertyChanged(_ContractID, value))
					_ContractID = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_CategoryID,_ContractID};
			else if (IsModified)
				parameterValues = new Object[] {_CategoryID,_ContractID};
			else if (IsDeleted)
				parameterValues = new Object[] {_CategoryID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_CategoryID = reader.GetInt32("CategoryID");
			_ContractID = reader.GetInt32("ContractID");
			SetUnchanged();
		}
		public static CustomList<ContactCategoryMapping> GetAllContactCategoryMapping()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<ContactCategoryMapping> ContactCategoryMappingCollection = new CustomList<ContactCategoryMapping>();
			IDataReader reader = null;
			const String sql = "select *from ContactCategoryMapping";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					ContactCategoryMapping newContactCategoryMapping = new ContactCategoryMapping();
					newContactCategoryMapping.SetData(reader);
					ContactCategoryMappingCollection.Add(newContactCategoryMapping);
				}
				ContactCategoryMappingCollection.InsertSpName = "spInsertContactCategoryMapping";
				ContactCategoryMappingCollection.UpdateSpName = "spUpdateContactCategoryMapping";
				ContactCategoryMappingCollection.DeleteSpName = "spDeleteContactCategoryMapping";
				return ContactCategoryMappingCollection;
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
