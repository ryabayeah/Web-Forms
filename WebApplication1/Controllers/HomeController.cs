using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SingleAction()
        {
            return View();
        }

        public IActionResult SeparateAction()
        {
            return View();
        }

        public IActionResult BindingParametrs()
        {
            return View();
        }
        public IActionResult BindingSeparate()
        {
            return View();
        }
        
        private double Calculate(double first, double second, string operation)
        {
            double result;

            switch (operation)
            {
                case "+":
                    result = first + second;
                    break;

                case "-":
                    result = first - second;
                    break;

                case "*":
                    result = first * second;
                    break;

                case "/":
                    result = first / second;
                    break;

                default:
                    result = 0;
                    break;
            }

            return result;
        }
        public IActionResult SinA()
        {
            if (Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                double first = Convert.ToInt32(this.Request.Form["first"]);
                double second = Convert.ToInt32(this.Request.Form["second"]);
                string operations = this.Request.Form["operations"];

                ViewBag.firstValue = first;
                ViewBag.secondValue = second;
                ViewBag.operations = operations;
                ViewBag.result = Calculate(first, second, operations);

            }

            return View("Result");
        }


        [HttpPost, ActionName("SepA")]
        public IActionResult SepA_()
        {
            double first = Convert.ToInt32(this.Request.Form["first"]);
            double second = Convert.ToInt32(this.Request.Form["second"]);
            string operations = this.Request.Form["operations"];

            ViewBag.firstValue = first;
            ViewBag.secondValue = second;
            ViewBag.operations = operations;
            ViewBag.result = Calculate(first, second, operations);

            return View("Result");
        }


        [HttpPost]
        public IActionResult BinP(double first, double second, string operations)
        {
            ViewBag.firstValue = first;
            ViewBag.secondValue = second;
            ViewBag.operations = operations;
            ViewBag.result = Calculate(first, second, operations);

            return View("Result");
        }

        [HttpPost]
        public IActionResult BinS(Calculation calc)
        {
            ViewBag.firstValue = calc.first;
            ViewBag.secondValue = calc.second;
            ViewBag.operations = calc.operations;
            ViewBag.result = calc.Calculate();
            Console.WriteLine(calc.first + calc.second + calc.operations + calc.Calculate() + "*********************");
            return View("Result");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
