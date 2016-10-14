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
    public class HRM_EvalDet : BaseItem
    {
        public HRM_EvalDet()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _EvalDetKey;
        [Browsable(true), DisplayName("EvalDetKey")]
        public System.Int64 EvalDetKey
        {
            get
            {
                return _EvalDetKey;
            }
            set
            {
                if (PropertyChanged(_EvalDetKey, value))
                    _EvalDetKey = value;
            }
        }

        private System.Int64 _EvalKey;
        [Browsable(true), DisplayName("EvalKey")]
        public System.Int64 EvalKey
        {
            get
            {
                return _EvalKey;
            }
            set
            {
                if (PropertyChanged(_EvalKey, value))
                    _EvalKey = value;
            }
        }

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

        private System.Int32 _EvalRating;
        [Browsable(true), DisplayName("EvalRating")]
        public System.Int32 EvalRating
        {
            get
            {
                return _EvalRating;
            }
            set
            {
                if (PropertyChanged(_EvalRating, value))
                    _EvalRating = value;
            }
        }

        private System.Int32 _ReviewRating;
        [Browsable(true), DisplayName("ReviewRating")]
        public System.Int32 ReviewRating
        {
            get
            {
                return _ReviewRating;
            }
            set
            {
                if (PropertyChanged(_ReviewRating, value))
                    _ReviewRating = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EvalKey, _EvalItemKey, _EvalRating, _ReviewRating };
            else if (IsModified)
                parameterValues = new Object[] { _EvalDetKey, _EvalKey, _EvalItemKey, _EvalRating, _ReviewRating };
            else if (IsDeleted)
                parameterValues = new Object[] { _EvalDetKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EvalDetKey = reader.GetInt64("EvalDetKey");
            _EvalKey = reader.GetInt64("EvalKey");
            _EvalItemKey = reader.GetInt32("EvalItemKey");
            _EvalRating = reader.GetInt32("EvalRating");
            _ReviewRating = reader.GetInt32("ReviewRating");
            SetUnchanged();
        }
        public static CustomList<HRM_EvalDet> GetAllHRM_EvalDet()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EvalDet> HRM_EvalDetCollection = new CustomList<HRM_EvalDet>();
            IDataReader reader = null;
            const String sql = "Select * from HRM_EvalDet";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EvalDet newHRM_EvalDet = new HRM_EvalDet();
                    newHRM_EvalDet.SetData(reader);
                    HRM_EvalDetCollection.Add(newHRM_EvalDet);
                }
                HRM_EvalDetCollection.InsertSpName = "spInsertHRM_EvalDet";
                HRM_EvalDetCollection.UpdateSpName = "spUpdateHRM_EvalDet";
                HRM_EvalDetCollection.DeleteSpName = "spDeleteHRM_EvalDet";
                return HRM_EvalDetCollection;
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

        public static CustomList<HRM_EvalDet> GetHRM_EvalDet(String EvalKey, int pagetype)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EvalDet> HRM_EvalDetCollection = new CustomList<HRM_EvalDet>();
            IDataReader reader = null;
            String sql = " SELECT dbo.HRM_EvalItem.EvalItemKey, Det.EvalRating, Det.ReviewRating,  Det.EvalDetKey, Det.EvalKey EvalKey " +
                               " FROM         dbo.HRM_EvalItem LEFT  JOIN " +
                               " (Select * from dbo.HRM_EvalDet Where EvalKey = '" + EvalKey + "') as  Det ON dbo.HRM_EvalItem.EvalItemKey = Det.EvalItemKey " +
                               " Where evalitemtype = " + pagetype +  " ORDER BY dbo.HRM_EvalItem.Seq";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EvalDet newHRM_EvalDet = new HRM_EvalDet();
                    newHRM_EvalDet.SetData(reader);
                    HRM_EvalDetCollection.Add(newHRM_EvalDet);
                }
                HRM_EvalDetCollection.InsertSpName = "spInsertHRM_EvalDet";
                HRM_EvalDetCollection.UpdateSpName = "spUpdateHRM_EvalDet";
                HRM_EvalDetCollection.DeleteSpName = "spDeleteHRM_EvalDet";
                return HRM_EvalDetCollection;
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