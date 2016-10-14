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
using System.Collections;
using System.Data.SqlClient;

namespace Hr.Web.UI.Attendance
{
    public partial class OTSlab : PageBase
    {
        OTSlabManager manager = new OTSlabManager();
        #region Constructur
        public OTSlab()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<ASL.Hr.DAO.OTSlab> OTSlabList
        {
            get
            {
                if (Session["OTSlab_OTSlabList"] == null)
                    return new CustomList<ASL.Hr.DAO.OTSlab>();
                else
                    return (CustomList<ASL.Hr.DAO.OTSlab>)Session["OTSlab_OTSlabList"];
            }
            set
            {
                Session["OTSlab_OTSlabList"] = value;
            }
        }
        private CustomList<PopulateDropdownList> DropdownList
        {
            get
            {
                if (Session["OTSlab_DropdownList"] == null)
                    return new CustomList<PopulateDropdownList>();
                else
                    return (CustomList<PopulateDropdownList>)Session["OTSlab_DropdownList"];
            }
            set
            {
                Session["OTSlab_DropdownList"] = value;
            }
        }
        private CustomList<SalaryHead> SalaryHeadList
        {
            get
            {
                if (Session["OTSlab_SalaryHeadList"] == null)
                    return new CustomList<SalaryHead>();
                else
                    return (CustomList<SalaryHead>)Session["OTSlab_SalaryHeadList"];
            }
            set
            {
                Session["OTSlab_SalaryHeadList"] = value;
            }
        }
        #endregion
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    txtOTSlabID.Text = StaticInfo.NewIDString;
                    txtOTSlabID.Enabled = false;
                    InitializeSession();
                }
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "SearchOTSlab")
                {
                    ASL.Hr.DAO.OTSlab searchOTSlab = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as ASL.Hr.DAO.OTSlab;
                    if (searchOTSlab.IsNotNull())
                    {
                        txtOTSlabID.Text = searchOTSlab.OTSlabID;
                        OTSlabList = manager.GetAllOTSlab(searchOTSlab.OTSlabID);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                SalaryHeadList = new CustomList<SalaryHead>();
                OTSlabList = new CustomList<ASL.Hr.DAO.OTSlab>();
                DropdownList = new CustomList<PopulateDropdownList>();
                foreach (int value in Enum.GetValues(typeof(enumsHr.enumCalculationMethod)))
                {
                    DropdownList.Add(new PopulateDropdownList
                    {
                        Text = Enum.GetName(typeof(enumsHr.enumCalculationMethod), value),
                        ValueField = value
                    });
                }

                SalaryHeadList = manager.GetAllSalaryHeadForSalaryRule();
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.OTSlab> lstOTSlab = (CustomList<ASL.Hr.DAO.OTSlab>)OTSlabList;
                if (lstOTSlab.IsNotNull())
                {
                    if (!CheckUserAuthentication(lstOTSlab)) return;
                    manager.SaveOTSlab(ref lstOTSlab);
                    txtOTSlabID.Text = manager.OTSlabID;
                    this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                }
            }
            catch (SqlException ex)
            {
                this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtOTSlabID.Enabled = true;
                txtOTSlabID.Text = StaticInfo.NewIDString;
                InitializeSession();  
            }
            catch (SqlException ex)
            {
                throw(ex);
            }
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.OTSlab> items = manager.GetAllOTSlab();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("OTSlabID", "OT Slab");

                StaticInfo.SearchItem(items, "OT Slab", "SearchOTSlab", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(ASL.Hr.DAO.OTSlab), columns), 500);
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
                CustomList<ASL.Hr.DAO.OTSlab> lstOTSlab = OTSlabList;
                if (lstOTSlab.Count !=0)
                {
                    lstOTSlab.ForEach(f=>f.Delete());
                    if (CheckUserAuthentication(lstOTSlab).IsFalse()) return;
                    manager.DeleteOTSlab(ref lstOTSlab);
                    txtOTSlabID.Enabled = false;
                    txtOTSlabID.Text = StaticInfo.NewIDString;
                    InitializeSession();
                    this.ErrorMessage = (StaticInfo.DeletedSuccessfullyMsg);
                }
            }
            catch (Exception ex)
            {

                this.ErrorMessage = ("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        #endregion
    }
}