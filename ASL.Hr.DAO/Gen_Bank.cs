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
    public class Gen_Bank : BaseItem
    {
        public Gen_Bank()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _BankKey;
        [Browsable(true), DisplayName("BankKey")]
        public System.Int32 BankKey
        {
            get
            {
                return _BankKey;
            }
            set
            {
                if (PropertyChanged(_BankKey, value))
                    _BankKey = value;
            }
        }

        private System.String _BnakName;
        [Browsable(true), DisplayName("BnakName")]
        public System.String BnakName
        {
            get
            {
                return _BnakName;
            }
            set
            {
                if (PropertyChanged(_BnakName, value))
                    _BnakName = value;
            }
        }

        private System.String _BankSName;
        [Browsable(true), DisplayName("BankSName")]
        public System.String BankSName
        {
            get
            {
                return _BankSName;
            }
            set
            {
                if (PropertyChanged(_BankSName, value))
                    _BankSName = value;
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

        private System.String _PhoneNo;
        [Browsable(true), DisplayName("PhoneNo")]
        public System.String PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                if (PropertyChanged(_PhoneNo, value))
                    _PhoneNo = value;
            }
        }

        private System.String _ContactPerson;
        [Browsable(true), DisplayName("ContactPerson")]
        public System.String ContactPerson
        {
            get
            {
                return _ContactPerson;
            }
            set
            {
                if (PropertyChanged(_ContactPerson, value))
                    _ContactPerson = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _BnakName, _BankSName, _Address, _PhoneNo, _ContactPerson };
            else if (IsModified)
                parameterValues = new Object[] {_BankKey, _BnakName, _BankSName, _Address, _PhoneNo, _ContactPerson };
            else if (IsDeleted)
                parameterValues = new Object[] { _BankKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _BankKey = reader.GetInt32("BankKey");
            _BnakName = reader.GetString("BnakName");
            _BankSName = reader.GetString("BankSName");
            _Address = reader.GetString("Address");
            _PhoneNo = reader.GetString("PhoneNo");
            _ContactPerson = reader.GetString("ContactPerson");
            SetUnchanged();
        }
        public static CustomList<Gen_Bank> GetAllGen_Bank()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_Bank> Gen_BankCollection = new CustomList<Gen_Bank>();
            IDataReader reader = null;
            const String sql = "select *from Gen_Bank";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_Bank newGen_Bank = new Gen_Bank();
                    newGen_Bank.SetData(reader);
                    Gen_BankCollection.Add(newGen_Bank);
                }
                Gen_BankCollection.InsertSpName = "spInsertGen_Bank";
                Gen_BankCollection.UpdateSpName = "spUpdateGen_Bank";
                Gen_BankCollection.DeleteSpName = "spDeleteGen_Bank";
                return Gen_BankCollection;
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
