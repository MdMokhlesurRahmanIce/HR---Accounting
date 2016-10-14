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
	public class ContactSubCategoryMapping : BaseItem
	{
		public ContactSubCategoryMapping()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _SubCategoryID;
		[Browsable(true), DisplayName("SubCategoryID")]
		public System.Int32 SubCategoryID 
		{
			get
			{
				return _SubCategoryID;
			}
			set
			{
			if (PropertyChanged(_SubCategoryID, value))
					_SubCategoryID = value;
			}
		}

		private System.Int32 _ContactID;
		[Browsable(true), DisplayName("ContactID")]
		public System.Int32 ContactID 
		{
			get
			{
				return _ContactID;
			}
			set
			{
			if (PropertyChanged(_ContactID, value))
					_ContactID = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_SubCategoryID,_ContactID};
			else if (IsModified)
				parameterValues = new Object[] {_SubCategoryID,_ContactID};
			else if (IsDeleted)
				parameterValues = new Object[] {_SubCategoryID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_SubCategoryID = reader.GetInt32("SubCategoryID");
			_ContactID = reader.GetInt32("ContactID");
			SetUnchanged();
		}
		public static CustomList<ContactSubCategoryMapping> GetAllContactSubCategoryMapping()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<ContactSubCategoryMapping> ContactSubCategoryMappingCollection = new CustomList<ContactSubCategoryMapping>();
			IDataReader reader = null;
			const String sql = "select *from ContactSubCategoryMapping";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					ContactSubCategoryMapping newContactSubCategoryMapping = new ContactSubCategoryMapping();
					newContactSubCategoryMapping.SetData(reader);
					ContactSubCategoryMappingCollection.Add(newContactSubCategoryMapping);
				}
				ContactSubCategoryMappingCollection.InsertSpName = "spInsertContactSubCategoryMapping";
				ContactSubCategoryMappingCollection.UpdateSpName = "spUpdateContactSubCategoryMapping";
				ContactSubCategoryMappingCollection.DeleteSpName = "spDeleteContactSubCategoryMapping";
				return ContactSubCategoryMappingCollection;
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
