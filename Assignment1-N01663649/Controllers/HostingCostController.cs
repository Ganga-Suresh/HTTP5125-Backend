using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1_N01663649.Controllers
{
    public class HostingCostController : ApiController
    {
        /// <summary>
        /// number of day is "id" divided by 14 + 1 and multiplied with per fortnight rate to find amount for the given days 
        /// HST calculated forthe amount and then added to it to find the final total 
        /// </summary>
        /// <param name="id"> input number of days</param>
        /// <returns> string </returns>

        public string Get(double id)
        {
            double numofdays = Math.Floor((id / 14) + 1);
            double rate = numofdays * 5.50;
            double HST = rate * 0.13;
            double total = (numofdays * rate) + HST;
            return numofdays + " Fortnight at $5.50/FN = " + rate + "  |   " + "HST 13% = " + HST + "   |  " + "Total = " + total;
        }
    }
}
