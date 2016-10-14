using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASL.Hr.DAO
{
    public class ATT_IO_Temp
    {
        #region Fields and Properties

        private System.Int64 _IOKey;
        public System.Int64 IOKey
        {
            get
            {
                return _IOKey;
            }
            set
            {
                _IOKey = value;
            }
        }

        private System.String _EmpCode;
        public System.String EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                _EmpCode = value;
            }
        }

        private System.DateTime _AttDate;
        public System.DateTime AttDate
        {
            get
            {
                return _AttDate;
            }
            set
            {
                _AttDate = value;
            }
        }

        private System.TimeSpan _InTime;
        public System.TimeSpan InTime
        {
            get
            {
                return _InTime;
            }
            set
            {
                _InTime = value;
            }
        }

        private System.TimeSpan _OutTime;
        public System.TimeSpan OutTime
        {
            get
            {
                return _OutTime;
            }
            set
            {
                _OutTime = value;
            }
        }

        private System.String _AttID;
        public System.String AttID
        {
            get
            {
                return _AttID;
            }
            set
            {
                _AttID = value;
            }
        }

        private System.String _IOFileRef;
        public System.String IOFileRef
        {
            get
            {
                return _IOFileRef;
            }
            set
            {
                _IOFileRef = value;
            }
        }

        private System.String _Remarks;
        public System.String Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }

        private System.Boolean _IsManual;
        public System.Boolean IsManual
        {
            get
            {
                return _IsManual;
            }
            set
            {
                _IsManual = value;
            }
        }

        //Add Properties shamim
        private System.Int64 _RowID;
        public System.Int64 RowID
        {
            get
            {
                return _RowID;
            }
            set
            {
                _RowID = value;
            }
        }

        private System.String _EmployeeCode;
        public System.String EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
            set
            {
                _EmployeeCode = value;
            }
        }

        private System.String _PTime;
        public System.String PTime
        {
            get
            {
                return _PTime;
            }
            set
            {
                _PTime = value;
            }
        }

        private System.DateTime _WorkDate;
        public System.DateTime WorkDate
        {
            get
            {
                return _WorkDate;
            }
            set
            {
                _WorkDate = value;
            }
        }

        private System.String _PunchCardNo;
        public System.String PunchCardNo
        {
            get
            {
                return _PunchCardNo;
            }
            set
            {
                _PunchCardNo = value;
            }
        }

        private System.String _DeviceID;
        public System.String DeviceID
        {
            get
            {
                return _DeviceID;
            }
            set
            {
                _DeviceID = value;
            }
        }
        #endregion
    }
}
