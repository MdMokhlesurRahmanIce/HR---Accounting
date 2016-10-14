using System;
using System.Collections;
using System.Data;


namespace ASL.DAL
{
    /// <summary>
    /// Summary description for IConnectionManager.
    /// </summary>
    /// 	

    interface IConnectionManager
    {

        void OpenConnection();
        void OpenConnection(String conName);

        /*
         'Chaos          =   The pending changes from more highly isolated transactions cannot be overwritten. 

         'ReadCommitted  =   Shared locks are held while the data is being read to avoid dirty reads, 
         '                   but the data can be changed before the end of the transaction, 
         '                   resulting in non-repeatable reads or phantom data. 

         'ReadUncommitted=   A dirty read is possible, meaning that no shared locks are issued and no 
         '                   exclusive locks are honored. 

         'RepeatableRead =   Locks are placed on all data that is used in a query, preventing other 
         '                   users from updating the data. Prevents non-repeatable reads but phantom rows 
         '                   are still possible. 

         'Serializable   =   A range lock is palced on the DataSet, preventing other 
         '                   users from updating or inserting rows into the dataset 
         '                   until the transaction is complete. 

         'Unspecified    =   A different isolation level than the one specified is being used, 
         '                   but the level cannot be determined. 

         'RepeatableRead ,Serializable are not Support with MS-Access
         */
        void BeginTransaction();
        void BeginTransaction(IsolationLevel eIsoLation);

        void CommitTransaction();

        void RollBack();

        #region CloseConnection
        void CloseConnection();
        #endregion

        #region ExecuteScalarWrapper
        object ExecuteScalarWrapper(String query);
        object ExecuteScalarWrapper(String query, Boolean requiredTransaction);
        object ExecuteScalarWrapper(String query, Boolean requiredTransaction, String conName);
        #endregion

        #region ExecuteNonQueryWrapper
        Int32 ExecuteNonQueryWrapper(String query);
        Int32 ExecuteNonQueryWrapper(String query, Boolean requiredTransaction);
        Int32 ExecuteNonQueryWrapper(String query, Boolean requiredTransaction, String conName);
        #endregion

        #region OpenDataReader
        void OpenDataReader(String query, out IDataReader drReaderRef,
            CommandBehavior behavior, Boolean requiredTransaction);

        void OpenDataReader(String query, out IDataReader drReaderRef,
            CommandBehavior behavior, Boolean requiredTransaction, String procedureName);

        void OpenDataReader(String query, out IDataReader drReaderRef,
            CommandBehavior behavior, Boolean requiredTransaction, String procedureName,
            IDbDataParameter[] oleDbParameterArray);

        void OpenDataReader(String query, out IDataReader drReaderRef,
            CommandBehavior behavior, Boolean requiredTransaction, String procedureName,
            IDbDataParameter[] oleDbParameterArray, String conName);
        #endregion

        #region SaveDataCollectionThroughCollection
        void SaveDataCollectionThroughCollection(params IEnumerable[] saveItems);
        void SaveDataCollectionThroughCollection(Boolean requiredTransaction, params IEnumerable[] saveItems);
        void SaveDataCollectionThroughCollection(Util.CrudType opMode, params IEnumerable[] saveItems);
        void SaveDataCollectionThroughCollection(Boolean requiredTransaction, Util.CrudType opMode, params IEnumerable[] saveItems);
        void SaveDataCollectionThroughCollection(Boolean requiredTransaction, String conName, Util.CrudType opMode, params IEnumerable[] saveItems);

        #endregion

        #region OpenDataSetThroughAdapter
        void OpenDataSetThroughAdapter(String strSquery, ref DataSet dsSetRef);

        void OpenDataSetThroughAdapter(String strSquery, ref DataSet dsSetRef, CommandType cmddType);

        void OpenDataSetThroughAdapter(String strSquery, ref DataSet dsSetRef, bool blnRequiredTransaction);

        void OpenDataSetThroughAdapter(String strSquery, ref DataSet dsSetRef, CommandType cmddType, bool blnRequiredTransaction);

        void OpenDataSetThroughAdapter(String strSquery, ref DataSet dsSetRef, bool blnRequiredTransaction, String strConName);

        void OpenDataSetThroughAdapter(String strSquery, ref DataSet dsSetRef, CommandType cmddType, bool blnRequiredTransaction, String strConName);

        void OpenDataSetThroughAdapter(String strSquery, ref DataSet dsSetRef, bool blnRequiredTransaction, bool blnJoinedQuery, String strActualUpdateQuery, String strConName);

        void OpenDataSetThroughAdapter(String strSquery, ref DataSet dsSetRef, CommandType cmddType, bool blnRequiredTransaction, bool blnJoinedQuery, String strActualUpdateQuery, String strConName);
        #endregion

        #region SaveDataSetThroughAdapter
        void SaveDataSetThroughAdapter(System.Data.DataSet dsSetRef);

        void SaveDataSetThroughAdapter(System.Data.DataSet dsSetRef, bool blnRequiredTransaction);

        void SaveDataSetThroughAdapter(System.Data.DataSet dsSetRef, bool blnRequiredTransaction, string ExcludeTableName);

        void SaveDataSetThroughAdapter(System.Data.DataSet dsSetRef, bool blnRequiredTransaction, string ExcludeTableName, string strConName);
        #endregion
    }
}
