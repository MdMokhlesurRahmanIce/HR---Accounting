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
    public class Gen_LookupEnt : BaseItem
    {
        public Gen_LookupEnt()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _ElementKey;
        [Browsable(true), DisplayName("ElementKey")]
        public System.Int64 ElementKey
        {
            get
            {
                return _ElementKey;
            }
            set
            {
                if (PropertyChanged(_ElementKey, value))
                    _ElementKey = value;
            }
        }

        private System.String _ElementName;
        [Browsable(true), DisplayName("ElementName")]
        public System.String ElementName
        {
            get
            {
                return _ElementName;
            }
            set
            {
                if (PropertyChanged(_ElementName, value))
                    _ElementName = value;
            }
        }

        private System.String _ElementDesc;
        [Browsable(true), DisplayName("ElementDesc")]
        public System.String ElementDesc
        {
            get
            {
                return _ElementDesc;
            }
            set
            {
                if (PropertyChanged(_ElementDesc, value))
                    _ElementDesc = value;
            }
        }

        private System.Int32 _EntityKey;
        [Browsable(true), DisplayName("EntityKey")]
        public System.Int32 EntityKey
        {
            get
            {
                return _EntityKey;
            }
            set
            {
                if (PropertyChanged(_EntityKey, value))
                    _EntityKey = value;
            }
        }

        private System.String _EntityCap;
        [Browsable(true), DisplayName("EntityCap")]
        public System.String EntityCap
        {
            get
            {
                return _EntityCap;
            }
            set
            {
                if (PropertyChanged(_EntityCap, value))
                    _EntityCap = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ElementName, _ElementDesc, _EntityKey, _EntityCap };
            else if (IsModified)
                parameterValues = new Object[] { _ElementKey, _ElementName, _ElementDesc, _EntityKey, _EntityCap };
            else if (IsDeleted)
                parameterValues = new Object[] { _ElementKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ElementKey = reader.GetInt64("ElementKey");
            _ElementName = reader.GetString("ElementName");
            _ElementDesc = reader.GetString("ElementDesc");
            _EntityKey = reader.GetInt32("EntityKey");
            _EntityCap = reader.GetString("EntityCap");
            SetUnchanged();
        }
        private void SetDataSalaryHead(IDataRecord reader)
        {
            _ElementKey = reader.GetInt64("ElementKey");
            _ElementName = reader.GetString("ElementName");
            _ElementDesc = reader.GetString("ElementDesc");
            SetUnchanged();
        }
        public static CustomList<Gen_LookupEnt> GetAllGen_LookupEnt()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_LookupEnt> Gen_LookupEntCollection = new CustomList<Gen_LookupEnt>();
            IDataReader reader = null;
            const String sql = "select *from Gen_LookupEnt";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_LookupEnt newGen_LookupEnt = new Gen_LookupEnt();
                    newGen_LookupEnt.SetData(reader);
                    Gen_LookupEntCollection.Add(newGen_LookupEnt);
                }
                Gen_LookupEntCollection.InsertSpName = "spInsertGen_LookupEnt";
                Gen_LookupEntCollection.UpdateSpName = "spUpdateGen_LookupEnt";
                Gen_LookupEntCollection.DeleteSpName = "spDeleteGen_LookupEnt";
                return Gen_LookupEntCollection;
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
        public static CustomList<Gen_LookupEnt> GetAllGen_LookupEnt(Int32 entityKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_LookupEnt> Gen_LookupEntCollection = new CustomList<Gen_LookupEnt>();
            IDataReader reader = null;
            String sql = "select *from Gen_LookupEnt where EntityKey='" + entityKey + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_LookupEnt newGen_LookupEnt = new Gen_LookupEnt();
                    newGen_LookupEnt.SetData(reader);
                    Gen_LookupEntCollection.Add(newGen_LookupEnt);
                }
                Gen_LookupEntCollection.InsertSpName = "spInsertGen_LookupEnt";
                Gen_LookupEntCollection.UpdateSpName = "spUpdateGen_LookupEnt";
                Gen_LookupEntCollection.DeleteSpName = "spDeleteGen_LookupEnt";
                return Gen_LookupEntCollection;
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
        public static CustomList<Gen_LookupEnt> GetSalHeadGen_LookupEnt(Int32 entityKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_LookupEnt> Gen_LookupEntCollection = new CustomList<Gen_LookupEnt>();
            IDataReader reader = null;
            String sql = "select ElementKey,ElementDesc,ElementName from Gen_LookupEnt where EntityKey='" + entityKey + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_LookupEnt newGen_LookupEnt = new Gen_LookupEnt();
                    newGen_LookupEnt.SetDataSalaryHead(reader);
                    Gen_LookupEntCollection.Add(newGen_LookupEnt);
                }
                //Gen_LookupEntCollection.InsertSpName = "spInsertGen_LookupEnt";
                //Gen_LookupEntCollection.UpdateSpName = "spUpdateGen_LookupEnt";
                //Gen_LookupEntCollection.DeleteSpName = "spDeleteGen_LookupEnt";
                return Gen_LookupEntCollection;
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
        public static CustomList<Gen_LookupEnt> GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup entitySetup)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_LookupEnt> Gen_LookupEntCollection = new CustomList<Gen_LookupEnt>();
            IDataReader reader = null;

            String sql = "select *from Gen_LookupEnt where EntityKey='" + (int)entitySetup + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_LookupEnt newGen_LookupEnt = new Gen_LookupEnt();
                    newGen_LookupEnt.SetData(reader);
                    Gen_LookupEntCollection.Add(newGen_LookupEnt);
                }
                Gen_LookupEntCollection.InsertSpName = "spInsertGen_LookupEnt";
                Gen_LookupEntCollection.UpdateSpName = "spUpdateGen_LookupEnt";
                Gen_LookupEntCollection.DeleteSpName = "spDeleteGen_LookupEnt";
                return Gen_LookupEntCollection;
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
