using ASL.DATA;
using ASL.Security.DAO;


namespace ASL.Security.BLL
{
    public class ApplicationManager
    {
        public CustomList<Application> GetAllApplication()
        {
            return Application.GetAllApplication();
        }

        public CustomList<Menu> GetAllMenusForAnApplication(int applicaitonId)
        {
            return Menu.GetAllMenuByApplicationID(applicaitonId);
        }

        public Users GetDefaultApplicationOfCurrentUser(string userCode)
        {
            return Users.GetDefaultApplicationByUserCode(userCode);
        }
        
        public SiteMaster GetCurrentSite()
        {
            return SiteMaster.GetCurrentSite();
        }
    }
}
