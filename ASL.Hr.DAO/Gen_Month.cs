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
	public class Gen_Month : BaseItem
	{
		public Gen_Month()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _MonthKey;
		[Browsable(true), DisplayName("MonthKey")]
		public System.Int32 MonthKey 
		{
			get
			{
				return _MonthKey;
			}
			set
			{
			if (PropertyChanged(_MonthKey, value))
					_MonthKey = value;
			}
		}

		private System.String _MonthName;
		[Browsable(true), DisplayName("MonthName")]
		public System.String MonthName 
		{
			get
			{
				return _MonthName;
			}
			set
			{
			if (PropertyChanged(_MonthName, value))
					_MonthName = value;
			}
		}

		private System.String _MonthSName;
		[Browsable(true), DisplayName("MonthSName")]
		public System.String MonthSName 
		{
			get
			{
				return _MonthSName;
			}
			set
			{
			if (PropertyChanged(_MonthSName, value))
					_MonthSName = value;
			}
		}

		private System.Int32 _Seq;
		[Browsable(true), DisplayName("Seq")]
		public System.Int32 Seq 
		{
			get
			{
				return _Seq;
			}
			set
			{
			if (PropertyChanged(_Seq, value))
					_Seq = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_MonthName,_MonthSName,_Seq};
			else if (IsModified)
				parameterValues = new Object[] {_MonthName,_MonthSName,_Seq};
			else if (IsDeleted)
				parameterValues = new Object[] {_MonthKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_MonthKey = reader.GetInt32("MonthKey");
			_MonthName = reader.GetString("MonthName");
			_MonthSName = reader.GetString("MonthSName");
			_Seq = reader.GetInt32("Seq");
			SetUnchanged();
		}
		public static CustomList<Gen_Month> GetAllGen_Month()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<Gen_Month> Gen_MonthCollection = new CustomList<Gen_Month>();
			IDataReader reader = null;
			const String sql = "Select *from Gen_Month";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Gen_Month newGen_Month = new Gen_Month();
					newGen_Month.SetData(reader);
					Gen_MonthCollection.Add(newGen_Month);
				}
				Gen_MonthCollection.InsertSpName = "spInsertGen_Month";
				Gen_MonthCollection.UpdateSpName = "spUpdateGen_Month";
				Gen_MonthCollection.DeleteSpName = "spDeleteGen_Month";
				return Gen_MonthCollection;
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
