using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1_N01663649.Controllers
{
    public class GreetingController : ApiController
    {
        /// <summary>
        /// first method uses POST method to give a message of "Hello World"
        /// second method gives a message of "greetings to 'x' people!" where 'x' is input through variable 'id'
        /// </summary>
        /// <param name="id" > number to be input for greeting number of people</param>
        /// method 1
        /// <returns>Hello World</returns>
        /// method 2
        /// <returns>Greetings to 'id' people!</returns>
        /// <example>
        /// CLI curl -d "" http://localhost:56893/api/Greeting => Hello World
        /// </example>
        /// <example>
        /// GET localhost/Greeting/3 => Greetings to 3 people!
        /// </example>
        /// <example>
        /// GET localhost/Greeting/6 => Greetings to 6 people!
        /// </example>
        /// <example>
        /// GET localhost/Greeting/0 => Greetings to 0 people!
        /// </example>

       
            public string Post()
            {
                return "Hello World";
            }

            public string Get(int id)
            {
                string greet = "Greetings to " + id + " people!";
                return greet;
            }
        

    }
}
