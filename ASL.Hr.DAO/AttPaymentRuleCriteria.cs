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
	public class AttPaymentRuleCriteria : BaseItem
	{
		public AttPaymentRuleCriteria()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _CriteriaID;
		[Browsable(true), DisplayName("CriteriaID")]
		public System.Int32 CriteriaID 
		{
			get
			{
				return _CriteriaID;
			}
			set
			{
			if (PropertyChanged(_CriteriaID, value))
					_CriteriaID = value;
			}
		}

		private System.String _CriteriaName;
		[Browsable(true), DisplayName("CriteriaName")]
		public System.String CriteriaName 
		{
			get
			{
				return _CriteriaName;
			}
			set
			{
			if (PropertyChanged(_CriteriaName, value))
					_CriteriaName = value;
			}
		}

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

		private System.String _DayStatus;
		[Browsable(true), DisplayName("DayStatus")]
		public System.String DayStatus 
		{
			get
			{
				return _DayStatus;
			}
			set
			{
			if (PropertyChanged(_DayStatus, value))
					_DayStatus = value;
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

		private System.Decimal _Days1;
		[Browsable(true), DisplayName("Days1")]
		public System.Decimal Days1 
		{
			get
			{
				return _Days1;
			}
			set
			{
			if (PropertyChanged(_Days1, value))
					_Days1 = value;
			}
		}

		private System.Decimal _Days2;
		[Browsable(true), DisplayName("Days2")]
		public System.Decimal Days2 
		{
			get
			{
				return _Days2;
			}
			set
			{
			if (PropertyChanged(_Days2, value))
					_Days2 = value;
			}
		}

		private System.Boolean _IsPercent;
		[Browsable(true), DisplayName("IsPercent")]
		public System.Boolean IsPercent 
		{
			get
			{
				return _IsPercent;
			}
			set
			{
			if (PropertyChanged(_IsPercent, value))
					_IsPercent = value;
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

		private System.Boolean _ConsiderPreApprovedLeave;
		[Browsable(true), DisplayName("ConsiderPreApprovedLeave")]
		public System.Boolean ConsiderPreApprovedLeave 
		{
			get
			{
				return _ConsiderPreApprovedLeave;
			}
			set
			{
			if (PropertyChanged(_ConsiderPreApprovedLeave, value))
					_ConsiderPreApprovedLeave = value;
			}
		}

		private System.String _LeaveType;
		[Browsable(true), DisplayName("LeaveType")]
		public System.String LeaveType 
		{
			get
			{
				return _LeaveType;
			}
			set
			{
			if (PropertyChanged(_LeaveType, value))
					_LeaveType = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_CriteriaID,_CriteriaName,_AttPaymentRuleID,_PaymentID,_DayStatus,_Condition,_Days1,_Days2,_IsPercent,_DateAdded.Value(StaticInfo.DateFormat),_DateUpdated.Value(StaticInfo.DateFormat),_AddedBy,_UpdatedBy,_ConsiderPreApprovedLeave,_LeaveType};
			else if (IsModified)
				parameterValues = new Object[] {_CriteriaID,_CriteriaName,_AttPaymentRuleID,_PaymentID,_DayStatus,_Condition,_Days1,_Days2,_IsPercent,_DateAdded.Value(StaticInfo.DateFormat),_DateUpdated.Value(StaticInfo.DateFormat),_AddedBy,_UpdatedBy,_ConsiderPreApprovedLeave,_LeaveType};
			else if (IsDeleted)
				parameterValues = new Object[] {_CriteriaID,_AttPaymentRuleID,_PaymentID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_CriteriaID = reader.GetInt32("CriteriaID");
			_CriteriaName = reader.GetString("CriteriaName");
			_AttPaymentRuleID = reader.GetInt64("AttPaymentRuleID");
			_PaymentID = reader.GetInt32("PaymentID");
			_DayStatus = reader.GetString("DayStatus");
			_Condition = reader.GetString("Condition");
			_Days1 = reader.GetDecimal("Days1");
			_Days2 = reader.GetDecimal("Days2");
			_IsPercent = reader.GetBoolean("IsPercent");
			_DateAdded = reader.GetDateTime("DateAdded");
			_DateUpdated = reader.GetDateTime("DateUpdated");
			_AddedBy = reader.GetString("AddedBy");
			_UpdatedBy = reader.GetString("UpdatedBy");
			_ConsiderPreApprovedLeave = reader.GetBoolean("ConsiderPreApprovedLeave");
			_LeaveType = reader.GetString("LeaveType");
			SetUnchanged();
		}
		public static CustomList<AttPaymentRuleCriteria> GetAllAttPaymentRuleCriteria()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<AttPaymentRuleCriteria> AttPaymentRuleCriteriaCollection = new CustomList<AttPaymentRuleCriteria>();
			IDataReader reader = null;
			const String sql = "select *from AttPaymentRuleCriteria";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					AttPaymentRuleCriteria newAttPaymentRuleCriteria = new AttPaymentRuleCriteria();
					newAttPaymentRuleCriteria.SetData(reader);
					AttPaymentRuleCriteriaCollection.Add(newAttPaymentRuleCriteria);
				}
				AttPaymentRuleCriteriaCollection.InsertSpName = "spInsertAttPaymentRuleCriteria";
				AttPaymentRuleCriteriaCollection.UpdateSpName = "spUpdateAttPaymentRuleCriteria";
				AttPaymentRuleCriteriaCollection.DeleteSpName = "spDeleteAttPaymentRuleCriteria";
				return AttPaymentRuleCriteriaCollection;
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