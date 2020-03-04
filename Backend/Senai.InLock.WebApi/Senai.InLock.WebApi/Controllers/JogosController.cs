using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using Senai.InLock.WebApi.Repository;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<JogosDomain> ListaDeJogos()
        {
            return _jogosRepository.ListarJogosEEstudios();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarJogo(JogosDomain novojogo)
        {
            _jogosRepository.CadastroJogos(novojogo);
            return StatusCode(201);
        }
    }
}