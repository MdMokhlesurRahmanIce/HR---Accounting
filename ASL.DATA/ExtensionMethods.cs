using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Globalization;
namespace ASL.DATA
{
    public static class ExtensionMethods
    {
        public static T To<T>(this IConvertible obj)
        {
            Type t = typeof(T);
            Type u = Nullable.GetUnderlyingType(t);

            if (u != null)
            {
                if (obj == null)
                    return default(T);

                return (T)Convert.ChangeType(obj, u);
            }
            else
            {
                return (T)Convert.ChangeType(obj, t);
            }
        }

        public static string ToStringOrDefault(this DateTime? source, string format, string defaultValue)
        {
            if (source != null)
            {
                return source.Value.ToString(format);
            }
            else
            {
                return String.IsNullOrEmpty(defaultValue) ? String.Empty : defaultValue;
            }
        }
        /// <summary>
        /// Gets a copy of the Collection that contains all changes made to
        /// it since it was loaded or ItemList.AcceptChanges() was last
        /// called.
        /// </summary>
        /// <typeparam name="BaseItem"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static CustomList<BaseItem> GetChanges(this CustomList<BaseItem> list)
        {
            return list.FindAll(item => item.IsAdded
                              || item.IsModified
                              || item.IsDeleted);
        }
        /// <summary>
        /// Gets a copy of the Collection containing all changes made to it
        /// since it was last loaded, or since ItemList.AcceptChanges()
        /// was called, filtered by itemState.
        /// </summary>
        /// <typeparam name="BaseItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="itemState"></param>
        /// <returns></returns>
        public static CustomList<BaseItem> GetChanges(this CustomList<BaseItem> list, ItemState itemState)
        {
            return list.FindAll(item => item.State.Equals(itemState));
        }
        /// <summary>
        /// Convert to actual Type
        /// </summary>
        /// <param name="source"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public static IEnumerable Cast(this CustomList<BaseItem> source, Type conversionType)
        {
            CustomList<Object> returnList = new CustomList<Object>();
            returnList.PreserveVid = true;
            foreach (Object conObject in source)
            {
                returnList.Add(Convert.ChangeType(conObject, conversionType));
            }
            return returnList;
        }
        /// <summary>
        /// Convert to CustomList
        /// </summary>
        /// <param name="source"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public static CustomList<T> ToCustomList<T>(this IEnumerable source)
        {
            return source.ToCustomList<T>(true);
        }
        public static CustomList<T> ToCustomList<T>(this IEnumerable source, Boolean preserveVid)
        {
            CustomList<T> returnList = new CustomList<T>();
            returnList.PreserveVid = preserveVid;
            //returnList.SelectSpName = source.GetType().GetProperty("SelectSpName").GetValue(source, null).ToString();
            returnList.InsertSpName = source.GetType().GetProperty("InsertSpName").GetValue(source, null).ToString();
            returnList.UpdateSpName = source.GetType().GetProperty("UpdateSpName").GetValue(source, null).ToString();
            returnList.DeleteSpName = source.GetType().GetProperty("DeleteSpName").GetValue(source, null).ToString();
            foreach (T additem in source)
            {
                returnList.Add(additem);
            }
            return returnList;
        }
        public static CustomList<T> ToCustomList2<T>(this IEnumerable source)
        {
            CustomList<T> returnList = new CustomList<T>();
            returnList.PreserveVid = false;
            foreach (T additem in source)
            {
                returnList.Add(additem);
            }
            return returnList;
        }
        /// <summary>
        /// Gets a copy of the Collection that contains all changes made to
        /// it since it was loaded or ItemList.AcceptChanges() was last
        /// called.
        /// </summary>
        /// <typeparam name="List<T>"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static CustomList<T> GetChanges<T>(this CustomList<T> list)
        {
            return list.FindAll(PredicateBuilder.Build<T>("item.IsAdded || item.IsModified || item.IsDeleted"));
        }
        /// <summary>
        /// Gets a copy of the Collection containing all changes made to it
        /// since it was last loaded, or since ItemList.AcceptChanges()
        /// was called, filtered by itemState.
        /// </summary>
        /// <typeparam name="List<T>"></typeparam>
        /// <param name="list"></param>
        /// <param name="itemState"></param>
        /// <returns></returns>
        public static CustomList<T> GetChanges<T>(this CustomList<T> list, ItemState itemState)
        {
            return list.FindAll(PredicateBuilder.Build<T>("item.State == ASL.DATA;.ItemState." + itemState.ToString() + ""));
        }
        public static void DeleteAll<T>(this CustomList<T> list)
        {
            foreach (Object item in list)
            {
                ((BaseItem)item).Delete();
            }
        }
        public static void SetAddedAll<T>(this CustomList<T> list)
        {
            foreach (Object item in list)
            {
                BaseItem bItem = ((BaseItem)item);
                if (bItem.IsUnchanged || bItem.IsModified)
                    bItem.SetAdded();
            }
        }
        public static void SetUnchangedAll<T>(this CustomList<T> list)
        {
            foreach (Object item in list)
            {
                BaseItem bItem = ((BaseItem)item);
                bItem.SetUnchanged();
            }
        }
        /// <summary>
        /// Commits all the changes made to this Collection since the last time ItemList.AcceptChanges()        
        /// was called.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void AcceptChanges<T>(this CustomList<T> list)
        {
            BaseItem[] items = list.Cast<BaseItem>().ToArray();
            foreach (BaseItem item in items)
            {
                switch (item.State)
                {
                    case ItemState.Deleted:
                        list.Remove((T)Convert.ChangeType(item, typeof(T)));
                        break;
                    case ItemState.Modified:
                    case ItemState.Added:
                        item.SetUnchanged();
                        break;
                }
            }
        }
        /// <summary>
        /// Commits all the changes made to this Collection since the last time ItemList.AcceptChanges()        
        /// was called.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void AcceptChanges<T>(this CustomList<T> list, ItemState itemState)
        {
            BaseItem[] items = list.Cast<BaseItem>().ToArray();
            foreach (BaseItem item in items)
            {
                if (item.State != itemState) continue;
                switch (item.State)
                {
                    case ItemState.Deleted:
                        list.Remove((T)Convert.ChangeType(item, typeof(T)));
                        break;
                    case ItemState.Modified:
                    case ItemState.Added:
                        item.SetUnchanged();
                        break;
                }
            }
        }

        /// <summary>
        /// Rolls back all changes that have been made to the Collection since it was loaded,
        /// or the last time ItemList.AcceptChanges() was called.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void RejectChanges<T>(this List<T> list)
        {
            ItemBase[] items = list.Cast<ItemBase>().ToArray();
            foreach (ItemBase item in items)
            {
                switch (item.State)
                {
                    case ItemState.Added:
                        list.Remove((T)Convert.ChangeType(item, typeof(T)));
                        break;
                    case ItemState.Deleted:
                    case ItemState.Modified:
                        item.RejectChanges();
                        break;
                }
            }
        }
        /// <summary>
        /// Copies both the structure and data for this Collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static CustomList<T> Copy<T>(this CustomList<T> list)
        {
            CustomList<T> returnList = new CustomList<T>();
            returnList.PreserveVid = true;
            IEnumerable<BaseItem> items = list.Cast<BaseItem>();
            foreach (BaseItem item in items)
            {
                returnList.Add((T)item.Copy());
            }
            return returnList;
        }
        public static IEnumerable[] Reverse(this IEnumerable[] list)
        {
            IEnumerable[] listTemp = new IEnumerable[list.Count()];
            int i = 0;
            for (int index = list.Count(); index >= 1; --index)
            {
                listTemp[i] = list[index - 1];
                i++;
            }
            return listTemp;
        }

        /// <summary>
        /// Clones the structure of the ItemList, including all Collection
        /// schemas and constraints.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static CustomList<T> Clone<T>(this CustomList<T> list)
        {
            return new CustomList<T>();
        }
        public static Object IfEmptyThenNull(this String str)
        {
            if (String.IsNullOrEmpty(str))
                return null;
            return str;
        }
        public static int? IfEmptyOrNullThenNull(this String str)
        {
            if (String.IsNullOrEmpty(str))
                return null;
            else
                return str.ToInt();
        }
        public static Boolean NotEquals(this Object val, Object compVal)
        {
            return val != compVal;
        }
        public static Boolean NotEquals(this String val, String compVal)
        {
            return val != compVal;
        }
        public static Boolean NotEquals(this Decimal val, Decimal compVal)
        {
            return val != compVal;
        }
        public static Boolean NotEquals(this Double val, Double compVal)
        {
            return val != compVal;
        }
        public static Boolean NotEquals(this Int32 val, Int32 compVal)
        {
            return val != compVal;
        }
        public static Boolean NotEquals(this Int16 val, Int16 compVal)
        {
            return val != compVal;
        }
        public static Boolean NotEquals(this Int64 val, Int64 compVal)
        {
            return val != compVal;
        }
        public static Boolean NotEquals(this DateTime val, DateTime compVal)
        {
            return val != compVal;
        }
        public static Boolean NotEquals(this Boolean val, Boolean compVal)
        {
            return val != compVal;
        }
        public static Boolean IsNullOrEmpty(this String str)
        {
            return String.IsNullOrEmpty(str);
        }
        public static Boolean IsNotNullOrEmpty(this String str)
        {
            return !String.IsNullOrEmpty(str);
        }
        public static Boolean IsZero(this Decimal val)
        {
            return val.Equals(Decimal.Zero);
        }
        public static Boolean IsNotZero(this Decimal val)
        {
            return !val.Equals(Decimal.Zero);
        }
        public static Boolean IsZero(this Double val)
        {
            return val.Equals(0);
        }
        public static Boolean IsNotZero(this Double val)
        {
            return !val.Equals(0);
        }
        public static Boolean IsZero(this int val)
        {
            return val.Equals(0);
        }
        public static Boolean IsNotZero(this int val)
        {
            return !val.Equals(0);
        }
        public static Boolean IsTrue(this Boolean val)
        {
            return val;
        }
        public static Boolean IsFalse(this Boolean val)
        {
            return !val;
        }
        public static Boolean IsNull(this BaseItem obj)
        {
            return obj == null;
        }
        public static Boolean IsNotNull(this BaseItem obj)
        {
            return obj != null;
        }
        public static Boolean IsNull(this Object obj)
        {
            return obj == null;
        }
        public static Boolean IsNotNull(this Object obj)
        {
            return obj != null;
        }
        public static String IfEmptyThenZero(this String str)
        {
            if (String.IsNullOrEmpty(str))
                return "0";
            return str;
        }
        public static Boolean IsNumber(this String str)
        {
            return IsNumber(str, false);
        }
        public static Boolean IsNumber(this String str, Boolean negativeCheck)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    Double.Parse(str.Trim());
                    if (negativeCheck)
                    {
                        if (Double.Parse(str.Trim()) < 0)
                            return false;
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return str.Trim() != String.Empty;
        }
        public static Boolean IsDate(this String strDate)
        {
            DateTime dt;
            Boolean isdate = true;
            try
            {
                dt = DateTime.Parse(strDate);
            }
            catch
            {
                isdate = false;
            }
            return isdate;
        }
        public static Decimal ToDecimal(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return Decimal.Parse(str.Trim());
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }
        public static Double ToDouble(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return Double.Parse(str.Trim());
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }
        public static int ToInt(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return int.Parse(str.Trim());
                }
                catch
                {
                    return -1;
                }
            }
            return -1;
        }
        public static Boolean ToBoolean(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return Boolean.Parse(str.Trim());
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public static DateTime ToDateTime(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return DateTime.Parse(str.Trim());
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            return DateTime.MinValue;
        }
        public static DateTime ToDateTime(this String str, String DateFormat)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    return DateTime.ParseExact(str.Trim(), DateFormat, provider);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            return DateTime.MinValue;
        }
        //public static int? IfEmptyOrNullThenNull(this String str)
        //{
        //    if (String.IsNullOrEmpty(str))
        //        return null;
        //    else
        //        return str.ToInt();
        //}
        public static Object Value(this DateTime dateTime, String format)
        {
            return dateTime.Equals(DateTime.MinValue) ? null : dateTime.ToString(format);
        }
        public static String StringValue(this DateTime dateTime)
        {
            return dateTime.Equals(DateTime.MinValue) ? String.Empty : dateTime.ToShortDateString();
        }
        public static Boolean GetBoolean(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? false : (Boolean)reader[columnName];
        }
        public static Byte[] GetBytes(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? null : (Byte[])reader[columnName];
        }
        public static DateTime GetDateTime(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? DateTime.MinValue : DateTime.Parse(reader[columnName].ToString());
        }
        public static Decimal GetDecimal(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? 0.0m : (Decimal)reader[columnName];
        }
        public static Double GetDouble(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? 0.0d : (Double)reader[columnName];
        }
        public static Int16 GetInt16(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? (Int16)0 : Convert.ToInt16(reader[columnName]);
        }
        public static Int32 GetInt32(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? 0 : (Int32)reader[columnName];
        }
        public static Int64 GetInt64(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? 0 : (Int64)reader[columnName];
        }
        public static Int64? GetNulableInt64(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? null : (Int64?)reader[columnName];
        }
        public static Int32? GetNulableInt32(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? null : (Int32?)reader[columnName];
        }
        public static String GetString(this IDataRecord reader, String columnName)
        {
            return reader[columnName].ToString();
        }
        public static TimeSpan? GetTimeSpan(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? null : (TimeSpan?)reader[columnName];
        }
        public static DateTime? GetNullableDateTime(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? null : (DateTime?)DateTime.Parse(reader[columnName].ToString());
        }
    }
}
public class StringEqualityComparer : IEqualityComparer<String>
{

    public bool Equals(String str1, String str2)
    {
        if (str1.Trim().ToLower().CompareTo(str2.Trim().ToLower()).Equals(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetHashCode(String str)
    {
        return str.GetHashCode();
    }

}
