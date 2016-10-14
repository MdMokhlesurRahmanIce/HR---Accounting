using System;

namespace ASL.DATA
{
    public class BooleanStorage : ItemStorage
    {
        public BooleanStorage(ItemBase item, String columnName, FieldCategory fieldType)
        {
            Name = columnName;
            this.item = item;
            this.item.Fields.Add(this);
            FieldType = fieldType;
        }
       
        private readonly ItemBase item;
        private Boolean original;

        private Boolean value;
        public Boolean Value
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

        private Boolean originalValue;
        public Boolean OriginalValue
        {
            get { return originalValue; }            
        }

        protected internal void PropertyChanged(Boolean newValue)
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
            set { this.value = (Boolean)value; }
        }
        public override String GetValue()
        {
            return String.Format("'{0}'", value);            
        }
    }
}
