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
	public class AttPaymentRuleAmount : BaseItem
	{
		public AttPaymentRuleAmount()
		{
			SetAdded();
		}
		
#region Properties

		private System.String _SalaryHeadID;
		[Browsable(true), DisplayName("SalaryHeadID")]
		public System.String SalaryHeadID 
		{
			get
			{
				return _SalaryHeadID;
			}
			set
			{
			if (PropertyChanged(_SalaryHeadID, value))
					_SalaryHeadID = value;
			}
		}

		private System.String _PaymentID;
		[Browsable(true), DisplayName("PaymentID")]
		public System.String PaymentID 
		{
			get
			{
				return _PaymentID;
			}
			set
			{
			if (PropertyChanged(_PaymentID, value))
					_PaymentID = value;
			}
		}

		private System.String _AttPaymentRuleID;
		[Browsable(true), DisplayName("AttPaymentRuleID")]
		public System.String AttPaymentRuleID 
		{
			get
			{
				return _AttPaymentRuleID;
			}
			set
			{
			if (PropertyChanged(_AttPaymentRuleID, value))
					_AttPaymentRuleID = value;
			}
		}

		private System.String _sCriteria;
		[Browsable(true), DisplayName("sCriteria")]
		public System.String sCriteria 
		{
			get
			{
				return _sCriteria;
			}
			set
			{
			if (PropertyChanged(_sCriteria, value))
					_sCriteria = value;
			}
		}

		private System.Decimal _ParentHeadValue;
		[Browsable(true), DisplayName("ParentHeadValue")]
		public System.Decimal ParentHeadValue 
		{
			get
			{
				return _ParentHeadValue;
			}
			set
			{
			if (PropertyChanged(_ParentHeadValue, value))
					_ParentHeadValue = value;
			}
		}

		private System.Decimal _PartialHeadValue;
		[Browsable(true), DisplayName("PartialHeadValue")]
		public System.Decimal PartialHeadValue 
		{
			get
			{
				return _PartialHeadValue;
			}
			set
			{
			if (PropertyChanged(_PartialHeadValue, value))
					_PartialHeadValue = value;
			}
		}

		private System.Boolean _IsHigher;
		[Browsable(true), DisplayName("IsHigher")]
		public System.Boolean IsHigher 
		{
			get
			{
				return _IsHigher;
			}
			set
			{
			if (PropertyChanged(_IsHigher, value))
					_IsHigher = value;
			}
		}

		private System.String _ParentHeadID;
		[Browsable(true), DisplayName("ParentHeadID")]
		public System.String ParentHeadID 
		{
			get
			{
				return _ParentHeadID;
			}
			set
			{
			if (PropertyChanged(_ParentHeadID, value))
					_ParentHeadID = value;
			}
		}

		private System.String _PartialHeadID;
		[Browsable(true), DisplayName("PartialHeadID")]
		public System.String PartialHeadID 
		{
			get
			{
				return _PartialHeadID;
			}
			set
			{
			if (PropertyChanged(_PartialHeadID, value))
					_PartialHeadID = value;
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

		private System.String _ReportHeadID;
		[Browsable(true), DisplayName("ReportHeadID")]
		public System.String ReportHeadID 
		{
			get
			{
				return _ReportHeadID;
			}
			set
			{
			if (PropertyChanged(_ReportHeadID, value))
					_ReportHeadID = value;
			}
		}

		private System.Boolean _LessThenPerDay;
		[Browsable(true), DisplayName("LessThenPerDay")]
		public System.Boolean LessThenPerDay 
		{
			get
			{
				return _LessThenPerDay;
			}
			set
			{
			if (PropertyChanged(_LessThenPerDay, value))
					_LessThenPerDay = value;
			}
		}

		private System.Boolean _IsGreater;
		[Browsable(true), DisplayName("IsGreater")]
		public System.Boolean IsGreater 
		{
			get
			{
				return _IsGreater;
			}
			set
			{
			if (PropertyChanged(_IsGreater, value))
					_IsGreater = value;
			}
		}

		private System.Decimal _Hours;
		[Browsable(true), DisplayName("Hours")]
		public System.Decimal Hours 
		{
			get
			{
				return _Hours;
			}
			set
			{
			if (PropertyChanged(_Hours, value))
					_Hours = value;
			}
		}

		private System.String _Condition;
		[Browsable(true), DisplayName("Condition")]
		public System.String Condition 
		{
			get
			{
				return _Condition;
			}
			set
			{
			if (PropertyChanged(_Condition, value))
					_Condition = value;
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
        private System.String _Calculation;
        [Browsable(true), DisplayName("Calculation")]
        public System.String Calculation
        {
            get
            {
                return _Calculation;
            }
            set
            {
                if (PropertyChanged(_Calculation, value))
                    _Calculation = value;
            }
        }
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_SalaryHeadID,_PaymentID,_AttPaymentRuleID,_sCriteria,_ParentHeadValue,_PartialHeadValue,_IsHigher,_ParentHeadID,_PartialHeadID,_IsFixed,_ReportHeadID,_LessThenPerDay,_IsGreater,_Hours,_Condition, _Calculation,_DateAdded.Value(StaticInfo.DateFormat),_DateUpdated.Value(StaticInfo.DateFormat),_AddedBy,_UpdatedBy};
			else if (IsModified)
                parameterValues = new Object[] { _SalaryHeadID, _PaymentID, _AttPaymentRuleID, _sCriteria, _ParentHeadValue, _PartialHeadValue, _IsHigher, _ParentHeadID, _PartialHeadID, _IsFixed, _ReportHeadID, _LessThenPerDay, _IsGreater, _Hours, _Condition, _Calculation, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy };
			else if (IsDeleted)
				parameterValues = new Object[] {_SalaryHeadID,_PaymentID,_AttPaymentRuleID,_ParentHeadID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_SalaryHeadID = reader.GetString("SalaryHeadID");
			_PaymentID = reader.GetString("PaymentID");
			_AttPaymentRuleID = reader.GetString("AttPaymentRuleID");
			_sCriteria = reader.GetString("sCriteria");
			_ParentHeadValue = reader.GetDecimal("ParentHeadValue");
			_PartialHeadValue = reader.GetDecimal("PartialHeadValue");
			_IsHigher = reader.GetBoolean("IsHigher");
			_ParentHeadID = reader.GetString("ParentHeadID");
			_PartialHeadID = reader.GetString("PartialHeadID");
			_IsFixed = reader.GetBoolean("IsFixed");
			_ReportHeadID = reader.GetString("ReportHeadID");
			_LessThenPerDay = reader.GetBoolean("LessThenPerDay");
			_IsGreater = reader.GetBoolean("IsGreater");
			_Hours = reader.GetDecimal("Hours");
			_Condition = reader.GetString("Condition");
            _Calculation = reader.GetString("Calculation");
			_DateAdded = reader.GetDateTime("DateAdded");
			_DateUpdated = reader.GetDateTime("DateUpdated");
			_AddedBy = reader.GetString("AddedBy");
			_UpdatedBy = reader.GetString("UpdatedBy");
			SetUnchanged();
		}
		public static CustomList<AttPaymentRuleAmount> GetAllAttPaymentRuleAmount()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<AttPaymentRuleAmount> AttPaymentRuleAmountCollection = new CustomList<AttPaymentRuleAmount>();
			IDataReader reader = null;
			const String sql = "select *from AttPaymentRuleAmount";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					AttPaymentRuleAmount newAttPaymentRuleAmount = new AttPaymentRuleAmount();
					newAttPaymentRuleAmount.SetData(reader);
					AttPaymentRuleAmountCollection.Add(newAttPaymentRuleAmount);
				}
				AttPaymentRuleAmountCollection.InsertSpName = "spInsertAttPaymentRuleAmount";
				AttPaymentRuleAmountCollection.UpdateSpName = "spUpdateAttPaymentRuleAmount";
				AttPaymentRuleAmountCollection.DeleteSpName = "spDeleteAttPaymentRuleAmount";
				return AttPaymentRuleAmountCollection;
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
