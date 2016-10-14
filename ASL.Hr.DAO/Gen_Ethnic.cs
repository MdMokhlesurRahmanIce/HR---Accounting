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
    public class Gen_Ethnic : BaseItem
    {
        public Gen_Ethnic()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _EthnicKey;
        [Browsable(true), DisplayName("EthnicKey")]
        public System.Int32 EthnicKey
        {
            get
            {
                return _EthnicKey;
            }
            set
            {
                if (PropertyChanged(_EthnicKey, value))
                    _EthnicKey = value;
            }
        }

        private System.Int32 _ReligionKey;
        [Browsable(true), DisplayName("ReligionKey")]
        public System.Int32 ReligionKey
        {
            get
            {
                return _ReligionKey;
            }
            set
            {
                if (PropertyChanged(_ReligionKey, value))
                    _ReligionKey = value;
            }
        }

        private System.String _EthnicName;
        [Browsable(true), DisplayName("EthnicName")]
        public System.String EthnicName
        {
            get
            {
                return _EthnicName;
            }
            set
            {
                if (PropertyChanged(_EthnicName, value))
                    _EthnicName = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ReligionKey, _EthnicName };
            else if (IsModified)
                parameterValues = new Object[] {_EthnicKey, _ReligionKey, _EthnicName };
            else if (IsDeleted)
                parameterValues = new Object[] { _EthnicKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EthnicKey = reader.GetInt32("EthnicKey");
            _ReligionKey = reader.GetInt32("ReligionKey");
            _EthnicName = reader.GetString("EthnicName");
            SetUnchanged();
        }
        public static CustomList<Gen_Ethnic> GetAllGen_Ethnic()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_Ethnic> Gen_EthnicCollection = new CustomList<Gen_Ethnic>();
            IDataReader reader = null;
            const String sql = "select *from  Gen_Ethnic";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_Ethnic newGen_Ethnic = new Gen_Ethnic();
                    newGen_Ethnic.SetData(reader);
                    Gen_EthnicCollection.Add(newGen_Ethnic);
                }
                Gen_EthnicCollection.InsertSpName = "spInsertGen_Ethnic";
                Gen_EthnicCollection.UpdateSpName = "spUpdateGen_Ethnic";
                Gen_EthnicCollection.DeleteSpName = "spDeleteGen_Ethnic";
                return Gen_EthnicCollection;
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
