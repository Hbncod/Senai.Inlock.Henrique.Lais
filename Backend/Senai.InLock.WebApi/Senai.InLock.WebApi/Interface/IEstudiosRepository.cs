using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interface
{
    interface IEstudiosRepository
    {
        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Retorna todos os Estudios</returns>
        List<EstudiosDomain> ListarEstudios();

    }
}
