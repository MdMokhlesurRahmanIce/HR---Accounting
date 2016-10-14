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
	public class Reactive : BaseItem
	{
		public Reactive()
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

		private System.DateTime _DOJ;
		[Browsable(true), DisplayName("DOJ"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime DOJ 
		{
			get
			{
				return _DOJ;
			}
			set
			{
			if (PropertyChanged(_DOJ, value))
					_DOJ = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_EmpKey,_DOJ.Value(StaticInfo.DateFormat)};
			else if (IsModified)
				parameterValues = new Object[] {_EmpKey,_DOJ.Value(StaticInfo.DateFormat)};
			else if (IsDeleted)
				parameterValues = new Object[] {_ID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_ID = reader.GetInt64("ID");
			_EmpKey = reader.GetInt64("EmpKey");
			_DOJ = reader.GetDateTime("DOJ");
			SetUnchanged();
		}
		public static CustomList<Reactive> GetAllReactive()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<Reactive> ReactiveCollection = new CustomList<Reactive>();
			IDataReader reader = null;
			const String sql = "select *from Reactive";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Reactive newReactive = new Reactive();
					newReactive.SetData(reader);
					ReactiveCollection.Add(newReactive);
				}
				ReactiveCollection.InsertSpName = "spInsertReactive";
				ReactiveCollection.UpdateSpName = "spUpdateReactive";
				ReactiveCollection.DeleteSpName = "spDeleteReactive";
				return ReactiveCollection;
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