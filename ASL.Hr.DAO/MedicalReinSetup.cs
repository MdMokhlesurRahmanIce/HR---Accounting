using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using System.Text;
using System.Web;

namespace ASL.Hr.DAO
{
    [Serializable]
    public class MedicalReinSetup : BaseItem
    {
        public MedicalReinSetup()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _MedReinbKey;
        [Browsable(true), DisplayName("MedReinbKey")]
        public System.Int32 MedReinbKey
        {
            get
            {
                return _MedReinbKey;
            }
            set
            {
                if (PropertyChanged(_MedReinbKey, value))
                    _MedReinbKey = value;
            }
        }

        private System.Int64 _EmpKey;
        [Browsable(true), DisplayName("EmpKey")]
        public System.Int64 EmpKey
        {
            get
            {
                return _EmpKey;
            }
            set
            {
                if (PropertyChanged(_EmpKey, value))
                    _EmpKey = value;
            }
        }

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

        private System.Decimal _SelfLimit;
        [Browsable(true), DisplayName("SelfLimit")]
        public System.Decimal SelfLimit
        {
            get
            {
                return _SelfLimit;
            }
            set
            {
                if (PropertyChanged(_SelfLimit, value))
                    _SelfLimit = value;
            }
        }

        private System.Decimal _FamilyLimit;
        [Browsable(true), DisplayName("FamilyLimit")]
        public System.Decimal FamilyLimit
        {
            get
            {
                return _FamilyLimit;
            }
            set
            {
                if (PropertyChanged(_FamilyLimit, value))
                    _FamilyLimit = value;
            }
        }

        private System.Decimal _MaternityPaid;
        [Browsable(true), DisplayName("MaternityPaid")]
        public System.Decimal MaternityPaid
        {
            get
            {
                return _MaternityPaid;
            }
            set
            {
                if (PropertyChanged(_MaternityPaid, value))
                    _MaternityPaid = value;
            }
        }

        private System.Decimal _SelfPaid;
        [Browsable(true), DisplayName("SelfPaid")]
        public System.Decimal SelfPaid
        {
            get
            {
                return _SelfPaid;
            }
            set
            {
                if (PropertyChanged(_SelfPaid, value))
                    _SelfPaid = value;
            }
        }

        private System.Decimal _FamilyPaid;
        [Browsable(true), DisplayName("FamilyPaid")]
        public System.Decimal FamilyPaid
        {
            get
            {
                return _FamilyPaid;
            }
            set
            {
                if (PropertyChanged(_FamilyPaid, value))
                    _FamilyPaid = value;
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

        private System.Decimal _MaternityLimit;
        [Browsable(true), DisplayName("MaternityLimit")]
        public System.Decimal MaternityLimit
        {
            get
            {
                return _MaternityLimit;
            }
            set
            {
                if (PropertyChanged(_MaternityLimit, value))
                    _MaternityLimit = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _FYKey, _SelfLimit, _FamilyLimit, _Remarks,_MaternityLimit };
            else if (IsModified)
                parameterValues = new Object[] { _MedReinbKey, _EmpKey, _FYKey, _SelfLimit, _FamilyLimit, _Remarks,_MaternityLimit };
            else if (IsDeleted)
                parameterValues = new Object[] { _MedReinbKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _MedReinbKey = reader.GetInt32("MedReinbKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _FYKey = reader.GetInt32("FYKey");
            _SelfLimit = reader.GetDecimal("SelfLimit");
            _FamilyLimit = reader.GetDecimal("FamilyLimit");
            _Remarks = reader.GetString("Remarks");
            _MaternityLimit = reader.GetDecimal("MaternityLimit");
            SetUnchanged();
        }
        public static CustomList<MedicalReinSetup> GetAllMedicalReinSetup()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<MedicalReinSetup> MedicalReinSetupCollection = new CustomList<MedicalReinSetup>();
            IDataReader reader = null;
            const String sql = "select *from MedicalReinSetup";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MedicalReinSetup newMedicalReinSetup = new MedicalReinSetup();
                    newMedicalReinSetup.SetData(reader);
                    MedicalReinSetupCollection.Add(newMedicalReinSetup);
                }
                MedicalReinSetupCollection.InsertSpName = "spInsertMedicalReinSetup";
                MedicalReinSetupCollection.UpdateSpName = "spUpdateMedicalReinSetup";
                MedicalReinSetupCollection.DeleteSpName = "spDeleteMedicalReinSetup";
                return MedicalReinSetupCollection;
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
        public static CustomList<MedicalReinSetup> GetAllMedicalReinSetup(string fyKey,string empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<MedicalReinSetup> MedicalReinSetupCollection = new CustomList<MedicalReinSetup>();
            IDataReader reader = null;
            String sql = "select *from MedicalReinSetup Where FYKey="+fyKey+" and EmpKey="+empKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MedicalReinSetup newMedicalReinSetup = new MedicalReinSetup();
                    newMedicalReinSetup.SetData(reader);
                    MedicalReinSetupCollection.Add(newMedicalReinSetup);
                }
                return MedicalReinSetupCollection;
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

        public static MedicalReinSetup GetAllMedicalBalance(string fyKey, string empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            IDataReader reader = null;
            String sql = "EXEC spGetMedicalAllowance " + empKey + "," + fyKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                MedicalReinSetup newMedicalReinSetup = new MedicalReinSetup();
                while (reader.Read())
                {
                    newMedicalReinSetup.SelfLimit = reader.GetDecimal("SelfLimit");
                    newMedicalReinSetup.FamilyLimit = reader.GetDecimal("FamilyLimit");
                    newMedicalReinSetup.SelfPaid = reader.GetDecimal("SelfPaid");
                    newMedicalReinSetup.FamilyPaid = reader.GetDecimal("FamilyPaid");
                    newMedicalReinSetup.MaternityLimit = reader.GetDecimal("MaternityLimit");
                    newMedicalReinSetup.MaternityPaid = reader.GetDecimal("MaternityPaid");
                }
                return newMedicalReinSetup;
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
