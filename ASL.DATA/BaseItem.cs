using System;
using System.ComponentModel;
using System.Data;

namespace ASL.DATA
{
    [Serializable]
    public abstract class BaseItem
    {
        private int vid;
        [Browsable(false)]
        public int VID
        {
            get { return vid; }
            internal set { vid = value; }
        }
        private ItemState state;
        [Browsable(false)]
        public ItemState State
        {
            get { return state; }
            set { state = value; }
        }
        private Object itemInfo;
        [Browsable(false)]
        public Object ItemInfo
        {
            get { return itemInfo; }
            set { itemInfo = value; }
        }
        [Browsable(false)]
        public Boolean IsAdded
        {
            get { return state == ItemState.Added; }
        }
        [Browsable(false)]
        public Boolean IsModified
        {
            get { return state == ItemState.Modified; }
        }
        [Browsable(false)]
        public Boolean IsDeleted
        {
            get { return state == ItemState.Deleted; }
        }
        [Browsable(false)]
        public Boolean IsDetached
        {
            get { return state == ItemState.Detached; }
        }
        [Browsable(false)]
        public Boolean IsUnchanged
        {
            get { return state == ItemState.Unchanged; }
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
        public Object Copy()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// Copy Item with New status
        /// </summary>
        /// <returns></returns>
        public T CopyAsNew<T>()
        {
            Object tNew = MemberwiseClone();
            ((BaseItem)tNew).SetAdded();
            return (T)tNew;
        }
        /// <summary>
        /// Item Information
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return String.Format("Item Name = {0},Item State = {1}", GetType().Name, state.ToString());
        }
        protected internal Boolean PropertyChanged(String oldValue, String newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }
        protected internal Boolean PropertyChanged(Object oldValue, Object newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }
        protected internal Boolean PropertyChanged(Int64 oldValue, Int64 newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }
        protected internal Boolean PropertyChanged(Int32 oldValue, Int32 newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }
        protected internal Boolean PropertyChanged(Int16 oldValue, Int16 newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }
        protected internal Boolean PropertyChanged(Double oldValue, Double newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }
        protected internal Boolean PropertyChanged(Decimal oldValue, Decimal newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }
        protected internal Boolean PropertyChanged(DateTime oldValue, DateTime newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }
        protected internal Boolean PropertyChanged(Byte[] oldValue, Byte[] newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }
        protected internal Boolean PropertyChanged(Boolean oldValue, Boolean newValue)
        {
            if (state.Equals(ItemState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                state = ItemState.Modified;
                return true;
            }
            return false;
        }

        protected internal abstract void SetData(IDataRecord reader);
        public abstract Object[] GetParameterValues();
    }
}
