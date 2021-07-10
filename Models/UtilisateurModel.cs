using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternTP.Models
{
    public class UtilisateurModel
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }

        public UtilisateurModel(int id, string nom, string prenom)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
        }
    }
}