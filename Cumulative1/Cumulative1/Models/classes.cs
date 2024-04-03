using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cumulative1.Models
{   
    /// <summary>
    /// variables for representing information of a class
    /// </summary>
    public class classes
    {
        public int ClassId; // classid from classes table
        public string Ccode; // classcode from classes table
        public int Idteacher; // teacherid from classes table
        public DateTime startdate; // startdate from classes table
        public DateTime finishdate; // finishdate from classes table
        public string Classname; // classname from classes table
    }
}