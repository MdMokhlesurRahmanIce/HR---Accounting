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
	public class Contact : BaseItem
	{
		public Contact()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _ID;
		[Browsable(true), DisplayName("ID")]
		public System.Int32 ID 
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

		private System.String _Name;
		[Browsable(true), DisplayName("Name")]
		public System.String Name 
		{
			get
			{
				return _Name;
			}
			set
			{
			if (PropertyChanged(_Name, value))
					_Name = value;
			}
		}

		private System.String _CardNo;
		[Browsable(true), DisplayName("CardNo")]
		public System.String CardNo 
		{
			get
			{
				return _CardNo;
			}
			set
			{
			if (PropertyChanged(_CardNo, value))
					_CardNo = value;
			}
		}

		private System.String _Address;
		[Browsable(true), DisplayName("Address")]
		public System.String Address 
		{
			get
			{
				return _Address;
			}
			set
			{
			if (PropertyChanged(_Address, value))
					_Address = value;
			}
		}

		private System.String _Email;
		[Browsable(true), DisplayName("Email")]
		public System.String Email 
		{
			get
			{
				return _Email;
			}
			set
			{
			if (PropertyChanged(_Email, value))
					_Email = value;
			}
		}

		private System.String _Mobile;
		[Browsable(true), DisplayName("Mobile")]
		public System.String Mobile 
		{
			get
			{
				return _Mobile;
			}
			set
			{
			if (PropertyChanged(_Mobile, value))
					_Mobile = value;
			}
		}

		private System.String _Phone;
		[Browsable(true), DisplayName("Phone")]
		public System.String Phone 
		{
			get
			{
				return _Phone;
			}
			set
			{
			if (PropertyChanged(_Phone, value))
					_Phone = value;
			}
		}

		private System.Int32 _TarriffID;
		[Browsable(true), DisplayName("TarriffID")]
		public System.Int32 TarriffID 
		{
			get
			{
				return _TarriffID;
			}
			set
			{
			if (PropertyChanged(_TarriffID, value))
					_TarriffID = value;
			}
		}

		private System.Decimal _DiscountPercent;
		[Browsable(true), DisplayName("DiscountPercent")]
		public System.Decimal DiscountPercent 
		{
			get
			{
				return _DiscountPercent;
			}
			set
			{
			if (PropertyChanged(_DiscountPercent, value))
					_DiscountPercent = value;
			}
		}

		private System.String _VATRegNo;
		[Browsable(true), DisplayName("VATRegNo")]
		public System.String VATRegNo 
		{
			get
			{
				return _VATRegNo;
			}
			set
			{
			if (PropertyChanged(_VATRegNo, value))
					_VATRegNo = value;
			}
		}

		private System.String _Note;
		[Browsable(true), DisplayName("Note")]
		public System.String Note 
		{
			get
			{
				return _Note;
			}
			set
			{
			if (PropertyChanged(_Note, value))
					_Note = value;
			}
		}

		private System.String _ContactPerson;
		[Browsable(true), DisplayName("ContactPerson")]
		public System.String ContactPerson 
		{
			get
			{
				return _ContactPerson;
			}
			set
			{
			if (PropertyChanged(_ContactPerson, value))
					_ContactPerson = value;
			}
		}

		private System.Int32 _CountryID;
		[Browsable(true), DisplayName("CountryID")]
		public System.Int32 CountryID 
		{
			get
			{
				return _CountryID;
			}
			set
			{
			if (PropertyChanged(_CountryID, value))
					_CountryID = value;
			}
		}

		private System.Boolean _VendorCategory;
		[Browsable(true), DisplayName("VendorCategory")]
		public System.Boolean VendorCategory 
		{
			get
			{
				return _VendorCategory;
			}
			set
			{
			if (PropertyChanged(_VendorCategory, value))
					_VendorCategory = value;
			}
		}

		private System.Int32 _StatusID;
		[Browsable(true), DisplayName("StatusID")]
		public System.Int32 StatusID 
		{
			get
			{
				return _StatusID;
			}
			set
			{
			if (PropertyChanged(_StatusID, value))
					_StatusID = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_Name,_CardNo,_Address,_Email,_Mobile,_Phone,_TarriffID,_DiscountPercent,_VATRegNo,_Note,_ContactPerson,_CountryID,_VendorCategory,_StatusID};
			else if (IsModified)
				parameterValues = new Object[] {_ID,_Name,_CardNo,_Address,_Email,_Mobile,_Phone,_TarriffID,_DiscountPercent,_VATRegNo,_Note,_ContactPerson,_CountryID,_VendorCategory,_StatusID};
			else if (IsDeleted)
				parameterValues = new Object[] {_ID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_ID = reader.GetInt32("ID");
			_Name = reader.GetString("Name");
			_CardNo = reader.GetString("CardNo");
			_Address = reader.GetString("Address");
			_Email = reader.GetString("Email");
			_Mobile = reader.GetString("Mobile");
			_Phone = reader.GetString("Phone");
			_TarriffID = reader.GetInt32("TarriffID");
			_DiscountPercent = reader.GetDecimal("DiscountPercent");
			_VATRegNo = reader.GetString("VATRegNo");
			_Note = reader.GetString("Note");
			_ContactPerson = reader.GetString("ContactPerson");
			_CountryID = reader.GetInt32("CountryID");
			_VendorCategory = reader.GetBoolean("VendorCategory");
			_StatusID = reader.GetInt32("StatusID");
			SetUnchanged();
		}
		public static CustomList<Contact> GetAllContact()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
			CustomList<Contact> ContactCollection = new CustomList<Contact>();
			IDataReader reader = null;
			const String sql = "select * from Contact";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Contact newContact = new Contact();
                    newContact.SetData(reader);
					ContactCollection.Add(newContact);
				}
				return ContactCollection;
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
