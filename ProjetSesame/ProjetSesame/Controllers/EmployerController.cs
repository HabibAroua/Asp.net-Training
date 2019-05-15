using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data;
using web_api_dot_net_Framework.Models;
using System.Web.Http.Cors;

namespace ProjetSesame.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class EmployerController : ApiController
    {

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/employer/all")]
        // GET client/habib
        public List<Employer> Get()
        {
            using (var context = new dbContext())
            {
                try
                {
                    return context.Employers.ToList();
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
        [System.Web.Http.Route("api/employer/insert")]
        public string Post([FromBody]Employer value)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    context.Employers.Add(value);
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
        [System.Web.Http.Route("api/employer/update")]
        public string update([FromBody] Employer e)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    Employer employer = (Employer)context.Employers.Where(r => r.Id == e.Id).First();
                    employer.Nom = e.Nom;
                    employer.Prenom = e.Prenom;
                    employer.Email = e.Email;
                    employer.Password = e.Password;
                    employer.Etat = e.Etat;
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
        [System.Web.Http.Route("api/employer/delete")]
        public string Delete(Employer e)
        {
            try
            {
                dbContext re = new dbContext();
                Employer employer = (Employer)re.Employers.Where(r => r.Id == e.Id).First();
                re.Employers.Remove(employer);
                re.SaveChanges();
                return "Employer deleted";
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return "Exception : " + Ex.Message;
            }
        }
    }
}
