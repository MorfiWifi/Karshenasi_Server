﻿using karhsenasi_server2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace karhsenasi_server2.Controllers.Api
{
    public class UserController : ApiController
    {
        Repo Db = Repo.GetInstance();

        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser()
        {
            var req = Request; // Find out Whre is Token (I have Forgot !!)
            // Find with Token !

            User user = null; // Restored from Token!
            return Ok(user);
        }

        [HttpPut]
        [ResponseType(typeof(User))]
        public IHttpActionResult InsertUser(User user)
        {
            var req = Request; // Find out Whre is Token (I have Forgot !!) (Find User From Its Token!!!)
            var sender = "User Gained From Token!";
            // Enhance Message (for Real Sender 
            var new_user = Db.AddUser(user);
            return Ok(new_user);
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        public IHttpActionResult DeletUser(User user)
        {
            var req = Request; // Find out Whre is Token (I have Forgot !!) (Find User From Its Token!!!)
            //var sender = "User Gained From Token!";
            var messages = Db.RemoveUser(user);
            return Ok(messages);
        }

        [HttpPut]
        [ResponseType(typeof(User))]
        public IHttpActionResult EditUser(User user)
        {
            //Foture Addes !!
            var req = Request; // Find out Whre is Token (I have Forgot !!) (Find User From Its Token!!!)
            //var sender = "User Gained From Token!";
            var new_user = Db.UpdateUser(user);
            return Ok(new_user);
        }
    }
}
