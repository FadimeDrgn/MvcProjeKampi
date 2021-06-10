using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var result1 = context.Categories.Count().ToString();
            ViewBag.result1 = result1;

            var result2 = context.Headings.Count(c => c.CategoryID == 19).ToString();
            ViewBag.result2 = result2;

            var result3 = (from c in context.Writers select c.WriterName.ToLower().IndexOf("a")).Count().ToString();
            ViewBag.result3 = result3;

            var result4 = context.Categories.Where(x => x.CategoryID == context.Headings.GroupBy(c => c.CategoryID).OrderByDescending(c => c.Count())
            .Select(c => c.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.result4 = result4;

            var result5 = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.result5 = result5;

            return View();
        }
    }
}