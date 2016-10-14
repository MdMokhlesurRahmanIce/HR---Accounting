using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ReportSuite.DAO
{
    [Serializable]
    public class ParameterFilterValue : BaseItem
    {
        public ParameterFilterValue()
        {
            SetAdded();
        }
        private String values = String.Empty;
        [Browsable(true), DisplayName("Values")]
        public String Values
        {
            get { return values; }
            set { values = value; }
        }
        private String actualValues = String.Empty;
        [Browsable(true), DisplayName("ActualValues")]
        public String ActualValues
        {
            get { return actualValues; }
            set { actualValues = value; }
        }
        private String displayMember = String.Empty;
        [Browsable(true), DisplayName("DisplayMember")]
        public String DisplayMember
        {
            get { return displayMember; }
            set { displayMember = value; }
        }
        public override Object[] GetParameterValues()
        {
            return null;
        }
        protected override void SetData(IDataRecord reader)
        {
            ActualValues = reader.GetString("ActualValues");
            DisplayMember = reader.GetString("DisplayMember");
            Values = reader.GetString("Values");
            SetUnchanged();
        }
        public static CustomList<ParameterFilterValue> GetReportValue(string parent)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ParameterFilterValue> ParameterFilterValueCollection = new CustomList<ParameterFilterValue>();
            IDataReader reader = null;
            String sql = "select OrgKey As ActualValues, OrgName As DisplayMember, OrgName As [Values]  from Gen_Org Where OrgParentKey in(" + parent + ")";//'" + userCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ParameterFilterValue newParameterFilterValue = new ParameterFilterValue();
                    newParameterFilterValue.SetData(reader);
                    ParameterFilterValueCollection.Add(newParameterFilterValue);
                }
                return ParameterFilterValueCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }

                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<ParameterFilterValue> GetReportValueDesig(string orgKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ParameterFilterValue> ParameterFilterValueCollection = new CustomList<ParameterFilterValue>();
            IDataReader reader = null;
            String sql = "select DesigKey As ActualValues, DesigName As DisplayMember, DesigName As [Values]  from Gen_Desig Where OrgKey in(" + orgKey + ")";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ParameterFilterValue newParameterFilterValue = new ParameterFilterValue();
                    newParameterFilterValue.SetData(reader);
                    ParameterFilterValueCollection.Add(newParameterFilterValue);
                }
                return ParameterFilterValueCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }

                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<ParameterFilterValue> GetReportValueFY(string orgKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ParameterFilterValue> ParameterFilterValueCollection = new CustomList<ParameterFilterValue>();
            IDataReader reader = null;
            String sql = "select FYKey As ActualValues, FYName As DisplayMember, FYName As [Values]  from Gen_FY Where OrgKey in(" + orgKey + ")";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ParameterFilterValue newParameterFilterValue = new ParameterFilterValue();
                    newParameterFilterValue.SetData(reader);
                    ParameterFilterValueCollection.Add(newParameterFilterValue);
                }
                return ParameterFilterValueCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }

                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<ParameterFilterValue> GetReportValueEmp(string search)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ParameterFilterValue> ParameterFilterValueCollection = new CustomList<ParameterFilterValue>();
            IDataReader reader = null;
            String sql = "Exec spReportViewerEmpSearch " + search;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ParameterFilterValue newParameterFilterValue = new ParameterFilterValue();
                    newParameterFilterValue.SetData(reader);
                    ParameterFilterValueCollection.Add(newParameterFilterValue);
                }
                return ParameterFilterValueCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }

                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}
