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
    public class Gen_FY : BaseItem
    {
        public Gen_FY()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _FYKey;
        [Browsable(true), DisplayName("FYKey")]
        public System.Int32 FYKey
        {
            get
            {
                return _FYKey;
            }
            set
            {
                if (PropertyChanged(_FYKey, value))
                    _FYKey = value;
            }
        }
        private System.Int32 _OrgKey;
        [Browsable(true), DisplayName("OrgKey")]
        public System.Int32 OrgKey
        {
            get
            {
                return _OrgKey;
            }
            set
            {
                if (PropertyChanged(_OrgKey, value))
                    _OrgKey = value;
            }
        }
        private System.String _FYName;
        [Browsable(true), DisplayName("FYName")]
        public System.String FYName
        {
            get
            {
                return _FYName;
            }
            set
            {
                if (PropertyChanged(_FYName, value))
                    _FYName = value;
            }
        }

        private System.DateTime _SDate;
        [Browsable(true), DisplayName("SDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime SDate
        {
            get
            {
                return _SDate;
            }
            set
            {
                if (PropertyChanged(_SDate, value))
                    _SDate = value;
            }
        }

        private System.DateTime _EDate;
        [Browsable(true), DisplayName("EDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EDate
        {
            get
            {
                return _EDate;
            }
            set
            {
                if (PropertyChanged(_EDate, value))
                    _EDate = value;
            }
        }

        private System.Boolean _Status;
        [Browsable(true), DisplayName("Status")]
        public System.Boolean Status
        {
            get
            {
                return _Status;
            }
            set
            {
                if (PropertyChanged(_Status, value))
                    _Status = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _OrgKey, _FYName, _SDate.Value(StaticInfo.DateFormat), _EDate.Value(StaticInfo.DateFormat), _Status };
            else if (IsModified)
                parameterValues = new Object[] { _FYKey, _OrgKey, _FYName, _SDate.Value(StaticInfo.DateFormat), _EDate.Value(StaticInfo.DateFormat), _Status };
            else if (IsDeleted)
                parameterValues = new Object[] { _FYKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _FYKey = reader.GetInt32("FYKey");
            _OrgKey = reader.GetInt32("OrgKey");
            _FYName = reader.GetString("FYName");
            _SDate = reader.GetDateTime("SDate");
            _EDate = reader.GetDateTime("EDate");
            _Status = reader.GetBoolean("Status");
            SetUnchanged();
        }
        public static CustomList<Gen_FY> GetAllGen_FY()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_FY> Gen_FYCollection = new CustomList<Gen_FY>();
            IDataReader reader = null;
            const String sql = "Select *from Gen_FY order by FYKey Desc";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_FY newGen_FY = new Gen_FY();
                    newGen_FY.SetData(reader);
                    Gen_FYCollection.Add(newGen_FY);
                }
                Gen_FYCollection.InsertSpName = "spInsertGen_FY";
                Gen_FYCollection.UpdateSpName = "spUpdateGen_FY";
                Gen_FYCollection.DeleteSpName = "spDeleteGen_FY";
                return Gen_FYCollection;
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

        public static CustomList<Gen_FY> GetAllGen_FY(String OrgKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_FY> Gen_FYCollection = new CustomList<Gen_FY>();
            IDataReader reader = null;
            String sql = string.Format("Select * from Gen_FY Where OrgKey={0}", OrgKey.ToInt());
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_FY newGen_FY = new Gen_FY();
                    newGen_FY.SetData(reader);
                    Gen_FYCollection.Add(newGen_FY);
                }
                Gen_FYCollection.InsertSpName = "spInsertGen_FY";
                Gen_FYCollection.UpdateSpName = "spUpdateGen_FY";
                Gen_FYCollection.DeleteSpName = "spDeleteGen_FY";
                return Gen_FYCollection;
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
