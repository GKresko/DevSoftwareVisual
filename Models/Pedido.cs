namespace LojaLivrosAPI.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
