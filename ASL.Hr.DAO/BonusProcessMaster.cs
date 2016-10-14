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
	public class BonusProcessMaster : BaseItem
	{
		public BonusProcessMaster()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _ProcessID;
		[Browsable(true), DisplayName("ProcessID")]
		public System.Int32 ProcessID 
		{
			get
			{
				return _ProcessID;
			}
			set
			{
			if (PropertyChanged(_ProcessID, value))
					_ProcessID = value;
			}
		}

		private System.DateTime _CutOffDate;
		[Browsable(true), DisplayName("CutOffDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime CutOffDate 
		{
			get
			{
				return _CutOffDate;
			}
			set
			{
			if (PropertyChanged(_CutOffDate, value))
					_CutOffDate = value;
			}
		}

		private System.Int32 _BonusPolicyID;
		[Browsable(true), DisplayName("BonusPolicyID")]
		public System.Int32 BonusPolicyID 
		{
			get
			{
				return _BonusPolicyID;
			}
			set
			{
			if (PropertyChanged(_BonusPolicyID, value))
					_BonusPolicyID = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_ProcessID,_CutOffDate.Value(StaticInfo.DateFormat),_BonusPolicyID};
			else if (IsModified)
				parameterValues = new Object[] {_ProcessID,_CutOffDate.Value(StaticInfo.DateFormat),_BonusPolicyID};
			else if (IsDeleted)
				parameterValues = new Object[] {_ProcessID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_ProcessID = reader.GetInt32("ProcessID");
			_CutOffDate = reader.GetDateTime("CutOffDate");
			_BonusPolicyID = reader.GetInt32("BonusPolicyID");
			SetUnchanged();
		}
		public static CustomList<BonusProcessMaster> GetAllBonusProcessMaster()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<BonusProcessMaster> BonusProcessMasterCollection = new CustomList<BonusProcessMaster>();
			IDataReader reader = null;
			const String sql = "select *from BonusProcessMaster";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					BonusProcessMaster newBonusProcessMaster = new BonusProcessMaster();
					newBonusProcessMaster.SetData(reader);
					BonusProcessMasterCollection.Add(newBonusProcessMaster);
				}
				BonusProcessMasterCollection.InsertSpName = "spInsertBonusProcessMaster";
				BonusProcessMasterCollection.UpdateSpName = "spUpdateBonusProcessMaster";
				BonusProcessMasterCollection.DeleteSpName = "spDeleteBonusProcessMaster";
				return BonusProcessMasterCollection;
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