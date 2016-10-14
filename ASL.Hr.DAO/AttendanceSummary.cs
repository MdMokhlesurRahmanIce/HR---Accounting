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
    public class AttnendanceSummary : BaseItem
    {
        public AttnendanceSummary()
        {
            SetAdded();
        }

        #region Properties

        private System.String _Workdate;
        [Browsable(true), DisplayName("Workdate")]
        public System.String Workdate
        {
            get
            {
                return _Workdate;
            }
            set
            {
                if (PropertyChanged(_Workdate, value))
                    _Workdate = value;
            }
        }
        private System.Int32 _TotalEmployee;
        [Browsable(true), DisplayName("TotalEmployee")]
        public System.Int32 TotalEmployee
        {
            get
            {
                return _TotalEmployee;
            }
            set
            {
                if (PropertyChanged(_TotalEmployee, value))
                    _TotalEmployee = value;
            }
        }

        private System.Int32 _ProcessedEmployee;
        [Browsable(true), DisplayName("ProcessedEmployee")]
        public System.Int32 ProcessedEmployee
        {
            get
            {
                return _ProcessedEmployee;
            }
            set
            {
                if (PropertyChanged(_ProcessedEmployee, value))
                    _ProcessedEmployee = value;
            }
        }

        private System.Int32 _Present;
        [Browsable(true), DisplayName("Present")]
        public System.Int32 Present
        {
            get
            {
                return _Present;
            }
            set
            {
                if (PropertyChanged(_Present, value))
                    _Present = value;
            }
        }

        private System.Int32 _Late;
        [Browsable(true), DisplayName("Late")]
        public System.Int32 Late
        {
            get
            {
                return _Late;
            }
            set
            {
                if (PropertyChanged(_Late, value))
                    _Late = value;
            }
        }

        private System.Int32 _Absent;
        [Browsable(true), DisplayName("Absent")]
        public System.Int32 Absent
        {
            get
            {
                return _Absent;
            }
            set
            {
                if (PropertyChanged(_Absent, value))
                    _Absent = value;
            }
        }

        private System.Int32 _Leave;
        [Browsable(true), DisplayName("Leave")]
        public System.Int32 Leave
        {
            get
            {
                return _Leave;
            }
            set
            {
                if (PropertyChanged(_Leave, value))
                    _Leave = value;
            }
        }

        private System.Int32 _WH;
        [Browsable(true), DisplayName("WH")]
        public System.Int32 WH
        {
            get
            {
                return _WH;
            }
            set
            {
                if (PropertyChanged(_WH, value))
                    _WH = value;
            }
        }

        private System.Int32 _Others;
        [Browsable(true), DisplayName("Others")]
        public System.Int32 Others
        {
            get
            {
                return _Others;
            }
            set
            {
                if (PropertyChanged(_Others, value))
                    _Others = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _TotalEmployee };
            else if (IsModified)
                parameterValues = new Object[] { _TotalEmployee };
            else if (IsDeleted)
                parameterValues = new Object[] { _TotalEmployee };
			return parameterValues;
		}
        protected override void SetData(IDataRecord reader)
        {
            _Workdate = reader.GetString("Workdate");
            _TotalEmployee = reader.GetInt32("TotalEmployee");
            _ProcessedEmployee = reader.GetInt32("ProcessedEmployee");
            _Present = reader.GetInt32("Present");
            _Late = reader.GetInt32("Late");
            _Absent = reader.GetInt32("Absent");
            _Leave = reader.GetInt32("Leave");
            _WH = reader.GetInt32("WH");
            _Others = reader.GetInt32("Others");
            SetUnchanged();
        }
        public static CustomList<AttnendanceSummary> GetAllAttnendanceSummary( string Workdate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<AttnendanceSummary> AttnendanceSummaryCollection = new CustomList<AttnendanceSummary>();
            IDataReader reader = null;
            String sql = "exec spGetAttnSummaryForProcess '" + Workdate +"'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    AttnendanceSummary newAttnendanceSummary = new AttnendanceSummary();
                    newAttnendanceSummary.SetData(reader);
                    AttnendanceSummaryCollection.Add(newAttnendanceSummary);
                }
                AttnendanceSummaryCollection.InsertSpName = "spInsertAttnendanceSummary";
                AttnendanceSummaryCollection.UpdateSpName = "spUpdateAttnendanceSummary";
                AttnendanceSummaryCollection.DeleteSpName = "spDeleteAttnendanceSummary";
                return AttnendanceSummaryCollection;
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