namespace LojaLivrosAPI.Models
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }
    }
}
