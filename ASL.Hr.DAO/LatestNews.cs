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
    public class LatestNews : BaseItem
    {
        public LatestNews()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _NewsKey;
        [Browsable(true), DisplayName("NewsKey")]
        public System.Int32 NewsKey
        {
            get
            {
                return _NewsKey;
            }
            set
            {
                if (PropertyChanged(_NewsKey, value))
                    _NewsKey = value;
            }
        }

        private System.String _NewsDetails;
        [Browsable(true), DisplayName("NewsDetails")]
        public System.String NewsDetails
        {
            get
            {
                return _NewsDetails;
            }
            set
            {
                if (PropertyChanged(_NewsDetails, value))
                    _NewsDetails = value;
            }
        }

        private System.Boolean _IsLatest;
        [Browsable(true), DisplayName("IsLatest")]
        public System.Boolean IsLatest
        {
            get
            {
                return _IsLatest;
            }
            set
            {
                if (PropertyChanged(_IsLatest, value))
                    _IsLatest = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _NewsDetails, _IsLatest };
            else if (IsModified)
                parameterValues = new Object[] { _NewsKey,_NewsDetails, _IsLatest };
            else if (IsDeleted)
                parameterValues = new Object[] { _NewsKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _NewsKey = reader.GetInt32("NewsKey");
            _NewsDetails = reader.GetString("NewsDetails");
            _IsLatest = reader.GetBoolean("IsLatest");
            SetUnchanged();
        }
        public static CustomList<LatestNews> GetAllLatestNews()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LatestNews> LatestNewsCollection = new CustomList<LatestNews>();
            IDataReader reader = null;
            const String sql = "select *from LatestNews";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LatestNews newLatestNews = new LatestNews();
                    newLatestNews.SetData(reader);
                    LatestNewsCollection.Add(newLatestNews);
                }
                LatestNewsCollection.InsertSpName = "spInsertLatestNews";
                LatestNewsCollection.UpdateSpName = "spUpdateLatestNews";
                LatestNewsCollection.DeleteSpName = "spDeleteLatestNews";
                return LatestNewsCollection;
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
        public static CustomList<LatestNews> GetAllLatestNewsForDisplay()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LatestNews> LatestNewsCollection = new CustomList<LatestNews>();
            IDataReader reader = null;
            String sql = "Exec GetLatestNews";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LatestNews newLatestNews = new LatestNews();
                    newLatestNews.NewsDetails = reader.GetString("NewsDetails");
                    LatestNewsCollection.Add(newLatestNews);
                }
                return LatestNewsCollection;
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
