using System;

namespace ASL.DATA
{
    public class DateTimeStorage : ItemStorage
    {
        public DateTimeStorage(ItemBase item, String columnName, FieldCategory fieldType)
            : this(item, columnName, fieldType, false)
        {
        }

        public DateTimeStorage(ItemBase item, String columnName, FieldCategory fieldType, Boolean isDateFormat)
        {
            Name = columnName;
            this.item = item;
            this.item.Fields.Add(this);
            FieldType = fieldType;
            this.isDateFormat = isDateFormat;
        }

        private const String DateFormat = "yyyy-MMM-dd";
        //private const string TimeFormat = "hh:mm:ss tt";
        private const String DateTimeFormat = "yyyy-MM-dd hh:mm:ss.mmm";
        private readonly ItemBase item;
        private Boolean original;
        private readonly Boolean isDateFormat;

        private DateTime value;
        public DateTime Value
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

        private DateTime originalValue;
        public DateTime OriginalValue
        {
            get { return originalValue; }            
        }

        protected internal void PropertyChanged(DateTime newValue)
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
            set { this.value = DateTime.Parse(value.ToString());}
        }
        public override String GetValue()
        {
            if (value == DateTime.MinValue)
                return "Null";
            return isDateFormat ? String.Format("'{0}'", value.ToString(DateFormat)) : String.Format("'{0}'", value.ToString(DateTimeFormat));
        }
    }
}
