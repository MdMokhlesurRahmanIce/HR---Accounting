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
    public partial class OTAssignmentApproval : PageBase
    {
        #region Constructur
        public OTAssignmentApproval()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<ASL.Hr.DAO.OTAssignment> OTAssignmentList
        {
            get
            {
                if (Session["OTAssignmentApproval_OTAssignmentList"] == null)
                    return new CustomList<ASL.Hr.DAO.OTAssignment>();
                else
                    return (CustomList<ASL.Hr.DAO.OTAssignment>)Session["OTAssignmentApproval_OTAssignmentList"];
            }
            set
            {
                Session["OTAssignmentApproval_OTAssignmentList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                OTAssignmentList = new CustomList<ASL.Hr.DAO.OTAssignment>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        #endregion
    }
}