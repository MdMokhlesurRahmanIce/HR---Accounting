using System;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Security.DAO;

namespace ASL.Security.BLL
{
    public class ProfileManager
    {
        public CustomList<Application> GetAllApplication()
        {
            return Application.GetAllApplication();
        }
        public CustomList<UserProfile> GetAllUserProfile(String userCode)
        {
            return UserProfile.GetAllUserProfile(userCode);
        }
        public void SaveUserProfile(ref CustomList<UserProfile> UserProfileList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(UserProfileList);


                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, UserProfileList);

                UserProfileList.AcceptChanges();

                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }

        }
        private void ReSetSPName(CustomList<UserProfile> UserProfileList)
        {
            #region User profile

            UserProfileList.InsertSpName = "spInsertUserProfile";
            UserProfileList.UpdateSpName = "spUpdateUserProfile";
            UserProfileList.DeleteSpName = "spDeleteUserProfile";
            #endregion
        }
    }
}
