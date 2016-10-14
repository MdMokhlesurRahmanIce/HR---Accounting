using System;
using System.Data;
using System.Web.Script.Serialization;

namespace Hr.Web.GridHelperClasses
{
 
    internal class MultipleSearching
    {
        private String _searchFilters;

        public MultipleSearching(String searchFilters)
        {            
            this._searchFilters = searchFilters;
        }

        private String ConstructFilterExpression(DataView view, GridSearch args)
        {
            String format = ((view.ToTable().Columns[args.SearchColumn].DataType == typeof(String)) || (view.ToTable().Columns[args.SearchColumn].DataType == typeof(DateTime))) ? "[{0}] {1} '{2}'" : "[{0}] {1} {2}";
            String text2 = "[{0}] {1} ('{2}')";
            String text3 = "[{0}] LIKE '{1}'";
            String text4 = "[{0}] NOT LIKE '{1}'";
            switch (args.SearchOperation)
            {
                case SearchOperation.IsEqualTo:
                    return String.Format(format, args.SearchColumn, "=", args.SearchString);

                case SearchOperation.IsNotEqualTo:
                    return String.Format(format, args.SearchColumn, "<>", args.SearchString);

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

        public string PerformSearch()
        {
            JsonMultipleSearch search = new JavaScriptSerializer().Deserialize<JsonMultipleSearch>(this._searchFilters);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (MultipleSearchRule rule in search.Rules)
            {
                String clause = string.Format("[{0}] LIKE '%{1}%'", rule.field, rule.data);
                sb.Append(clause);
                sb.Append(" AND ");
            }
            if (sb.ToString().EndsWith(" AND "))
            {
                return sb.ToString().Substring(0, sb.Length - 5);
            }
            return sb.ToString();
        }

        public string PerformSearch(bool isSP)
        {
            JsonMultipleSearch search = new JavaScriptSerializer().Deserialize<JsonMultipleSearch>(this._searchFilters);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (MultipleSearchRule rule in search.Rules)
            {
                String clause = string.Format("@{0}='{1}'", rule.field, rule.data);
                sb.Append(clause);
                sb.Append(",");
            }
            if (sb.ToString().EndsWith(","))
            {
                return sb.ToString().Substring(0, sb.Length - 1);
            }
            return sb.ToString();
        }

        public void PerformSearch(DataView view)
        {
            
            JsonMultipleSearch search = new JavaScriptSerializer().Deserialize<JsonMultipleSearch>(this._searchFilters);
            String text = "";
            foreach (MultipleSearchRule rule in search.Rules)
            {
                GridSearch args2 = new GridSearch();
                args2.SearchColumn = rule.field;
                args2.SearchString = rule.data;
                args2.SearchOperation = this.GetSearchOperationFromString(rule.op);
                GridSearch e = args2;

                String text2 = (text.Length > 0) ? (" " + search.GroupOp + " ") : "";
                text = text + text2 + this.ConstructFilterExpression(view, e);

                view.RowFilter = text;

            }
        }
    }
}

