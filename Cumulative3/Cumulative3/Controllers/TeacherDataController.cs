using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cumulative3.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Cors;

namespace Cumulative3.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        //public IEnumerable<Teacher> Teachers { get; private set; }

        //This Controller Will access the teacher table of our School database. 
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary> 
        /// <returns>
        /// A list of Teacher Objects with fields mapped to the database column values (first name, last name, employee Number, Phone number, salary).
        /// </returns>
        /// <example>GET api/TeacherData/ListTeachers -> {Teacher Object, Teacher Object, Teacher Object...}</example>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey = null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key) or lower(concat(teacherfname, ' ', teacherlname)) like lower(@key)";

            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teachers
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int Id = (int)ResultSet["teacherid"];
                string TfName = ResultSet["teacherfname"].ToString();
                string TlName = ResultSet["teacherlname"].ToString();
                string Tnumber = ResultSet["employeenumber"].ToString();
                DateTime Thiredate = (DateTime)ResultSet["hiredate"];
                decimal Tsalary = (decimal)ResultSet["salary"];


                Teacher NewTeacher = new Teacher();
                NewTeacher.Id = Id;
                NewTeacher.TfName = TfName;
                NewTeacher.TlName = TlName;
                NewTeacher.Tnumber = Tnumber;
                NewTeacher.Thiredate = Thiredate;
                NewTeacher.Tsalary = Tsalary;

                //Add the Author Name to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Teachers;
        }


        /// <summary>
        /// Finds an teacher from the MySQL Database through an id. 
        /// </summary>
        /// <param name="id">The Teacher ID</param>
        /// <returns>Teacher object containing information about the teacher with a matching ID. Empty teacher Object if the ID does not match any teacher in the system.</returns>
        /// <example>api/TeacherData/FindTeacher/6 -> {Teacher Object}</example>
        /// <example>api/TeacherData/FindTeacher/10 -> {Teacher Object}</example>
        [HttpGet]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where teacherid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int Id = (int)ResultSet["teacherid"];
                string TfName = ResultSet["teacherfname"].ToString();
                string TlName = ResultSet["teacherlname"].ToString();
                string Tnumber = ResultSet["employeenumber"].ToString();
                DateTime Thiredate = (DateTime)ResultSet["hiredate"];
                decimal Tsalary = (decimal)ResultSet["salary"];

                NewTeacher.Id = Id;
                NewTeacher.TfName = TfName;
                NewTeacher.TlName = TlName;
                NewTeacher.Tnumber = Tnumber;
                NewTeacher.Thiredate = Thiredate;
                NewTeacher.Tsalary = Tsalary;
            }
            Conn.Close();

            return NewTeacher;
        }


        /// <summary>
        /// Deletes an Teacher from the connected MySQL Database if the ID of that author exists. Does NOT maintain relational integrity. 
        /// </summary>
        /// <param name="id">The ID of the Teacher.</param>
        /// <example>POST /api/TeacherData/DeleteTeacher/3</example>
        [HttpPost]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void DeleteTeacher(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Delete from teachers where teacherid=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();


        }

        /// <summary>
        /// Adds an Teacher to the MySQL Database. 
        /// </summary>
        /// <param name="NewTeacher">An object with fields that map to the columns of the teacher's table. </param>
        /// <example>
        /// POST api/TeacherData/AddTeacher 
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// </example>
        [HttpPost]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void AddTeacher([FromBody] Teacher NewTeacher)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            Debug.WriteLine(NewTeacher.TfName);

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "insert into teachers (teacherfname, teacherlname, employeenumber, hiredate, salary) values (@TfName,@TlName,@Tnumber, CURRENT_DATE(), @Tsalary)";
            cmd.Parameters.AddWithValue("@TfName", NewTeacher.TfName);
            cmd.Parameters.AddWithValue("@TlName", NewTeacher.TlName);
            cmd.Parameters.AddWithValue("@Tnumber", NewTeacher.Tnumber);
            cmd.Parameters.AddWithValue("@Tsalary", NewTeacher.Tsalary);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();



        }

        /// <summary>
        /// Updates a Teacher on the MySQL Database. 
        /// </summary>
        /// <param name="TeacherInfo">An object with fields that map to the columns of the teachers's table.</param>
        /// <example>
        /// POST api/TeacherData/UpdateTeacher/208 
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// </example>
        [HttpPost]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void UpdateTeacher(int id, [FromBody] Teacher TeacherInfo)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Debug.WriteLine(AuthorInfo.AuthorFname);

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "update authors set authorfname=@AuthorFname, authorlname=@AuthorLname, authorbio=@AuthorBio, authoremail=@AuthorEmail  where authorid=@AuthorId";
            cmd.Parameters.AddWithValue("@TfName", TeacherInfo.TfName);
            cmd.Parameters.AddWithValue("@TlName", TeacherInfo.TlName);
            cmd.Parameters.AddWithValue("@Tnumber", TeacherInfo.Tnumber);
            cmd.Parameters.AddWithValue("@Tsalary", TeacherInfo.Tsalary);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();


        }

    }
}