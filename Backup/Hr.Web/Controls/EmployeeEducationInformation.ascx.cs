using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.DATA;
using ASL.Hr.DAO;
using ASL.Hr.BLL;
using Hr.Web.Utils;
using System.Collections;

namespace Hr.Web.Controls
{
    public partial class EmployeeEducationInformation : EmpBase
    {
        #region Fields
        private readonly EmployeeManager _manager;
        #endregion

        #region Properties

        private CustomList<HRM_EmpEdu> EducationList
        {
            get
            {
                if (Session["EmployeeBasicInformation_EducationList"] == null)
                    return new CustomList<HRM_EmpEdu>();
                else
                    return (CustomList<HRM_EmpEdu>)Session["EmployeeBasicInformation_EducationList"];
            }
            set
            {
                Session["EmployeeBasicInformation_EducationList"] = value;
            }
        }

        private CustomList<HRM_EmpEduDip> DipEducationList
        {
            get
            {
                if (Session["EmployeeBasicInformation_DipEducationList"] == null)
                    return new CustomList<HRM_EmpEduDip>();
                else
                    return (CustomList<HRM_EmpEduDip>)Session["EmployeeBasicInformation_DipEducationList"];
            }
            set
            {
                Session["EmployeeBasicInformation_DipEducationList"] = value;
            }
        }
        private CustomList<HRM_EmpEduDip> ProfessionalTrainingList
        {
            get
            {
                if (Session["EmployeeBasicInformation_ProfessionalTrainingList"] == null)
                    return new CustomList<HRM_EmpEduDip>();
                else
                    return (CustomList<HRM_EmpEduDip>)Session["EmployeeBasicInformation_ProfessionalTrainingList"];
            }
            set
            {
                Session["EmployeeBasicInformation_ProfessionalTrainingList"] = value;
            }
        }

        private CustomList<Gen_Country> CountryList
        {
            get
            {
                if (Session["EmployeeBasicInformation_CountryList"] == null)
                    return new CustomList<Gen_Country>();
                else
                    return (CustomList<Gen_Country>)Session["EmployeeBasicInformation_CountryList"];
            }
            set
            {
                Session["EmployeeBasicInformation_CountryList"] = value;
            }
        }

        //private CustomList<Gen_Exam> ExamList
        //{
        //    get
        //    {
        //        if (Session["ExamList"] == null)
        //            return new CustomList<Gen_Exam>();
        //        else
        //            return (CustomList<Gen_Exam>)Session["ExamList"];
        //    }
        //    set
        //    {
        //        Session["ExamList"] = value;
        //    }
        //}

        private CustomList<ASL.Hr.DAO.EducationQualification> EducationQualificationList
        {
            get
            {
                if (Session["EmployeeBasicInformation_EducationQualificationList"] == null)
                    return new CustomList<ASL.Hr.DAO.EducationQualification>();
                else
                    return (CustomList<ASL.Hr.DAO.EducationQualification>)Session["EmployeeBasicInformation_EducationQualificationList"];
            }
            set
            {
                Session["EmployeeBasicInformation_EducationQualificationList"] = value;
            }
        }

        //private CustomList<Gen_Country> GroupList
        //{
        //    get
        //    {
        //        if (Session["EmployeeBasicInformation_GroupList"] == null)
        //            return new CustomList<Gen_Country>();
        //        else
        //            return (CustomList<Gen_Country>)Session["EmployeeBasicInformation_GroupList"];
        //    }
        //    set
        //    {
        //        Session["EmployeeBasicInformation_GroupList"] = value;
        //    }
        //}
        #endregion

        #region Ctor
        public EmployeeEducationInformation()
        {
            _manager = new EmployeeManager();
        }
        #endregion

        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSession();
                EmpKey = null;
            }
        }

        #endregion

        internal void PopulateControl()
        {
            InitializeSession();
        }

        internal void SaveEmpEducationInfo(ArrayList empInfo)
        {
            //if (Session["EmpKey"] == null)
            //    return;

            //var empKey = EmpKey.ToInt(); ;
            var eduList = ((CustomList<HRM_EmpEdu>)EducationList);
            var dipEduList = ((CustomList<HRM_EmpEduDip>)DipEducationList);
            var professionTrainList = ((CustomList<HRM_EmpEduDip>)ProfessionalTrainingList);

            foreach (HRM_EmpEduDip ED in dipEduList)
            {
                ED.DipOrTran = "Diploma";
            }

            foreach (HRM_EmpEduDip ED in professionTrainList)
            {
                ED.DipOrTran = "Training";
                dipEduList.Add(ED);
            }


            //eduList.ForEach(x => x.EmpKey = empKey);
            //dipEduList.ForEach(x => x.EmpKey = empKey);

            //_manager.SaveEmpEdu(ref eduList, ref dipEduList);

            empInfo.Add(eduList);
            empInfo.Add(dipEduList);
            //empInfo.Add(professionTrainList);
        }

        #region Others

        public void InitializeSession()
        {
            EducationList = new CustomList<HRM_EmpEdu>();
            DipEducationList = new CustomList<HRM_EmpEduDip>();
            ProfessionalTrainingList = new CustomList<HRM_EmpEduDip>();
           // EducationList = _manager.GetAllEmpEduByEmpKey(EmpKey);
            //DipEducationList = _manager.GetAllDipEduByEmpKey(EmpKey, "Diploma");
            //ProfessionalTrainingList = _manager.GetAllDipEduByEmpKey(EmpKey, "Training");
            CountryList = _manager.GetAllCountry();
        }



        #endregion

        internal void Delete()
        {
            EducationList.ForEach(x => x.Delete());
            DipEducationList.ForEach(x => x.Delete());
            ProfessionalTrainingList.ForEach(x => x.Delete());
            //this.SaveEmpEducationInfo();
        }
    }
}