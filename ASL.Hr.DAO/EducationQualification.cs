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
    public class EducationQualification : BaseItem
    {
        public EducationQualification()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _EduQualKey;
        [Browsable(true), DisplayName("EduQualKey")]
        public System.Int32 EduQualKey
        {
            get
            {
                return _EduQualKey;
            }
            set
            {
                if (PropertyChanged(_EduQualKey, value))
                    _EduQualKey = value;
            }
        }

        private System.String _EduQualName;
        [Browsable(true), DisplayName("EduQualName")]
        public System.String EduQualName
        {
            get
            {
                return _EduQualName;
            }
            set
            {
                if (PropertyChanged(_EduQualName, value))
                    _EduQualName = value;
            }
        }

        private System.String _EduQualSName;
        [Browsable(true), DisplayName("EduQualSName")]
        public System.String EduQualSName
        {
            get
            {
                return _EduQualSName;
            }
            set
            {
                if (PropertyChanged(_EduQualSName, value))
                    _EduQualSName = value;
            }
        }

        private System.Int32 _EduLevel;
        [Browsable(true), DisplayName("EduLevel")]
        public System.Int32 EduLevel
        {
            get
            {
                return _EduLevel;
            }
            set
            {
                if (PropertyChanged(_EduLevel, value))
                    _EduLevel = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EduQualName, _EduQualSName, _EduLevel, _Remarks };
            else if (IsModified)
                parameterValues = new Object[] { _EduQualKey, _EduQualName, _EduQualSName, _EduLevel, _Remarks };
            else if (IsDeleted)
                parameterValues = new Object[] { _EduQualKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EduQualKey = reader.GetInt32("EduQualKey");
            _EduQualName = reader.GetString("EduQualName");
            _EduQualSName = reader.GetString("EduQualSName");
            _EduLevel = reader.GetInt32("EduLevel");
            _Remarks = reader.GetString("Remarks");
            SetUnchanged();
        }
        public static CustomList<EducationQualification> GetAllEducationQualification()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<EducationQualification> EducationQualificationCollection = new CustomList<EducationQualification>();
            IDataReader reader = null;
            const String sql = "select * from Gen_EduQual";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    EducationQualification newEducationQualification = new EducationQualification();
                    newEducationQualification.SetData(reader);
                    EducationQualificationCollection.Add(newEducationQualification);
                }
                EducationQualificationCollection.InsertSpName = "spInsertEducationQualification";
                EducationQualificationCollection.UpdateSpName = "spUpdateEducationQualification";
                EducationQualificationCollection.DeleteSpName = "spDeleteEducationQualification";
                return EducationQualificationCollection;
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