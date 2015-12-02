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
            return View(getPessoas());
        }

        public ActionResult xunxo()
        {
            ViewBag.onlyTable = true;

            return View("Index", getPessoas());
        }

        public IList<Pessoa> getPessoas()
        {
            System.Threading.Thread.Sleep(1000);

            IList<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < 10; i++)
            {
                pessoas.Add(new Pessoa()
                {
                    ID = i,
                    Documento = i + "2" + (i % 3) + "." + i + "5" + (i % 5) + "." + i + "2" + (i % 3),
                    Idade = (i + 15),
                    Nome = i % 3 == 0 ? "" : "xurupita ",
                    SobreNome = "tralala",
                    CodLeiAto = "cd. " + i + 36,
                    NomeLeiAto = "Lei ato " + i,
                    VersLeiAto = "v. " + i * 1.8764
                });
            }

            return pessoas;
        }
    }
}