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
    public class HouseKeepingValue : BaseItem
    {
        public HouseKeepingValue()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _HKID;
        [Browsable(true), DisplayName("HKID")]
        public System.Int32 HKID
        {
            get
            {
                return _HKID;
            }
            set
            {
                if (PropertyChanged(_HKID, value))
                    _HKID = value;
            }
        }

        private System.Int32 _EntityID;
        [Browsable(true), DisplayName("EntityID")]
        public System.Int32 EntityID
        {
            get
            {
                return _EntityID;
            }
            set
            {
                if (PropertyChanged(_EntityID, value))
                    _EntityID = value;
            }
        }

        private System.String _HKName;
        [Browsable(true), DisplayName("HKName")]
        public System.String HKName
        {
            get
            {
                return _HKName;
            }
            set
            {
                if (PropertyChanged(_HKName, value))
                    _HKName = value;
            }
        }

        private System.String _ShortName;
        [Browsable(true), DisplayName("ShortName")]
        public System.String ShortName
        {
            get
            {
                return _ShortName;
            }
            set
            {
                if (PropertyChanged(_ShortName, value))
                    _ShortName = value;
            }
        }

        private System.String _Description;
        [Browsable(true), DisplayName("Description")]
        public System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (PropertyChanged(_Description, value))
                    _Description = value;
            }
        }

        private System.String _Address;
        [Browsable(true), DisplayName("Address")]
        public System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                if (PropertyChanged(_Address, value))
                    _Address = value;
            }
        }

        private System.Boolean _IsSaved;
        [Browsable(true), DisplayName("IsSaved")]
        public System.Boolean IsSaved
        {
            get
            {
                return _IsSaved;
            }
            set
            {
                _IsSaved = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EntityID, _HKName, _ShortName, _Description, _Address };
            else if (IsModified)
                parameterValues = new Object[] { _HKID, _EntityID, _HKName, _ShortName, _Description, _Address };
            else if (IsDeleted)
                parameterValues = new Object[] { _HKID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _HKID = reader.GetInt32("HKID");
            _EntityID = reader.GetInt32("EntityID");
            _HKName = reader.GetString("HKName");
            _ShortName = reader.GetString("ShortName");
            _Description = reader.GetString("Description");
            _Address = reader.GetString("Address");
            SetUnchanged();
        }
        private void SetDataHeadType(IDataRecord reader)
        {
            _HKID = reader.GetInt32("HKID");
            _EntityID = reader.GetInt32("EntityID");
            _HKName = reader.GetString("HKName");
            _ShortName = reader.GetString("ShortName");
            SetUnchanged();
        }
        private void SetDataForDropdown(IDataRecord reader)
        {
            _HKID = reader.GetInt32("HKID");
            _HKName = reader.GetString("HKName");
            SetUnchanged();
        }
        public static CustomList<HouseKeepingValue> GetAllHouseKeepingValue(string search, string blank)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HouseKeepingValue> HouseKeepingValueCollection = new CustomList<HouseKeepingValue>();

            IDataReader reader = null;
            String sql = search;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HouseKeepingValue newHouseKeepingValue = new HouseKeepingValue();
                    newHouseKeepingValue.SetData(reader);
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                HouseKeepingValueCollection.InsertSpName = "spInsertHouseKeepingValue";
                HouseKeepingValueCollection.UpdateSpName = "spUpdateHouseKeepingValue";
                HouseKeepingValueCollection.DeleteSpName = "spDeleteHouseKeepingValue";
                return HouseKeepingValueCollection;
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
        public static CustomList<HouseKeepingValue> GetAllHouseKeepingValue(string entityKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HouseKeepingValue> HouseKeepingValueCollection = new CustomList<HouseKeepingValue>();
            IDataReader reader = null;
            String sql = "Exec spGetHkValue " + entityKey.ToInt();
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HouseKeepingValue newHouseKeepingValue = new HouseKeepingValue();
                    newHouseKeepingValue.SetData(reader);
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                HouseKeepingValueCollection.InsertSpName = "spInsertHouseKeepingValue";
                HouseKeepingValueCollection.UpdateSpName = "spUpdateHouseKeepingValue";
                HouseKeepingValueCollection.DeleteSpName = "spDeleteHouseKeepingValue";
                return HouseKeepingValueCollection;
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
        public static CustomList<HouseKeepingValue> GetAllSingleEntity(string spName)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HouseKeepingValue> HouseKeepingValueCollection = new CustomList<HouseKeepingValue>();
            IDataReader reader = null;
            String sql = "EXEC " + spName;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HouseKeepingValue newHouseKeepingValue = new HouseKeepingValue();
                    newHouseKeepingValue.SetDataHeadType(reader);
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                HouseKeepingValueCollection.InsertSpName = "spInsertHouseKeepingValue";
                HouseKeepingValueCollection.UpdateSpName = "spUpdateHouseKeepingValue";
                HouseKeepingValueCollection.DeleteSpName = "spDeleteHouseKeepingValue";
                return HouseKeepingValueCollection;
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
        public static CustomList<HouseKeepingValue> GetAllHouseKeepingValueForDropdown(string entityName)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HouseKeepingValue> HouseKeepingValueCollection = new CustomList<HouseKeepingValue>();
            IDataReader reader = null;
            String sql = "EXEC spGetHouseKeepingValue '" + entityName+"'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HouseKeepingValue newHouseKeepingValue = new HouseKeepingValue();
                    newHouseKeepingValue.SetDataForDropdown(reader);
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                return HouseKeepingValueCollection;
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
        public static CustomList<HouseKeepingValue> GetAllHouseKeepingValueForDropdown(Int32 parentID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HouseKeepingValue> HouseKeepingValueCollection = new CustomList<HouseKeepingValue>();
            IDataReader reader = null;
            String sql = "EXEC spGetChangeEventHouseKeepingValue '" + parentID + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HouseKeepingValue newHouseKeepingValue = new HouseKeepingValue();
                    newHouseKeepingValue.SetDataForDropdown(reader);
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                return HouseKeepingValueCollection;
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
        public static String GetHKName(Int32 HKID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);

            String HKName = "";
            try
            {
                String sql = "select HKName from HouseKeepingValue Where  HKID=" + HKID;
                Object Name = conManager.ExecuteScalarWrapper(sql);
                HKName = Convert.ToString(Name);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return HKName;
        }
        public static CustomList<HouseKeepingValue> GetAllHouseKeepingValue()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HouseKeepingValue> HouseKeepingValueCollection = new CustomList<HouseKeepingValue>();
            IDataReader reader = null;
            String sql = "select *from HouseKeepingValue ";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HouseKeepingValue newHouseKeepingValue = new HouseKeepingValue();
                    newHouseKeepingValue.SetData(reader);
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                HouseKeepingValueCollection.InsertSpName = "spInsertHouseKeepingValue";
                HouseKeepingValueCollection.UpdateSpName = "spUpdateHouseKeepingValue";
                HouseKeepingValueCollection.DeleteSpName = "spDeleteHouseKeepingValue";
                return HouseKeepingValueCollection;
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
        public static CustomList<HouseKeepingValue> GetAllCustomerInfo()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HouseKeepingValue> HouseKeepingValueCollection = new CustomList<HouseKeepingValue>();
            IDataReader reader = null;
            String sql = "Exec GetAllCustomerInfo";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HouseKeepingValue newHouseKeepingValue = new HouseKeepingValue();
                    newHouseKeepingValue.SetData(reader);
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                return HouseKeepingValueCollection;
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
        public static CustomList<HouseKeepingValue> GetAllOfficialInfo()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HouseKeepingValue> HouseKeepingValueCollection = new CustomList<HouseKeepingValue>();
            IDataReader reader = null;
            String sql = "Exec GetHouseKeepingValue";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HouseKeepingValue newHouseKeepingValue = new HouseKeepingValue();
                    newHouseKeepingValue.SetData(reader);
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                return HouseKeepingValueCollection;
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
        public static CustomList<HouseKeepingValue> GetCompany()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HouseKeepingValue> HouseKeepingValueCollection = new CustomList<HouseKeepingValue>();
            IDataReader reader = null;
            String sql = "Exec GetCompany";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HouseKeepingValue newHouseKeepingValue = new HouseKeepingValue();
                    newHouseKeepingValue.HKID = reader.GetInt32("HKID");
                    newHouseKeepingValue.HKName = reader.GetString("HKName");
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                return HouseKeepingValueCollection;
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