using ParkingManagement.Models;
using ParkManagementSysBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingManagement.Controllers
{
    public class HomeController : Controller
    {
        IBuisnessLayer ibuisnessLayer = new BuisnessLayer();
        public ActionResult Vechicle()
        {            
            Vechicle vechicle = new Vechicle()
            {
                lstVechicleType = ibuisnessLayer.GetVechileType().AsDataView(),
                lstVechicleName= ibuisnessLayer.GetVechileName(0).AsDataView(),
            };
            DataRow dr = vechicle.lstVechicleType.Table.NewRow();
            dr["VId"] = 0;
            dr["VechicleType"] = "--Select--";
            vechicle.lstVechicleType.Table.Rows.InsertAt(dr, 0);

            DataRow dr1 = vechicle.lstVechicleName.Table.NewRow();
            dr1["VId"] = 0;
            dr1["VechicleName"] = "--Select--";
            vechicle.lstVechicleName.Table.Rows.InsertAt(dr1, 0);

            return View(vechicle);
        }        
    }
}