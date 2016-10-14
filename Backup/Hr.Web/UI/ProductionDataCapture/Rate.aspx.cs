using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;
using System.Collections;
using System.Data.SqlClient;

namespace Hr.Web.UI.ProductionDataCapture
{
    public partial class Rate : PageBase
    {
        RateManager manager = new RateManager();
        #region Constractor
        public Rate()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<RateDynamicGrid> RateDynamicGridList
        {
            get
            {
                if (Session["Rate_RateDynamicGridList"] == null)
                    return new CustomList<RateDynamicGrid>();
                else
                    return (CustomList<RateDynamicGrid>)Session["Rate_RateDynamicGridList"];
            }
            set
            {
                Session["Rate_RateDynamicGridList"] = value;
            }
        }
        private CustomList<HouseKeepingValue> HouseKeepingValueList1
        {
            get
            {
                if (Session["Rate_HouseKeepingValueList1"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["Rate_HouseKeepingValueList1"];
            }
            set
            {
                Session["Rate_HouseKeepingValueList1"] = value;
            }
        }
        private CustomList<HouseKeepingValue> HouseKeepingValueList2
        {
            get
            {
                if (Session["Rate_HouseKeepingValueList2"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["Rate_HouseKeepingValueList2"];
            }
            set
            {
                Session["Rate_HouseKeepingValueList2"] = value;
            }
        }
        private CustomList<HouseKeepingValue> HouseKeepingValueList3
        {
            get
            {
                if (Session["Rate_HouseKeepingValueList3"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["Rate_HouseKeepingValueList3"];
            }
            set
            {
                Session["Rate_HouseKeepingValueList3"] = value;
            }
        }
        private CustomList<HouseKeepingValue> HouseKeepingValueList4
        {
            get
            {
                if (Session["Rate_HouseKeepingValueList4"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["Rate_HouseKeepingValueList4"];
            }
            set
            {
                Session["Rate_HouseKeepingValueList4"] = value;
            }
        }
        private CustomList<HouseKeepingValue> HouseKeepingValueList5
        {
            get
            {
                if (Session["Rate_HouseKeepingValueList5"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["Rate_HouseKeepingValueList5"];
            }
            set
            {
                Session["Rate_HouseKeepingValueList5"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
            }
        }
        #region All Method
        private void InitializeSession()
        {
            try
            {
                RateDynamicGridList = new CustomList<RateDynamicGrid>();
                CustomList<DataCaptureRate> DataCaptureRateList = manager.GetAllRate();
                String id = "";
                Int32 count = 1;
                RateDynamicGrid newObj = new RateDynamicGrid();
                if (DataCaptureRateList.Count != 0)
                {
                    id = DataCaptureRateList[0].DataCapRateRuleID;
                }
                if (DataCaptureRateList.Count != 0)
                {
                    foreach (DataCaptureRate dCR in DataCaptureRateList)
                    {
                        if (id != dCR.DataCapRateRuleID)
                        {
                            newObj.SetUnchanged();
                            RateDynamicGridList.Add(newObj);
                            newObj = new RateDynamicGrid();
                            count = 1;
                            id = dCR.DataCapRateRuleID;
                        }
                        if (count == 1)
                        {
                            newObj.RateKey1 = dCR.RateKey;
                            newObj.Key1 = dCR.Field;
                            newObj.Rate = dCR.Rate;
                            newObj.RateID = dCR.DataCapRateRuleID;
                        }
                        if (count == 2)
                        {
                            newObj.RateKey2 = dCR.RateKey;
                            newObj.Key2 = dCR.Field;
                            newObj.RateID = dCR.DataCapRateRuleID;
                        }
                        if (count == 3)
                        {
                            newObj.RateKey3 = dCR.RateKey;
                            newObj.Key3 = dCR.Field;
                            newObj.RateID = dCR.DataCapRateRuleID;
                        }
                        if (count == 4)
                        {
                            newObj.RateKey4 = dCR.RateKey;
                            newObj.Key4 = dCR.Field;
                            newObj.RateID = dCR.DataCapRateRuleID;
                        }
                        if (count == 5)
                        {
                            newObj.RateKey5 = dCR.RateKey;
                            newObj.Key5 = dCR.Field;
                            newObj.RateID = dCR.DataCapRateRuleID;
                        }
                        count++;
                    }
                    newObj.SetUnchanged();
                    RateDynamicGridList.Add(newObj);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ClearControls()
        {
            try
            {
                InitializeSession();
                CustomList<DataCaptureConfiguration> FieldList = manager.GetAllDataCaptureConfigurationForRate();
                int count = 1;
                foreach (DataCaptureConfiguration dCC in FieldList)
                {
                    if (count == 1)
                    {
                        HouseKeepingValueList1 = new CustomList<HouseKeepingValue>();
                        count++;
                    }
                    else if (count == 2)
                    {
                        HouseKeepingValueList2 = new CustomList<HouseKeepingValue>();
                        count++;
                    }
                    else if (count == 3)
                    {
                        HouseKeepingValueList3 = new CustomList<HouseKeepingValue>();
                        count++;
                    }
                    else if (count == 4)
                    {
                        HouseKeepingValueList4 = new CustomList<HouseKeepingValue>();
                        count++;
                    }
                    else if (count == 5)
                    {
                        HouseKeepingValueList5 = new CustomList<HouseKeepingValue>();
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<RateDynamicGrid> lstRateDynamicGrid = RateDynamicGridList;
                CustomList<DataCaptureConfiguration> FieldList = manager.GetAllDataCaptureConfigurationForRate();
                CustomList<DataCaptureRate> DataCaptureRateList = new CustomList<DataCaptureRate>();
                foreach (RateDynamicGrid rDG in lstRateDynamicGrid)
                {
                    string DataCapRateRuleID = "";
                    if (!rDG.IsUnchanged)
                    {
                        DataCaptureRate newObj1 = new DataCaptureRate();
                        DataCaptureRate newObj2 = new DataCaptureRate();
                        DataCaptureRate newObj3 = new DataCaptureRate();
                        DataCaptureRate newObj4 = new DataCaptureRate();
                        DataCaptureRate newObj5 = new DataCaptureRate();
                        DataCaptureRate newObj6 = new DataCaptureRate();
                        if (rDG.Key1 != 0 && rDG.Key1 != -1)
                        {
                            newObj1.RateKey = rDG.RateKey1;
                            newObj1.Field = rDG.Key1;
                            newObj1.Rate = rDG.Rate;
                            newObj1.SetAdded();
                            DataCapRateRuleID = FieldList[0].Field + ":" + HouseKeepingValue.GetHKName(rDG.Key1);
                            if (rDG.IsDeleted)
                            {
                                newObj1.DataCapRateRuleID = rDG.RateID;
                                newObj1.Delete();
                            }
                        }
                        if (rDG.Key2 != 0 && rDG.Key2 != -1)
                        {
                            newObj2.RateKey = rDG.RateKey2;
                            newObj2.Field = rDG.Key2;
                            newObj2.Rate = rDG.Rate;
                            newObj2.SetAdded();
                            DataCapRateRuleID += "-" + FieldList[1].Field + ":" + HouseKeepingValue.GetHKName(rDG.Key2);
                            if (rDG.IsDeleted)
                            {
                                newObj2.DataCapRateRuleID = rDG.RateID;
                                newObj2.Delete();
                            }
                        }
                        if (rDG.Key3 != 0 && rDG.Key3 != -1)
                        {
                            newObj3.RateKey = rDG.RateKey3;
                            newObj3.Field = rDG.Key3;
                            newObj3.Rate = rDG.Rate;
                            newObj3.SetAdded();
                            DataCapRateRuleID += "-" + FieldList[2].Field + ":" + HouseKeepingValue.GetHKName(rDG.Key3);
                            if (rDG.IsDeleted)
                            {
                                newObj3.DataCapRateRuleID = rDG.RateID;
                                newObj3.Delete();
                            }
                        }
                        if (rDG.Key4 != 0 && rDG.Key4 != -1)
                        {
                            newObj4.RateKey = rDG.RateKey4;
                            newObj4.Field = rDG.Key4;
                            newObj4.Rate = rDG.Rate;
                            if (rDG.RateKey4 == 0)
                            {
                                newObj4.SetAdded();
                                DataCapRateRuleID += "-" + FieldList[3].Field + ":" + HouseKeepingValue.GetHKName(rDG.Key4);
                            }
                            else if (rDG.IsDeleted)
                            {
                                newObj4.DataCapRateRuleID = rDG.RateID;
                                newObj4.Delete();
                            }
                        }
                        if (rDG.Key5 != 0 && rDG.Key5 != -1)
                        {
                            newObj5.RateKey = rDG.RateKey5;
                            newObj5.Field = rDG.Key5;
                            newObj5.Rate = rDG.Rate;
                            newObj5.SetAdded();
                            DataCapRateRuleID += "-" + FieldList[4].Field + ":" + HouseKeepingValue.GetHKName(rDG.Key5);
                            if (rDG.IsDeleted)
                            {
                                newObj5.DataCapRateRuleID = rDG.RateID;
                                newObj5.Delete();
                            }
                        }
                        if (rDG.Key6 != 0 && rDG.Key6 != -1)
                        {
                            newObj6.RateKey = rDG.RateKey6;
                            newObj6.Field = rDG.Key6;
                            newObj6.Rate = rDG.Rate;
                            newObj6.SetAdded();
                            DataCapRateRuleID += "-" + FieldList[5].Field + ":" + HouseKeepingValue.GetHKName(rDG.Key6);
                            if (rDG.IsDeleted)
                            {
                                newObj6.DataCapRateRuleID = rDG.RateID;
                                newObj6.Delete();
                            }
                        }

                        if (newObj1.Field != 0 && newObj1.Field != -1)
                        {
                            DataCaptureRateList = new CustomList<DataCaptureRate>();
                            newObj1.DataCapRateRuleID = DataCapRateRuleID;
                            DataCaptureRateList.Add(newObj1);
                            if (!CheckUserAuthentication(DataCaptureRateList)) return;
                        }
                        if (newObj2.Field != 0 && newObj2.Field != -1)
                        {
                            newObj2.DataCapRateRuleID = DataCapRateRuleID;
                            DataCaptureRateList.Add(newObj2);
                        }
                        if (newObj3.Field != 0 && newObj3.Field != -1)
                        {
                            newObj3.DataCapRateRuleID = DataCapRateRuleID;
                            DataCaptureRateList.Add(newObj3);
                        }
                        if (newObj4.Field != 0 && newObj4.Field != -1)
                        {
                            newObj4.DataCapRateRuleID = DataCapRateRuleID;
                            DataCaptureRateList.Add(newObj4);
                        }
                        if (newObj5.Field != 0 && newObj5.Field != -1)
                        {
                            newObj5.DataCapRateRuleID = DataCapRateRuleID;
                            DataCaptureRateList.Add(newObj5);
                        }
                        if (newObj6.Field != 0 && newObj6.Field != -1)
                        {
                            newObj6.DataCapRateRuleID = DataCapRateRuleID;
                            DataCaptureRateList.Add(newObj6);
                        }
                        manager.SaveDataDataCapture(ref DataCaptureRateList);

                    }
                }
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);

            }
            catch (SqlException ex)
            {
                this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        #endregion
    }
}