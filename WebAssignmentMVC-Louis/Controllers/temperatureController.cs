using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models;

namespace WebAssignmentMVC.Controllers
{
    public class temperatureController : Controller
    {
        TempService _tempService;

        public temperatureController()
        {
            _tempService = new TempService();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(double temp, string temp_type)
        {
            ViewBag.Temp = temp;

            try
            {
                _tempService.Create(temp,temp_type) ;

//                return View();
            }
            catch (ArgumentException exceptionData)
            {
                ViewBag.ExceptionMsg = exceptionData.Message;
            }
            ViewBag.TempType = _tempService.Gettemps(temp_type);
            
            return View();
        }
    }
}
