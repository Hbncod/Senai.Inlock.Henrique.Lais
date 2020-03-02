using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using Senai.InLock.WebApi.Repository;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudiosRepository { get; set; }

        public EstudiosController()
        {
            _estudiosRepository = new EstudiosRepository();
        }

        [HttpGet]
        public IEnumerable<EstudiosDomain> GetEstudios()
        {
            return _estudiosRepository.ListarEstudios();
        }


    }
}