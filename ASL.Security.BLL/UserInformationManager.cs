using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Security.DAO;
using ASL.Hr.DAO;

namespace ASL.Security.BLL
{
    public class UserInformationManager
    {
        private String userCode = String.Empty;
        public String UserCode
        {
            get { return userCode; }
        }
        public CustomList<Users> GetAllUsers()
        {
            return Users.doSearch(string.Empty);
        }
        public CustomList<Configuration> GetAllConfiguration()
        {
            return Configuration.GetAllConfiguration();
        }
        public CustomList<Company_Entity> GetAllCompany_Entity()
        {
            return Company_Entity.GetAllCompany_Entity();
        }
        public CustomList<Application> GetAllApplication()
        {
            return Application.GetAllApplication();
        }
        public CustomList<UserGroupList> GetAllUserGroupWithUserCode(string userCode)
        {
            return UserGroupList.GetAllUserGroupWithUserCode(userCode);
        }
        public CustomList<Users> GetAllEmp()
        {
            return Users.GetAllEmp();
        }
        public CustomList<HRM_Emp> doSearch(string whereClose)
        {
            return HRM_Emp.doSearch(whereClose);
        }
        public void SaveUser(ref CustomList<Users> userList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(userList);

                GetNewUserID(ref conManager, ref userList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, userList);

                userList.AcceptChanges();


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
        private void ReSetSPName(CustomList<Users> userList)
        {
            #region Security Rule

            userList.InsertSpName = "spInsertUser";
            userList.UpdateSpName = "spUpdateUser";
            userList.DeleteSpName = "spDeleteUser";
            #endregion
        }
        private void GetNewUserID(ref ConnectionManager conManager, ref CustomList<Users> userList)
        {
            String newUserCode = String.Empty;
            try
            {
                CustomList<Users> addedUserList = userList.FindAll(f => f.IsAdded);
                if (addedUserList.Count != 0)
                {
                    newUserCode = StaticInfo.MakeUniqueCode(ref conManager, "Usercode", 20, DateTime.Today.ToString(), "yy", "UI", "-", "");
                    //user.UserCode = newUserCode;
                    userList[0].UserCode = newUserCode;
                    userCode = newUserCode;
                }
                else
                {
                    userCode = userList[0].UserCode;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteUser(ref CustomList<Users> userList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPName(userList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, userList);
                userList.AcceptChanges();
                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception ex)
            {
                conManager.RollBack();
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }
    }
}
