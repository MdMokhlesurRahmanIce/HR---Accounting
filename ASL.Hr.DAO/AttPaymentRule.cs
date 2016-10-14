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
	public class AttPaymentRule : BaseItem
	{
		public AttPaymentRule()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int64 _AttPaymentRuleID;
		[Browsable(true), DisplayName("AttPaymentRuleID")]
		public System.Int64 AttPaymentRuleID 
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

		private System.String _AttPaymentRuleCode;
		[Browsable(true), DisplayName("AttPaymentRuleCode")]
		public System.String AttPaymentRuleCode 
		{
			get
			{
				return _AttPaymentRuleCode;
			}
			set
			{
			if (PropertyChanged(_AttPaymentRuleCode, value))
					_AttPaymentRuleCode = value;
			}
		}

		private System.Int32 _PaymentID;
		[Browsable(true), DisplayName("PaymentID")]
		public System.Int32 PaymentID 
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

		private System.String _RuleFor;
		[Browsable(true), DisplayName("RuleFor")]
		public System.String RuleFor 
		{
			get
			{
				return _RuleFor;
			}
			set
			{
			if (PropertyChanged(_RuleFor, value))
					_RuleFor = value;
			}
		}

		private System.Boolean _isCalander;
		[Browsable(true), DisplayName("isCalander")]
		public System.Boolean isCalander 
		{
			get
			{
				return _isCalander;
			}
			set
			{
			if (PropertyChanged(_isCalander, value))
					_isCalander = value;
			}
		}

		private System.Boolean _isWorking;
		[Browsable(true), DisplayName("isWorking")]
		public System.Boolean isWorking 
		{
			get
			{
				return _isWorking;
			}
			set
			{
			if (PropertyChanged(_isWorking, value))
					_isWorking = value;
			}
		}

		private System.Boolean _ExcludingWeek;
		[Browsable(true), DisplayName("ExcludingWeek")]
		public System.Boolean ExcludingWeek 
		{
			get
			{
				return _ExcludingWeek;
			}
			set
			{
			if (PropertyChanged(_ExcludingWeek, value))
					_ExcludingWeek = value;
			}
		}

		private System.Boolean _ExcludingHoliday;
		[Browsable(true), DisplayName("ExcludingHoliday")]
		public System.Boolean ExcludingHoliday 
		{
			get
			{
				return _ExcludingHoliday;
			}
			set
			{
			if (PropertyChanged(_ExcludingHoliday, value))
					_ExcludingHoliday = value;
			}
		}

		private System.Boolean _IsARA;
		[Browsable(true), DisplayName("IsARA")]
		public System.Boolean IsARA 
		{
			get
			{
				return _IsARA;
			}
			set
			{
			if (PropertyChanged(_IsARA, value))
					_IsARA = value;
			}
		}

		private System.Boolean _IsNoOfLate;
		[Browsable(true), DisplayName("IsNoOfLate")]
		public System.Boolean IsNoOfLate 
		{
			get
			{
				return _IsNoOfLate;
			}
			set
			{
			if (PropertyChanged(_IsNoOfLate, value))
					_IsNoOfLate = value;
			}
		}

		private System.Int32? _LateDays;
		[Browsable(true), DisplayName("LateDays")]
		public System.Int32? LateDays 
		{
			get
			{
				return _LateDays;
			}
			set
			{
			if (PropertyChanged(_LateDays, value))
					_LateDays = value;
			}
		}

		private System.Boolean _LateActionIsDays;
		[Browsable(true), DisplayName("LateActionIsDays")]
		public System.Boolean LateActionIsDays 
		{
			get
			{
				return _LateActionIsDays;
			}
			set
			{
			if (PropertyChanged(_LateActionIsDays, value))
					_LateActionIsDays = value;
			}
		}

		private System.Decimal _LateAction;
		[Browsable(true), DisplayName("LateAction")]
		public System.Decimal LateAction 
		{
			get
			{
				return _LateAction;
			}
			set
			{
			if (PropertyChanged(_LateAction, value))
					_LateAction = value;
			}
		}

		private System.Int32 _DaysInMonth;
		[Browsable(true), DisplayName("DaysInMonth")]
		public System.Int32 DaysInMonth 
		{
			get
			{
				return _DaysInMonth;
			}
			set
			{
			if (PropertyChanged(_DaysInMonth, value))
					_DaysInMonth = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_AttPaymentRuleID,_AttPaymentRuleCode,_PaymentID,_RuleFor,_isCalander,_isWorking,_ExcludingWeek,_ExcludingHoliday,_IsARA,_IsNoOfLate,_LateDays,_LateActionIsDays,_LateAction,_DaysInMonth};
			else if (IsModified)
				parameterValues = new Object[] {_AttPaymentRuleID,_AttPaymentRuleCode,_PaymentID,_RuleFor,_isCalander,_isWorking,_ExcludingWeek,_ExcludingHoliday,_IsARA,_IsNoOfLate,_LateDays,_LateActionIsDays,_LateAction,_DaysInMonth};
			else if (IsDeleted)
				parameterValues = new Object[] {_AttPaymentRuleID,_PaymentID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_AttPaymentRuleID = reader.GetInt64("AttPaymentRuleID");
			_AttPaymentRuleCode = reader.GetString("AttPaymentRuleCode");
			_PaymentID = reader.GetInt32("PaymentID");
			_RuleFor = reader.GetString("RuleFor");
			_isCalander = reader.GetBoolean("isCalander");
			_isWorking = reader.GetBoolean("isWorking");
			_ExcludingWeek = reader.GetBoolean("ExcludingWeek");
			_ExcludingHoliday = reader.GetBoolean("ExcludingHoliday");
			_IsARA = reader.GetBoolean("IsARA");
			_IsNoOfLate = reader.GetBoolean("IsNoOfLate");
			_LateDays = reader.GetInt32("LateDays");
			_LateActionIsDays = reader.GetBoolean("LateActionIsDays");
			_LateAction = reader.GetDecimal("LateAction");
			_DaysInMonth = reader.GetInt32("DaysInMonth");
			SetUnchanged();
		}
		public static CustomList<AttPaymentRule> GetAllAttPaymentRule()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<AttPaymentRule> AttPaymentRuleCollection = new CustomList<AttPaymentRule>();
			IDataReader reader = null;
			const String sql = "select *from AttPaymentRule";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					AttPaymentRule newAttPaymentRule = new AttPaymentRule();
					newAttPaymentRule.SetData(reader);
					AttPaymentRuleCollection.Add(newAttPaymentRule);
				}
				AttPaymentRuleCollection.InsertSpName = "spInsertAttPaymentRule";
				AttPaymentRuleCollection.UpdateSpName = "spUpdateAttPaymentRule";
				AttPaymentRuleCollection.DeleteSpName = "spDeleteAttPaymentRule";
				return AttPaymentRuleCollection;
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
