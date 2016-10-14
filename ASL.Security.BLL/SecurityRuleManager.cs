using System;
using System.Collections.Generic;
using ASL.DAL;
using ASL.DATA;
using ASL.Security.DAO;
using ASL.STATIC;
namespace ASL.Security.BLL
{
    public class SecurityRuleManager
    {
        public CustomList<SecurityRule> GetAlltblSecurityRule()
        {
            return SecurityRule.doSearch(String.Empty);
        }
    }
}
