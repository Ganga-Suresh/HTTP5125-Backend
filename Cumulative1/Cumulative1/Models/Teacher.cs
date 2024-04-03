using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cumulative1.Models
{
    /// <summary>
    /// model to represent information about a teacher
    /// </summary>
    public class Teacher
    {
        public int Id; // teacherid from teachers table
        public string TfName; // teacherfname from teachers table
        public string TlName; // teacherlname from teachers table
        public string Tnumber; // employeenumber from teachers table
        public DateTime Thiredate; // hiredate from teachers table
        public decimal Tsalary; // salary from teachers table
    }
}