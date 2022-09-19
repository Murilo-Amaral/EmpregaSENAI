using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EmpregaSENAI.Core;

namespace EmpregaSENAI.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = $"{Constants.Policies.Empresa}")]
        public ActionResult Empresa()
        {
            return View();
        }

        [Authorize(Policy = $"{Constants.Policies.Aluno}")]
        public ActionResult Aluno()
        {
            return View();
        }
                        //  \/ \/ CHAMADO DE "MAGICAL STRING" DIFICULTA A MANUNTENÇÃO DO CODIGO
        // TROCO ESSE >> [Authorize(Roles = "Adm")] POR ESSE >>
        // [Authorize(Roles = $"{Constants.Roles.Admin}")]
        [Authorize(Roles = $"{Constants.Roles.Admin}")]
        public ActionResult Admin()
        {
            return View();
        }
    }
}
