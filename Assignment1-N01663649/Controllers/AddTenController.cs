using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1_N01663649.Controllers
{
    public class AddTenController : ApiController
    {

        /// <summary>
        /// adds 10 to the number input as parameter through variable "id"
        /// </summary>
        /// <param name="id" > number to be input for performing addition</param>
        /// <returns>"id"+10</returns>
        /// <example>
        /// GET localhost/AddTen/21  => 31
        /// </example>
        /// <example>
        /// GET localhost/AddTen/0  => 10
        /// </example>
        /// <example>
        /// GET localhost/AddTen/-9  => 1
        /// </example>
        
            public int Get(int id)
            {
                int sum = id + 10;
                return sum;
            }
        

    }
}
