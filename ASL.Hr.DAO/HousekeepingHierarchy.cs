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
	public class HousekeepingHierarchy : BaseItem
	{
		public HousekeepingHierarchy()
		{
			SetAdded();
		}
		
#region Properties

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

		private System.Int32 _ParentID;
		[Browsable(true), DisplayName("ParentID")]
		public System.Int32 ParentID 
		{
			get
			{
				return _ParentID;
			}
			set
			{
			if (PropertyChanged(_ParentID, value))
					_ParentID = value;
			}
		}


		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_HKID,_ParentID};
			else if (IsModified)
				parameterValues = new Object[] {_HKID,_ParentID};
			else if (IsDeleted)
				parameterValues = new Object[] {_HKID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_HKID = reader.GetInt32("HKID");
			_ParentID = reader.GetInt32("ParentID");
			SetUnchanged();
		}
		public static CustomList<HousekeepingHierarchy> GetAllHousekeepingHierarchy(Int32 hKID)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<HousekeepingHierarchy> HousekeepingHierarchyCollection = new CustomList<HousekeepingHierarchy>();
			IDataReader reader = null;
            String sql = "select *from HousekeepingHierarchy where HKID=" + hKID;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					HousekeepingHierarchy newHousekeepingHierarchy = new HousekeepingHierarchy();
					newHousekeepingHierarchy.SetData(reader);
					HousekeepingHierarchyCollection.Add(newHousekeepingHierarchy);
				}
				return HousekeepingHierarchyCollection;
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
