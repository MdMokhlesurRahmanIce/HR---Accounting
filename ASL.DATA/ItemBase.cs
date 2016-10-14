using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace ASL.DATA
{
    [Serializable]
    public abstract class ItemBase 
    {
        private List<ItemStorage> fields = new List<ItemStorage>();
        [Browsable(false)]
        public List<ItemStorage> Fields
        {
            get { return fields; }
            set { fields = value; }
        }
        private ItemState state;
        [Browsable(false)]
        public ItemState State
        {
            get { return state; }
            set { state = value;}
        }
        private Object itemInfo;
        [Browsable(false)]
        public Object ItemInfo
        {
            get { return itemInfo; }
            set { itemInfo = value; }
        }
        /// <summary>
        /// Commits all the changes made to this item since the last time Item.AcceptChanges() 
        /// was called.
        /// </summary>        
        public void AcceptChanges()
        {
            foreach (ItemStorage data in fields)
            {
                data.AcceptChanges();
            }    
            state = ItemState.Unchanged;
        }
        /// <summary>
        /// Rejects all changes made to the item since Item.AcceptChanges() 
        /// was last called.
        /// </summary>        
        public void RejectChanges()
        {
            foreach (ItemStorage data in fields)
            {
                data.RejectChanges();
            }
            state = ItemState.Unchanged;
        }
        /// <summary>
        /// Changes the Item.ItemState of a item to Added.
        /// </summary>        
        public void SetAdded()
        {
            state = ItemState.Added;
        }
        /// <summary>
        /// Changes the Item.ItemState of a item to Modified.
        /// </summary>        
        public void SetModified()
        {
            state = ItemState.Modified;
        }
        /// <summary>
        /// Delete the Item.
        /// </summary>        
        public void Delete()
        {
            state = ItemState.Deleted;            
        }
        /// <summary>
        /// Detached the Item.
        /// </summary>        
        public void SetDetached()
        {
            state = ItemState.Detached;
        }
        /// <summary>
        /// Unchanged the Item.
        /// </summary>        
        public void SetUnchanged()
        {
            state = ItemState.Unchanged;
        }
        /// <summary>
        /// Copy Item
        /// </summary>
        /// <returns></returns>
        public object Copy()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// The zero-based index of the column 
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public Object this[int columnIndex]
        {
            get
            {
                return fields[columnIndex].ObjectTypeValue;
            }
            set
            {
                fields[columnIndex].ObjectTypeValue = value;
            }
        }
        /// <summary>
        /// The name of the column
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public Object this[String columnName]
        {
            get
            {
                foreach (ItemStorage itemStorage in fields)
                {
                    if (itemStorage.Name.ToUpper().CompareTo(columnName.ToUpper()).Equals(0))
                    {
                        return itemStorage.ObjectTypeValue;
                    }
                }
                return null;
            }
            set
            {
                foreach (ItemStorage itemStorage in fields)
                {
                    if (itemStorage.Name.ToUpper().CompareTo(columnName.ToUpper()).Equals(0))
                    {
                        itemStorage.ObjectTypeValue = value;
                    }
                }
            }
        }
        public override String ToString()
        {
            return state.ToString();
        }
        public Boolean Contains(String columnName)
        {
            foreach (ItemStorage itemStorage in fields)
            {
                if (itemStorage.Name.ToUpper().CompareTo(columnName.ToUpper()).Equals(0))
                {
                    return true;
                }
            }
            return false;
        }
        protected internal abstract void SetData(IDataRecord reader);
    }
}
