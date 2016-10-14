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
    public class Designation : BaseItem
    {
        public Designation()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _DesigKey;
        [Browsable(true), DisplayName("DesigKey")]
        public System.Int32 DesigKey
        {
            get
            {
                return _DesigKey;
            }
            set
            {
                if (PropertyChanged(_DesigKey, value))
                    _DesigKey = value;
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

        private System.String _DesigName;
        [Browsable(true), DisplayName("DesigName")]
        public System.String DesigName
        {
            get
            {
                return _DesigName;
            }
            set
            {
                if (PropertyChanged(_DesigName, value))
                    _DesigName = value;
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
                parameterValues = new Object[] { _OrgKey, _DesigName, _Remarks };
            else if (IsModified)
                parameterValues = new Object[] { _DesigKey, _OrgKey, _DesigName, _Remarks };
            else if (IsDeleted)
                parameterValues = new Object[] { _DesigKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _DesigKey = reader.GetInt32("DesigKey");
            _OrgKey = reader.GetInt32("OrgKey");
            _DesigName = reader.GetString("DesigName");
            _Remarks = reader.GetString("Remarks");
            SetUnchanged();
        }
        public static CustomList<Designation> GetAllDesignation(Int32 orgkey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Designation> DesignationCollection = new CustomList<Designation>();
            IDataReader reader = null;
            String sql = "select * from Gen_Desig Where OrgKey='" + orgkey + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Designation newDesignation = new Designation();
                    newDesignation.SetData(reader);
                    DesignationCollection.Add(newDesignation);
                }
                DesignationCollection.InsertSpName = "spInsertDesignation";
                DesignationCollection.UpdateSpName = "spUpdateDesignation";
                DesignationCollection.DeleteSpName = "spDeleteDesignation";
                return DesignationCollection;
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
        public static CustomList<Designation> GetAllDesignation()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Designation> DesignationCollection = new CustomList<Designation>();
            IDataReader reader = null;
            String sql = "select * from Gen_Desig";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Designation newDesignation = new Designation();
                    newDesignation.SetData(reader);
                    DesignationCollection.Add(newDesignation);
                }
                DesignationCollection.InsertSpName = "spInsertDesignation";
                DesignationCollection.UpdateSpName = "spUpdateDesignation";
                DesignationCollection.DeleteSpName = "spDeleteDesignation";
                return DesignationCollection;
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