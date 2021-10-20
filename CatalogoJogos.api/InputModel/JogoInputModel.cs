﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.api.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage ="O nome do jogo deve conter entre 3 á 100 caractéres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome do jogo deve conter no máximo 100 caractéres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "O preço do jogo deve ser no mínimo 1 real e no máximo 1000 reais")]
        public double Preco { get; set; }
    }
}
