using System;
using System.Collections.Generic;

namespace SampleLoja.Domain.Entidades
{
    public class Cliente
    {
        

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

  

        //Minha classe cliente tem uma lista de produtos
        public  virtual IEnumerable<Produto> Produtos { get; set; }


        //Comportamento da classe do cliente, alguma promoção algo do tipo
        public bool Clienteespecial(Cliente cliente)
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }
    }
}
