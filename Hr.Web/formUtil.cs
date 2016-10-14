using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Web.Framework;


namespace GM
{
    public class FormUtil
    {
        public FormUtil()
        {
        }       

        public static void ClearForm(Control container, FormClearOptions option, bool check_nc)
        {
            try
            {
                switch (option)
                {
                    case FormClearOptions.ClearAll:

                        if (check_nc)
                        {
                            if (container.ID != null)
                                if (container.ID.EndsWith("_nc"))
                                    break;
                        }

                        if (container.GetType().Equals(typeof(TextBox)))
                        {
                            TextBox txtBox = ((TextBox)container);
                            txtBox.Text = string.Empty;
                        }
                        else if (container.GetType().Equals(typeof(DropDownList)))
                        {
                            DropDownList ddl = ((DropDownList)container);
                            ddl.SelectedValue = string.Empty;
                        }
                        else if (container.GetType().Equals(typeof(CheckBox)))
                        {
                            CheckBox chk = ((CheckBox)container);
                            chk.Checked = false;
                        }
                        else if (container.GetType().Equals(typeof(RadioButtonList)))
                        {
                            RadioButtonList rbl = ((RadioButtonList)container);
                            rbl.SelectedIndex = -1;
                        }
                        else if (container.GetType().Equals(typeof(RadioButton)))
                        {
                            RadioButton rb = ((RadioButton)container);
                            rb.Checked = false;
                        }
                        else if (container.HasControls())
                        {
                            foreach (Control ctrl in container.Controls)
                                ClearForm(ctrl, option, check_nc);
                        }
                        break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ClearForm(Control container, List<Type> controlTypes)
        {
            if (container.GetType().Equals(typeof(Label)))
            {
                Label lbl = ((Label)container);
            }

            else if (container.HasControls())
            {
                foreach (Control ctrl in container.Controls)
                    ClearForm(ctrl, controlTypes);
            }
        }
    }
}
