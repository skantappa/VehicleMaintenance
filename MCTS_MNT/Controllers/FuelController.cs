using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCTS_MNT.EntityDataModel;

namespace MCTS_MNT.Controllers
{
    public class FuelController : Controller
    {
        public EntitiesMNT MNTEntity = new EntitiesMNT();
        // GET: Fuel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FDFU()
        {
            if (MNTEntity.MNT_FDFU.Count() > 0)
            { ViewBag.Message = "Data Exists"; }
            return View(MNTEntity.MNT_FDFU.ToList());
        }

        public ActionResult AddFDFU()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddFDFU(MCTS_MNT.EntityDataModel.MNT_FDFU objaddFdfu)
        {
            bool blnAddedFDFU = true;
            try
            {
                MNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_FDFU>(objaddFdfu).State = System.Data.Entity.EntityState.Added;
                MNTEntity.SaveChanges();
            }
            catch (Exception ex) { blnAddedFDFU = false; return RedirectToAction("Fleet", "Home"); }

            if (blnAddedFDFU == true)
            {
                return RedirectToAction("FDFU", "FUEL");
            }
            else return RedirectToAction("FDFU", "FUEL");
        }


        [Route("{FdStation}/{FdVehicle}/{FdHour}/{FdMinute}/{FdSec}")]
        public ActionResult EditFDFU(string FdStation, string FdDate, short FdVehicle, short FdHour, short FdMinute, short FdSec)
        {
            DateTime dtFdDate = Convert.ToDateTime(FdDate);
            return View(MNTEntity.MNT_FDFU.Where(c => c.FDFU_DATE== dtFdDate && c.VEHICLE==FdVehicle && c.FUEL_HOUR==FdHour && c.FUEL_MINUTE==FdMinute && c.FUEL_SECOND==FdSec).SingleOrDefault());
        }

        [AcceptVerbs(HttpVerbs.Post)]
             public ActionResult UpdateFDFU(MNT_FDFU objFDFU)
        {
            MNTEntity.Entry<MNT_FDFU>(objFDFU).State = System.Data.Entity.EntityState.Modified;
            MNTEntity.SaveChanges();
            return RedirectToAction("FDFU", "Fuel");
        }


        public ActionResult KKFU()
        {
            if (MNTEntity.MNT_KKFU.Count() > 0)
            { ViewBag.Message = "Data Exists"; }
            return View(MNTEntity.MNT_KKFU.ToList());
        }

        public ActionResult AddKKFU()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddKKFU(MCTS_MNT.EntityDataModel.MNT_KKFU objaddKKfu)
        {
            bool blnAddedKKFU = true;
            try
            {
                MNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_KKFU>(objaddKKfu).State = System.Data.Entity.EntityState.Added;
                MNTEntity.SaveChanges();
            }
            catch (Exception ex) { blnAddedKKFU = false; return RedirectToAction("Fleet", "Home"); }

            if (blnAddedKKFU == true)
            {
                return RedirectToAction("KKFU", "FUEL");
            }
            else return RedirectToAction("KKFU", "FUEL");
        }


        //[Route("{KKVehicle}/{KKHour}/{KKMinute}/{KKSec}")]
        //public ActionResult EditKKFU(string KKDate, short KKVehicle, short KKHour, short KKMinute, short KKSec)
        //{
        //    DateTime dtKKDate = Convert.ToDateTime(KKDate);
        //    return View(MNTEntity.MNT_KKFU.Where(c => c.KKFU_DATE == dtKKDate && c.VEHICLE == KKVehicle && c.FUEL_HOUR == KKHour && c.FUEL_MINUTE == KKMinute && c.FUEL_SECOND == KKSec).SingleOrDefault());
        //}
        [Route("Fuel/EditKKFU/{KKVehicle}/{KKHour}/{KKMinute}/{KKSec}")]
        public ActionResult EditKKFU(string KKDate, short KKVehicle, short KKHour, short KKMinute, short KKSec)
        {
            DateTime dtKKDate = Convert.ToDateTime(KKDate);
            return View(MNTEntity.MNT_KKFU.Where(c => c.KKFU_DATE == dtKKDate && c.VEHICLE == KKVehicle && c.FUEL_HOUR == KKHour && c.FUEL_MINUTE == KKMinute && c.FUEL_SECOND == KKSec).SingleOrDefault());
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateKKFU(MNT_KKFU objKKFU)
        {
            MNTEntity.Entry<MNT_KKFU>(objKKFU).State = System.Data.Entity.EntityState.Modified;
            MNTEntity.SaveChanges();
            return RedirectToAction("KKFU", "Fuel");
        }

        [HttpPost]
        public ContentResult MNTUpdateDailyFuel(string Station)
        {
            try
            {
                MNTEntity.Database.ExecuteSqlCommand("Exec MNFUEL8000_BATCH_UPDATE_FUEL @P_STATION", Station);
            }
            catch(Exception bex)
            {
                return Content("<script language='javascript' type='text/javascript'>alert(BatchUpdateDailyFuel Failed -> Error Message: " +  bex.Message.ToString() + ");</script>");
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Maintenance Revenue records were updated successfully with Daily Fuel data provided from FondDuLac and Kinnickinic Garages');</script>");

        }

    }
}