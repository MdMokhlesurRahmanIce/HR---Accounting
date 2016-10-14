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
    public class Gen_Exam : BaseItem
    {
        public Gen_Exam()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _ExamKey;
        [Browsable(true), DisplayName("ExamKey")]
        public System.Int32 ExamKey
        {
            get
            {
                return _ExamKey;
            }
            set
            {
                if (PropertyChanged(_ExamKey, value))
                    _ExamKey = value;
            }
        }

        private System.String _ExamName;
        [Browsable(true), DisplayName("ExamName")]
        public System.String ExamName
        {
            get
            {
                return _ExamName;
            }
            set
            {
                if (PropertyChanged(_ExamName, value))
                    _ExamName = value;
            }
        }

        private System.String _ExamSName;
        [Browsable(true), DisplayName("ExamSName")]
        public System.String ExamSName
        {
            get
            {
                return _ExamSName;
            }
            set
            {
                if (PropertyChanged(_ExamSName, value))
                    _ExamSName = value;
            }
        }

        private System.Int32 _ExamLevel;
        [Browsable(true), DisplayName("ExamLevel")]
        public System.Int32 ExamLevel
        {
            get
            {
                return _ExamLevel;
            }
            set
            {
                if (PropertyChanged(_ExamLevel, value))
                    _ExamLevel = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ExamName, _ExamSName, _ExamLevel };
            else if (IsModified)
                parameterValues = new Object[] { _ExamName, _ExamSName, _ExamLevel };
            else if (IsDeleted)
                parameterValues = new Object[] { _ExamKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ExamKey = reader.GetInt32("ExamKey");
            _ExamName = reader.GetString("ExamName");
            _ExamSName = reader.GetString("ExamSName");
            _ExamLevel = reader.GetInt32("ExamLevel");
            SetUnchanged();
        }
        public static CustomList<Gen_Exam> GetAllGen_Exam()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_Exam> Gen_ExamCollection = new CustomList<Gen_Exam>();
            IDataReader reader = null;
            const String sql = "select * from gen_exam";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_Exam newGen_Exam = new Gen_Exam();
                    newGen_Exam.SetData(reader);
                    Gen_ExamCollection.Add(newGen_Exam);
                }
                Gen_ExamCollection.InsertSpName = "spInsertGen_Exam";
                Gen_ExamCollection.UpdateSpName = "spUpdateGen_Exam";
                Gen_ExamCollection.DeleteSpName = "spDeleteGen_Exam";
                return Gen_ExamCollection;
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