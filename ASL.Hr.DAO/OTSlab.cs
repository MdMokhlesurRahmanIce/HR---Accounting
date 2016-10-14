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
	public class OTSlab : BaseItem
	{
		public OTSlab()
		{
			SetAdded();
		}
		
#region Properties

		private System.String _OTSlabID;
		[Browsable(true), DisplayName("OTSlabID")]
		public System.String OTSlabID 
		{
			get
			{
				return _OTSlabID;
			}
			set
			{
			if (PropertyChanged(_OTSlabID, value))
					_OTSlabID = value;
			}
		}

		private System.String _SlabType;
		[Browsable(true), DisplayName("SlabType")]
		public System.String SlabType 
		{
			get
			{
				return _SlabType;
			}
			set
			{
			if (PropertyChanged(_SlabType, value))
					_SlabType = value;
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

		private System.Int32 _SequenceNo;
		[Browsable(true), DisplayName("SequenceNo")]
		public System.Int32 SequenceNo 
		{
			get
			{
				return _SequenceNo;
			}
			set
			{
			if (PropertyChanged(_SequenceNo, value))
					_SequenceNo = value;
			}
		}

		private System.Decimal _Duration;
		[Browsable(true), DisplayName("Duration")]
		public System.Decimal Duration 
		{
			get
			{
				return _Duration;
			}
			set
			{
			if (PropertyChanged(_Duration, value))
					_Duration = value;
			}
		}

		private System.String _RateType;
		[Browsable(true), DisplayName("RateType")]
		public System.String RateType 
		{
			get
			{
				return _RateType;
			}
			set
			{
			if (PropertyChanged(_RateType, value))
					_RateType = value;
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

		private System.Int32 _SalaryHead;
		[Browsable(true), DisplayName("SalaryHead")]
		public System.Int32 SalaryHead 
		{
			get
			{
				return _SalaryHead;
			}
			set
			{
			if (PropertyChanged(_SalaryHead, value))
					_SalaryHead = value;
			}
		}

		private System.Int32 _Days;
		[Browsable(true), DisplayName("Days")]
		public System.Int32 Days 
		{
			get
			{
				return _Days;
			}
			set
			{
			if (PropertyChanged(_Days, value))
					_Days = value;
			}
		}

		private System.Decimal _MultificationFactor;
		[Browsable(true), DisplayName("MultificationFactor")]
		public System.Decimal MultificationFactor 
		{
			get
			{
				return _MultificationFactor;
			}
			set
			{
			if (PropertyChanged(_MultificationFactor, value))
					_MultificationFactor = value;
			}
		}

		private System.String _AddedBy;
		[Browsable(true), DisplayName("AddedBy")]
		public System.String AddedBy 
		{
			get
			{
				return _AddedBy;
			}
			set
			{
			if (PropertyChanged(_AddedBy, value))
					_AddedBy = value;
			}
		}

		private System.DateTime _AddedDate;
		[Browsable(true), DisplayName("AddedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime AddedDate 
		{
			get
			{
				return _AddedDate;
			}
			set
			{
			if (PropertyChanged(_AddedDate, value))
					_AddedDate = value;
			}
		}

		private System.String _UpdatedBy;
		[Browsable(true), DisplayName("UpdatedBy")]
		public System.String UpdatedBy 
		{
			get
			{
				return _UpdatedBy;
			}
			set
			{
			if (PropertyChanged(_UpdatedBy, value))
					_UpdatedBy = value;
			}
		}

		private System.DateTime _UpdatedDate;
		[Browsable(true), DisplayName("UpdatedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
		public System.DateTime UpdatedDate 
		{
			get
			{
				return _UpdatedDate;
			}
			set
			{
			if (PropertyChanged(_UpdatedDate, value))
					_UpdatedDate = value;
			}
		}
        public static Int32 RowCount()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Int32 status = 0;
            try
            {
                String sql = "select COUNT(*) As RowNo from OTSlab";
                Object empCount = conManager.ExecuteScalarWrapper(sql);
                status = Convert.ToInt32(empCount);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return status;
        }
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_OTSlabID,_SlabType,_Description,_SequenceNo,_Duration,_RateType,_Amount,_SalaryHead,_Days,_MultificationFactor,_AddedBy,_AddedDate.Value(StaticInfo.DateFormat),_UpdatedBy,_UpdatedDate.Value(StaticInfo.DateFormat)};
			else if (IsModified)
				parameterValues = new Object[] {_OTSlabID,_SlabType,_Description,_SequenceNo,_Duration,_RateType,_Amount,_SalaryHead,_Days,_MultificationFactor,_AddedBy,_AddedDate.Value(StaticInfo.DateFormat),_UpdatedBy,_UpdatedDate.Value(StaticInfo.DateFormat)};
			else if (IsDeleted)
				parameterValues = new Object[] {_OTSlabID,_SlabType};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_OTSlabID = reader.GetString("OTSlabID");
			_SlabType = reader.GetString("SlabType");
			_Description = reader.GetString("Description");
			_SequenceNo = reader.GetInt32("SequenceNo");
			_Duration = reader.GetDecimal("Duration");
			_RateType = reader.GetString("RateType");
			_Amount = reader.GetDecimal("Amount");
			_SalaryHead = reader.GetInt32("SalaryHead");
			_Days = reader.GetInt32("Days");
			_MultificationFactor = reader.GetDecimal("MultificationFactor");
			_AddedBy = reader.GetString("AddedBy");
			_AddedDate = reader.GetDateTime("AddedDate");
			_UpdatedBy = reader.GetString("UpdatedBy");
			_UpdatedDate = reader.GetDateTime("UpdatedDate");
			SetUnchanged();
		}
        private void SetDataOTSlab(IDataRecord reader)
        {
            _OTSlabID = reader.GetString("OTSlabID");
            SetUnchanged();
        }
		public static CustomList<OTSlab> GetAllOTSlab()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<OTSlab> OTSlabCollection = new CustomList<OTSlab>();
			IDataReader reader = null;
            const String sql = "select Distinct OTSlabID from OTSlab";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					OTSlab newOTSlab = new OTSlab();
					newOTSlab.SetDataOTSlab(reader);
					OTSlabCollection.Add(newOTSlab);
				}
				OTSlabCollection.InsertSpName = "spInsertOTSlab";
				OTSlabCollection.UpdateSpName = "spUpdateOTSlab";
				OTSlabCollection.DeleteSpName = "spDeleteOTSlab";
				return OTSlabCollection;
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
        public static CustomList<OTSlab> GetAllOTSlab(string otSlabID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<OTSlab> OTSlabCollection = new CustomList<OTSlab>();
            IDataReader reader = null;
            String sql = "select *from OTSlab where OTSlabID = " + otSlabID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    OTSlab newOTSlab = new OTSlab();
                    newOTSlab.SetData(reader);
                    OTSlabCollection.Add(newOTSlab);
                }
                return OTSlabCollection;
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
