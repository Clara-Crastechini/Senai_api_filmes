using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        /// <summary>
        /// Endpoint para listar os gêneros cadastrados
        /// </summary>
        /// <returns>Gêneros cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());
            }
            catch (Exception e)
            {

       
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint para Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">nome do gênero cadastrado</param>
        /// <returns>Novo gênero</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        /// <summary>
        /// Endpoint para buscar um Gênero pelo seu id 
        /// </summary>
        /// <param name="id"> id do Gênero buscado</param>
        /// <returns>Gênero Buscado</returns>
        [Authorize]
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id) {
            try
            {
                Genero generoBuscado = _generoRepository.BurcarPorId(id);

                return Ok(generoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint para atualizar o gênero
        /// </summary>
        /// <param name="id">id gênero</param>
        /// <param name="genero">nome</param>
        /// <returns>Gênero atualizado</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                _generoRepository.Atualizar(id, genero);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para apagar um gênero
        /// </summary>
        /// <param name="id">id gênero</param>
        /// <returns>nulo</returns>
        [Authorize]
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _generoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
