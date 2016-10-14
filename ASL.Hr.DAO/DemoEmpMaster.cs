using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ASL.DATA;
using System.ComponentModel;
using ASL.STATIC;
using System.Data;
using ASL.DAL;

namespace ASL.Hr.DAO
{
    [Serializable]
   public class DemoEmpMaster:BaseItem
    {
        public DemoEmpMaster()
		{
			SetAdded();
		}
        #region Properties

        private System.Int32 _empCode;
        [Browsable(true), DisplayName("Employee Code")]
        public System.Int32 empCode
        {
            get
            {
                return _empCode;
            }
            set
            {
                if (PropertyChanged(_empCode, value))
                    _empCode = value;
            }
        }

        private System.String _empName;
        [Browsable(true), DisplayName("Employee Name")]
        public System.String empName
        {
            get
            {
                return _empName;
            }
            set
            {
                if (PropertyChanged(_empName, value))
                    _empName = value;
            }
        }
                
        private System.DateTime _Doj;
        [Browsable(true), DisplayName("Date of joining"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime Doj
        {
            get
            {
                return _Doj;
            }
            set
            {
                if (PropertyChanged(_Doj, value))
                    _Doj = value;
            }
        }

        

        private System.DateTime _Doc;
        [Browsable(true), DisplayName("Date of Confirm"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime Doc
        {
            get
            {
                return _Doc;
            }
            set
            {
                if (PropertyChanged(_Doc, value))
                    _Doc = value;
            }
        }

        //private System.Boolean _IsChecked;
        //[Browsable(true), DisplayName("IsChecked")]
        //public System.Boolean IsChecked
        //{
        //    get
        //    {
        //        return _IsChecked;
        //    }
        //    set
        //    {
        //        if (PropertyChanged(_IsChecked, value))
        //            _IsChecked = value;
        //    }
        //}
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _empCode, _empName, _Doj.Value(StaticInfo.DateFormat),_Doc.Value(StaticInfo.DateFormat) };
            else if (IsModified)
                parameterValues = new Object[] { _empCode, _empName, _Doj.Value(StaticInfo.DateFormat), _Doc.Value(StaticInfo.DateFormat) };
            else if (IsDeleted)
                parameterValues = new Object[] { _empCode };
            return parameterValues;
        }

        protected override void SetData(IDataRecord reader)
        {
            _empCode = reader.GetInt32("empCode");
            _empName = reader.GetString("empName");            
            _Doj = reader.GetDateTime("Doj");            
            _Doc = reader.GetDateTime("Doc");
            SetUnchanged();
        }

        public static CustomList<DemoEmpMaster> GetAllempMaster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DemoEmpMaster> empMasterCollection = new CustomList<DemoEmpMaster>();
            IDataReader reader = null;
            const String sql = "Select * from DemoEmp";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DemoEmpMaster newempMaster = new DemoEmpMaster();
                    newempMaster.SetData(reader);
                    empMasterCollection.Add(newempMaster);
                }
                empMasterCollection.InsertSpName = "spInsertDemoemp";
                empMasterCollection.UpdateSpName = "spUpdateDemoemp";
                empMasterCollection.DeleteSpName = "spDeleteDemoemp";
                return empMasterCollection;
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




        public static CustomList<DemoEmpMaster> GetSelectedemp(int empCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DemoEmpMaster> empCollection = new CustomList<DemoEmpMaster>();
            IDataReader reader = null;
            String sql = "select * from DemoEmp where empCode= " + empCode + "";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DemoEmpMaster newemp = new DemoEmpMaster();
                    newemp.SetData(reader);
                    empCollection.Add(newemp);
                }
                empCollection.InsertSpName = "spInsertDemoemp";
                empCollection.UpdateSpName = "spUpdateDemoemp";
                empCollection.DeleteSpName = "spDeleteDemoemp";
                return empCollection;
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
