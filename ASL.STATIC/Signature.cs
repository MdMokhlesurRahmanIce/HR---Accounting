using System;
using System.Collections.Generic;
using System.Data;
using ASL.DAL;
using ASL.DATA;

namespace ASL.STATIC
{
    [Serializable]
    public class Signature : BaseItem
    {
        public Signature()
        {
            SetAdded();
        }

        #region Properties
        public System.String Field
        {
            get
            {
                return _Field;
            }
            set
            {
                if (PropertyChanged(_Field, value))
                    _Field = value;
            }
        }
        private String _Field;
        public System.String Dates
        {
            get
            {
                return _Dates;
            }
            set
            {
                if (PropertyChanged(_Dates, value))
                    _Dates = value;
            }
        }
        private String _Dates;
        public System.Decimal LastNumber
        {
            get
            {
                return _LastNumber;
            }
            set
            {
                if (PropertyChanged(_LastNumber, value))
                    _LastNumber = value;
            }
        }
        private Decimal _LastNumber;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _Field, _Dates, _LastNumber};
            else if (IsModified)
                parameterValues = new Object[] { _Field, _Dates, _LastNumber};
            else if (IsDeleted)
                parameterValues = new Object[] { _Field, _Dates };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _Field = reader.GetString("Field");
            _Dates = reader.GetString("Dates");
            _LastNumber = reader.GetDecimal("LastNumber");
            SetUnchanged();
        }
        public static CustomList<Signature> GetSignatureForUniqueCode(String sql)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<Signature> signatureCollection = new CustomList<Signature>();
            IDataReader reader = null;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        Signature newSignature = new Signature();
                        newSignature.SetData(reader);
                        signatureCollection.Add(newSignature);
                    }
                }
                return signatureCollection;
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
        public static CustomList<Signature> GetSignatureForUniqueCode(ref ConnectionManager conManager,String sql)
        {
            CustomList<Signature> signatureCollection = new CustomList<Signature>();
            IDataReader reader = null;
            try
            {
                conManager.OpenDataReader(sql, out reader, CommandBehavior.Default, true);
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        Signature newSignature = new Signature();
                        newSignature.SetData(reader);
                        signatureCollection.Add(newSignature);
                    }
                }
                return signatureCollection;
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