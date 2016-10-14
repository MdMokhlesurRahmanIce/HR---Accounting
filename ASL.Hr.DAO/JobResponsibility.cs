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
	public class JobResponsibility : BaseItem
	{
		public JobResponsibility()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int64 _JobKey;
		[Browsable(true), DisplayName("JobKey")]
		public System.Int64 JobKey 
		{
			get
			{
				return _JobKey;
			}
			set
			{
			if (PropertyChanged(_JobKey, value))
					_JobKey = value;
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

		private System.String _JobName;
		[Browsable(true), DisplayName("JobName")]
		public System.String JobName 
		{
			get
			{
				return _JobName;
			}
			set
			{
			if (PropertyChanged(_JobName, value))
					_JobName = value;
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

		private System.DateTime _From;
		[Browsable(true), DisplayName("From"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime From 
		{
			get
			{
				return _From;
			}
			set
			{
			if (PropertyChanged(_From, value))
					_From = value;
			}
		}

		private System.DateTime _To;
		[Browsable(true), DisplayName("To"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime To 
		{
			get
			{
				return _To;
			}
			set
			{
			if (PropertyChanged(_To, value))
					_To = value;
			}
		}

		private System.String _Weight;
		[Browsable(true), DisplayName("Weight")]
		public System.String Weight 
		{
			get
			{
				return _Weight;
			}
			set
			{
			if (PropertyChanged(_Weight, value))
					_Weight = value;
			}
		}

		private System.DateTime _AssignDate;
		[Browsable(true), DisplayName("AssignDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime AssignDate 
		{
			get
			{
				return _AssignDate;
			}
			set
			{
			if (PropertyChanged(_AssignDate, value))
					_AssignDate = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpKey,_JobName,_Description,_From.Value(StaticInfo.DateFormat),_To.Value(StaticInfo.DateFormat),_Weight,_AssignDate.Value(StaticInfo.DateFormat)};
			else if (IsModified)
                parameterValues = new Object[] { _JobKey,_EmpKey, _JobName, _Description, _From.Value(StaticInfo.DateFormat), _To.Value(StaticInfo.DateFormat), _Weight, _AssignDate.Value(StaticInfo.DateFormat) };
			else if (IsDeleted)
				parameterValues = new Object[] {_JobKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_JobKey = reader.GetInt64("JobKey");
			_EmpKey = reader.GetInt64("EmpKey");
			_JobName = reader.GetString("JobName");
			_Description = reader.GetString("Description");
			_From = reader.GetDateTime("From");
			_To = reader.GetDateTime("To");
			_Weight = reader.GetString("Weight");
			_AssignDate = reader.GetDateTime("AssignDate");
			SetUnchanged();
		}
		public static CustomList<JobResponsibility> GetAllJobResponsibility(long empKey)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<JobResponsibility> JobResponsibilityCollection = new CustomList<JobResponsibility>();
			IDataReader reader = null;
            String sql = "select  *from JobResponsibility Where EmpKey=" + empKey;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					JobResponsibility newJobResponsibility = new JobResponsibility();
					newJobResponsibility.SetData(reader);
					JobResponsibilityCollection.Add(newJobResponsibility);
				}
				return JobResponsibilityCollection;
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
