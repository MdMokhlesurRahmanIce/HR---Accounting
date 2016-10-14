using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ASL.Web.Framework
{
    [Serializable]
    public class SearchColumnConfig
    {
        String _ColumnName = String.Empty;
        public String ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                _ColumnName = value;
            }
        }
        String _Caption = String.Empty;
        public String Caption
        {
            get
            {
                return _Caption;
            }
            set
            {
                _Caption = value;
            }
        }
        Int16 _DisplayPosition;
        public Int16 DisplayPosition
        {
            get
            {
                return _DisplayPosition;
            }
            set
            {
                _DisplayPosition = value;
            }
        }
        Boolean _Hiden = false;
        public Boolean Hiden
        {
            get
            {
                return _Hiden;
            }
            set
            {
                _Hiden = value;
            }
        }

        #region --- Construcors ---

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchColumnConfig() { }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <param name="ordinal"></param>
        public SearchColumnConfig(string columnName, string caption, Int16 displayPosition)
        {
            _ColumnName = columnName;
            _Caption = caption;
            _DisplayPosition = displayPosition;
        }

        #endregion

        #region --- Static Methods ---

        /// <summary>
        /// returns a List object of SearchColumnConfig type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static List<SearchColumnConfig> GetColumnConfig(Type type, Dictionary<string, string> columns)
        {
            PropertyDescriptorCollection lstPropertie = TypeDescriptor.GetProperties(type);
            List<SearchColumnConfig> columnConfig = new List<SearchColumnConfig>();
            string caption = string.Empty;
            foreach (PropertyDescriptor objPropertie in lstPropertie)
            {
                if (columns.ContainsKey(objPropertie.Name))
                {
                    columns.TryGetValue(objPropertie.Name, out caption);
                    columnConfig.Add(new SearchColumnConfig { ColumnName = objPropertie.Name, Caption = caption });
                }
                else
                {
                    columnConfig.Add(new SearchColumnConfig { ColumnName = objPropertie.Name, Hiden = true });
                }
            }
            return columnConfig;
        }

        /// <summary>
        /// returns a List object of SearchColumnConfig type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static List<SearchColumnConfig> GetColumnConfig(Type type, List<SearchColumnConfig> columns)
        {
            PropertyDescriptorCollection lstPropertie = TypeDescriptor.GetProperties(type);
            List<SearchColumnConfig> columnConfig = new List<SearchColumnConfig>();
            string caption = string.Empty;
            foreach (PropertyDescriptor objPropertie in lstPropertie)
            {
                SearchColumnConfig item = columns.Find(p => p.ColumnName == objPropertie.Name);
                if (item != null)
                {
                    columnConfig.Add(new SearchColumnConfig { ColumnName = objPropertie.Name, Caption = item.Caption, DisplayPosition = item.DisplayPosition });
                }
                else
                {
                    columnConfig.Add(new SearchColumnConfig { ColumnName = objPropertie.Name, Hiden = true });
                }
            }
            return columnConfig;
        }

        #endregion
    }
}
