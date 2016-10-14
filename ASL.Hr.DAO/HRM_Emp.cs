using System;
using System.Web;
using System.Text;
using System.Web.SessionState;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Hr.DAO
{
    [Serializable]
    public class HRM_Emp : BaseItem
    {
        public HRM_Emp()
        {
            SetAdded();
        }

        #region Properties

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

        private System.String _EmpCode;
        [Browsable(true), DisplayName("EmpCode")]
        public System.String EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                if (PropertyChanged(_EmpCode, value))
                    _EmpCode = value;
            }
        }
        private System.String _Level;
        [Browsable(true), DisplayName("Level")]
        public System.String Level
        {
            get
            {
                return _Level;
            }
            set
            {
                if (PropertyChanged(_Level, value))
                    _Level = value;
            }
        }
        private System.String _Col3;
        [Browsable(true), DisplayName("Col3")]
        public System.String Col3
        {
            get
            {
                return _Col3;
            }
            set
            {
                if (PropertyChanged(_Col3, value))
                    _Col3 = value;
            }
        }
        private System.String _Col4;
        [Browsable(true), DisplayName("Col4")]
        public System.String Col4
        {
            get
            {
                return _Col4;
            }
            set
            {
                if (PropertyChanged(_Col4, value))
                    _Col4 = value;
            }
        }

        private System.String _Col5;
        [Browsable(true), DisplayName("Col5")]
        public System.String Col5
        {
            get
            {
                return _Col5;
            }
            set
            {
                if (PropertyChanged(_Col5, value))
                    _Col5 = value;
            }
        }

        private System.Int32 _Salutation;
        [Browsable(true), DisplayName("Salutation")]
        public System.Int32 Salutation
        {
            get
            {
                return _Salutation;
            }
            set
            {
                if (PropertyChanged(_Salutation, value))
                    _Salutation = value;
            }
        }

        private System.String _FirstName;
        [Browsable(true), DisplayName("FirstName")]
        public System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (PropertyChanged(_FirstName, value))
                    _FirstName = value;
            }
        }

        private System.String _MiddleName;
        [Browsable(true), DisplayName("MiddleName")]
        public System.String MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                if (PropertyChanged(_MiddleName, value))
                    _MiddleName = value;
            }
        }

        private System.String _NickName;
        [Browsable(true), DisplayName("NickName")]
        public System.String NickName
        {
            get
            {
                return _NickName;
            }
            set
            {
                if (PropertyChanged(_NickName, value))
                    _NickName = value;
            }
        }

        private System.String _LastName;
        [Browsable(true), DisplayName("LastName")]
        public System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (PropertyChanged(_LastName, value))
                    _LastName = value;
            }
        }

        private System.String _EmpName;
        [Browsable(true), DisplayName("EmpName")]
        public System.String EmpName
        {
            get
            {
                return _EmpName;
            }
            set
            {
                if (PropertyChanged(_EmpName, value))
                    _EmpName = value;
            }
        }

        private System.String _EmpPicture;
        [Browsable(true), DisplayName("EmpPicture")]
        public System.String EmpPicture
        {
            get
            {
                return _EmpPicture;
            }
            set
            {
                if (PropertyChanged(_EmpPicture, value))
                    _EmpPicture = value;
            }
        }

        private System.DateTime _DOB;
        [Browsable(true), DisplayName("DOB"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                if (PropertyChanged(_DOB, value))
                    _DOB = value;
            }
        }

        private System.Int32 _ReligionKey;
        [Browsable(true), DisplayName("ReligionKey")]
        public System.Int32 ReligionKey
        {
            get
            {
                return _ReligionKey;
            }
            set
            {
                if (PropertyChanged(_ReligionKey, value))
                    _ReligionKey = value;
            }
        }

        private System.Int32 _EthnicKey;
        [Browsable(true), DisplayName("EthnicKey")]
        public System.Int32 EthnicKey
        {
            get
            {
                return _EthnicKey;
            }
            set
            {
                if (PropertyChanged(_EthnicKey, value))
                    _EthnicKey = value;
            }
        }

        private System.String _BloodGroup;
        [Browsable(true), DisplayName("BloodGroup")]
        public System.String BloodGroup
        {
            get
            {
                return _BloodGroup;
            }
            set
            {
                if (PropertyChanged(_BloodGroup, value))
                    _BloodGroup = value;
            }
        }

        private System.String _Nationality;
        [Browsable(true), DisplayName("Nationality")]
        public System.String Nationality
        {
            get
            {
                return _Nationality;
            }
            set
            {
                if (PropertyChanged(_Nationality, value))
                    _Nationality = value;
            }
        }

        private System.String _TaxNumber;
        [Browsable(true), DisplayName("TaxNumber")]
        public System.String TaxNumber
        {
            get
            {
                return _TaxNumber;
            }
            set
            {
                if (PropertyChanged(_TaxNumber, value))
                    _TaxNumber = value;
            }
        }

        private System.String _PassportNumber;
        [Browsable(true), DisplayName("PassportNumber")]
        public System.String PassportNumber
        {
            get
            {
                return _PassportNumber;
            }
            set
            {
                if (PropertyChanged(_PassportNumber, value))
                    _PassportNumber = value;
            }
        }

        private System.String _NationalID;
        [Browsable(true), DisplayName("NationalID")]
        public System.String NationalID
        {
            get
            {
                return _NationalID;
            }
            set
            {
                if (PropertyChanged(_NationalID, value))
                    _NationalID = value;
            }
        }

        private System.String _Gender;
        [Browsable(true), DisplayName("Gender")]
        public System.String Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                if (PropertyChanged(_Gender, value))
                    _Gender = value;
            }
        }

        private System.String _DrivingLicenceNumber;
        [Browsable(true), DisplayName("DrivingLicenceNumber")]
        public System.String DrivingLicenceNumber
        {
            get
            {
                return _DrivingLicenceNumber;
            }
            set
            {
                if (PropertyChanged(_DrivingLicenceNumber, value))
                    _DrivingLicenceNumber = value;
            }
        }

        private System.String _Signature;
        [Browsable(true), DisplayName("Signature")]
        public System.String Signature
        {
            get
            {
                return _Signature;
            }
            set
            {
                if (PropertyChanged(_Signature, value))
                    _Signature = value;
            }
        }

        private System.String _FatherName;
        [Browsable(true), DisplayName("FatherName")]
        public System.String FatherName
        {
            get
            {
                return _FatherName;
            }
            set
            {
                if (PropertyChanged(_FatherName, value))
                    _FatherName = value;
            }
        }

        private System.String _MotherName;
        [Browsable(true), DisplayName("MotherName")]
        public System.String MotherName
        {
            get
            {
                return _MotherName;
            }
            set
            {
                if (PropertyChanged(_MotherName, value))
                    _MotherName = value;
            }
        }

        private System.Int32 _MaritalStatus;
        [Browsable(true), DisplayName("MaritalStatus")]
        public System.Int32 MaritalStatus
        {
            get
            {
                return _MaritalStatus;
            }
            set
            {
                if (PropertyChanged(_MaritalStatus, value))
                    _MaritalStatus = value;
            }
        }

        private System.String _SpouseName;
        [Browsable(true), DisplayName("SpouseName")]
        public System.String SpouseName
        {
            get
            {
                return _SpouseName;
            }
            set
            {
                if (PropertyChanged(_SpouseName, value))
                    _SpouseName = value;
            }
        }

        private System.String _SpouseOccupation;
        [Browsable(true), DisplayName("SpouseOccupation")]
        public System.String SpouseOccupation
        {
            get
            {
                return _SpouseOccupation;
            }
            set
            {
                if (PropertyChanged(_SpouseOccupation, value))
                    _SpouseOccupation = value;
            }
        }

        private System.Int32? _NoOfChieldren;
        [Browsable(true), DisplayName("NoOfChieldren")]
        public System.Int32? NoOfChieldren
        {
            get
            {
                return _NoOfChieldren;
            }
            set
            {
                if (PropertyChanged(_NoOfChieldren, value))
                    _NoOfChieldren = value;
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

        private System.Boolean _IsChecked;
        [Browsable(true), DisplayName("IsChecked")]
        public System.Boolean IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                if (PropertyChanged(_IsChecked, value))
                    _IsChecked = value;
            }
        }

        private System.String _PunchCardNo;
        [Browsable(true), DisplayName("PunchCardNo")]
        public System.String PunchCardNo
        {
            get
            {
                return _PunchCardNo;
            }
            set
            {
                if (PropertyChanged(_PunchCardNo, value))
                    _PunchCardNo = value;
            }
        }
        private System.String _PunchCardNo2;
        [Browsable(true), DisplayName("PunchCardNo2")]
        public System.String PunchCardNo2
        {
            get
            {
                return _PunchCardNo2;
            }
            set
            {
                if (PropertyChanged(_PunchCardNo2, value))
                    _PunchCardNo2 = value;
            }
        }


        private System.Int32 _ShiftID;
        [Browsable(true), DisplayName("ShiftID")]
        public System.Int32 ShiftID
        {
            get
            {
                return _ShiftID;
            }
            set
            {
                if (PropertyChanged(_ShiftID, value))
                    _ShiftID = value;
            }
        }

        private System.String _Shift;
        [Browsable(true), DisplayName("Shift")]
        public System.String Shift
        {
            get
            {
                return _Shift;
            }
            set
            {
                if (PropertyChanged(_Shift, value))
                    _Shift = value;
            }
        }
        private System.String _Alias;
        [Browsable(true), DisplayName("Alias")]
        public System.String Alias
        {
            get
            {
                return _Alias;
            }
            set
            {
                if (PropertyChanged(_Alias, value))
                    _Alias = value;
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

        private System.DateTime _DOC;
        [Browsable(true), DisplayName("DOC"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DOC
        {
            get
            {
                return _DOC;
            }
            set
            {
                if (PropertyChanged(_DOC, value))
                    _DOC = value;
            }
        }

        private System.String _PunchCard;
        [Browsable(true), DisplayName("PunchCard")]
        public System.String PunchCard
        {
            get
            {
                return _PunchCard;
            }
            set
            {
                if (PropertyChanged(_PunchCard, value))
                    _PunchCard = value;
            }
        }

        private System.Int32 _EmpType;
        [Browsable(true), DisplayName("EmpType")]
        public System.Int32 EmpType
        {
            get
            {
                return _EmpType;
            }
            set
            {
                if (PropertyChanged(_EmpType, value))
                    _EmpType = value;
            }
        }

        private System.Int32 _NatureOfEmployment;
        [Browsable(true), DisplayName("NatureOfEmployment")]
        public System.Int32 NatureOfEmployment
        {
            get
            {
                return _NatureOfEmployment;
            }
            set
            {
                if (PropertyChanged(_NatureOfEmployment, value))
                    _NatureOfEmployment = value;
            }
        }

        private System.String _EmpStatus;
        [Browsable(true), DisplayName("EmpStatus")]
        public System.String EmpStatus
        {
            get
            {
                return _EmpStatus;
            }
            set
            {
                if (PropertyChanged(_EmpStatus, value))
                    _EmpStatus = value;
            }
        }

        private System.Boolean _IsShiftRule;
        [Browsable(true), DisplayName("IsShiftRule")]
        public System.Boolean IsShiftRule
        {
            get
            {
                return _IsShiftRule;
            }
            set
            {
                if (PropertyChanged(_IsShiftRule, value))
                    _IsShiftRule = value;
            }
        }

        private System.Int32 _ShiftRuleKey;
        [Browsable(true), DisplayName("ShiftRuleKey")]
        public System.Int32 ShiftRuleKey
        {
            get
            {
                return _ShiftRuleKey;
            }
            set
            {
                if (PropertyChanged(_ShiftRuleKey, value))
                    _ShiftRuleKey = value;
            }
        }

        private System.DateTime _StartDate;
        [Browsable(true), DisplayName("StartDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                if (PropertyChanged(_StartDate, value))
                    _StartDate = value;
            }
        }

        private System.Boolean _IsOT;
        [Browsable(true), DisplayName("IsOT")]
        public System.Boolean IsOT
        {
            get
            {
                return _IsOT;
            }
            set
            {
                if (PropertyChanged(_IsOT, value))
                    _IsOT = value;
            }
        }

        private System.DateTime _OTEntitleDate;
        [Browsable(true), DisplayName("OTEntitleDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime OTEntitleDate
        {
            get
            {
                return _OTEntitleDate;
            }
            set
            {
                if (PropertyChanged(_OTEntitleDate, value))
                    _OTEntitleDate = value;
            }
        }

        private System.Boolean _IsOffDayOT;
        [Browsable(true), DisplayName("IsOffDayOT")]
        public System.Boolean IsOffDayOT
        {
            get
            {
                return _IsOffDayOT;
            }
            set
            {
                if (PropertyChanged(_IsOffDayOT, value))
                    _IsOffDayOT = value;
            }
        }

        private System.Boolean _IsHolidayBenefit;
        [Browsable(true), DisplayName("IsHolidayBenefit")]
        public System.Boolean IsHolidayBenefit
        {
            get
            {
                return _IsHolidayBenefit;
            }
            set
            {
                if (PropertyChanged(_IsHolidayBenefit, value))
                    _IsHolidayBenefit = value;
            }
        }

        private System.Boolean _IsPF;
        [Browsable(true), DisplayName("IsPF")]
        public System.Boolean IsPF
        {
            get
            {
                return _IsPF;
            }
            set
            {
                if (PropertyChanged(_IsPF, value))
                    _IsPF = value;
            }
        }

        private System.DateTime _PFEntitleDate;
        [Browsable(true), DisplayName("PFEntitleDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime PFEntitleDate
        {
            get
            {
                return _PFEntitleDate;
            }
            set
            {
                if (PropertyChanged(_PFEntitleDate, value))
                    _PFEntitleDate = value;
            }
        }

        private System.Int32 _PFCompany;
        [Browsable(true), DisplayName("PFCompany")]
        public System.Int32 PFCompany
        {
            get
            {
                return _PFCompany;
            }
            set
            {
                if (PropertyChanged(_PFCompany, value))
                    _PFCompany = value;
            }
        }

        private System.String _PFNominee;
        [Browsable(true), DisplayName("PFNominee")]
        public System.String PFNominee
        {
            get
            {
                return _PFNominee;
            }
            set
            {
                if (PropertyChanged(_PFNominee, value))
                    _PFNominee = value;
            }
        }

        private System.String _PFAccNo;
        [Browsable(true), DisplayName("PFAccNo")]
        public System.String PFAccNo
        {
            get
            {
                return _PFAccNo;
            }
            set
            {
                if (PropertyChanged(_PFAccNo, value))
                    _PFAccNo = value;
            }
        }

        private System.String _PFNomineeRelation;
        [Browsable(true), DisplayName("PFNomineeRelation")]
        public System.String PFNomineeRelation
        {
            get
            {
                return _PFNomineeRelation;
            }
            set
            {
                if (PropertyChanged(_PFNomineeRelation, value))
                    _PFNomineeRelation = value;
            }
        }

        private System.String _AddressOfNominee;
        [Browsable(true), DisplayName("AddressOfNominee")]
        public System.String AddressOfNominee
        {
            get
            {
                return _AddressOfNominee;
            }
            set
            {
                if (PropertyChanged(_AddressOfNominee, value))
                    _AddressOfNominee = value;
            }
        }
        private System.Boolean _IsInsurance;
        [Browsable(true), DisplayName("IsInsurance")]
        public System.Boolean IsInsurance
        {
            get
            {
                return _IsInsurance;
            }
            set
            {
                if (PropertyChanged(_IsInsurance, value))
                    _IsInsurance = value;
            }
        }

        private System.DateTime _InsuranceEntitleDate;
        [Browsable(true), DisplayName("InsuranceEntitleDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime InsuranceEntitleDate
        {
            get
            {
                return _InsuranceEntitleDate;
            }
            set
            {
                if (PropertyChanged(_InsuranceEntitleDate, value))
                    _InsuranceEntitleDate = value;
            }
        }

        private System.DateTime _DOS;
        [Browsable(true), DisplayName("DOS"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DOS
        {
            get
            {
                return _DOS;
            }
            set
            {
                if (PropertyChanged(_DOS, value))
                    _DOS = value;
            }
        }

        private System.DateTime _DOR;
        [Browsable(true), DisplayName("DOR"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DOR
        {
            get
            {
                return _DOR;
            }
            set
            {
                if (PropertyChanged(_DOR, value))
                    _DOR = value;
            }
        }

        private System.Int32 _InsuranceCompany;
        [Browsable(true), DisplayName("InsuranceCompany")]
        public System.Int32 InsuranceCompany
        {
            get
            {
                return _InsuranceCompany;
            }
            set
            {
                if (PropertyChanged(_InsuranceCompany, value))
                    _InsuranceCompany = value;
            }
        }

        private System.String _InsuranceNominee;
        [Browsable(true), DisplayName("InsuranceNominee")]
        public System.String InsuranceNominee
        {
            get
            {
                return _InsuranceNominee;
            }
            set
            {
                if (PropertyChanged(_InsuranceNominee, value))
                    _InsuranceNominee = value;
            }
        }

        private System.Int32? _BankKey;
        [Browsable(true), DisplayName("BankKey")]
        public System.Int32? BankKey
        {
            get
            {
                return _BankKey;
            }
            set
            {
                if (PropertyChanged(_BankKey, value))
                    _BankKey = value;
            }
        }

        private System.Int32? _BankBranchKey;
        [Browsable(true), DisplayName("BankBranchKey")]
        public System.Int32? BankBranchKey
        {
            get
            {
                return _BankBranchKey;
            }
            set
            {
                if (PropertyChanged(_BankBranchKey, value))
                    _BankBranchKey = value;
            }
        }

        private System.String _AccNo;
        [Browsable(true), DisplayName("AccNo")]
        public System.String AccNo
        {
            get
            {
                return _AccNo;
            }
            set
            {
                if (PropertyChanged(_AccNo, value))
                    _AccNo = value;
            }
        }

        private System.String _ContractPerson;
        [Browsable(true), DisplayName("ContractPerson")]
        public System.String ContractPerson
        {
            get
            {
                return _ContractPerson;
            }
            set
            {
                if (PropertyChanged(_ContractPerson, value))
                    _ContractPerson = value;
            }
        }
        private System.String _NTID;
        [Browsable(true), DisplayName("NTID")]
        public System.String NTID
        {
            get
            {
                return _NTID;
            }
            set
            {
                if (PropertyChanged(_NTID, value))
                    _NTID = value;
            }
        }

        private System.String _ContractPersonPhone;
        [Browsable(true), DisplayName("ContractPersonPhone")]
        public System.String ContractPersonPhone
        {
            get
            {
                return _ContractPersonPhone;
            }
            set
            {
                if (PropertyChanged(_ContractPersonPhone, value))
                    _ContractPersonPhone = value;
            }
        }

        private System.String _Reference1;
        [Browsable(true), DisplayName("Reference1")]
        public System.String Reference1
        {
            get
            {
                return _Reference1;
            }
            set
            {
                if (PropertyChanged(_Reference1, value))
                    _Reference1 = value;
            }
        }

        private System.String _Relation1;
        [Browsable(true), DisplayName("Relation1")]
        public System.String Relation1
        {
            get
            {
                return _Relation1;
            }
            set
            {
                if (PropertyChanged(_Relation1, value))
                    _Relation1 = value;
            }
        }

        private System.String _Reference2;
        [Browsable(true), DisplayName("Reference2")]
        public System.String Reference2
        {
            get
            {
                return _Reference2;
            }
            set
            {
                if (PropertyChanged(_Reference2, value))
                    _Reference2 = value;
            }
        }

        private System.String _Relation2;
        [Browsable(true), DisplayName("Relation2")]
        public System.String Relation2
        {
            get
            {
                return _Relation2;
            }
            set
            {
                if (PropertyChanged(_Relation2, value))
                    _Relation2 = value;
            }
        }
        private System.String _NationalityName;
        [Browsable(true), DisplayName("NationalityName")]
        public System.String NationalityName
        {
            get
            {
                return _NationalityName;
            }
            set
            {
                if (PropertyChanged(_NationalityName, value))
                    _NationalityName = value;
            }
        }

        private System.String _EmpTypeName;
        [Browsable(true), DisplayName("EmpTypeName")]
        public System.String EmpTypeName
        {
            get
            {
                return _EmpTypeName;
            }
            set
            {
                if (PropertyChanged(_EmpTypeName, value))
                    _EmpTypeName = value;
            }
        }

        private System.String _StaffCategory;
        [Browsable(true), DisplayName("StaffCategory")]
        public System.String StaffCategory
        {
            get
            {
                return _StaffCategory;
            }
            set
            {
                if (PropertyChanged(_StaffCategory, value))
                    _StaffCategory = value;
            }
        }

        private System.String _Designation;
        [Browsable(true), DisplayName("Designation")]
        public System.String Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                if (PropertyChanged(_Designation, value))
                    _Designation = value;
            }
        }

        private System.String _Department;
        [Browsable(true), DisplayName("Department")]
        public System.String Department
        {
            get
            {
                return _Department;
            }
            set
            {
                if (PropertyChanged(_Department, value))
                    _Department = value;
            }
        }

        private System.String _ShiftIntime;
        [Browsable(true), DisplayName("ShiftIntime")]
        public System.String ShiftIntime
        {
            get
            {
                return _ShiftIntime;
            }
            set
            {
                if (PropertyChanged(_ShiftIntime, value))
                    _ShiftIntime = value;
            }
        }

        private System.String _ShiftOutTime;
        [Browsable(true), DisplayName("ShiftOutTime")]
        public System.String ShiftOutTime
        {
            get
            {
                return _ShiftOutTime;
            }
            set
            {
                if (PropertyChanged(_ShiftOutTime, value))
                    _ShiftOutTime = value;
            }
        }

        private System.String _LateMargin;
        [Browsable(true), DisplayName("LateMargin")]
        public System.String LateMargin
        {
            get
            {
                return _LateMargin;
            }
            set
            {
                if (PropertyChanged(_LateMargin, value))
                    _LateMargin = value;
            }
        }

        private System.String _EarlyOutMargin;
        [Browsable(true), DisplayName("EarlyOutMargin")]
        public System.String EarlyOutMargin
        {
            get
            {
                return _EarlyOutMargin;
            }
            set
            {
                if (PropertyChanged(_EarlyOutMargin, value))
                    _EarlyOutMargin = value;
            }
        }

        private System.String _PhoneNo;
        [Browsable(true), DisplayName("PhoneNo")]
        public System.String PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                if (PropertyChanged(_PhoneNo, value))
                    _PhoneNo = value;
            }
        }

        private System.String _LandPhone;
        [Browsable(true), DisplayName("LandPhone")]
        public System.String LandPhone
        {
            get
            {
                return _LandPhone;
            }
            set
            {
                if (PropertyChanged(_LandPhone, value))
                    _LandPhone = value;
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

        private System.Int32? _Yrs;
        [Browsable(true), DisplayName("Yrs")]
        public System.Int32? Yrs
        {
            get
            {
                return _Yrs;
            }
            set
            {
                if (PropertyChanged(_Yrs, value))
                    _Yrs = value;
            }
        }

        private System.Int32? _Month;
        [Browsable(true), DisplayName("Month")]
        public System.Int32? Month
        {
            get
            {
                return _Month;
            }
            set
            {
                if (PropertyChanged(_Month, value))
                    _Month = value;
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

        private System.String _Hight;
        [Browsable(true), DisplayName("Hight")]
        public System.String Hight
        {
            get
            {
                return _Hight;
            }
            set
            {
                if (PropertyChanged(_Hight, value))
                    _Hight = value;
            }
        }

        private System.String _PerRemarks;
        [Browsable(true), DisplayName("PerRemarks")]
        public System.String PerRemarks
        {
            get
            {
                return _PerRemarks;
            }
            set
            {
                if (PropertyChanged(_PerRemarks, value))
                    _PerRemarks = value;
            }
        }

        private System.Int32 _TemplateID;
        [Browsable(true), DisplayName("TemplateID")]
        public System.Int32 TemplateID
        {
            get
            {
                return _TemplateID;
            }
            set
            {
                if (PropertyChanged(_TemplateID, value))
                    _TemplateID = value;
            }
        }

        private System.Int64? _Supervisor;
        [Browsable(true), DisplayName("Supervisor")]
        public System.Int64? Supervisor
        {
            get
            {
                return _Supervisor;
            }
            set
            {
                if (PropertyChanged(_Supervisor, value))
                    _Supervisor = value;
            }
        }
        private System.String _SupervisorName;
        [Browsable(true), DisplayName("SupervisorName")]
        public System.String SupervisorName
        {
            get
            {
                return _SupervisorName;
            }
            set
            {
                if (PropertyChanged(_SupervisorName, value))
                    _SupervisorName = value;
            }
        }


        private System.Int64? _FunctionalBoss;
        [Browsable(true), DisplayName("FunctionalBoss")]
        public System.Int64? FunctionalBoss
        {
            get
            {
                return _FunctionalBoss;
            }
            set
            {
                if (PropertyChanged(_FunctionalBoss, value))
                    _FunctionalBoss = value;
            }
        }

        private System.Int64? _AdminBoss;
        [Browsable(true), DisplayName("AdminBoss")]
        public System.Int64? AdminBoss
        {
            get
            {
                return _AdminBoss;
            }
            set
            {
                if (PropertyChanged(_AdminBoss, value))
                    _AdminBoss = value;
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

        private System.Int32 _LeaveRuleKey;
        [Browsable(true), DisplayName("LeaveRuleKey")]
        public System.Int32 LeaveRuleKey
        {
            get
            {
                return _LeaveRuleKey;
            }
            set
            {
                if (PropertyChanged(_LeaveRuleKey, value))
                    _LeaveRuleKey = value;
            }
        }
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
        private System.String _ShiftInDate;
        [Browsable(true), DisplayName("ShiftInDate")]
        public System.String ShiftInDate
        {
            get
            {
                return _ShiftInDate;
            }
            set
            {
                if (PropertyChanged(_ShiftInDate, value))
                    _ShiftInDate = value;
            }
        }
        private System.String _ShiftOutDate;
        [Browsable(true), DisplayName("ShiftOutDate")]
        public System.String ShiftOutDate
        {
            get
            {
                return _ShiftOutDate;
            }
            set
            {
                if (PropertyChanged(_ShiftOutDate, value))
                    _ShiftOutDate = value;
            }
        }

        private System.String _LunchOutTime;
        [Browsable(true), DisplayName("LunchOutTime")]
        public System.String LunchOutTime
        {
            get
            {
                return _LunchOutTime;
            }
            set
            {
                if (PropertyChanged(_LunchOutTime, value))
                    _LunchOutTime = value;
            }
        }

        private System.String _LunchInTime;
        [Browsable(true), DisplayName("LunchInTime")]
        public System.String LunchInTime
        {
            get
            {
                return _LunchInTime;
            }
            set
            {
                if (PropertyChanged(_LunchInTime, value))
                    _LunchInTime = value;
            }
        }

        private System.String _OfficialCellPhone;
        [Browsable(true), DisplayName("OfficialCellPhone")]
        public System.String OfficialCellPhone
        {
            get
            {
                return _OfficialCellPhone;
            }
            set
            {
                if (PropertyChanged(_OfficialCellPhone, value))
                    _OfficialCellPhone = value;
            }
        }

        private System.String _OfficialLandPhone;
        [Browsable(true), DisplayName("OfficialLandPhone")]
        public System.String OfficialLandPhone
        {
            get
            {
                return _OfficialLandPhone;
            }
            set
            {
                if (PropertyChanged(_OfficialLandPhone, value))
                    _OfficialLandPhone = value;
            }
        }

        private System.String _OfficialEmail;
        [Browsable(true), DisplayName("OfficialEmail")]
        public System.String OfficialEmail
        {
            get
            {
                return _OfficialEmail;
            }
            set
            {
                if (PropertyChanged(_OfficialEmail, value))
                    _OfficialEmail = value;
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

        private System.DateTime _DateAdded;
        [Browsable(true), DisplayName("DateAdded"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateAdded
        {
            get
            {
                return _DateAdded;
            }
            set
            {
                if (PropertyChanged(_DateAdded, value))
                    _DateAdded = value;
            }
        }
        private System.DateTime _DateUpdated;
        [Browsable(true), DisplayName("DateUpdated"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateUpdated
        {
            get
            {
                return _DateUpdated;
            }
            set
            {
                if (PropertyChanged(_DateUpdated, value))
                    _DateUpdated = value;
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

        private System.String _SeparationAction;
        [Browsable(true), DisplayName("SeparationAction")]
        public System.String SeparationAction
        {
            get
            {
                return _SeparationAction;
            }
            set
            {
                if (PropertyChanged(_SeparationAction, value))
                    _SeparationAction = value;
            }
        }

        private System.String _SeparationCause;
        [Browsable(true), DisplayName("SeparationCause")]
        public System.String SeparationCause
        {
            get
            {
                return _SeparationCause;
            }
            set
            {
                if (PropertyChanged(_SeparationCause, value))
                    _SeparationCause = value;
            }
        }

        private System.String _Workdate;
        [Browsable(true), DisplayName("Workdate")]
        public System.String Workdate
        {
            get
            {
                return _Workdate;
            }
            set
            {
                if (PropertyChanged(_Workdate, value))
                    _Workdate = value;
            }
        }

        private System.String _OfficialRemarks;
        [Browsable(true), DisplayName("OfficialRemarks")]
        public System.String OfficialRemarks
        {
            get
            {
                return _OfficialRemarks;
            }
            set
            {
                if (PropertyChanged(_OfficialRemarks, value))
                    _OfficialRemarks = value;
            }
        }

        private System.DateTime _RejoiningDate;
        [Browsable(true), DisplayName("RejoiningDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime RejoiningDate
        {
            get
            {
                return _RejoiningDate;
            }
            set
            {
                if (PropertyChanged(_RejoiningDate, value))
                    _RejoiningDate = value;
            }
        }

        private System.DateTime _EndDate;
        [Browsable(true), DisplayName("EndDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                if (PropertyChanged(_EndDate, value))
                    _EndDate = value;
            }
        }

        private System.Int32? _Vendor;
        [Browsable(true), DisplayName("Vendor")]
        public System.Int32? Vendor
        {
            get
            {
                return _Vendor;
            }
            set
            {
                if (PropertyChanged(_Vendor, value))
                    _Vendor = value;
            }
        }

        private System.String _VendorID;
        [Browsable(true), DisplayName("VendorID")]
        public System.String VendorID
        {
            get
            {
                return _VendorID;
            }
            set
            {
                if (PropertyChanged(_VendorID, value))
                    _VendorID = value;
            }
        }


        private System.String _JobLocation;
        [Browsable(true), DisplayName("JobLocation")]
        public System.String JobLocation
        {
            get
            {
                return _JobLocation;
            }
            set
            {
                if (PropertyChanged(_JobLocation, value))
                    _JobLocation = value;
            }
        }

        private System.String _LOB;
        [Browsable(true), DisplayName("LOB")]
        public System.String LOB
        {
            get
            {
                return _LOB;
            }
            set
            {
                if (PropertyChanged(_LOB, value))
                    _LOB = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpCode, _Salutation, _FirstName, _MiddleName, _LastName, _NickName, _EmpName, _EmpPicture, _DOB.Value(StaticInfo.DateFormat), _ReligionKey, _EthnicKey, _BloodGroup, _Nationality, _TaxNumber, _PassportNumber, _NationalID, _Gender, _DrivingLicenceNumber, _Signature, _Remarks, _DOJ.Value(StaticInfo.DateFormat), _DOC.Value(StaticInfo.DateFormat), _TemplateID, _PunchCard, _EmpType, _NatureOfEmployment, _EmpStatus, _FatherName, _MotherName, _MaritalStatus, _SpouseName, _SpouseOccupation, _NoOfChieldren, _PhoneNo, _LandPhone, _Email, _Yrs, _Month, _Weight, _Hight, _PerRemarks, _IsShiftRule, _ShiftID, _ShiftRuleKey, _StartDate.Value(StaticInfo.DateFormat), _Supervisor, _FunctionalBoss, _AdminBoss, _Note, _IsOT, _OTEntitleDate.Value(StaticInfo.DateFormat), _IsOffDayOT, _IsHolidayBenefit, _IsPF, _PFEntitleDate.Value(StaticInfo.DateFormat), _PFCompany, _PFNominee, _PFAccNo, _PFNomineeRelation, _AddressOfNominee, _IsInsurance, _InsuranceEntitleDate.Value(StaticInfo.DateFormat), _InsuranceCompany, _InsuranceNominee, _BankKey, _BankBranchKey, _AccNo, _ContractPerson, _ContractPersonPhone, _Reference1, _Relation1, _Reference2, _Relation2, _LeaveRuleKey, _DOS.Value(StaticInfo.DateFormat), _DOR, _OfficialCellPhone, _OfficialLandPhone, _OfficialEmail, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _DateUpdated.Value(StaticInfo.DateFormat), _EndDate.Value(StaticInfo.DateFormat), _Vendor, _VendorID, _NTID, _PunchCardNo2 };
            else if (IsModified)
                parameterValues = new Object[] { _EmpKey, _EmpCode, _Salutation, _FirstName, _MiddleName, _LastName, _NickName, _EmpName, _EmpPicture, _DOB.Value(StaticInfo.DateFormat), _ReligionKey, _EthnicKey, _BloodGroup, _Nationality, _TaxNumber, _PassportNumber, _NationalID, _Gender, _DrivingLicenceNumber, _Signature, _Remarks, _DOJ.Value(StaticInfo.DateFormat), _DOC.Value(StaticInfo.DateFormat), _TemplateID, _PunchCard, _EmpType, _NatureOfEmployment, _EmpStatus, _FatherName, _MotherName, _MaritalStatus, _SpouseName, _SpouseOccupation, _NoOfChieldren, _PhoneNo, _LandPhone, _Email, _Yrs, _Month, _Weight, _Hight, _PerRemarks, _IsShiftRule, _ShiftID, _ShiftRuleKey, _StartDate.Value(StaticInfo.DateFormat), _Supervisor, _FunctionalBoss, _AdminBoss, _Note, _IsOT, _OTEntitleDate.Value(StaticInfo.DateFormat), _IsOffDayOT, _IsHolidayBenefit, _IsPF, _PFEntitleDate.Value(StaticInfo.DateFormat), _PFCompany, _PFNominee, _PFAccNo, _PFNomineeRelation, _AddressOfNominee, _IsInsurance, _InsuranceEntitleDate.Value(StaticInfo.DateFormat), _InsuranceCompany, _InsuranceNominee, _BankKey, _BankBranchKey, _AccNo, _ContractPerson, _ContractPersonPhone, _Reference1, _Relation1, _Reference2, _Relation2, _LeaveRuleKey, _DOS.Value(StaticInfo.DateFormat), _DOR, _OfficialCellPhone, _OfficialLandPhone, _OfficialEmail, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _DateUpdated.Value(StaticInfo.DateFormat), _EndDate.Value(StaticInfo.DateFormat), _Vendor, _VendorID, _NTID, _PunchCardNo2 };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _Salutation = reader.GetInt32("Salutation");
            _FirstName = reader.GetString("FirstName");
            _MiddleName = reader.GetString("MiddleName");
            _LastName = reader.GetString("LastName");
            _NickName = reader.GetString("NickName");
            _EmpName = reader.GetString("EmpName");
            _EmpPicture = reader.GetString("EmpPicture");
            _DOB = reader.GetDateTime("DOB");
            _ReligionKey = reader.GetInt32("ReligionKey");
            _EthnicKey = reader.GetInt32("EthnicKey");
            _BloodGroup = reader.GetString("BloodGroup");
            _Nationality = reader.GetString("Nationality");
            _TaxNumber = reader.GetString("TaxNumber");
            _PassportNumber = reader.GetString("PassportNumber");
            _NationalID = reader.GetString("NationalID");
            _DrivingLicenceNumber = reader.GetString("DrivingLicenceNumber");
            _Signature = reader.GetString("Signature");
            _Remarks = reader.GetString("Remarks");
            _DOJ = reader.GetDateTime("DOJ");
            _DOC = reader.GetDateTime("DOC");
            _TemplateID = reader.GetInt32("TemplateID");
            _PunchCard = reader.GetString("PunchCard");
            _EmpType = reader.GetInt32("EmpType");
            _NatureOfEmployment = reader.GetInt32("NatureOfEmployment");
            _EmpStatus = reader.GetString("EmpStatus");
            _FatherName = reader.GetString("FatherName");
            _MotherName = reader.GetString("MotherName");
            _MaritalStatus = reader.GetInt32("MaritalStatus");
            _SpouseName = reader.GetString("SpouseName");
            _SpouseOccupation = reader.GetString("SpouseOccupation");
            _NoOfChieldren = reader.GetInt32("NoOfChieldren");
            _PhoneNo = reader.GetString("PhoneNo");
            _LandPhone = reader.GetString("LandPhone");
            _Email = reader.GetString("Email");
            _Yrs = reader.GetInt32("Yrs");
            _Month = reader.GetInt32("Month");
            _Weight = reader.GetString("Weight");
            _Hight = reader.GetString("Hight");
            _PerRemarks = reader.GetString("PerRemarks");
            _IsShiftRule = reader.GetBoolean("IsShiftRule");
            _ShiftID = reader.GetInt32("ShiftID");
            _ShiftRuleKey = reader.GetInt32("ShiftRuleKey");
            _StartDate = reader.GetDateTime("StartDate");
            _Supervisor = reader.GetInt64("Supervisor");
            _FunctionalBoss = reader.GetInt64("FunctionalBoss");
            _AdminBoss = reader.GetInt64("AdminBoss");
            _Note = reader.GetString("Note");
            _IsOT = reader.GetBoolean("IsOT");
            _OTEntitleDate = reader.GetDateTime("OTEntitleDate");
            _IsOffDayOT = reader.GetBoolean("IsOffDayOT");
            _IsHolidayBenefit = reader.GetBoolean("IsHolidayBenefit");
            _IsPF = reader.GetBoolean("IsPF");
            _PFEntitleDate = reader.GetDateTime("PFEntitleDate");
            _PFCompany = reader.GetInt32("PFCompany");
            _PFNominee = reader.GetString("PFNominee");
            _PFAccNo = reader.GetString("PFAccNo");
            _PFNomineeRelation = reader.GetString("PFNomineeRelation");
            _AddressOfNominee = reader.GetString("AddressOfNominee");
            _IsInsurance = reader.GetBoolean("IsInsurance");
            _InsuranceEntitleDate = reader.GetDateTime("InsuranceEntitleDate");
            _InsuranceCompany = reader.GetInt32("InsuranceCompany");
            _InsuranceNominee = reader.GetString("InsuranceNominee");
            _BankKey = reader.GetInt32("BankKey");
            _BankBranchKey = reader.GetInt32("BankBranchKey");
            _AccNo = reader.GetString("AccNo");
            _ContractPerson = reader.GetString("ContractPerson");
            _ContractPersonPhone = reader.GetString("ContractPersonPhone");
            _Reference1 = reader.GetString("Reference1");
            _Relation1 = reader.GetString("Relation1");
            _Reference2 = reader.GetString("Reference2");
            _Relation2 = reader.GetString("Relation2");
            _LeaveRuleKey = reader.GetInt32("LeaveRuleKey");
            _DOS = reader.GetDateTime("DOS");
            _DOR = reader.GetDateTime("DOR");
            _Gender = reader.GetString("Gender");
            _OfficialCellPhone = reader.GetString("OfficialCellPhone");
            _OfficialLandPhone = reader.GetString("OfficialLandPhone");
            _OfficialEmail = reader.GetString("OfficialEmail");
            _AddedBy = reader.GetString("AddedBy");
            _DateAdded = reader.GetDateTime("DateAdded");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            _EndDate = reader.GetDateTime("EndDate");
            _Vendor = reader.GetInt32("Vendor");
            _VendorID = reader.GetString("VendorID");
            _NTID = reader.GetString("NTID");
            _PunchCardNo2 = reader.GetString("PunchCardNo2");

            SetUnchanged();
        }
        private void SetDataEmp(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpName = reader.GetString("EmpName");
            _EmpCode = reader.GetString("EmpCode");
            _PunchCard = reader.GetString("PunchCard");
            SetUnchanged();
        }
        private void SetDataEmpSearch(IDataRecord reader)
        {
            //_EmpTypeName = reader.GetString("EmpTypeName");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            //_EmpNickName = reader.GetString("EmpNickName");
            _EmpPicture = reader.GetString("EmpPicture");
            //_Grade = reader.GetString("Grade");
            //_DesigName = reader.GetString("DesigName");
            _DOB = reader.GetDateTime("DOB");
            //_BirthPlaceDistrictName = reader.GetString("BirthPlaceDistrictName");
            //_DOJ = reader.GetDateTime("DOJ");
            //_PermanentDate = reader.GetDateTime("PermanentDate");
            //_Religion = reader.GetString("Religion");
            //_ReligionKey = reader.GetInt32("ReligionKey");
            //_EthnicName = reader.GetString("EthnicName");
            //_BloodGroupName = reader.GetString("BloodGroupName");
            //_NationalityDisplay = reader.GetString("NationalityDisplay");
            //_NID = reader.GetString("NID");
            //_SalaryDisburseType = reader.GetInt32("SalaryDisburseType");
            //_SalaryAccNo = reader.GetString("SalaryAccNo");
            //_BankName1 = reader.GetString("BankName1");
            //_BankBranch = reader.GetString("BankBranch");
            //_SalaryAccNo2 = reader.GetString("SalaryAccNo2");
            //_BankName2 = reader.GetString("BankName2");
            //_PassportNo = reader.GetString("PassportNo");
            //_IsOnHold = reader.GetBoolean("IsOnHold");
            //_OnHoldDate = reader.GetDateTime("OnHoldDate");
            //_GrossSalary = reader.GetDecimal("GrossSalary");
            //_EffectiveFrom = reader.GetDateTime("EffectiveFrom");
            //_TIN = reader.GetString("TIN");
            //_MobNo = reader.GetString("MobNo");
            //_OfficeExt = reader.GetInt32("OfficeExt");
            //_OfficeEmail = reader.GetString("OfficeEmail");
            _Signature = reader.GetString("Signature");
            //_Reference1 = reader.GetString("Reference1");
            //_RelationName1 = reader.GetString("RelationName1");
            //_Reference2 = reader.GetString("Reference2");
            //_RelationName2 = reader.GetString("RelationName2");

            //_MobNoPersonal = reader.GetString("MobNoPersonal");
            //_MobNoResident = reader.GetString("MobNoResident");
            //_EmailPersonal = reader.GetString("EmailPersonal");

            SetUnchanged();
        }
        private void SetDataEmpInfoSearch(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            //_EmpTypeName = reader.GetString("EmpTypeName");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            //_EmpNickName = reader.GetString("EmpNickName");
            //_Grade = reader.GetString("Grade");
            //_DesigName = reader.GetString("DesigName");
            //_PermanentDate = reader.GetDateTime("PermanentDate");
            //_DOB = reader.GetDateTime("DOB");
            //_Grade = reader.GetString("Grade");
            //_EmpPresentExpre = reader.GetInt32("EmpPresentExpre");
            //_ActualExperiance = reader.GetInt32("ActualExperiance");
            //_ExamName = reader.GetString("ExamName");
            //_Department = reader.GetString("Department");
            //_OrgDesc = reader.GetString("OrgDesc");
            //_OrgKey = reader.GetInt32("OrgKey");
            //_GradeKey = reader.GetInt32("GradeKey");
            //_DesigKey = reader.GetInt32("DesigKey");
            //_BranchName = reader.GetString("BranchName");
            SetUnchanged();
        }
        private void SetDataAllEmp(IDataRecord reader)
        {
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            //_DesigName = reader.GetString("DesigName");
            //_Grade = reader.GetString("Grade");
            //_DeptName = reader.GetString("DeptName");
            //_DOJ = reader.GetDateTime("DOJ");
            _DOB = reader.GetDateTime("DOB");
            //_TotalAssuredAmount = reader.GetDecimal("TotalAssuredAmount");
            SetUnchanged();
        }
        private void SetDataViewEmp(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _ShiftID = reader.GetInt32("ShiftID");
            _Shift = reader.GetString("Shift");
            _PunchCard = reader.GetString("PunchCard");
            _Department = reader.GetString("Department");
            _DOJ = reader.GetDateTime("DOJ");
            _ShiftInDate = reader.GetString("ShiftInDate");
            _ShiftIntime = reader.GetString("ShiftIntime");
            _ShiftOutDate = reader.GetString("ShiftOutDate");
            _ShiftOutTime = reader.GetString("ShiftOutTime");
            _LateMargin = reader.GetString("LateMargin");
            _EarlyOutMargin = reader.GetString("EarlyOutMargin");
            _LunchInTime = reader.GetString("LunchInTime");
            _LunchOutTime = reader.GetString("LunchOutTime");
            SetUnchanged();
        }
        private void SetDataViewEmpNew(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _ShiftID = reader.GetInt32("ShiftID");
            _Shift = reader.GetString("Shift");

            _Department = reader.GetString("Department");
            _DOJ = reader.GetDateTime("DOJ");
            _StaffCategory = reader.GetString("Staff Category");
            SetUnchanged();
        }
        private void SetDataLVEmp(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _Shift = reader.GetString("Shift");
            _StaffCategory = reader.GetString("Staff Category");
            _Department = reader.GetString("Department");
            _JobLocation = reader.GetString("Job Location");
            _DOJ = reader.GetDateTime("DOJ");
            _EmpPicture = reader.GetString("EmpPicture");
            //_DesigName = reader.GetString("DesigName");
            //_ShiftID = reader.GetInt32("ShiftID");
            //_Shift = reader.GetString("Shift");
            //_PunchCardNo = reader.GetString("PunchCardNo");
            //_DeptName = reader.GetString("DeptName");
            
            //_ShiftIntime = reader.GetString("ShiftIntime");
            //_ShiftOutTime = reader.GetString("ShiftOutTime");
            //_LateMargin = reader.GetString("LateMargin");
            //_EarlyOutMargin = reader.GetString("EarlyOutMargin");
            //_LunchOutTime = reader.GetString("LunchOutTime");
            //_LunchInTime = reader.GetString("LunchInTime");
            SetUnchanged();
        }
        private void SetDataViewUser(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _ShiftID = reader.GetInt32("ShiftID");
            _Shift = reader.GetString("Shift");
            _PunchCardNo = reader.GetString("PunchCardNo");
            _Department = reader.GetString("Department");
            _DOJ = reader.GetDateTime("DOJ");
            _UserCode = reader.GetString("UserCode").Trim();
            SetUnchanged();
        }
        private void SetDataEmpLevelInfo(IDataRecord reader)
        {
            _EmpCode = reader.GetString("EmpCode");
            _Level = reader.GetString("Level");

            SetUnchanged();
        }
        private void SetDataEmpGeneralInfo(IDataRecord reader)
        {

            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _EmpPicture = reader.GetString("EmpPicture");
            _DOJ = reader.GetDateTime("DOJ");
            _DOC = reader.GetDateTime("DOC");
            _NationalityName = reader.GetString("NationalityName");
            _EmpTypeName = reader.GetString("EmpTypeName");
            _PunchCard = reader.GetString("PunchCard");
            _NationalID = reader.GetString("NationalID");
            SetUnchanged();
        }
        private void SetDataNewEmpApproval(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _StaffCategory = reader.GetString("StaffCategory");
            _Department = reader.GetString("Department");
            _DOJ = reader.GetDateTime("DOJ");
            _AddedBy = reader.GetString("AddedBy");
        }
        private void SetDataForApplicableShift(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _Workdate = reader.GetString("Workdate");
            _ShiftID = reader.GetInt32("ShiftID");
            _Alias = reader.GetString("Alias");
            _ShiftIntime = reader.GetString("ShiftIntime");
            _ShiftOutTime = reader.GetString("ShiftOutTime");
            _LateMargin = reader.GetString("LateMargin");
            _LunchOutTime = reader.GetString("LunchOutTime");
            _LunchInTime = reader.GetString("LunchInTime");
        }
        public static CustomList<HRM_Emp> GetSearchEmp(string EmpCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            IDataReader reader = null;
            //String sql = "Exec spGetSearchEmp '" + empKey + "'";
            String sql = "Exec spGetCommonEmpInfo '" + EmpCode + "'";
            try
            {
                CustomList<HRM_Emp> EmpList = new CustomList<HRM_Emp>();
                HRM_Emp newHRM_Emp = new HRM_Emp();
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                   // newHRM_Emp.SetDataEmpSearch(reader);
                    newHRM_Emp.SetDataLVEmp(reader);
                    EmpList.Add(newHRM_Emp);

                }
                return EmpList;
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

        public static CustomList<HRM_Emp> DateRangWiseEmpApplicableShift(string Fromdate, string ToDate)
        {

            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;

            String sql = "Exec spDateRangeWiseApplicableShift '" + Fromdate + "','" + ToDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newHRM_Emp = new HRM_Emp();
                    newHRM_Emp.SetDataForApplicableShift(reader);
                    HRM_EmpCollection.Add(newHRM_Emp);
                }
                return HRM_EmpCollection;
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
        public static HRM_Emp GetEmployeeServiceInformation(String EmpCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            IDataReader reader = null;
            String sql = "Exec spGetEmp '" + EmpCode + "'";
            try
            {
                HRM_Emp newHRM_Emp = new HRM_Emp();
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    newHRM_Emp.SetDataEmpInfoSearch(reader);

                }
                return newHRM_Emp;
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
        public static CustomList<HRM_Emp> GetAllHRM_Emp()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;
            const String sql = "exec spGetEmpPunchCardInfo";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newHRM_Emp = new HRM_Emp();
                    newHRM_Emp.SetDataEmp(reader);
                    HRM_EmpCollection.Add(newHRM_Emp);
                }
                HRM_EmpCollection.InsertSpName = "spInsertHRM_Emp";
                HRM_EmpCollection.UpdateSpName = "spUpdateHRM_Emp";
                HRM_EmpCollection.DeleteSpName = "spDeleteHRM_Emp";
                return HRM_EmpCollection;
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
        public static CustomList<HRM_Emp> doSearch(string EmpKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            // search = "'" + search + whereClause + "'";
            IDataReader reader = null;
            String sql = String.Empty;

            sql = "EXEC spGetNonReportees '" + EmpKey + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newHRM_Emp = new HRM_Emp();
                    newHRM_Emp.SetDataLVEmp(reader);
                   // newHRM_Emp.LOB = reader.GetString("LOB");
                    newHRM_Emp.SupervisorName = reader.GetString("SupervisorName");
                    newHRM_Emp.EmpStatus = reader.GetString("EmpStatus");
                    HRM_EmpCollection.Add(newHRM_Emp);
                }
                return HRM_EmpCollection;
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

        public static CustomList<HRM_Emp> ManualEntryUserList()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();

            search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;
            IDataReader reader = null;
            String sql = String.Empty;

            sql = "EXEC spGetUsers " + search + "";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newHRM_Emp = new HRM_Emp();
                    newHRM_Emp.SetDataViewUser(reader);
                    HRM_EmpCollection.Add(newHRM_Emp);
                }
                return HRM_EmpCollection;
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
        public static CustomList<HRM_Emp> GetActiveEmpCodeAndEmpKeyOnly()
        {

            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;

            String sql = String.Format("select * from HRM_Emp Where EmpStatus='Active' ");
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newHRM_Emp = new HRM_Emp();
                    newHRM_Emp.SetData(reader);
                    HRM_EmpCollection.Add(newHRM_Emp);
                }
                HRM_EmpCollection.InsertSpName = "spInsertHRM_Emp";
                HRM_EmpCollection.UpdateSpName = "spUpdateHRM_Emp";
                HRM_EmpCollection.DeleteSpName = "spDeleteHRM_Emp";
                return HRM_EmpCollection;
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
        public static HRM_Emp GetEmpByCode(string code)
        {

            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;

            String sql = String.Format("select * from HRM_Emp emp where emp.EmpCode ='{0}'", code);
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newHRM_Emp = new HRM_Emp();
                    newHRM_Emp.SetData(reader);
                    HRM_EmpCollection.Add(newHRM_Emp);
                }
                HRM_EmpCollection.InsertSpName = "spInsertHRM_Emp";
                HRM_EmpCollection.UpdateSpName = "spUpdateHRM_Emp";
                HRM_EmpCollection.DeleteSpName = "spDeleteHRM_Emp";
                return HRM_EmpCollection[0];
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
        public static CustomList<HRM_Emp> GetAllEmp(Int32 orgKey)
        {

            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;

            String sql = "EXEC GetAllEmp " + orgKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newHRM_Emp = new HRM_Emp();
                    newHRM_Emp.SetDataAllEmp(reader);
                    HRM_EmpCollection.Add(newHRM_Emp);
                }
                return HRM_EmpCollection;
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

        public static CustomList<HRM_Emp> EmployeeSearch(string whereClause)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();

            if (whereClause == "") return HRM_EmpCollection;

            string search = String.Empty;
            if (whereClause == "")
            {
                search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;
            }
            else
            {
                search = search + whereClause;
            }
            IDataReader reader = null;
            String sql = String.Empty;

            sql = "EXEC spGetEmpForSearch " + search + "";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newHRM_Emp = new HRM_Emp();
                    newHRM_Emp.SetData(reader);
                    HRM_EmpCollection.Add(newHRM_Emp);
                }

                HRM_EmpCollection.InsertSpName = "spInsertHRM_Emp";
                HRM_EmpCollection.UpdateSpName = "spUpdateHRM_Emp";
                HRM_EmpCollection.DeleteSpName = "spDeleteHRM_Emp";
                return HRM_EmpCollection;
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
        public static CustomList<HRM_Emp> GetAllViewEmp(string spName, string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> EmpList = new CustomList<HRM_Emp>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            search = "@StrSearch='" + search + "'";

            IDataReader reader = null;
            String sql = "EXEC " + spName + " '" + fromDate + "','" + toDate + "'," + search;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newEmp = new HRM_Emp();
                    newEmp.SetDataLVEmp(reader);
                    EmpList.Add(newEmp);
                }
                return EmpList;
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
        public static CustomList<HRM_Emp> GetAllViewEmp(string spName, string fromDate, string toDate, string str)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> EmpList = new CustomList<HRM_Emp>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            search = "'" + search + "'";


            IDataReader reader = null;
            String sql = "EXEC " + spName + " '" + fromDate + "','" + toDate + "'," + search + ",'" + str + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newEmp = new HRM_Emp();
                    newEmp.SetDataViewEmpNew(reader);
                    EmpList.Add(newEmp);
                }
                return EmpList;
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
        public static CustomList<HRM_Emp> GetEmpInfo(string searchStrings)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> EmployeeCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;
            string profileEmpKey = (string)HttpContext.Current.Session["ProfileEmpKey"];
            String sql = "";
            if (profileEmpKey.IsNullOrEmpty())
            {
                sql = "exec spGetEmpInfoForLeftGrid '" + searchStrings + "'";
            }
            else
            {
                sql = "spGetProfileReportees " + profileEmpKey + ",'" + searchStrings + "%'";
            }
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newEmployee = new HRM_Emp();
                    //newEmployee.SetData(reader);
                    newEmployee.EmpKey = reader.GetInt64("EmpKey");
                    newEmployee.EmpCode = reader.GetString("EmpCode");
                    newEmployee.EmpName = reader.GetString("EmpName");
                    //newEmployee.Col3 = reader.GetString("Col3");
                    newEmployee.Col4 = reader.GetString("Col4");
                    newEmployee.Col5 = reader.GetString("Col5");
                    EmployeeCollection.Add(newEmployee);
                }
                return EmployeeCollection;
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
        public static CustomList<HRM_Emp> GetEmpInfoForShowingLevel(string empCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> EmployeeCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;
            String sql = "EXEC GetEmpInfoForLevel '" + empCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newEmployee = new HRM_Emp();
                    newEmployee.SetDataEmpLevelInfo(reader);
                    EmployeeCollection.Add(newEmployee);
                }
                return EmployeeCollection;
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
        public static CustomList<HRM_Emp> GetEmpGeneralInfo(string empCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> EmployeeCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;
            String sql = "EXEC spGetEmpInfo '" + empCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newEmployee = new HRM_Emp();
                    newEmployee.SetDataEmpGeneralInfo(reader);
                    EmployeeCollection.Add(newEmployee);
                }
                return EmployeeCollection;
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
        public static HRM_Emp GetReportingBoss(long empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            HRM_Emp newEmployee = new HRM_Emp();
            IDataReader reader = null;
            String sql = "EXEC spGetReportingBoss  " + empKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    newEmployee.EmpName = reader.GetString("EmpName");
                    newEmployee.Designation = reader.GetString("Designation");
                }
                return newEmployee;
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
        public static String GetExistingEmp(string empCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);

            String EmpCode = "";
            try
            {
                String sql = "select Top 1 FirstName from HRM_Emp Where  FirstName='" + empCode + "'";
                Object empcode = conManager.ExecuteScalarWrapper(sql);
                EmpCode = Convert.ToString(empcode);
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
            return EmpCode;
        }
        public static CustomList<HRM_Emp> GetReportees(long empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;
            String sql = "EXEC spGetReportees " + empKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newHRM_Emp = new HRM_Emp();
                    newHRM_Emp.SetDataLVEmp(reader);
                    newHRM_Emp.LOB = reader.GetString("LOB");
                    HRM_EmpCollection.Add(newHRM_Emp);
                }
                return HRM_EmpCollection;
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
        public static CustomList<HRM_Emp> GetNewEmpApproval(string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> EmpList = new CustomList<HRM_Emp>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            search = "@StrSearch='" + search + "'"; //+ "' AND (DOJ BETWEEN '" + fromDate+"' AND '"+toDate+"')";

            IDataReader reader = null;
            String sql = "EXEC spGetNewEmployeeApproval " + search;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newEmp = new HRM_Emp();
                    newEmp.SetDataNewEmpApproval(reader);
                    EmpList.Add(newEmp);
                }
                return EmpList;
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
        public static CustomList<HRM_Emp> GetEmpSeparationApproval(string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> EmpList = new CustomList<HRM_Emp>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            search = "@StrSearch='" + search + "'"; //+ "' AND (DOJ BETWEEN '" + fromDate+"' AND '"+toDate+"')";

            IDataReader reader = null;
            String sql = "EXEC spGetEmpSeparation " + search;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newEmp = new HRM_Emp();
                    newEmp.SetDataNewEmpApproval(reader);
                    newEmp.DOS = reader.GetDateTime("DOS");
                    newEmp.SeparationAction = reader.GetString("SeparationAction");
                    newEmp.SeparationCause = reader.GetString("SeparationCause");
                    newEmp.OfficialRemarks = reader.GetString("OfficialRemarks");
                    EmpList.Add(newEmp);
                }
                return EmpList;
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
        public static CustomList<HRM_Emp> GetEmpSeparationReActivation(string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> EmpList = new CustomList<HRM_Emp>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            search = "@StrSearch='" + search + "'"; //+ "' AND (DOJ BETWEEN '" + fromDate+"' AND '"+toDate+"')";

            IDataReader reader = null;
            String sql = "EXEC spGetEmpSeparationForReActivation " + search;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newEmp = new HRM_Emp();
                    newEmp.SetDataNewEmpApproval(reader);
                    newEmp.DOS = reader.GetDateTime("DOS");
                    newEmp.SeparationAction = reader.GetString("SeparationAction");
                    newEmp.SeparationCause = reader.GetString("SeparationCause");
                    newEmp.OfficialRemarks = reader.GetString("OfficialRemarks");
                    EmpList.Add(newEmp);
                }
                return EmpList;
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
        public static CustomList<HRM_Emp> GetAllSO()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_Emp> SOCollection = new CustomList<HRM_Emp>();
            IDataReader reader = null;
            const String sql = "EXEC spSOList";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_Emp newSO = new HRM_Emp();
                    newSO.EmpCode = reader.GetString("EmpCode");
                    newSO.EmpKey = reader.GetInt64("EmpKey");
                    newSO.EmpName = reader.GetString("EmpName");
                    SOCollection.Add(newSO);
                }               
                
                return SOCollection;
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

        private void SetDataVoucherType(IDataReader reader)
        {
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
        }
    }
}
