using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.Hr.DAO;
using ASL.DAL;
using ASL.STATIC;
using System.Collections;

namespace ASL.Hr.BLL
{
    public class AttendImportManager
    {
        public CustomList<Atten_Device> GetAllAtten_DeviceSQL()
        {
            return Atten_Device.GetAllAtten_DeviceSQL();
        }
        public CustomList<DiviceData> GetAllDeviceData(string conn, string query)
        {
            return DiviceData.GetAllDeviceData(conn, query);
        }
    }
}
