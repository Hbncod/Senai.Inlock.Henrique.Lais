using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.DataViewModel;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using Senai.InLock.WebApi.Repository;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuariosRepository();
        }
        [HttpPost]
        public IActionResult Login(UsuarioViewModel login)
        {
            UsuariosDomain usuariobuscado = _usuarioRepository.BuscarEmailESenha(login);

            if(usuariobuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,usuariobuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuariobuscado.Id_Usuario.ToString()),
                new Claim(ClaimTypes.Role, usuariobuscado.Fk_TipoUsuario.ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Inlock-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "InLock.WebApi",                // emissor do token
                audience: "InLock.WebApi",              // destinatário do token
                claims: claims,                         // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),   // tempo de expiração
                signingCredentials: creds               // credenciais do token
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }

    
    
}