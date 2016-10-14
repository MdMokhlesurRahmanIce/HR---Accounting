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
    public class HRM_EmpFileAttach : BaseItem
    {
        public HRM_EmpFileAttach()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _EmpAttachKey;
        [Browsable(true), DisplayName("EmpAttachKey")]
        public System.Int64 EmpAttachKey
        {
            get
            {
                return _EmpAttachKey;
            }
            set
            {
                if (PropertyChanged(_EmpAttachKey, value))
                    _EmpAttachKey = value;
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

        private System.String _FilePath;
        [Browsable(true), DisplayName("FilePath")]
        public System.String FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                if (PropertyChanged(_FilePath, value))
                    _FilePath = value;
            }
        }

        private System.String _FileName;
        [Browsable(true), DisplayName("FileName")]
        public System.String FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                if (PropertyChanged(_FileName, value))
                    _FileName = value;
            }
        }

        private System.DateTime _AttachDate;
        [Browsable(true), DisplayName("AttachDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime AttachDate
        {
            get
            {
                return _AttachDate;
            }
            set
            {
                if (PropertyChanged(_AttachDate, value))
                    _AttachDate = value;
            }
        }

        private System.String _AttachDesc;
        [Browsable(true), DisplayName("AttachDesc")]
        public System.String AttachDesc
        {
            get
            {
                return _AttachDesc;
            }
            set
            {
                if (PropertyChanged(_AttachDesc, value))
                    _AttachDesc = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _FilePath, _FileName, _AttachDate.Value(StaticInfo.DateFormat), _AttachDesc };
            else if (IsModified)
                parameterValues = new Object[] { _EmpAttachKey, _EmpKey, _FilePath, _FileName, _AttachDate.Value(StaticInfo.DateFormat), _AttachDesc };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpAttachKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EmpAttachKey = reader.GetInt64("EmpAttachKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _FilePath = reader.GetString("FilePath");
            _FileName = reader.GetString("FileName");
            _AttachDate = reader.GetDateTime("AttachDate");
            _AttachDesc = reader.GetString("AttachDesc");
            SetUnchanged();
        }
        public static CustomList<HRM_EmpFileAttach> GetAllHRM_EmpFileAttach()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpFileAttach> HRM_EmpFileAttachCollection = new CustomList<HRM_EmpFileAttach>();
            IDataReader reader = null;
            const String sql = "select * from HRM_EmpFileAttach";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpFileAttach newHRM_EmpFileAttach = new HRM_EmpFileAttach();
                    newHRM_EmpFileAttach.SetData(reader);
                    HRM_EmpFileAttachCollection.Add(newHRM_EmpFileAttach);
                }
                HRM_EmpFileAttachCollection.InsertSpName = "spInsertHRM_EmpFileAttach";
                HRM_EmpFileAttachCollection.UpdateSpName = "spUpdateHRM_EmpFileAttach";
                HRM_EmpFileAttachCollection.DeleteSpName = "spDeleteHRM_EmpFileAttach";
                return HRM_EmpFileAttachCollection;
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

        public static CustomList<HRM_EmpFileAttach> GetAllEmpfileByEmpKey(string EmpKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpFileAttach> HRM_EmpFileAttachCollection = new CustomList<HRM_EmpFileAttach>();
            IDataReader reader = null;
            String sql = "select * from HRM_EmpFileAttach where empkey = " + EmpKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpFileAttach newHRM_EmpFileAttach = new HRM_EmpFileAttach();
                    newHRM_EmpFileAttach.SetData(reader);
                    HRM_EmpFileAttachCollection.Add(newHRM_EmpFileAttach);
                }
                HRM_EmpFileAttachCollection.InsertSpName = "spInsertHRM_EmpFileAttach";
                HRM_EmpFileAttachCollection.UpdateSpName = "spUpdateHRM_EmpFileAttach";
                HRM_EmpFileAttachCollection.DeleteSpName = "spDeleteHRM_EmpFileAttach";
                return HRM_EmpFileAttachCollection;
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
        public static HRM_EmpFileAttach GetEmpfileByEmpKey(long EmpKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            //CustomList<HRM_EmpFileAttach> HRM_EmpFileAttachCollection = new CustomList<HRM_EmpFileAttach>();
            IDataReader reader = null;
            String sql = "select * from HRM_EmpFileAttach where empkey = " + EmpKey;
            try
            {
                HRM_EmpFileAttach newHRM_EmpFileAttach = new HRM_EmpFileAttach();
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    newHRM_EmpFileAttach.SetData(reader);
                }
                return newHRM_EmpFileAttach;
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