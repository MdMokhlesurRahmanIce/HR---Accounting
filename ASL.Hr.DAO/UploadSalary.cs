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
	public class UploadSalary : BaseItem
	{
		public UploadSalary()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _MiscSalaryKey;
		[Browsable(true), DisplayName("MiscSalaryKey")]
		public System.Int32 MiscSalaryKey 
		{
			get
			{
				return _MiscSalaryKey;
			}
			set
			{
			if (PropertyChanged(_MiscSalaryKey, value))
					_MiscSalaryKey = value;
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

		private System.Int32 _SalaryHeadKey;
		[Browsable(true), DisplayName("SalaryHeadKey")]
		public System.Int32 SalaryHeadKey 
		{
			get
			{
				return _SalaryHeadKey;
			}
			set
			{
			if (PropertyChanged(_SalaryHeadKey, value))
					_SalaryHeadKey = value;
			}
		}

		private System.Decimal _Amount;
		[Browsable(true), DisplayName("Amount")]
		public System.Decimal Amount 
		{
			get
			{
				return _Amount;
			}
			set
			{
			if (PropertyChanged(_Amount, value))
					_Amount = value;
			}
		}

		private System.Int64 _SalaryProcKey;
		[Browsable(true), DisplayName("SalaryProcKey")]
		public System.Int64 SalaryProcKey 
		{
			get
			{
				return _SalaryProcKey;
			}
			set
			{
			if (PropertyChanged(_SalaryProcKey, value))
					_SalaryProcKey = value;
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

		private System.String _AddedBy;
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

		private System.DateTime _DateAdded;
		[Browsable(true), DisplayName("DateAdded"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
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

		private System.String _UpdatedBy;
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

		private System.DateTime _DateUpdated;
		[Browsable(true), DisplayName("DateUpdated"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
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

		private System.Int32 _MonthNo;
		[Browsable(true), DisplayName("MonthNo")]
		public System.Int32 MonthNo 
		{
			get
			{
				return _MonthNo;
			}
			set
			{
			if (PropertyChanged(_MonthNo, value))
					_MonthNo = value;
			}
		}

		private System.Int32 _YearNo;
		[Browsable(true), DisplayName("YearNo")]
		public System.Int32 YearNo 
		{
			get
			{
				return _YearNo;
			}
			set
			{
			if (PropertyChanged(_YearNo, value))
					_YearNo = value;
			}
		}

		private System.DateTime _FromDate;
		[Browsable(true), DisplayName("FromDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime FromDate 
		{
			get
			{
				return _FromDate;
			}
			set
			{
			if (PropertyChanged(_FromDate, value))
					_FromDate = value;
			}
		}

		private System.DateTime _ToDate;
		[Browsable(true), DisplayName("ToDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime ToDate 
		{
			get
			{
				return _ToDate;
			}
			set
			{
			if (PropertyChanged(_ToDate, value))
					_ToDate = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpKey,_SalaryHeadKey,_Amount,_SalaryProcKey,_Remarks,_AddedBy,_DateAdded.Value(StaticInfo.DateFormat),_UpdatedBy,_DateUpdated.Value(StaticInfo.DateFormat),_MonthNo,_YearNo,_FromDate.Value(StaticInfo.DateFormat),_ToDate.Value(StaticInfo.DateFormat)};
			else if (IsModified)
				parameterValues = new Object[] {_EmpKey,_SalaryHeadKey,_Amount,_SalaryProcKey,_Remarks,_AddedBy,_DateAdded.Value(StaticInfo.DateFormat),_UpdatedBy,_DateUpdated.Value(StaticInfo.DateFormat),_MonthNo,_YearNo,_FromDate.Value(StaticInfo.DateFormat),_ToDate.Value(StaticInfo.DateFormat)};
			else if (IsDeleted)
				parameterValues = new Object[] {_MiscSalaryKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_MiscSalaryKey = reader.GetInt32("MiscSalaryKey");
			_EmpKey = reader.GetInt64("EmpKey");
			_SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
			_Amount = reader.GetDecimal("Amount");
			_SalaryProcKey = reader.GetInt64("SalaryProcKey");
			_Remarks = reader.GetString("Remarks");
			_AddedBy = reader.GetString("AddedBy");
			_DateAdded = reader.GetDateTime("DateAdded");
			_UpdatedBy = reader.GetString("UpdatedBy");
			_DateUpdated = reader.GetDateTime("DateUpdated");
			_MonthNo = reader.GetInt32("MonthNo");
			_YearNo = reader.GetInt32("YearNo");
			_FromDate = reader.GetDateTime("FromDate");
			_ToDate = reader.GetDateTime("ToDate");
			SetUnchanged();
		}
		public static CustomList<UploadSalary> GetAllUploadSalary()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<UploadSalary> UploadSalaryCollection = new CustomList<UploadSalary>();
			IDataReader reader = null;
			const String sql = "select *from UploadSalary";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					UploadSalary newUploadSalary = new UploadSalary();
					newUploadSalary.SetData(reader);
					UploadSalaryCollection.Add(newUploadSalary);
				}
				UploadSalaryCollection.InsertSpName = "spInsertUploadSalary";
				UploadSalaryCollection.UpdateSpName = "spUpdateUploadSalary";
				UploadSalaryCollection.DeleteSpName = "spDeleteUploadSalary";
				return UploadSalaryCollection;
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