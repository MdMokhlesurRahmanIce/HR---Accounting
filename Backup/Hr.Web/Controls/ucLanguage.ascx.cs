using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.DATA;
using ASL.Hr.DAO;
using Hr.Web.Utils;
using System.Collections;

namespace Hr.Web.Controls
{
    public partial class ucLanguage : System.Web.UI.UserControl
    {
                #region Fileds
        public readonly EmployeeManager _empManager;
        #endregion

        #region Properties
        private CustomList<LanguageInfo> EmpLanguageList
        {
            get
            {
                if (Session["EmployeeBasicInformation_EmpLanguageList"] == null)
                    return new CustomList<LanguageInfo>();
                else
                    return (CustomList<LanguageInfo>)Session["EmployeeBasicInformation_EmpLanguageList"];
            }
            set
            {
                Session["EmployeeBasicInformation_EmpLanguageList"] = value;
            }
        }
        #endregion

        #region Ctor
        public ucLanguage()
        {
            _empManager = new EmployeeManager();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializationSession();              
            }
        }
        #region All Methods
        public void InitializationSession()
        {
            EmpLanguageList = new CustomList<LanguageInfo>();
        }
        internal void Save(ArrayList empInfo)
        {
            var empLanguage = (CustomList<LanguageInfo>)EmpLanguageList;
            empInfo.Add(empLanguage);
        }
        internal void PopulateControl(long empKey)
        {
            EmpLanguageList = _empManager.GetAllLanguageInfo(empKey);
        }
        #endregion
    }
}