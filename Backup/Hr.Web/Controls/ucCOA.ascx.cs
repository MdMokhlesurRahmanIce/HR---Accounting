using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.DATA;
using ACC.DAO;
using System.Data.SqlClient;
using ASL.Web.Framework;
using ASL.STATIC;
using ACC.BLL;

namespace Hr.Web.Controls
{
    public partial class ucCOA : System.Web.UI.UserControl
    {
        #region Session & ViewState
        public CustomList<Acc_COA> _COA
        {
            get
            {
                if (Session["COA_COA"] == null)
                    return new CustomList<Acc_COA>();
                else
                    return (CustomList<Acc_COA>)Session["COA_COA"];
            }
            set
            {
                Session["COA_COA"] = value;
            }
        }
        private Int64 _SelectedCOAKey
        {
            get
            {
                if (ViewState["COA_SelectedCOAKey"] == null)
                    return (Int64)0;
                else
                    return (Int64)ViewState["COA_SelectedCOAKey"];
            }
            set
            {
                ViewState["COA_SelectedCOAKey"] = value;
            }
        }
        private TreeNode _selnode
        {
            get
            {
                if (Session["_selnode"] == null)
                    return null;
                else
                    return (TreeNode)Session["_selnode"];
            }
            set
            {
                Session["_selnode"] = value;
            }
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCOA();
                populateTreeView();
                tv.CollapseAll();
            }
        }
        #endregion

        #region OnPreRender
        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                if (_selnode != null)
                {
                    string[] nodes = _selnode.ValuePath.Split('/');
                    string curNode = string.Empty;
                    foreach (string node in nodes)
                    {
                        curNode += node;
                        tv.FindNode(curNode).Expand();
                        curNode += "/";
                    }
                }
            }
            catch
            {
                tv.CollapseAll();
            }
            base.OnPreRender(e);
        }
        #endregion

        #region Load COA from DB
        private void loadCOA()
        {
            _COA = Acc_COA.GetAllAcc_COA(true);
        }
        #endregion

        #region Build Treeview
        private void populateTreeView()
        {
            loadCOA();
            tv.Nodes.Clear();
            foreach (Acc_COA item in _COA)
            {
                if (item.ParentKey == null)
                {
                    TreeNode tnParent = new TreeNode();
                    tnParent.Text = item.COAName;
                    tnParent.Value = item.COAKey.ToString();
                    tv.Nodes.Add(tnParent);
                    FillChild(tnParent, item.COAKey);
                }
            }
        }

        public int FillChild(TreeNode parent, Int64 coaKey)
        {
            CustomList<Acc_COA> list = _COA.FindAll(p => p.ParentKey == coaKey);

            if (list.Count > 0)
            {
                foreach (Acc_COA item in list)
                {
                    TreeNode child = new TreeNode();
                    child.Text = item.COAName;
                    child.Value = item.COAKey.ToString();
                    parent.ChildNodes.Add(child);
                    FillChild(child, item.COAKey);
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Button Events
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Acc_COA dupitem = _COA.Find(p => p.COAName == txtAhead.Text.Trim() && p.ParentKey == _SelectedCOAKey && p.COAKey != _SelectedCOAKey);
                if (dupitem != null)
                {
                    ((Hr.Web.UI.ACC.COA)this.Page).ErrorMessage = "Duplicate Head Name could not be created.";
                    return;
                }

                Acc_COA selectedNode = _COA.Find(p => p.COAKey == _SelectedCOAKey);
                if (selectedNode != null)
                {
                    selectedNode.COAName = txtAhead.Text.Trim();
                    selectedNode.IsActive = chkActive.Checked;
                    selectedNode.IsSubsidiary = chkIsSubsidiary.Checked;
                    if (SaveCOA())
                        ((Hr.Web.UI.ACC.COA)this.Page).SuccessMessage = StaticInfo.UpdatedSuccessfullyMsg; ;
                }
            }
            catch (Exception ex)
            {
                ((Hr.Web.UI.ACC.COA)this.Page).ErrorMessage = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Acc_COA selectedNode = _COA.Find(p => p.COAKey == _SelectedCOAKey);
                if (selectedNode != null)
                {
                    //selectedNode.COAKey
                    Acc_VoucherDet obj = null;
                    if (selectedNode.IsSubsidiary)
                    {
                        obj = Acc_VoucherDet.CheckToDelete(selectedNode.COAKey);
                    }
                    if (obj.IsAdded)
                    {
                        selectedNode.Delete();
                        if (SaveCOA())
                            ((Hr.Web.UI.ACC.COA)this.Page).SuccessMessage = StaticInfo.DeletedSuccessfullyMsg;
                    }
                    else
                    {
                        ((Hr.Web.UI.ACC.COA)this.Page).ErrorMessage = "Transaction has been occured to this head!";
                    }
                }
            }
            catch (Exception ex)
            {
                ((Hr.Web.UI.ACC.COA)this.Page).ErrorMessage = ex.Message;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCHead.Text.IsNullOrEmpty())
                {
                    ((Hr.Web.UI.ACC.COA)this.Page).ErrorMessage = "Please provide Head Name.";
                    return;
                }

                Acc_COA dupitem = _COA.Find(p => p.COAName == txtCHead.Text.Trim() && p.ParentKey == _SelectedCOAKey);
                if (dupitem != null)
                {
                    ((Hr.Web.UI.ACC.COA)this.Page).ErrorMessage = "Duplicate Head Name could not be created.";
                    return;
                }

                Acc_COA selectedItem = _COA.Find(p => p.COAKey == _SelectedCOAKey);
                if (selectedItem != null)
                {
                    Acc_COA newItem = new Acc_COA();

                    newItem.COALevel = selectedItem.COALevel + 1;
                    newItem.COAName = txtCHead.Text.Trim();
                    newItem.IsActive = chkActive.Checked;
                    newItem.IsSubsidiary = chkIsSubsidiary.Checked;
                    newItem.ParentKey = _SelectedCOAKey;
                    newItem.COAKey = _COA.Count + Int32.MinValue;

                    newItem.IsPostingHead = false;
                    newItem.EntryDate = DateTime.Now;
                    newItem.EntryUserKey = (Int64)1;

                    //((ST.Web.Hr.Initialization.Setup.COA)this.Page).CurrentUserSession.UserCode;

                    _COA.Add(newItem);

                    if (SaveCOA())
                        ((Hr.Web.UI.ACC.COA)this.Page).SuccessMessage = StaticInfo.SavedSuccessfullyMsg;
                }
            }
            catch (Exception ex)
            {
                ((Hr.Web.UI.ACC.COA)this.Page).ErrorMessage = ex.Message;
            }
        }
        #endregion

        #region TreeView events
        protected void tv_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnCreate.Enabled = true;

                TreeNode node = tv.SelectedNode;
                _selnode = node;
                if (node == null) return;

                string value = node.Value;
                if (value.IsNullOrEmpty()) return;

                //setting node info
                Acc_COA selectedNode = _COA.Find(p => p.COAKey == Convert.ToInt64(value));
                if (selectedNode == null) return;

                txtAcLevel.Text = selectedNode.COALevel.ToString();
                txtAhead.Text = selectedNode.COAName;
                chkActive.Checked = selectedNode.IsActive;
                chkIsSubsidiary.Checked = selectedNode.IsSubsidiary;
                txtAcCode.Text = selectedNode.COACode;
                _SelectedCOAKey = selectedNode.COAKey;
                if (selectedNode.IsSubsidiary)
                    btnCreate.Enabled = false;
                validateState(node);
            }
            catch (Exception ex)
            {
                ((Hr.Web.UI.ACC.COA)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }

        }
        #endregion

        #region Private Methods
        private void validateState(TreeNode node)
        {
            if (node.Depth < 1)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCreate.Enabled = false;
            }
            if (node.ChildNodes.Count > 0)
            {
                btnDelete.Enabled = false;
            }
            //if (node.Depth >= 4)
            //{
            //    btnCreate.Enabled = false;
            //}
        }

        private bool SaveCOA()
        {
            try
            {
                COAManager manager = new COAManager();
                var coaList = _COA;
                manager.Save(ref coaList);

                populateTreeView();
                clearForm();
                return true;
            }
            catch (Exception ex)
            {
                ((Hr.Web.UI.ACC.COA)this.Page).ErrorMessage = ex.Message;
            }
            return false;
        }

        private void clearForm()
        {
            _SelectedCOAKey = 0;
            FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
        }
        #endregion
    }
}