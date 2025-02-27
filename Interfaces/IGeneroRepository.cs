using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces

    /// Interface para Genero : Contrato
    /// Toda classe que herdar (implementar) essa interface, deverá implementar todos os metodos definidos aqui dentro
    

{
    public interface IGeneroRepository
    {
        //Crud : Metodos
        //C: Create: Cadastrar novo objeto
        //R: Read: Listar todos os objetos
        //U: Update: Alterar objeto
        //D: Delete: Deleto ou excluo um objetos

        //Metodo: Tipo de retorno NomeDoMetodo(Argumentos)

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar(Guid id, Genero genero);

        void Deletar(Guid id);

        Genero BurcarPorId (Guid id);   
    }
}
