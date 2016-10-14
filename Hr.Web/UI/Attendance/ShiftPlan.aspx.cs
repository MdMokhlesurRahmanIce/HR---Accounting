using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;
//using  Web.Hr.Controls;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;

namespace Hr.Web.UI.Attendance
{
    public partial class ShiftPlan : PageBase
    {
        ShiftPlanManager manager = new ShiftPlanManager();
        #region Session Variable
        private CustomList<ShiftBreakInfo> ShiftBreakInfoList
        {
            get
            {
                if (Session["ShiftPlan_ShiftBreakInfoList"] == null)
                    return new CustomList<ShiftBreakInfo>();
                else
                    return (CustomList<ShiftBreakInfo>)Session["ShiftPlan_ShiftBreakInfoList"];
            }
            set
            {
                Session["ShiftPlan_ShiftBreakInfoList"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.ShiftPlan> ShiftPlanMasterList
        {
            get
            {
                if (Session["ShiftPlan_ShiftPlanMasterList"] == null)
                    return new CustomList<ASL.Hr.DAO.ShiftPlan>();
                else
                    return (CustomList<ASL.Hr.DAO.ShiftPlan>)Session["ShiftPlan_ShiftPlanMasterList"];
            }
            set
            {
                Session["ShiftPlan_ShiftPlanMasterList"] = value;
            }
        }
        #endregion
        #region Constructur
        public ShiftPlan()
        {
            RequiresAuthorization = true;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "IsPostBack", "var isPostBack = true;", true);
                InitializeCombo();
                InitializeSession();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "SearchShiftPlan")
                {
                    ShiftPlanMasterList = new CustomList<ASL.Hr.DAO.ShiftPlan>();
                    ASL.Hr.DAO.ShiftPlan searchShiftPlan = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as ASL.Hr.DAO.ShiftPlan;
                    ShiftPlanMasterList.Add(searchShiftPlan);
                    if (searchShiftPlan.IsNotNull())
                    {
                        PopulateShiftPlanInformation(searchShiftPlan);
                    }
                }
            }
        }
        #region all methods
        private void PopulateShiftPlanInformation(ASL.Hr.DAO.ShiftPlan shiftPlan)
        {
            try
            {
                txtShiftID.Text = shiftPlan.ShiftID.ToString();
                ddlShiftType.SelectedValue = shiftPlan.ShiftType.ToString();
                txtAlise.Text = shiftPlan.ALISE;
                txtDescription.Text = shiftPlan.Description;
                chkIsAutoCalculate.Checked = shiftPlan.IsAutoCalculate;
                chkIsProcessInSameDate.Checked = shiftPlan.IsProcessInSameDate;
                chkMakeItActive.Checked = shiftPlan.IsActive;
                chkMakeItDefault.Checked = shiftPlan.IsDefault;
                txtShiftInTime.Text = shiftPlan.ShiftIntime.ToDateTime().ToShortTimeString();
                txtShiftInStartMargin.Text = shiftPlan.ShiftInStartMargin.ToDateTime().ToShortTimeString();
                txtShiftOutTime.Text = shiftPlan.ShiftOutTime.ToDateTime().ToShortTimeString();
                txtShiftOutEndMargin.Text = shiftPlan.ShiftOutEndMargin.ToDateTime().ToShortTimeString();
                txtAbsentEndMargin.Text = shiftPlan.AbsentEndmargin.ToString()=="" ?  "": shiftPlan.AbsentEndmargin.ToDateTime().ToShortTimeString();

                /*DateTime toDate = DateTime.ParseExact(shiftPlan.ShiftOutTime, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                DateTime fromDate = DateTime.ParseExact(shiftPlan.ShiftIntime, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                TimeSpan diff = (toDate - fromDate);
                var seconds = diff.TotalSeconds;
                var minutes = Math.Floor(seconds / 60);
                seconds = seconds % 60;
                var hours = Math.Floor(minutes / 60);
                minutes = minutes % 60;
                txtWorkingHour.Text = hours + ":" + minutes;*/
                txtWorkingHour.Text = "8";

                txtEarlyOutMargin.Text = shiftPlan.EarlyOutMargin;
                txtLateMargin.Text = shiftPlan.LateMargin;
                ShiftBreakInfoList = manager.GetAllShiftBreakInfo(shiftPlan.ShiftID);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            try
            {
                //Loding Shift Type
                ddlShiftType.DataSource = manager.GetAllGen_LookupEnt();
                ddlShiftType.DataTextField = "ElementName";
                ddlShiftType.DataValueField = "ElementKey";
                ddlShiftType.DataBind();
                ddlShiftType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlShiftType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeSession()
        {
            try
            {
                ShiftBreakInfoList = new CustomList<ShiftBreakInfo>();
                ShiftPlanMasterList = new CustomList<ASL.Hr.DAO.ShiftPlan>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControlToObj(ref CustomList<ASL.Hr.DAO.ShiftPlan> lstShiftPlan)
        {
            try
            {
                ASL.Hr.DAO.ShiftPlan obj = lstShiftPlan[0];
                obj.ShiftType = ddlShiftType.SelectedValue.ToInt();
                obj.ALISE = txtAlise.Text;
                obj.Description = txtDescription.Text;
                obj.ShiftIntime = DateTime.Now.ToShortDateString()+' '+ txtShiftInTime.Text;
                DateTime I = (DateTime.Now.ToShortDateString() + ' ' + txtShiftInTime.Text).ToDateTime();
                DateTime IS = (DateTime.Now.ToShortDateString() + ' ' + txtShiftInStartMargin.Text).ToDateTime();
                if (IS < I)
                {
                    obj.ShiftInStartMargin = DateTime.Now.ToShortDateString() + ' ' + txtShiftInStartMargin.Text;
                }
                else obj.ShiftInStartMargin = DateTime.Now.AddDays(-1).ToShortDateString() + ' ' + txtShiftInStartMargin.Text;
                
                DateTime O = (DateTime.Now.ToShortDateString() + ' ' + txtShiftOutTime.Text).ToDateTime();
                DateTime OE = (DateTime.Now.ToShortDateString() + ' ' + txtShiftOutEndMargin.Text).ToDateTime();
                if (I < O)
                {
                    obj.ShiftOutTime = DateTime.Now.ToShortDateString() + ' ' + txtShiftOutTime.Text;
                   
                }
                else
                {
                    obj.ShiftOutTime = DateTime.Now.AddDays(1).ToShortDateString() + ' ' + txtShiftOutTime.Text;
                   
                }
                if (I < OE)
                {
                    obj.ShiftOutEndMargin = DateTime.Now.ToShortDateString() + ' ' + txtShiftOutEndMargin.Text;
                }
                else
                {
                    obj.ShiftOutEndMargin = DateTime.Now.AddDays(1).ToShortDateString() + ' ' + txtShiftOutEndMargin.Text;
                }
                obj.AbsentEndmargin = txtAbsentEndMargin.Text;
                obj.IsActive = chkMakeItActive.Checked;
                obj.IsDefault = chkMakeItDefault.Checked;
                obj.IsAutoCalculate = chkIsAutoCalculate.Checked;
                obj.IsProcessInSameDate = chkIsProcessInSameDate.Checked;
                obj.LateMargin = txtLateMargin.Text;
                obj.EarlyOutMargin = txtEarlyOutMargin.Text;
                if (obj.ShiftID != 0) obj.SetModified();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void ClearControls()
        {
            txtShiftID.Text = String.Empty;
            ddlShiftType.SelectedValue = String.Empty;
            txtAlise.Text = String.Empty;
            txtDescription.Text = String.Empty;
            chkIsAutoCalculate.Checked = false;
            chkIsProcessInSameDate.Checked = false;
            chkMakeItActive.Checked = false;
            chkMakeItDefault.Checked = false;
            txtShiftInTime.Text = String.Empty;
            txtShiftInStartMargin.Text = String.Empty;
            txtShiftOutTime.Text = String.Empty;
            txtShiftOutEndMargin.Text = String.Empty;
            txtAbsentEndMargin.Text = String.Empty;
            txtWorkingHour.Text = String.Empty;
            txtEarlyOutMargin.Text = String.Empty;
            txtLateMargin.Text = String.Empty;
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.ShiftPlan> lstShiftPlan = (CustomList<ASL.Hr.DAO.ShiftPlan>)ShiftPlanMasterList;
                if (lstShiftPlan.Count == 0)
                {
                    ASL.Hr.DAO.ShiftPlan newShiftPlan = new ASL.Hr.DAO.ShiftPlan();
                    lstShiftPlan.Add(newShiftPlan);
                }
                SetDataFromControlToObj(ref lstShiftPlan);
                CustomList<ShiftBreakInfo> lstShiftBreakInfo = (CustomList<ShiftBreakInfo>)ShiftBreakInfoList;

                if (!CheckUserAuthentication(lstShiftPlan, lstShiftBreakInfo)) return;
                manager.SaveShiftPlan(ref lstShiftPlan, ref lstShiftBreakInfo);
                txtShiftID.Text = manager._ShiftID.ToString();
                ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                ShiftBreakInfoList = new CustomList<ShiftBreakInfo>();
                txtShiftID.Text = StaticInfo.NewIDString;
                txtWorkingHour.Text = "0";
                txtLateMargin.Text = "0";
                txtEarlyOutMargin.Text = "0";
                chkMakeItActive.Checked = true;
                txtDescription.Enabled = true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.ShiftPlan> items = manager.GetAllShiftPlan();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("ShiftID", "Shift ID");
                columns.Add("Description", "Description");
                columns.Add("ShiftIntime", "Shift in time");
                columns.Add("ShiftOutTime", "Shift out time");

                StaticInfo.SearchItem(items, "Shift Plan", "SearchShiftPlan", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(ASL.Hr.DAO.ShiftPlan), columns), 500);
            }
            catch (Exception ex)
            {

                this.ErrorMessage = ("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.ShiftPlan> lstShiftPlan = ShiftPlanMasterList;
                CustomList<ShiftBreakInfo> lstShiftBreakInfo = ShiftBreakInfoList;
                if (lstShiftPlan.Count != 0)
                {
                    lstShiftPlan.ForEach(f => f.Delete());
                    lstShiftBreakInfo.ForEach(f => f.Delete());
                    if (CheckUserAuthentication(lstShiftPlan, lstShiftBreakInfo).IsFalse()) return;
                    manager.DeleteShiftPlan(ref lstShiftPlan, ref lstShiftBreakInfo);
                    ClearControls();
                    InitializeSession();
                    this.ErrorMessage = (StaticInfo.DeletedSuccessfullyMsg);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
    }
}