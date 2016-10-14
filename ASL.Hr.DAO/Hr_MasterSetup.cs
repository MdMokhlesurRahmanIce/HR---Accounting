using System;
using System.Web;
using System.Text;
using System.Web.SessionState;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;


namespace ASL.Hr.DAO
{
    [Serializable]
    public class Hr_MasterSetup : BaseItem
    {
        public Hr_MasterSetup()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _SetupID;
        [Browsable(true), DisplayName("SetupID")]
        public System.Int32 SetupID
        {
            get
            {
                return _SetupID;
            }
            set
            {
                if (PropertyChanged(_SetupID, value))
                    _SetupID = value;
            }
        }

        private System.String _ItemType;
        [Browsable(true), DisplayName("ItemType")]
        public System.String ItemType
        {
            get
            {
                return _ItemType;
            }
            set
            {
                if (PropertyChanged(_ItemType, value))
                    _ItemType = value;
            }
        }

        private System.String _ItemValue;
        [Browsable(true), DisplayName("ItemValue")]
        public System.String ItemValue
        {
            get
            {
                return _ItemValue;
            }
            set
            {
                if (PropertyChanged(_ItemValue, value))
                    _ItemValue = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ItemType, _ItemValue };
            else if (IsModified)
                parameterValues = new Object[] { _ItemType, _ItemValue };
            else if (IsDeleted)
                parameterValues = new Object[] { _SetupID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SetupID = reader.GetInt32("SetupID");
            _ItemType = reader.GetString("ItemType");
            _ItemValue = reader.GetString("ItemValue");
            SetUnchanged();
        }
        public static Int32 GetAllHr_MasterSetup()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Int32 IsOT = 0;
            try
            {
                String sql = "select Cast(ItemValue as int) from Hr_MasterSetup Where ItemType='IsOT'";
                Object OT = conManager.ExecuteScalarWrapper(sql);
                IsOT = Convert.ToInt32(OT);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return IsOT;
        }

        public static Int32 GetAllHr_MasterSetup(String ItemType)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Int32 IsValue = 0;
            try
            {
                String sql = "select Cast(ItemValue as int) from Hr_MasterSetup Where ItemType='" + ItemType + "'";
                Object obj = conManager.ExecuteScalarWrapper(sql);
                IsValue = Convert.ToInt32(obj);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return IsValue;
        }


        public static string GetAllHr_MasterSetupBufferTime()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            string IsValue = "";
            try
            {
                IDataReader reader = null;
                String sql = "select ItemValue from Hr_MasterSetup Where ItemType IN('InTimeBuffer','OutTimeBuffer','LunchInBuffer','LunchOutBuffer')";
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Hr_MasterSetup newHr_MasterSetup = new Hr_MasterSetup();
                    if (IsValue == "")
                    {
                        IsValue = reader.GetString("ItemValue");
                    }
                    else
                    {
                        IsValue = IsValue + "," + reader.GetString("ItemValue");
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return IsValue;
        }
        public static void ChangeMasterSetupValue(string itemValue, string parms)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            try
            {
                String sql = "UPDATE Hr_MasterSetup SET ItemValue='" + itemValue + "' Where ItemType='" + parms + "'";
                conManager.ExecuteScalarWrapper(sql);
            }
            catch (Exception ex)
            {
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
        public static CustomList<Hr_MasterSetup> GetAllHr_MasterCommissionAndVATPercent()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            string IsValue = "";
            CustomList<Hr_MasterSetup> Hr_MasterSetupList = new CustomList<Hr_MasterSetup>();
            try
            {
                IDataReader reader = null;
                String sql = "select ItemValue from Hr_MasterSetup Where ItemType IN('CP','VATP','InventoryP')";
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Hr_MasterSetup newHr_MasterSetup = new Hr_MasterSetup();
                    newHr_MasterSetup._ItemValue = reader.GetString("ItemValue");
                    Hr_MasterSetupList.Add(newHr_MasterSetup);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return Hr_MasterSetupList;
        }
    }
}