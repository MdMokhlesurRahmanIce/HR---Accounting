using System;
using System.Data;
namespace Hr.Web.GridHelperClasses
{
    internal class Searching
    {
        private String _searchColunm;
        private String _searchOperation;
        private String _searchString;

        public Searching(String searchColumn, String searchString, String searchOperation)
        {            
            this._searchColunm = searchColumn;
            this._searchString = searchString;
            this._searchOperation = searchOperation;
        }

        private String ConstructFilterExpression(DataView view, GridSearch args)
        {
            String format = ((view.ToTable().Columns[args.SearchColumn].DataType == typeof(String)) || (view.ToTable().Columns[args.SearchColumn].DataType == typeof(DateTime))) ? "[{0}] {1} '{2}'" : "[{0}] {1} {2}";
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

        public void PerformSearch(DataView view, String search)
        {
            if (!String.IsNullOrEmpty(search) && Convert.ToBoolean(search))
            {
                GridSearch args2 = new GridSearch();
                args2.SearchColumn = this._searchColunm;
                args2.SearchString = this._searchString;
                args2.SearchOperation = this.GetSearchOperationFromString(this._searchOperation);
                GridSearch e = args2;
                try
                {
                    view.RowFilter = this.ConstructFilterExpression(view, e);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}

