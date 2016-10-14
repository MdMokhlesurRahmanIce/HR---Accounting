using System;

namespace ASL.Hr.DAO
{
   public class enumsHr
    {
       [Flags]
       public enum enumAllowenceType
       {
           SalaryComponents = 1
          ,Deduction=2 
          ,Entitlement=3
          ,OverTime=4
          ,HolidayAllowance=5
          ,SalaryAdjustment=6
          //,VarAllowance=4
       }

       [Flags]
       public enum enumCalculationMethod
       {
           Percentage = 1,
           FixedAmount = 2 
       }

       [Flags]
       public enum enumAvailFrom
       {
           DOJ = 1,
           DOC = 2
       }

       [Flags]
       public enum enumEmpCriteria
       {
           Fixed = 1,
           Prorata = 2
       }

       [Flags]
       public enum enumEntitySetup
       {
           Religion = 1,
           BloodGroup =2,
           MaritalStatus = 3,
           EmployeeType = 4,
           Nationality=5,
           NatureOfEmployment=6,
           EmployeeStatus=7,
           PFCompany=8,
           InsuranceCompany=9,
           Occupation=10,
           Examination=11,
           LoanType=12,
           ShiftType=13,
           OfficialCause=14,
           Action=15,
           ApprovalList=16,
           Salutation=17,
           City=18,
           State=19,
           Gender=20,
           PromotionCriteria=21,
           TransferCriteria=22,
           PromotionType=23,
           TransferType=24,
           IncrementType=25,
           Vendor = 27,
           TarriffStatus=28,
           SupplierType=30,
           BonusType=31
       }
       [Flags]
       public enum enumSalaryAdjust
       {
           Deduction = 0,
           Entitlement = 1
       }


    }
}
