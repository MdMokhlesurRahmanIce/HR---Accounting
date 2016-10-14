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
	public class Bank_Branch : BaseItem
	{
		public Bank_Branch()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _BranchKey;
		[Browsable(true), DisplayName("BranchKey")]
		public System.Int32 BranchKey 
		{
			get
			{
				return _BranchKey;
			}
			set
			{
			if (PropertyChanged(_BranchKey, value))
					_BranchKey = value;
			}
		}

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

		private System.String _BranchName;
		[Browsable(true), DisplayName("BranchName")]
		public System.String BranchName 
		{
			get
			{
				return _BranchName;
			}
			set
			{
			if (PropertyChanged(_BranchName, value))
					_BranchName = value;
			}
		}

		private System.String _BranchSName;
		[Browsable(true), DisplayName("BranchSName")]
		public System.String BranchSName 
		{
			get
			{
				return _BranchSName;
			}
			set
			{
			if (PropertyChanged(_BranchSName, value))
					_BranchSName = value;
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

		private System.String _ContractPerson;
		[Browsable(true), DisplayName("ContractPerson")]
		public System.String ContractPerson 
		{
			get
			{
				return _ContractPerson;
			}
			set
			{
			if (PropertyChanged(_ContractPerson, value))
					_ContractPerson = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_BankKey,_BranchName,_BranchSName,_Address,_ContractPerson};
			else if (IsModified)
                parameterValues = new Object[] { _BranchKey,_BankKey, _BranchName, _BranchSName, _Address, _ContractPerson };
			else if (IsDeleted)
				parameterValues = new Object[] {_BranchKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_BranchKey = reader.GetInt32("BranchKey");
			_BankKey = reader.GetInt32("BankKey");
			_BranchName = reader.GetString("BranchName");
			_BranchSName = reader.GetString("BranchSName");
			_Address = reader.GetString("Address");
			_ContractPerson = reader.GetString("ContractPerson");
			SetUnchanged();
		}
		public static CustomList<Bank_Branch> GetAllBank_Branch(Int32 bankKey)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<Bank_Branch> Bank_BranchCollection = new CustomList<Bank_Branch>();
			IDataReader reader = null;
            String sql = "Select *from Bank_Branch";// where BankKey=" + bankKey;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Bank_Branch newBank_Branch = new Bank_Branch();
					newBank_Branch.SetData(reader);
					Bank_BranchCollection.Add(newBank_Branch);
				}
				return Bank_BranchCollection;
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
	}
}
