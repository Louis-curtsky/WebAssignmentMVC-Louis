using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models;

namespace WebAssignmentMVC.Controllers
{
    public class GuessGameController : Controller
    {
        RandomService _randomService;
        public GuessGameController()
        {
            _randomService = new RandomService();
        }

        [HttpGet]
        public IActionResult GuessGame(string msg, int correctNum, int numberofguess)
        {
//            string theGuess = "";
            string randNums = HttpContext.Session.GetString("RandNums");
            // Initialize Random number and stored in session when 1st time opeining this page
            if (string.IsNullOrWhiteSpace(randNums))
            {
                randNums = _randomService.GenerateNum();
                HttpContext.Session.SetString("RandNums", randNums);
            }

            string cookieHighest = Request.Cookies["NumberOfRight"];
            ViewBag.CookieHighest = cookieHighest;

            string numberofGuessCookies = Request.Cookies["CompareNumberOfGuess"];
            ViewBag.CookieGuessNum = numberofGuessCookies;

            ViewData["Msg"] = msg;

            if (msg != null)
            {
                if (msg.Contains("CORRECT"))
                {
                    ViewBag.ColorCode = "green";
                    ViewBag.RandNums = correctNum;
                    Response.Cookies.Append("NumberOfGuess", "");
                }
                else
                {
                    ViewBag.ColorCode = "warning";
                    ViewBag.RandNums = "";
                }
            }
            ViewData["NumGuess"] = numberofguess.ToString();
            // For debugging use

            return View();
        }

        [HttpPost]
        public IActionResult CreateGuess(int guessnum)
        {
            bool correctGuess;
            string msg;
            int intgetNumberofGuess;
            int intCompareNumberofGuess=0;
            

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(3);
            string getnumberofGuessCookies = Request.Cookies["NumberOfGuess"];
            if (string.IsNullOrWhiteSpace(getnumberofGuessCookies))
                intgetNumberofGuess = 1;
            else
            {
                if (_randomService.ResetGuess == true)
                {
                    intgetNumberofGuess = 1;
                    _randomService.ResetGuess = false;
                }
                else
                {
                    intgetNumberofGuess = int.Parse(getnumberofGuessCookies);
                    intgetNumberofGuess += 1;
                }
            }


            string randNums = HttpContext.Session.GetString("RandNums");

            //          RandNums = randNums;
            if (!string.IsNullOrWhiteSpace(randNums))
            {
                correctGuess= _randomService.GuessStart(randNums, guessnum);
            } else
            {
                randNums = _randomService.GenerateNum();
                HttpContext.Session.SetString("RandNums", randNums);
                correctGuess = _randomService.GuessStart(randNums, guessnum);
            }

            // Set Cookies for number of guess

            string cookieHighest = Request.Cookies["NumberOfRight"];
            string itIsToo = "";

            if (string.IsNullOrWhiteSpace(cookieHighest))
            {
                cookieHighest = "0";
            }

            _randomService.randNumSR = int.Parse(randNums);
            itIsToo = _randomService.GuessStart(guessnum);
            int numberRight = int.Parse(cookieHighest);

            // Get cookies for num of guess and store into comparing varible commpareNumGuess

            string getCompareNumberofGuess = Request.Cookies["CompareNumberOfGuess"];

            if (getCompareNumberofGuess != null)
                intCompareNumberofGuess = int.Parse(getCompareNumberofGuess);

            if  (correctGuess == true)
            {
                numberRight += 1;

                Response.Cookies.Append("NumberOfRight", numberRight.ToString());
                HttpContext.Session.SetString("RandNums", "");
                msg = "Congratulation, your guess is CORRECT!!!";
                correctGuess = false;

                if (numberRight > 1)
                {
                    
                    if (intgetNumberofGuess < intCompareNumberofGuess)
                    {
                        Response.Cookies.Append("CompareNumberOfGuess", intgetNumberofGuess.ToString());
                        
                    }
                    else
                    {
                        Response.Cookies.Append("CompareNumberOfGuess", intCompareNumberofGuess.ToString());
                    }
                }
                else // First guess write
                {
                    Response.Cookies.Append("CompareNumberOfGuess", intgetNumberofGuess.ToString());
                }

            }
            else
            {   
                Response.Cookies.Append("NumberOfGuess", intgetNumberofGuess.ToString());

                msg = $"Oops! Thats incorrect! {itIsToo}";
            } // End of Set Message


            //            ViewBag.CookieHighest = cookieHighest;

            return RedirectToAction("GuessGame", new { Msg = msg,
                CorrectNum = guessnum,  NumberofGuess = intgetNumberofGuess}) ; 
        }
    }
}
