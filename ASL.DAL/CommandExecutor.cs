using System;
using System.Collections.Generic;
using System.Data;
using ASL.DATA;

namespace ASL.DAL
{
    public class CommandExecutor
    {
        private IDbTransaction transaction;
        public CommandExecutor(IDbTransaction transaction, Util.ConnectionLibrary ProviderType)
        {
            this.transaction = transaction;
            DataAccessHelper.ProviderType = ProviderType;
        }
        public void Update(CustomList<BaseItem> itemList, Util.OperationType operationType)
        {
            String spName = String.Empty;

            switch (operationType)
            {
                case Util.OperationType.Insert:
                    spName = itemList.InsertSpName;
                    break;

                case Util.OperationType.Update:
                    spName = itemList.UpdateSpName;
                    break;

                case Util.OperationType.Delete:
                    spName = itemList.DeleteSpName;
                    break;
            }

            Object[] parameterValues = null;
            foreach (BaseItem item in itemList)
            {
                parameterValues = item.GetParameterValues();

                if (parameterValues.IsNotNull())
                {
                    DataAccessHelper.ExecuteNonQueryProcedure(transaction, spName, parameterValues);                    
                }
            }           
        }

        //zaki - Insert record and get Scope_Identity()
        public object Insert(CustomList<BaseItem> itemList, Util.OperationType operationType)
        {
            String spName = String.Empty;

            switch (operationType)
            {
                case Util.OperationType.Insert:
                    spName = itemList.InsertSpName;
                    break;

                case Util.OperationType.Update:
                    spName = itemList.UpdateSpName;
                    break;

                case Util.OperationType.Delete:
                    spName = itemList.DeleteSpName;
                    break;
            }

            Object[] parameterValues = null;
            object retVal = null;

            parameterValues = itemList[0].GetParameterValues();

            if (parameterValues.IsNotNull())
            {
               retVal = DataAccessHelper.ExecuteScalar(transaction, spName, parameterValues);
            }

            return retVal;
        }
    }
}

#region Deleted
//using System;
//using System.Data;
//using System.Collections.Generic;
//using System.Text;

//namespace ASL.DATA
//{
//    public class CommandBuilder
//    {
//        private readonly IDbCommand command;
//        private List<String> queryToExecute = new List<String>();
//        private readonly List<String> columnInfo = new List<String>();
//        private readonly List<String> keyInfo = new List<String>();
//        private readonly List<String> identityInfo = new List<String>();
//        private String tableName = String.Empty;
//        public CommandBuilder(IDbCommand command)
//        {
//            this.command = command;
//            GetColumnKeyInfo();
//        }
//        private void GetColumnKeyInfo()
//        {
//            IDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
//            DataTable dtKeyInfo = reader.GetSchemaTable();
//            reader.Close();
//            foreach (DataRow dr in dtKeyInfo.Rows)
//            {
//                if (Convert.ToBoolean(dr[SchemaTableColumnInfo.IsKey.ToString()]))
//                {
//                    keyInfo.Add(dr[SchemaTableColumnInfo.ColumnName.ToString()].ToString());
//                    tableName = dr[SchemaTableColumnInfo.BaseTableName.ToString()].ToString();
//                }
//                if (Convert.ToBoolean(dr[SchemaTableColumnInfo.IsIdentity.ToString()]))
//                    identityInfo.Add(dr[SchemaTableColumnInfo.ColumnName.ToString()].ToString());
//                //
//                columnInfo.Add(dr[SchemaTableColumnInfo.ColumnName.ToString()].ToString());
//            }
            
//        }
//        public void GetInsertCommand(IList<ItemBase> insertedList)
//        {
//            ItemStorage data;            
//            StringBuilder insertColumns;
//            StringBuilder insertValue;
//            queryToExecute = new List<String>();
//            foreach (ItemBase item in insertedList)
//            {
//                insertColumns = new StringBuilder();
//                insertValue = new StringBuilder();
//                insertColumns.AppendFormat("{0} {1}(", "Insert Into", tableName);
//                insertValue.Append("Values(");
//                foreach (String columnName in columnInfo)
//                {
//                    if (identityInfo.Contains(columnName))
//                        continue;
//                    data = item.Columns[columnName];
//                    if (data == null)
//                        throw new Exception("Missing the Column '" + columnName + "' in the Table '" + tableName + "' for the Source Column '" + columnName + "'.");
//                    //
//                    insertColumns.AppendFormat("{0},", data.Name);

//                    insertValue.AppendFormat("{0},", data.GetValue());

//                }
//                insertColumns.Append(")");
//                insertColumns.Replace(",)", ")");
//                //
//                insertValue.Append(")");
//                insertValue.Replace(",)", ")");
//                //
//                insertColumns.AppendLine();
//                insertColumns.Append(insertValue.ToString());
//                //
//                queryToExecute.Add(insertColumns.ToString());
//            }
//        }
//        public void GetUpdateCommand(IList<ItemBase> updatedList)
//        {
//            ItemStorage data;                      
//            StringBuilder updatedColumn;
//            StringBuilder whereValue;
//            queryToExecute = new List<String>();

//            foreach (ItemBase item in updatedList)
//            {
//                updatedColumn = new StringBuilder();
//                whereValue = new StringBuilder();
//                updatedColumn.AppendFormat("{0} {1} {2} ", "Update", tableName,"Set");
//                whereValue.Append("Where");

//                foreach (String columnName in columnInfo)
//                {
//                    data = item.Columns[columnName];
//                    if (data == null)
//                        throw new Exception("Missing the Column '" + columnName + "' in the Table '" + tableName + "' for the Source Column '" + columnName + "'.");

//                    if (keyInfo.Contains(data.Name))
//                    {
//                        whereValue.AppendFormat(" {0} = {1} And", data.Name, data.GetValue());
//                    }
//                    else
//                    {
//                        if (identityInfo.Contains(data.Name))
//                            continue;
//                        if (data.Modified)
//                            updatedColumn.AppendFormat("{0} = {1},", data.Name, data.GetValue());
//                    }
//                }
//                updatedColumn.Append(")");
//                updatedColumn.Replace(",)", "");
//                //
//                whereValue.Append(")");
//                whereValue.Replace("And)", "");
//                //
//                updatedColumn.AppendLine();
//                updatedColumn.Append(whereValue.ToString());
//                //
//                queryToExecute.Add(updatedColumn.ToString());
//            }
//        }
//        public void GetDeleteCommand(IList<ItemBase> deletedList)
//        {
//            ItemStorage data;            
//            StringBuilder whereValue;
//            queryToExecute = new List<String>();

//            foreach (ItemBase item in deletedList)
//            {                
//                whereValue = new StringBuilder();
//                whereValue.AppendFormat("{0} {1} {2}", "Delete", tableName, "Where");
//                foreach (String columnName in keyInfo)
//                {
//                    data = item.Columns[columnName];
//                    if (data == null)
//                        throw new Exception("Missing the Column '" + columnName + "' in the Table '" + tableName + "' for the Source Column '" + columnName + "'.");

//                    whereValue.AppendFormat(" {0} = {1} And", data.Name, data.GetValue());
//                }
//                //
//                whereValue.Append(")");
//                whereValue.Replace("And)", "");
//                //
//                queryToExecute.Add(whereValue.ToString());
//            }
//        }
//        public void Update()
//        {
//            foreach (String query in queryToExecute)
//            {
//                command.CommandText = query;
//                command.ExecuteNonQuery();
//            }
//        }
//    }
//}
#endregion