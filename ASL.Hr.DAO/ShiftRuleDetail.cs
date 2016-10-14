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
	public class ShiftRuleDetail : BaseItem
	{
		public ShiftRuleDetail()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _ShiftRuleDetailID;
		[Browsable(true), DisplayName("ShiftRuleDetailID")]
		public System.Int32 ShiftRuleDetailID 
		{
			get
			{
				return _ShiftRuleDetailID;
			}
			set
			{
			if (PropertyChanged(_ShiftRuleDetailID, value))
					_ShiftRuleDetailID = value;
			}
		}

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

		private System.String _ShiftID;
		[Browsable(true), DisplayName("ShiftID")]
		public System.String ShiftID 
		{
			get
			{
				return _ShiftID;
			}
			set
			{
			if (PropertyChanged(_ShiftID, value))
					_ShiftID = value;
			}
		}

		private System.Int32 _Days;
		[Browsable(true), DisplayName("Days")]
		public System.Int32 Days 
		{
			get
			{
				return _Days;
			}
			set
			{
			if (PropertyChanged(_Days, value))
					_Days = value;
			}
		}

		private System.Int32 _SequenceNo;
		[Browsable(true), DisplayName("SequenceNo")]
		public System.Int32 SequenceNo 
		{
			get
			{
				return _SequenceNo;
			}
			set
			{
			if (PropertyChanged(_SequenceNo, value))
					_SequenceNo = value;
			}
		}

		private System.String _ShiftType;
		[Browsable(true), DisplayName("ShiftType")]
		public System.String ShiftType 
		{
			get
			{
				return _ShiftType;
			}
			set
			{
			if (PropertyChanged(_ShiftType, value))
					_ShiftType = value;
			}
		}

        private System.String _ALISE;
        [Browsable(true), DisplayName("ALISE")]
        public System.String ALISE 
		{
			get
			{
                return _ALISE;
			}
			set
			{
                if (PropertyChanged(_ALISE, value))
                    _ALISE = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_ShiftRuleKey,_ShiftID,_Days,_SequenceNo,_ShiftType};
			else if (IsModified)
                parameterValues = new Object[] { _ShiftRuleDetailID, _ShiftRuleKey, _ShiftID, _Days, _SequenceNo, _ShiftType };
			else if (IsDeleted)
				parameterValues = new Object[] {_ShiftRuleDetailID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_ShiftRuleDetailID = reader.GetInt32("ShiftRuleDetailID");
            _ShiftRuleKey = reader.GetInt32("ShiftRuleKey");
			_ShiftID = reader.GetString("ShiftID");
			_Days = reader.GetInt32("Days");
			_SequenceNo = reader.GetInt32("SequenceNo");
			_ShiftType = reader.GetString("ShiftType");
			SetUnchanged();
		}
        private void SetDataShiftRoster(IDataRecord reader)
        {
            _ShiftRuleDetailID = reader.GetInt32("ShiftRuleDetailID");
            _ShiftRuleKey = reader.GetInt32("ShiftRuleKey");
            _ShiftID = reader.GetString("ShiftID");
            _Days = reader.GetInt32("Days");
            _SequenceNo = reader.GetInt32("SequenceNo");
            _ShiftType = reader.GetString("ShiftType");
            _ALISE = reader.GetString("ALISE");
            SetUnchanged();
        }
		public static CustomList<ShiftRuleDetail> GetAllShiftRuleDetail(int ShiftRuleKey)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<ShiftRuleDetail> ShiftRuleDetailCollection = new CustomList<ShiftRuleDetail>();
			IDataReader reader = null;
            String sql = "select *from ShiftRuleDetail Where ShiftRuleKey='"+ShiftRuleKey+"'";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					ShiftRuleDetail newShiftRuleDetail = new ShiftRuleDetail();
					newShiftRuleDetail.SetData(reader);
					ShiftRuleDetailCollection.Add(newShiftRuleDetail);
				}
				return ShiftRuleDetailCollection;
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

        public static CustomList<ShiftRuleDetail> GetAllShiftRuleDetail()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ShiftRuleDetail> ShiftRuleDetailCollection = new CustomList<ShiftRuleDetail>();
            IDataReader reader = null;
            String sql = "select SRD.*,SP.ALISE from ShiftRuleDetail SRD INNER JOIN ShiftPlan SP ON SP.ShiftID=SRD.ShiftID";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ShiftRuleDetail newShiftRuleDetail = new ShiftRuleDetail();
                    newShiftRuleDetail.SetDataShiftRoster(reader);
                    ShiftRuleDetailCollection.Add(newShiftRuleDetail);
                }
                return ShiftRuleDetailCollection;
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
