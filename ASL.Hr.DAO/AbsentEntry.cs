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
	public class AbsentEntry : BaseItem
	{
		public AbsentEntry()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int64 _RecordID;
		[Browsable(true), DisplayName("RecordID")]
		public System.Int64 RecordID 
		{
			get
			{
				return _RecordID;
			}
			set
			{
			if (PropertyChanged(_RecordID, value))
					_RecordID = value;
			}
		}

		private System.Int64 _EmpID;
		[Browsable(true), DisplayName("EmpID")]
		public System.Int64 EmpID 
		{
			get
			{
				return _EmpID;
			}
			set
			{
			if (PropertyChanged(_EmpID, value))
					_EmpID = value;
			}
		}

		private System.DateTime _AbsentDate;
		[Browsable(true), DisplayName("AbsentDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime AbsentDate 
		{
			get
			{
				return _AbsentDate;
			}
			set
			{
			if (PropertyChanged(_AbsentDate, value))
					_AbsentDate = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpID,_AbsentDate.Value(StaticInfo.DateFormat)};
			else if (IsModified)
				parameterValues = new Object[] {_EmpID,_AbsentDate.Value(StaticInfo.DateFormat)};
			else if (IsDeleted)
				parameterValues = new Object[] {_EmpID,_AbsentDate.Value(StaticInfo.DateFormat)};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_RecordID = reader.GetInt64("RecordID");
			_EmpID = reader.GetInt64("EmpID");
			_AbsentDate = reader.GetDateTime("AbsentDate");
			SetUnchanged();
		}
		public static CustomList<AbsentEntry> GetAllAbsentEntry()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<AbsentEntry> AbsentEntryCollection = new CustomList<AbsentEntry>();
			IDataReader reader = null;
			const String sql = "select *from AbsentEntry";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					AbsentEntry newAbsentEntry = new AbsentEntry();
					newAbsentEntry.SetData(reader);
					AbsentEntryCollection.Add(newAbsentEntry);
				}
				AbsentEntryCollection.InsertSpName = "spInsertAbsentEntry";
				AbsentEntryCollection.UpdateSpName = "spUpdateAbsentEntry";
				AbsentEntryCollection.DeleteSpName = "spDeleteAbsentEntry";
				return AbsentEntryCollection;
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
