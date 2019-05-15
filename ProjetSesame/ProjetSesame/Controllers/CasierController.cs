using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Web.Http.Cors;
using web_api_dot_net_Framework.Models;

namespace ProjetSesame.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CasierController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/casier/all")]
        // GET client/habib
        public List<Casier> Get()
        {
            using (var context = new dbContext())
            {
                try
                {
                    return context.Casiers.ToList();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error : " + Ex.Message);
                    return null;
                }
            }
            //var json = JsonConvert.SerializeObject(myList);
            //return myList;
        }


        // GET api/values/5
        public string Get(int id)
        {
            return "Cleint";
        }

        // POST api/values
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/casier/insert")]
        public string Post([FromBody]Casier value)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    context.Casiers.Add(value);
                    context.SaveChanges();
                    return "Element inserted ...";
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error : " + Ex.Message);
                    return "Error : " + Ex.Message;
                }
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/casier/update")]
        public string update([FromBody] Casier c)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    Casier casier = (Casier)context.Casiers.Where(r => r.Id == c.Id).First();
                    casier.Libelle = c.Libelle;
                    context.SaveChanges();
                    return "Data updated";
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error : " + Ex.Message);
                    return "Error " + Ex.Message;
                }
            }
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Ok(value);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/casier/delete")]
        // DELETE api/values/5
        public string Delete(Casier c)
        {
            try
            {
                dbContext re = new dbContext();
                Casier casier = (Casier)re.Casiers.Where(r => r.Id == c.Id).First();
                re.Casiers.Remove(casier);
                re.SaveChanges();
                return "Casier deleted";
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return "Exception : " + Ex.Message;
            }
        }
    }
}