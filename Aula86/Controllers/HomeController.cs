using Aula86.AcessoDados;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula86.Controllers
{
    public class HomeController : Controller 
    {
        private readonly IProdutoRepository _repository;
        public HomeController(IProdutoRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public string Obter()
        {
            return "Teste2";
        }

    }
}
