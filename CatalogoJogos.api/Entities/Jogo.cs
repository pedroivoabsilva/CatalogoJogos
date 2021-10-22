using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogoJogos.api.Entities
{
    public class Jogo
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public decimal Preco { get; set; }
    }
}
