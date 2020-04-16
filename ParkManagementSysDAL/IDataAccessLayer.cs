using System;
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
        DataTable GetVechileName(int VechicleId);        
    }
}
