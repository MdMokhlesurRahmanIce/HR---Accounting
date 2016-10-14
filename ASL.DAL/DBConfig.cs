using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;

namespace ASL.DAL
{

	sealed class DbConfig
	{
	    public static List<Connection> ConnectionList { get; set; }
        static DbConfig()
        {
            try
            {
                String server = String.Empty;
                String database = String.Empty;
                String userId = String.Empty;
                String password = String.Empty;
                ConnectionList = new List<Connection>();
                foreach (ConnectionStringSettings conString in WebConfigurationManager.ConnectionStrings)
                {
                    if (conString.Name.Equals("LocalSqlServer")) continue;
                    if (conString.Name.Equals("OraAspNetConString")) continue;
                    String[] serverInfo = conString.ConnectionString.Split(";".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
                    
                    foreach(String info in serverInfo)
                    {
                        if (info.Trim().ToLower().StartsWith("data source") || info.Trim().ToLower().StartsWith("server"))
                        {
                            server = info.Split('=')[1].Trim();
                        }
                        else if (info.Trim().ToLower().StartsWith("user id") || info.Trim().ToLower().StartsWith("user") || info.Trim().ToLower().StartsWith("uid"))
                        {
                            userId = info.Split('=')[1].Trim();
                        }
                        else if (info.Trim().ToLower().StartsWith("pwd") || info.Trim().ToLower().StartsWith("password"))
                        {
                            password = info.Split('=')[1].Trim();
                        }
                        else if (info.Trim().ToLower().StartsWith("initial catalog") || info.Trim().ToLower().StartsWith("database"))
                        {
                            database = info.Split('=')[1].Trim();
                        }
                        
                    }
                    var connection = new Connection
                                         {
                                             Name = conString.Name,
                                             Provider = (Util.ConnectionLibrary)Enum.Parse(typeof(Util.ConnectionLibrary), conString.ProviderName),
                                             ConnectionString = conString.ConnectionString,
                                             Default = conString.LockItem,
                                             Server = server,
                                             Database = database,
                                             UserId = userId,
                                             Password = password 
                                         };
                    ConnectionList.Add(connection);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //1. Open machine.config on the local machine.
        //WebConfigurationManager.OpenMachineConfiguration()

        //2. Open root web.config on the local machine.
        //WebConfigurationManager.OpenWebConfiguration(null)

        //3. Open web.config for the application at the root of the default web site.
        //WebConfigurationManager.OpenWebConfiguration("/")

        //4. Open web.config for a subdirectory of the application found at /MyApp.
        //WebConfigurationManager.OpenWebConfiguration("/MyApp/subdir")

        //5. Open web.config for an application at the root of another site.
        //WebConfigurationManager.OpenWebConfiguration("/", "Another Site")

        //6. Open the <location> tag for a subdirectory at the application level.
        //WebConfigurationManager.OpenWebConfiguration("/", null, "/subdir")

        //7. Open machine.config on another computer, using credentials provided.
        //WebConfigurationManager.OpenMachineConfiguration(null, "remotemachine", "user", "password")

        //Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        //ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
        //section.ConnectionStrings["SysMan"].ConnectionString = "Data Source = SHAMIM; User Id = sa; pwd = sa;";
        //ConnectionStringSettings s = new ConnectionStringSettings();
        //s.ProviderName = "SQL";
        //s.Name = "Test";
        //s.ConnectionString = "sdsd";
        //section.ConnectionStrings.Add(s);
        //config.Save();



        //private const string XmlFileName = "DbConfig";

        //static DbConfig()
        //{
        //    DsConnection = new DataSet();
        //    string configPath = AppDomain.CurrentDomain.BaseDirectory;

        //    try
        //    {
        //        if (!File.Exists(configPath + XmlFileName + ".xsd"))
        //        {
        //            WindowsIdentity user = WindowsIdentity.GetCurrent();
        //            if (user != null) configPath = AppDomain.CurrentDomain.BaseDirectory + "Users\\" + user.Name;

        //            if (!Directory.Exists(configPath))
        //            {
        //                Directory.CreateDirectory(configPath);
        //            }
        //            configPath += "\\";
        //        }

        //        if (File.Exists(configPath + XmlFileName + ".xsd"))
        //        {
        //            DsConnection.ReadXmlSchema(configPath + XmlFileName + ".xsd");
        //        }
        //        else
        //        {
        //            throw new Exception("A required file: " + XmlFileName + ".xsd is not found is the location: " + configPath);
        //        }
        //        if (File.Exists(configPath + XmlFileName + ".xml"))
        //        {
        //            DsConnection.ReadXml(configPath + XmlFileName + ".xml");
        //        }
        //        else
        //        {
        //            throw new Exception("A required file: " + XmlFileName + ".xml is not found is the location: " + configPath);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
	}
}
