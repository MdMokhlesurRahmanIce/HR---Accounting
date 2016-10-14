using System;

namespace ASL.DAL
{
    class Connection
    {
        public String Name { get; set; }
        public Util.ConnectionLibrary Provider { get; set; }
        public String ConnectionString { get; set; }
        public Boolean Default { get; set; }
        public String Server { get; set; }
        public String Database { get; set; }
        public String UserId { get; set; }
        public String Password { get; set; }
    }
}
