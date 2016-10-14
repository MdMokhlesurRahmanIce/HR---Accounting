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
    public class Gen_Grade : BaseItem
    {
        public Gen_Grade()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _GradeKey;
        [Browsable(true), DisplayName("GradeKey")]
        public System.Int32 GradeKey
        {
            get
            {
                return _GradeKey;
            }
            set
            {
                if (PropertyChanged(_GradeKey, value))
                    _GradeKey = value;
            }
        }

        private System.String _GradeName;
        [Browsable(true), DisplayName("GradeName")]
        public System.String GradeName
        {
            get
            {
                return _GradeName;
            }
            set
            {
                if (PropertyChanged(_GradeName, value))
                    _GradeName = value;
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
                parameterValues = new Object[] { _GradeName, _Remarks };
            else if (IsModified)
                parameterValues = new Object[] { _GradeName, _Remarks };
            else if (IsDeleted)
                parameterValues = new Object[] { _GradeKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _GradeKey = reader.GetInt32("GradeKey");
            _GradeName = reader.GetString("GradeName");
            _Remarks = reader.GetString("Remarks");
            SetUnchanged();
        }
        public static CustomList<Gen_Grade> GetAllGen_Grade()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_Grade> Gen_GradeCollection = new CustomList<Gen_Grade>();
            IDataReader reader = null;
            const String sql = "select * from Gen_Grade";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_Grade newGen_Grade = new Gen_Grade();
                    newGen_Grade.SetData(reader);
                    Gen_GradeCollection.Add(newGen_Grade);
                }
                Gen_GradeCollection.InsertSpName = "spInsertGen_Grade";
                Gen_GradeCollection.UpdateSpName = "spUpdateGen_Grade";
                Gen_GradeCollection.DeleteSpName = "spDeleteGen_Grade";
                return Gen_GradeCollection;
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