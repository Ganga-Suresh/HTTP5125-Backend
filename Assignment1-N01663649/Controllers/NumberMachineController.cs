using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1_N01663649.Controllers
{
    public class NumberMachineController : ApiController
    {
        /// <summary>
        /// performs four mathematical operations to the number input as parameter through variable "id"
        /// </summary>
        /// <param name="id" > number to be input for performing mathematical operations</param>
        /// <returns>"id"* 4 / 2 - 10 + 3</returns>
        /// <example>
        /// GET localhost/NumberMachine/10  => 13
        /// </example>
        /// <example>
        /// GET localhost/NumberMachine/-5  => -17
        /// </example>
        /// <example>
        /// GET localhost/NumberMachine/30  => 53
        /// </example>
       
            public int Get(int id)
            {
                int result = id * 4 / 2 - 10 + 3;
                return result;
            }
        

    }
}
