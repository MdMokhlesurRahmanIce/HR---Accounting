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
	public class LineInfo : BaseItem
	{
		public LineInfo()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _LineKey;
		[Browsable(true), DisplayName("LineKey")]
		public System.Int32 LineKey 
		{
			get
			{
				return _LineKey;
			}
			set
			{
			if (PropertyChanged(_LineKey, value))
					_LineKey = value;
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

		private System.String _LineNo;
		[Browsable(true), DisplayName("LineNo")]
		public System.String LineNo 
		{
			get
			{
				return _LineNo;
			}
			set
			{
			if (PropertyChanged(_LineNo, value))
					_LineNo = value;
			}
		}

		private System.String _LineName;
		[Browsable(true), DisplayName("LineName")]
		public System.String LineName 
		{
			get
			{
				return _LineName;
			}
			set
			{
			if (PropertyChanged(_LineName, value))
					_LineName = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_OrgKey,_LineNo,_LineName};
			else if (IsModified)
				parameterValues = new Object[] {_LineKey,_OrgKey,_LineNo,_LineName};
			else if (IsDeleted)
				parameterValues = new Object[] {_LineKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_LineKey = reader.GetInt32("LineKey");
			_OrgKey = reader.GetInt32("OrgKey");
			_LineNo = reader.GetString("LineNo");
			_LineName = reader.GetString("LineName");
			SetUnchanged();
		}
		public static CustomList<LineInfo> GetAllLineInfo(Int32 orgKey)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<LineInfo> LineInfoCollection = new CustomList<LineInfo>();
			IDataReader reader = null;
			String sql = "select *from LineInfo where OrgKey="+orgKey;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					LineInfo newLineInfo = new LineInfo();
					newLineInfo.SetData(reader);
					LineInfoCollection.Add(newLineInfo);
				}
				LineInfoCollection.InsertSpName = "spInsertLineInfo";
				LineInfoCollection.UpdateSpName = "spUpdateLineInfo";
				LineInfoCollection.DeleteSpName = "spDeleteLineInfo";
				return LineInfoCollection;
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
        public static CustomList<LineInfo> GetAllLineInfo()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LineInfo> LineInfoCollection = new CustomList<LineInfo>();
            IDataReader reader = null;
            String sql = "select *from LineInfo";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LineInfo newLineInfo = new LineInfo();
                    newLineInfo.SetData(reader);
                    LineInfoCollection.Add(newLineInfo);
                }
                LineInfoCollection.InsertSpName = "spInsertLineInfo";
                LineInfoCollection.UpdateSpName = "spUpdateLineInfo";
                LineInfoCollection.DeleteSpName = "spDeleteLineInfo";
                return LineInfoCollection;
            }
            catch (Exception ex)
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
