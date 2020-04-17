using ParkManagementSysDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ParkManagementSysBL
{
    public class BuisnessLayer : IBuisnessLayer
    {
        DataAccessLayer idataccesslayer = new DataAccessLayer();
        public DataTable GetVechileType()
        {
            return idataccesslayer.GetVechileType();   
        }
        public DataSet GetVechileName(int VechicleId)
        {
            return idataccesslayer.GetVechileName(VechicleId);
        }
        public int AddRemoveVechicles(int VechicleId, string VechicleType, string ActionName, ref int OccpCnt, ref int AvailCnt)
        {
            return idataccesslayer.AddRemoveVechicles(VechicleId,VechicleType, ActionName,ref OccpCnt,ref AvailCnt);
        }       
    }
}