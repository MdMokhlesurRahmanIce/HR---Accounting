using ASL.DATA;
using ASL.STATIC;


namespace ASL.Security.BLL
{
    public class CompanyEntityManager
    {
        public CustomList<CompanyEntity> GetAllCompanyEntity()
        {
            return CompanyEntity.GetAllCompanyEntity();
        }
    }
}
