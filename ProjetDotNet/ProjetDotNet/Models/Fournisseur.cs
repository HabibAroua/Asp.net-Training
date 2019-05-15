using System.ComponentModel.DataAnnotations;

namespace web_api_dot_net_Framework.Models
{
    public class Fournisseur
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        public string Nom
        {
            get;
            set;
        }

        public string Prenom
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

    }
}