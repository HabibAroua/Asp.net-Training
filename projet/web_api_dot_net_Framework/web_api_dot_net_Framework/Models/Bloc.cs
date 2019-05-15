using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web_api_dot_net_Framework.Models
{
    public class Bloc
    {
        [Key]
        public int Id
        {
            get;
            set;
        }
        public string Libelle
        {
            get;
            set;
        }
        public string Position
        {
            set;
            get;
        }
    }
}