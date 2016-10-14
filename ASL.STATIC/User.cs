using System;

namespace ASL.STATIC
{
    public class User
    {
        public String CompanyName { get; set; }
        public String PersonName { get; set; }
        public String SerialNo { get; set; }
        public String EmployeeCode { get; set; }

        public String EmpName { get; set; }
        public String Company { get; set; }
        public String Department { get; set; }
        public String EmpType { get; set; }
        public String Grade { get; set; }
        public String Designation { get; set; }
        public long EmpKey { get; set; }
        public long UserKey { get; set; }
        
        public String CompanyId
        {
            get { return StaticInfo.CurrentCompany.CompanyID; }
        }
        public String InventoryCompanyId { get; set; }
        public String SiteId { get; set; }
        public String SiteName { get; set; }
        public Boolean IsCentralSite { get; set; }
        public String UserCode { get; set; }
        public String UserName { get; set; }
        public String GroupCode { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int LoginHistoryID { get; set; }

        public Boolean IsLoggedIn { get; set; }
        public Boolean IsAdmin { get; set; }

        public Boolean CanSelect { get; set; }
        public Boolean CanInsert { get; set; }
        public Boolean CanUpdate { get; set; }
        public Boolean CanDelete { get; set; }

        public int CurrentMenuID { get; set; }
        public int CurrentApplicationID { get; set; }

        private int _defaultApplicaiotnID = 1;
        public int DefaultApplicationID
        {
            get
            {
                return _defaultApplicaiotnID;
            }
            set
            {
                _defaultApplicaiotnID = value;
            }
        }

        private string _defaultTheme = "Dark";
        public string DefaultTheme
        {
            get
            {
                return _defaultTheme;
            }
            set
            {
                _defaultTheme = value;
            }
        }

        public delegate void Child_Closed_Message(Boolean status, String details);

        public enum LoanType
        {
            LoanRefund,
            LoanIssue,
            LoanReceive,
            LoanRecovery
        }

        public enum ReceiveAgainst
        {
            PO,
            Ind,
            INV
        }
    }
}
