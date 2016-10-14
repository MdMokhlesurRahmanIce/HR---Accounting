using System;

namespace ASL.DATA
{
    public class StringStorage : ItemStorage
    {
        public StringStorage(ItemBase item, String columnName, FieldCategory fieldType)
        {
            Name = columnName;
            this.item = item;
            this.item.Fields.Add(this);
            FieldType = fieldType;
        }
       
        private readonly ItemBase item;
        private Boolean original;

        private String value;
        public String Value
        {
            get { return value; }
            set
            {
                this.value = value;
                if (!original)
                {
                    originalValue = value;
                    original = true;
                }
                else
                    PropertyChanged(value);
            }
        }

       
        private String originalValue;
        public String OriginalValue
        {
            get { return originalValue; }            
        }

        protected internal void PropertyChanged(String newValue)
        {
            if (!originalValue.Equals(newValue))
            {
                if (item.State.Equals(ItemState.Unchanged))
                {
                    item.State = ItemState.Modified;
                }
                Modified = true;
            }
            else
            {
                if (Modified)
                {
                    if (item.Fields.FindAll(column => column.Modified && column.FieldType.Equals(FieldCategory.NormalField)).Count.Equals(1))
                    {
                        item.State = ItemState.Unchanged;
                    }
                    Modified = false;
                }
            }
        }

        protected internal override void AcceptChanges()
        {
            originalValue = value;
        }
        protected internal override void RejectChanges()
        {
            value = originalValue;
        }
        public override Object ObjectTypeValue
        {
            get { return value; }
            set { this.value = value.ToString(); }
        }
        public override String GetValue()
        {
            if (value == null || value == DBNull.Value.ToString())
                return "Null";
            return String.Format("'{0}'", value);
        }
    }
}
