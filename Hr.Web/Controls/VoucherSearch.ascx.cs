using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACC.BLL;
using ACC.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;
using System.Data.SqlClient;
using System.Text;

namespace Hr.Web.Controls
{
    public partial class VoucherSearch : System.Web.UI.UserControl
    {
        VoucherManager manager = new VoucherManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeCombo();
                    txtDateFrom.Text = DateTime.Now.ToString(StaticInfo.GridDateFormatAcc);
                    txtDateTo.Text = DateTime.Now.ToString(StaticInfo.GridDateFormatAcc);
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #region All Methods
        private void InitializeCombo()
        {
            try
            {
                //Loding Company
                ddlCompany.DataSource = manager.GetCompany();
                ddlCompany.DataTextField = "HKName";
                ddlCompany.DataValueField = "HKID";
                ddlCompany.DataBind();
                //if (((PageBase)this.Page).CurrentUserSession.IsAdmin)
                //{
                //    ddlCompany.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                //    ddlCompany.SelectedIndex = 0;
                //}
                //Loding Voucher Type GetAllAcc_VoucherType
                ddlVoucherType.DataSource = manager.GetAllAcc_VoucherType();
                ddlVoucherType.DataTextField = "VoucherTypeCode";
                ddlVoucherType.DataValueField = "VoucherTypeKey";
                ddlVoucherType.DataBind();
                ddlVoucherType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlVoucherType.SelectedIndex = 0;

                ddlSO.DataSource = manager.GetAllSO();
                ddlSO.DataTextField = "EmpName";
                ddlSO.DataValueField = "EmpKey";
                ddlSO.DataBind();
                ddlSO.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlSO.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}