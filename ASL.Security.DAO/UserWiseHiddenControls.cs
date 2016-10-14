using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Security.DAO
{
    [Serializable]
    public class UserWiseHiddenControls : BaseItem
    {
        public UserWiseHiddenControls()
        {
            SetAdded();
        }

        #region Properties

        private System.Decimal _HiddenControlID;
        [Browsable(true), DisplayName("HiddenControlID")]
        public System.Decimal HiddenControlID
        {
            get
            {
                return _HiddenControlID;
            }
            set
            {
                if (PropertyChanged(_HiddenControlID, value))
                    _HiddenControlID = value;
            }
        }

        private System.String _NameSpace;
        [Browsable(true), DisplayName("NameSpace")]
        public System.String NameSpace
        {
            get
            {
                return _NameSpace;
            }
            set
            {
                if (PropertyChanged(_NameSpace, value))
                    _NameSpace = value;
            }
        }

        private System.String _FromName;
        [Browsable(true), DisplayName("FromName")]
        public System.String FromName
        {
            get
            {
                return _FromName;
            }
            set
            {
                if (PropertyChanged(_FromName, value))
                    _FromName = value;
            }
        }

        private System.String _ControlType;
        [Browsable(true), DisplayName("ControlType")]
        public System.String ControlType
        {
            get
            {
                return _ControlType;
            }
            set
            {
                if (PropertyChanged(_ControlType, value))
                    _ControlType = value;
            }
        }

        private System.String _ControlName;
        [Browsable(true), DisplayName("ControlName")]
        public System.String ControlName
        {
            get
            {
                return _ControlName;
            }
            set
            {
                if (PropertyChanged(_ControlName, value))
                    _ControlName = value;
            }
        }

        private System.String _ControlCaption;
        [Browsable(true), DisplayName("ControlCaption")]
        public System.String ControlCaption
        {
            get
            {
                return _ControlCaption;
            }
            set
            {
                if (PropertyChanged(_ControlCaption, value))
                    _ControlCaption = value;
            }
        }

        private System.Int32 _BandNo;
        [Browsable(true), DisplayName("BandNo")]
        public System.Int32 BandNo
        {
            get
            {
                return _BandNo;
            }
            set
            {
                if (PropertyChanged(_BandNo, value))
                    _BandNo = value;
            }
        }

        private System.String _ColumnName;
        [Browsable(true), DisplayName("ColumnName")]
        public System.String ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                if (PropertyChanged(_ColumnName, value))
                    _ColumnName = value;
            }
        }

        private System.String _ColumnCaption;
        [Browsable(true), DisplayName("ColumnCaption")]
        public System.String ColumnCaption
        {
            get
            {
                return _ColumnCaption;
            }
            set
            {
                if (PropertyChanged(_ColumnCaption, value))
                    _ColumnCaption = value;
            }
        }

        private System.Boolean _UserAccess;
        [Browsable(true), DisplayName("UserAccess")]
        public System.Boolean UserAccess
        {
            get
            {
                return _UserAccess;
            }
            set
            {
                if (PropertyChanged(_UserAccess, value))
                    _UserAccess = value;
            }
        }

        private System.String _UserCode;
        [Browsable(true), DisplayName("UserCode")]
        public System.String UserCode
        {
            get
            {
                return _UserCode;
            }
            set
            {
                if (PropertyChanged(_UserCode, value))
                    _UserCode = value;
            }
        }

        private System.Boolean _IsVisible;
        [Browsable(true), DisplayName("IsVisible")]
        public System.Boolean IsVisible
        {
            get
            {
                return _IsVisible;
            }
            set
            {
                if (PropertyChanged(_IsVisible, value))
                    _IsVisible = value;
            }
        }

        private System.Boolean _IsEnable;
        [Browsable(true), DisplayName("IsEnable")]
        public System.Boolean IsEnable
        {
            get
            {
                return _IsEnable;
            }
            set
            {
                if (PropertyChanged(_IsEnable, value))
                    _IsEnable = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            return null;
        }
        protected override void SetData(IDataRecord reader)
        {
            _HiddenControlID = reader.GetDecimal("HiddenControlID");
            _NameSpace = reader.GetString("NameSpace");
            _FromName = reader.GetString("FromName");
            _ControlType = reader.GetString("ControlType");
            _ControlName = reader.GetString("ControlName");
            _ControlCaption = reader.GetString("ControlCaption");
            _BandNo = reader.GetInt32("BandNo");
            _ColumnName = reader.GetString("ColumnName");
            _ColumnCaption = reader.GetString("ColumnCaption");
            _UserAccess = reader.GetBoolean("UserAccess");
            _UserCode = reader.GetString("UserCode");
            _IsVisible = reader.GetBoolean("IsVisible");
            _IsEnable = reader.GetBoolean("IsEnable");
            SetUnchanged();
        }
        public static CustomList<UserWiseHiddenControls> GetUserWiseHiddenControls(String nameSpace, String formName, String userCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<UserWiseHiddenControls> UserWiseHiddenControlsCollection = new CustomList<UserWiseHiddenControls>();
            IDataReader reader = null;
            const String spName = "sqGetHiddenControls";

            conManager.OpenDataReader(out reader, spName, nameSpace, formName, userCode);
            try
            {
                while (reader.Read())
                {
                    UserWiseHiddenControls newUserWiseHiddenControls = new UserWiseHiddenControls();
                    newUserWiseHiddenControls.SetData(reader);
                    UserWiseHiddenControlsCollection.Add(newUserWiseHiddenControls);
                }
                return UserWiseHiddenControlsCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}