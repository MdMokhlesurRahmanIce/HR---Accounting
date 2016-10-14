using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Web.Framework;
using ASL.Hr.BLL;
using ASL.DATA;
using ASL.Hr.DAO;
//using ST.Web.Hr.Utils;
using System.Collections;
using System.Text;
using ASL.STATIC;
using System.Data.SqlClient;
//using ASL.Web.Hr.Controls;

namespace Hr.Web.UI.Evaluation
{
    public partial class EvalManagement : PageBase
    {
        #region Fileds
        public readonly EvaluationManager _evalManager = new EvaluationManager();
        #endregion

        #region Properties
        private CustomList<HRM_Eval> EmpHistList
        {
            get
            {
                if (Session["EvalManagement_EmpHistList"] == null)
                    return new CustomList<HRM_Eval>();
                else
                    return (CustomList<HRM_Eval>)Session["EvalManagement_EmpHistList"];
            }
            set
            {
                Session["EvalManagement_EmpHistList"] = value;
            }
        }
        private CustomList<HRM_EvalDet> HRM_EvalDettList
        {
            get
            {
                if (Session["EvalManagement_HRM_EvalDet"] == null)
                    return new CustomList<HRM_EvalDet>();
                else
                    return (CustomList<HRM_EvalDet>)Session["EvalManagement_HRM_EvalDet"];
            }
            set
            {
                Session["EvalManagement_HRM_EvalDet"] = value;
            }
        }
        private CustomList<HRM_EvalItem> HRM_EvalItemList
        {
            get
            {
                if (Session["EvalManagement_HRM_EvalItem"] == null)
                    return new CustomList<HRM_EvalItem>();
                else
                    return (CustomList<HRM_EvalItem>)Session["EvalManagement_HRM_EvalItem"];
            }
            set
            {
                Session["EvalManagement_HRM_EvalItem"] = value;
            }
        }

        public int pagetype;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            var ptype = Request.QueryString.Get("type");

            if (ptype != null)
            {
                if (ptype == "nonmanagement")
                {
                    pagetype = 2;
                    lblFrmHeader.Text = "Performance Appraisal - Non Management Staff";
                }
            }
            else
            {
                pagetype = 1;
                lblFrmHeader.Text = "Performance Appraisal - Management Staff";
            }

            if (IsPostBack.IsFalse())
            {
                HRM_EvalDettList = new CustomList<HRM_EvalDet>();
                PopulateCombo();
                EnableControl(false);
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);

                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "SearchEval")
                {
                    hf_EvalKey.Value = "-1";
                    HRM_Eval searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Eval;
                    if (searchEmp.IsNotNull())
                    {
                        hf_EvalKey.Value = searchEmp.EvalKey.ToString();
                        EmpHistList = _evalManager.GetAllHRM_Eval(hf_EvalKey.Value.ToString());

                        if (EmpHistList.Count > 0)
                            GetValueFromList(EmpHistList[0]);

                        //LoadEmployeeInfo(txtEmployee.Text.ToString());
                        LoadGridProfermanceArea(hf_EvalKey.Value.ToString());
                        EnableControl(true);
                    }
                }
            }
        }

        #region Method
        private void LoadGridProfermanceArea(String EvalKey)
        {
            try
            {
                HRM_EvalDettList = _evalManager.GetHRM_EvalDet(EvalKey, pagetype);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        public void ClearControl()
        {
            try
            {
                hf_EvalKey.Value = "-1";
                txtDateTo.Text = string.Empty;
                txtDateFrom.Text = string.Empty;
                txtSpecQulification.Text = string.Empty;
                txtLimitations.Text = string.Empty;
                txtImprovment.Text = string.Empty;
                txtThisSpecQualification.Text = string.Empty;
                txtThisSortCommings.Text = string.Empty;
                txtThisSuggestion.Text = string.Empty;
                txtSuggestion.Text = string.Empty;
                txtSigPerformance.Text = string.Empty;
                txtEvalutorRec.Text = string.Empty;
                txtReveiwerRec.Text = string.Empty;
                txtHrRecom.Text = string.Empty;

                txtDateJoin.Text = string.Empty;
                txtDatePrevious.Text = string.Empty;
                txtDatePresent.Text = string.Empty;
                txtDateProposed.Text = string.Empty;

                txtGrossJoin.Text = string.Empty;
                txtPreviousSalary.Text = string.Empty;
                txtPresentSalary.Text = string.Empty;
                txtPurpose.Text = string.Empty;

                txtLastDayOfPromosion.Text = string.Empty;

                lblName.Text = String.Empty;
                lblDesig.Text = String.Empty;
                lblDept.Text = String.Empty;
                lblNatureOfEmp.Text = String.Empty;
                lblAcademicQualification.Text = String.Empty;
                lblLengthofWings.Text = String.Empty;
                lblDOJ.Text = String.Empty;
                lblPresentGrade.Text = String.Empty;
                lblWorkStat.Text = String.Empty;
                lblLengthofWings.Text = String.Empty;
                lblTotalServiceLength.Text = String.Empty;
                ddlDesignation.ClearSelection();
                LoadGridProfermanceArea(hf_EvalKey.Value.ToString());
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        public void EnableControl(bool Flag)
        {
            try
            {
                txtDateTo.Enabled = Flag;
                txtDateFrom.Enabled = Flag;
                txtSpecQulification.Enabled = Flag;
                txtLimitations.Enabled = Flag;
                txtImprovment.Enabled = Flag;
                txtThisSpecQualification.Enabled = Flag;
                txtThisSortCommings.Enabled = Flag;
                txtThisSuggestion.Enabled = Flag;
                txtSuggestion.Enabled = Flag;
                txtSigPerformance.Enabled = Flag;
                txtEvalutorRec.Enabled = Flag;
                txtReveiwerRec.Enabled = Flag;
                txtHrRecom.Enabled = Flag;
                txtPreviousSalary.Enabled = Flag;
                txtPresentSalary.Enabled = Flag;
                txtPurpose.Enabled = Flag;
                txtLastDayOfPromosion.Enabled = Flag;
                txtPreYaerTranning.Enabled = Flag;

                txtDateJoin.Enabled = Flag;
                txtDatePrevious.Enabled = Flag;
                txtDatePresent.Enabled = Flag;
                txtDateProposed.Enabled = Flag;

                drpOtherRecom.Enabled = Flag;
                ddlDesignation.Enabled = Flag;
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        private void SetValueFromControl(HRM_Eval objList)
        {
            try
            {
                if (hf_EvalKey.Value.ToString() != "-1")
                    objList.EvalKey = hf_EvalKey.Value.ToInt();
                objList.EvalFrom = txtDateFrom.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
                objList.EvalTo = txtDateTo.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
                objList.EvalDate = DateTime.Now;
                //objList.EmpKey = hfEmpKey.Value.ToInt();
                objList.ImproveSugg = txtSuggestion.Text.ToString();
                objList.EmpComntAck = txtSigPerformance.Text.ToString();
                objList.EvalRecom = txtEvalutorRec.Text.ToString();
                objList.ReviewRecom = txtReveiwerRec.Text.ToString();
                objList.Comment = txtHrRecom.Text.ToString();

                objList.DateJoin = txtDateJoin.Text.ToString().ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
                objList.DatePrevious = txtDatePrevious.Text.ToString().ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
                objList.DatePresent = txtDatePresent.Text.ToString().ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
                objList.DatePreposed = txtDateProposed.Text.ToString().ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);

                objList.GrossJoinSal = txtGrossJoin.Text.ToDecimal();

                if (String.IsNullOrWhiteSpace(txtPreviousSalary.Text)) txtPreviousSalary.Text = "0";
                objList.GrossPresentSal = txtPreviousSalary.Text.ToDecimal();
                if (String.IsNullOrWhiteSpace(txtPresentSalary.Text)) txtPresentSalary.Text = "0";
                objList.GrossPreviousSal = txtPresentSalary.Text.ToDecimal();
                if (String.IsNullOrWhiteSpace(txtPurpose.Text)) txtPurpose.Text = "0";
                objList.GrossProposedSal = txtPurpose.Text.ToDecimal();
                if (String.IsNullOrEmpty(txtPresentSalary.Text) == false)
                    objList.LastPromDate = txtLastDayOfPromosion.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
                if (ddlDesignation.SelectedValue != "")
                    objList.ToBePromoted = ddlDesignation.SelectedValue.ToInt();
                if (drpOtherRecom.SelectedValue != "")
                    objList.OtherRecom = drpOtherRecom.SelectedValue.ToInt();
                objList.M_CYSpQual = txtSpecQulification.Text.ToString();
                objList.M_CYShortComing = txtLimitations.Text.ToString();
                objList.M_CYSugg = txtImprovment.Text.ToString();
                objList.M_LYTraining = txtLastYearTranning.Text.ToString();
                objList.M_CYTraining = txtPreYaerTranning.Text.ToString();
                objList.M_CYSugg = txtThisSpecQualification.Text.ToString();
                objList.M_CYShortComing = txtThisSortCommings.Text.ToString();
                objList.M_CYSpQual = txtThisSuggestion.Text.ToString();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        private void GetValueFromList(HRM_Eval objList)
        {
            try
            {
                txtDateFrom.Text = objList.EvalFrom.ToString(StaticInfo.GridDateFormat);
                txtDateTo.Text = objList.EvalTo.ToString(StaticInfo.GridDateFormat);

                //hfEmpKey.Value = objList.EmpKey.ToString();
                txtSuggestion.Text = objList.ImproveSugg.ToString();
                txtSigPerformance.Text = objList.EmpComntAck.ToString();
                txtEvalutorRec.Text = objList.EvalRecom.ToString();
                txtReveiwerRec.Text = objList.ReviewRecom.ToString();
                txtHrRecom.Text = objList.Comment.ToString();

                txtDateJoin.Text = objList.DateJoin.ToString(StaticInfo.GridDateFormat);
                txtDatePrevious.Text = objList.DatePrevious.ToString(StaticInfo.GridDateFormat);
                txtDatePresent.Text = objList.DatePresent.ToString(StaticInfo.GridDateFormat);
                txtDateProposed.Text = objList.DatePreposed.ToString(StaticInfo.GridDateFormat);

                txtGrossJoin.Text = objList.GrossJoinSal.ToString();

                txtPreviousSalary.Text = objList.GrossPresentSal.ToString();
                txtPresentSalary.Text = objList.GrossPreviousSal.ToString();
                txtPurpose.Text = objList.GrossProposedSal.ToString();
                txtLastDayOfPromosion.Text = objList.LastPromDate.ToString(StaticInfo.GridDateFormat);
                ddlDesignation.SelectedValue = objList.ToBePromoted.ToString();
                drpOtherRecom.SelectedValue = drpOtherRecom.Items.FindByValue(objList.OtherRecom.ToString()) == null ? "" : objList.OtherRecom.ToString();
                txtSpecQulification.Text = objList.M_CYSpQual.ToString();
                txtLimitations.Text = objList.M_CYShortComing.ToString();
                txtImprovment.Text = objList.M_CYSugg.ToString();
                txtLastYearTranning.Text = objList.M_LYTraining.ToString();
                txtPreYaerTranning.Text = objList.M_CYTraining.ToString();
                txtThisSpecQualification.Text = objList.M_CYSugg.ToString();
                txtThisSortCommings.Text = objList.M_CYShortComing.ToString();
                txtThisSuggestion.Text = objList.M_CYSpQual.ToString();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        private void PopulateCombo()
        {
            try
            {
                //#region Designation
                //ddlDesignation.DataSource = _evalManager.GetAllGen_Desig();
                //ddlDesignation.DataTextField = "DesigName";
                //ddlDesignation.DataValueField = "DesigKey";
                //ddlDesignation.DataBind();
                //ddlDesignation.Items.Insert(0, new ListItem() { Value = "", Text = "" });
                //#endregion

                //#region OtherRecommendation
                //LeaveApplicationManager lm = new LeaveApplicationManager();
                //drpOtherRecom.DataSource = lm.GetEntityLookup(enumsHr.enumEntitySetup.OtherRecommendation);
                //drpOtherRecom.DataTextField = "ElementName";
                //drpOtherRecom.DataValueField = "EntityKey";
                //drpOtherRecom.DataBind();
                //drpOtherRecom.Items.Insert(0, new ListItem() { Value = "", Text = "" });
                //#endregion

                HRM_EvalItemList = _evalManager.GetAllHRM_EvalItem(pagetype);
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        private void LoadEmployeeInfo(string strEmployeeCode)
        {
            try
            {
                HRM_Emp Emp = new HRM_Emp(); ;
                Emp = HRM_Emp.GetEmployeeServiceInformation(strEmployeeCode);
                //hfEmpKey.Value = Emp.EmpKey.ToString();
                //lblName.Text = Emp.EmpName;
                //lblDesig.Text = Emp.DesigName;
                //lblDept.Text = Emp.Department;
                //lblNatureOfEmp.Text = Emp.EmpTypeName;
                //lblAcademicQualification.Text = Emp.ExamName;
                //lblLengthofWings.Text = Emp.EmpPresentExpre.ToString();
                //lblDOJ.Text = Emp.DOJ.ToString(ST.STATIC.StaticInfo.GridDateFormat);
                //LblCinfirmation.Text = Emp.PermanentDate.ToString(ST.STATIC.StaticInfo.GridDateFormat);
                //lblPresentGrade.Text = Emp.Grade;
                //lblWorkStat.Text = Emp.SepRemark;
                //lblLengthofWings.Text = Emp.EmpPresentExpre.ToString();
                //lblTotalServiceLength.Text = (Emp.ActualExperiance + Emp.EmpPresentExpre).ToString();

                //CustomList<HRM_EmpEdu> edus = HRM_EmpEdu.GetAllEmpEduByEmpKey(Emp.EmpKey, 2);
                //CustomList<HRM_EmpEduDip> dips = HRM_EmpEduDip.GetAllDipEduByEmpKey(Emp.EmpKey.ToString(), "Training");
                
                //edus.Reverse();

                //string top2Edus = string.Empty;
                //string alldips = string.Empty;

                //foreach (var item in edus)
                //{
                //    top2Edus += item.AchievementComm + ",";
                //}

                //foreach (var item in dips)
                //{
                //    alldips += item.DipName + ",";
                //}

                //if (top2Edus.EndsWith(","))
                //    top2Edus = top2Edus.Substring(0, top2Edus.Length - 1);

                //if (alldips.EndsWith(","))
                //    alldips = alldips.Substring(0, alldips.Length - 1);

                //lblAcademicQualification.Text = top2Edus;
                //lblProfQual.Text = alldips;
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        #endregion

        #region Button event

        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var page = this.Page as EvalManagement;
                EmpHistList = new CustomList<HRM_Eval>();
                page.ClearControl();
                EnableControl(true);
                //txtEmployee.Text = ((HiddenField)this.ucEmployeeSearch1.FindControl("hfEmpCode")).Value.ToString();
                //LoadEmployeeInfo(txtEmployee.Text.ToString());
                //txtLastYearTranning.Text = _evalManager.GetPreviousTranning(hfEmpKey.Value);
                hf_EvalKey.Value = "-1";
                LoadGridProfermanceArea(hf_EvalKey.Value.ToString());
                foreach (HRM_EvalDet list in HRM_EvalDettList)
                    list.SetAdded();

                //if (hfEmpKey.Value != "0")
                 //   loadSalHist(Convert.ToInt64(hfEmpKey.Value));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        private void loadSalHist(long empkey)
        {
            //CustomList<EmpSalHist> salList = EmpSalHist.GetAllEmpSalHistByEmpKey(empkey);

            //if (salList.Count > 0)
            //{
            //    EmpSalHist item = salList[0];

            //    txtDateJoin.Text = item.dateJoin.ToString(StaticInfo.GridDateFormat);
            //    txtDatePrevious.Text = item.datePrevious.ToString(StaticInfo.GridDateFormat);
            //    txtDatePresent.Text = item.datePresent.ToString(StaticInfo.GridDateFormat);

            //    txtGrossJoin.Text = item.grossJoin.ToString();
            //    txtPreviousSalary.Text = item.grossPrevious.ToString();
            //    txtPresentSalary.Text = item.grossPresent.ToString();
            //}

            //CustomList<EmpTransfer> list = EmpTransfer.GetLastEmpTransfer(empkey);
            //if (list.Count > 0)
            //{
            //    txtLastDayOfPromosion.Text = list[0].TransferDate.ToString(StaticInfo.GridDateFormat);
            //}
            //else
            //{
            //    txtLastDayOfPromosion.Text = string.Empty;
            //}
        }

        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                //txtEmployee.Text = ((HiddenField)this.ucEmployeeSearch1.FindControl("hfEmpCode")).Value.ToString();

                //LoadEmployeeInfo(txtEmployee.Text.ToString());
                //if (hfEmpKey.Value != "")
               // {
                 //   sb.Append("EmpKey=");
                   // sb.Append(hfEmpKey.Value.ToInt());
               // }

                //CustomList<HRM_Eval> ProcessedAndUnProcessedList = _evalManager.doSearch(hfEmpKey.Value.ToString());
                //Dictionary<string, string> columns = new Dictionary<string, string>();

                //columns.Add("EmpName", "Employee Name");
                //columns.Add("EvalDate", "Eval. Date");
                //columns.Add("EvalFrom", "From Date");
                //columns.Add("EvalTo", "To Date");

                //StaticInfo.SearchItem(ProcessedAndUnProcessedList, "Evaluation", "SearchEval", SearchColumnConfig.GetColumnConfig(typeof(HRM_Eval), columns), 500, GlobalEnums.enumSearchType.StoredProcedured);
            }
            catch (SqlException ex)
            {
                //this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                //this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            var page = this.Page as EvalManagement;
            page.ClearControl();
            ClearControl();
            EnableControl(false);

            FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
            HRM_EvalDettList = new CustomList<HRM_EvalDet>();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_Eval objEval = new HRM_Eval();

                if (EmpHistList.Count > 0)
                {
                    objEval = EmpHistList[0];
                    SetValueFromControl(objEval);
                }
                else
                {
                    objEval = new HRM_Eval();
                    SetValueFromControl(objEval);
                    EmpHistList.Add(objEval);
                }

                CustomList<HRM_Eval> HRM_EvalList = EmpHistList;
                CustomList<HRM_EvalDet> DelatislList = HRM_EvalDettList;

                _evalManager.SaveEvalution(ref HRM_EvalList, ref DelatislList);
                hf_EvalKey.Value = HRM_EvalList[0].EvalKey.ToString();

                ((PageBase)this.Page).SuccessMessage = ASL.STATIC.StaticInfo.SavedSuccessfullyMsg;
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpHistList.Count <= 0) return;
                CustomList<HRM_Eval> HRM_EvalList = EmpHistList;
                CustomList<HRM_EvalDet> DelatislList = HRM_EvalDettList;
                foreach (HRM_Eval list in HRM_EvalList)
                    list.Delete();
                foreach (HRM_EvalDet list in DelatislList)
                    list.Delete();
                _evalManager.SaveEvalution(ref HRM_EvalList, ref DelatislList);
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
                ((PageBase)this.Page).SuccessMessage = ASL.STATIC.StaticInfo.DeletedSuccessfullyMsg;
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        #endregion
    }
}