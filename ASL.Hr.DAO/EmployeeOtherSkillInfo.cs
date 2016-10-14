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
	public class EmployeeOtherSkillInfo : BaseItem
	{
		public EmployeeOtherSkillInfo()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int64 _ID;
		[Browsable(true), DisplayName("ID")]
		public System.Int64 ID 
		{
			get
			{
				return _ID;
			}
			set
			{
			if (PropertyChanged(_ID, value))
					_ID = value;
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

		private System.String _SkillCategory;
		[Browsable(true), DisplayName("SkillCategory")]
		public System.String SkillCategory 
		{
			get
			{
				return _SkillCategory;
			}
			set
			{
			if (PropertyChanged(_SkillCategory, value))
					_SkillCategory = value;
			}
		}

		private System.String _SkillArea;
		[Browsable(true), DisplayName("SkillArea")]
		public System.String SkillArea 
		{
			get
			{
				return _SkillArea;
			}
			set
			{
			if (PropertyChanged(_SkillArea, value))
					_SkillArea = value;
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

		private System.String _StandardRating;
		[Browsable(true), DisplayName("StandardRating")]
		public System.String StandardRating 
		{
			get
			{
				return _StandardRating;
			}
			set
			{
			if (PropertyChanged(_StandardRating, value))
					_StandardRating = value;
			}
		}

		private System.String _CurrentRating;
		[Browsable(true), DisplayName("CurrentRating")]
		public System.String CurrentRating 
		{
			get
			{
				return _CurrentRating;
			}
			set
			{
			if (PropertyChanged(_CurrentRating, value))
					_CurrentRating = value;
			}
		}

		private System.String _InitialRating;
		[Browsable(true), DisplayName("InitialRating")]
		public System.String InitialRating 
		{
			get
			{
				return _InitialRating;
			}
			set
			{
			if (PropertyChanged(_InitialRating, value))
					_InitialRating = value;
			}
		}

		private System.String _Status;
		[Browsable(true), DisplayName("Status")]
		public System.String Status 
		{
			get
			{
				return _Status;
			}
			set
			{
			if (PropertyChanged(_Status, value))
					_Status = value;
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

		private System.DateTime _ReviewDate;
		[Browsable(true), DisplayName("ReviewDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime ReviewDate 
		{
			get
			{
				return _ReviewDate;
			}
			set
			{
			if (PropertyChanged(_ReviewDate, value))
					_ReviewDate = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpKey,_SkillCategory,_SkillArea,_Description,_StandardRating,_CurrentRating,_InitialRating,_Status,_Remarks,_ReviewDate.Value(StaticInfo.DateFormat)};
			else if (IsModified)
				parameterValues = new Object[] {_EmpKey,_SkillCategory,_SkillArea,_Description,_StandardRating,_CurrentRating,_InitialRating,_Status,_Remarks,_ReviewDate.Value(StaticInfo.DateFormat)};
			else if (IsDeleted)
				parameterValues = new Object[] {_ID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_ID = reader.GetInt64("ID");
			_EmpKey = reader.GetInt64("EmpKey");
			_SkillCategory = reader.GetString("SkillCategory");
			_SkillArea = reader.GetString("SkillArea");
			_Description = reader.GetString("Description");
			_StandardRating = reader.GetString("StandardRating");
			_CurrentRating = reader.GetString("CurrentRating");
			_InitialRating = reader.GetString("InitialRating");
			_Status = reader.GetString("Status");
			_Remarks = reader.GetString("Remarks");
			_ReviewDate = reader.GetDateTime("ReviewDate");
			SetUnchanged();
		}
		public static CustomList<EmployeeOtherSkillInfo> GetAllEmployeeOtherSkillInfo()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<EmployeeOtherSkillInfo> EmployeeOtherSkillInfoCollection = new CustomList<EmployeeOtherSkillInfo>();
			IDataReader reader = null;
			const String sql = "select *from EmployeeOtherSkillInfo";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					EmployeeOtherSkillInfo newEmployeeOtherSkillInfo = new EmployeeOtherSkillInfo();
					newEmployeeOtherSkillInfo.SetData(reader);
					EmployeeOtherSkillInfoCollection.Add(newEmployeeOtherSkillInfo);
				}
				EmployeeOtherSkillInfoCollection.InsertSpName = "spInsertEmployeeOtherSkillInfo";
				EmployeeOtherSkillInfoCollection.UpdateSpName = "spUpdateEmployeeOtherSkillInfo";
				EmployeeOtherSkillInfoCollection.DeleteSpName = "spDeleteEmployeeOtherSkillInfo";
				return EmployeeOtherSkillInfoCollection;
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