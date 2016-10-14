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
	public class EmployeeSalaryTemp : BaseItem
	{
		public EmployeeSalaryTemp()
		{
			SetAdded();
		}
		
#region Properties

		private System.Decimal _EmployeeSalaryTempID;
		[Browsable(true), DisplayName("EmployeeSalaryTempID")]
		public System.Decimal EmployeeSalaryTempID 
		{
			get
			{
				return _EmployeeSalaryTempID;
			}
			set
			{
			if (PropertyChanged(_EmployeeSalaryTempID, value))
					_EmployeeSalaryTempID = value;
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

		private System.String _StepCode;
		[Browsable(true), DisplayName("StepCode")]
		public System.String StepCode 
		{
			get
			{
				return _StepCode;
			}
			set
			{
			if (PropertyChanged(_StepCode, value))
					_StepCode = value;
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

		private System.String _ApprovedBy;
		[Browsable(true), DisplayName("ApprovedBy")]
		public System.String ApprovedBy 
		{
			get
			{
				return _ApprovedBy;
			}
			set
			{
			if (PropertyChanged(_ApprovedBy, value))
					_ApprovedBy = value;
			}
		}

		private System.DateTime _DateApproved;
		[Browsable(true), DisplayName("DateApproved"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime DateApproved 
		{
			get
			{
				return _DateApproved;
			}
			set
			{
			if (PropertyChanged(_DateApproved, value))
					_DateApproved = value;
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
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpKey,_StepCode,_SalaryRuleCode,_SalaryHeadKey,_IsFixed,_Amount,_ApprovedBy,_DateApproved.Value(StaticInfo.DateFormat),_AddedBy,_DateAdded.Value(StaticInfo.DateFormat)};
			else if (IsModified)
                parameterValues = new Object[] { _EmpKey, _StepCode, _SalaryRuleCode, _SalaryHeadKey, _IsFixed, _Amount, _ApprovedBy, _DateApproved.Value(StaticInfo.DateFormat), _AddedBy, _DateAdded.Value(StaticInfo.DateFormat) };
			else if (IsDeleted)
				parameterValues = new Object[] {_EmployeeSalaryTempID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_EmployeeSalaryTempID = reader.GetDecimal("EmployeeSalaryTempID");
			_EmpKey = reader.GetInt64("EmpKey");
			_StepCode = reader.GetString("StepCode");
            _SalaryRuleCode = reader.GetString("SalaryRuleCode");
			_SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
			_IsFixed = reader.GetBoolean("IsFixed");
			_Amount = reader.GetDecimal("Amount");
			_ApprovedBy = reader.GetString("ApprovedBy");
			_DateApproved = reader.GetDateTime("DateApproved");
			_AddedBy = reader.GetString("AddedBy");
			_DateAdded = reader.GetDateTime("DateAdded");
			SetUnchanged();
		}
		public static CustomList<EmployeeSalaryTemp> GetAllEmployeeSalaryTemp()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<EmployeeSalaryTemp> EmployeeSalaryTempCollection = new CustomList<EmployeeSalaryTemp>();
			IDataReader reader = null;
			const String sql = "select *from EmployeeSalaryTemp";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					EmployeeSalaryTemp newEmployeeSalaryTemp = new EmployeeSalaryTemp();
					newEmployeeSalaryTemp.SetData(reader);
					EmployeeSalaryTempCollection.Add(newEmployeeSalaryTemp);
				}
				EmployeeSalaryTempCollection.InsertSpName = "spInsertEmployeeSalaryTemp";
				EmployeeSalaryTempCollection.UpdateSpName = "spUpdateEmployeeSalaryTemp";
				EmployeeSalaryTempCollection.DeleteSpName = "spDeleteEmployeeSalaryTemp";
				return EmployeeSalaryTempCollection;
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
        public static CustomList<EmployeeSalaryTemp> GetAllEmployeeSalaryByEmpKey(Int64 empKey, string usercode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<EmployeeSalaryTemp> EmployeeSalaryTempCollection = new CustomList<EmployeeSalaryTemp>();
            IDataReader reader = null;
            String sql = "EXEC spGetSalaryInfo " + empKey +" , '"+ usercode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    EmployeeSalaryTemp newEmployeeSalaryTemp = new EmployeeSalaryTemp();
                    newEmployeeSalaryTemp.EmpKey = reader.GetInt64("EmpKey");
                    newEmployeeSalaryTemp.SalaryRuleCode = reader.GetString("SalaryRuleCode");
                    newEmployeeSalaryTemp.SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
                    newEmployeeSalaryTemp.Amount = reader.GetDecimal("Amount");
                    EmployeeSalaryTempCollection.Add(newEmployeeSalaryTemp);
                }
                return EmployeeSalaryTempCollection;
            }
            catch (Exception ex)
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
