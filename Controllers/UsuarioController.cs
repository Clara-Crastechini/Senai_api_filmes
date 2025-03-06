using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        /// <summary>
        /// Endpoint para Cadastrar um novo usuario
        /// </summary>
        /// <param name="novoGenero">nome do usuario cadastrado</param>
        /// <returns>Novo usuario</returns>
        [HttpPost]

        public IActionResult Post(Usuario usuario) 
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(281, usuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar um usuario pelo seu id 
        /// </summary>
        /// <param name="id"> id do usuario buscado</param>
        /// <returns>Usuario Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                return Ok(usuarioBuscado);

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }
                return null;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        /// <summary>
        /// Endpoint para buscar um usuario pelo seu email e senha 
        /// </summary>
        /// <param name="id">email e senha buscado</param>
        /// <returns>Usuario Buscado</returns>
        [HttpGet("BuscarPorEmailESenha")]
        public IActionResult GetByEmailAndSenha(string email, string senha) 
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);

                if (usuarioBuscado != null)
                { return Ok(usuarioBuscado); 
                }
                return null!;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
