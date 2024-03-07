using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_j1.Controllers
{
    /// <summary>
    /// program uses for loop to check if sum of the numbers on both the dice adds up to 10; if yes the count increments by 1 forming the tootal number of chances to get 10
    /// </summary>
    /// <param name="m">receives the total side of one dice</param>
    /// <param name="n">receives the total side of one dice</param>
    /// <result>
    /// gives total number of chances for geting sum =  10 from numbers obtained from 2 dices.
    /// if count = 5 then outputs a string saying " there are 5 total ways to get the sum 10" 
    /// </result>
    public class J2Controller : ApiController
    {
        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string CalculateWaysToGetSum(int m, int n)
        {

            int count = 0;

            for (int i = 0; i <= m; i++)
            {
                for (int j = n; j > 0; j--)
                {
                    if (i + j == 10)
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
                return $"There are {count} ways to get the sum 10.";
            else if (count == 1)
                return $"There is {count} way to get the sum 10.";
            else
                return $"There are {count} total ways to get the sum 10.";
        }
    }
}
