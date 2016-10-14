using System;
using System.Data;
namespace Hr.Web.GridHelperClasses
{
    internal class ToolBarSearching
    {
       
        private String ConstructFilterExpression(DataView view, GridSearch args)
        {
            bool flag = false;
            if (view != null)
            {
                flag = (view.ToTable().Columns[args.SearchColumn].DataType == typeof(String)) || (view.ToTable().Columns[args.SearchColumn].DataType == typeof(DateTime));
            }
            else
            {
                //JQGridColumn column = this._grid.Columns.FromDataField(args.SearchColumn);
                //if (column.SearchDataType == SearchDataType.NotSet)
                //{
                //    throw new ArgumentException("SearchDataType for the respective column must be set in order to get custom search String (where clause)");
                //}
                //flag = (column.SearchDataType == SearchDataType.String) || (column.SearchDataType == SearchDataType.Date);
            }
            String format = flag ? "[{0}] {1} '{2}'" : "[{0}] {1} {2}";
            String text2 = "[{0}] {1} ({2})";
            String text3 = "[{0}] LIKE '{1}'";
            String text4 = "[{0}] NOT LIKE '{1}'";
            switch (args.SearchOperation)
            {
                case SearchOperation.IsEqualTo:
                    return String.Format(format, args.SearchColumn, "=", args.SearchString);

                case SearchOperation.IsLessThan:
                    return String.Format(format, args.SearchColumn, "<", args.SearchString);

                case SearchOperation.IsLessOrEqualTo:
                    return String.Format(format, args.SearchColumn, "<=", args.SearchString);

                case SearchOperation.IsGreaterThan:
                    return String.Format(format, args.SearchColumn, ">", args.SearchString);

                case SearchOperation.IsGreaterOrEqualTo:
                    return String.Format(format, args.SearchColumn, ">=", args.SearchString);

                case SearchOperation.IsIn:
                    return String.Format(text2, args.SearchColumn, "in", args.SearchString);

                case SearchOperation.IsNotIn:
                    return String.Format(text2, args.SearchColumn, "not in", args.SearchString);

                case SearchOperation.BeginsWith:
                    return String.Format(text3, args.SearchColumn, args.SearchString + "%");

                case SearchOperation.DoesNotBeginWith:
                    return String.Format(text4, args.SearchColumn, args.SearchString + "%");

                case SearchOperation.EndsWith:
                    return String.Format(text3, args.SearchColumn, "%" + args.SearchString);

                case SearchOperation.DoesNotEndWith:
                    return String.Format(text4, args.SearchColumn, "%" + args.SearchString);

                case SearchOperation.Contains:
                    return String.Format(text3, args.SearchColumn, "%" + args.SearchString + "%");

                case SearchOperation.DoesNotContain:
                    return String.Format(text4, args.SearchColumn, "%" + args.SearchString + "%");
            }
            throw new Exception("Invalid search operation.");
        }

        private String ConstructLinqFilterExpression(DataView view, GridSearch args)
        {
            bool flag = false;
            if (view != null)
            {
                flag = view.ToTable().Columns[args.SearchColumn].DataType == typeof(String);
            }
            else
            {
                //JQGridColumn column = this._grid.Columns.FromDataField(args.SearchColumn);
                //if (column.SearchDataType == SearchDataType.NotSet)
                //{
                //    throw new ArgumentException("SearchDataType for the respective column must be set in order to get custom search String (where clause)");
                //}
                //flag = column.SearchDataType == SearchDataType.String;
            }
            String format = flag ? "{0} {1} \"{2}\"" : "{0} {1} {2}";
            switch (args.SearchOperation)
            {
                case SearchOperation.IsEqualTo:
                    return String.Format(format, args.SearchColumn, "=", args.SearchString);

                case SearchOperation.IsLessThan:
                    return String.Format(format, args.SearchColumn, "<", args.SearchString);

                case SearchOperation.IsLessOrEqualTo:
                    return String.Format(format, args.SearchColumn, "<=", args.SearchString);

                case SearchOperation.IsGreaterThan:
                    return String.Format(format, args.SearchColumn, ">", args.SearchString);

                case SearchOperation.IsGreaterOrEqualTo:
                    return String.Format(format, args.SearchColumn, ">=", args.SearchString);

                case SearchOperation.BeginsWith:
                    return String.Format("{0}.BeginsWith(\"{1}\")", args.SearchColumn, args.SearchString);

                case SearchOperation.DoesNotBeginWith:
                    return String.Format("!{0}.BeginsWith(\"{1}\")", args.SearchColumn, args.SearchString);

                case SearchOperation.EndsWith:
                    return String.Format("{0}.EndsWith(\"{1}\")", args.SearchColumn, args.SearchString);

                case SearchOperation.DoesNotEndWith:
                    return String.Format("!{0}.EndsWith(\"{1}\")", args.SearchColumn, args.SearchString);

                case SearchOperation.Contains:
                    return String.Format("{0}.Contains(\"{1}\")", args.SearchColumn, args.SearchString);

                case SearchOperation.DoesNotContain:
                    return String.Format("!{0}.Contains(\"{1}\")", args.SearchColumn, args.SearchString);
            }
            throw new Exception("Invalid search operation.");
        }

        private SearchOperation GetSearchOperationFromString(String searchOperation)
        {
            switch (searchOperation)
            {
                case "eq":
                    return SearchOperation.IsEqualTo;

                case "ne":
                    return SearchOperation.IsNotEqualTo;

                case "lt":
                    return SearchOperation.IsLessThan;

                case "le":
                    return SearchOperation.IsLessOrEqualTo;

                case "gt":
                    return SearchOperation.IsGreaterThan;

                case "ge":
                    return SearchOperation.IsGreaterOrEqualTo;

                case "in":
                    return SearchOperation.IsIn;

                case "ni":
                    return SearchOperation.IsNotIn;

                case "bw":
                    return SearchOperation.BeginsWith;

                case "bn":
                    return SearchOperation.DoesNotEndWith;

                case "ew":
                    return SearchOperation.EndsWith;

                case "en":
                    return SearchOperation.DoesNotEndWith;

                case "cn":
                    return SearchOperation.Contains;

                case "nc":
                    return SearchOperation.DoesNotContain;
            }
            throw new Exception("Search operation not known: " + searchOperation);
        }

        public String GetWhereClause(DataView view, bool isLinq)
        {
            //String text = isLinq ? " && " : " AND ";
            //new Hashtable();
            //String text2 = String.Empty;
            //foreach (JQGridColumn column in this._grid.Columns)
            //{
            //    String text3 = this._grid.Page.Request[column.DataField];
            //    if (!String.IsNullOrEmpty(text3))
            //    {
            //        JQGridSearchEventArgs args2 = new JQGridSearchEventArgs();
            //        args2.SearchColumn = column.DataField;
            //        args2.SearchString = text3;
            //        args2.SearchOperation = column.SearchToolBarOperation;
            //        JQGridSearchEventArgs e = args2;

            //        String text4 = (text2.Length > 0) ? text : "";
            //        String text5 = isLinq ? this.ConstructLinqFilterExpression(view, e) : this.ConstructFilterExpression(view, e);
            //        text2 = text2 + text4 + text5;

            //    }
            //}
            //return text2;
            return String.Empty;
        }

        public void PerformSearch(DataView view, bool isLinq)
        {
            try
            {
                view.RowFilter = this.GetWhereClause(view, isLinq);
            }
            catch (Exception)
            {
            }
        }
    }
}

