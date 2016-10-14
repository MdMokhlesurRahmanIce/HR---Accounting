using System;
using System.Collections;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using ASL.DATA;

namespace ASL.DAL
{
    #region ConnectionManager

    public class ConnectionManager : IConnectionManager, IDisposable
    {
        #region DAL CONST
        private const String Query = "Query";
        private const String UpdateQuery = "UpdateQuery";
        private const String JoinedQuery = "JoinedQuery";

        private const String ConnectionTimeOut = "Connection Timeout = 30";
        private readonly String connectionName = String.Empty;
        private const int CommandTimeOutValue = 600;
        #endregion

        #region Variable Declaration
        public Boolean IsInTransaction;
        private String defaultConnectionString;
        private IDbConnection disconnection;
        private IDbTransaction transaction;
        private Util.ConnectionLibrary ProviderType;
        private readonly Boolean mblnIsConnectionString;
        private Boolean mblnTransactionStart;
        #endregion

        #region Construction Login

        public ConnectionManager()
        {
            if (MakeDefaultConnectionString().IsFalse())
            {
                if (defaultConnectionString.Trim().Length > 0)
                {
                    Initailize(defaultConnectionString);
                }
                else
                {
                    throw new Exception("DAL is not configured properly\n.There is no link between Application Server and Database Server. Please configure the Application Server properly or ask your MIS Officer or technical person to do so.");
                }
            }
        }
        public ConnectionManager(String strConn)
        {
            String connectionString = String.Empty;
            Util.ConnectionLibrary eType = Util.ConnectionLibrary.SQlClient;
            ProvideConnectionInfo(strConn, ref connectionString, ref eType);

            if (connectionString.Trim().Length <= 0)
            {
                throw new Exception(
                    "DAL is not configured properly\n.There is no link between Application Server and Database Server. Please configure the Application Server properly or ask your MIS Officer or technical person to do so.");
            }
            connectionName = strConn;
            Initailize(connectionString, eType);
        }
        public ConnectionManager(String strConn, Util.ConnectionLibrary eType)
        {
            String connectionString = String.Empty;
            ProvideConnectionInfo(strConn, ref connectionString, ref eType);

            if (connectionString.Trim().Length > 0)
            {
                Initailize(connectionString, eType);
            }
            else
            {
                throw new Exception("DAL is not configured properly\n.There is no link between Application Server and Database Server. Please configure the Application Server properly or ask your MIS Officer or technical person to do so.");
            }
        }
        public ConnectionManager(String strConn, Boolean isConnectionString, Util.ConnectionLibrary eType)
        {
            String connectionString = String.Empty;

            if (isConnectionString.IsFalse())
            {
                ProvideConnectionInfo(strConn, ref connectionString, ref eType);
            }
            else
            {
                connectionString = strConn;
                mblnIsConnectionString = true;
            }
            if (connectionString.Trim().Length > 0)
            {
                Initailize(connectionString, eType);
            }
            else
            {
                throw new Exception("DAL is not configured properly\n.There is no link between Application Server and Database Server. Please configure the Application Server properly or ask your MIS Officer or technical person to do so.");
            }
        }
        private Boolean MakeDefaultConnectionString()
        {
            try
            {
                if (DbConfig.ConnectionList.Count.IsZero())
                {
                    return false;
                }
                if (DbConfig.ConnectionList.Count.Equals(1))
                {
                    // Case of only one row
                    return MakeConnectionString(DbConfig.ConnectionList[0]);
                }
                // Case of more than one row:
                Connection defaultConnection = DbConfig.ConnectionList.Find(con => con.Default);
                return defaultConnection.IsNull() ? MakeConnectionString(DbConfig.ConnectionList[0]) : MakeConnectionString(defaultConnection);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private Boolean MakeConnectionString(Connection connection)
        {
            try
            {
                String connectionString = connection.ConnectionString;
                connectionString += String.Format("; {0}", ConnectionTimeOut);
                // Provider
                var provider = connection.Provider;
                Initailize(connectionString, provider);

                return true;

            }
            catch
            {
                return false;
            }
        }
        private void Initailize(String conString)
        {
            Initailize(conString, Util.ConnectionLibrary.SQlClient);
        }
        private void Initailize(String conString, Util.ConnectionLibrary eType)
        {
            ProviderType = eType;
            defaultConnectionString = conString;
        }
        #endregion

        #region Implementation of IConnectionManager

        #region OpenConncetion

        private static Boolean MakeConnectionInfo(Connection connection, ref String conString, ref Util.ConnectionLibrary provider)
        {
            try
            {
                conString = connection.ConnectionString;
                conString += String.Format("; {0}", ConnectionTimeOut);
                // provider
                provider = connection.Provider;
                return true;
            }
            catch
            {
                return false;
            }

        }
        private static Boolean ProvideConnectionInfo(String connName, ref String connectionString, ref Util.ConnectionLibrary providerType)
        {
            try
            {
                if (DbConfig.ConnectionList.Count.Equals(0)) return false;

                Connection connection = DbConfig.ConnectionList.Find(con => con.Name.Equals(connName));

                if (connection.IsNull()) return false;

                return MakeConnectionInfo(connection, ref connectionString, ref providerType);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void OpenConnection()
        {
            OpenConnection(String.Empty);
        }
        public void OpenConnection(String conName)
        {
            try
            {
                if (disconnection.IsNotNull())
                {
                    if (disconnection.State == ConnectionState.Open)
                    {
                        disconnection.Close();
                    }
                    disconnection = null;
                }
                else
                {
                    if (conName.Trim().Length == 0)
                    {
                        switch (ProviderType)
                        {
                            case Util.ConnectionLibrary.SQlClient:
                                disconnection = new SqlConnection();
                                break;
                            case Util.ConnectionLibrary.Oledb:
                                disconnection = new OleDbConnection();
                                break;
                            case Util.ConnectionLibrary.ODBC:
                                disconnection = new OdbcConnection();
                                break;
                        }
                        if (disconnection.IsNotNull()) disconnection.ConnectionString = defaultConnectionString;
                    }
                    else
                    {
                        // Find out the provider and Conncetion String
                        var providerType = new Util.ConnectionLibrary();
                        String connectionString = String.Empty;

                        if (mblnIsConnectionString.IsFalse())
                        {
                            if (ProvideConnectionInfo(conName, ref connectionString, ref providerType).IsFalse())
                            {
                                throw new Exception("Application Server is not configured properly\n.There is no link between Application Server and Database Server. Please configure the Application Server properly or ask your MIS Officer or technical person to do so.");
                            }
                        }
                        else
                        {
                            connectionString = defaultConnectionString;
                        }

                        switch (providerType)
                        {
                            case Util.ConnectionLibrary.SQlClient:
                                disconnection = new SqlConnection();
                                break;
                            case Util.ConnectionLibrary.Oledb:
                                disconnection = new OleDbConnection();
                                break;
                            case Util.ConnectionLibrary.ODBC:
                                disconnection = new OdbcConnection();
                                break;
                        }
                        if (disconnection.IsNotNull()) disconnection.ConnectionString = connectionString;
                    }
                }

                if (disconnection.IsNotNull()) disconnection.Open();
                mblnTransactionStart = false;
            }
            catch (OleDbException oleDbEx)
            {
                throw (oleDbEx);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region BeginTransaction

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
            IsInTransaction = true;
        }


        public void BeginTransaction(IsolationLevel eIsoLation)
        {
            try
            {
                if (disconnection.IsNotNull())
                {
                    transaction = disconnection.BeginTransaction(eIsoLation);
                    mblnTransactionStart = true;
                }
                else
                {
                    if (connectionName.IsNotNullOrEmpty())
                    {
                        OpenConnection(connectionName);
                    }
                    else
                    {
                        OpenConnection();
                    }
                    if (disconnection.IsNotNull()) transaction = disconnection.BeginTransaction(eIsoLation);
                    mblnTransactionStart = true;
                }


            }
            catch (OleDbException oleDbEx)
            {
                throw (oleDbEx);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region CommitTrans

        public void CommitTransaction()
        {
            try
            {

                if (transaction.IsNotNull())
                {
                    transaction.Commit();
                    IsInTransaction = false;
                    mblnTransactionStart = false;
                    CloseConnection();
                }
                else
                {
                    throw new Exception("Transaction Object not Initialized");
                }
            }
            catch (OleDbException oleDbEx)
            {
                throw (oleDbEx);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region RollBack

        public void RollBack()
        {
            try
            {
                if (transaction.IsNotNull())
                {
                    transaction.Rollback();
                    IsInTransaction = false;
                    mblnTransactionStart = false;
                    CloseConnection();
                }
                else
                {
                    throw new Exception("Transaction Object not Initialized");
                }
            }
            catch (OleDbException oleDbEx)
            {
                throw (oleDbEx);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region SaveDataCollectionThroughCollection

        public void SaveDataCollectionThroughCollection(params IEnumerable[] saveItems)
        {
            SaveDataCollectionThroughCollection(false, String.Empty, Util.CrudType.Default, saveItems);
        }
        public void SaveDataCollectionThroughCollection(Boolean requiredTransaction, params IEnumerable[] saveItems)
        {
            SaveDataCollectionThroughCollection(requiredTransaction, String.Empty, Util.CrudType.Default, saveItems);
        }

        //zaki - Insert record and get Scope_Identity()
        public object InsertData(Boolean requiredTransaction, IEnumerable saveItem)
        {
            return SaveDataCollectionThroughCollection(requiredTransaction, String.Empty, Util.CrudType.Default, saveItem);
        }

        public void SaveDataCollectionThroughCollection(Util.CrudType opMode, params IEnumerable[] saveItems)
        {
            SaveDataCollectionThroughCollection(false, String.Empty, opMode, saveItems);
        }
        public void SaveDataCollectionThroughCollection(Boolean requiredTransaction, Util.CrudType opMode, params IEnumerable[] saveItems)
        {
            SaveDataCollectionThroughCollection(requiredTransaction, String.Empty, opMode, saveItems);
        }

        //zaki - Insert record and get Scope_Identity()
        public object SaveDataCollectionThroughCollection(Boolean requiredTransaction, String conName, Util.CrudType opMode, IEnumerable saveItem)
        {
            CommandExecutor command;
            Boolean blnBeginTrans = false;

            CustomList<BaseItem> itemNew;

            try
            {

                if (saveItem.IsNull())
                {
                    throw new Exception("Collection not Initialized");
                }

                if (requiredTransaction.IsFalse())
                {
                    if (conName.Length > 0)
                    {
                        OpenConnection(conName);
                    }
                    else
                    {
                        OpenConnection(String.Empty);
                    }
                }

                if (disconnection.IsNotNull())
                {
                    if (requiredTransaction.IsFalse())
                    {
                        transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                        blnBeginTrans = true;
                    }
                    else
                    {
                        if (transaction.IsNull())
                        {
                            throw new Exception("Transaction is not initialized");
                        }
                        blnBeginTrans = true;
                    }
                }
                else
                {
                    throw new Exception("Connection is not initialized");
                }

                CustomList<BaseItem> saveItemBase = saveItem.ToCustomList<BaseItem>();
                itemNew = saveItemBase.GetChanges(ItemState.Added);
                object retVal = null;

                switch (ProviderType)
                {
                    case Util.ConnectionLibrary.SQlClient:
                        command = new CommandExecutor(transaction, ProviderType);
                        if (itemNew.IsNotNull() && itemNew.Count.NotEquals(0))
                        {
                            retVal = command.Insert(itemNew, Util.OperationType.Insert);
                        }
                        break;

                    default: break;
                }

                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Commit();
                        blnBeginTrans = false;
                    }
                    disconnection.Close();
                    disconnection.Dispose();
                    disconnection = null;
                }

                return retVal;
            }
            catch (OleDbException exOleDb)
            {
                if (blnBeginTrans && requiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }

                throw (exOleDb);
            }
            catch (DBConcurrencyException exDbce)
            {
                if (blnBeginTrans && requiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (exDbce);
            }
            catch (Exception ex)
            {
                if (blnBeginTrans && requiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (ex);
            }
        }













        // This update make the Transaction out from loop!! 
        //So it is possible now to update multiple table in same transaction! No need the BeginTransaction from business layer.
        public void SaveDataCollectionThroughCollection(Boolean requiredTransaction, String conName, Util.CrudType opMode, params IEnumerable[] saveItems)
        {

            if (opMode == Util.CrudType.Delete)
                saveItems = saveItems.Reverse();

            CommandExecutor command;
            Boolean blnBeginTrans = false;

            CustomList<BaseItem> itemNew;
            CustomList<BaseItem> itemUpdate;
            CustomList<BaseItem> itemDelete;

            try
            {

                if (saveItems.IsNull() || saveItems.Count().IsZero())
                {
                    throw new Exception("Collection not Initialized");
                }

                if (requiredTransaction.IsFalse())
                {
                    if (conName.Length > 0)
                    {
                        OpenConnection(conName);
                    }
                    else
                    {
                        OpenConnection(String.Empty);
                    }
                }

                if (disconnection.IsNotNull())
                {
                    if (requiredTransaction.IsFalse())
                    {
                        transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                        blnBeginTrans = true;
                    }
                    else
                    {
                        if (transaction.IsNull())
                        {
                            throw new Exception("Transaction is not initialized");
                        }
                        blnBeginTrans = true;
                    }
                }
                else
                {
                    throw new Exception("Connection is not initialized");
                }

                foreach (IEnumerable saveList in saveItems)
                {
                    CustomList<BaseItem> saveItemBase = saveList.ToCustomList<BaseItem>();

                    switch (opMode)
                    {
                        case Util.CrudType.Default:
                            itemNew = saveItemBase.GetChanges(ItemState.Added);
                            itemUpdate = saveItemBase.GetChanges(ItemState.Modified);
                            itemDelete = saveItemBase.GetChanges(ItemState.Deleted);

                            switch (ProviderType)
                            {
                                case Util.ConnectionLibrary.SQlClient:
                                    command = new CommandExecutor(transaction, ProviderType);
                                    if (itemDelete.IsNotNull() && itemDelete.Count.NotEquals(0))
                                    {
                                        command.Update(itemDelete, Util.OperationType.Delete);
                                    }
                                    if (itemNew.IsNotNull() && itemNew.Count.NotEquals(0))
                                    {
                                        command.Update(itemNew, Util.OperationType.Insert);
                                    }
                                    if (itemUpdate.IsNotNull() && itemUpdate.Count.NotEquals(0))
                                    {
                                        command.Update(itemUpdate, Util.OperationType.Update);
                                    }
                                    break;
                            }
                            break;
                        case Util.CrudType.Insert:
                            itemNew = saveItemBase.GetChanges(ItemState.Added);
                            itemUpdate = saveItemBase.GetChanges(ItemState.Modified);

                            switch (ProviderType)
                            {
                                case Util.ConnectionLibrary.SQlClient:
                                    command = new CommandExecutor(transaction, ProviderType);
                                    if (itemNew.IsNotNull() && itemNew.Count.NotEquals(0))
                                    {
                                        command.Update(itemNew, Util.OperationType.Insert);
                                    }
                                    if (itemUpdate.IsNotNull() && itemUpdate.Count.NotEquals(0))
                                    {
                                        command.Update(itemUpdate, Util.OperationType.Update);
                                    }
                                    break;
                            }
                            break;
                        case Util.CrudType.Delete:
                            itemDelete = saveItemBase.GetChanges(ItemState.Deleted);
                            switch (ProviderType)
                            {
                                case Util.ConnectionLibrary.SQlClient:
                                    command = new CommandExecutor(transaction, ProviderType);
                                    if (itemDelete.IsNotNull() && itemDelete.Count.NotEquals(0))
                                    {
                                        command.Update(itemDelete, Util.OperationType.Delete);
                                    }
                                    break;
                            }
                            break;
                    }
                }

                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Commit();
                        blnBeginTrans = false;
                    }
                    disconnection.Close();
                    disconnection.Dispose();
                    disconnection = null;
                }

            }
            catch (OleDbException exOleDb)
            {
                if (blnBeginTrans && requiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }

                throw (exOleDb);
            }
            catch (DBConcurrencyException exDbce)
            {
                if (blnBeginTrans && requiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (exDbce);
            }
            catch (Exception ex)
            {
                if (blnBeginTrans && requiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (ex);
            }
        }



        public void SaveDataCollectionThroughCollection(Boolean requiredTransaction, String conName, params IEnumerable[] saveItems)
        {
            CommandExecutor command;
            Boolean blnBeginTrans = false;

            CustomList<BaseItem> itemNew;
            CustomList<BaseItem> itemUpdate;
            CustomList<BaseItem> itemDelete;

            try
            {

                if (saveItems.IsNull() || saveItems.Count().IsZero())
                {
                    throw new Exception("Collection not Initialized");
                }

                if (requiredTransaction.IsFalse())
                {
                    if (conName.Length > 0)
                    {
                        OpenConnection(conName);
                    }
                    else
                    {
                        OpenConnection(String.Empty);
                    }
                }

                if (disconnection.IsNotNull())
                {
                    if (requiredTransaction.IsFalse())
                    {
                        transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                        blnBeginTrans = true;
                    }
                    else
                    {
                        if (transaction.IsNull())
                        {
                            throw new Exception("Transaction is not initialized");
                        }
                        blnBeginTrans = true;
                    }
                }
                else
                {
                    throw new Exception("Connection is not initialized");
                }

                //For Delete
                saveItems = saveItems.Reverse();
                foreach (IEnumerable saveList in saveItems)
                {
                    CustomList<BaseItem> saveItemBase = saveList.ToCustomList<BaseItem>();
                    itemDelete = saveItemBase.GetChanges(ItemState.Deleted);

                    switch (ProviderType)
                    {
                        case Util.ConnectionLibrary.SQlClient:
                            command = new CommandExecutor(transaction, ProviderType);
                            if (itemDelete.IsNotNull() && itemDelete.Count.NotEquals(0))
                            {
                                command.Update(itemDelete, Util.OperationType.Delete);
                            }
                            break;
                    }
                }
                //For Insert Update
                saveItems = saveItems.Reverse();
                foreach (IEnumerable saveList in saveItems)
                {
                    CustomList<BaseItem> saveItemBase = saveList.ToCustomList<BaseItem>();

                    itemNew = saveItemBase.GetChanges(ItemState.Added);
                    itemUpdate = saveItemBase.GetChanges(ItemState.Modified);

                    switch (ProviderType)
                    {
                        case Util.ConnectionLibrary.SQlClient:
                            command = new CommandExecutor(transaction, ProviderType);
                            if (itemNew.IsNotNull() && itemNew.Count.NotEquals(0))
                            {
                                command.Update(itemNew, Util.OperationType.Insert);
                            }
                            if (itemUpdate.IsNotNull() && itemUpdate.Count.NotEquals(0))
                            {
                                command.Update(itemUpdate, Util.OperationType.Update);
                            }
                            break;
                    }
                }

                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Commit();
                        blnBeginTrans = false;
                    }
                    disconnection.Close();
                    disconnection.Dispose();
                    disconnection = null;
                }

            }
            catch (OleDbException exOleDb)
            {
                if (blnBeginTrans && requiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }

                throw (exOleDb);
            }
            catch (DBConcurrencyException exDbce)
            {
                if (blnBeginTrans && requiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (exDbce);
            }
            catch (Exception ex)
            {
                if (blnBeginTrans && requiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (ex);
            }
        }

        #endregion

        //#region SaveDataCollectionThroughCollection

        //public void SaveDataCollectionThroughCollection(params IEnumerable[] saveItems)
        //{
        //    SaveDataCollectionThroughCollection(false, String.Empty, saveItems);
        //}
        //public void SaveDataCollectionThroughCollection(Boolean requiredTransaction, params IEnumerable[] saveItems)
        //{
        //    SaveDataCollectionThroughCollection(requiredTransaction, String.Empty, saveItems);
        //}
        //// This update make the Transaction out from loop!! 
        ////So it is possible now to update multiple table in same transaction! No need the BeginTransaction from business layer.
        //public void SaveDataCollectionThroughCollection(Boolean requiredTransaction, String conName, params IEnumerable[] saveItems)
        //{

        //    CommandBuilder command;
        //    Boolean blnBeginTrans = false;
        //    IDbCommand mainCommand;

        //    List<ItemBase> itemNew;
        //    List<ItemBase> itemUpdate;
        //    List<ItemBase> itemDelete;

        //    String tableName;

        //    try
        //    {

        //        if (saveItems == null || saveItems.Count() == 0)
        //        {
        //            throw new Exception("Collection not Initialized");
        //        }

        //        if (!requiredTransaction)
        //        {
        //            if (conName.Length > 0)
        //            {
        //                OpenConnection(conName);
        //            }
        //            else
        //            {
        //                OpenConnection(String.Empty);
        //            }
        //        }

        //        if (disconnection != null)
        //        {
        //            if (!requiredTransaction)
        //            {
        //                transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
        //                blnBeginTrans = true;
        //            }
        //            else
        //            {
        //                if (transaction == null)
        //                {
        //                    throw new Exception("Transaction is not initialized");
        //                }
        //                blnBeginTrans = true;
        //            }

        //            switch (eProviderType)
        //            {
        //                case Util.ConnectionLibrary.SQlClient:
        //                    mainCommand = new SqlCommand();
        //                    break;
        //                case Util.ConnectionLibrary.Oledb:
        //                    mainCommand = new OleDbCommand();
        //                    break;
        //                case Util.ConnectionLibrary.ODBC:
        //                    mainCommand = new OdbcCommand();
        //                    break;
        //                default:
        //                    mainCommand = null;
        //                    break;
        //            }

        //            if (mainCommand != null)
        //            {
        //                mainCommand.Connection = disconnection;
        //                mainCommand.Transaction = transaction;
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Connection is not initialized");
        //        }

        //        if (mainCommand != null) mainCommand.CommandTimeout = CommandTimeOutValue;


        //        foreach (IEnumerable saveEnumerable in saveItems)
        //        {
        //            var saveItemBase = saveEnumerable.Cast<ItemBase>().ToList();

        //            tableName = saveEnumerable.GetTableName();
        //            if ((tableName.Trim()).Length == 0)
        //            {
        //                throw new Exception("Table name is blank");
        //            }

        //            if (mainCommand != null) mainCommand.CommandText = tableName;

        //            itemNew = saveItemBase.GetChanges(ItemState.Added);
        //            itemUpdate = saveItemBase.GetChanges(ItemState.Modified);
        //            itemDelete = saveItemBase.GetChanges(ItemState.Deleted);

        //            switch (eProviderType)
        //            {
        //                case Util.ConnectionLibrary.SQlClient:
        //                    command = new CommandBuilder(mainCommand);
        //                    if (itemDelete != null && itemDelete.Count != 0)
        //                    {
        //                        command.GetDeleteCommand(itemDelete);
        //                        command.Update();
        //                    }
        //                    if (itemNew != null && itemNew.Count != 0)
        //                    {
        //                        command.GetInsertCommand(itemNew);
        //                        command.Update();
        //                    }
        //                    if (itemUpdate != null && itemUpdate.Count != 0)
        //                    {
        //                        command.GetUpdateCommand(itemUpdate);
        //                        command.Update();
        //                    }
        //                    break;
        //            }
        //        }

        //        if (!requiredTransaction)
        //        {
        //            if (blnBeginTrans)
        //            {
        //                transaction.Commit();
        //                blnBeginTrans = false;
        //            }
        //            disconnection.Close();
        //            disconnection.Dispose();
        //            disconnection = null;
        //        }

        //    }
        //    catch (OleDbException exOleDb)
        //    {
        //        if (blnBeginTrans && !requiredTransaction)
        //        {
        //            transaction.Rollback();
        //            if (disconnection != null)
        //            {
        //                if (disconnection.State == ConnectionState.Open)
        //                {
        //                    disconnection.Close();
        //                }
        //                disconnection.Dispose();
        //                disconnection = null;
        //            }
        //        }

        //        throw (exOleDb);
        //    }
        //    catch (DBConcurrencyException exDbce)
        //    {
        //        if (blnBeginTrans && !requiredTransaction)
        //        {
        //            transaction.Rollback();
        //            if (disconnection != null)
        //            {
        //                if (disconnection.State == ConnectionState.Open)
        //                {
        //                    disconnection.Close();
        //                }
        //                disconnection.Dispose();
        //                disconnection = null;
        //            }
        //        }
        //        throw (exDbce);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (blnBeginTrans && !requiredTransaction)
        //        {
        //            transaction.Rollback();
        //            if (disconnection != null)
        //            {
        //                if (disconnection.State == ConnectionState.Open)
        //                {
        //                    disconnection.Close();
        //                }
        //                disconnection.Dispose();
        //                disconnection = null;
        //            }
        //        }
        //        throw (ex);
        //    }
        //}

        //#endregion

        #region OpenDataSetThroughAdapter

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef)
        {
            OpenDataSetThroughAdapter(strSquery, ref dsSetRef, CommandType.Text);
        }

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef, CommandType cmdType)
        {
            OpenDataSetThroughAdapter(strSquery, ref dsSetRef, cmdType, false);
        }

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef,
            Boolean blnRequiredTransaction)
        {
            OpenDataSetThroughAdapter(strSquery, ref dsSetRef, CommandType.Text, blnRequiredTransaction, false, String.Empty, String.Empty);
        }

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef, CommandType cmdType,
            Boolean blnRequiredTransaction)
        {
            OpenDataSetThroughAdapter(strSquery, ref dsSetRef, cmdType, blnRequiredTransaction, false, String.Empty, String.Empty);
        }

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef,
            Boolean blnRequiredTransaction, String strConName)
        {
            OpenDataSetThroughAdapter(strSquery, ref dsSetRef, CommandType.Text, blnRequiredTransaction, false, String.Empty, strConName);
        }

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef, CommandType cmdType,
            Boolean blnRequiredTransaction, String strConName)
        {
            OpenDataSetThroughAdapter(strSquery, ref dsSetRef, cmdType, blnRequiredTransaction, false, String.Empty, strConName);
        }

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef,
            Boolean blnRequiredTransaction, Boolean blnJoinedQuery, String strActualQuery)
        {
            OpenDataSetThroughAdapter(strSquery, ref dsSetRef, CommandType.Text, blnRequiredTransaction, blnJoinedQuery, strActualQuery, String.Empty);
        }

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef, CommandType cmdType,
            Boolean blnRequiredTransaction, Boolean blnJoinedQuery, String strActualQuery)
        {
            OpenDataSetThroughAdapter(strSquery, ref dsSetRef, cmdType, blnRequiredTransaction, blnJoinedQuery, strActualQuery, String.Empty);
        }

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef,
            Boolean blnRequiredTransaction, Boolean blnJoinedQuery, String strActualQuery, String strConName)
        {
            OpenDataSetThroughAdapter(strSquery, ref dsSetRef, CommandType.Text, blnRequiredTransaction, blnJoinedQuery, strActualQuery, strConName);
        }

        public void OpenDataSetThroughAdapter(String strSquery, ref System.Data.DataSet dsSetRef, CommandType cmdType,
            Boolean blnRequiredTransaction, Boolean blnJoinedQuery, String strActualQuery, String strConName)
        {
            System.Data.IDbDataAdapter IDBAdpater;
            System.Data.IDbCommand IMainCommand;
            dsSetRef = new DataSet();
            Boolean blnBeginTrans = false;
            try
            {
                if ((strSquery.Trim()).Length == 0)
                    throw new Exception("Query is blank");

                if (ProviderType == Util.ConnectionLibrary.SQlClient)
                {
                    IMainCommand = new SqlCommand();
                }
                else if (ProviderType == Util.ConnectionLibrary.Oledb)
                {
                    IMainCommand = new OleDbCommand();
                }
                else if (ProviderType == Util.ConnectionLibrary.ODBC)
                {
                    IMainCommand = new OdbcCommand();
                }
                else
                {
                    IMainCommand = null;
                }

                IMainCommand.CommandTimeout = CommandTimeOutValue;

                if (blnRequiredTransaction == false)
                {
                    if (strConName.Length > 0)
                    {
                        OpenConnection(strConName);
                    }
                    else
                    {
                        OpenConnection(String.Empty);
                    }

                    transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                    blnBeginTrans = true;
                }
                else
                {
                    if (mblnTransactionStart)
                    {
                        blnBeginTrans = true;
                    }
                }

                if (disconnection.IsNotNull() && disconnection.State == ConnectionState.Open)
                {
                    IMainCommand.CommandText = strSquery;
                    IMainCommand.CommandType = cmdType;
                    IMainCommand.Connection = disconnection;
                    if (blnBeginTrans)
                    {
                        IMainCommand.Transaction = transaction;
                    }

                    if (ProviderType == Util.ConnectionLibrary.SQlClient)
                    {
                        IDBAdpater = new SqlDataAdapter((SqlCommand)IMainCommand);
                    }

                    else if (ProviderType == Util.ConnectionLibrary.Oledb)
                    {
                        IDBAdpater = new OleDbDataAdapter((OleDbCommand)IMainCommand);
                    }
                    else if (ProviderType == Util.ConnectionLibrary.ODBC)
                    {
                        IDBAdpater = new OdbcDataAdapter((OdbcCommand)IMainCommand);
                    }
                    else
                    {
                        IDBAdpater = null;
                    }
                    //IDBAdpater.FillSchema(dsSetRef,SchemaType.Mapped);
                    IDBAdpater.Fill(dsSetRef);

                    foreach (DataTable dt in dsSetRef.Tables)
                    {
                        dt.ExtendedProperties.Add(Query, strSquery);
                        dt.ExtendedProperties.Add(UpdateQuery, strActualQuery);
                        dt.ExtendedProperties.Add(JoinedQuery, blnJoinedQuery);

                    }
                }
                if (blnRequiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Commit();
                        blnBeginTrans = false;
                    }
                }
                return;
            }

            catch (System.Data.OleDb.OleDbException OleDbEx)
            {
                if (blnBeginTrans && blnRequiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                }
                throw (OleDbEx);
            }
            catch (System.Exception ex)
            {
                if (blnBeginTrans && blnRequiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                }
                throw ex;
            }
            finally
            {
                if (blnRequiredTransaction.IsFalse() && disconnection.IsNotNull())
                {
                    disconnection.Close();
                    disconnection.Dispose();
                    disconnection = null;

                    mblnTransactionStart = false;
                }
                IMainCommand = null;
                IDBAdpater = null;
            }
        }
        #endregion

        #region SaveDataSetThroughAdapter
        public void SaveDataSetThroughAdapter(System.Data.DataSet dsSetRef)
        {
            SaveDataSetThroughAdapter(dsSetRef, false, String.Empty, String.Empty);
        }

        public void SaveDataSetThroughAdapter(System.Data.DataSet dsSetRef,
            Boolean blnRequiredTransaction)
        {
            SaveDataSetThroughAdapter(dsSetRef, blnRequiredTransaction, String.Empty, String.Empty);
        }

        public void SaveDataSetThroughAdapter(System.Data.DataSet dsSetRef,
            Boolean blnRequiredTransaction, String ExcludeTableName)
        {
            SaveDataSetThroughAdapter(dsSetRef, blnRequiredTransaction, ExcludeTableName, String.Empty);
        }

        public void SaveDataSetThroughAdapter(System.Data.DataSet dsSetRef,
            Boolean blnRequiredTransaction, String ExcludeTableName, String strConName)
        {

            Boolean blnBeginTrans = false;
            OleDbDataAdapter objOleDBAdpater;
            OdbcDataAdapter objOdbcDBAdpater;
            SqlDataAdapter objSqlDBAdpater;

            OdbcCommandBuilder objOdbcDBCommandBuilder;
            OleDbCommandBuilder objOleDBCommandBuilder;
            SqlCommandBuilder objSqlDBCommandBuilder;

            IDbCommand IMainCommand;

            DataTable dtInsert;
            DataTable dtUpdate;
            DataTable dtDelete;
            Boolean TableExist;
            String strQuery;

            try
            {

                if (dsSetRef == null)
                {
                    throw new Exception("DataSet not Initialized");
                }

                String[] TableName;

                char[] delimeter;
                String seperator;
                seperator = ",";
                delimeter = seperator.ToCharArray();
                TableName = ExcludeTableName.Split(delimeter);


                if (blnRequiredTransaction.IsFalse())
                {
                    if (strConName.Length > 0)
                    {
                        OpenConnection(strConName);
                    }
                    else
                    {
                        OpenConnection(String.Empty);
                    }
                }

                if (disconnection.IsNotNull())
                {
                    if (blnRequiredTransaction.IsFalse())
                    {
                        transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                        blnBeginTrans = true;
                    }
                    else
                    {
                        if (transaction == null)
                        {
                            throw new Exception("Transaction is not initialized");
                        }
                        else
                        {
                            blnBeginTrans = true;
                        }
                    }

                    if (ProviderType == Util.ConnectionLibrary.SQlClient)
                    {
                        IMainCommand = new SqlCommand();
                    }
                    else if (ProviderType == Util.ConnectionLibrary.Oledb)
                    {
                        IMainCommand = new OleDbCommand();
                    }
                    else if (ProviderType == Util.ConnectionLibrary.ODBC)
                    {
                        IMainCommand = new OdbcCommand();
                    }
                    else
                    {
                        IMainCommand = null;
                    }

                    IMainCommand.Connection = disconnection;
                    IMainCommand.Transaction = transaction;
                }
                else
                {
                    throw new Exception("Connection is not initialized");
                }

                IMainCommand.CommandTimeout = CommandTimeOutValue;

                foreach (DataTable dtRef in dsSetRef.Tables)
                {
                    TableExist = false;
                    foreach (String tablename in TableName)
                    {
                        if (dtRef.TableName.ToUpper() == tablename.ToUpper())
                        {
                            TableExist = true;
                            break;
                        }
                    }
                    if (TableExist) continue;


                    if ((Boolean)dtRef.ExtendedProperties[JoinedQuery])
                    {
                        strQuery = dtRef.ExtendedProperties[UpdateQuery].ToString();
                    }
                    else
                    {
                        strQuery = dtRef.ExtendedProperties[Query].ToString();
                    }


                    if ((strQuery.Trim()).Length == 0)
                    {
                        throw new Exception("Query is blank");
                    }

                    IMainCommand.CommandText = strQuery;

                    dtInsert = dtRef.GetChanges(DataRowState.Added);
                    dtUpdate = dtRef.GetChanges(DataRowState.Modified);
                    dtDelete = dtRef.GetChanges(DataRowState.Deleted);

                    if (ProviderType == Util.ConnectionLibrary.SQlClient)
                    {
                        objSqlDBAdpater = new SqlDataAdapter((SqlCommand)IMainCommand);
                        objSqlDBCommandBuilder = new SqlCommandBuilder(objSqlDBAdpater);

                        if (dtDelete.IsNotNull())
                        {
                            objSqlDBCommandBuilder.GetDeleteCommand();
                            objSqlDBAdpater.Update(dtDelete);
                            dtDelete.Dispose();
                            dtDelete = null;
                        }

                        if (dtInsert.IsNotNull())
                        {
                            objSqlDBCommandBuilder.GetInsertCommand();
                            objSqlDBAdpater.Update(dtInsert);
                            dtInsert.Dispose();
                            dtInsert = null;
                        }

                        if (dtUpdate.IsNotNull())
                        {
                            objSqlDBCommandBuilder.GetUpdateCommand();
                            objSqlDBAdpater.Update(dtUpdate);

                            dtUpdate.Dispose();
                            dtUpdate = null;
                        }
                    }

                    else if (ProviderType == Util.ConnectionLibrary.Oledb)
                    {
                        objOleDBAdpater = new OleDbDataAdapter((OleDbCommand)IMainCommand);
                        objOleDBCommandBuilder = new OleDbCommandBuilder(objOleDBAdpater);
                        if (dtInsert.IsNotNull())
                        {
                            objOleDBCommandBuilder.GetInsertCommand();
                            objOleDBAdpater.Update(dtInsert);
                            dtInsert.Dispose();
                            dtInsert = null;
                        }

                        if (dtUpdate.IsNotNull())
                        {
                            objOleDBCommandBuilder.GetUpdateCommand();
                            objOleDBAdpater.Update(dtUpdate);
                            dtUpdate.Dispose();
                            dtUpdate = null;
                        }

                        if (dtDelete.IsNotNull())
                        {
                            objOleDBCommandBuilder.GetDeleteCommand();
                            objOleDBAdpater.Update(dtDelete);
                            dtDelete.Dispose();
                            dtDelete = null;
                        }
                    }
                    else if (ProviderType == Util.ConnectionLibrary.ODBC)
                    {
                        objOdbcDBAdpater = new OdbcDataAdapter((OdbcCommand)IMainCommand);
                        objOdbcDBCommandBuilder = new OdbcCommandBuilder(objOdbcDBAdpater);
                        if (dtInsert.IsNotNull())
                        {
                            objOdbcDBCommandBuilder.GetInsertCommand();
                            objOdbcDBAdpater.Update(dtInsert);
                            dtInsert.Dispose();
                            dtInsert = null;
                        }
                        if (dtUpdate.IsNotNull())
                        {
                            objOdbcDBCommandBuilder.GetUpdateCommand();
                            objOdbcDBAdpater.Update(dtUpdate);
                            dtUpdate.Dispose();
                            dtUpdate = null;
                        }
                        if (dtDelete.IsNotNull())
                        {
                            objOdbcDBCommandBuilder.GetDeleteCommand();
                            objOdbcDBAdpater.Update(dtDelete);
                            dtDelete.Dispose();
                            dtDelete = null;
                        }
                    }
                    else
                    {
                        objSqlDBAdpater = null;
                        objOleDBAdpater = null;
                        objOdbcDBAdpater = null;
                        objSqlDBCommandBuilder = null;
                        objOleDBCommandBuilder = null;
                        objOdbcDBCommandBuilder = null;
                    }

                }


                if (blnRequiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Commit();
                        blnBeginTrans = false;
                    }
                    disconnection.Close();
                    disconnection.Dispose();
                    disconnection = null;
                }

            }
            catch (System.Data.OleDb.OleDbException exOleDb)
            {
                if (blnBeginTrans && blnRequiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == System.Data.ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (exOleDb);
            }
            catch (System.Data.DBConcurrencyException exDBCE)
            {
                if (blnBeginTrans && blnRequiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == System.Data.ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (exDBCE);
            }
            catch (System.Exception ex)
            {
                if (blnBeginTrans && blnRequiredTransaction.IsFalse())
                {
                    transaction.Rollback();
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == System.Data.ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (ex);
            }
            finally
            {

                if (ProviderType == Util.ConnectionLibrary.SQlClient)
                {
                    IMainCommand = null;
                    objSqlDBAdpater = null;
                    objSqlDBCommandBuilder = null;

                }
                else if (ProviderType == Util.ConnectionLibrary.Oledb)
                {
                    IMainCommand = null;
                    objOleDBAdpater = null;
                    objOleDBCommandBuilder = null;

                }
                else if (ProviderType == Util.ConnectionLibrary.ODBC)
                {
                    IMainCommand = null;
                    objOdbcDBAdpater = null;
                    objOdbcDBCommandBuilder = null;
                }
            }
        }
        #endregion

        #region CloseConnection


        public void CloseConnection()
        {
            try
            {
                if (disconnection.IsNotNull() && disconnection.State == ConnectionState.Open)
                {
                    disconnection.Close();
                    disconnection.Dispose();
                    disconnection = null;
                    mblnTransactionStart = false;
                }
            }
            catch (Exception e3)
            {
                throw (e3);
            }
        }
        #endregion

        #region ExecuteScalarWrapper

        public Object ExecuteScalarWrapper(String query)
        {
            return ExecuteScalarWrapper(query, false, String.Empty);
        }


        public Object ExecuteScalarWrapper(String query, Boolean requiredTransaction)
        {
            return ExecuteScalarWrapper(query, requiredTransaction, String.Empty);
        }

        // As OpenDataSetThroughAdapter and ExecuteNonQueryWrapper, this mothod also modified
        // so that it can able to hold a transaction for store procedure containing multiple 
        // action query. So that it is now not required to make explicite transaction for DAL
        // from the business layer. (DATE: Sat, 18 June, 2005)
        public Object ExecuteScalarWrapper(String query, Boolean requiredTransaction, String conName)
        {
            IDbCommand mainCommand;
            Boolean blnBeginTrans = false;
            try
            {
                if ((query.Trim()).Length.IsZero())
                    throw new Exception("Query is blank");

                switch (ProviderType)
                {
                    case Util.ConnectionLibrary.SQlClient:
                        mainCommand = new SqlCommand();
                        break;
                    case Util.ConnectionLibrary.Oledb:
                        mainCommand = new OleDbCommand();
                        break;
                    case Util.ConnectionLibrary.ODBC:
                        mainCommand = new OdbcCommand();
                        break;
                    default:
                        mainCommand = null;
                        break;
                }
                object objRtValue = null;
                if (mainCommand.IsNotNull())
                {
                    mainCommand.CommandTimeout = CommandTimeOutValue;

                    if (requiredTransaction.IsFalse())
                    {
                        if (conName.Length > 0)
                        {
                            OpenConnection(conName);
                        }
                        else
                        {
                            OpenConnection(String.Empty);
                        }
                        transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                        blnBeginTrans = true;
                        mainCommand.Transaction = transaction;
                    }
                    else
                    {
                        mainCommand.Transaction = transaction;
                        blnBeginTrans = true;
                    }
                    mainCommand.Connection = disconnection;
                    mainCommand.CommandText = query;
                    objRtValue = mainCommand.ExecuteScalar();
                }

                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Commit();
                        blnBeginTrans = false;
                    }
                }

                return objRtValue;
            }
            catch (Exception ex)
            {
                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Rollback();
                    }
                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (ex);
            }
            finally
            {
                if (requiredTransaction.IsFalse())
                {
                    CloseConnection();
                }
            }
        }

        public Object ExecuteScalarWrapper(String spName, params Object[] parameterValues)
        {
            return ExecuteScalarWrapper(false, String.Empty, spName, parameterValues);
        }

        public Object ExecuteScalarWrapper(String conName, String spName, params Object[] parameterValues)
        {
            return ExecuteScalarWrapper(false, conName, spName, parameterValues);
        }

        public Object ExecuteScalarWrapper(Boolean requiredTransaction, String conName, String spName, params Object[] parameterValues)
        {
            Boolean blnBeginTrans = false;
            try
            {
                if ((spName.Trim()).Length.IsZero())
                    throw new Exception("spName is blank");

                Object objRtValue = null;

                if (requiredTransaction.IsFalse())
                {
                    if (conName.Length > 0)
                    {
                        OpenConnection(conName);
                    }
                    else
                    {
                        OpenConnection(String.Empty);
                    }
                    transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                    blnBeginTrans = true;
                }
                else
                {
                    blnBeginTrans = true;
                }

                objRtValue = DataAccessHelper.ExecuteScalar(transaction, spName, parameterValues);

                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Commit();
                        blnBeginTrans = false;
                    }
                }

                return objRtValue;
            }
            catch (Exception ex)
            {
                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Rollback();
                    }
                }
                throw (ex);
            }
            finally
            {
                if (requiredTransaction.IsFalse())
                {
                    CloseConnection();
                }
            }

        }

        #endregion

        #region ExecuteNonQueryWrapper


        public int ExecuteNonQueryWrapper(String query)
        {
            return ExecuteNonQueryWrapper(query, false, String.Empty);
        }


        public int ExecuteNonQueryWrapper(String query, Boolean requiredTransaction)
        {
            return ExecuteNonQueryWrapper(query, requiredTransaction, String.Empty);
        }
        //It is again modified so that it can hold a transaction for storeprocedure which contain multiple action query (18 June, 2005)
        public int ExecuteNonQueryWrapper(String query, Boolean requiredTransaction, String conName)
        {
            IDbCommand mainCommand;
            Boolean blnBeginTrans = false;
            try
            {
                if ((query.Trim()).Length.IsZero())
                    throw new Exception("Query is blank");

                switch (ProviderType)
                {
                    case Util.ConnectionLibrary.SQlClient:
                        mainCommand = new SqlCommand();
                        break;
                    case Util.ConnectionLibrary.Oledb:
                        mainCommand = new OleDbCommand();
                        break;
                    case Util.ConnectionLibrary.ODBC:
                        mainCommand = new OdbcCommand();
                        break;
                    default:
                        mainCommand = null;
                        break;
                }
                if (requiredTransaction.IsFalse())
                {
                    if (conName.Length > 0)
                    {
                        OpenConnection(conName);
                    }
                    else
                    {
                        OpenConnection(String.Empty);
                    }
                    transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                    blnBeginTrans = true;
                    if (mainCommand.IsNotNull()) mainCommand.Transaction = transaction;
                }
                else
                {
                    if (mainCommand.IsNotNull()) mainCommand.Transaction = transaction;
                    blnBeginTrans = true;
                }
                int rtValue = 0;
                if (mainCommand.IsNotNull())
                {
                    mainCommand.CommandTimeout = CommandTimeOutValue;

                    mainCommand.Connection = disconnection;
                    mainCommand.CommandText = query;
                    rtValue = mainCommand.ExecuteNonQuery();
                }

                if (requiredTransaction.IsFalse())
                {
                    if (true)
                    {
                        transaction.Commit();
                        blnBeginTrans = false;
                    }
                }

                return rtValue;

            }
            catch (Exception ex)
            {
                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Rollback();
                    }

                    if (disconnection.IsNotNull())
                    {
                        if (disconnection.State == ConnectionState.Open)
                        {
                            disconnection.Close();
                        }
                        disconnection.Dispose();
                        disconnection = null;
                    }
                }
                throw (ex);
            }
            finally
            {
                if (requiredTransaction.IsFalse())
                {
                    CloseConnection();
                }
            }
        }

        public Object ExecuteNonQueryWrapper(String spName, params Object[] parameterValues)
        {
            return ExecuteNonQueryWrapper(false, String.Empty, spName, parameterValues);
        }

        public Object ExecuteNonQueryWrapper(String conName, String spName, params Object[] parameterValues)
        {
            return ExecuteNonQueryWrapper(false, conName, spName, parameterValues);
        }

        public Object ExecuteNonQueryWrapper(Boolean requiredTransaction, String conName, String spName, params Object[] parameterValues)
        {
            Boolean blnBeginTrans = false;
            try
            {
                if ((spName.Trim()).Length.IsZero())
                    throw new Exception("spName is blank");

                int objRtValue = 0;

                if (requiredTransaction.IsFalse())
                {
                    if (conName.Length > 0)
                    {
                        OpenConnection(conName);
                    }
                    else
                    {
                        OpenConnection(String.Empty);
                    }
                    transaction = disconnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                    blnBeginTrans = true;
                }
                else
                {
                    blnBeginTrans = true;
                }

                objRtValue = DataAccessHelper.ExecuteNonQuery(transaction, spName, parameterValues);

                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Commit();
                        blnBeginTrans = false;
                    }
                }

                return objRtValue;
            }
            catch (Exception ex)
            {
                if (requiredTransaction.IsFalse())
                {
                    if (blnBeginTrans)
                    {
                        transaction.Rollback();
                    }
                }
                throw (ex);
            }
            finally
            {
                if (requiredTransaction.IsFalse())
                {
                    CloseConnection();
                }
            }

        }
        #endregion

        #region OpenDataReader

        public void OpenDataReader(String query, out IDataReader readerRef)
        {
            OpenDataReader(query, out readerRef, CommandBehavior.CloseConnection, false, String.Empty, null, String.Empty);
        }

        public void OpenDataReader(String query, out IDataReader readerRef, CommandBehavior behavior)
        {
            OpenDataReader(query, out readerRef, behavior, false, String.Empty, null, String.Empty);
        }

        public void OpenDataReader(String query, out IDataReader readerRef, CommandBehavior behavior, Boolean requiredTransaction)
        {
            OpenDataReader(query, out readerRef, behavior, requiredTransaction, String.Empty, null, String.Empty);
        }

        public void OpenDataReader(String query, out IDataReader readerRef, CommandBehavior behaviour, Boolean requiredTransaction, String procedureName)
        {
            OpenDataReader(query, out readerRef, behaviour, requiredTransaction, procedureName, null, String.Empty);
        }

        public void OpenDataReader(String query, out IDataReader readerRef,
            CommandBehavior behaviour, Boolean requiredTransaction, String
            procedureName, IDbDataParameter[] oleDbParameterArray)
        {
            OpenDataReader(query, out readerRef, behaviour, requiredTransaction, procedureName, oleDbParameterArray, String.Empty);
        }

        public void OpenDataReader(String query, out IDataReader readerRef,
            CommandBehavior behaviour, Boolean requiredTransaction, String procedureName,
            IDbDataParameter[] oleDbParameterArray, String conName)
        {
            IDbCommand mainCommand;
            try
            {
                if ((procedureName.Trim()).Length.IsZero())
                {
                    if ((query.Trim()).Length.IsZero())
                        throw new Exception("Query is blank");
                }

                switch (ProviderType)
                {
                    case Util.ConnectionLibrary.SQlClient:
                        mainCommand = new SqlCommand();
                        break;
                    case Util.ConnectionLibrary.Oledb:
                        mainCommand = new OleDbCommand();
                        break;
                    case Util.ConnectionLibrary.ODBC:
                        mainCommand = new OdbcCommand();
                        break;
                    default:
                        mainCommand = null;
                        break;
                }

                if (mainCommand.IsNull())
                {
                    readerRef = null;
                    return;
                }
                if (requiredTransaction.IsFalse())
                {
                    if (conName.Length > 0)
                    {
                        OpenConnection(conName);
                    }
                    else
                    {
                        OpenConnection(String.Empty);
                    }
                }
                else
                {
                    mainCommand.Transaction = transaction;
                }

                if ((procedureName.Trim()).Length.IsZero())
                {
                    mainCommand.CommandType = CommandType.Text;
                    mainCommand.CommandText = query;

                }
                else if (oleDbParameterArray.IsNull() && (procedureName.Trim()).Length > 0)
                {
                    mainCommand.CommandType = CommandType.StoredProcedure;
                    mainCommand.CommandText = procedureName;

                }
                else if (oleDbParameterArray.IsNotNull() && (procedureName.Trim()).Length > 0)
                {
                    mainCommand.CommandType = CommandType.StoredProcedure;
                    mainCommand.CommandText = procedureName;
                    for (Int32 i = 0; i < oleDbParameterArray.Length; i++)
                    {
                        if (oleDbParameterArray[i].IsNotNull())
                        {
                            mainCommand.Parameters.Add(oleDbParameterArray[i]);
                        }
                    }
                }
                else
                {
                    throw new Exception("Could Not Create the Command Object");
                }

                mainCommand.CommandTimeout = CommandTimeOutValue;

                mainCommand.Connection = disconnection;


                readerRef = mainCommand.ExecuteReader(behaviour);
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw (ex);
            }

        }

        public void OpenDataReader(out IDataReader readerRef, String spName, params Object[] parameterValues)
        {
            try
            {
                OpenConnection(String.Empty);
                readerRef = DataAccessHelper.ExecuteReader(disconnection, spName, parameterValues);
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw (ex);
            }
        }
        #endregion
        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            if (ProviderType == Util.ConnectionLibrary.SQlClient)
            {

            }
            else if (ProviderType == Util.ConnectionLibrary.Oledb)
            {

            }
            else if (ProviderType == Util.ConnectionLibrary.ODBC)
            {

            }

        }


        #endregion

        #region TestSqlConnection
        public Boolean TestSqlConnection(String conString)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn.IsNotNull())
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
            }
        }
        #endregion

    }
    #endregion
}
