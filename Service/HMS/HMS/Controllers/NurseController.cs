using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using HMS.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Numerics;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NurseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select UserId,Username, FullName,Email,Password,NrTel from dbo.users where Role = 'Nurse'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HMSCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult Post(Nurse nurse)
        {
            //string query = @"
            //  insert into dbo.Nurse
            //    (Username, Email, Password, FullName, PhoneNumber, Role, DataCreated)
            //   values

            //,'" + nurse.FullName + @"'
            //,'" + nurse.Email + @"'
            //,'" + nurse.Password + @"'
            //,'" + nurse.NrTel + @"'
            // )
            //";

            string q = @"
            insert into dbo.users (Username, FullName, Email, Password, NrTel,Role)
            values ('" + nurse.Username + @"','" + nurse.FullName + @"', '" + nurse.Email + @"', '" + nurse.Password + @"', '" + nurse.NrTel + @"', '" + nurse.Role + @"')
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HMSCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(q, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }

                return new JsonResult("Added Successfully");
            }
        }

        [HttpPut]
        public JsonResult Put(Nurse nurse)
        {
            string query = @"
               update dbo.users set 
                Username = '" + nurse.Username + @"'
               ,FullName = '" + nurse.FullName + @"'
               ,Email = '" + nurse.Email + @"'
                ,Password = '" + nurse.Password + @"'
                ,NrTel = '" + nurse.NrTel + @"'
               where UserID = " + nurse.UserID + @"
               ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HMSCon");    
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }

                return new JsonResult("Update Successfully");
            }
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
               delete from dbo.users
               where UserID = " + id + @"
               ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HMSCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }

                return new JsonResult("Deleted Successfully");
            }
        }
    }
}
               