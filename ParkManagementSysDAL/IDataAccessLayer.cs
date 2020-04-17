﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkManagementSysDAL
{
    interface IDataAccessLayer
    {
        DataTable GetVechileType();
        DataSet GetVechileName(int VechicleId);
        int AddRemoveVechicles(int VechicleId, string VechicleType, string ActionName, ref int OccpCnt, ref int AvailCnt);
    }
}
