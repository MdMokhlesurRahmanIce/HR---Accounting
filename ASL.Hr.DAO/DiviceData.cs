using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ASL.Hr.DAO
{
    public class DiviceData : BaseItem
    {
        public DiviceData()
        {
            //SetAdded();
        }
        // public DiviceData() { }
        public DiviceData(String cdate, String ctime, String cardNum)
        {
            this.CDate = cdate;
            this.CTime = ctime;
            this.CardNum = cardNum;
            this.nDateTime = nDateTime;
        }
        public String CTime { get; set; }
        public String CDate { get; set; }
        public String CardNum { get; set; }
        public Int32 nDateTime { get; set; }

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            //if (IsAdded)
            // parameterValues = new Object[] { _DeviceName, _Extension, _IsFileUpload, _SqlConnectionString, _QueryString };
            //else if (IsModified)
            // parameterValues = new Object[] { _DeviceName, _Extension, _IsFileUpload, _SqlConnectionString, _QueryString };
            //else if (IsDeleted)
            //parameterValues = new Object[] { _id };
            return parameterValues;
        }

        protected override void SetData(IDataRecord reader)
        {
            CTime = reader.GetString("CTime");
            CDate = reader.GetString("CDate");
            CardNum = reader.GetString("CardNum");
            SetUnchanged();
        }
        private void SetDataDevice(IDataRecord reader)
        {
            //CTime = reader.GetString("CTime");
            //CDate = reader.GetString("CDate");
            nDateTime = reader.GetInt32("nDateTime");
            CardNum = reader.GetString("CardNum");
            SetUnchanged();
        }
        public static CustomList<DiviceData> GetAllDeviceData(string conn, string query)
        {
            string cs = conn;

            string sql = query;
            //ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DiviceData> DiviceDataCollection = new CustomList<DiviceData>();
            IDataReader reader = null;
            //const String sql = "select EmpKey,EmpName,EmpCode,PunchCardNo from HRM_Emp";
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                //conManager.OpenDataReader(query, out reader);
                while (rdr.Read())
                {
                    DiviceData newDiviceData = new DiviceData();
                    newDiviceData.SetDataDevice(rdr);
                    DiviceDataCollection.Add(newDiviceData);
                }

                return DiviceDataCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}
