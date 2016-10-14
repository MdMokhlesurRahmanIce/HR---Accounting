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
    public class HRM_EvalItem : BaseItem
    {
        public HRM_EvalItem()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _EvalItemKey;
        [Browsable(true), DisplayName("EvalItemKey")]
        public System.Int32 EvalItemKey
        {
            get
            {
                return _EvalItemKey;
            }
            set
            {
                if (PropertyChanged(_EvalItemKey, value))
                    _EvalItemKey = value;
            }
        }

        private System.Int32 _Seq;
        [Browsable(true), DisplayName("Seq")]
        public System.Int32 Seq
        {
            get
            {
                return _Seq;
            }
            set
            {
                if (PropertyChanged(_Seq, value))
                    _Seq = value;
            }
        }

        private System.Int32 _EvalItemType;
        [Browsable(true), DisplayName("EvalItemType")]
        public System.Int32 EvalItemType
        {
            get
            {
                return _EvalItemType;
            }
            set
            {
                if (PropertyChanged(_EvalItemType, value))
                    _EvalItemType = value;
            }
        }

        private System.String _EvalItemName;
        [Browsable(true), DisplayName("EvalItemName")]
        public System.String EvalItemName
        {
            get
            {
                return _EvalItemName;
            }
            set
            {
                if (PropertyChanged(_EvalItemName, value))
                    _EvalItemName = value;
            }
        }

        private System.String _EvalItemDesc;
        [Browsable(true), DisplayName("EvalItemDesc")]
        public System.String EvalItemDesc
        {
            get
            {
                return _EvalItemDesc;
            }
            set
            {
                if (PropertyChanged(_EvalItemDesc, value))
                    _EvalItemDesc = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _Seq, _EvalItemType, _EvalItemName, _EvalItemDesc };
            else if (IsModified)
                parameterValues = new Object[] { EvalItemKey, _Seq, _EvalItemType, _EvalItemName, _EvalItemDesc };
            else if (IsDeleted)
                parameterValues = new Object[] { _EvalItemKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EvalItemKey = reader.GetInt32("EvalItemKey");
            _Seq = reader.GetInt32("Seq");
            _EvalItemType = reader.GetInt32("EvalItemType");
            _EvalItemName = reader.GetString("EvalItemName");
            _EvalItemDesc = reader.GetString("EvalItemDesc");
            SetUnchanged();
        }
        public static CustomList<HRM_EvalItem> GetAllHRM_EvalItem(int pagetype)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EvalItem> HRM_EvalItemCollection = new CustomList<HRM_EvalItem>();
            IDataReader reader = null;
            String sql = string.Format("Select * from HRM_EvalItem Where EvalItemType = {0}", pagetype);
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EvalItem newHRM_EvalItem = new HRM_EvalItem();
                    newHRM_EvalItem.SetData(reader);
                    HRM_EvalItemCollection.Add(newHRM_EvalItem);
                }
                HRM_EvalItemCollection.InsertSpName = "spInsertHRM_EvalItem";
                HRM_EvalItemCollection.UpdateSpName = "spUpdateHRM_EvalItem";
                HRM_EvalItemCollection.DeleteSpName = "spDeleteHRM_EvalItem";
                return HRM_EvalItemCollection;
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

        public static CustomList<HRM_EvalItem> GetAllHRM_EvalItem()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EvalItem> HRM_EvalItemCollection = new CustomList<HRM_EvalItem>();
            IDataReader reader = null;
            const String sql = "Select * from HRM_EvalItem";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EvalItem newHRM_EvalItem = new HRM_EvalItem();
                    newHRM_EvalItem.SetData(reader);
                    HRM_EvalItemCollection.Add(newHRM_EvalItem);
                }
                HRM_EvalItemCollection.InsertSpName = "spInsertHRM_EvalItem";
                HRM_EvalItemCollection.UpdateSpName = "spUpdateHRM_EvalItem";
                HRM_EvalItemCollection.DeleteSpName = "spDeleteHRM_EvalItem";
                return HRM_EvalItemCollection;
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