using System;

namespace ASL.DATA
{
    public class ByteStorage : ItemStorage
    {
        public ByteStorage(ItemBase item, String columnName, FieldCategory fieldType)
        {
            Name = columnName;
            this.item = item;
            this.item.Fields.Add(this);
            FieldType = fieldType;
        }
        private readonly ItemBase item;
        private Boolean original;

        private Byte[] value;
        public Byte[] Value
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

        private Byte[] originalValue;
        public Byte[] OriginalValue
        {
            get { return originalValue; }
        }

        protected internal void PropertyChanged(Byte[] newValue)
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
            set { this.value = (Byte[])value; }
        }
        public override String GetValue()
        {
            return "@" + Name;
        }

        //internal System.Drawing.Image GetImage(Byte[] byteImage)
        //{
        //    //var objStrea = new MemoryStream((Byte[])dsEmp.Tables["tblEmpImage"].Rows[0]["EmpImage"]);
        //    var objStrea = new MemoryStream(byteImage);
        //    return System.Drawing.Image.FromStream(objStrea);

        //}
        //internal Byte[] SetImage(System.Drawing.Image image)
        //{
        //    var fileStream = new MemoryStream();
        //    image.Save(fileStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    var objByte = new Byte[fileStream.Length];
        //    fileStream.Position = 0;
        //    fileStream.Read(objByte, 0, Convert.ToInt32(fileStream.Length));
        //    //					
        //    return objByte;
        //}
    }
}
