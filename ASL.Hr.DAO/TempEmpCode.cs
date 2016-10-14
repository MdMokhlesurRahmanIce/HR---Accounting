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
    public class TempEmpCode : BaseItem
    {
        public TempEmpCode()
        {
            SetAdded();
        }

        #region Properties

        private System.String _TableName;
        [Browsable(true), DisplayName("TableName")]
        public System.String TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                if (PropertyChanged(_TableName, value))
                    _TableName = value;
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

        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _TableName, _EmpKey };
            else if (IsModified)
                parameterValues = new Object[] { _EmpKey };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpKey };

            return parameterValues;
        }


        protected override void SetData(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            SetUnchanged();
        }
        public static CustomList<TempEmpCode> GetAllTempEmpCode()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TempEmpCode> TempEmpCodeCollection = new CustomList<TempEmpCode>();
            IDataReader reader = null;
            const String sql = "Select * from [2347]";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TempEmpCode newTempEmpCode = new TempEmpCode();
                    newTempEmpCode.SetData(reader);
                    TempEmpCodeCollection.Add(newTempEmpCode);
                }
                TempEmpCodeCollection.InsertSpName = "spInsertTempEmpCode";
                TempEmpCodeCollection.UpdateSpName = "spUpdateTempEmpCode";
                TempEmpCodeCollection.DeleteSpName = "spDeleteTempEmpCode";
                return TempEmpCodeCollection;
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