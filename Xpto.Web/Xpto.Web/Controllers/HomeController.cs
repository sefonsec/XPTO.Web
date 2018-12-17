using System;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Xpto.Persistencia.Context;
using Xpto.Modelo;

namespace Xpto.Web.Controllers
{
    public class HomeController : Controller
    {
        private EFContext db = new EFContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ExtrairDadosArquivos()
        {
            var extrairDados = new Persistencia.ExtrairDados();

            //var caminho = Server.MapPath(@"~/Arquivos").Replace('\\', '/');

            var caminho1 = @"C:\Users\eduardo\source\repos\Stefanini\XPTO\Xpto.Web\Xpto.Web\Arquivos\ARQUIVO1-PLENO.txt";
            var caminho2 = @"C:\Users\eduardo\source\repos\Stefanini\XPTO\Xpto.Web\Xpto.Web\Arquivos\ARQUIVO2-PLENO.txt";

            extrairDados.ExtrairDadosArquivo_1(caminho1);
            extrairDados.ExtrairDadosArquivo_2(caminho2);

            return View();       
        }
    }
}