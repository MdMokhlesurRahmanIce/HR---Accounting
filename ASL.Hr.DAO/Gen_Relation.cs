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
    public class Gen_Relation : BaseItem
    {
        public Gen_Relation()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _RelationKey;
        [Browsable(true), DisplayName("RelationKey")]
        public System.Int32 RelationKey
        {
            get
            {
                return _RelationKey;
            }
            set
            {
                if (PropertyChanged(_RelationKey, value))
                    _RelationKey = value;
            }
        }

        private System.String _RelationName;
        [Browsable(true), DisplayName("RelationName")]
        public System.String RelationName
        {
            get
            {
                return _RelationName;
            }
            set
            {
                if (PropertyChanged(_RelationName, value))
                    _RelationName = value;
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
                parameterValues = new Object[] { _RelationName, _Remarks };
            else if (IsModified)
                parameterValues = new Object[] { _RelationName, _Remarks };
            else if (IsDeleted)
                parameterValues = new Object[] { _RelationKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _RelationKey = reader.GetInt32("RelationKey");
            _RelationName = reader.GetString("RelationName");
            _Remarks = reader.GetString("Remarks");
            SetUnchanged();
        }
        public static CustomList<Gen_Relation> GetAllGen_Relation()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_Relation> Gen_RelationCollection = new CustomList<Gen_Relation>();
            IDataReader reader = null;
            const String sql = "select * from Gen_Relation";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_Relation newGen_Relation = new Gen_Relation();
                    newGen_Relation.SetData(reader);
                    Gen_RelationCollection.Add(newGen_Relation);
                }
                Gen_RelationCollection.InsertSpName = "spInsertGen_Relation";
                Gen_RelationCollection.UpdateSpName = "spUpdateGen_Relation";
                Gen_RelationCollection.DeleteSpName = "spDeleteGen_Relation";
                return Gen_RelationCollection;
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