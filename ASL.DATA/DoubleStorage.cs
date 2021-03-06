﻿using System;

namespace ASL.DATA
{
    public class DoubleStorage : ItemStorage
    {
        public DoubleStorage(ItemBase item, String columnName, FieldCategory fieldType)
        {
            Name = columnName;
            this.item = item;
            this.item.Fields.Add(this);
            FieldType = fieldType;
        }
        private readonly ItemBase item;
        private Boolean original;

        private Double value;
        public Double Value
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
       
        private Double originalValue;
        public Double OriginalValue
        {
            get { return originalValue; }            
        }

        protected internal void PropertyChanged(Double newValue)
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
            set { this.value = (Double)value; }
        }
        public override String GetValue()
        {
            return value.ToString();
        }
    }
}
