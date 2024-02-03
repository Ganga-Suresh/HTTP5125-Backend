using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1_N01663649.Controllers
{
    public class SquareController : ApiController
    {
        /// <summary>
        /// returns square of the number input as parameter through variable "id"
        /// </summary>
        /// <param name="id" > number to be input for performing square</param>
        /// <returns>"id"*"id"</returns>
        /// <example>
        /// GET localhost/Square/2   => 4
        /// </example>
        /// <example>
        /// GET localhost/Square/-2   => 4
        /// </example>
        /// <example>
        /// GET localhost/Square/10   => 100
        /// </example>
       
            public int Get(int id)
            {
                int square = id * id;
                return square;
            }
        

    }
}
