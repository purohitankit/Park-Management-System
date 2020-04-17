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

        [HttpPost]
        [Route("Lookup/AddRemoveVechicles")]
        public ActionResult AddRemoveVechicles(int VechicleId,string VechicleType, string ActionName)
        {
            int OccpCnt=0;
            int AvailCnt=0;
            string jsonStr = JsonConvert.SerializeObject(ibuisnessLayer.AddRemoveVechicles(VechicleId, VechicleType, ActionName,ref OccpCnt,ref AvailCnt));
            var jsonObj = new
            {
                res=jsonStr,
                OccupCnt=OccpCnt,
                AvailCnt=AvailCnt
            };
            return Json(jsonObj, JsonRequestBehavior.AllowGet);
        }        
    }
}