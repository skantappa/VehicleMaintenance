using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCTS_MNT.EntityDataModel;

namespace MCTS_MNT.Controllers
{
    public class BatchController : Controller
    {
        [HttpPost]
        // GET: Batch
        public ContentResult MNTUpdateDailyFuel()
        {
            return Content("<script language='javascript' type='text/javascript'>alert('Maintenance Revenue records were updated successfully with Daily Fuel data provided from FondDuLac and Kinnickinic Garages');</script>");
           
        }
        //public ContentResult MNTUpdateDailyFuel()
        //{
        //    //string username = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
        //    //ViewBag.UsrId = username;

        //    return Content("<script language='javascript' type='text/javascript'>alert('Maintenance Revenue records were updated successfully with Daily Fuel data provided from FondDuLac and Kinnickinic Garages');</script>");
        //}
    }
}