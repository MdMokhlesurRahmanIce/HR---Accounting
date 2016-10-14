using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace  ASL.Hr.DAO
{
	[Serializable]
	public class EmployeeSalary : BaseItem
	{
		public EmployeeSalary()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _SalaryKey;
		[Browsable(true), DisplayName("SalaryKey")]
		public System.Int32 SalaryKey 
		{
			get
			{
				return _SalaryKey;
			}
			set
			{
			if (PropertyChanged(_SalaryKey, value))
					_SalaryKey = value;
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

		private System.String _SalaryRuleCode;
		[Browsable(true), DisplayName("SalaryRuleCode")]
        public System.String SalaryRuleCode 
		{
			get
			{
				return _SalaryRuleCode;
			}
			set
			{
			if (PropertyChanged(_SalaryRuleCode, value))
					_SalaryRuleCode = value;
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

		private System.Boolean _IsFixed;
		[Browsable(true), DisplayName("IsFixed")]
		public System.Boolean IsFixed 
		{
			get
			{
				return _IsFixed;
			}
			set
			{
			if (PropertyChanged(_IsFixed, value))
					_IsFixed = value;
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
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpKey,_SalaryRuleCode,_SalaryHeadKey,_IsFixed,_Amount};
			else if (IsModified)
				parameterValues = new Object[] {_EmpKey,_SalaryRuleCode,_SalaryHeadKey,_IsFixed,_Amount};
			else if (IsDeleted)
				parameterValues = new Object[] {_SalaryHeadKey,_EmpKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_SalaryKey = reader.GetInt32("SalaryKey");
			_EmpKey = reader.GetInt64("EmpKey");
			_SalaryRuleCode = reader.GetString("SalaryRuleCode");
			_SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
			_IsFixed = reader.GetBoolean("IsFixed");
			_Amount = reader.GetDecimal("Amount");
			SetUnchanged();
		}
		public static CustomList<EmployeeSalary> GetAllEmployeeSalary()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<EmployeeSalary> EmployeeSalaryCollection = new CustomList<EmployeeSalary>();
			IDataReader reader = null;
			const String sql = "select *from EmployeeSalary";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					EmployeeSalary newEmployeeSalary = new EmployeeSalary();
					newEmployeeSalary.SetData(reader);
					EmployeeSalaryCollection.Add(newEmployeeSalary);
				}
				EmployeeSalaryCollection.InsertSpName = "spInsertEmployeeSalary";
				EmployeeSalaryCollection.UpdateSpName = "spUpdateEmployeeSalary";
				EmployeeSalaryCollection.DeleteSpName = "spDeleteEmployeeSalary";
				return EmployeeSalaryCollection;
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