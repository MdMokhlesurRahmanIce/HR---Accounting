using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using System.Web.UI.WebControls;

namespace ASL.Hr.DAO
{
    [Serializable]
    public class Atten_Device : BaseItem
    {
        public Atten_Device()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _id;
        [Browsable(true), DisplayName("id")]
        public System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (PropertyChanged(_id, value))
                    _id = value;
            }
        }

        private System.String _DeviceName;
        [Browsable(true), DisplayName("DeviceName")]
        public System.String DeviceName
        {
            get
            {
                return _DeviceName;
            }
            set
            {
                if (PropertyChanged(_DeviceName, value))
                    _DeviceName = value;
            }
        }

        private System.String _Extension;
        [Browsable(true), DisplayName("Extension")]
        public System.String Extension
        {
            get
            {
                return _Extension;
            }
            set
            {
                if (PropertyChanged(_Extension, value))
                    _Extension = value;
            }
        }

        private System.Boolean _IsFileUpload;
        [Browsable(true), DisplayName("IsFileUpload")]
        public System.Boolean IsFileUpload
        {
            get
            {
                return _IsFileUpload;
            }
            set
            {
                if (PropertyChanged(_IsFileUpload, value))
                    _IsFileUpload = value;
            }
        }

        private System.String _SqlConnectionString;
        [Browsable(true), DisplayName("SqlConnectionString")]
        public System.String SqlConnectionString
        {
            get
            {
                return _SqlConnectionString;
            }
            set
            {
                if (PropertyChanged(_SqlConnectionString, value))
                    _SqlConnectionString = value;
            }
        }

        private System.String _QueryString;
        [Browsable(true), DisplayName("QueryString")]
        public System.String QueryString
        {
            get
            {
                return _QueryString;
            }
            set
            {
                if (PropertyChanged(_QueryString, value))
                    _QueryString = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _DeviceName, _Extension, _IsFileUpload, _SqlConnectionString, _QueryString };
            else if (IsModified)
                parameterValues = new Object[] { _DeviceName, _Extension, _IsFileUpload, _SqlConnectionString, _QueryString };
            else if (IsDeleted)
                parameterValues = new Object[] { _id };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _id = reader.GetInt32("id");
            _DeviceName = reader.GetString("DeviceName");
            _Extension = reader.GetString("Extension");
            _IsFileUpload = reader.GetBoolean("IsFileUpload");
            _SqlConnectionString = reader.GetString("SqlConnectionString");
            _QueryString = reader.GetString("QueryString");
            SetUnchanged();
        }
        public static CustomList<Atten_Device> GetAllAtten_Device()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Atten_Device> Atten_DeviceCollection = new CustomList<Atten_Device>();
            IDataReader reader = null;
            const String sql = "Select * From Atten_Device";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Atten_Device newAtten_Device = new Atten_Device();
                    newAtten_Device.SetData(reader);
                    Atten_DeviceCollection.Add(newAtten_Device);
                }
                Atten_DeviceCollection.InsertSpName = "spInsertAtten_Device";
                Atten_DeviceCollection.UpdateSpName = "spUpdateAtten_Device";
                Atten_DeviceCollection.DeleteSpName = "spDeleteAtten_Device";
                return Atten_DeviceCollection;
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
        public static CustomList<Atten_Device> GetAllAtten_DeviceSQL()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Atten_Device> Atten_DeviceCollection = new CustomList<Atten_Device>();
            IDataReader reader = null;
            const String sql = "Select * From Atten_Device WHERE Extension='sql'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Atten_Device newAtten_Device = new Atten_Device();
                    newAtten_Device.SetData(reader);
                    Atten_DeviceCollection.Add(newAtten_Device);
                }
                return Atten_DeviceCollection;
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
        public static bool GetIsFileUpload(int DeviceID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Atten_Device> Atten_DeviceCollection = new CustomList<Atten_Device>();
            IDataReader reader = null;
            Atten_Device newAtten_Device = null;
            String sql = "Select * From Atten_Device Where id=" + DeviceID + " ";
            try
            {

                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    newAtten_Device = new Atten_Device();
                    newAtten_Device.SetData(reader);

                }

                return newAtten_Device._IsFileUpload;
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
        public ListItem DefaultListItem()
        {


            ListItem li = new ListItem();

            //return li;

            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Atten_Device> Atten_DeviceCollection = new CustomList<Atten_Device>();
            IDataReader reader = null;
            Atten_Device newAtten_Device = null;
            String sql = "Select * From Atten_Device Where id=" + 3 + " ";
            try
            {

                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    newAtten_Device = new Atten_Device();
                    newAtten_Device.SetData(reader);

                }
                li.Text = newAtten_Device._DeviceName;
                li.Value = newAtten_Device._id.ToString();
                return li;
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