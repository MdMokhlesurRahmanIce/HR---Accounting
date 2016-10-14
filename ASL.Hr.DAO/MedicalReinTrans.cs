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
	public class MedicalReinTrans : BaseItem
	{
		public MedicalReinTrans()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int64 _TransKey;
		[Browsable(true), DisplayName("TransKey")]
		public System.Int64 TransKey 
		{
			get
			{
				return _TransKey;
			}
			set
			{
			if (PropertyChanged(_TransKey, value))
					_TransKey = value;
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

		private System.DateTime _TransDate;
		[Browsable(true), DisplayName("TransDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime TransDate 
		{
			get
			{
				return _TransDate;
			}
			set
			{
			if (PropertyChanged(_TransDate, value))
					_TransDate = value;
			}
		}

		private System.Int32 _Type;
		[Browsable(true), DisplayName("Type")]
		public System.Int32 Type 
		{
			get
			{
				return _Type;
			}
			set
			{
			if (PropertyChanged(_Type, value))
					_Type = value;
			}
		}

		private System.Decimal _Amount;
		[Browsable(true), DisplayName("Amount")]
		public System.Decimal Amount 
		{
			get
			{
				return _Amount;
			}
			set
			{
			if (PropertyChanged(_Amount, value))
					_Amount = value;
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
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpKey,_FYKey,_TransDate.Value(StaticInfo.DateFormat),_Type,_Amount,_Description,_Remarks};
			else if (IsModified)
                parameterValues = new Object[] { _TransKey,_EmpKey, _FYKey, _TransDate.Value(StaticInfo.DateFormat), _Type, _Amount, _Description, _Remarks };
			else if (IsDeleted)
				parameterValues = new Object[] {_TransKey,_EmpKey,_FYKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_TransKey = reader.GetInt64("TransKey");
			_EmpKey = reader.GetInt64("EmpKey");
			_FYKey = reader.GetInt32("FYKey");
			_TransDate = reader.GetDateTime("TransDate");
			_Type = reader.GetInt32("Type");
			_Amount = reader.GetDecimal("Amount");
			_Description = reader.GetString("Description");
			_Remarks = reader.GetString("Remarks");
			SetUnchanged();
		}
		public static CustomList<MedicalReinTrans> GetAllMedicalReinTrans(string empKey,string fyKey)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<MedicalReinTrans> MedicalReinTransCollection = new CustomList<MedicalReinTrans>();
			IDataReader reader = null;
            String sql = "select *from MedicalReinTrans Where EmpKey=" + empKey + " And FYKey=" + fyKey;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					MedicalReinTrans newMedicalReinTrans = new MedicalReinTrans();
					newMedicalReinTrans.SetData(reader);
					MedicalReinTransCollection.Add(newMedicalReinTrans);
				}
				return MedicalReinTransCollection;
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