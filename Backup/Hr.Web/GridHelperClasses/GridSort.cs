using System;
namespace Hr.Web.GridHelperClasses
{
    public class GridSort
    {
        public GridSort(String sortExpression, String sortDirection)
        {
            this.sortExpression = sortExpression;
            if (sortDirection != null)
            {
                this.sortDirection = (sortDirection.ToLower() == "asc") ? SortDirection.Asc : SortDirection.Desc;
            }
            else
            {
                this.sortDirection = SortDirection.Asc;
            }
        }

        private SortDirection sortDirection;
        public SortDirection SortDirection
        {
            get
            {
                return this.sortDirection;
            }
            set
            {
                this.sortDirection = value;
            }
        }

        private String sortExpression;
        public String SortExpression
        {
            get
            {
                return this.sortExpression;
            }
            set
            {
                this.sortExpression = value;
            }
        }
    }
}

