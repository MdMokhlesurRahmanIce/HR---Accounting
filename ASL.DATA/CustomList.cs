
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ASL.DATA
{
    // This is the "list" data structure's implementation in C#, based on variable-sized array
    // of given type (passed as T class parameter).

    //Methods like Add, Remove, RemoveAt, THIS accessor etc. fire 
    //appropriate events before doing anything (BeforeAdd, BeforeRemove) (with
    //possibility to cancel that, and after (OnAdd, OnRemove...). All of them also call 
    //BeforeAction and OnAction.

    /// <summary>
    /// Represents a list which can contain items of specified type. All commmon methods
    /// fire events associated with them. Also all common methods fire BeforeAction
    /// and OnAction events, if handled. The "Before..." events give possibility
    /// to break called method. Also events for get and set accesors are provided.
    /// </summary>
    /// <typeparam name="T">Type of items.</typeparam>    
    [DebuggerDisplay("Count = {Count}")]
    [Serializable()]
    public class CustomList<T> : IList<T>, System.Collections.IList
    {

        #region Delegates & events delecrations and ActionEventArgs class

        public delegate void OnSetEventHandler(CustomList<T> sender, T oldValue, T newValue);
        public delegate void BeforeSetEventHandler(CustomList<T> sender, ref T oldValue, ref T newValue, ref bool cancel);
        public delegate void OnClearEventHandler(CustomList<T> sender);
        public delegate void BeforeClearEventHandler(CustomList<T> sender, ref bool cancel);
        public delegate void EventyListAfterEventHandler(CustomList<T> sender, T item);
        public delegate void EventyListBeforeEventHandler(CustomList<T> sender, ref T item, ref bool cancel);
        public delegate void OnRemoveAtEventHandler(CustomList<T> sender, int index);
        public delegate void BeforeRemoveAtEventHandler(CustomList<T> sender, ref int index, ref bool cancel);
        public delegate void OnAddRangeEventHandler(CustomList<T> sender, IEnumerable<T> collection);
        public delegate void BeforeAddRangeEventHandler(CustomList<T> sender, IEnumerable<T> collection, ref bool cancel);
        public delegate void OnRemoveRangeEventHandler(CustomList<T> sender, int start, int count);
        public delegate void BeforeRemoveRangeEventHandler(CustomList<T> sender, ref int start, ref int count, ref bool cancel);
        public delegate void OnActionEventHandler(CustomList<T> sender, ActionEventArgs e);
        public delegate void BeforeActionEventHandler(CustomList<T> sender, ActionEventArgs e, ref bool cancel);

        public event EventyListAfterEventHandler OnAdd, OnGet, OnInsert;
        /// <summary>Warning: If Remove method is called, both Remove and RemoveAt events fire respectively.
        /// But when RemoveAt method is called, only RemoveAt event is fired.</summary>
        public event EventyListAfterEventHandler OnRemove;
        public event EventyListBeforeEventHandler BeforeAdd, BeforeInsert;
        /// <summary>Warning: If Remove method is called, both Remove and RemoveAt events fire respectively.
        /// But when RemoveAt method is called, only RemoveAt event is fired.</summary>
        public event EventyListBeforeEventHandler BeforeRemove;
        public event OnSetEventHandler OnSet;
        public event OnClearEventHandler OnClear;
        public event BeforeClearEventHandler BeforeClear;
        /// <summary>Warning: If Remove method is called, both Remove and RemoveAt events fire respectively.
        /// But when RemoveAt method is called, only RemoveAt event is fired.</summary>
        public event OnRemoveAtEventHandler OnRemoveAt;
        /// <summary>Warning: If Remove method is called, both Remove and RemoveAt events fire respectively.
        /// But when RemoveAt method is called, only RemoveAt event is fired.</summary>
        public event BeforeRemoveAtEventHandler BeforeRemoveAt;
        public event OnAddRangeEventHandler OnAddRange;
        public event BeforeAddRangeEventHandler BeforeAddRange;
        public event OnRemoveRangeEventHandler OnRemoveRange;
        public event BeforeRemoveRangeEventHandler BeforeRemoveRange;
        public event BeforeSetEventHandler BeforeSet;
        /// <summary>Occurs after any of actions specified in MyList.ListAction enumeration is performed.
        /// Warning: If Remove method is called, both Remove and RemoveAt events fire respectively. But when RemoveAt method is called,
        /// only RemoveAt event is fired.</summary>
        public event OnActionEventHandler OnAction;
        /// <summary>Occurs before any of actions specified in MyList.ListAction enumeration is performed.
        /// Warning: If Remove method is called, both Remove and RemoveAt events fire respectively.
        /// But when RemoveAt method is called, only RemoveAt event is fired.</summary>
        public event BeforeActionEventHandler BeforeAction;
        public enum ListAction { Add, Remove, Clear, Insert, Get, Set, AddRange, RemoveRange, RemoveAt }


        public class ActionEventArgs : EventArgs
        {
            private int index, count;
            private bool cancel;
            private ListAction action;
            private IEnumerable<T> addRangeCollection;
            T item;
            T setOldValue;

            internal ActionEventArgs(ListAction acton, int _startIndex, int _count)
            {
                index = _startIndex;
                count = _count;
                action = acton;
            }
            internal ActionEventArgs(ListAction acton, int _index)
            {
                index = _index;
                action = acton;
            }
            internal ActionEventArgs(ListAction acton)
            {
                action = acton;
            }
            internal ActionEventArgs(ListAction acton, bool cancl)
            {
                action = acton;
                cancel = cancl;
            }
            internal ActionEventArgs(ListAction acton, T itm)
            {
                item = itm;
                action = acton;
            }
            internal ActionEventArgs(ListAction acton, T oldVal, T newVal)
            {
                setOldValue = oldVal;
                item = newVal;
                action = acton;
            }
            internal ActionEventArgs(ListAction acton, IEnumerable<T> coll)
            {
                addRangeCollection = coll;
                action = acton;
            }
            internal ActionEventArgs(ListAction acton, int _startIndex, int _count, bool cancl)
            {
                index = _startIndex;
                count = _count;
                cancel = cancl;
                action = acton;
            }
            internal ActionEventArgs(ListAction acton, int _index, bool cancl)
            {
                index = _index;
                action = acton;
                cancel = cancl;
            }
            internal ActionEventArgs(ListAction acton, T itm, bool cancl)
            {
                item = itm;
                cancel = cancl;
                action = acton;
            }
            internal ActionEventArgs(ListAction acton, T oldVal, T newVal, bool cancl)
            {
                setOldValue = oldVal;
                item = newVal;
                action = acton;
                cancel = cancl;
            }
            internal ActionEventArgs(ListAction acton, IEnumerable<T> coll, bool cancl)
            {
                addRangeCollection = coll;
                cancel = cancl;
                action = acton;
            }
            /// <summary>Use only with BeforeAction event. Setting this to true will cancel an action</summary>
            public bool Cancel
            {
                get { return cancel; }
                set { cancel = value; }
            }

            /// <summary>Use only with Add, Get, Set and Remove actions. Setting this to true will cancel an action</summary>
            public T Item
            {
                get { return item; }
                set { item = value; }
            }
            /// <summary>Use only with Set action. Specifies old value, before using setter.</summary>
            public T SetOldValue
            {
                get { return setOldValue; }
                set { setOldValue = value; }
            }
            /// <summary>Use only with Set action. Specifies old value, before using setter.</summary>
            public T SetNewValue
            {
                get { return item; }
                set { item = value; }
            }
            /// <summary>Specifies what is going on.</summary>
            public ListAction Action
            {
                get { return action; }
            }
            /// <summary>Use only with AddRange action.</summary>
            public IEnumerable<T> AddRangeCollection
            {
                get { return addRangeCollection; }
                set { addRangeCollection = value; }
            }
            /// <summary>Use only with RemoveRange action.</summary>
            public int RemoveRangeStartIndex
            {
                get { return index; }
                set { index = value; }
            }
            /// <summary>Use only with RemoveRange action.</summary>
            public int RemoveRangeCount
            {
                get { return count; }
                set { count = value; }
            }
            /// <summary>Use only with RemoveAt action.</summary>
            public int RemoveAtIndex
            {
                get { return index; }
                set { index = value; }
            }
        }

        #endregion

        #region Public Property

        /// <summary>Select Stored Procedure Name.</summary>
        private String selectSpName = String.Empty;
        public String SelectSpName
        {
            get
            {
                return selectSpName;
            }
            set
            {
                selectSpName = value;
            }
        }

        /// <summary>Insert Stored Procedure Name.</summary>
        private String insertSpName = String.Empty;
        public String InsertSpName
        {
            get
            {
                return insertSpName;
            }
            set
            {
                insertSpName = value;
            }
        }
        /// <summary>Update Stored Procedure Name.</summary>
        private String updateSpName = String.Empty;
        public String UpdateSpName
        {
            get
            {
                return updateSpName;
            }
            set
            {
                updateSpName = value;
            }
        }
        /// <summary>Delete Stored Procedure Name.</summary>        
        private String deleteSpName = String.Empty;
        public String DeleteSpName
        {
            get
            {
                return deleteSpName;
            }
            set
            {
                deleteSpName = value;
            }
        }

        private Boolean preserveVid = false;
        public Boolean PreserveVid
        {
            get
            {
                return preserveVid;
            }
            set
            {
                preserveVid = value;
            }
        }

        private Predicate<T> filter;
        public Predicate<T> Filter
        {
            set
            {
                filter = value;
            }
        }
        public CustomList<T> DefaultView
        {
            get
            {
                if (filter == null)
                    return this;
                else
                    return FindAll(filter);
            }
        }  

        #endregion



        #region Events' protected methods

        protected virtual void onAdd(T item)
        {
            if (!PreserveVid)
            {
                try
                {
                    item.GetType().GetProperty("VID").SetValue(item, Count - 1, null);
                }
                catch { throw new Exception("Item in this list must be inherited from BaseItem class."); }
            }

            EventyListAfterEventHandler evt = OnAdd;
            OnActionEventHandler ae = OnAction;
            if (evt != null)
                evt(this, item);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Add, item));
        }
        protected virtual void onRemove(T item)
        {
            EventyListAfterEventHandler evt = OnRemove;
            OnActionEventHandler ae = OnAction;
            if (evt != null)
                evt(this, item);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Remove, item));
        }
        protected virtual void onGet(T item)
        {
            EventyListAfterEventHandler evt = OnGet;
            OnActionEventHandler ae = OnAction;
            if (evt != null)
                evt(this, item);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Get, item));
        }
        protected virtual void onSet(T oldValue, T newValue)
        {
            OnSetEventHandler evt = OnSet;
            OnActionEventHandler ae = OnAction;
            if (evt != null)
                evt(this, oldValue, newValue);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Set, oldValue, newValue));
        }
        protected virtual void onInsert(T item)
        {
            EventyListAfterEventHandler evt = OnInsert;
            OnActionEventHandler ae = OnAction;
            if (evt != null)
                evt(this, item);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Insert, item));
        }
        protected virtual void onClear()
        {
            OnClearEventHandler evt = OnClear;
            OnActionEventHandler ae = OnAction;
            if (evt != null)
                evt(this);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Clear));
        }
        protected virtual void onAddRange(IEnumerable<T> coll)
        {
            OnAddRangeEventHandler evt = OnAddRange;
            OnActionEventHandler ae = OnAction;
            if (evt != null)
                evt(this, coll);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.AddRange, coll));
        }

        protected virtual void onRemoveRange(int start, int count)
        {
            OnRemoveRangeEventHandler evt = OnRemoveRange;
            OnActionEventHandler ae = OnAction;
            if (evt != null)
                evt(this, start, count);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.RemoveRange, start, count));
        }
        protected virtual void onRemoveAt(int index)
        {
            OnRemoveAtEventHandler evt = OnRemoveAt;
            OnActionEventHandler ae = OnAction;
            if (evt != null)
                evt(this, index);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.RemoveAt, index));
        }
        /// <summary>Returns TRUE if Add action should be cancelled.</summary>
        protected virtual bool beforeAdd(ref T item)
        {
            bool cancel = false;
            EventyListBeforeEventHandler evt = BeforeAdd;
            BeforeActionEventHandler ae = BeforeAction;
            if (evt != null)
                evt(this, ref item, ref cancel);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Add, item), ref cancel);
            return cancel;
        }
        /// <summary>Returns TRUE if Remove action should be cancelled.</summary>
        protected virtual bool beforeRemove(ref T item)
        {
            bool cancel = false;
            EventyListBeforeEventHandler evt = BeforeRemove;
            BeforeActionEventHandler ae = BeforeAction;
            if (evt != null)
                evt(this, ref item, ref cancel);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Remove, item), ref cancel);
            return cancel;
        }
        /// <summary>Returns TRUE if Set action should be cancelled.</summary>
        protected virtual bool beforeSet(ref T oldValue, ref T newValue)
        {
            bool cancel = false;
            BeforeSetEventHandler evt = BeforeSet;
            BeforeActionEventHandler ae = BeforeAction;
            if (evt != null)
                evt(this, ref oldValue, ref newValue, ref cancel);
            if (ae != null)
            {
                ae(this, new ActionEventArgs(ListAction.Set, oldValue, newValue), ref cancel);
            }
            return cancel;
        }
        /// <summary>Returns TRUE if Insert action should be cancelled.</summary>
        protected virtual bool beforeInsert(ref T item)
        {
            bool cancel = false;
            EventyListBeforeEventHandler evt = BeforeInsert;
            BeforeActionEventHandler ae = BeforeAction;
            if (evt != null)
                evt(this, ref item, ref cancel);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Insert, item), ref cancel);
            return cancel;
        }
        /// <summary>Returns TRUE if Insert action should be cancelled.</summary>
        protected virtual bool beforeClear()
        {
            bool cancel = false;
            BeforeActionEventHandler ae = BeforeAction;
            BeforeClearEventHandler evt = BeforeClear;
            if (evt != null)
                evt(this, ref cancel);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.Clear), ref cancel);
            return cancel;
        }
        protected virtual bool beforeAddRange(IEnumerable<T> coll)
        {
            bool cancel = false;
            BeforeAddRangeEventHandler evt = BeforeAddRange;
            BeforeActionEventHandler ae = BeforeAction;
            if (evt != null)
                evt(this, coll, ref cancel);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.AddRange, coll), ref cancel);
            return cancel;
        }
        protected virtual bool beforeRemoveRange(ref int start, ref int count)
        {
            bool cancel = false;
            BeforeRemoveRangeEventHandler evt = BeforeRemoveRange;
            BeforeActionEventHandler ae = BeforeAction;
            if (evt != null)
                evt(this, ref start, ref count, ref cancel);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.RemoveRange), ref cancel);
            return cancel;
        }
        protected virtual bool beforeRemoveAt(int index)
        {
            bool cancel = false;
            BeforeRemoveAtEventHandler evt = BeforeRemoveAt;
            BeforeActionEventHandler ae = BeforeAction;
            if (evt != null)
                evt(this, ref index, ref cancel);
            if (ae != null)
                ae(this, new ActionEventArgs(ListAction.RemoveAt, index), ref cancel);
            return cancel;
        }
        #endregion

        #region List implementation

        private T[] arr;
        private int size;
        private int ver;

        public CustomList()
        {
            arr = new T[0];
        }
        public CustomList(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException();
            arr = new T[capacity];
        }

        public CustomList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                arr = new T[0];
                return;
            }

            ICollection<T> c = collection as ICollection<T>;
            if (c != null)
            {
                int count = c.Count;
                arr = new T[count];
                c.CopyTo(arr, 0);
                size = count;
            }
            else
            {
                size = 0;
                arr = new T[4];

                using (IEnumerator<T> en = collection.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        Add(en.Current);
                    }
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= size)
                    throw new ArgumentOutOfRangeException();
                T item = arr[index];
                onGet(item);
                return item;
            }
            set
            {
                if ((uint)index >= (uint)size)
                    throw new ArgumentOutOfRangeException();
                T oldValue = arr[index];
                if (beforeSet(ref oldValue, ref value)) return;
                arr[index] = value;
                ver++;
                onSet(oldValue, value);
            }
        }
        Object System.Collections.IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                if (!IsCompatibleObject(value))
                    throw new ArgumentException("Wrong value type: \"" + value.GetType().ToString() + "\"!");
                this[index] = (T)value;
            }
        }
        public int Count
        {
            get { return size; }
        }

        private static bool IsCompatibleObject(object value)
        {
            return ((value is T) || (value == null && !typeof(T).IsValueType));
        }


        public void Add(T item)
        {
            if (beforeAdd(ref item)) return;
            if (size >= arr.Length) EnsureCapacity(size + 1);
            arr[size++] = item;
            ver++;
            onAdd(item);
        }
        /// <summary>Adds object to the list. Warning: No events are fired!</summary>
        /// <param name="item">Item to add</param>
        /// <returns>Number of items in the list after the operation</returns>
        int System.Collections.IList.Add(Object item)
        {
            Add((T)item);
            return Count - 1;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (beforeAddRange(collection)) return;
            InsertRange(size, collection);
            onAddRange(collection);
        }

        public void Clear()
        {
            if (beforeClear()) return;
            arr = new T[size];
            size = 0;
            ver++;
            onClear();
        }

        public bool Contains(T item)
        {
            if ((Object)item == null)
            {
                for (int i = 0; i < size; i++)
                    if ((Object)arr[i] == null)
                        return true;
                return false;
            }
            else
            {
                EqualityComparer<T> c = EqualityComparer<T>.Default;
                for (int i = 0; i < size; i++)
                {
                    if (c.Equals(arr[i], item)) return true;
                }
                return false;
            }
        }

        bool System.Collections.IList.Contains(Object item)
        {
            if (IsCompatibleObject(item))
            {
                return Contains((T)item);
            }
            return false;
        }

        public CustomList<outType> ConvertAll<outType>(Converter<T, outType> converter)
        {
            if (converter == null)
                return null;

            CustomList<outType> list = new CustomList<outType>(size);
            for (int i = 0; i < size; i++)
                list.arr[i] = converter(arr[i]);
            list.size = size;
            return list;
        }

        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        void System.Collections.ICollection.CopyTo(Array array, int arrayIndex)
        {
            if (array.Rank != 1)
                throw new ArgumentException("Multi dimensional arrays are not supported.");
            try
            {
                Array.Copy(arr, 0, array, arrayIndex, size);
            }
            catch (ArrayTypeMismatchException)
            {
                throw new ArgumentException("Incompatible array types");
            }
        }

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            Array.Copy(arr, index, array, arrayIndex, count);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(arr, 0, array, arrayIndex, size);
        }

        private void EnsureCapacity(int min)
        {
            if (arr.Length < min)
            {
                int newCap = arr.Length == 0 ? 4 : arr.Length * 2;
                if (newCap < min) newCap = min;
                T[] newArr = new T[newCap];
                arr.CopyTo(newArr, 0);
                arr = newArr;
            }
        }

        public bool Exists(Predicate<T> match)
        {
            return FindIndex(match) != -1;
        }

        public T Find(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            for (int i = 0; i < size; i++)
                if (match(arr[i]))
                    return arr[i];
            return default(T);
        }

        public CustomList<T> FindAll(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            CustomList<T> ret = new CustomList<T>();
            ret.PreserveVid = true;
            CopySpName(ret);
            for (int i = 0; i < size; i++)
                if (match(arr[i]))
                    ret.Add(arr[i]);
            ret.preserveVid = false;
            return ret;
        }
        

        private void CopySpName(CustomList<T> ret)
        {
            ret.SelectSpName = this.SelectSpName;
            ret.InsertSpName = this.InsertSpName;
            ret.UpdateSpName = this.UpdateSpName;
            ret.DeleteSpName = this.DeleteSpName;
        }

        public int FindIndex(Predicate<T> match)
        {
            return FindIndex(0, size, match);
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            return FindIndex(startIndex, size - startIndex, match);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex > size)
                throw new ArgumentOutOfRangeException("startIndex", (object)startIndex, "Too big...");
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");
            if (startIndex > size - count)
                throw new ArgumentOutOfRangeException("startIndex");

            if (match == null)
                throw new ArgumentNullException("match");

            int end = startIndex + count;
            for (int i = startIndex; i < end; i++)
            {
                if (match(arr[i])) return i;
            }
            return -1;
        }

        public T FindLast(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            for (int i = size - 1; i >= 0; i--)
                if (match(arr[i]))
                    return arr[i];
            return default(T);
        }

        public int FindLastIndex(Predicate<T> match)
        {
            return FindLastIndex(size - 1, size, match);
        }

        public int FindLastIndex(int startIndex, Predicate<T> match)
        {
            return FindLastIndex(startIndex, startIndex + 1, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            if (count < 0 || startIndex - count + 1 < 0)
                throw new ArgumentOutOfRangeException();

            int end = startIndex - count;
            for (int i = startIndex; i > end; i--)
                if (match(arr[i]))
                    return i;
            return -1;
        }


        public void ForEach(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException("match");
            for (int i = 0; i < size; i++)
                action(arr[i]);
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public CustomList<T> GetRange(int index, int count)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index");
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");

            if (size - index < count)
                throw new ArgumentOutOfRangeException();

            CustomList<T> list = new CustomList<T>(count);
            Array.Copy(arr, index, list.arr, 0, count);
            list.size = count;
            return list;
        }


        public int IndexOf(T item)
        {
            return Array.IndexOf(arr, item, 0, size);
        }

        int System.Collections.IList.IndexOf(Object item)
        {
            if (IsCompatibleObject(item))
            {
                return IndexOf((T)item);
            }
            return -1;
        }

        public int IndexOf(T item, int index)
        {
            if (index > size)
                throw new ArgumentOutOfRangeException();
            return Array.IndexOf(arr, item, index, size - index);
        }

        public int IndexOf(T item, int index, int count)
        {
            if (index > size)
                throw new ArgumentOutOfRangeException();
            if (count < 0 || index > size - count) throw new ArgumentOutOfRangeException();

            return Array.IndexOf(arr, item, index, count);
        }

        public void Insert(int index, T item)
        {
            if (index > size)
                throw new ArgumentOutOfRangeException();

            if (size == arr.Length) EnsureCapacity(size + 1);
            if (index < size)
                Array.Copy(arr, index, arr, index + 1, size - index);
            arr[index] = item;
            size++;
            ver++;
        }

        void System.Collections.IList.Insert(int index, Object item)
        {
            Insert(index, (T)item);
        }

        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if (collection == null)
                return;

            if (index > size)
                throw new ArgumentOutOfRangeException("index");

            ICollection<T> c = collection as ICollection<T>;
            if (c != null)
            {
                int count = c.Count;
                if (count > 0)
                {
                    EnsureCapacity(size + count);
                    if (index < size)
                    {
                        Array.Copy(arr, index, arr, index + count, size - index);
                    }
                    if (this == c)
                    {
                        Array.Copy(arr, 0, arr, index, index);
                        Array.Copy(arr, index + count, arr, index * 2, size - index);
                    }
                    else
                    {
                        T[] itemsToInsert = new T[count];
                        c.CopyTo(itemsToInsert, 0);
                        itemsToInsert.CopyTo(arr, index);
                    }
                    size += count;
                }
            }
            else
            {
                using (IEnumerator<T> en = collection.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        Insert(index++, en.Current);
                    }
                }
            }
            ver++;
        }

        public int LastIndexOf(T item)
        {
            return LastIndexOf(item, size - 1, size);
        }

        public int LastIndexOf(T item, int index)
        {
            if (index >= size)
                throw new ArgumentOutOfRangeException();
            return LastIndexOf(item, index, index + 1);
        }

        public int LastIndexOf(T item, int index, int count)
        {
            if (size == 0)
                return -1;

            if (index < 0 || count < 0)
                throw new ArgumentOutOfRangeException();

            if (index >= size || count > index + 1)
                throw new ArgumentOutOfRangeException();

            return Array.LastIndexOf(arr, item, index, count);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                if (beforeRemove(ref item))
                    return false;
                RemoveAt(index);
                onRemove(item);
                return true;
            }
            return false;
        }

        void System.Collections.IList.Remove(Object item)
        {
            if (IsCompatibleObject(item))
                Remove((T)item);
        }

        public int RemoveAll(Predicate<T> match)
        {
            if (match == null)
                return -1;

            int freeIndex = 0;

            while (freeIndex < size && !match(arr[freeIndex])) freeIndex++;
            if (freeIndex >= size) return 0;

            int current = freeIndex + 1;
            while (current < size)
            {
                while (current < size && match(arr[current])) current++;

                if (current < size)
                    arr[freeIndex++] = arr[current++];
            }

            Array.Clear(arr, freeIndex, size - freeIndex);
            int ret = size - freeIndex;
            size = freeIndex;
            ver++;
            return ret;
        }

        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)size)
                throw new ArgumentOutOfRangeException();
            if (beforeRemoveAt(index)) return;
            size--;
            if (index < size)
                Array.Copy(arr, index + 1, arr, index, size - index);
            arr[size] = default(T);
            ver++;
            onRemoveAt(index);
        }

        public void RemoveRange(int index, int count)
        {
            if (index < 0 || count < 0)
                throw new ArgumentOutOfRangeException();
            if (size - index < count)
                throw new ArgumentOutOfRangeException();
            if (count > 0)
            {
                if (beforeRemoveRange(ref index, ref count)) return;
                size -= count;
                if (index < size)
                {
                    Array.Copy(arr, index + count, arr, index, size - index);
                }
                Array.Clear(arr, size, count);
                ver++;
                onRemoveRange(index, count);
            }
        }

        public void Reverse()
        {
            Reverse(0, Count);
        }

        public void Reverse(int index, int count)
        {
            if (index < 0 || count < 0 || size - index < count)
                throw new ArgumentOutOfRangeException();
            Array.Reverse(arr, index, count);
            ver++;
        }

        public void Sort()
        {
            Sort(0, Count, null);
        }

        public void Sort(IComparer<T> comparer)
        {
            Sort(0, Count, comparer);
        }

        public void Sort(int index, int count, IComparer<T> comparer)
        {
            if (index < 0 || count < 0 || size - index < count)
                throw new ArgumentOutOfRangeException();
            Array.Sort<T>(arr, index, count, comparer);
            ver++;
        }

        public void Sort(Comparison<T> comparison)
        {
            if (comparison == null)
                return;
            if (size > 0)
                Sort(0, size, new comparer(comparison));
            //Array.Sort(arr, comparison);
        }
        class comparer : IComparer<T>
        {
            Comparison<T> comprMethod;
            public comparer(Comparison<T> method)
            {
                comprMethod = method;
            }
            public int Compare(T x, T y)
            {
                return comprMethod(x, y);
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[size];
            Array.Copy(arr, 0, array, 0, size);
            return array;
        }

        public bool TrueForAll(Predicate<T> match)
        {
            if (match == null)
                return false;

            for (int i = 0; i < size; i++)
                if (!match(arr[i]))
                    return false;
            return true;
        }

        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            if (index < 0 || count < 0 || size - index < count)
                throw new ArgumentOutOfRangeException("index");
            return Array.BinarySearch<T>(arr, index, count, item, comparer);
        }

        public int BinarySearch(T item)
        {
            return BinarySearch(0, Count, item, null);
        }

        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return BinarySearch(0, Count, item, comparer);
        }


        #region The Enumerator

        [Serializable()]
        public struct Enumerator : IEnumerator<T>, System.Collections.IEnumerator
        {
            private CustomList<T> list;
            private int index;
            private int version;
            private T current;

            internal Enumerator(CustomList<T> lst)
            {
                this.list = lst;
                index = 0;
                version = lst.ver;
                current = default(T);
            }

            public bool MoveNext()
            {
                if (version != list.ver)
                    throw new InvalidOperationException("Collection has changed!");

                if (index < list.size)
                {
                    current = list.arr[index++];
                    return true;
                }
                index = list.size + 1;
                current = default(T);
                return false;
            }

            public T Current
            {
                get { return current; }
            }

            Object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index == list.size + 1)
                        throw new InvalidOperationException("What's up?");
                    return Current;
                }
            }

            void System.Collections.IEnumerator.Reset()
            {
                if (version != list.ver)
                    throw new InvalidOperationException("Collection has changed!");

                index = 0;
                current = default(T);
            }

            public void Dispose()
            {
            }

        }
        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return null; }
        }
        #endregion

        #endregion

        #region IList<T> Members

        int IList<T>.IndexOf(T item)
        {
            return IndexOf(item);
        }

        void IList<T>.Insert(int index, T item)
        {
            Insert(index, item);
        }

        void IList<T>.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        T IList<T>.this[int index]
        {
            get { return this[index]; }
            set { this[index] = value; }
        }

        #endregion

        #region ICollection<T> Members

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        void ICollection<T>.Clear()
        {
            Clear();
        }

        bool ICollection<T>.Contains(T item)
        {
            return Contains(item);
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            CopyTo(array, arrayIndex);
        }

        int ICollection<T>.Count
        {
            get { return Count; }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return IsReadOnly; }
        }

        bool ICollection<T>.Remove(T item)
        {
            return Remove(item);
        }

        #endregion
    }
}

