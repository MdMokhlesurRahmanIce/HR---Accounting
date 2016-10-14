using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class SkillManager
    {
        public CustomList<SkillInfo> GetAllSkillInfo()
        {
            return SkillInfo.GetAllSkillInfo();
        }
    }
}