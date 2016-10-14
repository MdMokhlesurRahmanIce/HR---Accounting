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
    public class ATT_IO : BaseItem
    {
        public ATT_IO()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _IOKey;
        [Browsable(true), DisplayName("IOKey")]
        public System.Int64 IOKey
        {
            get
            {
                return _IOKey;
            }
            set
            {
                if (PropertyChanged(_IOKey, value))
                    _IOKey = value;
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

        private System.DateTime _AttDate;
        [Browsable(true), DisplayName("AttDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime AttDate
        {
            get
            {
                return _AttDate;
            }
            set
            {
                if (PropertyChanged(_AttDate, value))
                    _AttDate = value;
            }
        }

        private System.TimeSpan _InTime;
        [Browsable(true), DisplayName("InTime")]
        public System.TimeSpan InTime
        {
            get
            {
                return _InTime;
            }
            set
            {
                if (PropertyChanged(_InTime, value))
                    _InTime = value;
            }
        }

        private System.TimeSpan _OutTime;
        [Browsable(true), DisplayName("OutTime")]
        public System.TimeSpan OutTime
        {
            get
            {
                return _OutTime;
            }
            set
            {
                if (PropertyChanged(_OutTime, value))
                    _OutTime = value;
            }
        }

        private System.String _AttID;
        [Browsable(true), DisplayName("AttID")]
        public System.String AttID
        {
            get
            {
                return _AttID;
            }
            set
            {
                if (PropertyChanged(_AttID, value))
                    _AttID = value;
            }
        }

        private System.String _IOFileRef;
        [Browsable(true), DisplayName("IOFileRef")]
        public System.String IOFileRef
        {
            get
            {
                return _IOFileRef;
            }
            set
            {
                if (PropertyChanged(_IOFileRef, value))
                    _IOFileRef = value;
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

        private System.Boolean _IsManual;
        [Browsable(true), DisplayName("IsManual")]
        public System.Boolean IsManual
        {
            get
            {
                return _IsManual;
            }
            set
            {
                if (PropertyChanged(_IsManual, value))
                    _IsManual = value;
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
        private System.String _DesigName;
        [Browsable(true), DisplayName("DesigName")]
        public System.String DesigName
        {
            get
            {
                return _DesigName;
            }
            set
            {
                if (PropertyChanged(_DesigName, value))
                    _DesigName = value;
            }
        }
        private System.String _OrgName;
        [Browsable(true), DisplayName("OrgName")]
        public System.String OrgName
        {
            get
            {
                return _OrgName;
            }
            set
            {
                if (PropertyChanged(_OrgName, value))
                    _OrgName = value;
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

        //Shamim Added

        private System.Int32 _RowID;
        [Browsable(true), DisplayName("RowID")]
        public System.Int32 RowID
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

        private System.String _EmployeeCode;
        [Browsable(true), DisplayName("EmployeeCode")]
        public System.String EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
            set
            {
                if (PropertyChanged(_EmployeeCode, value))
                    _EmployeeCode = value;
            }
        }

        private System.String _PTime;
        [Browsable(true), DisplayName("PTime")]
        public System.String PTime
        {
            get
            {
                return _PTime;
            }
            set
            {
                if (PropertyChanged(_PTime, value))
                    _PTime = value;
            }
        }

        private System.DateTime _WorkDate;
        [Browsable(true), DisplayName("WorkDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime WorkDate
        {
            get
            {
                return _WorkDate;
            }
            set
            {
                if (PropertyChanged(_WorkDate, value))
                    _WorkDate = value;
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

        private System.String _PunchType;
        [Browsable(true), DisplayName("PunchType")]
        public System.String PunchType
        {
            get
            {
                return _PunchType;
            }
            set
            {
                if (PropertyChanged(_PunchType, value))
                    _PunchType = value;
            }
        }

        private System.String _DeviceID;
        [Browsable(true), DisplayName("DeviceID")]
        public System.String DeviceID
        {
            get
            {
                return _DeviceID;
            }
            set
            {
                if (PropertyChanged(_DeviceID, value))
                    _DeviceID = value;
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
        #endregion
        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpCode, _PTime, _WorkDate, _PunchCardNo, _PunchType, _DeviceID, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat) };
            else if (IsModified)
                parameterValues = new Object[] { _RowID, _EmpCode, _PTime, _WorkDate, _PunchCardNo, _PunchType, _DeviceID, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat) };
            else if (IsDeleted)
                parameterValues = new Object[] { _RowID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _IOKey = reader.GetInt64("IOKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _AttDate = reader.GetDateTime("AttDate");
            _InTime = (TimeSpan)reader["InTime"];
            _OutTime = (TimeSpan)reader["OutTime"];
            _AttID = reader.GetString("AttID");
            _IOFileRef = reader.GetString("IOFileRef");
            _Remarks = reader.GetString("Remarks");
            _IsManual = reader.GetBoolean("IsManual");
            SetUnchanged();
        }
        private void SetDataAtt(IDataRecord reader)
        {
            _IOKey = reader.GetInt64("IOKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _DesigName = reader.GetString("DesigName");
            _OrgName = reader.GetString("OrgName");
            _AttDate = reader.GetDateTime("AttDate");
            _InTime = (TimeSpan)reader["InTime"];
            _OutTime = (TimeSpan)reader["OutTime"];
            _IsManual = reader.GetBoolean("IsManual");
            SetUnchanged();
        }
        //protected override void SetData(IDataRecord reader)
        //{
        //    _RowID = reader.GetInt32("RowID");
        //    _EmployeeCode = reader.GetString("EmployeeCode");
        //    _PTime = reader.GetString("PTime");
        //    _WorkDate = reader.GetDateTime("WorkDate");
        //    _PunchCardNo = reader.GetString("PunchCardNo");
        //    _PunchType = reader.GetString("PunchType");
        //    _DeviceID = reader.GetString("DeviceID");
        //    _AddedBy = reader.GetString("AddedBy");
        //    _DateAdded = reader.GetDateTime("DateAdded");
        //    SetUnchanged();
        //}
        //public static CustomList<2012-6> GetAll2012-6()
        //{
        //    ConnectionManager conManager = new ConnectionManager(ConnectionName.OTS);
        //    CustomList<2012-6> 2012-6Collection = new CustomList<2012-6>();
        //    IDataReader reader = null;
        //    const String sql = "select *from [2012-6]";
        //    try
        //    {
        //        conManager.OpenDataReader(sql, out reader);
        //        while (reader.Read())
        //        {
        //            2012-6 new2012-6 = new 2012-6();
        //            new2012-6.SetData(reader);
        //            2012-6Collection.Add(new2012-6);
        //        }
        //        2012-6Collection.InsertSpName = "spInsert2012-6";
        //        2012-6Collection.UpdateSpName = "spUpdate2012-6";
        //        2012-6Collection.DeleteSpName = "spDelete2012-6";
        //        return 2012-6Collection;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        if (reader != null && !reader.IsClosed)
        //            reader.Close();
        //    }
        //}
        public static CustomList<ATT_IO> GetAllATT_IO()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ATT_IO> ATT_IOCollection = new CustomList<ATT_IO>();
            IDataReader reader = null;
            const String sql = "Select * From ATT_IO";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ATT_IO newATT_IO = new ATT_IO();
                    newATT_IO.SetData(reader);
                    ATT_IOCollection.Add(newATT_IO);
                }
                ATT_IOCollection.InsertSpName = "spInsertATT_IO";
                ATT_IOCollection.UpdateSpName = "spUpdateATT_IO";
                ATT_IOCollection.DeleteSpName = "spDeleteATT_IO";
                return ATT_IOCollection;
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
        public static CustomList<ATT_IO> GetAllAttForManualProcess(string date)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ATT_IO> ATT_IOCollection = new CustomList<ATT_IO>();
            StringBuilder searchArg = new StringBuilder();
            searchArg = (StringBuilder)HttpContext.Current.Session[StaticInfo.SearchArg];


            if (searchArg == null) return ATT_IOCollection;

            string search = String.Empty;
            search = searchArg.ToString();
            search = search + "@Date=" + "'" + date + "',";
            search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;


            IDataReader reader = null;
            try
            {
                String sql = "EXEC spGetAllEmpForManualAttandanceProcess " + search + "";
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ATT_IO newAtt_IO = new ATT_IO();
                    newAtt_IO.SetDataAtt(reader);
                    ATT_IOCollection.Add(newAtt_IO);
                }
                return ATT_IOCollection;
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