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
    public class DoctorController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DoctorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select UserId,Username, FullName,Email,Password,NrTel from dbo.users where Role = 'Doctor'";
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
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Doctor d)
        {
            //string q = @"
            //    insert into dbo.users values
            //    ('" + d.FullName + @"'
            //    ,'" + d.Email + @"'
            //    ,'" + d.Password + @"'
            //    ,'" + d.NrTel + @"')
            //    ";
            string q = @"
            insert into dbo.users (Username,FullName, Email, Password, NrTel,Role)
            values ('" + d.Username + @"','" + d.FullName + @"', '" + d.Email + @"', '" + d.Password + @"', '" + d.NrTel + @"', '" + d.Role + @"')
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
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }

                return new JsonResult("Added Successfully");
            }
        }

        [HttpPut]
        public JsonResult Put(Doctor d)
        {
            string query = @"
               update dbo.users set 
                Username = '" + d.Username + @"'
               ,FullName = '" + d.FullName + @"'
               ,Email = '" + d.Email + @"'
                ,Password = '" + d.Password + @"'
                ,NrTel = '" + d.NrTel + @"'
               where UserID = " + d.UserID + @"
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


        //Dashboard Category Count
        //[Route("GetAllCountDoctor")]
        //public JsonResult GetAllCountDoctor()
        //{
        //    string query = @"
        //        select COUNT(*) from dbo.users ";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("HMSCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader); ;

        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult(table);
        //}
    }
}

