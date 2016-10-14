using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.DATA;

namespace ST
{
    public partial class Search : Page
    {
        private List<PropertyDescriptor> ObjectProperties
        {
            get
            {
                if (Session["Properties"] == null)
                    return new List<PropertyDescriptor>();
                else
                    return (List<PropertyDescriptor>)Session["Properties"];
            }
            set
            {
                Session["Properties"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            
            var helper = (SearchHelper)Session["SearchHelper"];
            Title = helper.Caption;

            ObjectProperties = GetPropertyDescriptor(helper);

            InitScreen(helper);
                        
        }

        protected void grdFind_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                var helper = (SearchHelper)Session["SearchHelper"];
                if (helper.ViewSource.Count == 0) return;


                var properties = ObjectProperties;

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    for (int i = 1; i < e.Row.Cells.Count; i++)
                    {
                        e.Row.Cells[i].Visible = properties[i-1].IsBrowsable;
                        e.Row.Cells[i].Text = properties[i-1].DisplayName;

                        if (helper.HideColumns.Contains(properties[i - 1].Name))
                            e.Row.Cells[i].Visible = false;
                    }                    
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    for (int i = 1; i < e.Row.Cells.Count; i++)
                    {
                        e.Row.Cells[i].Visible = properties[i-1].IsBrowsable;
                        if (helper.HideColumns.Contains(properties[i - 1].Name))
                            e.Row.Cells[i].Visible = false;
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdFind_SelectedIndexChanged(Object sender, EventArgs e)
        {
            try
            {
                var helper = (SearchHelper)Session["SearchHelper"];
                helper.ItemReturn = helper.ViewSource[grdFind.SelectedRow.DataItemIndex];

                if (helper.MultipleSelect)
                {
                    Object check = helper.ItemReturn.GetType().GetProperty("Check").GetValue(helper.ItemReturn, null);
                    helper.ItemReturn.GetType().GetProperty("Check").SetValue(helper.ItemReturn, !(Boolean)check, null);
                    LoadGrid(helper);
                }
                else
                {
                    String script = "parent.$('iframe').dialog('close');parent.doPostBack('" + helper.SearchFor + "');";
                    if (!ClientScript.IsStartupScriptRegistered("clientScript"))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "clientScript", script, true);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdFind_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdFind.PageIndex = e.NewPageIndex;
                var helper = (SearchHelper)Session["SearchHelper"];
                LoadGrid(helper);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void LoadGrid(SearchHelper helper)
        {
            try
            {
                grdFind.DataSource = helper.ViewSource.Cast(helper.SearchType);
                grdFind.DataBind();
                lblTotalRow.Text = "Total Row(s) : " + helper.SearchItems.Count.ToString();
                lblFilteredRow.Text = "Filtered Row(s) : " + helper.ViewSource.Count.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
        private void InitScreen(SearchHelper helper)
        {
            try
            {

                chkSelectAll.Visible = helper.MultipleSelect;
                btnSelect.Visible = helper.MultipleSelect;               
                //
                helper.ViewSource = helper.SearchItems;
                LoadGrid(helper);               


                var findBy = new List<FindDataBy>();
                var demandOn = new List<DemandOn>();
                //
                demandOn.Add(new DemandOn { Demand = "Starts With", ActionOn = "System.String" });
                demandOn.Add(new DemandOn { Demand = "Contains", ActionOn = "System.String" });
                demandOn.Add(new DemandOn { Demand = "<", ActionOn = "System.NumericOrDateTime" });
                demandOn.Add(new DemandOn { Demand = "<=", ActionOn = "System.NumericOrDateTime" });
                demandOn.Add(new DemandOn { Demand = ">", ActionOn = "System.NumericOrDateTime" });
                demandOn.Add(new DemandOn { Demand = ">=", ActionOn = "System.NumericOrDateTime" });
                demandOn.Add(new DemandOn { Demand = "=", ActionOn = "System.NumericOrDateTime" });
                demandOn.Add(new DemandOn { Demand = "Between", ActionOn = "System.NumericOrDateTime" });
                demandOn.Add(new DemandOn { Demand = "=", ActionOn = "System.Boolean" });

                //
                cboDemands.DataSource = demandOn;
                cboDemands.DataTextField = "Demand";
                cboDemands.DataValueField = "Demand";
                cboDemands.DataBind();
                ViewState["Demand"] = demandOn;

               
                if (helper.ViewSource.Count == 0) return;

                var properties = ObjectProperties;

                foreach (PropertyDescriptor property in properties)
                {
                    #region Data Organizing  For FindBy Combo Box

                    if (property.IsBrowsable)
                    {
                        if (property.PropertyType.FullName == "System.String")
                            findBy.Add(new FindDataBy { FindBy = property.Name, FieldType = property.PropertyType.FullName });                        
                    }

                    #endregion
                }
                //}
                cboFindBy.DataSource = findBy;
                cboFindBy.DataTextField = "FindBy";
                cboFindBy.DataValueField = "FindBy";
                cboFindBy.DataBind();
                ViewState["FindBy"] = findBy;
                if (findBy.Count > 0)
                {
                    if (helper.SelectedValue.Trim().Length > 0)
                    {
                        //foreach (UltraGridRow grdRow in cboFindBy.Rows)
                        //{
                        //    if (grdRow.Cells[0].Value.ToString().Trim().ToUpper() != selectedValue.Trim().ToUpper())
                        //        continue;
                        //    grdRow.Selected = true;
                        //    break;
                        //}
                    }
                    else
                    {
                        cboFindBy.Text = findBy[0].FindBy;
                    }

                    FindFieldType(findBy[0].FieldType,helper);
                    if (helper.FieldType == "System.String")
                    {
                        cboDemands.Text = "Contains";
                    }
                    else if (helper.FieldType != "")
                    {
                        cboDemands.Text = "=";
                    }
                }
                cboFindBy_SelectedIndexChanged(null, null);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private List<PropertyDescriptor> GetPropertyDescriptor(SearchHelper helper)
        {
            List<PropertyDescriptor> returnProp = new List<PropertyDescriptor>();

            var properties = TypeDescriptor.GetProperties(helper.SearchType);
            foreach (PropertyDescriptor propDes in properties)
            {
                PropertyDescriptor property = propDes;
                if (helper.HideColumns.Contains(propDes.Name))
                {                    
                    if (property != null)
                    {
                        System.ComponentModel.AttributeCollection runtimeAttributes = property.Attributes;
                        // make a copy of the original attributes
                        // but make room for one extra attribute
                        Attribute[] attrs = new Attribute[runtimeAttributes.Count + 1];
                        runtimeAttributes.CopyTo(attrs, 0);
                        attrs[runtimeAttributes.Count] = new BrowsableAttribute(false);

                        // makes this Property hidden in PropertyGrid
                        property = TypeDescriptor.CreateProperty(this.GetType(), property.Name, property.PropertyType, attrs);                        
                    }
                }

                returnProp.Add(property);
            }            
            return returnProp;
        }

        private void FindFieldType(String type, SearchHelper helper)
        {
            if (type == "System.String"
                || type == SqlDbType.Text.ToString()
                || type == SqlDbType.VarChar.ToString()
                || type == SqlDbType.Char.ToString()
                )
            {
                helper.FieldType = "System.String";
            }
            else if (
                type == "System.DateTime")
            {
                helper.FieldType = "System.DateTime";
            }
            else if (
                type == "System.Int16"
                || type == "System.Int32"
                || type == "System.Int64"
                || type == "System.UInt16"
                || type == "System.UInt32"
                || type == "System.UInt64"
                || type == "System.Single"
                || type == "System.Double"
                || type == "System.Decimal"
                || type == SqlDbType.Int.ToString()
                || type == SqlDbType.BigInt.ToString()
                || type == SqlDbType.Float.ToString()
                || type == SqlDbType.SmallInt.ToString()
                || type == SqlDbType.TinyInt.ToString()
                )
            {
                helper.FieldType = "System.Numeric";
            }
            else if (
                type == "System.Boolean")
            {
                helper.FieldType = "System.Boolean";
            }
            else
            {
                helper.FieldType = "";
            }
        }
        protected void cboFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboFindBy.SelectedItem == null)
                    return;
                var helper = (SearchHelper)Session["SearchHelper"];
                //
                var findBy = (List<FindDataBy>)ViewState["FindBy"];
                var dataBy = findBy.Find(p => p.FindBy == cboFindBy.SelectedItem.Value);
                if (dataBy == null) return;
                FindFieldType(dataBy.FieldType, helper);
                switch (helper.FieldType)
                {
                    case "System.String":
                        helper.ActionOn = "System.String";
                        break;
                    case "System.Boolean":
                        helper.ActionOn = "System.Boolean";
                        break;
                    default:
                        if (helper.FieldType != "")
                        {
                            helper.ActionOn = "System.NumericOrDateTime";
                        }
                        break;
                }
                //
                
                var demand = (List<DemandOn>)ViewState["Demand"];
                cboDemands.DataSource = demand.Where(p => p.ActionOn == helper.ActionOn).ToList();
                cboDemands.DataBind();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        private void StartSearch()
        {
            if (cboFindBy.SelectedItem == null || cboDemands.SelectedItem == null)
            {
                return;
            }
            //	
            var helper = (SearchHelper)Session["SearchHelper"];
            if (helper.ActionOn == "System.String")
            {
                var helper1 = helper.SearchItems.FindAll(item => item.GetType().GetProperty(cboFindBy.SelectedValue).GetValue(item, null) != null);
                //
                if (cboDemands.SelectedValue.ToUpper() == "Contains".ToUpper())
                    helper.ViewSource = helper1.FindAll(item => item.GetType().GetProperty(cboFindBy.SelectedValue).GetValue(item, null).ToString().ToLower().Contains(txtSearchText.Text.Trim().ToLower()));
                //helper.ViewSource = helper.SearchItems.FindAll(item => item.GetType().GetProperty(cboFindBy.SelectedValue).GetValue(item, null).ToString().ToLower().Contains(txtSearchText.Text.Trim().ToLower()));
                else if (cboDemands.SelectedValue.ToUpper() == "Starts With".ToUpper())
                    helper.ViewSource = helper1.FindAll(item => item.GetType().GetProperty(cboFindBy.SelectedValue).GetValue(item, null).ToString().ToLower().StartsWith(txtSearchText.Text.Trim().ToLower()));
                //helper.ViewSource = helper.SearchItems.FindAll(item => item.GetType().GetProperty(cboFindBy.SelectedValue).GetValue(item, null).ToString().ToLower().StartsWith(txtSearchText.Text.Trim().ToLower()));

                LoadGrid(helper);
            }            
        }

        protected void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StartSearch();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckedAndUncheckedAll(chkSelectAll.Checked);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void CheckedAndUncheckedAll(Boolean isChecked)
        {
            var helper = (SearchHelper)Session["SearchHelper"];
            foreach (BaseItem item in helper.ViewSource)
            {
                item.GetType().GetProperty("Check").SetValue(item, isChecked, null);
            }
            LoadGrid(helper);
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            var helper = (SearchHelper)Session["SearchHelper"];
            helper.ItemReturns = helper.ViewSource.FindAll(p => p.GetType().GetProperty("Check").GetValue(p, null).ToString().ToLower() == "true");
            //helper.ItemReturns = selectedItems.Cast(helper.SearchType);            

            String script = "parent.$('iframe').dialog('close');parent.doPostBack('" + helper.SearchFor + "');";
            if (!ClientScript.IsStartupScriptRegistered("clientScript"))
            {
                ClientScript.RegisterStartupScript(GetType(), "clientScript", script, true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var helper = (SearchHelper)Session["SearchHelper"];
            helper.ItemReturn = null;
            helper.ItemReturns = null;

            string strscript = "parent.$('iframe').dialog('close');";
            if (!ClientScript.IsStartupScriptRegistered("clientScript"))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strscript,true);
            }
        }        
    }

    [Serializable]
    internal class DemandOn
    {
        public string Demand { get; set; }
        public string ActionOn { get; set; }
    }
    [Serializable]
    internal class FindDataBy
    {
        public String FindBy { get; set; }

        public String FieldType { get; set; }
    }
}
