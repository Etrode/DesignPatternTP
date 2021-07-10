using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternTP.Models
{
    public class SerieModel
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string saison { get; set; }
        public string episode { get; set; }
        public int id_utilisateur { get; set; }

        public UtilisateurModel Utilisateur { get; set; }

        public SerieModel(int id, string titre, string saison, string episode, int id_utilisateur, UtilisateurModel utilisateur)
        {
            this.id = id;
            this.titre = titre;
            this.saison = saison;
            this.episode = episode;
            this.id_utilisateur = id_utilisateur;
            Utilisateur = utilisateur;
        }
    }
}