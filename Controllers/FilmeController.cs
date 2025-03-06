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
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        /// <summary>
        /// Endpoint para listar os filmes cadastrados
        /// </summary>
        /// <returns>Filmes cadastrados</returns>
        [HttpGet]
        public IActionResult Get() {
            try
            {

                return Ok(_filmeRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme">nome do filme cadastrado</param>
        /// <returns>Novo Filme</returns>
        [HttpPost]
        public IActionResult Post(Filme novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar um filme pelo seu id 
        /// </summary>
        /// <param name="id"> id do filme buscado</param>
        /// <returns>Filme buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);
                return Ok(filmeBuscado);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }


        /// <summary>
        /// Endpoint para atualizar o filme
        /// </summary>
        /// <param name="id">id filme</param>
        /// <param name="filme">nome</param>
        /// <returns>filme atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Filme filme)
        {
            try
            {
                _filmeRepository.Atualizar(id, filme);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint para apagar um filme
        /// </summary>
        /// <param name="id">id filme</param>
        /// <returns>nulo</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Endpoint para listar os filmes pelo id gênero
        /// </summary>
        /// <param name="Id">id gênero</param>
        /// <returns>filmes</returns>
        [HttpGet("listarporgenero/{Id}")]
        public IActionResult GetByGenero(Guid Id)
        {
            try
            {
               List<Filme> ListarPorGenero = _filmeRepository.ListarPorGenero(Id);
               return Ok (ListarPorGenero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
