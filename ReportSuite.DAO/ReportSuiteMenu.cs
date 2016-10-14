using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ReportSuite.DAO
{
    [Serializable]
    public class ReportSuiteMenu : BaseItem
    {
        public ReportSuiteMenu()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _REPORTID;
        [Browsable(true), DisplayName("REPORTID")]
        public System.Int32 REPORTID
        {
            get
            {
                return _REPORTID;
            }
            set
            {
                if (PropertyChanged(_REPORTID, value))
                    _REPORTID = value;
            }
        }

        private System.Int32 _PARENT_KEY;
        [Browsable(true), DisplayName("PARENT_KEY")]
        public System.Int32 PARENT_KEY
        {
            get
            {
                return _PARENT_KEY;
            }
            set
            {
                if (PropertyChanged(_PARENT_KEY, value))
                    _PARENT_KEY = value;
            }
        }

        private System.Int32 _NODE_KEY;
        [Browsable(true), DisplayName("NODE_KEY")]
        public System.Int32 NODE_KEY
        {
            get
            {
                return _NODE_KEY;
            }
            set
            {
                if (PropertyChanged(_NODE_KEY, value))
                    _NODE_KEY = value;
            }
        }

        private System.String _NODE_TEXT;
        [Browsable(true), DisplayName("NODE_TEXT")]
        public System.String NODE_TEXT
        {
            get
            {
                return _NODE_TEXT;
            }
            set
            {
                if (PropertyChanged(_NODE_TEXT, value))
                    _NODE_TEXT = value;
            }
        }

        private System.String _REPORT_NAME;
        [Browsable(true), DisplayName("REPORT_NAME")]
        public System.String REPORT_NAME
        {
            get
            {
                return _REPORT_NAME;
            }
            set
            {
                if (PropertyChanged(_REPORT_NAME, value))
                    _REPORT_NAME = value;
            }
        }

        private System.String _REPORT_PATH_NAME;
        [Browsable(true), DisplayName("REPORT_PATH_NAME")]
        public System.String REPORT_PATH_NAME
        {
            get
            {
                return _REPORT_PATH_NAME;
            }
            set
            {
                if (PropertyChanged(_REPORT_PATH_NAME, value))
                    _REPORT_PATH_NAME = value;
            }
        }

        private System.String _REPORT_SQL;
        [Browsable(true), DisplayName("REPORT_SQL")]
        public System.String REPORT_SQL
        {
            get
            {
                return _REPORT_SQL;
            }
            set
            {
                if (PropertyChanged(_REPORT_SQL, value))
                    _REPORT_SQL = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _REPORTID, _PARENT_KEY, _NODE_KEY, _NODE_TEXT, _REPORT_NAME, _REPORT_PATH_NAME, _REPORT_SQL };
            else if (IsModified)
                parameterValues = new Object[] { _REPORTID, _PARENT_KEY, _NODE_KEY, _NODE_TEXT, _REPORT_NAME, _REPORT_PATH_NAME, _REPORT_SQL };
            else if (IsDeleted)
                parameterValues = new Object[] { _REPORTID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _REPORTID = reader.GetInt32("REPORTID");
            _PARENT_KEY = reader.GetInt32("PARENT_KEY");
            _NODE_KEY = reader.GetInt32("NODE_KEY");
            _NODE_TEXT = reader.GetString("NODE_TEXT");
            _REPORT_NAME = reader.GetString("REPORT_NAME");
            _REPORT_PATH_NAME = reader.GetString("REPORT_PATH_NAME");
            _REPORT_SQL = reader.GetString("REPORT_SQL");
            SetUnchanged();
        }
        public static CustomList<ReportSuiteMenu> GetReportSuiteMenu(string userCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ReportSuiteMenu> ReportSuiteMenuCollection = new CustomList<ReportSuiteMenu>();
            IDataReader reader = null;
            String sql = "EXEC spGetUserWiseTreeMenu";//'" + userCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ReportSuiteMenu newReportSuiteMenu = new ReportSuiteMenu();
                    newReportSuiteMenu.SetData(reader);
                    ReportSuiteMenuCollection.Add(newReportSuiteMenu);
                }
                return ReportSuiteMenuCollection;
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
        public static CustomList<ReportSuiteMenu> GetReportSuiteMenu()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ReportSuiteMenu> ReportSuiteMenuCollection = new CustomList<ReportSuiteMenu>();
            IDataReader reader = null;
            String sql = "EXEC spGetUserWiseProfileReport";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ReportSuiteMenu newReportSuiteMenu = new ReportSuiteMenu();
                    newReportSuiteMenu.SetData(reader);
                    ReportSuiteMenuCollection.Add(newReportSuiteMenu);
                }
                return ReportSuiteMenuCollection;
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