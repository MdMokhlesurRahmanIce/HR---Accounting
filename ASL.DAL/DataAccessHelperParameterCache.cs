using System;
using System.Collections;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ASL.DAL
{
    internal sealed class DataAccessHelperParameterCache
    {        
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());
        
        public static void CacheParameterSet(String connectionString, String commandText, params IDbDataParameter[] commandParameters)
        {            
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((commandText == null) || (commandText.Length == 0))
            {
                throw new ArgumentNullException("commandText");
            }
            String text = connectionString + ":" + commandText;
            paramCache[text] = commandParameters;
        }

        private static IDbDataParameter[] CloneParameters(IDbDataParameter[] originalParameters)
        {
            IDbDataParameter[] parameterArray = new IDbDataParameter[originalParameters.Length];
            int index = 0;
            int length = originalParameters.Length;
            while (index < length)
            {
                parameterArray[index] = (IDbDataParameter) ((ICloneable) originalParameters[index]).Clone();
                index++;
            }
            return parameterArray;
        }

        private static IDbDataParameter[] DiscoverSpParameterSet(IDbConnection connection, String spName, bool includeReturnValueParameter)
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

            switch (DataAccessHelper.ProviderType)
            {
                case Util.ConnectionLibrary.SQlClient:
                    command = new SqlCommand(spName, (SqlConnection)connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlCommandBuilder.DeriveParameters((SqlCommand)command);
                    break;
                case Util.ConnectionLibrary.Oledb:
                    command = new OleDbCommand(spName, (OleDbConnection)connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    OleDbCommandBuilder.DeriveParameters((OleDbCommand)command);
                    break;
                case Util.ConnectionLibrary.ODBC:
                    command = new OdbcCommand(spName, (OdbcConnection)connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    OdbcCommandBuilder.DeriveParameters((OdbcCommand)command);
                    break;
                default:
                    command = null;
                    break;
            }


            connection.Close();
            if (!includeReturnValueParameter)
            {
                command.Parameters.RemoveAt(0);
            }
            IDbDataParameter[] array = new IDbDataParameter[command.Parameters.Count];
            command.Parameters.CopyTo(array, 0);
            foreach (IDbDataParameter parameter in array)
            {
                parameter.Value = DBNull.Value;
            }
            return array;
        }

        public static IDbDataParameter[] GetCachedParameterSet(String connectionString, String commandText)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((commandText == null) || (commandText.Length == 0))
            {
                throw new ArgumentNullException("commandText");
            }
            String text = connectionString + ":" + commandText;
            IDbDataParameter[] originalParameters = paramCache[text] as IDbDataParameter[];
            if (originalParameters == null)
            {
                return null;
            }
            return CloneParameters(originalParameters);
        }

        internal static IDbDataParameter[] GetSpParameterSet(IDbConnection connection, String spName)
        {
            return GetSpParameterSet(connection, spName, false);
        }

        public static IDbDataParameter[] GetSpParameterSet(String connectionString, String spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        internal static IDbDataParameter[] GetSpParameterSet(IDbConnection connection, String spName, bool includeReturnValueParameter)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            using (IDbConnection connection2 = ((IDbConnection) ((ICloneable) connection).Clone()))
            {
                return GetSpParameterSetInternal(connection2, spName, includeReturnValueParameter);
            }
        }

        public static IDbDataParameter[] GetSpParameterSet(String connectionString, String spName, bool includeReturnValueParameter)
        {
            if ((connectionString == null) || (connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            IDbConnection connection = null;
            switch (DataAccessHelper.ProviderType)
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

            return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
        }

        private static IDbDataParameter[] GetSpParameterSetInternal(IDbConnection connection, String spName, bool includeReturnValueParameter)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            if ((spName == null) || (spName.Length == 0))
            {
                throw new ArgumentNullException("spName");
            }
            String text = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
            IDbDataParameter[] originalParameters = paramCache[text] as IDbDataParameter[];
            if (originalParameters == null)
            {
                IDbDataParameter[] parameterArray2 = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                paramCache[text] = parameterArray2;
                originalParameters = parameterArray2;
            }
            return CloneParameters(originalParameters);
        }
    }
}

