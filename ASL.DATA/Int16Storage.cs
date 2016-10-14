using System;

namespace ASL.DATA
{
    public class Int16Storage : ItemStorage
    {
        public Int16Storage(ItemBase item, String columnName, FieldCategory fieldType)
        {
            Name = columnName;
            this.item = item;
            this.item.Fields.Add(this);
            FieldType = fieldType;
        }
        private readonly ItemBase item;
        private Boolean original;

        private Int16 value;
        public Int16 Value
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

        private Int16 originalValue;
        public Int16 OriginalValue
        {
            get { return originalValue; }            
        }

        protected internal void PropertyChanged(Int16 newValue)
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
            set { this.value = (Int16)value; }
        }
        public override String GetValue()
        {
            return value.ToString();
        }
    }
}
