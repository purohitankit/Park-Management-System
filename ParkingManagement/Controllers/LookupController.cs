using Newtonsoft.Json;
using ParkManagementSysBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingManagement.Controllers
{
    public class LookupController : Controller
    {
        IBuisnessLayer ibuisnessLayer = new BuisnessLayer();

        [HttpGet]
       [Route("Lookup/GetVechileNames")]
        public ActionResult GetVechileNames(int VechicleId)
        {
            string jsonStr= JsonConvert.SerializeObject(ibuisnessLayer.GetVechileName(VechicleId));
            return Json(jsonStr,JsonRequestBehavior.AllowGet);
        }
    }
}