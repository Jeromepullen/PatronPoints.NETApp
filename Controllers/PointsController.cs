using Microsoft.AspNetCore.Mvc;
using PatronPointsRewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronPointsRewards.Controllers
{
    public class PointsController : Controller
    {
        List<PointsModel> points = new List<PointsModel>();
        public IActionResult Index()
        {
            return View(points);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(PointsModel point)
        {
            points.Add(point);
            return View("Details", point);
        }
    }
}
