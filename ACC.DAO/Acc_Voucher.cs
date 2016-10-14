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
	public class Acc_Voucher : BaseItem
	{
		public Acc_Voucher()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int64 _VoucherKey;
		[Browsable(true), DisplayName("VoucherKey")]
		public System.Int64 VoucherKey 
		{
			get
			{
				return _VoucherKey;
			}
			set
			{
			if (PropertyChanged(_VoucherKey, value))
					_VoucherKey = value;
			}
		}

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

		private System.Int64 _OrgKey;
		[Browsable(true), DisplayName("OrgKey")]
		public System.Int64 OrgKey 
		{
			get
			{
				return _OrgKey;
			}
			set
			{
			if (PropertyChanged(_OrgKey, value))
					_OrgKey = value;
			}
		}

        private System.String _VoucherNo;
        [Browsable(true), DisplayName("VoucherNo")]
        public System.String VoucherNo
        {
            get
            {
                return _VoucherNo;
            }
            set
            {
                if (PropertyChanged(_VoucherNo, value))
                    _VoucherNo = value;
            }
        }


		private System.DateTime _VoucherDate;
		[Browsable(true), DisplayName("VoucherDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime VoucherDate 
		{
			get
			{
				return _VoucherDate;
			}
			set
			{
			if (PropertyChanged(_VoucherDate, value))
					_VoucherDate = value;
			}
		}

        private System.String _CheckNo;
        [Browsable(true), DisplayName("CheckNo")]
        public System.String CheckNo
        {
            get
            {
                return _CheckNo;
            }
            set
            {
                if (PropertyChanged(_CheckNo, value))
                    _CheckNo = value;
            }
        }


        private System.DateTime? _CheckDate;
        [Browsable(true), DisplayName("CheckDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime? CheckDate
        {
            get
            {
                return _CheckDate;
            }
            set
            {
                if (PropertyChanged(_CheckDate, value))
                    _CheckDate = value;
            }
        }

		private System.String _VoucherClient;
		[Browsable(true), DisplayName("VoucherClient")]
		public System.String VoucherClient 
		{
			get
			{
				return _VoucherClient;
			}
			set
			{
			if (PropertyChanged(_VoucherClient, value))
					_VoucherClient = value;
			}
		}

		private System.String _PayRec;
		[Browsable(true), DisplayName("PayRec")]
		public System.String PayRec 
		{
			get
			{
				return _PayRec;
			}
			set
			{
			if (PropertyChanged(_PayRec, value))
					_PayRec = value;
			}
		}

		private System.String _VoucherDesc;
		[Browsable(true), DisplayName("VoucherDesc")]
		public System.String VoucherDesc 
		{
			get
			{
				return _VoucherDesc;
			}
			set
			{
			if (PropertyChanged(_VoucherDesc, value))
					_VoucherDesc = value;
			}
		}

		private System.Int32 _IsPost;
		[Browsable(true), DisplayName("IsPost")]
        public System.Int32 IsPost 
		{
			get
			{
				return _IsPost;
			}
			set
			{
			if (PropertyChanged(_IsPost, value))
					_IsPost = value;
			}
		}

        private System.Boolean _IsApproved;
        [Browsable(true), DisplayName("IsApproved")]
        public System.Boolean IsApproved
        {
            get
            {
                return _IsApproved;
            }
            set
            {
                if (PropertyChanged(_IsApproved, value))
                    _IsApproved = value;
            }
        }

		private System.DateTime _PostDate;
		[Browsable(true), DisplayName("PostDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime PostDate 
		{
			get
			{
				return _PostDate;
			}
			set
			{
			if (PropertyChanged(_PostDate, value))
					_PostDate = value;
			}
		}

		private System.Int64 _PostBy;
		[Browsable(true), DisplayName("PostBy")]
		public System.Int64 PostBy 
		{
			get
			{
				return _PostBy;
			}
			set
			{
			if (PropertyChanged(_PostBy, value))
					_PostBy = value;
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

		private System.Decimal _NField_1;
		[Browsable(true), DisplayName("NField_1")]
		public System.Decimal NField_1 
		{
			get
			{
				return _NField_1;
			}
			set
			{
			if (PropertyChanged(_NField_1, value))
					_NField_1 = value;
			}
		}

		private System.Decimal _NField_2;
		[Browsable(true), DisplayName("NField_2")]
		public System.Decimal NField_2 
		{
			get
			{
				return _NField_2;
			}
			set
			{
			if (PropertyChanged(_NField_2, value))
					_NField_2 = value;
			}
		}

		private System.String _TField_1;
		[Browsable(true), DisplayName("TField_1")]
		public System.String TField_1 
		{
			get
			{
				return _TField_1;
			}
			set
			{
			if (PropertyChanged(_TField_1, value))
					_TField_1 = value;
			}
		}

		private System.String _TField_2;
		[Browsable(true), DisplayName("TField_2")]
		public System.String TField_2 
		{
			get
			{
				return _TField_2;
			}
			set
			{
			if (PropertyChanged(_TField_2, value))
					_TField_2 = value;
			}
		}

		private System.String _TField_3;
		[Browsable(true), DisplayName("TField_3")]
		public System.String TField_3 
		{
			get
			{
				return _TField_3;
			}
			set
			{
			if (PropertyChanged(_TField_3, value))
					_TField_3 = value;
			}
		}

		private System.String _TField_4;
		[Browsable(true), DisplayName("TField_4")]
		public System.String TField_4 
		{
			get
			{
				return _TField_4;
			}
			set
			{
			if (PropertyChanged(_TField_4, value))
					_TField_4 = value;
			}
		}

		private System.String _TField_5;
		[Browsable(true), DisplayName("TField_5")]
		public System.String TField_5 
		{
			get
			{
				return _TField_5;
			}
			set
			{
			if (PropertyChanged(_TField_5, value))
					_TField_5 = value;
			}
		}

		private System.DateTime? _DField_1;
		[Browsable(true), DisplayName("DField_1"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime? DField_1 
		{
			get
			{
				return _DField_1;
			}
			set
			{
			if (PropertyChanged(_DField_1, value))
					_DField_1 = value;
			}
		}

		private System.DateTime? _DField_2;
		[Browsable(true), DisplayName("DField_2"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime? DField_2 
		{
			get
			{
				return _DField_2;
			}
			set
			{
			if (PropertyChanged(_DField_2, value))
					_DField_2 = value;
			}
		}

		private System.Int32 _IField_1;
		[Browsable(true), DisplayName("IField_1")]
		public System.Int32 IField_1 
		{
			get
			{
				return _IField_1;
			}
			set
			{
			if (PropertyChanged(_IField_1, value))
					_IField_1 = value;
			}
		}

		private System.Int64 _BField_1;
		[Browsable(true), DisplayName("BField_1")]
		public System.Int64 BField_1 
		{
			get
			{
				return _BField_1;
			}
			set
			{
			if (PropertyChanged(_BField_1, value))
					_BField_1 = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_VoucherTypeKey,_FYKey,_OrgKey,_VoucherDate.Value(StaticInfo.DateFormat),_VoucherNo,_VoucherClient,_PayRec,_VoucherDesc,_IsPost,_PostDate.Value(StaticInfo.DateFormat),_PostBy,_EntryDate.Value(StaticInfo.DateFormat),_EntryUserKey,_LastUpdateDate.Value(StaticInfo.DateFormat),_LastUpdateUserKey,_NField_1,_NField_2,_TField_1,_TField_2,_TField_3,_TField_4,_TField_5,_DField_1,_DField_2,_IField_1,_BField_1,_CheckNo,_CheckDate};
			else if (IsModified)
				parameterValues = new Object[] {_VoucherKey, _VoucherTypeKey,_FYKey,_OrgKey,_VoucherDate.Value(StaticInfo.DateFormat),_VoucherNo,_VoucherClient,_PayRec,_VoucherDesc,_IsPost,_PostDate.Value(StaticInfo.DateFormat),_PostBy,_EntryDate.Value(StaticInfo.DateFormat),_EntryUserKey,_LastUpdateDate.Value(StaticInfo.DateFormat),_LastUpdateUserKey,_NField_1,_NField_2,_TField_1,_TField_2,_TField_3,_TField_4,_TField_5,_DField_1,_DField_2,_IField_1,_BField_1,_CheckNo,_CheckDate};
			else if (IsDeleted)
				parameterValues = new Object[] {_VoucherKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_VoucherKey = reader.GetInt64("VoucherKey");
			_VoucherTypeKey = reader.GetInt32("VoucherTypeKey");
			_FYKey = reader.GetInt32("FYKey");
			_OrgKey = reader.GetInt64("OrgKey");
			_VoucherDate = reader.GetDateTime("VoucherDate");
			_VoucherNo = reader.GetString("VoucherNo");
			_VoucherClient = reader.GetString("VoucherClient");
			_PayRec = reader.GetString("PayRec");
			_VoucherDesc = reader.GetString("VoucherDesc");
			_IsPost = reader.GetInt32("IsPost");
			_PostDate = reader.GetDateTime("PostDate");
			_PostBy = reader.GetInt64("PostBy");
			_EntryDate = reader.GetDateTime("EntryDate");
			_EntryUserKey = reader.GetInt64("EntryUserKey");
			_LastUpdateDate = reader.GetDateTime("LastUpdateDate");
			_LastUpdateUserKey = reader.GetInt64("LastUpdateUserKey");
			_NField_1 = reader.GetDecimal("NField_1");
			_NField_2 = reader.GetDecimal("NField_2");
			_TField_1 = reader.GetString("TField_1");
			_TField_2 = reader.GetString("TField_2");
			_TField_3 = reader.GetString("TField_3");
			_TField_4 = reader.GetString("TField_4");
			_TField_5 = reader.GetString("TField_5");
			_DField_1 = reader.GetDateTime("DField_1");
			_DField_2 = reader.GetDateTime("DField_2");
			_IField_1 = reader.GetInt32("IField_1");
			_BField_1 = reader.GetInt64("BField_1");
            _CheckNo = reader.GetString("CheckNo");
            _CheckDate = reader.GetNullableDateTime("CheckDate");
			SetUnchanged();
		}
        private void SetDataSearch(IDataRecord reader)
        {
            _VoucherKey = reader.GetInt64("VoucherKey");
            _VoucherTypeKey = reader.GetInt32("VoucherTypeKey");
            _VoucherDate = reader.GetDateTime("VoucherDate");
            _VoucherNo = reader.GetString("VoucherNo");
            _PayRec = reader.GetString("PayRec");
            _VoucherDesc = reader.GetString("VoucherDesc");
            SetUnchanged();
        }
		public static CustomList<Acc_Voucher> GetAllAcc_Voucher()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<Acc_Voucher> Acc_VoucherCollection = new CustomList<Acc_Voucher>();
			IDataReader reader = null;
            const String sql = "select VoucherKey,VoucherTypeKey,FYKey,OrgKey,VoucherDate,VoucherNo,VoucherClient,PayRec,VoucherDesc,IsPost,PostDate,PostBy,EntryDate,EntryUserKey,LastUpdateDate,LastUpdateUserKey,NField_1,NField_2,TField_1,TField_2,TField_3,TField_4,TField_5,DField_1,DField_2,IField_1,BField_1,CheckNo,CheckDate from Acc_Voucher Where IsPost=0 Order By VoucherDate Desc";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Acc_Voucher newAcc_Voucher = new Acc_Voucher();
					newAcc_Voucher.SetData(reader);
					Acc_VoucherCollection.Add(newAcc_Voucher);
				}
				Acc_VoucherCollection.InsertSpName = "spInsertAcc_Voucher";
				Acc_VoucherCollection.UpdateSpName = "spUpdateAcc_Voucher";
				Acc_VoucherCollection.DeleteSpName = "spDeleteAcc_Voucher";
				return Acc_VoucherCollection;
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
        public static CustomList<Acc_Voucher> GetAllAcc_VoucherSearch(string searchStr)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_Voucher> Acc_VoucherCollection = new CustomList<Acc_Voucher>();
            IDataReader reader = null;
            String sql = "EXEC spGetVoucher " + searchStr;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_Voucher newAcc_Voucher = new Acc_Voucher();
                    newAcc_Voucher.SetDataSearch(reader);
                    Acc_VoucherCollection.Add(newAcc_Voucher);
                }
                return Acc_VoucherCollection;
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
        public static CustomList<Acc_Voucher> GetAllAcc_VoucherSearch(string searchStr,string blank)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_Voucher> Acc_VoucherCollection = new CustomList<Acc_Voucher>();
            IDataReader reader = null;
            String sql = "EXEC spGetSearchVoucher " + searchStr;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_Voucher newAcc_Voucher = new Acc_Voucher();
                    newAcc_Voucher.SetDataSearch(reader);
                    Acc_VoucherCollection.Add(newAcc_Voucher);
                }
                return Acc_VoucherCollection;
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
        public static Acc_Voucher GetAllAcc_Voucher(string voucherNo)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Acc_Voucher voucher = new Acc_Voucher();
            IDataReader reader = null;
            String sql = "select VoucherKey,VoucherTypeKey,FYKey,OrgKey,VoucherDate,VoucherNo,VoucherClient,PayRec,VoucherDesc,IsPost,PostDate,PostBy,EntryDate,EntryUserKey,LastUpdateDate,LastUpdateUserKey,NField_1,NField_2,TField_1,TField_2,TField_3,TField_4,TField_5,DField_1,DField_2,IField_1,BField_1,CheckNo,CheckDate from Acc_Voucher where VoucherNo='" + voucherNo + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_Voucher newAcc_Voucher = new Acc_Voucher();
                    newAcc_Voucher.SetData(reader);
                    voucher = newAcc_Voucher;
                }
                return voucher;
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