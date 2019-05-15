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
    public class AdminController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/admin/all")]
        // GET client/habib
        public List<Admin> Get()
        {
            using (var context = new dbContext())
            {
                try
                {
                    return context.Admins.ToList();
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
        [System.Web.Http.Route("api/admin/insert")]
        public string Post([FromBody]Admin value)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    context.Admins.Add(value);
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
        [System.Web.Http.Route("api/admin/update")]
        public string update([FromBody] Admin a)
        {
            using (dbContext context = new dbContext())
            {
                try
                {
                    Admin admin = (Admin)context.Admins.Where(r => r.Id == a.Id).First();
                    admin.Nom = a.Nom;
                    admin.Prenom = a.Prenom;
                    admin.Cin = a.Cin;
                    admin.Email = a.Email;
                    admin.Password = a.Password;
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

        // DELETE api/values/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/admin/delete")]
        public string Delete(Admin a)
        {
            try
            {
                dbContext re = new dbContext();
                Admin admin = (Admin)re.Admins.Where(r => r.Id == a.Id).First();
                re.Admins.Remove(admin);
                re.SaveChanges();
                return "Admin deleted";
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception : " + Ex.Message);
                return "Exception : " + Ex.Message;
            }
        }
    }
}
