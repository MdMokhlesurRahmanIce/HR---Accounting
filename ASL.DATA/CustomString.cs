using System;

namespace ASL.DATA
{
    [Serializable]
    public class CustomString
    {

        private readonly String value;

        private CustomString(String value)
        {
            this.value = value;
        }
        public static implicit operator CustomString(String value)
        {
            return new CustomString(value);
        }
        public static explicit operator String(CustomString str)
        {
            return str.value;
        }
        public static explicit operator Int32(CustomString str)
        {
            return str.value.Length;
        }
        public override String ToString()
        {            
            return value;
        }
    }
}
