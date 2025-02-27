using System.Linq;
using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Repositories
{

    /// <summary>
    /// Classe que vai implementar a interface IFilmeRepository
    /// Ou seja,vamos implementar os metodos, toda a logicas dos metodos
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {
        private readonly Filmes_Context _context;
        public FilmeRepository(Filmes_Context context) {
            _context = context;
        }
        public void Atualizar(Guid id, Filme filme)
        {
            Filme filmeBuscado = _context.Filme.Find(id);

            if (filmeBuscado != null)
            {
                filmeBuscado.Titulo = filme.Titulo;
                filmeBuscado.IdGenero = filme.IdGenero;
            }

            _context.SaveChanges();
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
               Filme filmeBuscado = _context.Filme.Find(id)!;
               return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Filme novoFilme)
        {
            try
            {
               _context.Filme.Add(novoFilme);
               _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;
                if (filmeBuscado != null)
                {
                    _context.Filme.Remove(filmeBuscado);  
                }  

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filme.Include(g => g.Genero).ToList();
                //.Select(f => new Filme){
                //IdFilme = f.IdFilme,
                //Titulo = f.Titulo,
                //Genero = new Genero
                //{
                //   idGenero = f.IdGenero,
                //   Nome = f.Genero!.Nome
                //}
                
                return listaDeFilmes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Filme> ListarPorGenero(Guid IdGenero)
        {
            try
            {
                List<Filme> listaDeFilmesGenero = _context.Filme.Include(g => g.Genero)
                    .Where(f => f.IdGenero == IdGenero) //aqui vc tem que fazer a condicao
                    .ToList();   
                return listaDeFilmesGenero;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
