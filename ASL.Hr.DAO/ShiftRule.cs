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
	public class ShiftRule : BaseItem
	{
		public ShiftRule()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _ShiftRuleKey;
		[Browsable(true), DisplayName("ShiftRuleKey")]
		public System.Int32 ShiftRuleKey 
		{
			get
			{
				return _ShiftRuleKey;
			}
			set
			{
			if (PropertyChanged(_ShiftRuleKey, value))
					_ShiftRuleKey = value;
			}
		}

		private System.String _ShiftRuleCode;
		[Browsable(true), DisplayName("ShiftRuleCode")]
		public System.String ShiftRuleCode 
		{
			get
			{
				return _ShiftRuleCode;
			}
			set
			{
			if (PropertyChanged(_ShiftRuleCode, value))
					_ShiftRuleCode = value;
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

		private System.Boolean _IsDefaultRule;
		[Browsable(true), DisplayName("IsDefaultRule")]
		public System.Boolean IsDefaultRule 
		{
			get
			{
				return _IsDefaultRule;
			}
			set
			{
			if (PropertyChanged(_IsDefaultRule, value))
					_IsDefaultRule = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_ShiftRuleCode,_Description,_IsDefaultRule};
			else if (IsModified)
                parameterValues = new Object[] { _ShiftRuleKey, _ShiftRuleCode, _Description, _IsDefaultRule };
			else if (IsDeleted)
				parameterValues = new Object[] {_ShiftRuleKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_ShiftRuleKey = reader.GetInt32("ShiftRuleKey");
			_ShiftRuleCode = reader.GetString("ShiftRuleCode");
			_Description = reader.GetString("Description");
			_IsDefaultRule = reader.GetBoolean("IsDefaultRule");
			SetUnchanged();
		}
        public static CustomList<ShiftRule> doSearch(string whereClause)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<ShiftRule> ShiftRuleCollection = new CustomList<ShiftRule>();
			IDataReader reader = null;
            String sql = string.Format("Select * From [ShiftRule] Where 1=1 {0}", whereClause);
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					ShiftRule newShiftRule = new ShiftRule();
					newShiftRule.SetData(reader);
					ShiftRuleCollection.Add(newShiftRule);
				}
				return ShiftRuleCollection;
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
		public static CustomList<ShiftRule> GetAllShiftRule()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<ShiftRule> ShiftRuleCollection = new CustomList<ShiftRule>();
			IDataReader reader = null;
			const String sql = "Select * from ShiftRule";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					ShiftRule newShiftRule = new ShiftRule();
					newShiftRule.SetData(reader);
					ShiftRuleCollection.Add(newShiftRule);
				}
				ShiftRuleCollection.InsertSpName = "spInsertShiftRule";
				ShiftRuleCollection.UpdateSpName = "spUpdateShiftRule";
				ShiftRuleCollection.DeleteSpName = "spDeleteShiftRule";
				return ShiftRuleCollection;
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
      