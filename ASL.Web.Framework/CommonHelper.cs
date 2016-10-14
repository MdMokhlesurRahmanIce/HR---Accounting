using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ASL.DATA;
using System.Web;
using ReportSuite.DAO;
//using System.Text;

namespace ASL.Web.Framework
{
    public class CommonHelper
    {
        public IList<ListItem> PopulteDropdownList(dynamic list)
        {
            //var ddlList = new List<ListItem>();
            //foreach (var item in list)
            //{
            //    var li = new ListItem()
            //{
            //    Text = "",
            //    Value = ""
            //};
            //    ddlList.Add(li);
            //}
            //return ddlList;

            return null;
        }
        public static String CreateSearchString()
        {
            CustomList<FilterSets> SearchList = (CustomList<FilterSets>)HttpContext.Current.Session["ucEmpSearch_FilterSetsList"];
            StringBuilder sb = new StringBuilder();
            foreach (FilterSets fS in SearchList)
            {
                switch (fS.ColumnName)
                {
                    case "Company":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@OrgKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append(",");
                        break;
                    case "Branch":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@BranchKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Department":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@DepartmentKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Grade":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@GradeKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Designation":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@DesigKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Unit":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@UnitKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Division":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@DivisionKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Sub Division":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@SubDivisionKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Staff Category":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@StaffCategoryKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Section":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@SectionKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Sub Section":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@SubSectionKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Job Location":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@JobLocationKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    case "Piece Rate":
                        if (fS.ColumnValue == "") break;
                        sb.Append("@PieceRateKey");
                        sb.Append("='");
                        sb.Append(fS.ColumnValue);
                        sb.Append("',");
                        break;
                    default: break;
                }
            }
            return sb.ToString();
        }
    }
}
