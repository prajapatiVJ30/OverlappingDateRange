using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Model;
using Demo.Service;
using System.Web.Mvc;
using System.Threading.Tasks;
using Kendo.Mvc;
using System.Globalization;

namespace Demo.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IDemoService _demoService;
        public HomeController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        public ActionResult Index()
        {
            return View(new DemoModel());
        }

        [Route("demo/save")]
        [HttpPost]
        public JsonResult Save(DemoModel model)
        {
            int id;
            if (ModelState.IsValid)
            {
                model = CalculateDateOverlap(model);
                model.StartDate1 = model.StartDate1;
                model.EndDate1 = model.EndDate1;
                model.StartDate2 = model.StartDate2;
                model.EndDate2 = model.EndDate2;
                if (model.Overlap_StartDate != null)
                    model.Overlap_StartDate = model.Overlap_StartDate.Value.ToUniversalTime();
                if (model.Overlap_EndDate != null)
                    model.Overlap_EndDate = model.Overlap_EndDate.Value.ToUniversalTime();
                model.CreateDate = DateTime.Now.ToUniversalTime();
                id = _demoService.Save(model);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CalculateOverlap(DemoModel demo)
        {
            DemoModel calculatedValue = CalculateDateOverlap(demo);
            if (calculatedValue.Overlap_StartDate != null)
                calculatedValue.Overlap_StartDate = calculatedValue.Overlap_StartDate.Value.ToUniversalTime();
            if (calculatedValue.Overlap_EndDate != null)
                calculatedValue.Overlap_EndDate = calculatedValue.Overlap_EndDate.Value.ToUniversalTime();

            return Json(new { IsOverlap = calculatedValue.IsOverlap, Overlap_StartDate = calculatedValue.Overlap_StartDate.Value.ToString("MM-dd-yyyy HH:mm"), Overlap_EndDate = calculatedValue.Overlap_EndDate.Value.ToString("MM-dd-yyyy HH:mm") }, JsonRequestBehavior.AllowGet);
        }

        public DemoModel CalculateDateOverlap(DemoModel demo)
        {
            bool overlap = demo.StartDate1 < demo.EndDate2 && demo.StartDate2 < demo.EndDate1;
            demo.IsOverlap = overlap;
            // Overlap Startdate2 in between startdate1 & enddate1 date
            if (demo.StartDate1 < demo.StartDate2 && demo.StartDate2 < demo.EndDate1)
            {
                demo.Overlap_StartDate = demo.StartDate2;
            }
            // Overlap Startdate1 in between startdate2 & enddate2 date
            else if (demo.StartDate2 < demo.StartDate1 && demo.StartDate1 < demo.EndDate2)
            {
                demo.Overlap_StartDate = demo.StartDate1;
            }
            // Overlap EndDate1 in between startdate2 & enddate2 date
            if (demo.StartDate2 < demo.EndDate1 && demo.EndDate1 < demo.EndDate2)
            {
                demo.Overlap_EndDate = demo.EndDate1;
            }
            // Overlap EndDate2 in between startdate1 & enddate1 date
            else if (demo.StartDate1 < demo.EndDate2 && demo.EndDate2 < demo.EndDate1)
            {
                demo.Overlap_EndDate = demo.EndDate2;
            }
            // Overlap StartDate1 & EndDate1 into StartDate2 & EndDate2
            if (demo.StartDate2 < demo.StartDate1 && demo.EndDate2 > demo.EndDate1)
            {
                demo.Overlap_StartDate = demo.StartDate1;
                demo.Overlap_EndDate = demo.EndDate1;
            }
            // Overlap StartDate2 & EndDate2 into StartDate1 & EndDate1
            if (demo.StartDate1 < demo.StartDate2 && demo.EndDate1 > demo.EndDate2)
            {
                demo.Overlap_StartDate = demo.StartDate2;
                demo.Overlap_EndDate = demo.EndDate2;
            }
            return demo;
        }

        public JsonResult GetData()
        {
            return Json(_demoService.Load(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}