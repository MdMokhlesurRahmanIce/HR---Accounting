using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;


namespace ACC.DAO
{
	[Serializable]
	public class Acc_VoucherType : BaseItem
	{
		public Acc_VoucherType()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _VoucherTypeKey;
		[Browsable(true), DisplayName("VoucherTypeKey")]
		public System.Int32 VoucherTypeKey 
		{
			get
			{
				return _VoucherTypeKey;
			}
			set
			{
			if (PropertyChanged(_VoucherTypeKey, value))
					_VoucherTypeKey = value;
			}
		}

		private System.String _VoucherTypeCode;
		[Browsable(true), DisplayName("VoucherTypeCode")]
		public System.String VoucherTypeCode 
		{
			get
			{
				return _VoucherTypeCode;
			}
			set
			{
			if (PropertyChanged(_VoucherTypeCode, value))
					_VoucherTypeCode = value;
			}
		}

		private System.String _VoucherTypeName;
		[Browsable(true), DisplayName("VoucherTypeName")]
		public System.String VoucherTypeName 
		{
			get
			{
				return _VoucherTypeName;
			}
			set
			{
			if (PropertyChanged(_VoucherTypeName, value))
					_VoucherTypeName = value;
			}
		}

		private System.DateTime _EntryDate;
		[Browsable(true), DisplayName("EntryDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime EntryDate 
		{
			get
			{
				return _EntryDate;
			}
			set
			{
			if (PropertyChanged(_EntryDate, value))
					_EntryDate = value;
			}
		}

		private System.Int64 _EntryUserKey;
		[Browsable(true), DisplayName("EntryUserKey")]
		public System.Int64 EntryUserKey 
		{
			get
			{
				return _EntryUserKey;
			}
			set
			{
			if (PropertyChanged(_EntryUserKey, value))
					_EntryUserKey = value;
			}
		}

		private System.DateTime _LastUpdateDate;
		[Browsable(true), DisplayName("LastUpdateDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime LastUpdateDate 
		{
			get
			{
				return _LastUpdateDate;
			}
			set
			{
			if (PropertyChanged(_LastUpdateDate, value))
					_LastUpdateDate = value;
			}
		}

		private System.Int64 _LastUpdateUserKey;
		[Browsable(true), DisplayName("LastUpdateUserKey")]
		public System.Int64 LastUpdateUserKey 
		{
			get
			{
				return _LastUpdateUserKey;
			}
			set
			{
			if (PropertyChanged(_LastUpdateUserKey, value))
					_LastUpdateUserKey = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_VoucherTypeCode,_VoucherTypeName,_EntryDate.Value(StaticInfo.DateFormat),_EntryUserKey,_LastUpdateDate.Value(StaticInfo.DateFormat),_LastUpdateUserKey};
			else if (IsModified)
				parameterValues = new Object[] {_VoucherTypeCode,_VoucherTypeName,_EntryDate.Value(StaticInfo.DateFormat),_EntryUserKey,_LastUpdateDate.Value(StaticInfo.DateFormat),_LastUpdateUserKey};
			else if (IsDeleted)
				parameterValues = new Object[] {_VoucherTypeKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_VoucherTypeKey = reader.GetInt32("VoucherTypeKey");
			_VoucherTypeCode = reader.GetString("VoucherTypeCode");
			_VoucherTypeName = reader.GetString("VoucherTypeName");
			_EntryDate = reader.GetDateTime("EntryDate");
			_EntryUserKey = reader.GetInt64("EntryUserKey");
			_LastUpdateDate = reader.GetDateTime("LastUpdateDate");
			_LastUpdateUserKey = reader.GetInt64("LastUpdateUserKey");
			SetUnchanged();
		}
        private void SetDataVoucherType(IDataRecord reader)
        {
            _VoucherTypeCode = reader.GetString("VoucherTypeCode");
            _VoucherTypeKey = reader.GetInt32("VoucherTypeKey");
            SetUnchanged();
        }
		public static CustomList<Acc_VoucherType> GetAllAcc_VoucherType()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<Acc_VoucherType> Acc_VoucherTypeCollection = new CustomList<Acc_VoucherType>();
			IDataReader reader = null;
            const String sql = "select VoucherTypeKey,VoucherTypeCode from Acc_VoucherType";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Acc_VoucherType newAcc_VoucherType = new Acc_VoucherType();
                    newAcc_VoucherType.SetDataVoucherType(reader);
					Acc_VoucherTypeCollection.Add(newAcc_VoucherType);
				}
				Acc_VoucherTypeCollection.InsertSpName = "spInsertAcc_VoucherType";
				Acc_VoucherTypeCollection.UpdateSpName = "spUpdateAcc_VoucherType";
				Acc_VoucherTypeCollection.DeleteSpName = "spDeleteAcc_VoucherType";
				return Acc_VoucherTypeCollection;
			}
			catch(Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}
		}
        public static CustomList<Acc_VoucherType> GetAllAcc_VoucherTypePayment()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherType> Acc_VoucherTypeCollection = new CustomList<Acc_VoucherType>();
            IDataReader reader = null;
            const String sql = "select VoucherTypeKey,VoucherTypeCode from Acc_VoucherType Where VoucherTypeKey in(1,3)";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherType newAcc_VoucherType = new Acc_VoucherType();
                    newAcc_VoucherType.SetDataVoucherType(reader);
                    Acc_VoucherTypeCollection.Add(newAcc_VoucherType);
                }
                Acc_VoucherTypeCollection.InsertSpName = "spInsertAcc_VoucherType";
                Acc_VoucherTypeCollection.UpdateSpName = "spUpdateAcc_VoucherType";
                Acc_VoucherTypeCollection.DeleteSpName = "spDeleteAcc_VoucherType";
                return Acc_VoucherTypeCollection;
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
        public static CustomList<Acc_VoucherType> GetAllAcc_VoucherTypeReceipt()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherType> Acc_VoucherTypeCollection = new CustomList<Acc_VoucherType>();
            IDataReader reader = null;
            const String sql = "select VoucherTypeKey,VoucherTypeCode from Acc_VoucherType Where VoucherTypeKey in(2,4)";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherType newAcc_VoucherType = new Acc_VoucherType();
                    newAcc_VoucherType.SetDataVoucherType(reader);
                    Acc_VoucherTypeCollection.Add(newAcc_VoucherType);
                }
                return Acc_VoucherTypeCollection;
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
        public static CustomList<Acc_VoucherType> GetAllAcc_VoucherTypeForPurchase()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherType> Acc_VoucherTypeCollection = new CustomList<Acc_VoucherType>();
            IDataReader reader = null;
            const String sql = "select VoucherTypeKey,VoucherTypeCode from Acc_VoucherType Where VoucherTypeKey in(1,3)";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherType newAcc_VoucherType = new Acc_VoucherType();
                    newAcc_VoucherType.SetDataVoucherType(reader);
                    Acc_VoucherTypeCollection.Add(newAcc_VoucherType);
                }
                return Acc_VoucherTypeCollection;
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