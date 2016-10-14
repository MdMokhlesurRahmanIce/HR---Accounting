using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ASL.DAL
{
    internal sealed class DataAccessHelper
    {
        public static Util.ConnectionLibrary ProviderType = Util.ConnectionLibrary.SQlClient;
        private static void AssignParameterValues(IDbDataParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters != null) && (dataRow != null))
            {
                int num = 0;
                foreach (IDbDataParameter parameter in commandParameters)
                {
                    if ((parameter.ParameterName == null) || (parameter.ParameterName.Length <= 1))
                    {
                        throw new Exception(String.Format("Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.", num, parameter.ParameterName));
                    }
                    if (dataRow.Table.Columns.IndexOf(parameter.ParameterName.Substring(1)) != -1)
                    {
                        parameter.Value = dataRow[parameter.ParameterName.Substring(1)];
                    }
                    num++;
                }
            }
        }

        private static void AssignParameterValues(IDbDataParameter[] commandParameters, Object[] parameterValues)
        {
            if ((commandParameters != null) && (parameterValues != null))
            {
                if (commandParameters.Length != parameterValues.Length)
                {
                    throw new ArgumentException("Parameter count does not match Parameter Value count.");
                }
                int index = 0;
                int length = commandParameters.Length;
                while (index < length)
                {
                    if (parameterValues[index] is IDbDataParameter)
                    {
                        IDbDataParameter parameter = (IDbDataParameter)parameterValues[index];
                        if (parameter.Value == null)
                        {
                            commandParameters[index].Value = DBNull.Value;
                        }
                        else
                        {
                            commandParameters[index].Value = parameter.Value;
                        }
                    }
                    else if (parameterValues[index] == null)
                    {
                        commandParameters[index].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[index].Value = parameterValues[index];
                    }
                    index++;
                }
            }
        }

        private static void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {            
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (commandParameters != null)
            {
                foreach (IDbDataParameter parameter in commandParameters)
                {
                    if (parameter != null)
                    {
                        if (((parameter.Direction == ParameterDirection.InputOutput) || (parameter.Direction == ParameterDirection.Input)) && (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }
            }
        }

        public static IDbCommand CreateCommand(IDbConnection connection, String spName, params String[] sourceColumns)
        {
            IDbCommand command = null;
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand(spName, (SqlConnection)connection);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand(spName, (OleDbConnection)connection);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand(spName, (OdbcConnection)connection);
                    break;
                default:
                    command = null;
                    break;
            }

            
            command.CommandType = CommandType.StoredProcedure;
            if ((sourceColumns != null) && (sourceColumns.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                for (int i = 0; i < sourceColumns.Length; i++)
                {
                    spParameterSet[i].SourceColumn = sourceColumns[i];
                }
                AttachParameters(command, spParameterSet);
            }
            return command;
        }

        public static DataSet ExecuteDataset(IDbConnection connection, CommandType commandType, String commandText)
        {
            return ExecuteDataset(connection, commandType, commandText, null);
        }

        public static DataSet ExecuteDataset(IDbConnection connection, String spName, params Object[] parameterValues)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteDataset(connection, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
        }

        public static DataSet ExecuteDataset(IDbTransaction transaction, CommandType commandType, String commandText)
        {            
            return ExecuteDataset(transaction, commandType, commandText, null);
        }

        public static DataSet ExecuteDataset(IDbTransaction transaction, String spName, params Object[] parameterValues)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
        }

        public static DataSet ExecuteDataset(String connectionString, CommandType commandType, String commandText)
        {
            return ExecuteDataset(connectionString, commandType, commandText, null);
        }

        public static DataSet ExecuteDataset(String connectionString, String spName, params Object[] parameterValues)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
        }

        public static DataSet ExecuteDataset(IDbConnection connection, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            IDbCommand command = null;
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand();
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand();
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand();
                    break;
                default:
                    command = null;
                    break;
            }
            bool mustCloseConnection = false;
            PrepareCommand(command, connection, null, commandType, commandText, commandParameters, out mustCloseConnection);

            IDbDataAdapter adapter = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    adapter = new SqlDataAdapter((SqlCommand)command);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    adapter = new OleDbDataAdapter((OleDbCommand)command);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    adapter = new OdbcDataAdapter((OdbcCommand)command);
                    break;
                default:
                    adapter = null;
                    break;
            }

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            command.Parameters.Clear();
            if (mustCloseConnection)
            {
                connection.Close();
            }
            return dataSet;
        }

        public static DataSet ExecuteDataset(IDbTransaction transaction, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            IDbCommand command = null;
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand();
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand();
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand();
                    break;
                default:
                    command = null;
                    break;
            }
            bool mustCloseConnection = false;
            PrepareCommand(command, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            IDbDataAdapter adapter = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    adapter = new SqlDataAdapter((SqlCommand)command);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    adapter = new OleDbDataAdapter((OleDbCommand)command);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    adapter = new OdbcDataAdapter((OdbcCommand)command);
                    break;
                default:
                    adapter = null;
                    break;
            }

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            command.Parameters.Clear();
            return dataSet;
        }

        public static DataSet ExecuteDataset(String connectionString, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            IDbConnection connection = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    connection = new SqlConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    connection = new OleDbConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    connection = new OdbcConnection(connectionString);
                    break;
                default:
                    connection = null;
                    break;
            }
            connection.Open();
            return ExecuteDataset(connection, commandType, commandText, commandParameters);
        }

        public static DataSet ExecuteDatasetTypedParams(IDbConnection connection, String spName, DataRow dataRow)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteDataset(connection, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
        }

        public static DataSet ExecuteDatasetTypedParams(IDbTransaction transaction, String spName, DataRow dataRow)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
        }

        public static DataSet ExecuteDatasetTypedParams(String connectionString, String spName, DataRow dataRow)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
        }

        public static int ExecuteNonQueryProcedure(IDbTransaction transaction, String spName, params Object[] parameterValues)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
        }


        public static int ExecuteNonQuery(IDbConnection connection, CommandType commandType, String commandText)
        {
            return ExecuteNonQuery(connection, commandType, commandText, (int?)null);
        }

        public static int ExecuteNonQuery(IDbConnection connection, String spName, params Object[] parameterValues)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
        }

        public static int ExecuteNonQuery(IDbTransaction transaction, CommandType commandType, String commandText)
        {
            return ExecuteNonQuery(transaction, commandType, commandText, null);
        }

        public static int ExecuteNonQuery(IDbTransaction transaction, String spName, params Object[] parameterValues)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
        }

        public static int ExecuteNonQuery(String connectionString, CommandType commandType, String commandText)
        {
            return ExecuteNonQuery(connectionString, commandType, commandText, (int?)null);
        }

        public static int ExecuteNonQuery(String connectionString, String spName, params Object[] parameterValues)
        {
            return ExecuteNonQuery(connectionString, spName, null, parameterValues);
        }

        public static int ExecuteNonQuery(IDbConnection connection, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            return ExecuteNonQuery(connection, commandType, commandText, null, commandParameters);
        }

        public static int ExecuteNonQuery(IDbConnection connection, CommandType commandType, String commandText, int? timeout)
        {
            return ExecuteNonQuery(connection, commandType, commandText, timeout, null);
        }

        public static int ExecuteNonQuery(IDbTransaction transaction, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            IDbCommand command = null;
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }

            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand();
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand();
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand();
                    break;
                default:
                    command = null;
                    break;
            }

            bool mustCloseConnection = false;
            PrepareCommand(command, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return num;
        }

        public static int ExecuteNonQuery(String connectionString, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            return ExecuteNonQuery(connectionString, commandType, commandText, null, commandParameters);
        }

        public static int ExecuteNonQuery(String connectionString, CommandType commandType, String commandText, int? commandTimeout)
        {
            return ExecuteNonQuery(connectionString, commandType, commandText, commandTimeout, null);
        }

        public static int ExecuteNonQuery(String connectionString, String spName, int? timeout, params Object[] parameterValues)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, timeout, spParameterSet);
            }
            return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, timeout);
        }

        public static int ExecuteNonQuery(IDbConnection connection, CommandType commandType, String commandText, int? timeout, params IDbDataParameter[] commandParameters)
        {
            IDbCommand command = null;
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand();
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand();
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand();
                    break;
                default:
                    command = null;
                    break;
            }
            
            bool mustCloseConnection = false;
            PrepareCommand(command, connection, null, commandType, commandText, commandParameters, timeout, out mustCloseConnection);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            if (mustCloseConnection)
            {
                connection.Close();
            }
            return num;
        }

        public static int ExecuteNonQuery(String connectionString, CommandType commandType, String commandText, int? commandTimeout, params IDbDataParameter[] commandParameters)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            IDbConnection connection = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    connection = new SqlConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    connection = new OleDbConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    connection = new OdbcConnection(connectionString);
                    break;
                default:
                    connection = null;
                    break;
            }

            connection.Open();
            return ExecuteNonQuery(connection, commandType, commandText, commandTimeout, commandParameters);
        }

        public static int ExecuteNonQueryTypedParams(IDbConnection connection, String spName, DataRow dataRow)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
        }

        public static int ExecuteNonQueryTypedParams(IDbTransaction transaction, String spName, DataRow dataRow)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
        }

        public static int ExecuteNonQueryTypedParams(String connectionString, String spName, DataRow dataRow)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
        }

        public static IDataReader ExecuteReader(IDbConnection connection, CommandType commandType, String commandText)
        {
            return ExecuteReader(connection, commandType, commandText, null);
        }

        public static IDataReader ExecuteReader(IDbConnection connection, String spName, params Object[] parameterValues)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteReader(connection, CommandType.StoredProcedure, spName);
        }

        public static IDataReader ExecuteReader(IDbTransaction transaction, CommandType commandType, String commandText)
        {
            return ExecuteReader(transaction, commandType, commandText, null);
        }

        public static IDataReader ExecuteReader(IDbTransaction transaction, String spName, params Object[] parameterValues)
        {            
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
        }

        public static IDataReader ExecuteReader(String connectionString, CommandType commandType, String commandText)
        {
            return ExecuteReader(connectionString, commandType, commandText, null);
        }

        public static IDataReader ExecuteReader(String connectionString, String spName, params Object[] parameterValues)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
        }

        public static IDataReader ExecuteReader(IDbConnection connection, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            return ExecuteReader(connection, null, commandType, commandText, commandParameters, ConnectionOwnership.External);
        }

        public static IDataReader ExecuteReader(IDbTransaction transaction, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, ConnectionOwnership.External);
        }

        public static IDataReader ExecuteReader(String connectionString, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            IDataReader reader;
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            IDbConnection connection = null;
            try
            {

                switch (ProviderType)
                {
                    case Util.ConnectionLibrary.SQlClient:
                        connection = new SqlConnection(connectionString);
                        break;
                    case Util.ConnectionLibrary.Oledb:
                        connection = new OleDbConnection(connectionString);
                        break;
                    case Util.ConnectionLibrary.ODBC:
                        connection = new OdbcConnection(connectionString);
                        break;
                    default:
                        connection = null;
                        break;
                }


                connection.Open();
                reader = ExecuteReader(connection, null, commandType, commandText, commandParameters, ConnectionOwnership.Internal);
            }
            catch
            {
                if (connection != null)
                {
                    connection.Close();
                }
                throw;
            }
            return reader;
        }

        private static IDataReader ExecuteReader(IDbConnection connection, IDbTransaction transaction, CommandType commandType, String commandText, IDbDataParameter[] commandParameters, ConnectionOwnership connectionOwnership)
        {
            IDataReader reader2;
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            bool mustCloseConnection = false;
            IDbCommand command = null;
            
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand();
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand();
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand();
                    break;
                default:
                    command = null;
                    break;
            }
            
            try
            {
                IDataReader reader;
                PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
                if (connectionOwnership == ConnectionOwnership.External)
                {
                    reader = command.ExecuteReader();
                }
                else
                {
                    reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                }
                bool flag2 = true;
                foreach (IDbDataParameter parameter in command.Parameters)
                {
                    if (parameter.Direction != ParameterDirection.Input)
                    {
                        flag2 = false;
                    }
                }
                if (flag2)
                {
                    command.Parameters.Clear();
                }
                reader2 = reader;
            }
            catch
            {
                if (mustCloseConnection)
                {
                    connection.Close();
                }
                throw;
            }
            return reader2;
        }

        public static IDataReader ExecuteReaderTypedParams(IDbConnection connection, String spName, DataRow dataRow)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteReader(connection, CommandType.StoredProcedure, spName);
        }

        public static IDataReader ExecuteReaderTypedParams(IDbTransaction transaction, String spName, DataRow dataRow)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
        }

        public static IDataReader ExecuteReaderTypedParams(String connectionString, String spName, DataRow dataRow)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
        }

        public static Object ExecuteScalar(IDbConnection connection, CommandType commandType, String commandText)
        {
            return ExecuteScalar(connection, commandType, commandText, null);
        }

        public static Object ExecuteScalar(IDbConnection connection, String spName, params Object[] parameterValues)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteScalar(connection, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
        }

        public static Object ExecuteScalar(IDbTransaction transaction, CommandType commandType, String commandText)
        {
            return ExecuteScalar(transaction, commandType, commandText, null);
        }

        public static Object ExecuteScalar(IDbTransaction transaction, String spName, params Object[] parameterValues)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
        }

        public static Object ExecuteScalar(String connectionString, CommandType commandType, String commandText)
        {
            return ExecuteScalar(connectionString, commandType, commandText, null);
        }

        public static Object ExecuteScalar(String connectionString, String spName, params Object[] parameterValues)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
        }

        public static Object ExecuteScalar(IDbConnection connection, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            IDbCommand command = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand();
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand();
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand();
                    break;
                default:
                    command = null;
                    break;
            }

            bool mustCloseConnection = false;
            PrepareCommand(command, connection, null, commandType, commandText, commandParameters, out mustCloseConnection);
            Object obj2 = command.ExecuteScalar();
            command.Parameters.Clear();
            if (mustCloseConnection)
            {
                connection.Close();
            }
            return obj2;
        }

        public static Object ExecuteScalar(IDbTransaction transaction, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            IDbCommand command = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand();
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand();
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand();
                    break;
                default:
                    command = null;
                    break;
            }
            bool mustCloseConnection = false;
            PrepareCommand(command, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
            Object obj2 = command.ExecuteScalar();
            command.Parameters.Clear();
            return obj2;
        }

        public static Object ExecuteScalar(String connectionString, CommandType commandType, String commandText, params IDbDataParameter[] commandParameters)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            IDbConnection connection = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    connection = new SqlConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    connection = new OleDbConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    connection = new OdbcConnection(connectionString);
                    break;
                default:
                    connection = null;
                    break;
            }
            connection.Open();
            return ExecuteScalar(connection, commandType, commandText, commandParameters);
        }

        public static Object ExecuteScalarTypedParams(IDbConnection connection, String spName, DataRow dataRow)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteScalar(connection, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
        }

        public static Object ExecuteScalarTypedParams(IDbTransaction transaction, String spName, DataRow dataRow)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
        }

        public static Object ExecuteScalarTypedParams(String connectionString, String spName, DataRow dataRow)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((dataRow != null) && (dataRow.ItemArray.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connectionString, spName);
                AssignParameterValues(spParameterSet, dataRow);
                return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, spParameterSet);
            }
            return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
        }        

        public static void FillDataset(IDbConnection connection, CommandType commandType, String commandText, DataSet dataSet, String[] tableNames)
        {
            FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
        }

        public static void FillDataset(IDbConnection connection, String spName, DataSet dataSet, String[] tableNames, params Object[] parameterValues)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, spParameterSet);
            }
            else
            {
                FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames);
            }
        }

        public static void FillDataset(IDbTransaction transaction, CommandType commandType, String commandText, DataSet dataSet, String[] tableNames)
        {
            FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
        }

        public static void FillDataset(IDbTransaction transaction, String spName, DataSet dataSet, String[] tableNames, params Object[] parameterValues)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            if ((transaction != null) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                IDbDataParameter[] spParameterSet = DataAccessHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                AssignParameterValues(spParameterSet, parameterValues);
                FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, spParameterSet);
            }
            else
            {
                FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames);
            }
        }

        public static void FillDataset(String connectionString, CommandType commandType, String commandText, DataSet dataSet, String[] tableNames)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet");
            }
            IDbConnection connection = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    connection = new SqlConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    connection = new OleDbConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    connection = new OdbcConnection(connectionString);
                    break;
                default:
                    connection = null;
                    break;
            }

            connection.Open();
            FillDataset(connection, commandType, commandText, dataSet, tableNames);
        }

        public static void FillDataset(String connectionString, String spName, DataSet dataSet, String[] tableNames, params Object[] parameterValues)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet");
            }
            IDbConnection connection = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    connection = new SqlConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    connection = new OleDbConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    connection = new OdbcConnection(connectionString);
                    break;
                default:
                    connection = null;
                    break;
            }
            connection.Open();
            FillDataset(connection, spName, dataSet, tableNames, parameterValues);
        }

        public static void FillDataset(IDbConnection connection, CommandType commandType, String commandText, DataSet dataSet, String[] tableNames, params IDbDataParameter[] commandParameters)
        {
            FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        public static void FillDataset(IDbTransaction transaction, CommandType commandType, String commandText, DataSet dataSet, String[] tableNames, params IDbDataParameter[] commandParameters)
        {
            FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        public static void FillDataset(String connectionString, CommandType commandType, String commandText, DataSet dataSet, String[] tableNames, params IDbDataParameter[] commandParameters)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet");
            }
            IDbConnection connection = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    connection = new SqlConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    connection = new OleDbConnection(connectionString);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    connection = new OdbcConnection(connectionString);
                    break;
                default:
                    connection = null;
                    break;
            }
            connection.Open();
            FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        private static void FillDataset(IDbConnection connection, IDbTransaction transaction, CommandType commandType, String commandText, DataSet dataSet, String[] tableNames, params IDbDataParameter[] commandParameters)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet");
            }
            IDbCommand command = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand();
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand();
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand();
                    break;
                default:
                    command = null;
                    break;
            }
            bool mustCloseConnection = false;
            PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            IDbDataAdapter adapter = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    adapter = new SqlDataAdapter((SqlCommand)command);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    adapter = new OleDbDataAdapter((OleDbCommand)command);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    adapter = new OdbcDataAdapter((OdbcCommand)command);
                    break;
                default:
                    adapter = null;
                    break;
            }

            if ((tableNames != null) && (tableNames.Length > 0))
            {
                String sourceTable = "Table";
                for (int i = 0; i < tableNames.Length; i++)
                {
                    if ((tableNames[i] == null) || (tableNames[i].Length == 0))
                    {
                        throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty String.", "tableNames");
                    }
                    adapter.TableMappings.Add(sourceTable, tableNames[i]);
                    sourceTable = sourceTable + ((i + 1)).ToString();
                }
            }
            adapter.Fill(dataSet);
            command.Parameters.Clear();

            if (mustCloseConnection)
            {
                connection.Close();
            }
        }

        private static void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, String commandText, IDbDataParameter[] commandParameters, out bool mustCloseConnection)
        {
            PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, null, out mustCloseConnection);
        }

        private static void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, String commandText, IDbDataParameter[] commandParameters, int? commandTimeout, out bool mustCloseConnection)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if ((commandText == null) || (commandText.Length == 0))
            {
                throw new ArgumentNullException("commandText");
            }
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            command.Connection = connection;
            command.CommandText = commandText;
            if (commandTimeout.HasValue)
            {
                command.CommandTimeout = commandTimeout.Value;
            }
            else
            {
                command.CommandTimeout = command.Connection.ConnectionTimeout;
            }
            if (transaction != null)
            {
                if (transaction.Connection == null)
                {
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                }
                command.Transaction = transaction;
            }
            command.CommandType = commandType;
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }

        public static void UpdateDataset(IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand, DataSet dataSet, String tableName)
        {
            if (insertCommand == null)
            {
                throw new ArgumentNullException("insertCommand");
            }
            if (deleteCommand == null)
            {
                throw new ArgumentNullException("deleteCommand");
            }
            if (updateCommand == null)
            {
                throw new ArgumentNullException("updateCommand");
            }
            if ((tableName == null) || (tableName.Length == 0))
            {
                throw new ArgumentNullException("tableName");
            }

            IDbDataAdapter adapter = null;
            switch (ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    adapter = new SqlDataAdapter();
                    adapter.UpdateCommand = updateCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.DeleteCommand = deleteCommand;
                    ((SqlDataAdapter)adapter).Update(dataSet, tableName);
                    dataSet.AcceptChanges();
                    break;
                case Util.ConnectionLibrary.Oledb:
                    adapter = new OleDbDataAdapter();
                    adapter.UpdateCommand = updateCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.DeleteCommand = deleteCommand;
                    ((OleDbDataAdapter)adapter).Update(dataSet, tableName);
                    dataSet.AcceptChanges();
                    break;
                case Util.ConnectionLibrary.ODBC:
                    adapter = new OdbcDataAdapter();
                    adapter.UpdateCommand = updateCommand;
                    adapter.InsertCommand = insertCommand;
                    adapter.DeleteCommand = deleteCommand;
                    ((OdbcDataAdapter)adapter).Update(dataSet, tableName);
                    dataSet.AcceptChanges();
                    break;
                default:
                    adapter = null;
                    break;
            }

            
        }

        private enum ConnectionOwnership
        {
            Internal,
            External
        }
    }
}

