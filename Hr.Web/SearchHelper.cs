using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ASL.DATA;

namespace ST
{
    [Serializable]
    public class SearchHelper
    {
        private String searchFor;
        public String SearchFor
        {
            get { return searchFor; }
            set { searchFor = value; }
        }
        private CustomList<BaseItem> searchItems;
        public CustomList<BaseItem> SearchItems
        {
            get { return searchItems; }
            set { searchItems = value; }
        }
        private CustomList<BaseItem> viewSource;
        public CustomList<BaseItem> ViewSource
        {
            get { return viewSource; }
            set { viewSource = value; }
        }
        private BaseItem itemReturn;
        public BaseItem ItemReturn
        {
            get { return itemReturn; }
            set { itemReturn = value; }
        }
        private CustomList<BaseItem> itemReturns;
        public CustomList<BaseItem> ItemReturns
        {
            get { return itemReturns; }
            set { itemReturns = value; }
        }

        private Type searchType;
        public Type SearchType
        {
            get { return searchType; }
            set { searchType = value; }
        }

        private Boolean blnMultipleSelect;
        public Boolean MultipleSelect
        {
            get { return blnMultipleSelect; }
            set { blnMultipleSelect = value; }
        }
        private String caption = "Find Screen";
        public String Caption
        {
            get { return caption; }
            set { caption = value; }
        }
        private String selectedValue = String.Empty;
        public String SelectedValue
        {
            get { return selectedValue; }
            set { selectedValue = value; }
        }        
        private String fstColumn = String.Empty;
        public String FstColumn
        {
            get { return fstColumn; }
            set { fstColumn = value; }
        }        
        private String actionOn;
        public String ActionOn
        {
            get { return actionOn; }
            set { actionOn = value; }
        }
        private String fieldType;
        public String FieldType
        {
            get { return fieldType; }
            set { fieldType = value; }
        }
        private String hideColumns = String.Empty;
        public String HideColumns
        {
            get { return hideColumns; }
            set { hideColumns = value; }
        }
        private String selectedColumn = String.Empty;
        public String SelectedColumn
        {
            get { return selectedColumn; }
            set { selectedColumn = value; }
        }


        public SearchHelper(Object searchItems, Type searchType, String searchFor)
        {
            blnMultipleSelect = false;
            this.searchItems = ((IList)searchItems).ToCustomList<BaseItem>();
            this.searchType = searchType;
            this.searchFor = searchFor;
        }
        public SearchHelper(Object searchItems, Type searchType, String searchFor, String eCaption)
            : this(searchItems, searchType, searchFor)
        {
            caption = eCaption;
        }
        public SearchHelper(Object searchItems, Type searchType, String searchFor, Boolean multipleSelect)
            : this(searchItems, searchType, searchFor)
        {
            blnMultipleSelect = multipleSelect;
            hideColumns = String.Empty;
        }
        public SearchHelper(Object searchItems, Type searchType, String searchFor, Boolean multipleSelect, String hideColumns)
            : this(searchItems, searchType, searchFor)
        {
            blnMultipleSelect = multipleSelect;
            this.hideColumns = hideColumns;            
        }

        public SearchHelper(Object searchItems, Type searchType, String searchFor, Boolean multipleSelect, String hideColumns, String selectedColumn)
            : this(searchItems, searchType, searchFor)
        {
            blnMultipleSelect = multipleSelect;
            this.hideColumns = hideColumns;
            this.selectedColumn = selectedColumn;
        }
        public SearchHelper(Object searchItems, Type searchType, String searchFor, String eCaption, Boolean multipleSelect, String hideColumns)
            : this(searchItems, searchType, searchFor)
        {
            caption = eCaption;
            blnMultipleSelect = multipleSelect;
            this.hideColumns = hideColumns;

        }
        public SearchHelper(Object searchItems, Type searchType, String searchFor, String eCaption, Boolean multipleSelect, String hideColumns, String selectedColumn)
            : this(searchItems, searchType, searchFor)
        {
            caption = eCaption;
            blnMultipleSelect = multipleSelect;
            this.hideColumns = hideColumns;
            this.selectedColumn = selectedColumn;

        }
        public SearchHelper(Object searchItems, Type searchType, String searchFor, String eCaption, Boolean multipleSelect, String hideColumns, String selectedColumn, String findBySelectedValue)
            : this(searchItems, searchType, searchFor)
        {
            caption = eCaption;
            blnMultipleSelect = multipleSelect;
            this.hideColumns = hideColumns;
            this.selectedColumn = selectedColumn;
            selectedValue = findBySelectedValue;
        }
        public SearchHelper(Object searchItems, Type searchType, String searchFor, String eCaption, Boolean multipleSelect, String hideColumns, String selectedColumn, String findBySelectedValue, String firstColumn)
            : this(searchItems, searchType, searchFor)
        {
            caption = eCaption;
            blnMultipleSelect = multipleSelect;
            this.hideColumns = hideColumns;
            this.selectedColumn = selectedColumn;
            selectedValue = findBySelectedValue;
            fstColumn = firstColumn;

        }
    }    
}
