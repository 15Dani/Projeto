namespace SampleLoja.Domain.Entidades
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nomeproduto { get; set; }
        public decimal Valorproduto { get; set; }
        public bool Disponivel { get; set; }
       
        //O produto está vinculado a meu cliente
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }




    }
}
