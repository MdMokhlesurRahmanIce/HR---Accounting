using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ACC.DAO
{
	[Serializable]
	public class Gen_AccFY : BaseItem
	{
		public Gen_AccFY()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _FYKey;
		[Browsable(true), DisplayName("FYKey")]
		public System.Int32 FYKey 
		{
			get
			{
				return _FYKey;
			}
			set
			{
			if (PropertyChanged(_FYKey, value))
					_FYKey = value;
			}
		}

		private System.String _FYName;
		[Browsable(true), DisplayName("FYName")]
		public System.String FYName 
		{
			get
			{
				return _FYName;
			}
			set
			{
			if (PropertyChanged(_FYName, value))
					_FYName = value;
			}
		}

		private System.DateTime _SDate;
		[Browsable(true), DisplayName("SDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime SDate 
		{
			get
			{
				return _SDate;
			}
			set
			{
			if (PropertyChanged(_SDate, value))
					_SDate = value;
			}
		}

		private System.DateTime _EDate;
		[Browsable(true), DisplayName("EDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime EDate 
		{
			get
			{
				return _EDate;
			}
			set
			{
			if (PropertyChanged(_EDate, value))
					_EDate = value;
			}
		}

		private System.Boolean _IsActive;
		[Browsable(true), DisplayName("IsActive")]
		public System.Boolean IsActive 
		{
			get
			{
				return _IsActive;
			}
			set
			{
			if (PropertyChanged(_IsActive, value))
					_IsActive = value;
			}
		}

		private System.Int32 _YearEndType;
		[Browsable(true), DisplayName("YearEndType")]
		public System.Int32 YearEndType 
		{
			get
			{
				return _YearEndType;
			}
			set
			{
			if (PropertyChanged(_YearEndType, value))
					_YearEndType = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_FYName,_SDate.Value(StaticInfo.DateFormat),_EDate.Value(StaticInfo.DateFormat),_IsActive,_YearEndType};
			else if (IsModified)
				parameterValues = new Object[] {_FYKey, _FYName,_SDate.Value(StaticInfo.DateFormat),_EDate.Value(StaticInfo.DateFormat),_IsActive,_YearEndType};
			else if (IsDeleted)
				parameterValues = new Object[] {_FYKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_FYKey = reader.GetInt32("FYKey");
			_FYName = reader.GetString("FYName");
			_SDate = reader.GetDateTime("SDate");
			_EDate = reader.GetDateTime("EDate");
			_IsActive = reader.GetBoolean("IsActive");
			_YearEndType = reader.GetInt32("YearEndType");
			SetUnchanged();
		}
		public static CustomList<Gen_AccFY> GetAllGen_AccFY()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<Gen_AccFY> Gen_AccFYCollection = new CustomList<Gen_AccFY>();
			IDataReader reader = null;
			const String sql = "select *from Gen_AccFY order by FYKey Desc";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Gen_AccFY newGen_AccFY = new Gen_AccFY();
					newGen_AccFY.SetData(reader);
					Gen_AccFYCollection.Add(newGen_AccFY);
				}
				Gen_AccFYCollection.InsertSpName = "spInsertGen_AccFY";
				Gen_AccFYCollection.UpdateSpName = "spUpdateGen_AccFY";
				Gen_AccFYCollection.DeleteSpName = "spDeleteGen_AccFY";
				return Gen_AccFYCollection;
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
