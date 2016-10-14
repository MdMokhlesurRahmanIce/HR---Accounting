//using System;
//using System.Data;
//using System.Data.SqlClient;
//using ST.Utilities;

//namespace ASL.DAL
//{		
//    public class DataBaseMaintainers : IDisposable
//    {
					
//        private SqlConnection objConnection; 
//        private SqlDataAdapter objAdapter; 
		
//        private SqlCommand objCommand;

//        private const int CommandTimeOut = 900;

//        private void OpenConnection(String masterConn)
//        {	
//            try
//            {
//                if(objConnection != null && objConnection.State == ConnectionState.Open)  
//                {
//                    objConnection.Close();			
//                    objConnection = null;
//                }
//                //			
//                objConnection  = new SqlConnection(masterConn);			
//                objConnection.Open();				
//            }
//            catch(Exception ex)
//            {				
//                throw (ex);
//            }			
//        }	
//        private void CloseConnection()
//        {
//            if(objConnection != null && objConnection.State == ConnectionState.Open)
//            {
//                objConnection.Close ();
//                objConnection.Dispose();
//                objConnection = null;					
//            }				
//        }
//        public DataTable GetDbConfig()
//        {
//            try
//            {
//                return DbConfig.DsConnection.Tables[0].Copy();
//            }
//            catch(Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        public void SetDatabaseName(String conName,String databaseName)
//        {
//            try
//            {
//                DataRow[] drConnection = DbConfig.DsConnection.Tables[0].Select("ConnectionName = '" + conName + "'");
//                if (drConnection.Length == 1)
//                {
//                    drConnection[0]["DatabaseName"] = databaseName;
//                    EncryptRow(ref drConnection[0]);
//                    drConnection[0].AcceptChanges();
//                }
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        private static void EncryptRow(ref DataRow drConnection)
//        {
//            try
//            {
//                var objEncryption = new Encryption("nAlam", "ecs2317");
//                String strUserID = "";
//                if (drConnection["UserName"] != DBNull.Value)
//                {
//                    strUserID = drConnection["UserName"].ToString();
//                }

//                drConnection["DatabaseName"] = objEncryption.EncryptWord(drConnection["DatabaseName"].ToString(), strUserID);

//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        public void GetDbHistory(ref DataTable dt,String masterConn,String conName)
//        {	
//            try
//            {
//                OpenConnection(masterConn);
//                //			
//                dt = new DataTable();
//                String sql = "select '' Dumy,IsBackUp,ConnectionName,DatabaseName,AddedBy,DateAdded,Path,[FileName] from DBHistory where ConnectionName = '" + @conName + "' and IsBackup = 1 order by DateAdded";

//                objAdapter = new SqlDataAdapter(sql,objConnection);			
//                objAdapter.Fill(dt);			
//                CloseConnection();		
//            }
//            catch(Exception ex)
//            {
//                throw (ex);
//            }
//        }		
//        public void DatabaseMaintainers(String masterConn,String dBName,String conName,String path,String fileName,String addedBy,String actionName)
//        {
//            try
//            {
//                OpenConnection(masterConn);
//                objCommand = new SqlCommand {CommandTimeout = CommandTimeOut, Connection = objConnection};
//                //								
//                String sql1 = "";
//                String sql2 = "";
//                const string password = "admin";
//                if(actionName == "RESTORE")
//                {
//                    objCommand.CommandText = "select req_spid from syslockinfo where rsc_dbid = (select dbid from sysdatabases where [name] = '" + dBName + "')";
//                    objAdapter = new SqlDataAdapter(objCommand);
//                    var dt = new DataTable();
//                    objAdapter.Fill(dt);						
//                    foreach(DataRow dr in dt.Rows)
//                    {
//                        try
//                        {
//                            sql1 = "KILL " + dr["req_spid"];
//                            objCommand.CommandText = sql1;
//                            objCommand.ExecuteNonQuery();
//                        }
//                        catch (Exception ex)
//                        {
//                            throw(ex);
//                        }
//                    }
//                    //
//                    //restore database [HRMS5SANTA] from DISK = '\\server-001\asif\HRMS5_06Mar21_1516.dat' with MEDIAPASSWORD = 'admin', MOVE 'HRMS5_data' TO 'c:\HRMS5SNTA.mdf', MOVE 'HRMS5_log' TO 'c:\HRMS5SNTA_log.ldf'
//                    sql1 = "restore database [" + dBName + "] from DISK = '" + path + "\\" + fileName + "' with MEDIAPASSWORD = '" + password + "'";
//                    sql2 = "insert into DBHistory(DatabaseName,ConnectionName,Path,[FileName],DateAdded,AddedBy,IsBackup) values ('" + dBName + "','" + conName + "','" + path + "','" + fileName + "','" + DateTime.Now + "','" + addedBy + "',0)";
//                }
//                else if(actionName == "BACKUP")
//                {
//                    sql1 = 	"backup database [" + dBName + "] to DISK = '" + path + "\\" + fileName + "' with INIT,SKIP, MEDIAPASSWORD = '" + password + "'";
//                    sql2 = "insert into DBHistory(DatabaseName,ConnectionName,Path,[FileName],DateAdded,AddedBy,IsBackup) values ('" + dBName + "','" + conName + "','" + path + "','" + fileName + "','" + DateTime.Now + "','" + addedBy + "',1)";					
//                }	
//                objCommand.CommandText = sql1;
//                objCommand.ExecuteNonQuery();
				
//                objCommand.CommandText = sql2;
//                objCommand.ExecuteNonQuery();
//                //
//                if(objAdapter != null)
//                {
//                    objAdapter.Dispose();
//                    objAdapter = null;
//                }
//                CloseConnection();		
//            }
//            catch(Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        #region Implementation of IDisposable
//        public void Dispose()
//        {
//            objConnection = null;
//        }
//        #endregion

//    }
//}
