using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkManagementSysDAL
{
    public class DataAccessLayer : IDataAccessLayer
    {
        public string ConnestionString = null;
        public DataAccessLayer()
        {
            ConnestionString = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
        }        

        public DataTable GetVechileType()
        {
            DataTable ldt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnestionString))
            {
                sqlConnection.Open();
                SqlCommand scommand = new SqlCommand("SPGetVechicleType", sqlConnection);
                SqlDataReader reader= scommand.ExecuteReader();
                ldt.Load(reader);
            }
            return ldt;
        }

        public DataTable GetVechileName(int VechicleId)
        {
            DataTable ldt = new DataTable();
            SqlParameter sqlParameter = new SqlParameter("@vechicleId", VechicleId);
            using (SqlConnection sqlConnection = new SqlConnection(ConnestionString))
            {
                sqlConnection.Open();
                SqlCommand scommand = new SqlCommand("SPGetVechicleName", sqlConnection);
                scommand.CommandType = CommandType.StoredProcedure;
                scommand.Parameters.Add(sqlParameter);
                SqlDataReader reader = scommand.ExecuteReader();
                ldt.Load(reader);
            }
            return ldt;
        }
        //public void GetParkingSlotCountStatus(int VechicleId,ref int VAailCount,ref int VOccupiedCount)        
        //{
        //    DataTable ldt = new DataTable();
        //    SqlParameter sqlParameter = new SqlParameter("@vechicleId", VechicleId);
        //    using (SqlConnection sqlConnection = new SqlConnection(ConnestionString))
        //    {
        //        sqlConnection.Open();
        //        SqlCommand scommand = new SqlCommand("GetCountOfVechicleSlots", sqlConnection);
        //        scommand.CommandType = CommandType.StoredProcedure;
        //        scommand.Parameters.Add(sqlParameter);
        //        SqlDataReader reader = scommand.ExecuteReader();
        //        ldt.Load(reader);
        //    }
        //    VAailCount = Convert.ToInt16(ldt.Rows[0]["AvailableCount"]);
        //    VOccupiedCount  = Convert.ToInt16(ldt.Rows[0]["OccupiedCount"]);
        //}
    }
}