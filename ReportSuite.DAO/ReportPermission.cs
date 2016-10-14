using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ReportSuite.DAO
{
	[Serializable]
	public class ReportPermission : BaseItem
	{
		public ReportPermission()
		{
			SetAdded();
		}
		
#region Properties

		private System.String _UserCode;
		[Browsable(true), DisplayName("UserCode")]
		public System.String UserCode 
		{
			get
			{
				return _UserCode;
			}
			set
			{
			if (PropertyChanged(_UserCode, value))
					_UserCode = value;
			}
		}

        private System.String _ReportName;
        [Browsable(true), DisplayName("ReportName")]
        public System.String ReportName
        {
            get
            {
                return _ReportName;
            }
            set
            {
                if (PropertyChanged(_ReportName, value))
                    _ReportName = value;
            }
        }

		private System.String _ReportID;
		[Browsable(true), DisplayName("ReportID")]
		public System.String ReportID 
		{
			get
			{
				return _ReportID;
			}
			set
			{
			if (PropertyChanged(_ReportID, value))
					_ReportID = value;
			}
		}

		private System.Boolean _IsVissible;
		[Browsable(true), DisplayName("IsVissible")]
		public System.Boolean IsVissible 
		{
			get
			{
				return _IsVissible;
			}
			set
			{
			if (PropertyChanged(_IsVissible, value))
					_IsVissible = value;
			}
		}

		private System.Boolean _IsPreview;
		[Browsable(true), DisplayName("IsPreview")]
		public System.Boolean IsPreview 
		{
			get
			{
				return _IsPreview;
			}
			set
			{
			if (PropertyChanged(_IsPreview, value))
					_IsPreview = value;
			}
		}

		private System.Boolean _IsPrint;
		[Browsable(true), DisplayName("IsPrint")]
		public System.Boolean IsPrint 
		{
			get
			{
				return _IsPrint;
			}
			set
			{
			if (PropertyChanged(_IsPrint, value))
					_IsPrint = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_UserCode,_ReportID,_IsVissible,_IsPreview,_IsPrint};
			else if (IsModified)
				parameterValues = new Object[] {_UserCode,_ReportID,_IsVissible,_IsPreview,_IsPrint};
			else if (IsDeleted)
                parameterValues = new Object[] { _UserCode, _ReportID };
			return parameterValues;
		}
        
		protected override void SetData(IDataRecord reader)
		{
			_UserCode = reader.GetString("UserCode");
			_ReportID = reader.GetString("ReportID");
            _ReportName = reader.GetString("ReportName");
			_IsVissible = reader.GetBoolean("IsVissible");
			_IsPreview = reader.GetBoolean("IsPreview");
			_IsPrint = reader.GetBoolean("IsPrint");
			SetUnchanged();
		}
        private void SetDataByUserCode(IDataRecord reader)
		{
			_UserCode = reader.GetString("UserCode");
			_ReportID = reader.GetString("ReportID");
			_IsVissible = reader.GetBoolean("IsVissible");
			_IsPreview = reader.GetBoolean("IsPreview");
			_IsPrint = reader.GetBoolean("IsPrint");
			SetUnchanged();
		}
		public static CustomList<ReportPermission> GetAllReportPermissionByUsercode(string userCode)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<ReportPermission> ReportPermissionCollection = new CustomList<ReportPermission>();
			IDataReader reader = null;
            String sql = "Exec spGetReportPermission '" + userCode + "'";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					ReportPermission newReportPermission = new ReportPermission();
					newReportPermission.SetData(reader);
					ReportPermissionCollection.Add(newReportPermission);
				}
				ReportPermissionCollection.InsertSpName = "spInsertReportPermission";
				ReportPermissionCollection.UpdateSpName = "spUpdateReportPermission";
				ReportPermissionCollection.DeleteSpName = "spDeleteReportPermission";
				return ReportPermissionCollection;
			}
			catch(Exception ex)
			{
				throw (ex);
			}
			finally
			{
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }

				if (reader != null && !reader.IsClosed)
					reader.Close();
			}
		}
        public static CustomList<ReportPermission> GetAllReportPermission(string userCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ReportPermission> ReportPermissionCollection = new CustomList<ReportPermission>();
            IDataReader reader = null;
            String sql = "select *from ReportPermission Where UserCode='" + userCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ReportPermission newReportPermission = new ReportPermission();
                    newReportPermission.SetDataByUserCode(reader);
                    ReportPermissionCollection.Add(newReportPermission);
                }
                ReportPermissionCollection.InsertSpName = "spInsertReportPermission";
                ReportPermissionCollection.UpdateSpName = "spUpdateReportPermission";
                ReportPermissionCollection.DeleteSpName = "spDeleteReportPermission";
                return ReportPermissionCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }

                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
	}
}
