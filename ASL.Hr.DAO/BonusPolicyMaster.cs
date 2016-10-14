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
	public class BonusPolicyMaster : BaseItem
	{
		public BonusPolicyMaster()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _PolicyID;
		[Browsable(true), DisplayName("PolicyID")]
		public System.Int32 PolicyID 
		{
			get
			{
				return _PolicyID;
			}
			set
			{
			if (PropertyChanged(_PolicyID, value))
					_PolicyID = value;
			}
		}

		private System.String _PolicyCode;
		[Browsable(true), DisplayName("PolicyCode")]
		public System.String PolicyCode 
		{
			get
			{
				return _PolicyCode;
			}
			set
			{
			if (PropertyChanged(_PolicyCode, value))
					_PolicyCode = value;
			}
		}

        private System.String _PolicyName;
        [Browsable(true), DisplayName("PolicyName")]
        public System.String PolicyName
        {
            get
            {
                return _PolicyName;
            }
            set
            {
                if (PropertyChanged(_PolicyName, value))
                    _PolicyName = value;
            }
        }

		private System.Int32 _BonusType;
		[Browsable(true), DisplayName("BonusType")]
		public System.Int32 BonusType 
		{
			get
			{
				return _BonusType;
			}
			set
			{
			if (PropertyChanged(_BonusType, value))
					_BonusType = value;
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

		private System.Int32 _AvailFrom;
		[Browsable(true), DisplayName("AvailFrom")]
		public System.Int32 AvailFrom 
		{
			get
			{
				return _AvailFrom;
			}
			set
			{
			if (PropertyChanged(_AvailFrom, value))
					_AvailFrom = value;
			}
		}

		private System.Int32 _AfterDays;
		[Browsable(true), DisplayName("AfterDays")]
		public System.Int32 AfterDays 
		{
			get
			{
				return _AfterDays;
			}
			set
			{
			if (PropertyChanged(_AfterDays, value))
					_AfterDays = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_PolicyCode,_PolicyName,_BonusType,_Description,_AvailFrom,_AfterDays};
			else if (IsModified)
                parameterValues = new Object[] { _PolicyID, _PolicyCode, _PolicyName, _BonusType, _Description, _AvailFrom, _AfterDays };
			else if (IsDeleted)
				parameterValues = new Object[] {_PolicyID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_PolicyID = reader.GetInt32("PolicyID");
			_PolicyCode = reader.GetString("PolicyCode");
            _PolicyName = reader.GetString("PolicyName");
			_BonusType = reader.GetInt32("BonusType");
			_Description = reader.GetString("Description");
			_AvailFrom = reader.GetInt32("AvailFrom");
			_AfterDays = reader.GetInt32("AfterDays");
			SetUnchanged();
		}
		public static CustomList<BonusPolicyMaster> GetAllBonusPolicyMaster()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<BonusPolicyMaster> BonusPolicyMasterCollection = new CustomList<BonusPolicyMaster>();
			IDataReader reader = null;
			const String sql = "select *from BonusPolicyMaster";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					BonusPolicyMaster newBonusPolicyMaster = new BonusPolicyMaster();
					newBonusPolicyMaster.SetData(reader);
					BonusPolicyMasterCollection.Add(newBonusPolicyMaster);
				}
				BonusPolicyMasterCollection.InsertSpName = "spInsertBonusPolicyMaster";
				BonusPolicyMasterCollection.UpdateSpName = "spUpdateBonusPolicyMaster";
				BonusPolicyMasterCollection.DeleteSpName = "spDeleteBonusPolicyMaster";
				return BonusPolicyMasterCollection;
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
