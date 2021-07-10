using DesignPatternTP.ModelAdapter;
using DesignPatternTP.Utils;
using DesignPatternTP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignPatternTP.Controllers
{
    public class HomeController : Controller
    {

        // Singleton + Fabrique + Adapter  (Dossier DataAccessLayer + ModelAdapter)

        public ActionResult Index(int? offset)
        {
            // Limite
            int limit = 5;
            if (offset == null)
                offset = 0;
            SerieVM vm = new SerieVM();
            serieDBEntities db = (serieDBEntities) SingletonDBSeries.getInstance().getDbContext();
            vm.Total = db.Series.Count();
            List<Serie> lSerie = db.Series.OrderBy(u => u.id_utilisateur).ThenBy(n => n.titre).ThenBy(s => s.saison).ThenBy(e => e.episode)
                                          .Skip((int)offset * limit).Take(limit).ToList();

            // Initialisation adapteur entité > model
            IAdapterSerieModel iAdapterSerieModel = new AdapterSerieModel(new ConstructorSerieModel());

            foreach (Serie serie in lSerie)
            {
                vm.ListeSeries.Add(iAdapterSerieModel.Adapter(serie));
            }
            int nbButton = vm.Total / limit;
            if (vm.Total % limit > 0)
                nbButton++;
            vm.Pages = nbButton;
            return View(vm);
        }

        public ActionResult Nouveau()
        {
            Serie serie = new Serie();
            serieDBEntities db = (serieDBEntities) SingletonDBSeries.getInstance().getDbContext();
            ViewBag.Organisations = new SelectList((from u in db.Utilisateurs.ToList() select new
                                                    {
                                                        id = u.id,
                                                        prenom_nom = u.prenom + " " + u.nom
                                                    })
                                                        , "id", "prenom_nom");
            return View(serie);
        }

        public ActionResult Enregistrer(Serie model)
        {
            serieDBEntities db = (serieDBEntities) SingletonDBSeries.getInstance().getDbContext();
            
            db.Series.Add(model);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Modification(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(405);
            }
            else
            {

                serieDBEntities db = (serieDBEntities) SingletonDBSeries.getInstance().getDbContext();
                
                var serie = db.Series.First(x => x.id == id);
                ViewBag.Organisations = new SelectList((from u in db.Utilisateurs.ToList()
                                                        select new
                                                        {
                                                            id = u.id,
                                                            prenom_nom = u.prenom + " " + u.nom
                                                        })
                                                            , "id", "prenom_nom");
                return View(serie);
                
            }
        }

        [HttpPost]
        public ActionResult Modification(Serie model)
        {

            serieDBEntities db = (serieDBEntities) SingletonDBSeries.getInstance().getDbContext();

            Serie serie = db.Series.First(x => x.id == model.id);
            UpdateModel(serie);

            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return null;
            }
        }

        public ActionResult Suppression(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(405);
            }
            else
            {
                serieDBEntities db = (serieDBEntities) SingletonDBSeries.getInstance().getDbContext();
                
                var serie = db.Series.First(x => x.id == id);
                db.Series.Remove(serie);

                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return null;
                }
            }
        }


    }
}