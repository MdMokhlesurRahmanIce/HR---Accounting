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
	public class ContactCategory : BaseItem
	{
		public ContactCategory()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _ID;
		[Browsable(true), DisplayName("ID")]
		public System.Int32 ID 
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

		private System.String _Name;
		[Browsable(true), DisplayName("Name")]
		public System.String Name 
		{
			get
			{
				return _Name;
			}
			set
			{
			if (PropertyChanged(_Name, value))
					_Name = value;
			}
		}

        private System.Boolean _IsChecked;
        [Browsable(true), DisplayName("IsChecked")]
        public System.Boolean IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                if (PropertyChanged(_IsChecked, value))
                    _IsChecked = value;
            }
        }
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_Name};
			else if (IsModified)
				parameterValues = new Object[] {_Name};
			else if (IsDeleted)
				parameterValues = new Object[] {_ID,_Name};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_ID = reader.GetInt32("ID");
			_Name = reader.GetString("Name");
			SetUnchanged();
		}
		public static CustomList<ContactCategory> GetAllContactCategory()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
			CustomList<ContactCategory> ContactCategoryCollection = new CustomList<ContactCategory>();
			IDataReader reader = null;
			const String sql = "select *from ContactCategory";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					ContactCategory newContactCategory = new ContactCategory();
					newContactCategory.SetData(reader);
					ContactCategoryCollection.Add(newContactCategory);
				}
				ContactCategoryCollection.InsertSpName = "spInsertContactCategory";
				ContactCategoryCollection.UpdateSpName = "spUpdateContactCategory";
				ContactCategoryCollection.DeleteSpName = "spDeleteContactCategory";
				return ContactCategoryCollection;
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