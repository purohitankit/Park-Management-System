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

        public DataSet GetVechileName(int VechicleId)
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
            DataSet ds = new DataSet();
            ds.Tables.Add(ldt);
            ds.Tables.Add(GetParkingSlotCountStatus(VechicleId));
            return ds;
        }

        private DataTable GetParkingSlotCountStatus(int VechicleId)
        {
            DataTable ldt = new DataTable();
            SqlParameter sqlParameter = new SqlParameter("@vechicleId", VechicleId);
            using (SqlConnection sqlConnection = new SqlConnection(ConnestionString))
            {
                sqlConnection.Open();
                SqlCommand scommand = new SqlCommand("GetCountOfVechicleSlots", sqlConnection);
                scommand.CommandType = CommandType.StoredProcedure;
                scommand.Parameters.Add(sqlParameter);
                SqlDataReader reader = scommand.ExecuteReader();
                ldt.Load(reader);
            }
            return ldt;           
        }

        public int AddRemoveVechicles(int VechicleId, string VechicleType, string ActionName, ref int OccpCnt, ref int AvailCnt)
        {
            int res;
            SqlParameter sqlParameter = new SqlParameter("@VechicleId", VechicleId);
            SqlParameter sqlParameter1 = new SqlParameter("@VechicleType", VechicleType);
            SqlParameter sqlParameter2 = new SqlParameter("@Action", ActionName);
            using (SqlConnection sqlConnection = new SqlConnection(ConnestionString))
            {
                sqlConnection.Open();
                SqlCommand scommand = new SqlCommand("AddRemoveVechicles", sqlConnection);
                scommand.CommandType = CommandType.StoredProcedure;
                scommand.Parameters.Add(sqlParameter);
                scommand.Parameters.Add(sqlParameter1);
                scommand.Parameters.Add(sqlParameter2);
                res= Convert.ToInt16(scommand.ExecuteNonQuery());
            }

            DataTable ldt = new DataTable();
            ldt=GetParkingSlotCountStatus(VechicleId);

            OccpCnt = Convert.ToInt16(ldt.Rows[0]["OccupiedCount"]);
            AvailCnt = Convert.ToInt16(ldt.Rows[0]["AvailableCount"]);

            return res;
        }

        public int AddVechiclesCategory(string VechicleType, string VechicleName, int SlotSize)
        {
            int res;
            SqlParameter sqlParameter = new SqlParameter("@VechicleType", VechicleType);
            SqlParameter sqlParameter1 = new SqlParameter("@VechicleName", VechicleName);
            SqlParameter sqlParameter2 = new SqlParameter("@SlotSize", SlotSize);
            using (SqlConnection sqlConnection = new SqlConnection(ConnestionString))
            {
                sqlConnection.Open();
                SqlCommand scommand = new SqlCommand("AddDataToAuditVechicle", sqlConnection);
                scommand.CommandType = CommandType.StoredProcedure;
                scommand.Parameters.Add(sqlParameter);
                scommand.Parameters.Add(sqlParameter1);
                scommand.Parameters.Add(sqlParameter2);
                res = Convert.ToInt16(scommand.ExecuteNonQuery());
            }           

            return res;

        }
    }
}