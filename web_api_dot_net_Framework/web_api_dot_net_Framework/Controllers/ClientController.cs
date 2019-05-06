using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Http.Cors;
using web_api_dot_net_Framework.Models;
using System.Web.Mvc;
using Newtonsoft.Json;



namespace web_api_dot_net_Framework.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/client/aa")]
        // GET client/habib
        public string Get()
        {
            Client c1 = new Client();
            c1.Id = 1;
            c1.name = "Habib";
            Client c2 = new Client();
            c2.Id = 2;
            c2.name = "AbdelAziz";
            Client c3 = new Client();
            c3.Id = 3;
            c3.name = "Anas";
            List<Client> myList = new List<Client>();
            myList.Add(c1);
            myList.Add(c2);
            myList.Add(c3);
            var json = JsonConvert.SerializeObject(myList);
            return json;
        }
        [System.Web.Http.Route("api/all")]
        public IHttpActionResult All()
        {
            return Ok("Hello world");
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "Cleint";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}