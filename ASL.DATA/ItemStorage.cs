using System;

namespace ASL.DATA
{
    [Serializable]
    public abstract class ItemStorage// : IDisposable
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private Boolean modified;
        public Boolean Modified
        {
            get { return modified; }
            set { modified = value; }
        }
        private FieldCategory fieldType;
        public FieldCategory FieldType
        {
            get { return fieldType; }
            set { fieldType = value; }
        }
        public override string ToString()
        {
            return name;
        }

        protected internal abstract void AcceptChanges();
        protected internal abstract void RejectChanges();
        public abstract String GetValue();
        public abstract Object ObjectTypeValue
        {
            get;
            set;
        }
      //  public void Dispose()
      //  {
      //      Dispose(true);
      //      GC.SuppressFinalize(this);
      //  }
      //  protected virtual void Dispose(bool disposing)
      //  {

      //  }
      //  ~ItemStorage()
      //{
      //   Dispose();
      //}
    }
}
