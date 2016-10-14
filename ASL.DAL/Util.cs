using System;
using System.Data;
using System.Globalization;


namespace ASL.DAL
{
    public class Util
    {
        public enum ConnectionLibrary : short { Oledb, SQlClient, ODBC, OracleClient, OledbMSSQL, OledbOracle, OledbMSAcess2000 };
        public enum Operators : short { Equal, NotEqual, GreaterThan, LessThan, GreaterThanEqualsTo, LessThanEqualsTo, Not };
        public enum OperationType : short { Select, Insert, Update, Delete };
        public enum CrudType : short { Default, Insert, Delete };


        private static readonly String[] AryOperator = { "=", "<>", ">", "<", ">=", "<=", "!" };

        public static String FormatCriteria(String fieldName, Object fieldValue)
        {
            return FormatCriteria(fieldName, fieldValue, Operators.Equal, "", fieldValue.GetType(), ConnectionLibrary.SQlClient);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue, Operators eO)
        {
            return FormatCriteria(fieldName, fieldValue, eO, "", fieldValue.GetType(), ConnectionLibrary.SQlClient);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            String tablename)
        {
            return FormatCriteria(fieldName, fieldValue, Operators.Equal, tablename, fieldValue.GetType(), ConnectionLibrary.SQlClient);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            Operators eO, String tablename)
        {
            return FormatCriteria(fieldName, fieldValue, eO, tablename, fieldValue.GetType(), ConnectionLibrary.SQlClient);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            Type sysType)
        {
            return FormatCriteria(fieldName, fieldValue, Operators.Equal, "", sysType, ConnectionLibrary.SQlClient);
        }
        public static String FormatCriteria(String fieldName, Object fieldValue,
            Operators eO, Type sysType)
        {
            return FormatCriteria(fieldName, fieldValue, eO, "", sysType, ConnectionLibrary.SQlClient);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            ConnectionLibrary eCl)
        {
            return FormatCriteria(fieldName, fieldValue, Operators.Equal, "", fieldValue.GetType(), eCl);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            Operators eO, ConnectionLibrary eCl)
        {
            return FormatCriteria(fieldName, fieldValue, eO, "", fieldValue.GetType(), eCl);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            String tablename, Type sysType)
        {
            return FormatCriteria(fieldName, fieldValue, Operators.Equal, tablename, sysType, ConnectionLibrary.SQlClient);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            Operators eO, String tablename, Type sysType)
        {
            return FormatCriteria(fieldName, fieldValue, eO, tablename, sysType, ConnectionLibrary.SQlClient);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            String tablename, ConnectionLibrary eCl)
        {
            return FormatCriteria(fieldName, fieldValue, Operators.Equal, tablename, fieldValue.GetType(), eCl);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            Operators eO, String tablename, ConnectionLibrary eCl)
        {
            return FormatCriteria(fieldName, fieldValue, eO, tablename, fieldValue.GetType(), eCl);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            Type sysType, ConnectionLibrary eCl)
        {
            return FormatCriteria(fieldName, fieldValue, Operators.Equal, "", sysType, eCl);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue,
            Operators eO, Type sysType, ConnectionLibrary eCl)
        {
            return FormatCriteria(fieldName, fieldValue, eO, "", sysType, eCl);
        }

        public static String FormatCriteria(String fieldName, Object fieldValue, Operators eO, String tableName, Type sysType, ConnectionLibrary eCl)
        {
            String criteria = String.Empty;
            String value;

            String strOperator = AryOperator[Convert.ToInt32(eO)];

            try
            {
                if (fieldName.Trim().Length > 0 && fieldValue != null)
                {
                    if (eCl == ConnectionLibrary.SQlClient)
                    {
                        if (sysType == typeof(String))
                        {
                            value = fieldValue.ToString();
                            value = value.Replace("'", "''");
                            criteria = fieldName + strOperator + "'" + value + "'";

                        }
                        else if (sysType == typeof(DateTime))
                        {
                            value = fieldValue.ToString();
                            criteria = fieldName + strOperator + "'" + value + "'";
                        }
                        else if (sysType == typeof(Int16) || sysType == typeof(Int32)
                            || sysType == typeof(Int64) || sysType == typeof(Decimal))
                        {

                            value = fieldValue.ToString();
                            criteria = fieldName + strOperator + value;

                        }
                        else if (sysType == typeof(DBNull))
                        {

                            value = "Null";
                            if (eO == Operators.Not)
                            {
                                criteria = fieldName + " is not " + value;
                            }
                            else
                            {
                                criteria = fieldName + " is " + value;
                            }
                        }

                    }


                    if (tableName.Trim().Length > 0)
                    {
                        criteria = tableName + "." + criteria;
                    }
                }
                else
                {
                    if (fieldName.Trim().Length > 0)
                    {
                        throw new Exception("Field name is blank.");
                    }
                    if (fieldValue == null)
                    {
                        throw new Exception("Field value is Null.");
                    }
                }
                return criteria;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static DataSet DataReaderToDataSet(IDataReader reader)
        {
            var ds = new DataSet();
            DataTable table;
            do
            {
                int fieldCount = reader.FieldCount;
                table = new DataTable();
                for (int i = 0; i < fieldCount; i++)
                {
                    table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                }
                table.BeginLoadData();
                var values = new Object[fieldCount];
                while (reader.Read())
                {
                    reader.GetValues(values);
                    table.LoadDataRow(values, true);
                }
                table.EndLoadData();

                ds.Tables.Add(table);

            } while (reader.NextResult());
            reader.Close();
            return ds;
        }

        public static bool IsNumeric(String number)
        {
            Double doubleValue;

            var nfinfo = new NumberFormatInfo();

            if (number.Length == 0)
            {
                return false;
            }
            return Double.TryParse(number, NumberStyles.Float, nfinfo, out doubleValue);
        }

        public static String GetDatabaseName(String conName)
        {
            Connection connection = DbConfig.ConnectionList.Find(con => con.Name.Equals(conName));
            return connection == null ? String.Empty : connection.Database;
        }
        public static String GetConnectionString(String conName)
        {
            Connection connection = DbConfig.ConnectionList.Find(con => con.Name.Equals(conName));
            return connection == null ? String.Empty : connection.ConnectionString;
        }
    }
}
