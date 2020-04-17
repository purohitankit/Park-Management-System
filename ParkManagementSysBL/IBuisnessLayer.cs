using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkManagementSysBL
{
    public interface IBuisnessLayer
    {
        DataTable GetVechileType();
        DataSet GetVechileName(int VechicleId);
        int AddRemoveVechicles(int VechicleId, string VechicleType, string ActionName,ref int OccpCnt,ref int AvailCnt);
        int AddVechiclesCategory(string VechicleType, string VechicleName, int SlotSize);
    }
}
