using System;

namespace Hr.Web.GridHelperClasses
{
    public class GridSearch
    {        
        
        public GridSearch()
        { }

        public GridSearch(String searchColumn, String searchString, SearchOperation searchOperation) : this()
        {
            this.searchColumn = searchColumn;
            this.searchString = searchString;
            this.searchOperation = searchOperation;
        }

        private String searchColumn;
        public String SearchColumn
        {
            get
            {
                return this.searchColumn;
            }
            set
            {
                this.searchColumn = value;
            }
        }

        private SearchOperation searchOperation;
        public SearchOperation SearchOperation
        {
            get
            {
                return this.searchOperation;
            }
            set
            {
                this.searchOperation = value;
            }
        }

        private String searchString;
        public String SearchString
        {
            get
            {
                return this.searchString;
            }
            set
            {
                this.searchString = value;
            }
        }
    }
}

