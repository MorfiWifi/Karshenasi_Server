using karhsenasi_server2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace karhsenasi_server2.Controllers.Api
{
    public class MessageController : ApiController
    {
        Repo Db = Repo.GetInstance();

        [HttpGet]
        [ResponseType(typeof(List<Message>))]
        public IHttpActionResult GetMessages ()
        {
            var req = Request.Headers.Authorization.Scheme; // Find out Whre is Token (I have Forgot !!)
            var ch =  TokenController.CheckToken(req);
            if (ch.isTrue == false)
            {
                return BadRequest("You Didnt Autherize (correctly)");
            }
            var messages = Db.Messages(ch.user);
            return Ok(messages);
        }

        [HttpPut]
        [ResponseType(typeof(Message))]
        public IHttpActionResult InsertMessages(Message message)
        {
            var req = Request.Headers.Authorization.Scheme; // Find out Whre is Token (I have Forgot !!)
            var ch = TokenController.CheckToken(req);
            if (ch.isTrue == false)
            {
                return BadRequest("You Didnt Autherize (correctly)");
            }
            // Enhance Message (for Real Sender 
            var messages = Db.AddMessage(message);
            return Ok(messages);
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        public IHttpActionResult DeletMessages(Message message)
        {
            var req = Request.Headers.Authorization.Scheme; // Find out Whre is Token (I have Forgot !!)
            var ch = TokenController.CheckToken(req);
            if (ch.isTrue == false)
            {
                return BadRequest("You Didnt Autherize (correctly)");
            }
            var messages = Db.RemoveMessage (message);
            return Ok(messages);
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        public IHttpActionResult EditMessages(Message message)
        {
            var req = Request.Headers.Authorization.Scheme; // Find out Whre is Token (I have Forgot !!)
            var ch = TokenController.CheckToken(req);
            if (ch.isTrue == false)
            {
                return BadRequest("You Didnt Autherize (correctly)");
            }
            var messages = Db.UpdateMessage(message);
            return Ok(messages);
        }
    }
}
