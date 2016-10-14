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
    public class Gen_EmpType : BaseItem
    {
        public Gen_EmpType()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _EmpTypeKey;
        [Browsable(true), DisplayName("EmpTypeKey")]
        public System.Int32 EmpTypeKey
        {
            get
            {
                return _EmpTypeKey;
            }
            set
            {
                if (PropertyChanged(_EmpTypeKey, value))
                    _EmpTypeKey = value;
            }
        }

        private System.String _EmpTypeName;
        [Browsable(true), DisplayName("EmpTypeName")]
        public System.String EmpTypeName
        {
            get
            {
                return _EmpTypeName;
            }
            set
            {
                if (PropertyChanged(_EmpTypeName, value))
                    _EmpTypeName = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpTypeName };
            else if (IsModified)
                parameterValues = new Object[] { _EmpTypeName };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpTypeKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EmpTypeKey = reader.GetInt32("EmpTypeKey");
            _EmpTypeName = reader.GetString("EmpTypeName");
            SetUnchanged();
        }
        public static CustomList<Gen_EmpType> GetAllGen_EmpType()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_EmpType> Gen_EmpTypeCollection = new CustomList<Gen_EmpType>();
            IDataReader reader = null;
            const String sql = "select * from Gen_EmpType";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_EmpType newGen_EmpType = new Gen_EmpType();
                    newGen_EmpType.SetData(reader);
                    Gen_EmpTypeCollection.Add(newGen_EmpType);
                }
                Gen_EmpTypeCollection.InsertSpName = "spInsertGen_EmpType";
                Gen_EmpTypeCollection.UpdateSpName = "spUpdateGen_EmpType";
                Gen_EmpTypeCollection.DeleteSpName = "spDeleteGen_EmpType";
                return Gen_EmpTypeCollection;
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