using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationTeste.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            IList<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < 200; i++)
            {
                pessoas.Add(new Pessoa()
                {
                    ID = i,
                    Documento = i + "2" + (i % 3) + "." + i + "5" + (i % 5) + "." + i + "2" + (i % 3),
                    Idade = (i + 15),
                    Nome = "xurupita ",
                    SobreNome = "tralala"
                });
            }

            return View(pessoas);
        }

        public ActionResult xunxo()
        {
            IList<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < 200; i++)
            {
                pessoas.Add(new Pessoa()
                {
                    ID = i,
                    Documento = i + "2" + (i % 3) + "." + i + "5" + (i % 5) + "." + i + "2" + (i % 3),
                    Idade = (i + 15),
                    Nome = "xurupita ",
                    SobreNome = "tralala"
                });
            }

            ViewBag.onlyTable = true;

            return View("Index", pessoas);
        }
	}
}