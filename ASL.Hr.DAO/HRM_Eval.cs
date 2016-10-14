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
    public class HRM_Eval : BaseItem
    {
        public HRM_Eval()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _EvalKey;
        [Browsable(true), DisplayName("EvalKey")]
        public System.Int64 EvalKey
        {
            get
            {
                return _EvalKey;
            }
            set
            {
                if (PropertyChanged(_EvalKey, value))
                    _EvalKey = value;
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

                _EmpName = value;
            }
        }

        private System.DateTime _EvalDate;
        [Browsable(true), DisplayName("EvalDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EvalDate
        {
            get
            {
                return _EvalDate;
            }
            set
            {
                if (PropertyChanged(_EvalDate, value))
                    _EvalDate = value;
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

        private System.DateTime _EvalFrom;
        [Browsable(true), DisplayName("EvalFrom"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EvalFrom
        {
            get
            {
                return _EvalFrom;
            }
            set
            {
                if (PropertyChanged(_EvalFrom, value))
                    _EvalFrom = value;
            }
        }

        private System.DateTime _EvalTo;
        [Browsable(true), DisplayName("EvalTo"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EvalTo
        {
            get
            {
                return _EvalTo;
            }
            set
            {
                if (PropertyChanged(_EvalTo, value))
                    _EvalTo = value;
            }
        }

        private System.String _ImproveSugg;
        [Browsable(true), DisplayName("ImproveSugg")]
        public System.String ImproveSugg
        {
            get
            {
                return _ImproveSugg;
            }
            set
            {
                if (PropertyChanged(_ImproveSugg, value))
                    _ImproveSugg = value;
            }
        }

        private System.String _EmpComntAck;
        [Browsable(true), DisplayName("EmpComntAck")]
        public System.String EmpComntAck
        {
            get
            {
                return _EmpComntAck;
            }
            set
            {
                if (PropertyChanged(_EmpComntAck, value))
                    _EmpComntAck = value;
            }
        }

        private System.String _EvalRecom;
        [Browsable(true), DisplayName("EvalRecom")]
        public System.String EvalRecom
        {
            get
            {
                return _EvalRecom;
            }
            set
            {
                if (PropertyChanged(_EvalRecom, value))
                    _EvalRecom = value;
            }
        }

        private System.String _ReviewRecom;
        [Browsable(true), DisplayName("ReviewRecom")]
        public System.String ReviewRecom
        {
            get
            {
                return _ReviewRecom;
            }
            set
            {
                if (PropertyChanged(_ReviewRecom, value))
                    _ReviewRecom = value;
            }
        }

        private System.String _Comment;
        [Browsable(true), DisplayName("Comment")]
        public System.String Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                if (PropertyChanged(_Comment, value))
                    _Comment = value;
            }
        }

        private System.Decimal _GrossJoinSal;
        [Browsable(true), DisplayName("GrossJoinSal")]
        public System.Decimal GrossJoinSal
        {
            get
            {
                return _GrossJoinSal;
            }
            set
            {
                if (PropertyChanged(_GrossJoinSal, value))
                    _GrossJoinSal = value;
            }
        }

        private System.Decimal _GrossPreviousSal;
        [Browsable(true), DisplayName("GrossPreviousSal")]
        public System.Decimal GrossPreviousSal
        {
            get
            {
                return _GrossPreviousSal;
            }
            set
            {
                if (PropertyChanged(_GrossPreviousSal, value))
                    _GrossPreviousSal = value;
            }
        }

        private System.Decimal _GrossPresentSal;
        [Browsable(true), DisplayName("GrossPresentSal")]
        public System.Decimal GrossPresentSal
        {
            get
            {
                return _GrossPresentSal;
            }
            set
            {
                if (PropertyChanged(_GrossPresentSal, value))
                    _GrossPresentSal = value;
            }
        }

        private System.Decimal _GrossProposedSal;
        [Browsable(true), DisplayName("GrossProposedSal")]
        public System.Decimal GrossProposedSal
        {
            get
            {
                return _GrossProposedSal;
            }
            set
            {
                if (PropertyChanged(_GrossProposedSal, value))
                    _GrossProposedSal = value;
            }
        }

        private System.DateTime _DateJoin;
        [Browsable(true), DisplayName("DateJoin"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateJoin
        {
            get
            {
                return _DateJoin;
            }
            set
            {
                if (PropertyChanged(_DateJoin, value))
                    _DateJoin = value;
            }
        }

        private System.DateTime _DatePrevious;
        [Browsable(true), DisplayName("DatePrevious"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DatePrevious
        {
            get
            {
                return _DatePrevious;
            }
            set
            {
                if (PropertyChanged(_DatePrevious, value))
                    _DatePrevious = value;
            }
        }

        private System.DateTime _DatePresent;
        [Browsable(true), DisplayName("DatePresent"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DatePresent
        {
            get
            {
                return _DatePresent;
            }
            set
            {
                if (PropertyChanged(_DatePresent, value))
                    _DatePresent = value;
            }
        }

        private System.DateTime _DatePreposed;
        [Browsable(true), DisplayName("DatePreposed"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DatePreposed
        {
            get
            {
                return _DatePreposed;
            }
            set
            {
                if (PropertyChanged(_DatePreposed, value))
                    _DatePreposed = value;
            }
        }

        private System.DateTime _LastPromDate;
        [Browsable(true), DisplayName("LastPromDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime LastPromDate
        {
            get
            {
                return _LastPromDate;
            }
            set
            {
                if (PropertyChanged(_LastPromDate, value))
                    _LastPromDate = value;
            }
        }

        private System.Int32 _ToBePromoted;
        [Browsable(true), DisplayName("ToBePromoted")]
        public System.Int32 ToBePromoted
        {
            get
            {
                return _ToBePromoted;
            }
            set
            {
                if (PropertyChanged(_ToBePromoted, value))
                    _ToBePromoted = value;
            }
        }

        private System.Int32 _OtherRecom;
        [Browsable(true), DisplayName("OtherRecom")]
        public System.Int32 OtherRecom
        {
            get
            {
                return _OtherRecom;
            }
            set
            {
                if (PropertyChanged(_OtherRecom, value))
                    _OtherRecom = value;
            }
        }

        private System.String _M_LYSpQual;
        [Browsable(true), DisplayName("M_LYSpQual")]
        public System.String M_LYSpQual
        {
            get
            {
                return _M_LYSpQual;
            }
            set
            {
                if (PropertyChanged(_M_LYSpQual, value))
                    _M_LYSpQual = value;
            }
        }

        private System.String _M_LYShortComing;
        [Browsable(true), DisplayName("M_LYShortComing")]
        public System.String M_LYShortComing
        {
            get
            {
                return _M_LYShortComing;
            }
            set
            {
                if (PropertyChanged(_M_LYShortComing, value))
                    _M_LYShortComing = value;
            }
        }

        private System.String _M_LYSugg;
        [Browsable(true), DisplayName("M_LYSugg")]
        public System.String M_LYSugg
        {
            get
            {
                return _M_LYSugg;
            }
            set
            {
                if (PropertyChanged(_M_LYSugg, value))
                    _M_LYSugg = value;
            }
        }

        private System.String _M_LYTraining;
        [Browsable(true), DisplayName("M_LYTraining")]
        public System.String M_LYTraining
        {
            get
            {
                return _M_LYTraining;
            }
            set
            {
                if (PropertyChanged(_M_LYTraining, value))
                    _M_LYTraining = value;
            }
        }

        private System.String _M_CYSpQual;
        [Browsable(true), DisplayName("M_CYSpQual")]
        public System.String M_CYSpQual
        {
            get
            {
                return _M_CYSpQual;
            }
            set
            {
                if (PropertyChanged(_M_CYSpQual, value))
                    _M_CYSpQual = value;
            }
        }

        private System.String _M_CYShortComing;
        [Browsable(true), DisplayName("M_CYShortComing")]
        public System.String M_CYShortComing
        {
            get
            {
                return _M_CYShortComing;
            }
            set
            {
                if (PropertyChanged(_M_CYShortComing, value))
                    _M_CYShortComing = value;
            }
        }

        private System.String _M_CYSugg;
        [Browsable(true), DisplayName("M_CYSugg")]
        public System.String M_CYSugg
        {
            get
            {
                return _M_CYSugg;
            }
            set
            {
                if (PropertyChanged(_M_CYSugg, value))
                    _M_CYSugg = value;
            }
        }

        private System.String _M_CYTraining;
        [Browsable(true), DisplayName("M_CYTraining")]
        public System.String M_CYTraining
        {
            get
            {
                return _M_CYTraining;
            }
            set
            {
                if (PropertyChanged(_M_CYTraining, value))
                    _M_CYTraining = value;
            }
        }
        
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EvalDate.Value(StaticInfo.DateFormat), _EmpKey, _EvalFrom.Value(StaticInfo.DateFormat), _EvalTo.Value(StaticInfo.DateFormat), _ImproveSugg, _EmpComntAck, _EvalRecom, _ReviewRecom, _Comment, _DateJoin.Value(StaticInfo.DateFormat), _DatePrevious.Value(StaticInfo.DateFormat), _DatePresent.Value(StaticInfo.DateFormat), _DatePreposed.Value(StaticInfo.DateFormat), _GrossJoinSal, _GrossPreviousSal, _GrossPresentSal, _GrossProposedSal, _LastPromDate.Value(StaticInfo.DateFormat), _ToBePromoted, _OtherRecom, _M_LYSpQual, _M_LYShortComing, _M_LYSugg, _M_LYTraining, _M_CYSpQual, _M_CYShortComing, _M_CYSugg, _M_CYTraining };
            else if (IsModified)
                parameterValues = new Object[] { _EvalKey, _EvalDate.Value(StaticInfo.DateFormat), _EmpKey, _EvalFrom.Value(StaticInfo.DateFormat), _EvalTo.Value(StaticInfo.DateFormat), _ImproveSugg, _EmpComntAck, _EvalRecom, _ReviewRecom, _Comment, _DateJoin.Value(StaticInfo.DateFormat), _DatePrevious.Value(StaticInfo.DateFormat), _DatePresent.Value(StaticInfo.DateFormat), _DatePreposed.Value(StaticInfo.DateFormat), _GrossJoinSal, _GrossPreviousSal, _GrossPresentSal, _GrossProposedSal, _LastPromDate.Value(StaticInfo.DateFormat), _ToBePromoted, _OtherRecom, _M_LYSpQual, _M_LYShortComing, _M_LYSugg, _M_LYTraining, _M_CYSpQual, _M_CYShortComing, _M_CYSugg, _M_CYTraining };
            else if (IsDeleted)
                parameterValues = new Object[] { _EvalKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EvalKey = reader.GetInt64("EvalKey");
            _EvalDate = reader.GetDateTime("EvalDate");
            _EmpKey = reader.GetInt64("EmpKey");
            _EvalFrom = reader.GetDateTime("EvalFrom");
            _EvalTo = reader.GetDateTime("EvalTo");
            _ImproveSugg = reader.GetString("ImproveSugg");
            _EmpComntAck = reader.GetString("EmpComntAck");
            _EvalRecom = reader.GetString("EvalRecom");
            _ReviewRecom = reader.GetString("ReviewRecom");
            _Comment = reader.GetString("Comment");
            _DateJoin = reader.GetDateTime("DateJoin");
            _DatePrevious = reader.GetDateTime("DatePrevious");
            _DatePresent = reader.GetDateTime("DatePresent");
            _DatePreposed = reader.GetDateTime("DatePreposed");
            _GrossJoinSal = reader.GetDecimal("GrossJoinSal");
            _GrossPreviousSal = reader.GetDecimal("GrossPreviousSal");
            _GrossPresentSal = reader.GetDecimal("GrossPresentSal");
            _GrossProposedSal = reader.GetDecimal("GrossProposedSal");
            _LastPromDate = reader.GetDateTime("LastPromDate");
            _ToBePromoted = reader.GetInt32("ToBePromoted");
            _OtherRecom = reader.GetInt32("OtherRecom");
            _M_LYSpQual = reader.GetString("M_LYSpQual");
            _M_LYShortComing = reader.GetString("M_LYShortComing");
            _M_LYSugg = reader.GetString("M_LYSugg");
            _M_LYTraining = reader.GetString("M_LYTraining");
            _M_CYSpQual = reader.GetString("M_CYSpQual");
            _M_CYShortComing = reader.GetString("M_CYShortComing");
            _M_CYSugg = reader.GetString("M_CYSugg");
            _M_CYTraining = reader.GetString("M_CYTraining");
            SetUnchanged();
        }
        private void SetDataEmp(IDataRecord reader)
        {
            _EmpName = reader.GetString("EmpName");
            SetUnchanged();
        }

        public static CustomList<HRM_Eval> GetAllHRM_Eval()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Eval> HRM_EvalCollection = new CustomList<HRM_Eval>();
            IDataReader reader = null;
            const String sql = "Select * from HRM_Eval";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Eval newHRM_Eval = new HRM_Eval();
                    newHRM_Eval.SetData(reader);
                    HRM_EvalCollection.Add(newHRM_Eval);
                }
                HRM_EvalCollection.InsertSpName = "spInsertHRM_Eval";
                HRM_EvalCollection.UpdateSpName = "spUpdateHRM_Eval";
                HRM_EvalCollection.DeleteSpName = "spDeleteHRM_Eval";
                return HRM_EvalCollection;
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

        public static CustomList<HRM_Eval> GetAllHRM_Eval(String EvalKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Eval> HRM_EvalCollection = new CustomList<HRM_Eval>();
            IDataReader reader = null;
            String sql = "Select * from HRM_Eval Where EvalKey='" + EvalKey + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Eval newHRM_Eval = new HRM_Eval();
                    newHRM_Eval.SetData(reader);
                    HRM_EvalCollection.Add(newHRM_Eval);
                }
                HRM_EvalCollection.InsertSpName = "spInsertHRM_Eval";
                HRM_EvalCollection.UpdateSpName = "spUpdateHRM_Eval";
                HRM_EvalCollection.DeleteSpName = "spDeleteHRM_Eval";
                return HRM_EvalCollection;
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

        public static CustomList<HRM_Eval> doSearch(string whereClause)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Eval> HRM_EvalCollection = new CustomList<HRM_Eval>();
            StringBuilder searchArg;
            searchArg = (StringBuilder)HttpContext.Current.Session[StaticInfo.SearchArg];

            if (searchArg == null && whereClause == "") return HRM_EvalCollection;

            string search = String.Empty;
            search = searchArg.ToString();
            IDataReader reader = null;
            String sql = String.Empty;

            sql = "Select * from HRM_Eval Inner join HRM_Emp on HRM_Emp.EmpKey=HRM_Eval.EmpKey WHERE HRM_Eval.EmpKey=" + whereClause + "";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Eval newHRM_Emp = new HRM_Eval();
                    newHRM_Emp.SetData(reader);
                    newHRM_Emp.SetDataEmp(reader);
                    HRM_EvalCollection.Add(newHRM_Emp);
                }

                HRM_EvalCollection.InsertSpName = "spInsertHRM_Eval";
                HRM_EvalCollection.UpdateSpName = "spUpdateHRM_Eval";
                HRM_EvalCollection.DeleteSpName = "spDeleteHRM_Eval";
                return HRM_EvalCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }

                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}