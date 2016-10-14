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
	public class EmployeeHKInfo : BaseItem
	{
		public EmployeeHKInfo()
		{
			SetAdded();
		}
		
#region Properties

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

		private System.Int32 _HKID;
		[Browsable(true), DisplayName("HKID")]
		public System.Int32 HKID 
		{
			get
			{
				return _HKID;
			}
			set
			{
			if (PropertyChanged(_HKID, value))
					_HKID = value;
			}
		}

		private System.String _HKName;
		[Browsable(true), DisplayName("HKName")]
		public System.String HKName 
		{
			get
			{
				return _HKName;
			}
			set
			{
			if (PropertyChanged(_HKName, value))
					_HKName = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpKey,_HKID,_HKName};
			else if (IsModified)
				parameterValues = new Object[] {_EmpKey,_HKID,_HKName};
			else if (IsDeleted)
				parameterValues = new Object[] {_EmpKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_EmpKey = reader.GetInt64("EmpKey");
			_HKID = reader.GetInt32("HKID");
			_HKName = reader.GetString("HKName");
			SetUnchanged();
		}
		public static CustomList<EmployeeHKInfo> GetAllEmployeeHKInfo(Int64 empKey)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<EmployeeHKInfo> EmployeeHKInfoCollection = new CustomList<EmployeeHKInfo>();
			IDataReader reader = null;
            String sql = "select *from EmployeeHKInfo where EmpKey=" + empKey;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					EmployeeHKInfo newEmployeeHKInfo = new EmployeeHKInfo();
					newEmployeeHKInfo.SetData(reader);
					EmployeeHKInfoCollection.Add(newEmployeeHKInfo);
				}
				EmployeeHKInfoCollection.InsertSpName = "spInsertEmployeeHKInfo";
				EmployeeHKInfoCollection.UpdateSpName = "spUpdateEmployeeHKInfo";
				EmployeeHKInfoCollection.DeleteSpName = "spDeleteEmployeeHKInfo";
				return EmployeeHKInfoCollection;
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
