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
    public class CategorieController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/categorie/all")]
        // GET client/habib
        public List<Categorie> Get()
        {
            using (var context = new dbContext())
            {
                try
                {
                    return context.Categories.ToList();
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
        [System.Web.Http.Route("api/categorie/insert")]
        public string Post([FromBody]Categorie value)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    context.Categories.Add(value);
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
        [System.Web.Http.Route("api/categorie/update")]
        public string update([FromBody] Categorie c)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    Categorie categorie = (Categorie)context.Categories.Where(r => r.Id == c.Id).First();
                    categorie.Type = c.Type;
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

        }

        // DELETE api/values/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/categorie/delete")]
        public string Delete(Categorie c)
        {
            try
            {
                dbContext re = new dbContext();
                Categorie categorie = (Categorie)re.Categories.Where(r => r.Id == c.Id).First();
                re.Categories.Remove(categorie);
                re.SaveChanges();
                return "Categorie deleted";
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return "Exception : " + Ex.Message;
            }
        }
    }
}