using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Security.DAO
{
    [Serializable]
    public class FormAccessRights : BaseItem
    {
        public FormAccessRights()
        {
            SetAdded();
        }

        #region Properties

        [Browsable(true), DisplayName("CanSelect")]
        public System.Boolean CanSelect
        {
            get
            {
                return _CanSelect;
            }
            set
            {
                if (PropertyChanged(_CanSelect, value))
                    _CanSelect = value;
            }
        }
        private System.Boolean _CanSelect;
        [Browsable(true), DisplayName("CanInsert")]
        public System.Boolean CanInsert
        {
            get
            {
                return _CanInsert;
            }
            set
            {
                if (PropertyChanged(_CanInsert, value))
                    _CanInsert = value;
            }
        }
        private System.Boolean _CanInsert;
        [Browsable(true), DisplayName("CanUpdate")]
        public System.Boolean CanUpdate
        {
            get
            {
                return _CanUpdate;
            }
            set
            {
                if (PropertyChanged(_CanUpdate, value))
                    _CanUpdate = value;
            }
        }
        private System.Boolean _CanUpdate;
        [Browsable(true), DisplayName("CanDelete")]
        public System.Boolean CanDelete
        {
            get
            {
                return _CanDelete;
            }
            set
            {
                if (PropertyChanged(_CanDelete, value))
                    _CanDelete = value;
            }
        }
        private System.Boolean _CanDelete;

        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _CanSelect, _CanInsert, _CanUpdate, _CanDelete };
            else if (IsModified)
                parameterValues = new Object[] { _CanSelect, _CanInsert, _CanUpdate, _CanDelete };
            else if (IsDeleted)
                parameterValues = new Object[] { };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _CanSelect = reader.GetBoolean("CanSelect");
            _CanInsert = reader.GetBoolean("CanInsert");
            _CanUpdate = reader.GetBoolean("CanUpdate");
            _CanDelete = reader.GetBoolean("CanDelete");
            SetUnchanged();
        }
        public static CustomList<FormAccessRights> GetAllFormAccessRights()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<FormAccessRights> FormAccessRightsCollection = new CustomList<FormAccessRights>();
            IDataReader reader = null;
            const String sql = "select *from SecurityRule_Object";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    FormAccessRights newFormAccessRights = new FormAccessRights();
                    newFormAccessRights.SetData(reader);
                    FormAccessRightsCollection.Add(newFormAccessRights);
                }
                FormAccessRightsCollection.InsertSpName = "spInsertFormAccessRights";
                FormAccessRightsCollection.UpdateSpName = "spUpdateFormAccessRights";
                FormAccessRightsCollection.DeleteSpName = "spDeleteFormAccessRights";
                return FormAccessRightsCollection;
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

        public static FormAccessRights GetFormAccessRightsByUserCodeAndFormName(string userCode, string formName)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            IDataReader reader = null;

            FormAccessRights newFormAccessRights = new FormAccessRights();
            conManager.OpenDataReader(out reader, "spWebGetFormAccessRights", userCode, formName);
            try
            {
                while (reader.Read())
                {
                    newFormAccessRights.SetData(reader);
                }

                return newFormAccessRights;
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