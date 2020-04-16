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
        public DataTable GetVechileName(int VechicleId)
        {
            return idataccesslayer.GetVechileName(VechicleId);
        }        
    }
}