using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCTS_MNT.EntityDataModel;
using System.Data;
using System.Data.Entity;

namespace MCTS_MNT.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public EntitiesMNT objMNTEntity = new EntitiesMNT();
        public ActionResult Index()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.MyData = username;
            return View();
        }

        public ActionResult About()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Fleet()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Your application description page.";
            return View(objMNTEntity.MNT_FLET.ToList());
        }

        public ActionResult AddFleet()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Add Fleet page.";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddFleet(MCTS_MNT.EntityDataModel.MNT_FLET objFleet)
        {
            bool blnAddedFleet = true;
            try
            {
                objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_FLET>(objFleet).State = System.Data.Entity.EntityState.Added;
                objMNTEntity.SaveChanges();
            }
            catch (Exception ex) { blnAddedFleet = false;  return RedirectToAction("Fleet", "Home"); }
          
            if(blnAddedFleet == true) { 
            return RedirectToAction("MNTPMSCHEDULE", "Home");}else return RedirectToAction("Fleet", "Home");
        }


        public ActionResult EditFleet(string id)
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Fleet Edit page.";
            return View(objMNTEntity.MNT_FLET.Where(c=>c.FLEET_CODE.Equals(id)).SingleOrDefault());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditFleet(MCTS_MNT.EntityDataModel.MNT_FLET objFleet)
        {
            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_FLET>(objFleet).State = System.Data.Entity.EntityState.Modified;
            objMNTEntity.SaveChanges();
            return RedirectToAction("Fleet", "Home");
        }


        public ActionResult MNTPMSCHEDULE()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Your application description page.";
            return View(objMNTEntity.MNT_PMSC.ToList());
        }

        public ActionResult AddPMSCHEDULE()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Add Fleet page.";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddPMSCHEDULE(MCTS_MNT.EntityDataModel.MNT_PMSC objPMSC)
        {
            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_PMSC>(objPMSC).State = System.Data.Entity.EntityState.Added;
            objMNTEntity.SaveChanges();
            return RedirectToAction("MNTPMSCHEDULE", "Home");
        }


        public ActionResult EditPMSCHEDULE(string id)
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Fleet Edit page.";
            return View(objMNTEntity.MNT_PMSC.Where(c => c.CODE_TYPE.Equals(id)).SingleOrDefault());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditPMSCHEDULE(MCTS_MNT.EntityDataModel.MNT_PMSC objPMSC)
        {
            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_PMSC>(objPMSC).State = System.Data.Entity.EntityState.Modified;
            objMNTEntity.SaveChanges();
            return RedirectToAction("MNTPMSCHEDULE", "Home");
        }


        public ActionResult MNTBadge()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Your application description page.";
            return View(objMNTEntity.MNT_TBAD.ToList());
        }

        public ActionResult AddBadge()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Add Badge page.";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddBadge(MCTS_MNT.EntityDataModel.MNT_TBAD objTBad)
        {
            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_TBAD>(objTBad).State = System.Data.Entity.EntityState.Added;
            objMNTEntity.SaveChanges();
            return RedirectToAction("MNTBadge", "Home");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteBadge(Int32 Id)
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            MCTS_MNT.EntityDataModel.MNT_TBAD objDelTBad = new MNT_TBAD();
            objDelTBad = objMNTEntity.MNT_TBAD.Where(d => d.BADGE.Equals(Id)).SingleOrDefault();
            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_TBAD>(objDelTBad).State = System.Data.Entity.EntityState.Deleted;
            objMNTEntity.SaveChanges();
            return RedirectToAction("MNTBadge", "Home");
        }

        public ActionResult MNTTireRetorque()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Your application description page.";
            return View(objMNTEntity.MNT_RTRQ.ToList());
        }
        public ActionResult AddTireRETRQ()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTireRETRQ(MCTS_MNT.EntityDataModel.MNT_RTRQ objaddRtrq)
        {
            bool blnAddedFRtrq = true;
            try
            {
                List<MNT_VEHICLE> lstRevVehicle = objMNTEntity.MNT_VEHICLE.Where(b => b.VEHICLE_NUMBER == objaddRtrq.BUS_NUMBER).ToList();
                if (lstRevVehicle.Count() > 0)
                {
                    
                    objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_RTRQ>(objaddRtrq).State = System.Data.Entity.EntityState.Added;
                    objMNTEntity.SaveChanges();
                }
                else
                {
                    blnAddedFRtrq = false;
                    return RedirectToAction("MNTTireRetorque", "Home");
                }

            }
            catch (Exception ex) { blnAddedFRtrq = false; return RedirectToAction("Fleet", "Home"); }

            if (blnAddedFRtrq == true)
            {
                return RedirectToAction("MNTTireRetorque", "Home");
            }
            else return RedirectToAction("MNTTireRetorque", "Home"); 
        }


        [Route("{RTRQBUSNo}/{RTRQWheelPos}/{RTRQStatus}")]
        public ActionResult EditRTRQ(string RTRQDate, int RTRQBUSNo, string RTRQWheelPos, string RTRQStatus)
        {
            DateTime dtRTRQDate = Convert.ToDateTime(RTRQDate);
            string strRTRQWheelPos = RTRQWheelPos + ' ';
            return View(objMNTEntity.MNT_RTRQ.Where(c => c.DATE_96 == dtRTRQDate && c.BUS_NUMBER == RTRQBUSNo && c.WHEEL_POSITION == strRTRQWheelPos && c.STATUS == RTRQStatus).SingleOrDefault());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateRTRQ(MNT_RTRQ objRTRQ)
        {
            objMNTEntity.Entry<MNT_RTRQ>(objRTRQ).State = System.Data.Entity.EntityState.Modified;
            objMNTEntity.SaveChanges();
            return RedirectToAction("MNTTireRetorque", "Home");
        }

        public ActionResult MNTVehicleHistory()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Your application description page.";
            //List<short> VehList = objMNTEntity.MNT_VEHICLE.Where(v => v.VEHICLE_TYPE == "REVENUE").Select(d => d.VEHICLE_NUMBER).ToList();
            //ViewBag.VehList = new SelectList(VehList);
            return View(objMNTEntity.MNT_WHPE.ToList());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateHistory(MNT_WHPE objVehHistory)
        {
            objMNTEntity.Entry<MNT_WHPE>(objVehHistory).State = System.Data.Entity.EntityState.Modified;
            objMNTEntity.SaveChanges();
            return RedirectToAction("MNTVehicleHistory", "Home");
        }

        public ActionResult MNTBrakes()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Your application description page.";
            //List<short> VehList = objMNTEntity.MNT_VEHICLE.Where(v => v.VEHICLE_TYPE == "REVENUE").Select(d => d.VEHICLE_NUMBER).ToList();
            //ViewBag.VehList = new SelectList(VehList);
            return View(objMNTEntity.MNT_BAKE.ToList());
        }
        public ActionResult AddBrakes()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddBrakes(MCTS_MNT.EntityDataModel.MNT_BAKE objaddBrakes)
        {
            bool blnAddedBrakes = true;
            try
            {
                List<MNT_VEHICLE> lstRevVehicle = objMNTEntity.MNT_VEHICLE.Where(b => b.VEHICLE_NUMBER == objaddBrakes.BUS_NUMBER).ToList();
                //Error at : 
                DateTime dtNullDate = Convert.ToDateTime("1/1/1901");
                MNT_BAKE lstBake = objMNTEntity.MNT_BAKE.Where(c => c.BUS_NUMBER == objaddBrakes.BUS_NUMBER && c.DATE_BRAKE_OFF == dtNullDate && c.AXLE_POSITION == objaddBrakes.AXLE_POSITION).SingleOrDefault();
                MNT_BAKE lstNewBake = new MNT_BAKE();// objMNTEntity.MNT_BAKE.Where(c => c.BUS_NUMBER == objaddBrakes.BUS_NUMBER && c.DATE_BRAKE_OFF == dtNullDate && c.AXLE_POSITION == objaddBrakes.AXLE_POSITION).SingleOrDefault();
                if (lstRevVehicle.Count() > 0)
                {
                    if (lstBake!=null  && lstBake.BUS_NUMBER>0)
                    {
                        try
                        {
                            lstNewBake.BUS_NUMBER = lstBake.BUS_NUMBER;
                            lstNewBake.AXLE_POSITION = lstBake.AXLE_POSITION;
                            lstNewBake.DATE_BRAKE_OFF =  objaddBrakes.DATE_BRAKE_ON is null || objaddBrakes.DATE_BRAKE_ON.ToString().Contains("01/01/0001") ? Convert.ToDateTime("1/1/1901"): (DateTime) objaddBrakes.DATE_BRAKE_ON;
                            lstNewBake.MILEAGE_BRAKE_OFF = objaddBrakes.MILEAGE_BRAKE_ON;
                            lstNewBake.DATE_BRAKE_ON = lstBake.DATE_BRAKE_ON;
                            lstNewBake.MILEAGE_BRAKE_ON = lstBake.MILEAGE_BRAKE_ON;
                            lstNewBake.GARAGE = lstBake.GARAGE;
                            lstNewBake.BAKE_SIZE = lstBake.BAKE_SIZE;
                            lstNewBake.BADGE_NUMBER_1 = lstBake.BADGE_NUMBER_1;
                            lstNewBake.BADGE_NUMBER_2 = lstBake.BADGE_NUMBER_2;
                            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_BAKE>(lstNewBake).State = System.Data.Entity.EntityState.Added;
                            objMNTEntity.SaveChanges();

                            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_BAKE>(lstBake).State = System.Data.Entity.EntityState.Deleted;
                            objMNTEntity.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            blnAddedBrakes = false;
                          //  return RedirectToAction("MNTBrakes", "Home");
                        }
                       
                    }
                    if (blnAddedBrakes == true)
                    {
                        objaddBrakes.DATE_BRAKE_OFF = string.IsNullOrEmpty(objaddBrakes.DATE_BRAKE_OFF.ToString()) || objaddBrakes.DATE_BRAKE_OFF.ToString().Contains("1/1/0001") ? Convert.ToDateTime("1/1/1901") : objaddBrakes.DATE_BRAKE_OFF;
                        objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_BAKE>(objaddBrakes).State = System.Data.Entity.EntityState.Added;
                        objMNTEntity.SaveChanges();
                    }
                }
                else
                {
                    blnAddedBrakes = false;
                    return RedirectToAction("MNTBrakes", "Home");
                }

            }
            catch (Exception ex) { blnAddedBrakes = false; return RedirectToAction("MNTBrakes", "Home"); }

            if (blnAddedBrakes == true)
            {
                return RedirectToAction("MNTBrakes", "Home");
            }
            else return RedirectToAction("MNTBrakes", "Home");
        }


        [Route("Home/EditBrakes/{bkBusNo}/{bkAxlePos}")]
        public ActionResult EditBrakes(string bkDateBrkOff, short bkBusNo,  string bkAxlePos)
        {
            DateTime dtBrakeOffDate = Convert.ToDateTime(bkDateBrkOff);
            return View(objMNTEntity.MNT_BAKE.Where(c => c.AXLE_POSITION == bkAxlePos && c.BUS_NUMBER == bkBusNo && c.DATE_BRAKE_OFF == dtBrakeOffDate ).SingleOrDefault());
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateBrakes(MCTS_MNT.EntityDataModel.MNT_BAKE objBrake)
        {
            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_BAKE>(objBrake).State = System.Data.Entity.EntityState.Modified;
            objMNTEntity.SaveChanges();
            return RedirectToAction("MNTBrakes", "Home");
        }

        public ActionResult DeleteBrake(string bkDateBrkOff, short bkBusNo, string bkAxlePos)
        {
            //string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            //ViewBag.UsrId = username;
            DateTime dtBrakeOffDate = Convert.ToDateTime(bkDateBrkOff);
            MCTS_MNT.EntityDataModel.MNT_BAKE objDelBake = new MNT_BAKE();
            objDelBake = objMNTEntity.MNT_BAKE.Where(c => c.AXLE_POSITION == bkAxlePos && c.BUS_NUMBER == bkBusNo && c.DATE_BRAKE_OFF == dtBrakeOffDate).SingleOrDefault();
            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_BAKE>(objDelBake).State = System.Data.Entity.EntityState.Deleted;
            objMNTEntity.SaveChanges();
            return RedirectToAction("MNTBrakes", "Home");
        }

        //public ActionResult EditBadge(string id)
        //{
        //    string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
        //    ViewBag.UsrId = username;
        //    ViewBag.Message = "Fleet Edit page.";
        //    return View(objMNTEntity.MNT_PMSC.Where(c => c.CODE_TYPE.Equals(id)).SingleOrDefault());
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult EditBadge(MCTS_MNT.EntityDataModel.MNT_PMSC objPMSC)
        //{
        //    objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_PMSC>(objPMSC).State = System.Data.Entity.EntityState.Modified;
        //    objMNTEntity.SaveChanges();
        //    return RedirectToAction("MNTPMSCHEDULE", "Home");
        //}


        //[HttpPost]
        //public ActionResult SearchVehicleHistory()
        //{

        //    return View();
        //}






        //public ActionResult DeleteFleet(string id)
        //{
        //    string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
        //    ViewBag.UsrId = username;
        //    ViewBag.Message = "Fleet Delete page.";
        //    return View(objMNTEntity.MNT_FLET.Where(c => c.FLEET_CODE.Equals(id)).SingleOrDefault());
        //}


        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        public ActionResult MNTREVE()
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Your application description page.";
            return View(objMNTEntity.MNT_REVE.ToList());
        }

        //public ActionResult AddReve()
        //{
        //    string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
        //    ViewBag.UsrId = username;
        //    ViewBag.Message = "Add Fleet page.";
        //    return View();
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult AddReve(MCTS_MNT.EntityDataModel.MNT_FLET objFleet)
        //{
        //    bool blnAddedFleet = true;
        //    try
        //    {
        //        objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_FLET>(objFleet).State = System.Data.Entity.EntityState.Added;
        //        objMNTEntity.SaveChanges();
        //    }
        //    catch (Exception ex) { blnAddedFleet = false; return RedirectToAction("Fleet", "Home"); }

        //    if (blnAddedFleet == true)
        //    {
        //        return RedirectToAction("MNTPMSCHEDULE", "Home");
        //    }
        //    else return RedirectToAction("Fleet", "Home");
        //}

        [Route("{strYear}/{strBUSNo}")]
        public ActionResult EditReve(short strYear, short strBUSNo)
        {
            string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.UsrId = username;
            ViewBag.Message = "Revenue Edit page.";
            return View(objMNTEntity.MNT_REVE.Where(c => c.YR == strYear && c.VEHICLE_NUMBER == strBUSNo).SingleOrDefault());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditReve(MCTS_MNT.EntityDataModel.MNT_REVE objReve)
        {
            objMNTEntity.Entry<MCTS_MNT.EntityDataModel.MNT_REVE>(objReve).State = System.Data.Entity.EntityState.Modified;
            objMNTEntity.SaveChanges();
            return RedirectToAction("MNTREVE", "Home");
        }

        public ActionResult TKPayroll()
        {
            ViewBag.Message = "Time Keeping page";

            return View();
        }
    }
}