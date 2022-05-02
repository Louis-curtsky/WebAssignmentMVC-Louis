using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssignmentMVC.Models
{
    public class TempService
    {
        private string tempType;
    
        public string TempType {
            get
            {
                return tempType;
            }
            set
            {
                if (tempType == null)
                    tempType = "Celcius";
            }
        }
        public string tempStr;

        public TempService()
        {
            if (TempType == null)
            {
                tempType = "Celcius";
            }                
        }
        public void Create() { }
/*
        public string Gettemps(double temp)
        {
            if (TempType != "Celcius")
            {
                temp = temp * 1.8 + 32;
            }
            tempStr = temp.ToString();
            return tempStr;
        }
 */
        public string Gettemps(string tempType)
        {
            string conType = TempType;
            if (tempType != "ce")
            {
//                temp = temp * 1.8 + 32;
                conType = "Fahrenheit";
            }

            return conType;
        }


        public void Create(double temp, string tempType)
        {

            string conType = "";
            double maxTemp = 37;
            double minTemp = 35;
            if (tempType != "ce")
            {
                maxTemp = maxTemp * 1.8 + 32;
                minTemp = minTemp * 1.8 + 32;
                conType = "Fahrenheit";
            }
            else
                conType = "Celcius";

            if (temp > maxTemp)
            {
                throw new ArgumentException($"You have a fever!!!");
            }
            else
            if (temp < minTemp)
            {
                throw new ArgumentException($"Unrealistic temperature...is too low!!!");
            }
            tempStr = temp.ToString();
            TempType = conType;
        }

    }
}
