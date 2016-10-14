using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Hr.DAO
{

       [Serializable]
       public class EmpFilterSets : BaseItem
       {
           public EmpFilterSets()
           {
               SetAdded();
           }


           private String caption = String.Empty;
           [Browsable(true), DisplayName("Caption")]
           public String Caption
           {
               get { return caption; }
               set { caption = value; }
           }
           private Int32 entityID = 0;
           [Browsable(true), DisplayName("EntityID")]
           public Int32 EntityID
           {
               get { return entityID; }
               set { entityID = value; }
           }
           private String columnName = String.Empty;
           [Browsable(true), DisplayName("ColumnName")]
           public String ColumnName
           {
               get { return columnName; }
               set { columnName = value; }
           }
           //
           private String operators = String.Empty;
           [Browsable(true), DisplayName("Operators")]
           public String Operators
           {
               get { return operators; }
               set { operators = value; }
           }
           //
           private String columnValue = String.Empty;
           [Browsable(true), DisplayName("ColumnValue")]
           public String ColumnValue
           {
               get { return columnValue; }
               set { columnValue = value; }
           }

           //
           private String displaySeletedColumnValue = String.Empty;
           [Browsable(true), DisplayName("DisplaySeletedColumnValue")]
           public String DisplaySeletedColumnValue
           {
               get { return displaySeletedColumnValue; }
               set { displaySeletedColumnValue = value; }
           }
           //
           private String orAnd = String.Empty;
           [Browsable(true), DisplayName("OrAnd")]
           public String OrAnd
           {
               get { return orAnd; }
               set { orAnd = value; }
           }
           //
           private String dataType = String.Empty;
           [Browsable(true), DisplayName("DataType")]
           public String DataType
           {
               get { return dataType; }
               set { dataType = value; }
           }
           //
           private String tableName = String.Empty;
           [Browsable(true), DisplayName("TableName")]
           public String TableName
           {
               get { return tableName; }
               set { tableName = value; }
           }
           //
           private Boolean isParameter = false;
           [Browsable(true), DisplayName("IsParameter")]
           public Boolean IsParameter
           {
               get { return isParameter; }
               set { isParameter = value; }
           }
           public override Object[] GetParameterValues()
           {
               return null;
           }
           protected override void SetData(IDataRecord reader)
           {
               SetUnchanged();
           }
           private String defaultValue = String.Empty;
           public String DefaultValue
           {
               get { return defaultValue; }
               set { defaultValue = value; }
           }
       }
    }

