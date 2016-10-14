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
	public class HRM_PolicyFileAttach : BaseItem
	{
		public HRM_PolicyFileAttach()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int64 _PolicyAttachKey;
		[Browsable(true), DisplayName("PolicyAttachKey")]
		public System.Int64 PolicyAttachKey 
		{
			get
			{
				return _PolicyAttachKey;
			}
			set
			{
			if (PropertyChanged(_PolicyAttachKey, value))
					_PolicyAttachKey = value;
			}
		}

		private System.Int32 _OrgKey;
		[Browsable(true), DisplayName("OrgKey")]
		public System.Int32 OrgKey 
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

		private System.String _FilePath;
		[Browsable(true), DisplayName("FilePath")]
		public System.String FilePath 
		{
			get
			{
				return _FilePath;
			}
			set
			{
			if (PropertyChanged(_FilePath, value))
					_FilePath = value;
			}
		}

		private System.String _FileName;
		[Browsable(true), DisplayName("FileName")]
		public System.String FileName 
		{
			get
			{
				return _FileName;
			}
			set
			{
			if (PropertyChanged(_FileName, value))
					_FileName = value;
			}
		}

		private System.DateTime _AttachDate;
		[Browsable(true), DisplayName("AttachDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime AttachDate 
		{
			get
			{
				return _AttachDate;
			}
			set
			{
			if (PropertyChanged(_AttachDate, value))
					_AttachDate = value;
			}
		}

		private System.String _AttachDesc;
		[Browsable(true), DisplayName("AttachDesc")]
		public System.String AttachDesc 
		{
			get
			{
				return _AttachDesc;
			}
			set
			{
			if (PropertyChanged(_AttachDesc, value))
					_AttachDesc = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_OrgKey,_FilePath,_FileName,_AttachDate.Value(StaticInfo.DateFormat),_AttachDesc};
			else if (IsModified)
                parameterValues = new Object[] { _PolicyAttachKey,_OrgKey, _FilePath, _FileName, _AttachDate.Value(StaticInfo.DateFormat), _AttachDesc };
			else if (IsDeleted)
				parameterValues = new Object[] {_PolicyAttachKey,_OrgKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_PolicyAttachKey = reader.GetInt64("PolicyAttachKey");
			_OrgKey = reader.GetInt32("OrgKey");
			_FilePath = reader.GetString("FilePath");
			_FileName = reader.GetString("FileName");
			_AttachDate = reader.GetDateTime("AttachDate");
			_AttachDesc = reader.GetString("AttachDesc");
			SetUnchanged();
		}
		public static CustomList<HRM_PolicyFileAttach> GetAllHRM_PolicyFileAttach()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<HRM_PolicyFileAttach> HRM_PolicyFileAttachCollection = new CustomList<HRM_PolicyFileAttach>();
			IDataReader reader = null;
			const String sql = "select *from HRM_PolicyFileAttach";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					HRM_PolicyFileAttach newHRM_PolicyFileAttach = new HRM_PolicyFileAttach();
					newHRM_PolicyFileAttach.SetData(reader);
					HRM_PolicyFileAttachCollection.Add(newHRM_PolicyFileAttach);
				}
				HRM_PolicyFileAttachCollection.InsertSpName = "spInsertHRM_PolicyFileAttach";
				HRM_PolicyFileAttachCollection.UpdateSpName = "spUpdateHRM_PolicyFileAttach";
				HRM_PolicyFileAttachCollection.DeleteSpName = "spDeleteHRM_PolicyFileAttach";
				return HRM_PolicyFileAttachCollection;
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
