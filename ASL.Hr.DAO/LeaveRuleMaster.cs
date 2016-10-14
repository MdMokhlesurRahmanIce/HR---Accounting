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
	public class LeaveRuleMaster : BaseItem
	{
		public LeaveRuleMaster()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _LeaveRuleKey;
		[Browsable(true), DisplayName("LeaveRuleKey")]
		public System.Int32 LeaveRuleKey 
		{
			get
			{
				return _LeaveRuleKey;
			}
			set
			{
			if (PropertyChanged(_LeaveRuleKey, value))
					_LeaveRuleKey = value;
			}
		}

		private System.String _LeaveRuleCode;
		[Browsable(true), DisplayName("LeaveRuleCode")]
		public System.String LeaveRuleCode 
		{
			get
			{
				return _LeaveRuleCode;
			}
			set
			{
			if (PropertyChanged(_LeaveRuleCode, value))
					_LeaveRuleCode = value;
			}
		}

		private System.String _Description;
		[Browsable(true), DisplayName("Description")]
		public System.String Description 
		{
			get
			{
				return _Description;
			}
			set
			{
			if (PropertyChanged(_Description, value))
					_Description = value;
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
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_LeaveRuleCode,_Description,_AddedBy,_DateAdded.Value(StaticInfo.DateFormat),_UpdatedBy,_DateUpdated.Value(StaticInfo.DateFormat)};
			else if (IsModified)
                parameterValues = new Object[] { _LeaveRuleKey,_LeaveRuleCode, _Description, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _DateUpdated.Value(StaticInfo.DateFormat) };
			else if (IsDeleted)
				parameterValues = new Object[] {_LeaveRuleKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_LeaveRuleKey = reader.GetInt32("LeaveRuleKey");
			_LeaveRuleCode = reader.GetString("LeaveRuleCode");
			_Description = reader.GetString("Description");
			_AddedBy = reader.GetString("AddedBy");
			_DateAdded = reader.GetDateTime("DateAdded");
			_UpdatedBy = reader.GetString("UpdatedBy");
			_DateUpdated = reader.GetDateTime("DateUpdated");
			SetUnchanged();
		}
		public static CustomList<LeaveRuleMaster> GetAllLeaveRuleMaster()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<LeaveRuleMaster> LeaveRuleMasterCollection = new CustomList<LeaveRuleMaster>();
			IDataReader reader = null;
			const String sql = "select * from LeaveRuleMaster";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					LeaveRuleMaster newLeaveRuleMaster = new LeaveRuleMaster();
					newLeaveRuleMaster.SetData(reader);
					LeaveRuleMasterCollection.Add(newLeaveRuleMaster);
				}
				LeaveRuleMasterCollection.InsertSpName = "spInsertLeaveRuleMaster";
				LeaveRuleMasterCollection.UpdateSpName = "spUpdateLeaveRuleMaster";
				LeaveRuleMasterCollection.DeleteSpName = "spDeleteLeaveRuleMaster";
				return LeaveRuleMasterCollection;
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
        public static CustomList<LeaveRuleMaster> GetSelectedLeaveRule(int LeaveRuleKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveRuleMaster> LeaveRuleCollection = new CustomList<LeaveRuleMaster>();
            IDataReader reader = null;
            String sql = "select * from LeaveRuleMaster where LeaveRuleKey= " + LeaveRuleKey + "";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveRuleMaster newLeaveRule = new LeaveRuleMaster();
                    newLeaveRule.SetData(reader);
                    LeaveRuleCollection.Add(newLeaveRule);
                }
                LeaveRuleCollection.InsertSpName = "spInsertLeaveRule";
                LeaveRuleCollection.UpdateSpName = "spUpdateLeaveRule";
                LeaveRuleCollection.DeleteSpName = "spDeleteLeaveRule";
                return LeaveRuleCollection;
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
       