using System;
using System.Web;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Security.DAO
{
	[Serializable]
	public class UserProfile : BaseItem
	{
		public UserProfile()
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

		private System.String _ThemeName;
		[Browsable(true), DisplayName("ThemeName")]
		public System.String ThemeName 
		{
			get
			{
				return _ThemeName;
			}
			set
			{
			if (PropertyChanged(_ThemeName, value))
					_ThemeName = value;
			}
		}

		private System.Int32 _DefaultAppID;
		[Browsable(true), DisplayName("DefaultAppID")]
		public System.Int32 DefaultAppID 
		{
			get
			{
				return _DefaultAppID;
			}
			set
			{
			if (PropertyChanged(_DefaultAppID, value))
					_DefaultAppID = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_UserCode,_ThemeName,_DefaultAppID};
			else if (IsModified)
				parameterValues = new Object[] {_UserCode,_ThemeName,_DefaultAppID};
			else if (IsDeleted)
				parameterValues = new Object[] {_UserCode};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_UserCode = reader.GetString("UserCode");
			_ThemeName = reader.GetString("ThemeName");
			_DefaultAppID = reader.GetInt32("DefaultAppID");
			SetUnchanged();
		}
		public static CustomList<UserProfile> GetAllUserProfile(String userCode)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
			CustomList<UserProfile> UserProfileCollection = new CustomList<UserProfile>();
			IDataReader reader = null;
            String sql = "select  *from UserProfile Where UserCode='" + userCode + "'";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					UserProfile newUserProfile = new UserProfile();
					newUserProfile.SetData(reader);
					UserProfileCollection.Add(newUserProfile);
				}
				return UserProfileCollection;
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
