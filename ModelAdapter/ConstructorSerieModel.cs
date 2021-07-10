using DesignPatternTP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternTP.ModelAdapter
{
    public class ConstructorSerieModel
    {
        public SerieModel Construct(Serie serie)
        {
            return new SerieModel(serie.id, serie.titre, serie.saison, serie.episode, serie.id_utilisateur,
                                     new Models.UtilisateurModel(serie.Utilisateur.id, serie.Utilisateur.nom, serie.Utilisateur.prenom));
        }
    }
}