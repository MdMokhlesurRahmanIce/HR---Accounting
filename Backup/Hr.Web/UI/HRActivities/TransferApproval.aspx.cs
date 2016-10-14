using System;
using ASL.DATA;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.Web.Framework;

namespace Hr.Web.UI.EmployeeBasicInfo
{
    public partial class TransferApproval : PageBase
    {
        PromotionManager manager = new PromotionManager();
        #region Sesson Variable
        private CustomList<ASL.Hr.DAO.TransferAndPromotionHistory> _TransferEmpList
        {
            get
            {
                if (Session["TransferApproval_TransferEmpList"] == null)
                    return new CustomList<ASL.Hr.DAO.TransferAndPromotionHistory>();
                else
                    return (CustomList<ASL.Hr.DAO.TransferAndPromotionHistory>)Session["TransferApproval_TransferEmpList"];
            }
            set
            {
                Session["TransferApproval_TransferEmpList"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.TransferAndPromotionHistory> _TransferCriteria
        {
            get
            {
                if (Session["TransferApproval_TransferCriteria"] == null)
                    return new CustomList<ASL.Hr.DAO.TransferAndPromotionHistory>();
                else
                    return (CustomList<ASL.Hr.DAO.TransferAndPromotionHistory>)Session["TransferApproval_TransferCriteria"];
            }
            set
            {
                Session["TransferApproval_TransferCriteria"] = value;
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
                _TransferEmpList = new CustomList<TransferAndPromotionHistory>();
                _TransferCriteria = new CustomList<TransferAndPromotionHistory>();
                _TransferEmpList = manager.GetAllEmpForTransferApproval();
                _TransferCriteria = manager.GetAllTransferApproval();
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        #endregion
    }
}