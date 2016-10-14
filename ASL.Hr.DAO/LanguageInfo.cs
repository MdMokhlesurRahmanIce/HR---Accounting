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
	public class LanguageInfo : BaseItem
	{
		public LanguageInfo()
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

		private System.String _LanguageName;
		[Browsable(true), DisplayName("LanguageName")]
		public System.String LanguageName 
		{
			get
			{
				return _LanguageName;
			}
			set
			{
			if (PropertyChanged(_LanguageName, value))
					_LanguageName = value;
			}
		}

		private System.String _Writing;
		[Browsable(true), DisplayName("Writing")]
		public System.String Writing 
		{
			get
			{
				return _Writing;
			}
			set
			{
			if (PropertyChanged(_Writing, value))
					_Writing = value;
			}
		}

		private System.String _Reading;
		[Browsable(true), DisplayName("Reading")]
		public System.String Reading 
		{
			get
			{
				return _Reading;
			}
			set
			{
			if (PropertyChanged(_Reading, value))
					_Reading = value;
			}
		}

		private System.String _Spoken;
		[Browsable(true), DisplayName("Spoken")]
		public System.String Spoken 
		{
			get
			{
				return _Spoken;
			}
			set
			{
			if (PropertyChanged(_Spoken, value))
					_Spoken = value;
			}
		}

		private System.Boolean _MotherLanguage;
		[Browsable(true), DisplayName("MotherLanguage")]
		public System.Boolean MotherLanguage 
		{
			get
			{
				return _MotherLanguage;
			}
			set
			{
			if (PropertyChanged(_MotherLanguage, value))
					_MotherLanguage = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpKey,_LanguageName,_Writing,_Reading,_Spoken,_MotherLanguage};
			else if (IsModified)
				parameterValues = new Object[] {_ID,_EmpKey,_LanguageName,_Writing,_Reading,_Spoken,_MotherLanguage};
			else if (IsDeleted)
				parameterValues = new Object[] {_ID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_ID = reader.GetInt64("ID");
			_EmpKey = reader.GetInt64("EmpKey");
			_LanguageName = reader.GetString("LanguageName");
			_Writing = reader.GetString("Writing");
			_Reading = reader.GetString("Reading");
			_Spoken = reader.GetString("Spoken");
			_MotherLanguage = reader.GetBoolean("MotherLanguage");
			SetUnchanged();
		}
		public static CustomList<LanguageInfo> GetAllLanguageInfo(long empKey)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<LanguageInfo> LanguageInfoCollection = new CustomList<LanguageInfo>();
			IDataReader reader = null;
            String sql = "select *from LanguageInfo where EmpKey=" + empKey;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					LanguageInfo newLanguageInfo = new LanguageInfo();
					newLanguageInfo.SetData(reader);
					LanguageInfoCollection.Add(newLanguageInfo);
				}
				LanguageInfoCollection.InsertSpName = "spInsertLanguageInfo";
				LanguageInfoCollection.UpdateSpName = "spUpdateLanguageInfo";
				LanguageInfoCollection.DeleteSpName = "spDeleteLanguageInfo";
				return LanguageInfoCollection;
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