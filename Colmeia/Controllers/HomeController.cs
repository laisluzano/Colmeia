using Colmeia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Colmeia.Controllers
{
    public class HomeController : Controller
    {

        //bool editFlag = false;

        private Queen checkQueenSession()
        {
            Queen queen = null;

            if (Session["Queen"] == null)
            {
                List<Worker> workers = new List<Worker>();
                workers.Add(new Worker(new string[] { "Coletar nectar; ", "Produção de de mel; " }, "Abelha 1", 1));
                workers.Add(new Worker(new string[] { "Cuidar dos olhos; ", "Ensinar as abelhas bebês; " }, "Abelha 2", 2));
                workers.Add(new Worker(new string[] { "Manuntenção da colméia; ", "Patrulha; " }, "Abelha 3", 3));
                workers.Add(new Worker(new string[] { "Coletor de nectar; ", "Produçãode de mel; ", "Cuidar dos ovos; ", "Ensinar as abelhas bebê; ", "Manunteção da colméia; ", "Patrulha; " }, "Abelha 4", 4));
                queen = new Queen(workers);

                Session["Queen"] = queen;
            }
            else
            {

                queen = (Queen)Session["Queen"];
            }

            return queen;
        }
        public ActionResult Index()
        {
            Queen queen = checkQueenSession();

            return View("Index", queen);
        }

        public ActionResult deleteWorker(int workerId)
        {
            Queen queen = checkQueenSession();
            queen.workers.RemoveAll(i => i.Id == workerId);

            Session["Queen"] = queen;
            return View("Index", queen);
        }

        public ActionResult saveWorker(string workerName, int workerId)
        {
            Queen queen = checkQueenSession();

            Worker wk = queen.workers.Find(i => i.Id == workerId);
            if (wk == null)
                queen.workers.Add(new Worker(workerName, workerId));
            else
                wk.Nome = workerName;

            Session["Queen"] = queen;
            return View("Index", queen);
        }

        public ActionResult Return()
        {
            return RedirectToAction("Index");
        }

        public ActionResult editWorker(int workerId)
        {
            Queen queen = checkQueenSession();
            Worker edit;

            if (workerId != 0)
                edit = queen.workers.Find(i => i.Id == workerId);
            else
                edit = new Worker();

            return View("Edit", edit);
        }

        public ActionResult searchWorker(int workerId)
        {
            Queen queen = checkQueenSession();
            queen.workers.OrderBy(i => i.Id == workerId);
            return View("Index", queen);

        }
    }
}