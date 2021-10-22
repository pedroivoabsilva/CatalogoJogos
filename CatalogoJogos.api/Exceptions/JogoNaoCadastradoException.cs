﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.api.Exceptions
{
    public class JogoNaoCadastradoException:Exception
    {
        public JogoNaoCadastradoException():base("EsteJogo não está cadastrado")
        {}
    }
}
