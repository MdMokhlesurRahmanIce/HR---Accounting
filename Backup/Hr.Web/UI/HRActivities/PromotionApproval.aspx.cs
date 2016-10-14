using System;
using ASL.DATA;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.Web.Framework;

namespace Hr.Web.UI.EmployeeBasicInfo
{
    public partial class PromotionApproval : PageBase
    {
        PromotionManager manager = new PromotionManager();
        #region Sesson Variable
        private CustomList<ASL.Hr.DAO.TransferAndPromotionHistory> _PromotionEmpList
        {
            get
            {
                if (Session["PromotionApproval_PromotionEmpList"] == null)
                    return new CustomList<ASL.Hr.DAO.TransferAndPromotionHistory>();
                else
                    return (CustomList<ASL.Hr.DAO.TransferAndPromotionHistory>)Session["PromotionApproval_PromotionEmpList"];
            }
            set
            {
                Session["PromotionApproval_PromotionEmpList"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.TransferAndPromotionHistory> _PromotionCriteria
        {
            get
            {
                if (Session["PromotionApproval_PromotionCriteria"] == null)
                    return new CustomList<ASL.Hr.DAO.TransferAndPromotionHistory>();
                else
                    return (CustomList<ASL.Hr.DAO.TransferAndPromotionHistory>)Session["PromotionApproval_PromotionCriteria"];
            }
            set
            {
                Session["PromotionApproval_PromotionCriteria"] = value;
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
                _PromotionEmpList = new CustomList<TransferAndPromotionHistory>();
                _PromotionCriteria = new CustomList<TransferAndPromotionHistory>();
                _PromotionEmpList = manager.GetAllEmpForPromotionApproval();
                _PromotionCriteria = manager.GetAllPromotionApproval();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}