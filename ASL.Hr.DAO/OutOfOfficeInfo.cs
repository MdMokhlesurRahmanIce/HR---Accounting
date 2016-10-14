using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using System.Text;
using System.Web;

namespace ASL.Hr.DAO
{
	[Serializable]
	public class OutOfOfficeInfo : BaseItem
	{
		public OutOfOfficeInfo()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int64 _RowID;
		[Browsable(true), DisplayName("RowID")]
		public System.Int64 RowID 
		{
			get
			{
				return _RowID;
			}
			set
			{
			if (PropertyChanged(_RowID, value))
					_RowID = value;
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

		private System.DateTime _Date;
		[Browsable(true), DisplayName("Date"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime Date 
		{
			get
			{
				return _Date;
			}
			set
			{
			if (PropertyChanged(_Date, value))
					_Date = value;
			}
		}

		private System.String _StartTime;
		[Browsable(true), DisplayName("StartTime")]
		public System.String StartTime 
		{
			get
			{
				return _StartTime;
			}
			set
			{
			if (PropertyChanged(_StartTime, value))
					_StartTime = value;
			}
		}

        private System.String _EndTime;
        [Browsable(true), DisplayName("EndTime")]
        public System.String EndTime 
		{
			get
			{
                return _EndTime;
			}
			set
			{
                if (PropertyChanged(_EndTime, value))
                    _EndTime = value;
			}
		}

		private System.String _Project;
		[Browsable(true), DisplayName("Project")]
		public System.String Project 
		{
			get
			{
				return _Project;
			}
			set
			{
			if (PropertyChanged(_Project, value))
					_Project = value;
			}
		}

		private System.String _StayPlace;
		[Browsable(true), DisplayName("StayPlace")]
		public System.String StayPlace 
		{
			get
			{
				return _StayPlace;
			}
			set
			{
			if (PropertyChanged(_StayPlace, value))
					_StayPlace = value;
			}
		}

		private System.String _Reason;
		[Browsable(true), DisplayName("Reason")]
		public System.String Reason 
		{
			get
			{
				return _Reason;
			}
			set
			{
			if (PropertyChanged(_Reason, value))
					_Reason = value;
			}
		}

		private System.String _Remarks;
		[Browsable(true), DisplayName("Remarks")]
		public System.String Remarks 
		{
			get
			{
				return _Remarks;
			}
			set
			{
			if (PropertyChanged(_Remarks, value))
					_Remarks = value;
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

		private System.DateTime _AddedDate;
		[Browsable(true), DisplayName("AddedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime AddedDate 
		{
			get
			{
				return _AddedDate;
			}
			set
			{
			if (PropertyChanged(_AddedDate, value))
					_AddedDate = value;
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

		private System.DateTime _UpdatedDate;
		[Browsable(true), DisplayName("UpdatedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime UpdatedDate 
		{
			get
			{
				return _UpdatedDate;
			}
			set
			{
			if (PropertyChanged(_UpdatedDate, value))
					_UpdatedDate = value;
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

        private System.String _EmpName;
        [Browsable(true), DisplayName("EmpName")]
        public System.String EmpName
        {
            get
            {
                return _EmpName;
            }
            set
            {
                if (PropertyChanged(_EmpName, value))
                    _EmpName = value;
            }
        }
        private System.String _PunchCardNo;
        [Browsable(true), DisplayName("PunchCardNo")]
        public System.String PunchCardNo
        {
            get
            {
                return _PunchCardNo;
            }
            set
            {
                if (PropertyChanged(_PunchCardNo, value))
                    _PunchCardNo = value;
            }
        }

        private System.Boolean _IsDefault;
        [Browsable(true), DisplayName("IsDefault")]
        public System.Boolean IsDefault
        {
            get
            {
                return _IsDefault;
            }
            set
            {
                if (PropertyChanged(_IsDefault, value))
                    _IsDefault = value;
            }
        }
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _Date.Value(StaticInfo.DateFormat), _StartTime, _EndTime, _Project, _StayPlace, _Reason, _Remarks, _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
			else if (IsModified)
                parameterValues = new Object[] { _RowID, _EmpKey, _Date.Value(StaticInfo.DateFormat), _StartTime, _EndTime, _Project, _StayPlace, _Reason, _Remarks, _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
			else if (IsDeleted)
				parameterValues = new Object[] {_RowID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_RowID = reader.GetInt64("RowID");
            _EmpKey = reader.GetInt64("EmpKey");
			_Date = reader.GetDateTime("Date");
			_StartTime = reader.GetString("StartTime");
            _EndTime = reader.GetString("EndTime");
			_Project = reader.GetString("Project");
			_StayPlace = reader.GetString("StayPlace");
			_Reason = reader.GetString("Reason");
			_Remarks = reader.GetString("Remarks");
			_AddedBy = reader.GetString("AddedBy");
			_AddedDate = reader.GetDateTime("AddedDate");
			_UpdatedBy = reader.GetString("UpdatedBy");
			_UpdatedDate = reader.GetDateTime("UpdatedDate");
            //_EmpName = reader.GetString("EmpName");
            //_PunchCardNo = reader.GetString("PunchCardNo");
           // _IsDefault = reader.GetBoolean("IsDefault");

			SetUnchanged();
		}
		public static CustomList<OutOfOfficeInfo> GetAllOutOfOfficeInfo()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<OutOfOfficeInfo> OutOfOfficeInfoCollection = new CustomList<OutOfOfficeInfo>();
			IDataReader reader = null;
			const String sql = "select *from OutOfOfficeInfo";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					OutOfOfficeInfo newOutOfOfficeInfo = new OutOfOfficeInfo();
					newOutOfOfficeInfo.SetData(reader);
					OutOfOfficeInfoCollection.Add(newOutOfOfficeInfo);
				}
				OutOfOfficeInfoCollection.InsertSpName = "spInsertOutOfOfficeInfo";
				OutOfOfficeInfoCollection.UpdateSpName = "spUpdateOutOfOfficeInfo";
				OutOfOfficeInfoCollection.DeleteSpName = "spDeleteOutOfOfficeInfo";
				return OutOfOfficeInfoCollection;
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
        public static CustomList<OutOfOfficeInfo> GetAllOutOutOfOfficeEntry(string date)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<OutOfOfficeInfo> OutOfOfficeInfoCollection = new CustomList<OutOfOfficeInfo>();
            StringBuilder searchArg = new StringBuilder();
            searchArg = (StringBuilder)HttpContext.Current.Session[StaticInfo.SearchArg];


            if (searchArg == null) return OutOfOfficeInfoCollection;

            string search = String.Empty;
            search = searchArg.ToString();
            search = search + "@Date=" + "'" + date + "',";
            search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;


            IDataReader reader = null;
            try
            {
                String sql = "EXEC spGetOutOfOfficeEntryEmpList " + search + "";
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    OutOfOfficeInfo newOutOfOfficeInfo = new OutOfOfficeInfo();
                    newOutOfOfficeInfo.SetData(reader);
                    newOutOfOfficeInfo.EmpName = reader.GetString("EmpName");
                    newOutOfOfficeInfo.PunchCardNo = reader.GetString("PunchCardNo");
                    newOutOfOfficeInfo.IsDefault = reader.GetBoolean("IsDefault");
                    OutOfOfficeInfoCollection.Add(newOutOfOfficeInfo);
                }
                return OutOfOfficeInfoCollection;
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
        public static CustomList<OutOfOfficeInfo> GetExistingEntry(string fromDate,string toDate, string empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<OutOfOfficeInfo> OutOfOfficeInfoCollection = new CustomList<OutOfOfficeInfo>();
            IDataReader reader = null;
            try
            {
                String sql = "EXEC spGetOutOfOfficeEntry '" + fromDate + "','" + toDate + "','" + empKey+"'";
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    OutOfOfficeInfo newOutOfOfficeInfo = new OutOfOfficeInfo();
                    newOutOfOfficeInfo.SetData(reader);
                    newOutOfOfficeInfo.EmpCode = reader.GetString("EmpCode");
                    newOutOfOfficeInfo.EmpName = reader.GetString("EmpName");
                    OutOfOfficeInfoCollection.Add(newOutOfOfficeInfo);
                }
                return OutOfOfficeInfoCollection;
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
