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
	public class SalaryHead : BaseItem
	{
		public SalaryHead()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _SalaryHeadKey;
		[Browsable(true), DisplayName("SalaryHeadKey")]
		public System.Int32 SalaryHeadKey 
		{
			get
			{
				return _SalaryHeadKey;
			}
			set
			{
			if (PropertyChanged(_SalaryHeadKey, value))
					_SalaryHeadKey = value;
			}
		}

		private System.String _HeadName;
		[Browsable(true), DisplayName("HeadName")]
		public System.String HeadName 
		{
			get
			{
				return _HeadName;
			}
			set
			{
			if (PropertyChanged(_HeadName, value))
					_HeadName = value;
			}
		}

		private System.String _Description;
		[Browsable(true), DisplayName("Description")]
		public System.String Description 
		{
			get
			{
				return _Description;
			}
			set
			{
			if (PropertyChanged(_Description, value))
					_Description = value;
			}
		}

		private System.String _HeadType;
		[Browsable(true), DisplayName("HeadType")]
		public System.String HeadType 
		{
			get
			{
				return _HeadType;
			}
			set
			{
			if (PropertyChanged(_HeadType, value))
					_HeadType = value;
			}
		}

		private System.Int32 _SequenceNo;
		[Browsable(true), DisplayName("SequenceNo")]
		public System.Int32 SequenceNo 
		{
			get
			{
				return _SequenceNo;
			}
			set
			{
			if (PropertyChanged(_SequenceNo, value))
					_SequenceNo = value;
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

		private System.Boolean _IsDisburse;
		[Browsable(true), DisplayName("IsDisburse")]
		public System.Boolean IsDisburse 
		{
			get
			{
				return _IsDisburse;
			}
			set
			{
			if (PropertyChanged(_IsDisburse, value))
					_IsDisburse = value;
			}
		}

		private System.Boolean _IsPerquisite;
		[Browsable(true), DisplayName("IsPerquisite")]
		public System.Boolean IsPerquisite 
		{
			get
			{
				return _IsPerquisite;
			}
			set
			{
			if (PropertyChanged(_IsPerquisite, value))
					_IsPerquisite = value;
			}
		}

        private System.Boolean _IsChecked;
        [Browsable(true), DisplayName("IsChecked")]
        public System.Boolean IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                if (PropertyChanged(_IsChecked, value))
                    _IsChecked = value;
            }
        }

        private System.String _ShortName;
        [Browsable(true), DisplayName("ShortName")]
        public System.String ShortName
        {
            get
            {
                return _ShortName;
            }
            set
            {
                if (PropertyChanged(_ShortName, value))
                    _ShortName = value;
            }
        }

        private System.Decimal _DefaultAmount;
        [Browsable(true), DisplayName("DefaultAmount")]
        public System.Decimal DefaultAmount
        {
            get
            {
                return _DefaultAmount;
            }
            set
            {
                if (PropertyChanged(_DefaultAmount, value))
                    _DefaultAmount = value;
            }
        }
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_HeadName,_Description,_HeadType,_SequenceNo,_IsVisible,_IsDisburse,_IsPerquisite};
			else if (IsModified)
				parameterValues = new Object[] {_SalaryHeadKey, _HeadName,_Description,_HeadType,_SequenceNo,_IsVisible,_IsDisburse,_IsPerquisite};
			else if (IsDeleted)
				parameterValues = new Object[] {_SalaryHeadKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
			_HeadName = reader.GetString("HeadName");
			_Description = reader.GetString("Description");
			_HeadType = reader.GetString("HeadType");
			_SequenceNo = reader.GetInt32("SequenceNo");
			_IsVisible = reader.GetBoolean("IsVisible");
			_IsDisburse = reader.GetBoolean("IsDisburse");
			_IsPerquisite = reader.GetBoolean("IsPerquisite");
			SetUnchanged();
		}
        private void SetDataSR(IDataRecord reader)
        {
            _SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
            _HeadName = reader.GetString("HeadName");
            SetUnchanged();
        }
        private void SetDataMisc(IDataRecord reader)
        {
            _SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
            _HeadName = reader.GetString("HeadName");
            _ShortName = reader.GetString("ShortName");
            SetUnchanged();
        }
		public static CustomList<SalaryHead> GetAllSalaryHeadForSalaryRule()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<SalaryHead> SalaryHeadCollection = new CustomList<SalaryHead>();
			IDataReader reader = null;
			const String sql = "select SalaryHeadKey,HeadName from SalaryHead";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					SalaryHead newSalaryHead = new SalaryHead();
                    newSalaryHead.SetDataSR(reader);
					SalaryHeadCollection.Add(newSalaryHead);
				}
				SalaryHeadCollection.InsertSpName = "spInsertSalaryHead";
				SalaryHeadCollection.UpdateSpName = "spUpdateSalaryHead";
				SalaryHeadCollection.DeleteSpName = "spDeleteSalaryHead";
				return SalaryHeadCollection;
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
        public static CustomList<SalaryHead> GetAllSalaryHead()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryHead> SalaryHeadCollection = new CustomList<SalaryHead>();
            IDataReader reader = null;
            const String sql = "select * from SalaryHead";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryHead newSalaryHead = new SalaryHead();
                    newSalaryHead.SetData(reader);
                    SalaryHeadCollection.Add(newSalaryHead);
                }
                SalaryHeadCollection.InsertSpName = "spInsertSalaryHead";
                SalaryHeadCollection.UpdateSpName = "spUpdateSalaryHead";
                SalaryHeadCollection.DeleteSpName = "spDeleteSalaryHead";
                return SalaryHeadCollection;
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
        public static CustomList<SalaryHead> GetAllSalaryHeadForMisc()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryHead> SalaryHeadCollection = new CustomList<SalaryHead>();
            IDataReader reader = null;
            const String sql = "EXEC GetAllSalaryHead";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryHead newSalaryHead = new SalaryHead();
                    newSalaryHead.SetDataMisc(reader);
                    SalaryHeadCollection.Add(newSalaryHead);
                }
                return SalaryHeadCollection;
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
