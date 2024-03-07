using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_j1.Controllers
{
    /// <summary>
    /// recieves oders from user and calculate the total calories of the food
    /// the arrays calorieb, caloried, calories, calorieds store the calories of the 4 menu options  of burger, drinks,side and desserts respectively from which item will be chosen as per user input and then added to get total calories
    /// </summary>
    /// <param name="burger">stores index of burger menu</param>
    /// <param name="drink">stores index of drink menu</param>
    /// <param name="side">stores index of side menu</param>
    /// <param name="dessert">stores index of dessert menu</param>
    /// <returns>
    /// total calories after calculation.
    /// 
    /// </returns>
    public class J1Controller : ApiController
    {
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]

        public int Menu(int burger, int drink, int side, int dessert)
        {

            int[] Calorieb = { 461, 431, 420, 0 };
            int[] Caloried = { 130, 160, 118, 0 };
            int[] Calories = { 100, 57, 70, 0 };
            int[] Calorieds = { 167, 266, 75, 0 };

            int totalCalories = Calorieb[burger - 1] + Caloried[drink - 1] + Calories[side - 1] + Calorieds[dessert - 1];

            return totalCalories;
        }
    }

}
