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
	public class LeaveAllocation : BaseItem
	{
		public LeaveAllocation()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _LeaveAllocationKey;
		[Browsable(true), DisplayName("LeaveAllocationKey")]
		public System.Int32 LeaveAllocationKey 
		{
			get
			{
				return _LeaveAllocationKey;
			}
			set
			{
			if (PropertyChanged(_LeaveAllocationKey, value))
					_LeaveAllocationKey = value;
			}
		}

		private System.String _LeaveYearID;
		[Browsable(true), DisplayName("LeaveYearID")]
		public System.String LeaveYearID 
		{
			get
			{
				return _LeaveYearID;
			}
			set
			{
			if (PropertyChanged(_LeaveYearID, value))
					_LeaveYearID = value;
			}
		}

        private System.String _EmpCode;
        [Browsable(true), DisplayName("EmpCode")]
        public System.String EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                if (PropertyChanged(_EmpCode, value))
                    _EmpCode = value;
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

		private System.Int32 _LeavePolicyID;
		[Browsable(true), DisplayName("LeavePolicyID")]
		public System.Int32 LeavePolicyID 
		{
			get
			{
				return _LeavePolicyID;
			}
			set
			{
			if (PropertyChanged(_LeavePolicyID, value))
					_LeavePolicyID = value;
			}
		}

		private System.Decimal _Advance;
		[Browsable(true), DisplayName("Advance")]
        public System.Decimal Advance 
		{
			get
			{
				return _Advance;
			}
			set
			{
			if (PropertyChanged(_Advance, value))
					_Advance = value;
			}
		}

        private System.Decimal _UploadOpeningBalance;
		[Browsable(true), DisplayName("UploadOpeningBalance")]
        public System.Decimal UploadOpeningBalance 
		{
			get
			{
				return _UploadOpeningBalance;
			}
			set
			{
			if (PropertyChanged(_UploadOpeningBalance, value))
					_UploadOpeningBalance = value;
			}
		}

		private System.Decimal _OpeningBalance;
		[Browsable(true), DisplayName("OpeningBalance")]
        public System.Decimal OpeningBalance 
		{
			get
			{
				return _OpeningBalance;
			}
			set
			{
			if (PropertyChanged(_OpeningBalance, value))
					_OpeningBalance = value;
			}
		}

		private System.Decimal _Allocated;
		[Browsable(true), DisplayName("Allocated")]
		public System.Decimal Allocated 
		{
			get
			{
				return _Allocated;
			}
			set
			{
			if (PropertyChanged(_Allocated, value))
					_Allocated = value;
			}
		}

		private System.Decimal _Availed;
		[Browsable(true), DisplayName("Availed")]
		public System.Decimal Availed 
		{
			get
			{
				return _Availed;
			}
			set
			{
			if (PropertyChanged(_Availed, value))
					_Availed = value;
			}
		}

		private System.Decimal _Balance;
		[Browsable(true), DisplayName("Balance")]
		public System.Decimal Balance 
		{
			get
			{
				return _Balance;
			}
			set
			{
			if (PropertyChanged(_Balance, value))
					_Balance = value;
			}
		}

        private System.Decimal _Encashed;
        [Browsable(true), DisplayName("Encashed")]
        public System.Decimal Encashed
        {
            get
            {
                return _Encashed;
            }
            set
            {
                if (PropertyChanged(_Encashed, value))
                    _Encashed = value;
            }
        }
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_LeaveYearID,_EmpKey,_LeavePolicyID,_Advance,_UploadOpeningBalance,_OpeningBalance,_Allocated,_Availed,_Balance};
			else if (IsModified)
				parameterValues = new Object[] {_LeaveAllocationKey,_LeaveYearID,_EmpKey,_LeavePolicyID,_Advance,_UploadOpeningBalance,_OpeningBalance,_Allocated,_Availed,_Balance};
			else if (IsDeleted)
				parameterValues = new Object[] {_LeaveAllocationKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_LeaveAllocationKey = reader.GetInt32("LeaveAllocationKey");
			_LeaveYearID = reader.GetString("LeaveYearID");
            _LeaveType = reader.GetString("LeaveType");
			_EmpKey = reader.GetInt64("EmpKey");
			_LeavePolicyID = reader.GetInt32("LeavePolicyID");
			_Advance = reader.GetDecimal("Advance");
			_UploadOpeningBalance = reader.GetInt32("UploadOpeningBalance");
			_OpeningBalance = reader.GetInt32("OpeningBalance");
			_Allocated = reader.GetDecimal("Allocated");
			_Availed = reader.GetDecimal("Availed");
			_Balance = reader.GetDecimal("Balance");
			SetUnchanged();
		}
        private void SetDataLeaveSummary(IDataRecord reader)
        {
            _LeaveType = reader.GetString("LeaveType");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _LeavePolicyID = reader.GetInt32("LeavePolicyID");
            _Advance = reader.GetDecimal("Advance");
            _OpeningBalance = reader.GetDecimal("OpeningBalance");
            _Allocated = reader.GetDecimal("Allocated");
            _Availed = reader.GetDecimal("Availed");
            _Balance = reader.GetDecimal("Balance");
            _Encashed = reader.GetDecimal("Encashed");
            _LeaveAllocationKey = reader.GetInt32("LeaveAllocationKey");
            SetUnchanged();
        }
		public static CustomList<LeaveAllocation> GetAllLeaveAllocation()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<LeaveAllocation> LeaveAllocationCollection = new CustomList<LeaveAllocation>();
			IDataReader reader = null;
			const String sql = "select * from LeaveAllocation";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					LeaveAllocation newLeaveAllocation = new LeaveAllocation();
					newLeaveAllocation.SetData(reader);
					LeaveAllocationCollection.Add(newLeaveAllocation);
				}
				LeaveAllocationCollection.InsertSpName = "spInsertLeaveAllocation";
				LeaveAllocationCollection.UpdateSpName = "spUpdateLeaveAllocation";
				LeaveAllocationCollection.DeleteSpName = "spDeleteLeaveAllocation";
				return LeaveAllocationCollection;
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
        public static CustomList<LeaveAllocation> GetEmpWiseLeaveAllocation(string LeaveYear, string EmpCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveAllocation> LeaveAllocationCollection = new CustomList<LeaveAllocation>();
            IDataReader reader = null;
            String sql = "exec spLeaveSummeryEmpWise '" + LeaveYear + "','" + EmpCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveAllocation newLeaveAllocation = new LeaveAllocation();
                    newLeaveAllocation.SetDataLeaveSummary(reader);
                    LeaveAllocationCollection.Add(newLeaveAllocation);
                }
                LeaveAllocationCollection.InsertSpName = "spInsertLeaveAllocation";
                LeaveAllocationCollection.UpdateSpName = "spUpdateLeaveAllocation";
                LeaveAllocationCollection.DeleteSpName = "spDeleteLeaveAllocation";
                return LeaveAllocationCollection;
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

  