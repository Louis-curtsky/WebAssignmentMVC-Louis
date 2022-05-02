using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models
{
    public class RandomService
    {
        public int randNumSR;
        public int numberRight;
        public bool ResetGuess=false;
//        public int PreviousHighest;
        public string ShowMsg;

        public string GenerateNum()
        {
            Random randGen = new Random();
            randNumSR = randGen.Next(1, 100);
            string strNum = randNumSR.ToString();
            return strNum;
        }
        public string GuessStart(int guessInput)
        {
            int randNumsInt = randNumSR;
            if (randNumsInt > guessInput)
                ShowMsg = " is lower than the guessing number!!!";
            else
            if (randNumsInt < guessInput)
                ShowMsg = " is higher than the guessing number!!!";

//            numberOfGuess += 1;
            return ShowMsg;
        }
        public bool GuessStart(string randNums, int guessInput)
        {
            bool correctCount = false;
            int randNumsInt = int.Parse(randNums);
            if (randNumsInt == guessInput)
            {
                correctCount = true;
                numberRight += 1;
                ResetGuess = true;
            }
            return correctCount;
        }
    }
}
