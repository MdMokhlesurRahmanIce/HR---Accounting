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
	public class LoanType : BaseItem
	{
		public LoanType()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _LoanTypeID;
		[Browsable(true), DisplayName("LoanTypeID")]
		public System.Int32 LoanTypeID 
		{
			get
			{
				return _LoanTypeID;
			}
			set
			{
			if (PropertyChanged(_LoanTypeID, value))
					_LoanTypeID = value;
			}
		}

		private System.String _LoanType1;
		[Browsable(true), DisplayName("LoanType1")]
		public System.String LoanType1 
		{
			get
			{
				return _LoanType1;
			}
			set
			{
			if (PropertyChanged(_LoanType1, value))
					_LoanType1 = value;
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

		private System.Decimal _MaxPercent;
		[Browsable(true), DisplayName("MaxPercent")]
		public System.Decimal MaxPercent 
		{
			get
			{
				return _MaxPercent;
			}
			set
			{
			if (PropertyChanged(_MaxPercent, value))
					_MaxPercent = value;
			}
		}

		private System.Int32 _SalaryHead;
		[Browsable(true), DisplayName("SalaryHead")]
		public System.Int32 SalaryHead 
		{
			get
			{
				return _SalaryHead;
			}
			set
			{
			if (PropertyChanged(_SalaryHead, value))
					_SalaryHead = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_LoanType1,_Description,_MaxPercent,_SalaryHead};
			else if (IsModified)
				parameterValues = new Object[] {_LoanType1,_Description,_MaxPercent,_SalaryHead};
			else if (IsDeleted)
				parameterValues = new Object[] {_LoanTypeID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_LoanTypeID = reader.GetInt32("LoanTypeID");
			_LoanType1 = reader.GetString("LoanType");
			_Description = reader.GetString("Description");
			_MaxPercent = reader.GetDecimal("MaxPercent");
			_SalaryHead = reader.GetInt32("SalaryHead");
			SetUnchanged();
		}
		public static CustomList<LoanType> GetAllLoanType()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<LoanType> LoanTypeCollection = new CustomList<LoanType>();
			IDataReader reader = null;
			const String sql = "select *from LoanType";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					LoanType newLoanType = new LoanType();
					newLoanType.SetData(reader);
					LoanTypeCollection.Add(newLoanType);
				}
				LoanTypeCollection.InsertSpName = "spInsertLoanType";
				LoanTypeCollection.UpdateSpName = "spUpdateLoanType";
				LoanTypeCollection.DeleteSpName = "spDeleteLoanType";
				return LoanTypeCollection;
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